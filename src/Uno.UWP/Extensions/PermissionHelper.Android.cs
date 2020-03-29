﻿#if __ANDROID__

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Extensions
{
	public partial class PermissionsHelper
	{
		private static TaskCompletionSource<bool> _permissionCompletionSource;

		/// <summary>
		/// Return null on error, or array of permission to be asked for (not granted at this time). Both parameters can be null
		/// </summary>
		/// <param name="requiredPermissions">Permissions that are required. Can be null.</param>
		/// <param name="optionalPermissions">Permissions that are required only if declared in Manifest. Can be null.</param>
		/// <returns>Array of all permission that is not granted at this moment (can be empty!), or null if some error occured</returns>
		public static string[] MissingPermissions(string[] requiredPermissions, string[] optionalPermissions)
		{
			// since API 29, we should do something more:
			// https://developer.android.com/reference/android/content/pm/PackageInstaller.SessionParams.html#setWhitelistedRestrictedPermissions(java.util.Set%3Cjava.lang.String%3E)

			// do we have declared permissions in Manifest?
			Android.Content.Context context = Android.App.Application.Context;
			Android.Content.PM.PackageInfo packageInfo =
				context.PackageManager.GetPackageInfo(context.PackageName, Android.Content.PM.PackageInfoFlags.Permissions);
			var manifestPermissions = packageInfo?.RequestedPermissions;
			if (manifestPermissions is null)
				return null;

			// test required permissions
			if (requiredPermissions != null)
			{
				foreach (string permission in requiredPermissions)
				{
					bool foundInManifest = false;
					foreach (string oPerm in manifestPermissions)
					{
						if (oPerm.Equals(permission, StringComparison.OrdinalIgnoreCase))
							foundInManifest = true;

					}
					if (!foundInManifest) return null;
				}
			}

			// prepare list of all permissions
			var allPermissions = new List<string>();
			if (requiredPermissions != null)
				allPermissions.AddRange(requiredPermissions.ToList());

			// add all optional permission, found in Manifest
			if (optionalPermissions != null)
			{
				foreach (string permission in optionalPermissions)
				{
					foreach (string oPerm in manifestPermissions)
					{
						if (oPerm.Equals(permission, StringComparison.OrdinalIgnoreCase))
							allPermissions.Add(permission);
					}
				}
			}

			// prepare list of permission to ask for
			var askForPermission = new List<string>();

			// check if permission is granted
			foreach (var permission in allPermissions)
			{
				if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(context, permission)
						!= Android.Content.PM.Permission.Granted)
				{
					askForPermission.Add(permission);
				}
			}

			return askForPermission.ToArray();

		}


		/// <summary>
		/// Return true if requiredPermission is granted. Show dialog asking for missing permission.
		/// </summary>
		/// <param name="requiredPermission">Permission that are required</param>
		/// <returns>Bool if permission is granted, false if not</returns>
		public static Task<bool> AndroidPermissionAsync(string requiredPermission)
			=> AndroidPermissionAsync(new string[] { requiredPermission }, null);

		/// <summary>
		/// Return true if granted are: requiredPermission, and optionalPermissions (if mentioned in Manifest). Show dialog asking for missing permissions..
		/// </summary>
		/// <param name="requiredPermissions">Permission that are required</param>
		/// <param name="optionalPermissions">Permission that are required only if declared in Manifest</param>
		/// <returns>Bool if all permissions are granted, false if any of them is not granted</returns>
		public static Task<bool> AndroidPermissionAsync(string requiredPermission, string optionalPermission)
			=> AndroidPermissionAsync(new string[] { requiredPermission }, new string[] { optionalPermission });


		/// <summary>
		/// Return true if granted are: all requiredPermissions, and all optionalPermissions mentioned in Manifest. Show dialog asking for missing permissions. Both parameters can be null.
		/// </summary>
		/// <param name="requiredPermissions">Permissions that are required. Can be null.</param>
		/// <param name="optionalPermissions">Permissions that are required only if declared in Manifest. Can be null.</param>
		/// <returns>Bool if all permissions are granted, false if any of them is not granted</returns>
		public static Task<bool> AndroidPermissionAsync(string[] requiredPermissions, string[] optionalPermissions)
		{
			// prepare return value
			_permissionCompletionSource = new TaskCompletionSource<bool>();

			var askForPermission = MissingPermissions(requiredPermissions, optionalPermissions);
			if (askForPermission is null)
			{
				_permissionCompletionSource.SetResult(false); // signal: "permission denied", although there is some error
				return _permissionCompletionSource.Task;
			}


			if (askForPermission.Count() < 1)
			{
				_permissionCompletionSource.SetResult(true); // signal: "permission granted"
				return _permissionCompletionSource.Task;
			}

			// system dialog asking for permission

			var intermediaryIntent = new Android.Content.Intent(Android.App.Application.Context, typeof(AskForPermission));
			// put parameters into Intent
			intermediaryIntent.PutExtra("permissions", askForPermission.ToArray());

			// wrap it in Task
			AskForPermission.AfterDialog += AfterPermissionDialog;

			Android.App.Application.Context.StartActivity(intermediaryIntent);

			void AfterPermissionDialog(object sender, bool granted)
			{
				AskForPermission.AfterDialog -= AfterPermissionDialog;
				_permissionCompletionSource.SetResult(granted);
			}
			return _permissionCompletionSource.Task;
		}


		[Android.App.Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
		internal class AskForPermission : Android.App.Activity
		{
			internal static event EventHandler<bool> AfterDialog;

			protected override void OnCreate(Android.OS.Bundle savedInstanceState)
			{
				base.OnCreate(savedInstanceState);

				var caller = base.Intent.Extras;
				var permissionsArray = caller?.GetStringArray("permissions");
				if (permissionsArray is null)
				{
					throw new Exception("AskForPermission:OnCreate - empty permission array in Intent.Extras?");
				}

				RequestPermissions(permissionsArray, 1);

			}

			public override void OnRequestPermissionsResult(int requestCode, String[] permissions, Android.Content.PM.Permission[] grantResults)
			{
				base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

				bool allGranted = true;

				for (int i = 0; i < grantResults.Count(); i++)
				{
					if (grantResults[i] != Android.Content.PM.Permission.Granted)
					{
						allGranted = false;
					}
				}

				AfterDialog?.Invoke(null, allGranted);
				Finish();   // means activity.finish
			}

		}

	}

}

#endif 
