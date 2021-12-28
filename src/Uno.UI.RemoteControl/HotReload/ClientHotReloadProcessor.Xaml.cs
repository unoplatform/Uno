﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.RemoteControl.HotReload.Messages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
#if __IOS__
using _View = UIKit.UIView;
#else
using _View = Windows.UI.Xaml.FrameworkElement;
#endif

#if __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#elif __ANDROID__
using Uno.UI;
#endif

namespace Uno.UI.RemoteControl.HotReload
{
	partial class ClientHotReloadProcessor
	{
		private async Task ReloadFile(FileReload fileReload)
		{
			Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(
				Windows.UI.Core.CoreDispatcherPriority.Normal,
				async () =>
			{
				try
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().LogDebug($"Reloading changed file [{fileReload.FilePath}]");
					}

					var uri = new Uri("file:///" + fileReload.FilePath.Replace("\\", "/"));

					Application.RegisterComponent(uri, fileReload.Content);

					foreach (var instance in EnumerateInstances(Window.Current.Content, uri))
					{
						switch (instance)
						{
#if __IOS__
							case UserControl userControl:
								SwapViews(userControl, XamlReader.LoadUsingXClass(fileReload.Content) as UIKit.UIView);
								break;
#endif
							case ContentControl content:
								SwapViews(content, XamlReader.LoadUsingXClass(fileReload.Content) as ContentControl);
								break;
						}
					}

					if (ResourceResolver.RetrieveDictionaryForFilePath(uri.AbsolutePath) is { } targetDictionary)
					{
						var replacementDictionary = (ResourceDictionary)XamlReader.Load(fileReload.Content);
						targetDictionary.CopyFrom(replacementDictionary);
						Application.Current.UpdateResourceBindingsForHotReload();
					}
				}
				catch (Exception e)
				{
					if (this.Log().IsEnabled(LogLevel.Error))
					{
						this.Log().LogError($"Failed reloading changed file [{fileReload.FilePath}]", e);
					}

					await _rcClient.SendMessage(
						new HotReload.Messages.XamlLoadError(
							filePath: fileReload.FilePath,
							exceptionType: e.GetType().ToString(),
							message: e.Message,
							stackTrace: e.StackTrace));
				}
			});
		}

		private IEnumerable<UIElement> EnumerateInstances(object instance, Uri baseUri)
		{
			if (
				instance is FrameworkElement fe && baseUri.OriginalString == fe.BaseUri?.OriginalString)
			{
				yield return fe;
			}
			else if (instance != null)
			{
				IEnumerable<IEnumerable<UIElement>> Dig()
				{
					switch (instance)
					{
						case Panel panel:
							foreach (var child in panel.Children)
							{
								yield return EnumerateInstances(child, baseUri);
							}
							break;

						case Border border:
							yield return EnumerateInstances(border.Child, baseUri);
							break;

						case ContentControl control when control.ContentTemplateRoot != null || control.Content != null:
							yield return EnumerateInstances(control.ContentTemplateRoot ?? control.Content, baseUri);
							break;

						case Control control:
							yield return EnumerateInstances(control.TemplatedRoot, baseUri);
							break;

						case ContentPresenter presenter:
							yield return EnumerateInstances(presenter.Content, baseUri);
							break;
					}
				}

				foreach (var inner in Dig())
				{
					foreach (var validElement in inner)
					{
						yield return validElement;
					}
				}
			}
		}

		private static void SwapViews(_View oldView, _View newView)
		{
			var parentAsContentControl = oldView.GetVisualTreeParent() as ContentControl;
			parentAsContentControl = parentAsContentControl ?? (oldView.GetVisualTreeParent() as ContentPresenter)?.FindFirstParent<ContentControl>();

			if (parentAsContentControl?.Content == oldView)
			{
				parentAsContentControl.Content = newView;
			}
			else
			{
				VisualTreeHelper.SwapViews(oldView, newView);
			}

			PropagateProperties(oldView as FrameworkElement, newView as FrameworkElement);
		}

		private static void PropagateProperties(FrameworkElement oldView, FrameworkElement newView)
		{
			if (oldView == null || newView == null)
			{
				return;
			}
			newView.BaseUri = oldView.BaseUri;

			if (oldView is Page oldPage && newView is Page newPage)
			{
				newPage.Frame = oldPage.Frame;
			}
		}
	}
}
