﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Webkit;
using Uno.Disposables;
using Uno.Foundation.Logging;

namespace Uno.UI.Xaml.Controls;

internal class InternalWebChromeClient : WebChromeClient
{
	private IValueCallback _filePathCallback;

	readonly SerialDisposable _fileChooserTaskDisposable = new SerialDisposable();

	public override bool OnShowFileChooser(
		Android.Webkit.WebView webView,
		IValueCallback filePathCallback,
		FileChooserParams fileChooserParams)
	{
		_filePathCallback = filePathCallback;

		var cancellationDisposable = new CancellationDisposable();
		_fileChooserTaskDisposable.Disposable = cancellationDisposable;

		Task.Run(async () =>
		{
			try
			{
				await StartFileChooser(cancellationDisposable.Token, fileChooserParams);
			}
			catch (Exception e)
			{
				this.Log().Error(e.Message, e);
			}
		});

		return true;
	}

	public override void OnPermissionRequest(PermissionRequest request) => request.Grant(request.GetResources());

	/// <summary>
	/// Uses the Activity Tracker to start, then return an Activity
	/// </summary>
	/// <typeparam name="T">A BaseActivity to start</typeparam>
	/// <param name="ct">CancellationToken</param>
	/// <returns>The BaseActivity that just started (OnResume called)</returns>
	private async Task<T> StartActivity<T>(CancellationToken ct) where T : BaseActivity
	{
		//Get topmost Activity
		var currentActivity = BaseActivity.Current;

		if (currentActivity != null)
		{
			//Set up event handler for when activity changes
			var finished = new TaskCompletionSource<BaseActivity>();

			EventHandler<CurrentActivityChangedEventArgs> handler = null;
			handler = new EventHandler<CurrentActivityChangedEventArgs>((snd, args) =>
			{
				if (args?.Current != null)
				{
					finished.TrySetResult(args.Current);
					BaseActivity.CurrentChanged -= handler;
				}
			});

			BaseActivity.CurrentChanged += handler;

			//Start a new DelegateActivity
			currentActivity.StartActivity(typeof(T));

			//Wait for it to be the current....
			var newCurrent = await finished.Task;

			//return the activity.
			return newCurrent as T;
		}

		return null;
	}

	private async Task StartFileChooser(CancellationToken ct, FileChooserParams fileChooserParams)
	{
		var intent = fileChooserParams.CreateIntent();
		//Get an invisible (Transparent) Activity to handle the Intent
		var delegateActivity = await StartActivity<DelegateActivity>(ct);

		var result = await delegateActivity.GetActivityResult(ct, intent);

		_filePathCallback.OnReceiveValue(FileChooserParams.ParseResult((int)result.ResultCode, result.Intent));
	}
}
