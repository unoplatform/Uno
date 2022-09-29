﻿#nullable disable

#pragma warning disable 618

using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace Uno.UI.ViewManagement
{
	public delegate void ActivityActionModeFinishedHandler(ActionMode mode);
	public delegate void ActivityActionModeStartedHandler(ActionMode mode);
	public delegate void ActivityActivityReenterHandler(int resultCode, Intent data);
	public delegate void ActivityActivityResultHandler(int requestCode, Result resultCode, Intent data);
	public delegate void ActivityAttachedToWindowHandler();
	public delegate void ActivityAttachFragmentHandler(Fragment fragment);
	public delegate bool ActivityContextItemSelectedHandler(IMenuItem item);
	public delegate void ActivityBackPressedHandler();
	public delegate void ActivityChildTitleChangedHandler(Activity childActivity, ICharSequence title);
	public delegate void ActivityConfigurationChangedHandler(Configuration newConfig);
	public delegate void ActivityContentChangedHandler();
	public delegate void ActivityContextMenuClosedHandler(IMenu menu);
	public delegate void ActivityCreateHandler(Bundle savedInstanceState);
	public delegate void ActivityCreateWithPersistedStateHandler(Bundle savedInstanceState, PersistableBundle persistentState);
	public delegate void ActivityCreateContextMenuHandler(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo);
	public delegate ICharSequence ActivityCreateDescriptionFormattedHandler();
	public delegate void ActivityCreateNavigateUpTaskStackHandler(TaskStackBuilder builder);
	public delegate bool ActivityCreateOptionsMenuHandler(IMenu menu);
	public delegate bool ActivityCreatePanelMenuHandler(int featureId, IMenu menu);
	public delegate View ActivityCreatePanelViewHandler(int featureId);
	public delegate bool ActivityCreateThumbnailHandler(Bitmap outBitmap, Canvas canvas);
	public delegate View ActivityCreateViewHandler(string name, Android.Content.Context context, IAttributeSet attrs);
	public delegate View ActivityCreateViewWithParentHandler(View parent, string name, Android.Content.Context context, IAttributeSet attrs);
	public delegate void ActivityDestroyHandler();
	public delegate void ActivityDetachedFromWindowHandler();
	public delegate void ActivityEnterAnimationCompleteHandler();
	public delegate bool ActivityGenericMotionEventHandler(MotionEvent e);
	public delegate bool ActivityKeyDownHandler(Keycode keyCode, KeyEvent e);
	public delegate bool ActivityKeyLongPressHandler(Keycode keyCode, KeyEvent e);
	public delegate bool ActivityKeyMultipleHandler(Keycode keyCode, int repeatCount, KeyEvent e);
	public delegate bool ActivityKeyShortcutHandler(Keycode keyCode, KeyEvent e);
	public delegate bool ActivityKeyUpHandler(Keycode keyCode, KeyEvent e);
	public delegate void ActivityLowMemoryHandler();
	public delegate bool ActivityMenuOpenedHandler(int featureId, IMenu menu);
	public delegate bool ActivityNavigateUpHandler();
	public delegate bool ActivityNavigateUpFromChildHandler(Activity child);
	public delegate void ActivityNewIntentHandler(Intent intent);
	public delegate bool ActivityOptionsItemSelectedHandler(IMenuItem item);
	public delegate void ActivityOptionsMenuClosedHandler(IMenu menu);
	public delegate void ActivityPanelClosedHandler(int featureId, IMenu menu);
	public delegate void ActivityPauseHandler();
	public delegate void ActivityPostCreateHandler(Bundle savedInstanceState);
	public delegate void ActivityPostCreateWithPersistedStateHandler(Bundle savedInstanceState, PersistableBundle persistentState);
	public delegate void ActivityPostResumeHandler();
	public delegate void ActivityPrepareNavigateUpTaskStackHandler(TaskStackBuilder builder);
	public delegate bool ActivityPrepareOptionsMenuHandler(IMenu menu);
	public delegate bool ActivityPrepareOptionsPanelHandler(View view, IMenu menu);
	public delegate bool ActivityPreparePanelHandler(int featureId, View view, IMenu menu);
	public delegate void ActivityProvideAssistDataHandler(Bundle data);
	public delegate void ActivityRequestPermissionsResultWithResultsHandler(int requestCode, string[] permissions, Permission[] grantResults);
	public delegate void ActivityRestartHandler();
	public delegate void ActivityRestoreInstanceStateHandler(Bundle savedInstanceState);
	public delegate void ActivityRestoreInstanceStateWithPersistedStateHandler(Bundle savedInstanceState, PersistableBundle persistentState);
	public delegate void ActivityResumeHandler();
	public delegate void ActivityResumeFragmentsHandler();
	public delegate Java.Lang.Object ActivityRetainCustomNonConfigurationInstanceHandler();
	public delegate void ActivitySaveInstanceStateHandler(Bundle outState);
	public delegate void ActivitySaveInstanceStateWithPersistedStateHandler(Bundle outState, PersistableBundle outPersistentState);
	public delegate bool ActivitySearchRequestedHandler();
	public delegate void ActivityStartHandler();
	public delegate void ActivityStateNotSavedHandler();
	public delegate void ActivityStopHandler();
	public delegate void ActivityTitleChangedHandler(ICharSequence title, Color color);
	public delegate void ActivityTopResumedActivityChangedHandler(bool isTopResumedActivity);
	public delegate bool ActivityTouchEventHandler(MotionEvent e);
	public delegate bool ActivityTrackballEventHandler(MotionEvent e);
	public delegate void ActivityTrimMemoryHandler(TrimMemory level);
	public delegate void ActivityUserInteractionHandler();
	public delegate void ActivityUserLeaveHintHandler();
	public delegate void ActivityVisibleBehindCanceledHandler();
	public delegate void ActivityWindowAttributesChangedHandler(WindowManagerLayoutParams @params);
	public delegate void ActivityWindowFocusChangedHandler(bool hasFocus);
	public delegate ActionMode ActivityWindowStartingActionModeHandler(ActionMode.ICallback callback);
}
