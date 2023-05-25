using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.UI.Xaml.Controls;

public partial class MediaTransportControls_partial // dxaml\xcp\dxaml\lib\MediaTransportControls_Partial.h
{
	//#define CREATE_MEDIA_POINTER_EVENT_HANDLER(pfnEventHandler)               \
	//            new ClassMemberEventHandler<                                  \
	//                    MediaTransportControls,                               \
	//                    IMediaTransportControls,                              \
	//                    xaml_input::IPointerEventHandler,                     \
	//                    IInspectable,                                         \
	//                    xaml_input::IPointerRoutedEventArgs>(this, pfnEventHandler)

	//#define CREATE_MEDIA_KEY_EVENT_HANDLER(pfnEventHandler)                   \
	//            new ClassMemberEventHandler<                                  \
	//                    MediaTransportControls,                               \
	//                    IMediaTransportControls,                              \
	//                    xaml_input::IKeyEventHandler,                         \
	//                    IInspectable,                                         \
	//                    xaml_input::IKeyRoutedEventArgs>(this, pfnEventHandler)

	// Indicates which parent MTC using
	//enum MTCParent
	//{
	//    MTCParent_None,
	//    MTCParent_MediaElement,
	//    MTCParent_MediaPlayerElement
	//};

	//// Indicates MediaPlayer Property
	//enum MediaPlayer_Property
	//{
	//    MediaPlayer_MediaOpened,
	//    MediaPlayer_MediaFailed,
	//    MediaPlayer_Position,
	//    MediaPlayer_Volume,
	//    MediaPlayer_Mute,
	//    MediaPlayer_DownloadProgress,
	//    MediaPlayer_CurrentState,
	//    MediaPlayer_NaturalDuration,
	//    MediaPlayer_Source,
	//    MediaPlayer_ItemChanged,
	//    MediaPlayer_PlaybackRate,
	//    MediaPlayer_MediaBreak_CurrentState,
	//    MediaPlayer_MediaBreak_Position,
	//    MediaPlayer_MediaBreak_DownloadProgress,
	//    MediaPlayer_Repeat
	//};

	//struct TrackFields
	//{
	//    wrl_wrappers::HString label;
	//    wrl_wrappers::HString name;
	//    wrl_wrappers::HString language;
	//    wrl_wrappers::HString id;
	//    wrl_wrappers::HString subtype;
	//    wrl_wrappers::HString channelCount;
	//    int trackIndex;

	//    TrackFields() { }
	//    TrackFields(const TrackFields& fields)
	//    {
	//        label.Set(fields.label.Get());
	//        name.Set(fields.name.Get());
	//        language.Set(fields.language.Get());
	//        id.Set(fields.id.Get());
	//        subtype.Set(fields.subtype.Get());
	//        channelCount.Set(fields.channelCount.Get());
	//        trackIndex = fields.trackIndex;
	//    }
	//};
}
public partial class MediaTransportControls_partial // dxaml\xcp\dxaml\lib\MediaTransportControls_Partial.h
{
	//public:
	//// Creates a new instance of the MediaTransportControls class and
	//// associates it with provided MediaElement.
	//static _Check_return_ HRESULT Create(_Outptr_ MediaTransportControls** ppMediaTransportControls);

	//_Check_return_ HRESULT InitializeTransportControls(_In_ xaml_controls::IMediaElement* pMediaElement);
	//_Check_return_ HRESULT InitializeTransportControls(_In_ xaml_controls::IMediaPlayerElement* pMediaPlayerElement);

	//_Check_return_ HRESULT DeinitializeTransportControls();
	//_Check_return_ HRESULT DeinitializeTransportControlsFromME();
	//_Check_return_ HRESULT DeinitializeTransportControlsFromMPE();

	//_Check_return_ HRESULT Enable();
	//_Check_return_ HRESULT EnableFromME();

	//_Check_return_ HRESULT Disable();
	//_Check_return_ HRESULT DisableFromME();


	//_Check_return_ HRESULT InitializeVisualState();
	//_Check_return_ HRESULT InitializeVisualStateFromME();
	//_Check_return_ HRESULT InitializeVisualStateFromMPE();

	//_Check_return_ HRESULT UpdateVisualState(_In_ bool bUseTransitions = true);
	//_Check_return_ HRESULT UpdateVisualStateFromME(_In_ bool bUseTransitions = true);
	//_Check_return_ HRESULT UpdateVisualStateFromMPE(_In_ bool bUseTransitions = true);

	//_Check_return_ HRESULT UpdateAudioSelectionFlyout();
	//_Check_return_ HRESULT UpdateAudioSelectionFlyoutFromME();
	//_Check_return_ HRESULT UpdateAudioSelectionFlyoutFromMPE();

	//_Check_return_ HRESULT UpdateCCSelectionFlyout();
	//_Check_return_ HRESULT UpdateCCSelectionFlyoutFromME();
	//_Check_return_ HRESULT UpdateCCSelectionFlyoutFromMPE();

	//_Check_return_ HRESULT UpdatePlaybackRateFlyout();

	//void ReleaseMenuFlyoutItemClickHandlers();

	//void ReleaseCCSelectionMenuFlyoutItemClickHandlers();

	//void ReleasePlaybackRateMenuFlyoutItemClickHandlers();

	//BOOLEAN GetIsEnabled() { return m_transportControlsEnabled; }

	//_Check_return_ HRESULT OnOwnerPropertyChanged(_In_ KnownPropertyIndex propertyIndex);
	//_Check_return_ HRESULT OnOwnerMPEPropertyChanged(_In_ KnownPropertyIndex propertyIndex);

	//_Check_return_ HRESULT AddToFullWindowMediaRoot();

	//static _Check_return_ HRESULT SetMediaPlayerElementFullWindow(ctl::ComPtr<xaml_controls::IMediaPlayerElement> spMediaPlayer, BOOLEAN value);

	//_Check_return_ HRESULT UpdateAfterEnteringFullWindow();
	//_Check_return_ HRESULT SetFocusAfterEnteringFullWindowMode();
	//_Check_return_ HRESULT HandleExitFullWindowMode();

	//_Check_return_ HRESULT AddToMediaElement();
	//_Check_return_ HRESULT RemoveFromFullWindowMediaRoot();
	//_Check_return_ HRESULT RemoveFromMediaElement();


	//_Check_return_ HRESULT HandleMediaFailed();
	//_Check_return_ HRESULT HandleMediaFailed(_In_ wmp::IMediaPlayerFailedEventArgs* pArgs);
	//_Check_return_ HRESULT HandleItemMediaFailed(_In_ wmp::IMediaPlaybackItemFailedEventArgs* pArgs);

	//BOOLEAN GetControlPanelIsVisible() { return m_controlPanelIsVisible; }

	//// Used to handle back button presses on phone
	//_Check_return_ HRESULT OnBackButtonPressedImpl(_Out_ BOOLEAN* returnValue);

	//_Check_return_ HRESULT ReleasePlaybackItemReference();

	//_Check_return_ HRESULT SetThumbnailImage(_In_ wsts::IInputStream* pstream);
	//IFACEMETHOD(add_ThumbnailRequested)(_In_ wf::ITypedEventHandler<xaml_controls::MediaTransportControls*, xaml_media::MediaTransportControlsThumbnailRequestedEventArgs*>* pValue, _Out_ EventRegistrationToken* ptToken) override;
	//IFACEMETHOD(remove_ThumbnailRequested)(_In_ EventRegistrationToken tToken) override;

	//_Check_return_ HRESULT EnterImpl(
	//	_In_ XBOOL bLive,
	//	_In_ XBOOL bSkipNameRegistration,
	//	_In_ XBOOL bCoercedIsEnabled,
	//	_In_ XBOOL bUseLayoutRounding) sealed override;

	//_Check_return_ HRESULT ShowImpl() { return ShowControlPanel(); }
	//_Check_return_ HRESULT HideImpl() { return HideControlPanel(true /*hideImmediately*/); }

	//protected:
	//MediaTransportControls();

	//~MediaTransportControls();

	//IFACEMETHOD(OnApplyTemplate)() override;

	//_Check_return_ HRESULT Initialize() override;

	//_Check_return_ HRESULT OnPropertyChanged2(_In_ const PropertyChangedParams& args) override;

	//_Check_return_ HRESULT LeaveImpl(
	//	_In_ XBOOL bLive,
	//	_In_ XBOOL bSkipNameRegistration,
	//	_In_ XBOOL bCoercedIsEnabled,
	//	_In_ XBOOL bVisualTreeBeingReset) sealed override;

	//private:
	//_Check_return_ HRESULT GetComponentSizeConstants() noexcept;
	//_Check_return_ HRESULT HookupPartsAndHandlers();
	//_Check_return_ HRESULT HookupVolumeAndProgressPartsAndHandlers();
	//_Check_return_ HRESULT MoreControls();

	//_Check_return_ HRESULT InitializeAudio();
	//_Check_return_ HRESULT InitializeVideo();
	//_Check_return_ HRESULT InitializeVolume();

	//_Check_return_ HRESULT ShowControlPanel();
	//_Check_return_ HRESULT ShowControlPanelFromME();
	//_Check_return_ HRESULT ShowControlPanelFromMPE();

	//_Check_return_ HRESULT HideControlPanel(_In_ bool hideImmediately = false);
	//_Check_return_ HRESULT HideControlPanelFromME();
	//_Check_return_ HRESULT HideControlPanelFromMPE();

	//_Check_return_ HRESULT ShowVerticalVolume();

	//_Check_return_ HRESULT HideVerticalVolume(BOOLEAN forceHide = FALSE);

	//_Check_return_ HRESULT OnRootUserControlLoaded();

	//_Check_return_ HRESULT OnProgressSliderSizeChanged();

	//_Check_return_ HRESULT OnProgressSliderFocusDisengaged();

	//_Check_return_ HRESULT OnPositionUpdateTimerTick();

	//_Check_return_ HRESULT OnHideControlPanelTimerTick();

	//_Check_return_ HRESULT OnHideVerticalVolumeTimerTick();

	//_Check_return_ HRESULT OnAudioSelectionButtonClick();

	//_Check_return_ HRESULT OnTHAudioTrackSelectionButtonClick();

	//_Check_return_ HRESULT OnCCSelectionButtonClick();

	//_Check_return_ HRESULT OnPlaybackRateButtonClick();

	//_Check_return_ HRESULT OnMuteClick();

	//_Check_return_ HRESULT OnVolumeClick();

	//_Check_return_ HRESULT OnPlayPauseClick();
	//_Check_return_ HRESULT OnPlayPauseFromME();
	//_Check_return_ HRESULT OnPlayPauseFromMPE();

	//_Check_return_ HRESULT OnFullWindowClick();

	//_Check_return_ HRESULT OnZoomClick();

	//_Check_return_ HRESULT OnVolumeSliderValueChanged();

	//_Check_return_ HRESULT OnVolumeButtonGotFocus(
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnControlPanelEntered();

	//_Check_return_ HRESULT OnControlPanelExited();

	//_Check_return_ HRESULT OnControlPanelTapped(
	//	_In_ xaml_input::ITappedRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnControlPanelGotFocus(
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnControlPanelLostFocus(
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnControlPanelCaptureLost(
	//	_In_ xaml_input::IPointerRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnRootExited();

	//_Check_return_ HRESULT OnRootPressed();

	//_Check_return_ HRESULT OnRootReleased();

	//_Check_return_ HRESULT OnRootCaptureLost();

	//_Check_return_ HRESULT OnRootMoved();

	//_Check_return_ HRESULT OnPositionSliderValueChanged(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml_primitives::IRangeBaseValueChangedEventArgs* pArgs);

	//_Check_return_ HRESULT OnPositionSliderPressed(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml_input::IPointerRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnPositionSliderReleased(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml_input::IPointerRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnPositionSliderKeyDown(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml_input::IKeyRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnPositionSliderKeyUp(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml_input::IKeyRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnAudioTrackClicked(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnCCTrackClicked(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnPlaybackRateMenuClicked(
	//	_In_ IInspectable* pSender,
	//	_In_ xaml::IRoutedEventArgs* pArgs);

	//_Check_return_ HRESULT OnFastForwardButtonClicked();

	//_Check_return_ HRESULT OnFastRewindButtonClicked();

	//_Check_return_ HRESULT SkipBackward();

	//_Check_return_ HRESULT SkipForward();

	//_Check_return_ HRESULT OnStopButtonClicked();

	//_Check_return_ HRESULT OnCastButtonClicked();

	//_Check_return_ HRESULT OnRepeatButtonClicked();

	//_Check_return_ HRESULT OnCompactOverlayButtonClicked();

	//_Check_return_ HRESULT OnSizeChanged();

	//_Check_return_ HRESULT OnBorderSizeChanged();

	//_Check_return_ HRESULT OnCoreWindowKeyDown(
	//	_In_ wuc::IKeyEventArgs* pArgs);

	//_Check_return_ HRESULT OnVisibilityVisualStateChanged(
	//	_In_ xaml::IVisualStateChangedEventArgs* pEventArgs);

	//_Check_return_ HRESULT UpdatePlayPauseUI();

	//_Check_return_ HRESULT UpdateAudioSelectionUI();

	//_Check_return_ HRESULT UpdateCCSelectionUI();

	//_Check_return_ HRESULT UpdateFullWindowUI();

	//_Check_return_ HRESULT UpdateMiniViewUI();

	//_Check_return_ HRESULT SetMiniView(_In_ bool bIsEnable);

	//_Check_return_ HRESULT UpdateIsMutedUI();

	//_Check_return_ HRESULT UpdateVolumeUI();

	//_Check_return_ HRESULT UpdatePositionUI();

	//_Check_return_ HRESULT UpdateDownloadProgressUI();

	//_Check_return_ HRESULT UpdateErrorUI();
	//_Check_return_ HRESULT UpdateErrorUIFromME();
	//_Check_return_ HRESULT UpdateErrorUIFromMPE();

	//_Check_return_ HRESULT UpdateRepeatButtonUI();
	//_Check_return_ HRESULT UpdateRepeatButtonUIFromMPE();

	//_Check_return_ HRESULT StartPositionUpdateTimer();

	//_Check_return_ HRESULT StopPositionUpdateTimer();

	//_Check_return_ HRESULT StartVerticalVolumeHideTimer();

	//_Check_return_ HRESULT StopVerticalVolumeHideTimer();

	//_Check_return_ HRESULT StartControlPanelHideTimer();

	//_Check_return_ HRESULT StopControlPanelHideTimer();

	//_Check_return_ HRESULT SetCheckedProperty(
	//	_In_opt_ xaml_primitives::IToggleButton* pToggleButton,
	//	_In_ BOOLEAN value);

	//_Check_return_ HRESULT AddTooltip(
	//	_In_ xaml::IDependencyObject* pTooltipTarget,
	//	_In_ HSTRING hstrTooltipText);

	//_Check_return_ HRESULT UpdateTooltipText(
	//	_In_ xaml::IDependencyObject* pTooltipTarget,
	//	_In_ HSTRING hstrTooltipText);

	//_Check_return_ HRESULT ConvertSecondsToHString(
	//	_In_ INT64 totalSeconds,
	//	_Outptr_ HSTRING* pDisplayTime);

	//_Check_return_ HRESULT GetLocalizedLanguageName(
	//	_In_ HSTRING languageTag,
	//	_Outptr_ HSTRING* pProcessedLanguageName);

	//_Check_return_ HRESULT MarkLanguageSelection(
	//	_In_opt_ HSTRING localizedLanguage,
	//	_Outptr_ HSTRING* pMarkedLocalizedLanguage);

	//_Check_return_ HRESULT GetErrorResourceID(
	//	_In_ UINT32 errorCode,
	//	_Out_ UINT32* pResourceID);

	//_Check_return_ HRESULT HasKeyOrProgFocus(
	//	_In_ xaml::IRoutedEventArgs* pArgs,
	//	_Out_ BOOLEAN *pHasKeyOrProgFocus);

	//_Check_return_ HRESULT CompareWithOriginalSource(
	//	_In_ xaml::IRoutedEventArgs* pArgs,
	//	_In_ IInspectable *pObjectToCompare,
	//	_Out_ BOOLEAN *pIsEqual);

	//_Check_return_ HRESULT HitTestHelper(
	//	_In_ wf::Point point,
	//	_In_ xaml::IUIElement* pElement,
	//	_Out_ BOOLEAN* pHasHit);

	//BOOLEAN ShouldHideVerticalVolume();

	//BOOLEAN ShouldHideControlPanel();
	//BOOLEAN ShouldHideControlPanelWhilePlaying();

	//_Check_return_ HRESULT EnterScrubbingMode();

	//_Check_return_ HRESULT ExitScrubbingMode();

	//inline BOOLEAN IsLiveContent()
	//{
	//	// Content that reports a 0 or Infinite duration is considered live for UI purposes
	//	return m_sourceLoaded &&
	//		  (m_naturalDuration.TimeSpan.Duration == INT64_MAX ||
	//		   m_naturalDuration.TimeSpan.Duration == 0);
	//}

	//_Check_return_ HRESULT LoadMediaTransportControlsFromXBF(
	//	_Outptr_ xaml_controls::IUserControl** ppTransportControlsRoot);

	//_Check_return_ HRESULT

	//UpdateMediaTransportBounds();

	//_Check_return_ HRESULT SetupDefaultProperties();

	//_Check_return_ HRESULT UpdateMediaControlState(_In_ KnownPropertyIndex propertyIndex) noexcept;

	//_Check_return_ HRESULT UpdateMediaControlAllStates();

	//_Check_return_ HRESULT CalculateDropOutLevel();

	//_Check_return_ HRESULT CreateCCFlyoutTrack(_In_ HSTRING strLabel, _In_ int id, _In_ int idx);

	//_Check_return_ HRESULT MeasureCommandBar();
	//_Check_return_ HRESULT SetMeasureCommandBar();

	//_Check_return_ HRESULT Dropout(_In_ double availableSize,
	//							  _In_ wf::Size expectSize);
	//_Check_return_ HRESULT Expand(_In_ double availableSize,
	//							 _In_ wf::Size expectSize);
	//_Check_return_ HRESULT AddMarginsBetweenGroups();
	//_Check_return_ HRESULT ResetMargins();
	//BOOLEAN IsButtonCollapsedbySystem(_In_ xaml::IUIElement* element);

	//_Check_return_ HRESULT GetCastingDevicePicker(_Out_ ctl::ComPtr<wm::Casting::ICastingDevicePicker> &spCastingDevicePicker);
	//_Check_return_ HRESULT ResetPlayBackAfterCasting();
	//_Check_return_ HRESULT HideCastButtonIfNecessary();

	//_Check_return_ HRESULT OnCommandBarLoaded();
	//_Check_return_ HRESULT HideMoreButtonIfNecessary();

	//_Check_return_ HRESULT OnVolumeSliderPointerWheelChanged(_In_ IInspectable* pSender, _In_ xaml_input::IPointerRoutedEventArgs* pArgs);
	//_Check_return_ HRESULT UpdateFullScreenMode(_In_ BOOLEAN isFullWindow);
	//_Check_return_ HRESULT GetFullScreenView(_Outptr_opt_ wuv::IApplicationView3** ppAppView);
	//_Check_return_ HRESULT GetMiniView(_Outptr_opt_ wuv::IApplicationView4** ppAppView);

	//_Check_return_ HRESULT UpdatePlaybackItemReference();

	//_Check_return_ HRESULT IsMediaStateClosedFromME(_Out_ BOOLEAN* value);
	//_Check_return_ HRESULT IsMediaStateClosedFromMPE(_Out_ BOOLEAN* value);
	//_Check_return_ HRESULT SetAudioTrackFromME(_In_ UINT selectedIndex);
	//_Check_return_ HRESULT SetAudioTrackFromMPE(_In_ UINT selectedIndex);
	//_Check_return_ HRESULT SetCCTrackFromME(_In_ UINT selectedIndex);
	//_Check_return_ HRESULT SetCCTrackFromMPE(_In_ UINT selectedIndex);

	//_Check_return_ HRESULT UpdateSafeMargins(_In_ bool applySafeMargin);
	//_Check_return_ HRESULT UpdateSafeMarginsinFullWindow(_In_ bool applySafeMargin);
	//_Check_return_ HRESULT SetTabIndex();

	//private:
	//// HNS Hunderds of Nano Seconds used for conversion in timer duration
	//static const unsigned int HNSPerSecond;
	//// Control Panel Timout in secs, after timeout Control Panel will be hide.
	//static const double ControlPanelDisplayTimeoutInSecs;
	//// Vertical Volume bar Timout in secs, after timout Vertical Volume bar will be hide.
	//static const double VerticalVolumeDisplayTimeoutInSecs;
	//// Timer frequecy in second to update Seek bar.
	//static const double SeekbarPositionUpdateFreqInSecs;
	//// Elapsed-Remaining Button used seeking interval defined in HNS
	//static const long TimeButtonUsedSeekIntervalInHNS;
	//// Maximum Time String length unsed in the Time Buttons.
	//static const unsigned int MaxTimeButtonTextLength;
	//// Maximum Processed Language length
	//static const unsigned int MaxProcessedLanguageNameLength;
	//// Maximum Dropout levels used in WinBlue
	//static const unsigned int MaxDropuOutLevels;
	//// Maximum PlayRate Counts
	//static const unsigned int AvailablePlaybackRateCount;
	//static const double AvailablePlaybackRateList[];
	//// Skip forward/Skip Backward time interval defined in Seconds
	//static const unsigned int SkipForwardInSecs;
	//static const unsigned int SkipBackwardInSecs;
	//static const int VolumeSliderWheelScrollStep;
	//static const int MinSupportedPlayRate;

	//ctl::WeakRefPtr m_wrOwnerParent;                    // Week reference to Parent(ME/MPE) associated with this MediaTransportControls.

	//// Component size constants, defined as StatisResources in Xaml
	//double m_resControlPanelHeight;                     // Height of Control Panel
	//double m_resVerticalVolumeSliderMinHeight;          // Minimum height of Vertical Volume slider track
	//double m_resVerticalVolumeSliderMaxHeight;          // Maximum height of slider track
	//double m_resVerticalVolumeSliderTopPadding;         // Padding at top of slider track, but inside the panel
	//double m_resVerticalVolumeSliderTopGap;             // Required minimum gap between top of slider panel and top of content area
	//double m_resSideMargins;                            // Sum of left and right margins around each subcontrol
	//double m_resMediaButtonWidth;                       // Width of each of the round buttons (PlayPause, Volume, Mute, etc)
	//double m_resTimeButtonWidth;                        // Width of each time button (ElapsedTime, RemainingTime)
	//double m_resPositionSliderMinimumWidth;             // Minimum width of Position Slider
	//double m_resHorizontalVolumeSliderWidth;            // Width of Horizontal Volume Slider

	//// State flags
	//int m_dropOutLevel;
	//BOOLEAN m_transportControlsEnabled         : 1;
	//BOOLEAN m_stretchOnFullWindowChanged       : 1;
	//BOOLEAN m_verticalVolumeVisibilityChanged  : 1;
	//BOOLEAN m_verticalVolumeIsVisible          : 1;
	//BOOLEAN m_verticalVolumeHasKeyOrProgFocus  : 1;
	//BOOLEAN m_controlPanelVisibilityChanged    : 1;
	//BOOLEAN m_controlPanelIsVisible            : 1;
	//BOOLEAN m_controlPanelHasPointerOver       : 1;
	//BOOLEAN m_shouldDismissControlPanel        : 1;     // Specifies whether Control Panel should be dismissed. It gets set when
	//													//  - we hit FullScreen button while playing media,
	//													//  - we tap on the screen
	//													//  - play state is changed (to Buffering or to Pause).
	//													// This flag overrides m_controlPanelHasPointerOver flag in ShouldHideControlPanel logic.
	//BOOLEAN m_rootHasPointerPressed            : 1;
	//BOOLEAN m_controlsHaveKeyOrProgFocus       : 1;     // Specifies whether one of the transport controls has keyboard or programmatic focus
	//BOOLEAN m_positionUpdateUIOnly             : 1;     // If true, update the Position slider value only - do not set underlying ME.Position DP
	//BOOLEAN m_volumeUpdateUIOnly               : 1;     // If true, update the Volume slider value only - do not set underlying ME.Volume DP
	//BOOLEAN m_sourceLoaded                     : 1;
	//BOOLEAN m_isPlaying                        : 1;     // Specifies whether we are currently playing (for setting PlayButtons state). This includes buffering also
	//BOOLEAN m_isBuffering                      : 1;     // Specifies whether we are currently buffering
	//BOOLEAN m_hasError                         : 1;
	//BOOLEAN m_hasMultipleAudioStreams          : 1;
	//BOOLEAN m_hasCCTracks                      : 1;
	//BOOLEAN m_isInScrubMode                    : 1;

	//// Cache values which are accessed frequently
	//BOOLEAN m_isAudioOnly                     : 1;
	//BOOLEAN m_isFullWindow                    : 1;
	//BOOLEAN m_isFullScreen                    : 1;
	//BOOLEAN m_isCompact                       : 1;
	//BOOLEAN m_isFlyoutOpen                    : 1;
	//BOOLEAN m_isPausedForCastingSelection     : 1;
	//BOOLEAN m_isFullScreenClicked             : 1;
	//BOOLEAN m_isFullScreenPending             : 1;
	//BOOLEAN m_isLaunchedAsFullScreen          : 1;
	//BOOLEAN m_isCastSupports                  : 1;
	//BOOLEAN m_isthruScrubber                  : 1;
	//BOOLEAN m_isPointerMove                   : 1;
	//BOOLEAN m_isMiniView                      : 1;
	//BOOLEAN m_isMiniViewClicked               : 1;
	//BOOLEAN m_isSpanningCompactEnabled        : 1;

	//double m_positionSliderMinimum;
	//double m_positionSliderMaximum;
	//double m_volumeSliderMinimum;
	//double m_volumeSliderMaximum;
	//xaml::Duration m_naturalDuration;
	//xaml_media::Stretch m_stretchToRestore;
	//double m_lastKnownMiniViewWidth = 0;
	//double m_lastKnownMiniViewHeight = 0;

	//MTCParent m_parentType;

	////Telemetry Helper Class
	//CAggMediaControlEvents m_AggTelemetry;
	////
	//// References to control parts we need to manipulate
	////
	//// Reference to the control panel grid
	//TrackerPtr<xaml_controls::IGrid> m_tpControlPanelGrid;

	//// Reference to the media position slider.
	//TrackerPtr<xaml_controls::ISlider> m_tpMediaPositionSlider;

	//// Reference to the horizontal volume slider (audio-only mode audio slider).
	//TrackerPtr<xaml_controls::ISlider> m_tpHorizontalVolumeSlider;

	//// Reference to the vertical volume slider (video-mode audio slider).
	//TrackerPtr<xaml_controls::ISlider> m_tpVerticalVolumeSlider;

	//// Reference to the Threshold Volume slider (video-mode & audio-mode slider).
	//TrackerPtr<xaml_controls::ISlider> m_tpTHVolumeSlider;

	//// Refererence to currently active volume slider
	//TrackerPtr<xaml_controls::ISlider> m_tpActiveVolumeSlider;

	//// Reference to download progress indicator, which is a part in the MediaSlider template
	//TrackerPtr<xaml_controls::IProgressBar> m_tpDownloadProgressIndicator;

	//// Reference to the buffering indeterminate progress bar
	//TrackerPtr<xaml_controls::IProgressBar> m_tpBufferingProgressBar;

	//// Reference to the PlayPause button used in Blue and Threshold
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpPlayPauseButton;

	//// Reference to the PlayPause button used only in Threshold
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpTHLeftSidePlayPauseButton;

	//// Reference to the Audio Selection button
	//TrackerPtr<xaml_controls::IButton> m_tpAudioSelectionButton;

	//// Reference to the Audio Selection button for Threshold
	//TrackerPtr<xaml_controls::IButton> m_tpTHAudioTrackSelectionButton;

	//// Reference to the Available Audiotracks flyout
	//TrackerPtr<xaml_controls::IMenuFlyout> m_tpAvailableAudioTracksMenuFlyout;

	//// Reference to the Available Audiotracks flyout target
	//TrackerPtr<xaml::IFrameworkElement> m_tpAvailableAudioTracksMenuFlyoutTarget;

	//// Reference to the Close Captioning Selection button
	//TrackerPtr<xaml_controls::IButton> m_tpCCSelectionButton;

	//// Reference to the Available Close Captioning tracks flyout
	//TrackerPtr<xaml_controls::IMenuFlyout> m_tpAvailableCCTracksMenuFlyout;

	//// Reference to the Play Rate Selection button
	//TrackerPtr<xaml_controls::IButton> m_tpPlaybackRateButton;

	//// Reference to the Available Play Rate List flyout
	//TrackerPtr<xaml_controls::IMenuFlyout> m_tpAvailablePlaybackRateMenuFlyout;

	//// Reference to the Video volume button
	//TrackerPtr<xaml_primitives::IToggleButton> m_tpVideoVolumeButton;

	//// Reference to the Audio-mute button for Blue and Mute button for Video/Audio in Threshold
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpMuteButton;

	//// Reference to the Threshold volume button
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpTHVolumeButton;

	//// Reference to the Full Window button
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpFullWindowButton;

	//// Reference to the Zoom button
	//TrackerPtr<xaml_primitives::IButtonBase> m_tpZoomButton;

	//// Reference to currently active volume button
	//TrackerPtr<xaml_primitives::IToggleButton> m_tpActiveVolumeButton;

	//// Reference to Time Elapsed / -30 sec seek button or Time Elapsed TextBlock
	//TrackerPtr<xaml::IFrameworkElement> m_tpTimeElapsedElement;

	//// Reference to Time Remaining / +30 sec seek button or Time Remaining TextBlock
	//TrackerPtr<xaml::IFrameworkElement> m_tpTimeRemainingElement;

	//// Reference to the fast forward button
	//TrackerPtr<xaml_controls::IButton> m_tpFastForwardButton;

	//// Reference to the rewind button
	//TrackerPtr<xaml_controls::IButton> m_tpFastRewindButton;

	//// Reference to the stop button
	//TrackerPtr<xaml_controls::IButton> m_tpStopButton;

	//// Reference to the cast button
	//TrackerPtr<xaml_controls::IButton> m_tpCastButton;

	//// Reference to the Skip Forward button
	//TrackerPtr<xaml_controls::IButton> m_tpSkipForwardButton;
	//// Reference to the Skip Backward button
	//TrackerPtr<xaml_controls::IButton> m_tpSkipBackwardButton;
	//// Reference to the Next Track button
	//TrackerPtr<xaml_controls::IButton> m_tpNextTrackButton;
	//// Reference to the Previous Track button
	//TrackerPtr<xaml_controls::IButton> m_tpPreviousTrackButton;
	//// Reference to currently Repeat button
	//TrackerPtr<xaml_primitives::IToggleButton> m_tpRepeatButton;
	//// Reference to the Mini View button
	//TrackerPtr<xaml_controls::IButton> m_tpCompactOverlayButton;
	//// Reference to the Left AppBarSeparator
	//TrackerPtr<xaml_controls::IAppBarSeparator> m_tpLeftAppBarSeparator;
	//// Reference to the Right AppBarSeparator
	//TrackerPtr<xaml_controls::IAppBarSeparator> m_tpRightAppBarSeparator;
	//// Reference to the Image thumbnail preview
	//TrackerPtr<xaml_controls::IImage> m_tpThumbnailImage;
	//// Reference to the Time Elapsed  preview
	//TrackerPtr<xaml_controls::ITextBlock> m_tpTimeElapsedPreview;

	//// Reference to Error TextBlock
	//TrackerPtr<xaml_controls::ITextBlock> m_tpErrorTextBlock;

	//// Dispatcher timer responsible for updating clock and position slider
	//TrackerPtr<xaml::IDispatcherTimer> m_tpPositionUpdateTimer;

	//// Dispatcher timer responsible for hiding vertical volume host border
	//TrackerPtr<xaml::IDispatcherTimer> m_tpHideVerticalVolumeTimer;

	//// Dispatcher timer responsible for hiding UI control panel
	//TrackerPtr<xaml::IDispatcherTimer> m_tpHideControlPanelTimer;

	//// Dispatcher timer to detect the pointer move ends.
	//TrackerPtr<xaml::IDispatcherTimer> m_tpPointerMoveEndTimer;

	//// Reference to the Visibility Border element.
	//TrackerPtr<xaml_controls::IBorder> m_tpControlPanelVisibilityBorder;

	//// Reference to the CommandBar Element.
	//TrackerPtr<xaml_controls::ICommandBar> m_tpCommandBar;

	//// Reference to the CommandBar Element.
	//TrackerPtr<xaml_primitives::IFlyoutBase> m_tpVolumeFlyout;

	//// Reference to the VisualStateGroup
	//TrackerPtr<xaml::IVisualStateGroup> m_tpVisibilityStatesGroup;

	////
	//// Event handlers
	////

	//ctl::EventPtr<FrameworkElementLoadedEventCallback> m_epRootUserControlLoadedHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epPlayPauseButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epLeftsidePlayPauseButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epAudioSelectionButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epAudioTrackSelectionButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epCCSelectionButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epPlaybackRateButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epVolumeButtonClickHandler;
	//ctl::EventPtr<UIElementGotFocusEventCallback> m_epVolumeButtonGotFocusHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epAudioMuteButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epFullWindowButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epZoomButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epFastForwardButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epFastRewindButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epStopButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epCastButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epSkipForwardButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epSkipBackwardButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epNextTrackButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epPreviousTrackButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epRepeatButtonClickHandler;
	//ctl::EventPtr<ButtonBaseClickEventCallback> m_epCompactOverlayButtonClickHandler;
	//ctl::EventPtr<FrameworkElementSizeChangedEventCallback> m_epProgressSliderSizeChangedHandler;
	//ctl::EventPtr<ControlFocusDisengagedEventCallback> m_epProgressSliderFocusDisengagedHandler;
	//ctl::EventPtr<RangeBaseValueChangedEventCallback> m_epHorizontalVolumeChangedHandler;
	//ctl::EventPtr<RangeBaseValueChangedEventCallback> m_epVerticalVolumeChangedHandler;
	//ctl::EventPtr<RangeBaseValueChangedEventCallback> m_epVolumeChangedHandler;
	//ctl::EventPtr<RangeBaseValueChangedEventCallback> m_epPositionChangedHandler;
	//ctl::EventPtr<UIElementPointerEnteredEventCallback> m_epControlPanelEnteredHandler;
	//ctl::EventPtr<UIElementPointerExitedEventCallback> m_epControlPanelExitedHandler;
	//ctl::EventPtr<UIElementTappedEventCallback> m_epControlPanelTappedHandler;
	//ctl::EventPtr<UIElementPointerCaptureLostEventCallback> m_epControlPanelCaptureLostHandler;
	//ctl::EventPtr<UIElementGotFocusEventCallback> m_epControlPanelGotFocusHandler;
	//ctl::EventPtr<UIElementLostFocusEventCallback> m_epControlPanelLostFocusHandler;
	//ctl::EventPtr<UIElementPointerExitedEventCallback> m_epRootExitedHandler;
	//ctl::EventPtr<UIElementPointerPressedEventCallback> m_epRootPressedHandler;
	//ctl::EventPtr<UIElementPointerReleasedEventCallback> m_epRootReleasedHandler;
	//ctl::EventPtr<UIElementPointerCaptureLostEventCallback> m_epRootCaptureLostHandler;
	//ctl::EventPtr<UIElementPointerMovedEventCallback> m_epRootMovedHandler;
	//ctl::EventPtr<DispatcherTimerTickEventCallback> m_epPositionUpdateTimerTickHandler;
	//ctl::EventPtr<DispatcherTimerTickEventCallback> m_epHideControlPanelTimerTickHandler;
	//ctl::EventPtr<DispatcherTimerTickEventCallback> m_epHideVerticalVolumeTimerTickHandler;
	//ctl::EventPtr<VisualStateGroupCurrentStateChangedEventCallback> m_visibilityStateChangedEventHandler;
	//ctl::EventPtr<DispatcherTimerTickEventCallback> m_epPointerMoveEndTimerTickHandler;

	//// Following handlers need to set handledEventsToo flag, so that they can get events
	//// marked handled by source subcontrols. EventPtr template does not support this,
	//// so ClassMemberEventHandler with explicit tokens is used here.
	//EventRegistrationToken m_positionSliderPressedEventToken;
	//EventRegistrationToken m_positionSliderReleasedEventToken;
	//EventRegistrationToken m_positionSliderKeyDownEventToken;
	//EventRegistrationToken m_positionSliderKeyUpEventToken;
	//ctl::EventPtr<FrameworkElementSizeChangedEventCallback> m_epSizeChangedHandler;
	//ctl::EventPtr<FrameworkElementSizeChangedEventCallback> m_epBorderSizeChangedHandler;
	//EventRegistrationToken m_tokLayoutBoundsChanged {0};
	//EventRegistrationToken m_tokCoreWindowKeyDown;
	//ctl::EventPtr<FrameworkElementLoadedEventCallback> m_epCommandBarLoadedHandler;
	//ctl::EventPtr<FlyoutBaseOpenedEventCallback> m_epFlyoutOpenedHandler;
	//ctl::EventPtr<FlyoutBaseClosedEventCallback> m_epFlyoutClosedHandler;
	//ctl::EventPtr<UIElementPointerWheelChangedEventCallback> m_volumeSliderPointerWheelChangedHandler;

	//// Vector of Click event handlers for Audio Selection MenuFlyoutItems
	//std::vector<ctl::EventPtr<MenuFlyoutItemClickEventCallback>*> m_audioTrackClickHandlers;

	//// Vector of Click event handlers for Close Caption Selection MenuFlyoutItems
	//std::vector<ctl::EventPtr<MenuFlyoutItemClickEventCallback>*> m_CCTrackClickHandlers;

	//// Vector maps UI index(key) to MF track IDs(value)
	//std::vector<INT> m_trackIdMappings;

	//// MF ID of the current selected text track
	//INT m_currentTrack;

	//// CurrentPlayback Rate
	//double m_currentPlaybackRate;
	//// keep track original playrate in FF/Rewind mode
	//double m_orginalPlaybackRate;

	//// Vector of Click event handlers for Play Rate Selection MenuFlyoutItems
	//std::vector<ctl::EventPtr<MenuFlyoutItemClickEventCallback>*> m_playbackRateClickHandlers;

	//// Vector of currently available playback rates
	//std::vector<double> m_currentPlaybackRates;

	//ctl::ComPtr<wmp::IMediaPlaybackItem> m_spCurrentItem;
	//EventRegistrationToken m_trackAddedEventToken;
	//// Reference to the Casting Device Picker
	//ctl::ComPtr<wm::Casting::ICastingDevicePicker> m_spCastingDevicePicker;
	//ctl::ComPtr<wm::Casting::ICastingConnection> m_spCastingConnection;
	//EventRegistrationToken m_castingDeviceSelectedToken;
	//EventRegistrationToken m_castingPickerDismissedToken;
	//EventRegistrationToken m_castingConnectStateChangeToken;
	//BOOLEAN m_isMediaPlayerSubscribed :1;
	//BOOLEAN m_isTrickBackwardMode     :1;
	//BOOLEAN m_isTrickForwardMode      :1;
	//BOOLEAN m_isThumbnailEnabled      :1;
	//BOOLEAN m_isTemplateApplied       :1;
	//BOOLEAN m_isBreakPlaying          :1;
	//BOOLEAN m_isVSStateChangeExternal :1;

	//_Check_return_ HRESULT SubscribeMediaPlayerEvents() noexcept;
	//_Check_return_ HRESULT UnSubscribeMediaPlayerEvents() noexcept;
	//_Check_return_ HRESULT SubscribeTrackEvents();
	//_Check_return_ HRESULT UnSubscribeTrackEvents();
	//_Check_return_ HRESULT SubscribeBreakListEvents();
	//_Check_return_ HRESULT UnSubscribeBreakListEvents();
	//_Check_return_ HRESULT GetMediaPlayer2ForPlaybackDataSource(_Outptr_result_maybenull_ wmp::IMediaPlayer2** value);
	//_Check_return_ HRESULT GetCurrentPlaybackSession(_Outptr_result_maybenull_ wmp::IMediaPlaybackSession** ppValue);

	////MediaAPI Properties wrappers
	//_Check_return_ HRESULT GetMuted(_Out_ BOOLEAN *value);
	//_Check_return_ HRESULT SetMuted(_In_ BOOLEAN value);
	//_Check_return_ HRESULT GetFullWindow(_Out_ BOOLEAN *value);
	//_Check_return_ HRESULT SetFullWindow(_In_ BOOLEAN value);
	//_Check_return_ HRESULT GetStretch(_Out_ xaml_media::Stretch* value);
	//_Check_return_ HRESULT SetStretch(_In_ xaml_media::Stretch value);
	//_Check_return_ HRESULT GetVolume(_Out_ DOUBLE *value);
	//_Check_return_ HRESULT SetVolume(_In_ DOUBLE value);
	//_Check_return_ HRESULT GetPosition(_Out_ wf::TimeSpan* value);
	//_Check_return_ HRESULT SetPosition(_In_ wf::TimeSpan value, _In_ bool isScrubber = true);
	//_Check_return_ HRESULT GetAudioTrackCount(_Out_ INT *value);
	//_Check_return_ HRESULT GetCCTrackCount(_Out_ UINT *pValue);
	//_Check_return_ HRESULT GetSupportedTrackCount(
	//	_In_ wfc::IVectorView<wmc::TimedMetadataTrack*>* pList,
	//	_In_ wmp::IMediaPlaybackItem* pCurrentItem, _Out_ UINT *pValue);
	//_Check_return_ HRESULT GetDownloadProgress(_Out_ DOUBLE *value);
	//_Check_return_ HRESULT GetPlaybackRate(_Out_ DOUBLE *value);
	//_Check_return_ HRESULT SetPlaybackRate(_In_ DOUBLE value, _In_ bool isScrubber = true);
	//_Check_return_ HRESULT Stop();
	//_Check_return_ HRESULT Play(_In_ bool isCast = false);
	//_Check_return_ HRESULT Pause(_In_ bool isCast = false);
	//_Check_return_ HRESULT GetRepeatMode(_Out_ MediaPlaybackDataSourceExtension_RepeatMode* value);
	//_Check_return_ HRESULT SetRepeatMode(_In_ MediaPlaybackDataSourceExtension_RepeatMode value);
	//_Check_return_ HRESULT GetAsCastingSource(_Outptr_opt_ wm::Casting::ICastingSource** returnValue);
	//_Check_return_ HRESULT OnMediaPropertyChanged(_In_ MediaPlayer_Property propertyIndex);
	//_Check_return_ HRESULT TrickModeForward();
	//_Check_return_ HRESULT TrickModeBackward();
	//_Check_return_ HRESULT ResetTrickMode();
	//_Check_return_ HRESULT UpdateTrickModeFallbackUI();
	//_Check_return_ HRESULT NextTrack();
	//_Check_return_ HRESULT PreviousTrack();
	//_Check_return_ HRESULT UpdateTracksUI();
	//_Check_return_ HRESULT FireThumbnailEvent();
	//_Check_return_ HRESULT ShowHideThumbnail(BOOLEAN value);
	//_Check_return_ HRESULT UpdateTrickModeButton(_In_ double playrate);
	//_Check_return_ HRESULT IsPlaybackRateSupported(_In_ double playrate, _Out_ BOOLEAN* value);
	//_Check_return_ HRESULT UpdateSeekPositionsUI();
	//_Check_return_ HRESULT UpdatePlaybackRateUI();
	//_Check_return_ HRESULT UpdateBreakStatus(_In_ bool isBreakStart);
	//_Check_return_ HRESULT UpdateBreakUI();

	//EventRegistrationToken m_mediaPlayerMuteChangeToken;
	//EventRegistrationToken m_mediaPlayerVolumeChangeToken;
	//EventRegistrationToken m_mediaPlayerDownloadProgressChangeToken;
	//EventRegistrationToken m_mediaPlayerCurrentStateChangeToken;
	//EventRegistrationToken m_mediaPlayerNaturalDurationChangeToken;
	//EventRegistrationToken m_mediaPlayerPositionChangeToken;
	//EventRegistrationToken m_mediaPlayerMediaOpenedToken;
	//EventRegistrationToken m_mediaPlayerMediaFailedToken;
	//EventRegistrationToken m_mediaPlayerSourceChangeToken;
	//EventRegistrationToken m_mediaPlayerItemFailedToken;
	//EventRegistrationToken m_mediaPlayerItemChangedToken;
	//EventRegistrationToken m_mediaPlayerBreakItemChangedToken;
	//EventRegistrationToken m_mediaPlayerPlaybackRateChangeToken;
	//EventRegistrationToken m_mediaPlayerAutoRepeatChangedToken;
	//EventRegistrationToken m_cmdManagerPlayBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerPauseBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerNextBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerPreviousBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerFastForwardBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerRewindBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerPositionBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerRateBehaviorChangeToken;
	//EventRegistrationToken m_cmdManagerAutoRepeatBehaviorChangeToken;
	//EventRegistrationToken m_brkManagerBreakStartToken;
	//EventRegistrationToken m_brkManagerBreakEndToken;
	//EventRegistrationToken m_brkManagerBreakSkippedToken;
	//EventRegistrationToken m_mediaBreakCurrentStateChangeToken;
	//EventRegistrationToken m_mediaBreakPositionChangeToken;
	//EventRegistrationToken m_mediaBreakDownloadProgressChangeToken;
	//EventRegistrationToken m_mediaPlayerIsLoopingEnabledToken;
	//ctl::ComPtr<wmp::IMediaPlayer> m_spMediaPlayer;
	//ctl::ComPtr<wmp::IMediaPlaybackList> m_spMediaPlaybackList;
	//ctl::ComPtr<wmp::IMediaPlaybackList> m_spMediaBreakPlaybackList;

	//_Check_return_ HRESULT AddRegistrationCoreWindowKeyDown();
	//_Check_return_ HRESULT RemoveRegistrationCoreWindowKeyDown();
	//_Check_return_ HRESULT EnableValueChangedEventThrottlingOnSliderAutomation(bool value);
	//_Check_return_ HRESULT UpdateTimeAutomationProperties();

	//UINT32 m_errcodeFromMPE;
	//UINT32 GetMediaEngineErrorCode(_In_ wmp::MediaPlayerError errorMediaPlayer);
	//UINT32 GetMediaEngineErrorCode(_In_ wmp::MediaPlaybackItemErrorCode errorMediaPlaybackItem);

	//_Check_return_ HRESULT ConcatFields(_Inout_ wrl_wrappers::HString* base,
	//									_In_ wrl_wrappers::HString& input,
	//									_Inout_ int* fieldCount,
	//									_In_ int numberOfFields);
	//_Check_return_ HRESULT CreateAudioTags(_In_ wmp::IMediaPlaybackItem* pPlaybackItem,
	//									   _Out_ std::vector<wrl_wrappers::HString>&& pTagList);
	//_Check_return_ HRESULT CreateUniqueTags(_In_ std::vector<TrackFields> trackData,
	//										_Out_ std::vector<wrl_wrappers::HString>&& pTrackTags);
	//_Check_return_ HRESULT AudioTag(_In_ TrackFields trackFields,
	//								_In_ int numberOfFields,
	//								_Out_ wrl_wrappers::HString& pAudioTag);
	//_Check_return_ HRESULT UsedPreviously(_In_ std::vector<wrl_wrappers::HString>&& trackTags,
	//									  _In_ wrl_wrappers::HString& current,
	//									  _Out_ BOOLEAN* value);
	//_Check_return_ HRESULT CreateLanguage(_In_z_ PCWSTR languageTag, _COM_Outptr_ wg::ILanguage** ppLanguage);
}
public partial class MediaTransportControls_partial // dxaml\xcp\dxaml\lib\MediaTransportControls_partial.cpp
{
	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Creates an instance of the MediaTransportControls class.
	////
	////------------------------------------------------------------------------
	//MediaTransportControls::MediaTransportControls() :
	//    m_resControlPanelHeight(0)
	//    , m_resVerticalVolumeSliderMinHeight(0)
	//    , m_resVerticalVolumeSliderMaxHeight(0)
	//    , m_resVerticalVolumeSliderTopPadding(0)
	//    , m_resVerticalVolumeSliderTopGap(0)
	//    , m_resSideMargins(0)
	//    , m_resMediaButtonWidth(0)
	//    , m_resTimeButtonWidth(0)
	//    , m_resPositionSliderMinimumWidth(0)
	//    , m_resHorizontalVolumeSliderWidth(0)
	//    , m_transportControlsEnabled(FALSE)
	//    , m_sourceLoaded(FALSE)
	//    , m_isPlaying(FALSE)
	//    , m_isBuffering(FALSE)
	//    , m_stretchOnFullWindowChanged(FALSE)
	//    , m_verticalVolumeVisibilityChanged(FALSE)
	//    , m_verticalVolumeIsVisible(FALSE)
	//    , m_verticalVolumeHasKeyOrProgFocus(FALSE)
	//    , m_controlPanelVisibilityChanged(FALSE)
	//    , m_controlPanelIsVisible(FALSE)
	//    , m_rootHasPointerPressed(FALSE)
	//    , m_controlPanelHasPointerOver(FALSE)
	//    , m_shouldDismissControlPanel(FALSE)
	//    , m_controlsHaveKeyOrProgFocus(FALSE)
	//    , m_isAudioOnly(false)
	//    , m_isFullWindow(FALSE)
	//    , m_isFullScreen(FALSE)
	//    , m_isFullScreenClicked(FALSE)
	//    , m_isLaunchedAsFullScreen(FALSE)
	//    , m_isFullScreenPending(FALSE)
	//    , m_hasError(FALSE)
	//    , m_positionUpdateUIOnly(FALSE)
	//    , m_volumeUpdateUIOnly(FALSE)
	//    , m_stretchToRestore(Stretch_None)
	//    , m_hasMultipleAudioStreams(FALSE)
	//    , m_hasCCTracks(FALSE)
	//    , m_isInScrubMode(FALSE)
	//    , m_dropOutLevel(-1)
	//    , m_AggTelemetry()
	//    , m_currentTrack(-1)
	//    , m_isCompact(FALSE)
	//    , m_isFlyoutOpen(FALSE)
	//    , m_isPausedForCastingSelection(FALSE)
	//    , m_isCastSupports(TRUE)
	//    , m_parentType(MTCParent_None)
	//    , m_currentPlaybackRate(0.0)
	//    , m_orginalPlaybackRate(0.0)
	//    , m_errcodeFromMPE(MF_MEDIA_ENGINE_ERR_NOERROR)
	//    , m_isMediaPlayerSubscribed(FALSE)
	//    , m_isTrickBackwardMode(FALSE)
	//    , m_isTrickForwardMode(FALSE)
	//    , m_isThumbnailEnabled(FALSE)
	//    , m_isTemplateApplied(FALSE)
	//    , m_isBreakPlaying(FALSE)
	//    , m_isthruScrubber(FALSE)
	//    , m_isVSStateChangeExternal(FALSE)
	//    , m_isPointerMove(FALSE)
	//    , m_isMiniView(FALSE)
	//    , m_isMiniViewClicked(FALSE)
	//    , m_isSpanningCompactEnabled(FALSE)
	//{
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Destroys an instance of the MediaTransportControls class.
	////
	////------------------------------------------------------------------------
	//MediaTransportControls::~MediaTransportControls()
	//{
	//    DeinitializeTransportControls();

	//    ReleaseMenuFlyoutItemClickHandlers();
	//    ReleaseCCSelectionMenuFlyoutItemClickHandlers();
	//    ReleasePlaybackRateMenuFlyoutItemClickHandlers();
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Create and initializes a MediaTransportControls instance
	////      associated with the provided MediaElement.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::Create(_Outptr_ MediaTransportControls** ppMediaTransportControls)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MediaTransportControls> spMediaTransportControls;

	//    // Instantiate the MediaTransportControls object
	//    IFC(ctl::make<MediaTransportControls>(&spMediaTransportControls));
	//    IFC(spMediaTransportControls.CopyTo(ppMediaTransportControls));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Initialize initial MTC state.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::Initialize()
	//{
	//    HRESULT hr = S_OK;

	//    IFC(MediaTransportControlsGenerated::Initialize());

	//    m_naturalDuration.TimeSpan.Duration = 0;
	//    m_naturalDuration.Type = xaml::DurationType_TimeSpan;
	//    m_positionSliderPressedEventToken.value = 0;
	//    m_positionSliderReleasedEventToken.value = 0;
	//    m_positionSliderKeyDownEventToken.value = 0;
	//    m_positionSliderKeyUpEventToken.value = 0;
	//    m_tokLayoutBoundsChanged.value = 0;
	//    m_tokCoreWindowKeyDown.value = 0;
	//    m_trackAddedEventToken.value = 0;
	//    m_castingDeviceSelectedToken.value = 0;
	//    m_castingPickerDismissedToken.value = 0;
	//    m_castingConnectStateChangeToken.value = 0;
	//    m_mediaPlayerMuteChangeToken.value = 0;
	//    m_mediaPlayerVolumeChangeToken.value = 0;
	//    m_mediaPlayerDownloadProgressChangeToken.value = 0;
	//    m_mediaPlayerCurrentStateChangeToken.value = 0;
	//    m_mediaPlayerNaturalDurationChangeToken.value = 0;
	//    m_mediaPlayerPositionChangeToken.value = 0;
	//    m_mediaPlayerMediaOpenedToken.value = 0;
	//    m_mediaPlayerMediaFailedToken.value = 0;
	//    m_mediaPlayerSourceChangeToken.value = 0;
	//    m_mediaPlayerItemFailedToken.value = 0;
	//    m_mediaPlayerItemChangedToken.value = 0;
	//    IFC(SetupDefaultProperties());
	//Cleanup:
	//    return hr;
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Enable the controls by initializing size and visual state,
	////       then appending them as child of the owner ME.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::Enable()
	//{
	//    HRESULT hr = S_OK;
	//    if (!m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // Set enabled flag here as it is checked by below calls
	//        m_transportControlsEnabled = TRUE;

	//        // Set initial visual state
	//        IFC(InitializeVisualState());

	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(EnableFromME());
	//        }
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Disable the transport controls by removing them from ME's children.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::Disable()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(StopPositionUpdateTimer());
	//        IFC(StopVerticalVolumeHideTimer());
	//        IFC(StopControlPanelHideTimer());
	//        if (m_isMiniView)
	//        {
	//            IFC(SetMiniView(false));
	//        }

	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(DisableFromME());
	//        }

	//        m_transportControlsEnabled = FALSE;
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::AddRegistrationCoreWindowKeyDown()
	//{
	//    // Add the core window key down event if doesn't exist
	//    if (m_tokCoreWindowKeyDown.value == 0)
	//    {
	//        Window *pWindow = DXamlCore::GetCurrent()->GetWindow();
	//        IFCPTR_RETURN(pWindow);
	//        {
	//            ctl::ComPtr<wuc::ICoreWindow> spCoreWindow;
	//            ctl::WeakRefPtr wrThis;
	//            // Using weak reference in event handler callback to make
	//            // sure this pointer still exist.If weak refereance as unreachable we won't call into it
	//            // as resolving weak reference returns NULL.
	//            IFC_RETURN(ctl::AsWeak(this, &wrThis));
	//            IFC_RETURN(pWindow->get_CoreWindow(&spCoreWindow));
	//            IFC_RETURN(spCoreWindow->add_KeyDown(
	//                wrl::Callback< Microsoft::WRL::Implements<
	//                Microsoft::WRL::RuntimeClassFlags<Microsoft::WRL::ClassicCom>,
	//                wf::ITypedEventHandler<wuc::CoreWindow*, wuc::KeyEventArgs*>,
	//                Microsoft::WRL::FtmBase >> (
	//                [wrThis](wuc::ICoreWindow*, wuc::IKeyEventArgs* pArgs) mutable -> HRESULT
	//            {
	//                ctl::ComPtr<MediaTransportControls> spThis;
	//                IFC_RETURN(wrThis.As(&spThis));
	//                if (spThis.Get())
	//                {
	//                    IFC_RETURN(spThis->OnCoreWindowKeyDown(pArgs));
	//                }
	//                return S_OK;
	//            }).Get(), &m_tokCoreWindowKeyDown));
	//        }
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::RemoveRegistrationCoreWindowKeyDown()
	//{
	//    // Remove the core window key down event.
	//    if (m_tokCoreWindowKeyDown.value)
	//    {
	//        ctl::ComPtr<wuc::ICoreWindow> spCoreWindow;
	//        Window *pWindow = DXamlCore::GetCurrent()->GetWindow();
	//        IFCPTR_RETURN(pWindow);
	//        IFC_RETURN(pWindow->get_CoreWindow(&spCoreWindow));
	//        IFC_RETURN(spCoreWindow->remove_KeyDown(m_tokCoreWindowKeyDown));
	//    }
	//    m_tokCoreWindowKeyDown.value = 0;

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Deinitilize the Tranport Contols.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::DeinitializeTransportControls()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_isMiniView)
	//    {
	//        IFC(SetMiniView(false));
	//    }

	//    // Note - DetacHandler() may no-op if already  being called
	//    //        This is ok since associated
	//    //        EventPtr's will also be destroyed in this codepath, and clean up
	//    //        the handlers.

	//    // Release Play button's event handlers
	//    IFC(DetachHandler(m_epPlayPauseButtonClickHandler, m_tpPlayPauseButton));
	//    IFC(DetachHandler(m_epLeftsidePlayPauseButtonClickHandler, m_tpTHLeftSidePlayPauseButton));

	//    // Release Audio Selection button's event handlers
	//    IFC(DetachHandler(m_epAudioSelectionButtonClickHandler, m_tpAudioSelectionButton));

	//    // Release Audio Selection button's event handlers for Threshold
	//    IFC(DetachHandler(m_epAudioTrackSelectionButtonClickHandler, m_tpTHAudioTrackSelectionButton));

	//    // Release Closed Caption Selection button's event handlers
	//    IFC(DetachHandler(m_epCCSelectionButtonClickHandler, m_tpCCSelectionButton));

	//    // Release Play Rate Selection button's event handlers
	//    IFC(DetachHandler(m_epPlaybackRateButtonClickHandler, m_tpPlaybackRateButton));

	//    // Release Video Mute/Volume button's event handlers
	//    IFC(DetachHandler(m_epVolumeButtonClickHandler, m_tpVideoVolumeButton));

	//    // Release Audio Mute button's event handlers
	//    IFC(DetachHandler(m_epAudioMuteButtonClickHandler, m_tpMuteButton));

	//    // Release Full Window button's event handlers
	//    IFC(DetachHandler(m_epFullWindowButtonClickHandler, m_tpFullWindowButton));

	//    // Release Zoom button's event handlers
	//    IFC(DetachHandler(m_epZoomButtonClickHandler, m_tpZoomButton));

	//    // Release other Media button's event handlers
	//    IFC(DetachHandler(m_epFastForwardButtonClickHandler, m_tpFastForwardButton));
	//    IFC(DetachHandler(m_epFastRewindButtonClickHandler, m_tpFastRewindButton));
	//    IFC(DetachHandler(m_epStopButtonClickHandler, m_tpStopButton));
	//    IFC(DetachHandler(m_epCastButtonClickHandler, m_tpCastButton));
	//    IFC(DetachHandler(m_epSkipForwardButtonClickHandler, m_tpSkipForwardButton));
	//    IFC(DetachHandler(m_epSkipBackwardButtonClickHandler, m_tpSkipBackwardButton));
	//    IFC(DetachHandler(m_epNextTrackButtonClickHandler, m_tpNextTrackButton));
	//    IFC(DetachHandler(m_epPreviousTrackButtonClickHandler, m_tpPreviousTrackButton));
	//    IFC(DetachHandler(m_epRepeatButtonClickHandler, m_tpRepeatButton));
	//    IFC(DetachHandler(m_epCompactOverlayButtonClickHandler, m_tpCompactOverlayButton));

	//    // Release Position Slider's event handlers
	//    IFC(DetachHandler(m_epProgressSliderSizeChangedHandler, m_tpMediaPositionSlider));
	//    IFC(DetachHandler(m_epProgressSliderFocusDisengagedHandler, m_tpMediaPositionSlider));
	//    IFC(DetachHandler(m_epPositionChangedHandler, m_tpMediaPositionSlider));
	//    {
	//        auto spMediaPositionSlider = m_tpMediaPositionSlider.GetSafeReference();

	//        if (spMediaPositionSlider)
	//        {
	//            IFC(spMediaPositionSlider.Cast<Slider>()->remove_PointerPressed(m_positionSliderPressedEventToken));
	//            IFC(spMediaPositionSlider.Cast<Slider>()->remove_PointerReleased(m_positionSliderReleasedEventToken));
	//            IFC(spMediaPositionSlider.Cast<Slider>()->remove_KeyDown(m_positionSliderKeyDownEventToken));
	//            IFC(spMediaPositionSlider.Cast<Slider>()->remove_KeyUp(m_positionSliderKeyUpEventToken));
	//        }
	//    }
	//    if (m_spCastingDevicePicker)
	//    {
	//        if (m_castingDeviceSelectedToken.value != 0)
	//        {
	//            IFC(m_spCastingDevicePicker->remove_CastingDeviceSelected(m_castingDeviceSelectedToken));
	//        }
	//        if (m_castingPickerDismissedToken.value != 0)
	//        {
	//            IFC(m_spCastingDevicePicker->remove_CastingDevicePickerDismissed(m_castingPickerDismissedToken));
	//            m_castingPickerDismissedToken.value = 0;
	//        }
	//        if (m_spCastingConnection && m_castingConnectStateChangeToken.value != 0)
	//        {
	//            IFC(m_spCastingConnection->remove_StateChanged(m_castingConnectStateChangeToken));
	//            m_castingConnectStateChangeToken.value = 0;
	//        }
	//        m_spCastingDevicePicker = nullptr;
	//    }

	//    // Release Horizontal volume slider's event handlers
	//    IFC(DetachHandler(m_epHorizontalVolumeChangedHandler, m_tpHorizontalVolumeSlider));

	//    // Release Threshold volume slider's event handlers
	//    IFC(DetachHandler(m_epVolumeChangedHandler, m_tpTHVolumeSlider));
	//    IFC(DetachHandler(m_volumeSliderPointerWheelChangedHandler, m_tpTHVolumeSlider));

	//    // Release Video volume button's event handlers
	//    IFC(DetachHandler(m_epVolumeButtonGotFocusHandler, m_tpVideoVolumeButton));

	//    // Release Vertical volume slider's event handlers
	//    IFC(DetachHandler(m_epVerticalVolumeChangedHandler, m_tpVerticalVolumeSlider));

	//    // Release control panel grid's event handlers
	//    IFC(DetachHandler(m_epControlPanelEnteredHandler, m_tpControlPanelGrid));
	//    IFC(DetachHandler(m_epControlPanelExitedHandler, m_tpControlPanelGrid));
	//    IFC(DetachHandler(m_epControlPanelTappedHandler, m_tpControlPanelGrid));
	//    IFC(DetachHandler(m_epControlPanelCaptureLostHandler, m_tpControlPanelGrid));
	//    IFC(DetachHandler(m_epControlPanelGotFocusHandler, m_tpControlPanelGrid));
	//    IFC(DetachHandler(m_epControlPanelLostFocusHandler, m_tpControlPanelGrid));

	//    IFC(DetachHandler(m_epBorderSizeChangedHandler, m_tpControlPanelVisibilityBorder));
	//    IFC(DetachHandler(m_visibilityStateChangedEventHandler, m_tpVisibilityStatesGroup));

	//    // Release Position Timer's event handlers
	//    IFC(DetachHandler(m_epPositionUpdateTimerTickHandler, m_tpPositionUpdateTimer));

	//    // Release Control Panel Hide Timer's event handlers
	//    IFC(DetachHandler(m_epHideControlPanelTimerTickHandler, m_tpHideControlPanelTimer));

	//    // Release Pointer Move Timer's event handlers
	//    IFC(DetachHandler(m_epPointerMoveEndTimerTickHandler, m_tpPointerMoveEndTimer));

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        IFC(DeinitializeTransportControlsFromME());
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//         IFC(DeinitializeTransportControlsFromMPE());
	//    }

	//    IFC(DetachHandler(m_epFlyoutOpenedHandler, m_tpVolumeFlyout));
	//    IFC(DetachHandler(m_epFlyoutClosedHandler, m_tpVolumeFlyout));

	//    DXamlCore::GetCurrent()->GetLayoutBoundsHelperNoRef()->RemoveLayoutBoundsChangedCallback(&m_tokLayoutBoundsChanged);

	//    IFC(RemoveRegistrationCoreWindowKeyDown());

	//    // Clean up any existing template parts
	//    m_tpControlPanelGrid.Clear();
	//    m_tpMediaPositionSlider.Clear();
	//    m_tpHorizontalVolumeSlider.Clear();
	//    m_tpVerticalVolumeSlider.Clear();
	//    m_tpActiveVolumeSlider.Clear();
	//    m_tpTHVolumeSlider.Clear();
	//    m_tpDownloadProgressIndicator.Clear();
	//    m_tpBufferingProgressBar.Clear();
	//    m_tpPlayPauseButton.Clear();
	//    m_tpTHLeftSidePlayPauseButton.Clear();
	//    m_tpAudioSelectionButton.Clear();
	//    m_tpTHAudioTrackSelectionButton.Clear();
	//    m_tpCCSelectionButton.Clear();
	//    m_tpPlaybackRateButton.Clear();
	//    m_tpAvailableAudioTracksMenuFlyout.Clear();
	//    m_tpAvailableAudioTracksMenuFlyoutTarget.Clear();
	//    m_tpAvailableCCTracksMenuFlyout.Clear();
	//    m_tpAvailablePlaybackRateMenuFlyout.Clear();
	//    m_tpVideoVolumeButton.Clear();
	//    m_tpMuteButton.Clear();
	//    m_tpTHVolumeButton.Clear();
	//    m_tpFullWindowButton.Clear();
	//    m_tpZoomButton.Clear();
	//    m_tpActiveVolumeButton.Clear();
	//    m_tpTimeElapsedElement.Clear();
	//    m_tpTimeRemainingElement.Clear();
	//    m_tpErrorTextBlock.Clear();
	//    m_tpPositionUpdateTimer.Clear();
	//    m_tpPointerMoveEndTimer.Clear();
	//    m_tpHideVerticalVolumeTimer.Clear();
	//    m_tpHideControlPanelTimer.Clear();
	//    m_tpFastForwardButton.Clear();
	//    m_tpFastRewindButton.Clear();
	//    m_tpStopButton.Clear();
	//    m_tpCommandBar.Clear();
	//    m_tpCastButton.Clear();
	//    m_tpVolumeFlyout.Clear();
	//    m_tpSkipForwardButton.Clear();
	//    m_tpSkipBackwardButton.Clear();
	//    m_tpNextTrackButton.Clear();
	//    m_tpPreviousTrackButton.Clear();
	//    m_tpRepeatButton.Clear();
	//    m_tpCompactOverlayButton.Clear();
	//    m_tpThumbnailImage.Clear();
	//    m_tpTimeElapsedPreview.Clear();
	//    m_tpControlPanelVisibilityBorder.Clear();
	//    m_tpVisibilityStatesGroup.Clear();

	//    if (m_spCurrentItem && m_trackAddedEventToken.value != 0)
	//    {
	//        IFC(m_spCurrentItem->remove_TimedMetadataTracksChanged(m_trackAddedEventToken));
	//        m_trackAddedEventToken.value = 0;
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Helper to get sizes of transport controls components
	////       defined as StaticResource's in Xaml.
	////
	////       Used for vertical volume height and dropout level calculations.
	//// 
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::GetComponentSizeConstants() noexcept
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IResourceDictionary> spResourceDictionary;
	//    ctl::ComPtr<wf::IPropertyValueStatics> spPropertyValueFactory;
	//    ctl::ComPtr<wf::IPropertyValue> spKeyAsPV;
	//    ctl::ComPtr<IInspectable> spValue;
	//    ctl::ComPtr<wf::IReference<DOUBLE>> spValueAsDouble;

	//    IFC(get_Resources(&spResourceDictionary));

	//    IFC(wf::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_Foundation_PropertyValue).Get(), spPropertyValueFactory.ReleaseAndGetAddressOf()));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCControlPanelHeight")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resControlPanelHeight));

	//    //
	//    // Sizes used for vertical volume height calculation
	//    //
	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCVerticalVolumeSliderMinHeight")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resVerticalVolumeSliderMinHeight));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCVerticalVolumeSliderMaxHeight")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resVerticalVolumeSliderMaxHeight));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCVerticalVolumeSliderTopPadding")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resVerticalVolumeSliderTopPadding));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCVerticalVolumeSliderTopGap")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resVerticalVolumeSliderTopGap));

	//    // Sizes used for dropout level calculation

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCSideMargins")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resSideMargins));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCMediaButtonWidth")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resMediaButtonWidth));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCTimeButtonWidth")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resTimeButtonWidth));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCPositionSliderMinimumWidth")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resPositionSliderMinimumWidth));

	//    IFC(spPropertyValueFactory->CreateString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MTCHorizontalVolumeSliderWidth")).Get(), &spKeyAsPV));
	//    IFC(spResourceDictionary.Cast<ResourceDictionary>()->Lookup(spKeyAsPV.Get(), &spValue));
	//    IFC(spValue.As(&spValueAsDouble));
	//    IFC(spValueAsDouble->get_Value(&m_resHorizontalVolumeSliderWidth));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Apply a template to the MediaTransportControls
	////
	////------------------------------------------------------------------------
	//IFACEMETHODIMP MediaTransportControls::OnApplyTemplate()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_parentType == MTCParent_None || m_wrOwnerParent.Get())
	//    {
	//        m_isTemplateApplied = TRUE;
	//        // Detach any existing handlers
	//        IFC(DeinitializeTransportControls());

	//        IFC(MediaTransportControlsGenerated::OnApplyTemplate());

	//        IFC(HookupPartsAndHandlers());

	//        // Initialize the visual state
	//        IFC(InitializeVisualState());

	//        // Update MediaControl States
	//        UpdateMediaControlAllStates();

	//        // Register Keydown Events on the onApplyTemplate.
	//        IFC(AddRegistrationCoreWindowKeyDown());
	//    }

	//Cleanup:
	//    return hr;
	//}


	//_Check_return_ HRESULT MediaTransportControls::UpdateSafeMargins(_In_ bool applySafeMargin)
	//{
	//    xaml::Thickness margin = {0};

	//    if (applySafeMargin)
	//    {
	//        ctl::ComPtr<xaml::IResourceDictionary> resources;
	//        ctl::ComPtr<IInspectable> boxedResourceKey;
	//        ctl::ComPtr<wfc::IMap<IInspectable*, IInspectable*>> resourcesMap;
	//        BOOLEAN doesResourceExist = FALSE;
	//        IFC_RETURN(get_Resources(&resources));
	//        IFC_RETURN(resources.As(&resourcesMap));
	//        IFC_RETURN(PropertyValue::CreateFromString(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"MediaTransportControlsTitleSafeBounds")).Get(), &boxedResourceKey));
	//        IFC_RETURN(resourcesMap->HasKey(boxedResourceKey.Get(), &doesResourceExist));
	//        // Developer have options to change desiredbounds or override the MediaTransportControlsTitleSafeBounds resource key to override this.
	//        if (doesResourceExist)
	//        {
	//            ctl::ComPtr<IInspectable> boxedResource;
	//            IFC_RETURN(resourcesMap->Lookup(boxedResourceKey.Get(), &boxedResource));
	//            IFCPTR_RETURN(boxedResource);
	//            auto thicknessReference = ctl::query_interface_cast<wf::IReference<xaml::Thickness>>(boxedResource.Get());
	//            IFC_RETURN(thicknessReference->get_Value(&margin));
	//        }
	//    }

	//    if (m_tpControlPanelGrid)
	//    {
	//        IFC_RETURN(m_tpControlPanelGrid.Cast<Grid>()->put_Margin(margin));
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT MediaTransportControls::UpdateSafeMarginsinFullWindow(_In_ bool applySafeMargin)
	//{
	//    if (XboxUtility::IsOnXbox())
	//    {
	//        wuv::ApplicationViewBoundsMode boundsMode;
	//        IFC_RETURN(LayoutBoundsChangedHelper::GetDesiredBoundsMode(&boundsMode));
	//        // Update safemargin in useVisible mode in the fullwindow
	//        if (boundsMode == wuv::ApplicationViewBoundsMode::ApplicationViewBoundsMode_UseVisible)
	//        {
	//            IFC_RETURN(UpdateSafeMargins(applySafeMargin));
	//        }
	//    }
	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Obtain references for control components to be
	////       manipulated and hook up handlers for events to be handled.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::HookupPartsAndHandlers()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IDependencyObject> spComponentAsDO;
	//    wrl_wrappers::HString strAutomationName;
	//    wrl_wrappers::HString strSeparator;
	//    wrl_wrappers::HString strSkipString;
	//    wf::TimeSpan positionUpdateTickFrequency;
	//    wf::TimeSpan controlPanelDisplayTimeoutFrequency;
	//    wf::TimeSpan pointerMoveEndTimeout;
	//    ctl::ComPtr<DispatcherTimer> spPositionUpdateTimer;
	//    ctl::ComPtr<DispatcherTimer> spHideControlPanelTimer;
	//    ctl::ComPtr<DispatcherTimer> spPointerMoveEndTimer;

	//    // Types and variables for handlers created with ClassMemberEventHandler<> (which supports setting handledEventsToo flag)
	//    typedef CRoutedEventSource<xaml_input::IPointerEventHandler, IInspectable, xaml_input::IPointerRoutedEventArgs> PointerPressedEventSourceType;
	//    typedef CRoutedEventSource<xaml_input::IPointerEventHandler, IInspectable, xaml_input::IPointerRoutedEventArgs> PointerReleasedEventSourceType;
	//    typedef CRoutedEventSource<xaml_input::IKeyEventHandler, IInspectable, xaml_input::IKeyRoutedEventArgs> KeyDownEventSourceType;
	//    typedef CRoutedEventSource<xaml_input::IKeyEventHandler, IInspectable, xaml_input::IKeyRoutedEventArgs> KeyUpEventSourceType;
	//    ctl::ComPtr<xaml_input::IPointerEventHandler> spPositionSliderPressedHandler;
	//    PointerPressedEventSourceType* pPositionSliderPressedEventSource = nullptr;
	//    ctl::ComPtr<xaml_input::IPointerEventHandler> spPositionSliderReleasedHandler;
	//    PointerReleasedEventSourceType* pPositionSliderReleasedEventSource = nullptr;
	//    ctl::ComPtr<xaml_input::IKeyEventHandler> spPositionSliderKeyDownHandler;
	//    KeyDownEventSourceType* pPositionSliderKeyDownEventSource = nullptr;
	//    ctl::ComPtr<xaml_input::IKeyEventHandler> spPositionSliderKeyUpHandler;
	//    KeyUpEventSourceType* pPositionSliderKeyUpEventSource = nullptr;

	//    // Get the parts for obtain reference
	//    // No-op if part deosn't available
	//    // Also set localized UIA Name and add Tooltip where applicable. Note that
	//    // both use the same localized text strings.

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"ControlPanelGrid").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpControlPanelGrid, spComponentAsDO.Get());

	//    // Need to set Title Safe zone for Xbox
	//    if (m_tpControlPanelGrid && XboxUtility::IsOnXbox())
	//    {
	//        wuv::ApplicationViewBoundsMode boundsMode;
	//        IFC(LayoutBoundsChangedHelper::GetDesiredBoundsMode(&boundsMode));

	//        // Apply Title safe marigins only if desired bounds as UseCoreWindow
	//        // If we're in UseVisible mode, then the framework is already laying things out to the TV safe bounds so the MTC doesn't need to do anything.
	//        // In UseCoreWindow, the app has decided they're smart enough to lay out to the screen and will do TV safe bounds themselves - but for MTC
	//        // they can't do that specifically so thy need the framework to do this anyway.Thus, the only time MTC's code needs to do TV safe correction is in UseCoreWindow.
	//        if (wuv::ApplicationViewBoundsMode::ApplicationViewBoundsMode_UseCoreWindow == boundsMode)
	//        {
	//            IFC(UpdateSafeMargins(true /*apply safe region margin*/));
	//        }
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"TimeElapsedElement").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTimeElapsedElement, spComponentAsDO.Get());
	//    if (m_tpTimeElapsedElement)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_TIME_ELAPSED, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTimeElapsedElement.Cast<FrameworkElement>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTimeElapsedElement.Cast<FrameworkElement>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"TimeRemainingElement").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTimeRemainingElement, spComponentAsDO.Get());

	//    if (m_tpTimeRemainingElement)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_TIME_REMAINING, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTimeRemainingElement.Cast<FrameworkElement>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTimeRemainingElement.Cast<FrameworkElement>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"ProgressSlider").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpMediaPositionSlider, spComponentAsDO.Get());
	//    if (m_tpMediaPositionSlider)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_SEEK, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpMediaPositionSlider.Cast<Slider>(), strAutomationName));
	//        IFC(AddTooltip(m_tpMediaPositionSlider.Cast<Slider>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"PlayPauseButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpPlayPauseButton, spComponentAsDO.Get());
	//    if (m_tpPlayPauseButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_PLAY, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpPlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpPlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"PlayPauseButtonOnLeft").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTHLeftSidePlayPauseButton, spComponentAsDO.Get());
	//    if (m_tpTHLeftSidePlayPauseButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_PLAY, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"FullWindowButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpFullWindowButton, spComponentAsDO.Get());
	//    if (m_tpFullWindowButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_FULLSCREEN, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpFullWindowButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpFullWindowButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"ZoomButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpZoomButton, spComponentAsDO.Get());
	//    if (m_tpZoomButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_ASPECTRATIO, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpZoomButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpZoomButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"ErrorTextBlock").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpErrorTextBlock, spComponentAsDO.Get());
	//    if (m_tpErrorTextBlock)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_ERROR, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpErrorTextBlock.Cast<TextBlock>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"MediaControlsCommandBar").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpCommandBar, spComponentAsDO.Get());

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"VolumeFlyout").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpVolumeFlyout, spComponentAsDO.Get());

	//    // Attach handlers for events we need to track
	//    IFC(m_epRootUserControlLoadedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml::IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnRootUserControlLoaded());
	//        }));
	//    if (m_tpPlayPauseButton)
	//    {
	//        IFC(m_epPlayPauseButtonClickHandler.AttachEventHandler(m_tpPlayPauseButton.Cast<ButtonBase>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//            {
	//                RRETURN(OnPlayPauseClick());
	//            }));
	//    }
	//    if (m_tpTHLeftSidePlayPauseButton)
	//    {
	//        IFC(m_epLeftsidePlayPauseButtonClickHandler.AttachEventHandler(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnPlayPauseClick());
	//        }));
	//    }
	//    if (m_tpFullWindowButton)
	//    {
	//        IFC(m_epFullWindowButtonClickHandler.AttachEventHandler(m_tpFullWindowButton.Cast<ButtonBase>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//            {
	//                RRETURN(OnFullWindowClick());
	//            }));
	//    }
	//    if (m_tpZoomButton)
	//    {
	//        IFC(m_epZoomButtonClickHandler.AttachEventHandler(m_tpZoomButton.Cast<ButtonBase>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//            {
	//                RRETURN(OnZoomClick());
	//            }));
	//    }
	//    if (m_tpMediaPositionSlider)
	//    {
	//        IFC(m_epProgressSliderSizeChangedHandler.AttachEventHandler(m_tpMediaPositionSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, ISizeChangedEventArgs *pArgs)
	//            {
	//                RRETURN(OnProgressSliderSizeChanged());
	//            }));

	//        IFC(m_epProgressSliderFocusDisengagedHandler.AttachEventHandler(m_tpMediaPositionSlider.AsOrNull<xaml_controls::IControl>().Get(),
	//            [this](xaml_controls::IControl *pSender, IFocusDisengagedEventArgs *pArgs)
	//            {
	//                RRETURN(OnProgressSliderFocusDisengaged());
	//            }));


	//        IFC(m_epPositionChangedHandler.AttachEventHandler(m_tpMediaPositionSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, xaml_primitives::IRangeBaseValueChangedEventArgs *pArgs)
	//            {
	//                RRETURN(OnPositionSliderValueChanged(pSender, pArgs));
	//            }));

	//        // Position update timer
	//        spPositionSliderPressedHandler.Attach(CREATE_MEDIA_POINTER_EVENT_HANDLER(&MediaTransportControls::OnPositionSliderPressed));
	//        IFC(m_tpMediaPositionSlider.Cast<Slider>()->GetPointerPressedEventSourceNoRef(&pPositionSliderPressedEventSource));
	//        IFC(pPositionSliderPressedEventSource->AddHandler(spPositionSliderPressedHandler.Get(), TRUE /* handledEventsToo */));
	//        m_positionSliderPressedEventToken.value = reinterpret_cast<INT64>(spPositionSliderPressedHandler.Get());

	//        spPositionSliderReleasedHandler.Attach(CREATE_MEDIA_POINTER_EVENT_HANDLER(&MediaTransportControls::OnPositionSliderReleased));
	//        IFC(m_tpMediaPositionSlider.Cast<Slider>()->GetPointerReleasedEventSourceNoRef(&pPositionSliderReleasedEventSource));
	//        IFC(pPositionSliderReleasedEventSource->AddHandler(spPositionSliderReleasedHandler.Get(), TRUE /* handledEventsToo */));
	//        m_positionSliderReleasedEventToken.value = reinterpret_cast<INT64>(spPositionSliderReleasedHandler.Get());

	//        spPositionSliderKeyDownHandler.Attach(CREATE_MEDIA_KEY_EVENT_HANDLER(&MediaTransportControls::OnPositionSliderKeyDown));
	//        IFC(m_tpMediaPositionSlider.Cast<Slider>()->GetKeyDownEventSourceNoRef(&pPositionSliderKeyDownEventSource));
	//        IFC(pPositionSliderKeyDownEventSource->AddHandler(spPositionSliderKeyDownHandler.Get(), TRUE /* handledEventsToo */));
	//        m_positionSliderKeyDownEventToken.value = reinterpret_cast<INT64>(spPositionSliderKeyDownHandler.Get());

	//        spPositionSliderKeyUpHandler.Attach(CREATE_MEDIA_KEY_EVENT_HANDLER(&MediaTransportControls::OnPositionSliderKeyUp));
	//        IFC(m_tpMediaPositionSlider.Cast<Slider>()->GetKeyUpEventSourceNoRef(&pPositionSliderKeyUpEventSource));
	//        IFC(pPositionSliderKeyUpEventSource->AddHandler(spPositionSliderKeyUpHandler.Get(), TRUE /* handledEventsToo */));
	//        m_positionSliderKeyUpEventToken.value = reinterpret_cast<INT64>(spPositionSliderKeyUpHandler.Get());

	//        IFC(ctl::make<DispatcherTimer>(&spPositionUpdateTimer));
	//        SetPtrValueWithQIOrNull(m_tpPositionUpdateTimer, spPositionUpdateTimer.Get());

	//        positionUpdateTickFrequency.Duration = static_cast<INT64>(SeekbarPositionUpdateFreqInSecs * static_cast<DOUBLE> (HNSPerSecond));
	//        IFC(m_tpPositionUpdateTimer.Cast<DispatcherTimer>()->put_Interval(positionUpdateTickFrequency));

	//        IFC(m_epPositionUpdateTimerTickHandler.AttachEventHandler(m_tpPositionUpdateTimer.Cast<DispatcherTimer>(),
	//            [this](IInspectable *pSender, IInspectable *pArgs)
	//        {
	//            RRETURN(OnPositionUpdateTimerTick());
	//        }));

	//        IFC(EnableValueChangedEventThrottlingOnSliderAutomation(true));
	//    }

	//    if (m_tpControlPanelGrid)
	//    {
	//        IFC(m_epControlPanelEnteredHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//            {
	//                RRETURN(OnControlPanelEntered());
	//            }));

	//        IFC(m_epControlPanelExitedHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//            {
	//                RRETURN(OnControlPanelExited());
	//            }));

	//        IFC(m_epControlPanelCaptureLostHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//            {
	//                RRETURN(OnControlPanelCaptureLost(pArgs));
	//            }));

	//        IFC(m_epControlPanelGotFocusHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable *pSender, xaml::IRoutedEventArgs *pArgs)
	//            {
	//                RRETURN(OnControlPanelGotFocus(pArgs));
	//            }));

	//        IFC(m_epControlPanelLostFocusHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable *pSender, xaml::IRoutedEventArgs *pArgs)
	//            {
	//                RRETURN(OnControlPanelLostFocus(pArgs));
	//            }));

	//        IFC(ctl::make<DispatcherTimer>(&spHideControlPanelTimer));
	//        SetPtrValueWithQIOrNull(m_tpHideControlPanelTimer, spHideControlPanelTimer.Get());

	//        controlPanelDisplayTimeoutFrequency.Duration = static_cast<INT64>(ControlPanelDisplayTimeoutInSecs * static_cast<DOUBLE> (HNSPerSecond));
	//        IFC(m_tpHideControlPanelTimer.Cast<DispatcherTimer>()->put_Interval(controlPanelDisplayTimeoutFrequency));

	//        IFC(m_epHideControlPanelTimerTickHandler.AttachEventHandler(m_tpHideControlPanelTimer.Cast<DispatcherTimer>(),
	//            [this](IInspectable *pSender, IInspectable *pArgs)
	//        {
	//            RRETURN(OnHideControlPanelTimerTick());
	//        }));

	//        // Look for TranslateVertical Transform, if exist then need to clip the border on the size change.
	//        ctl::ComPtr<IInspectable> spTranformAsII;
	//        ctl::ComPtr<IFrameworkElement> spControlPanelGridAsIFE;
	//        IFC(m_tpControlPanelGrid.As(&spControlPanelGridAsIFE));
	//        IFC(spControlPanelGridAsIFE->FindName(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"TranslateVertical")).Get(),
	//                            &spTranformAsII));
	//        if (spTranformAsII)
	//        {
	//            IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"ControlPanel_ControlPanelVisibilityStates_Border").Get(), &spComponentAsDO));
	//            SetPtrValueWithQIOrNull(m_tpControlPanelVisibilityBorder, spComponentAsDO.Get());
	//            if (m_tpControlPanelVisibilityBorder)
	//            {
	//                IFC(m_epBorderSizeChangedHandler.AttachEventHandler(m_tpControlPanelVisibilityBorder.Cast<Border>(),
	//                    [this](IInspectable *pSender, IInspectable *pArgs)
	//                {
	//                    RRETURN(OnBorderSizeChanged());
	//                }));
	//            }
	//        }
	//    }

	//    IFC(m_epRootExitedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnRootExited());
	//        }));

	//    IFC(m_epRootPressedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnRootPressed());
	//        }));

	//    IFC(m_epRootReleasedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnRootReleased());
	//        }));

	//    IFC(m_epRootCaptureLostHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnRootCaptureLost());
	//        }));

	//    IFC(m_epRootMovedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnRootMoved());
	//        }));


	//    IFC(m_epSizeChangedHandler.AttachEventHandler(this,
	//        [this](IInspectable *pSender, IInspectable *pArgs)
	//        {
	//            RRETURN(OnSizeChanged());
	//        }));

	//    if (m_tpCommandBar)
	//    {
	//        // Attach handlers for CommandBar Loaded
	//        IFC(m_epCommandBarLoadedHandler.AttachEventHandler(m_tpCommandBar.Cast<CommandBar>(),
	//            [this](IInspectable *pSender, xaml::IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnCommandBarLoaded());
	//        }));
	//    }

	//    if (m_tpVolumeFlyout)
	//    {
	//        // Attach handler for Flyout Opened
	//        IFC(m_epFlyoutOpenedHandler.AttachEventHandler(m_tpVolumeFlyout.Cast<FlyoutBase>(),
	//            [this](IInspectable* pSender, IInspectable* pArgs)
	//        {
	//            // if volume flyout open, we should not hide MTC panel
	//            m_isFlyoutOpen = TRUE;
	//            return S_OK;
	//        }));
	//        // Attach handler for Flyout Closed
	//        IFC(m_epFlyoutClosedHandler.AttachEventHandler(m_tpVolumeFlyout.Cast<FlyoutBase>(),
	//            [this](IInspectable* pSender, IInspectable* pArgs)
	//        {
	//            m_isFlyoutOpen = FALSE;
	//            HideControlPanel();
	//            return S_OK;
	//        }));

	//        IFC(m_tpVolumeFlyout.Cast<FlyoutBase>()->put_ShouldConstrainToRootBounds(TRUE));
	//    }

	//    IFC(ctl::make<DispatcherTimer>(&spPointerMoveEndTimer));
	//    SetPtrValueWithQIOrNull(m_tpPointerMoveEndTimer, spPointerMoveEndTimer.Get());

	//    pointerMoveEndTimeout.Duration = 0;
	//    IFC(m_tpPointerMoveEndTimer.Cast<DispatcherTimer>()->put_Interval(pointerMoveEndTimeout));

	//    IFC(m_epPointerMoveEndTimerTickHandler.AttachEventHandler(m_tpPointerMoveEndTimer.Cast<DispatcherTimer>(),
	//        [this](IInspectable *pSender, IInspectable *pArgs)
	//    {
	//        m_isPointerMove = FALSE;
	//        if (m_tpPointerMoveEndTimer)
	//        {
	//            m_tpPointerMoveEndTimer->Stop();
	//        }
	//        RRETURN(StartControlPanelHideTimer());
	//    }));

	//    IFC(HookupVolumeAndProgressPartsAndHandlers());

	//    if (m_tpControlPanelGrid)
	//    {
	//        IFC(m_epControlPanelTappedHandler.AttachEventHandler(m_tpControlPanelGrid.Cast<Grid>(),
	//            [this](IInspectable* pSender, xaml_input::ITappedRoutedEventArgs* pArgs)
	//            {
	//                RRETURN(OnControlPanelTapped(pArgs));
	//            }));
	//    }

	//    IFC(GetComponentSizeConstants());
	//    IFC(MoreControls());
	//    IFC(SetTabIndex());

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::HookupVolumeAndProgressPartsAndHandlers()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IDependencyObject> spComponentAsDO;
	//    wrl_wrappers::HString strAutomationName;
	//    ctl::ComPtr<DispatcherTimer> spHideVerticalVolumeTimer;
	//    wf::TimeSpan verticalVolumeDisplayTimeoutFrequency;
	//    ctl::ComPtr<xaml_controls::IButton> spSeekButton;

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"HorizontalVolumeSlider").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpHorizontalVolumeSlider, spComponentAsDO.Get());
	//    if (m_tpHorizontalVolumeSlider)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_VOLUME, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpHorizontalVolumeSlider.Cast<Slider>(), strAutomationName));
	//        IFC(AddTooltip(m_tpHorizontalVolumeSlider.Cast<Slider>(), strAutomationName));
	//    }


	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"VerticalVolumeSlider").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpVerticalVolumeSlider, spComponentAsDO.Get());
	//    if (m_tpVerticalVolumeSlider)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_VOLUME, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpVerticalVolumeSlider.Cast<Slider>(), strAutomationName));
	//        IFC(AddTooltip(m_tpVerticalVolumeSlider.Cast<Slider>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"VolumeSlider").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTHVolumeSlider, spComponentAsDO.Get());
	//    if (m_tpTHVolumeSlider)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_VOLUME, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTHVolumeSlider.Cast<Slider>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTHVolumeSlider.Cast<Slider>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"AudioSelectionButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpAudioSelectionButton, spComponentAsDO.Get());
	//    if (m_tpAudioSelectionButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_AUDIO_SELECTION, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpAudioSelectionButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpAudioSelectionButton.Cast<Button>(), strAutomationName));
	//    }

	//    // Audio Track Selection for Threshold and Flyout attached to it.
	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"AudioTracksSelectionButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTHAudioTrackSelectionButton, spComponentAsDO.Get());
	//    if (m_tpTHAudioTrackSelectionButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_AUDIO_SELECTION, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTHAudioTrackSelectionButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTHAudioTrackSelectionButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"AvailableAudioTracksMenuFlyout").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpAvailableAudioTracksMenuFlyout, spComponentAsDO.Get());

	//    if (m_tpAvailableAudioTracksMenuFlyout)
	//    {
	//        IFC(m_tpAvailableAudioTracksMenuFlyout.Cast<MenuFlyout>()->put_ShouldConstrainToRootBounds(TRUE));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"AvailableAudioTracksMenuFlyoutTarget").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpAvailableAudioTracksMenuFlyoutTarget, spComponentAsDO.Get());

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"CCSelectionButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpCCSelectionButton, spComponentAsDO.Get());
	//    if (m_tpCCSelectionButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_CC_SELECTION, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpCCSelectionButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpCCSelectionButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"PlaybackRateButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpPlaybackRateButton, spComponentAsDO.Get());
	//    if (m_tpPlaybackRateButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_PLAYBACKRATE, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpPlaybackRateButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpPlaybackRateButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"VolumeButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpVideoVolumeButton, spComponentAsDO.Get());
	//    if (m_tpVideoVolumeButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_VOLUME, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpVideoVolumeButton.Cast<ToggleButton>(), strAutomationName));
	//        IFC(AddTooltip(m_tpVideoVolumeButton.Cast<ToggleButton>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"AudioMuteButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpMuteButton, spComponentAsDO.Get());
	//    if (m_tpMuteButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_MUTE, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpMuteButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpMuteButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"VolumeMuteButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpTHVolumeButton, spComponentAsDO.Get());
	//    if (m_tpTHVolumeButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_MUTE, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTHVolumeButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpTHVolumeButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"BufferingProgressBar").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpBufferingProgressBar, spComponentAsDO.Get());
	//    if (m_tpBufferingProgressBar)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_BUFFERING_PROGRESS, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpBufferingProgressBar.Cast<ProgressBar>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"FastForwardButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpFastForwardButton, spComponentAsDO.Get());
	//    if (m_tpFastForwardButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_FASTFORWARD, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpFastForwardButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpFastForwardButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"RewindButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpFastRewindButton, spComponentAsDO.Get());
	//    if (m_tpFastRewindButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_REWIND, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpFastRewindButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpFastRewindButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"StopButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpStopButton, spComponentAsDO.Get());
	//    if (m_tpStopButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_STOP, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpStopButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpStopButton.Cast<Button>(), strAutomationName));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"CastButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpCastButton, spComponentAsDO.Get());
	//    if (m_tpCastButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_CAST, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpCastButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpCastButton.Cast<Button>(), strAutomationName));
	//    }

	//    if (m_tpAudioSelectionButton)
	//    {
	//        IFC(m_epAudioSelectionButtonClickHandler.AttachEventHandler(m_tpAudioSelectionButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnAudioSelectionButtonClick());
	//        }));
	//    }

	//    if (m_tpTHAudioTrackSelectionButton)
	//    {
	//        IFC(m_epAudioTrackSelectionButtonClickHandler.AttachEventHandler(m_tpTHAudioTrackSelectionButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnTHAudioTrackSelectionButtonClick());
	//        }));
	//    }

	//    if (m_tpCCSelectionButton)
	//    {
	//        IFC(m_epCCSelectionButtonClickHandler.AttachEventHandler(m_tpCCSelectionButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnCCSelectionButtonClick());
	//        }));
	//    }

	//    if (m_tpPlaybackRateButton)
	//    {
	//        IFC(m_epPlaybackRateButtonClickHandler.AttachEventHandler(m_tpPlaybackRateButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnPlaybackRateButtonClick());
	//        }));
	//    }

	//    if (m_tpVideoVolumeButton)
	//    {

	//        IFC(m_epVolumeButtonClickHandler.AttachEventHandler(m_tpVideoVolumeButton.Cast<ToggleButton>(),
	//        [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnVolumeClick());
	//        }));

	//        IFC(m_epVolumeButtonGotFocusHandler.AttachEventHandler(m_tpVideoVolumeButton.Cast<ToggleButton>(),
	//            [this](IInspectable *pSender, xaml::IRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnVolumeButtonGotFocus(pArgs));
	//        }));
	//    }

	//    if (m_tpMuteButton)
	//    {
	//        IFC(m_epAudioMuteButtonClickHandler.AttachEventHandler(m_tpMuteButton.Cast<ButtonBase>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnMuteClick());
	//        }));
	//    }

	//    if (m_tpHorizontalVolumeSlider)
	//    {

	//        IFC(m_epHorizontalVolumeChangedHandler.AttachEventHandler(m_tpHorizontalVolumeSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, xaml_primitives::IRangeBaseValueChangedEventArgs *pArgs)
	//        {
	//            RRETURN(OnVolumeSliderValueChanged());
	//        }));
	//    }

	//    if (m_tpVerticalVolumeSlider)
	//    {
	//        IFC(m_epVerticalVolumeChangedHandler.AttachEventHandler(m_tpVerticalVolumeSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, xaml_primitives::IRangeBaseValueChangedEventArgs *pArgs)
	//        {
	//            RRETURN(OnVolumeSliderValueChanged());
	//        }));
	//    }

	//    if (m_tpTHVolumeSlider)
	//    {

	//        IFC(m_epVolumeChangedHandler.AttachEventHandler(m_tpTHVolumeSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, xaml_primitives::IRangeBaseValueChangedEventArgs *pArgs)
	//        {
	//            RRETURN(OnVolumeSliderValueChanged());
	//        }));

	//        IFC(m_volumeSliderPointerWheelChangedHandler.AttachEventHandler(m_tpTHVolumeSlider.Cast<Slider>(),
	//            [this](IInspectable *pSender, xaml_input::IPointerRoutedEventArgs *pArgs)
	//        {
	//            RRETURN(OnVolumeSliderPointerWheelChanged(pSender, pArgs));
	//        }));
	//    }

	//    if (m_tpFastForwardButton)
	//    {
	//        IFC(m_epFastForwardButtonClickHandler.AttachEventHandler(m_tpFastForwardButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnFastForwardButtonClicked());
	//        }));
	//    }

	//    if (m_tpFastRewindButton)
	//    {
	//        IFC(m_epFastRewindButtonClickHandler.AttachEventHandler(m_tpFastRewindButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnFastRewindButtonClicked());
	//        }));
	//    }

	//    if (m_tpStopButton)
	//    {
	//        IFC(m_epStopButtonClickHandler.AttachEventHandler(m_tpStopButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnStopButtonClicked());
	//        }));
	//    }

	//    if (m_tpCastButton)
	//    {
	//        IFC(m_epCastButtonClickHandler.AttachEventHandler(m_tpCastButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnCastButtonClicked());
	//        }));
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Hookup new Controls for Redstone
	////
	////------------------------------------------------------------------------

	//_Check_return_ HRESULT
	//MediaTransportControls::MoreControls()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IDependencyObject> spComponentAsDO;
	//    wrl_wrappers::HString strAutomationName;
	//    ctl::ComPtr<IVisualStateGroup> spVisibilityStatesGroup;

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"SkipForwardButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpSkipForwardButton, spComponentAsDO.Get());
	//    if (m_tpSkipForwardButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_SKIPFORWARD, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpSkipForwardButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpSkipForwardButton.Cast<Button>(), strAutomationName));

	//        IFC(m_epSkipForwardButtonClickHandler.AttachEventHandler(m_tpSkipForwardButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(SkipForward());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"SkipBackwardButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpSkipBackwardButton, spComponentAsDO.Get());
	//    if (m_tpSkipBackwardButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_SKIPBACKWARD, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpSkipBackwardButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpSkipBackwardButton.Cast<Button>(), strAutomationName));

	//        IFC(m_epSkipBackwardButtonClickHandler.AttachEventHandler(m_tpSkipBackwardButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(SkipBackward());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"NextTrackButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpNextTrackButton, spComponentAsDO.Get());
	//    if (m_tpNextTrackButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_NEXTRACK, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpNextTrackButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpNextTrackButton.Cast<Button>(), strAutomationName));

	//        IFC(m_epNextTrackButtonClickHandler.AttachEventHandler(m_tpNextTrackButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(NextTrack());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"PreviousTrackButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpPreviousTrackButton, spComponentAsDO.Get());
	//    if (m_tpPreviousTrackButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_PREVIOUSTRACK, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpPreviousTrackButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpPreviousTrackButton.Cast<Button>(), strAutomationName));

	//        IFC(m_epPreviousTrackButtonClickHandler.AttachEventHandler(m_tpPreviousTrackButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(PreviousTrack());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"RepeatButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpRepeatButton, spComponentAsDO.Get());
	//    if (m_tpRepeatButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_REPEAT_NONE, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpRepeatButton.Cast<ToggleButton>(), strAutomationName));
	//        IFC(AddTooltip(m_tpRepeatButton.Cast<ToggleButton>(), strAutomationName));
	//        IFC(m_epRepeatButtonClickHandler.AttachEventHandler(m_tpRepeatButton.Cast<ToggleButton>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnRepeatButtonClicked());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"CompactOverlayButton").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpCompactOverlayButton, spComponentAsDO.Get());
	//    if (m_tpCompactOverlayButton)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_MINIVIEW, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpCompactOverlayButton.Cast<Button>(), strAutomationName));
	//        IFC(AddTooltip(m_tpCompactOverlayButton.Cast<Button>(), strAutomationName));

	//        IFC(m_epCompactOverlayButtonClickHandler.AttachEventHandler(m_tpCompactOverlayButton.Cast<Button>(),
	//            [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//        {
	//            RRETURN(OnCompactOverlayButtonClicked());
	//        }));
	//    }

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"LeftSeparator").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpLeftAppBarSeparator, spComponentAsDO.Get());

	//    IFC(GetTemplateChild(wrl_wrappers::HStringReference(L"RightSeparator").Get(), &spComponentAsDO));
	//    SetPtrValueWithQIOrNull(m_tpRightAppBarSeparator, spComponentAsDO.Get());

	//    // This is specific fix to Movies&TV app(re-template without commandbar)
	//    // Listen Visibility visual state changes which can triggers through app by retemplate. so that we should sync MTC internal state with VisualStates.
	//    if (!m_tpCommandBar.Get())
	//    {
	//        IFC(GetTemplatePart<IVisualStateGroup>(STR_LEN_PAIR(L"ControlPanelVisibilityStates"), spVisibilityStatesGroup.ReleaseAndGetAddressOf()));
	//        SetPtrValue(m_tpVisibilityStatesGroup, spVisibilityStatesGroup.Get());

	//        if (m_tpVisibilityStatesGroup)
	//        {
	//            IFC(m_visibilityStateChangedEventHandler.AttachEventHandler(m_tpVisibilityStatesGroup.Get(),
	//                [this](IInspectable* pSender, IVisualStateChangedEventArgs* pArgs)
	//            {
	//                RRETURN(OnVisibilityVisualStateChanged(pArgs));
	//            }));
	//        }
	//    }

	//Cleanup:
	//    RRETURN(hr);
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Initialize the UI / visual state of the Transport Controls.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::InitializeVisualState()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_wrOwnerParent.Get())
	//    {
	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(InitializeVisualStateFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(InitializeVisualStateFromMPE());
	//        }

	//        IFC(InitializeVolume());

	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            // Make sure we have the latest playback item
	//            IFC(UpdatePlaybackItemReference());
	//        }

	//        IFC(UpdateRepeatButtonUI());

	//        // Update UI
	//        IFC(UpdatePlayPauseUI());
	//        IFC(UpdateFullWindowUI());
	//        IFC(UpdatePositionUI());
	//        IFC(UpdateDownloadProgressUI());
	//        IFC(UpdateErrorUI());

	//        if (m_tpMediaPositionSlider)
	//        {
	//            IFC(m_tpMediaPositionSlider.Cast<Slider>()->get_Minimum(&m_positionSliderMinimum));
	//            IFC(m_tpMediaPositionSlider.Cast<Slider>()->get_Maximum(&m_positionSliderMaximum));
	//        }

	//        // We could have switched into or out of audio mode, which changes the controls that are displayed.
	//        IFC(UpdateAudioSelectionUI());
	//        IFC(UpdateIsMutedUI());
	//        IFC(UpdateVolumeUI());
	//        IFC(CalculateDropOutLevel());

	//        // ShowControlPanel() calls UpdateVisualState()
	//        IFC(ShowControlPanel());
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Initialize state specific to video mode.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::InitializeVideo()
	//{
	//    HRESULT hr = S_OK;

	//    // Set references to video-mode volume parts
	//    if (m_tpVerticalVolumeSlider)
	//    {
	//        SetPtrValue(m_tpActiveVolumeSlider, m_tpVerticalVolumeSlider.Get());
	//        // Cache slider min/max
	//        IFC(m_tpVerticalVolumeSlider.Cast<Slider>()->get_Minimum(&m_volumeSliderMinimum));
	//        IFC(m_tpVerticalVolumeSlider.Cast<Slider>()->get_Maximum(&m_volumeSliderMaximum));
	//    }

	//    if (m_tpVideoVolumeButton)
	//    {
	//        SetPtrValue(m_tpActiveVolumeButton, m_tpVideoVolumeButton.Get());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Initialize state specific to audio mode.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::InitializeAudio()
	//{
	//    HRESULT hr = S_OK;

	//    // Set references to audio-mode volume parts
	//    if (m_tpHorizontalVolumeSlider)
	//    {
	//        SetPtrValue(m_tpActiveVolumeSlider, m_tpHorizontalVolumeSlider.Get());
	//        // Cache slider min/max
	//        IFC(m_tpHorizontalVolumeSlider.Cast<Slider>()->get_Minimum(&m_volumeSliderMinimum));
	//        IFC(m_tpHorizontalVolumeSlider.Cast<Slider>()->get_Maximum(&m_volumeSliderMaximum));
	//    }
	//    if (m_tpMuteButton)
	//    {
	//        ctl::ComPtr<xaml_primitives::IToggleButton> spToggleButton;
	//        IFC(m_tpMuteButton.As(&spToggleButton));
	//        SetPtrValue(m_tpActiveVolumeButton, spToggleButton);
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Initialize state specific to Volume in the Threshold.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::InitializeVolume()
	//{
	//    HRESULT hr = S_OK;

	//    // Set references to volume parts
	//    if (m_tpTHVolumeSlider)
	//    {
	//        SetPtrValue(m_tpActiveVolumeSlider, m_tpTHVolumeSlider.Get());
	//        // Cache slider min/max
	//        IFC(m_tpTHVolumeSlider.Cast<Slider>()->get_Minimum(&m_volumeSliderMinimum));
	//        IFC(m_tpTHVolumeSlider.Cast<Slider>()->get_Maximum(&m_volumeSliderMaximum));
	//    }

	//Cleanup:
	//    return hr;
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Update all aspects of visual state based on state variables
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateVisualState(_In_ bool bUseTransitions)
	//{
	//    HRESULT hr = S_OK;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        IFC(UpdateVisualStateFromME(bUseTransitions));
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        IFC(UpdateVisualStateFromMPE(bUseTransitions));
	//    }

	//Cleanup:
	//    return hr;
	//}

	////-------------------------------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Calculate drop out level based on total width of tranport controls works for WinBlue
	////
	////-------------------------------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::CalculateDropOutLevel()
	//{
	//    HRESULT hr = S_OK;
	//    double mediaControlsWidth = 0;
	//    double dropoutWidths[MaxDropuOutLevels] = { 0 };
	//    ctl::ComPtr<IVisualStateGroup> spGroup;

	//    // This is works only for WinBlue where dropout states defined in the Template
	//    IFC(GetTemplatePart<IVisualStateGroup>(STR_LEN_PAIR(L"DropOutLevels"), spGroup.ReleaseAndGetAddressOf()));
	//    if (m_transportControlsEnabled && spGroup)
	//    {

	//        IFC(get_ActualWidth(&mediaControlsWidth));

	//        // Note: On 1.4x plateau there could be single pixel errors on 1.4x plateau due to
	//        // layout rounding. There, elements will not be sized & positioned on whole pixel
	//        // boundaries, but on 1/1.4 pixel boundaries (see CUIElement::LayoutRound), meaning
	//        // the constants we have for dropout levels won't be accurate anymore.This inaccuracy
	//        // for dropout level selection is minor enough that it should not be perceptible to
	//        // the user and we can ignore it.
	//        double controlPanelEdgeMargins = m_resSideMargins;
	//        double playPauseButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double fullWindowButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double zoomButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double volumeButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double muteButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double audioSelectionButtonWithMarginsWidth = m_resMediaButtonWidth + m_resSideMargins;
	//        double positionSliderWithMarginsWidth = m_resPositionSliderMinimumWidth + m_resSideMargins;
	//        double horizontalVolumeSliderWithMarginsWidth = m_resHorizontalVolumeSliderWidth + m_resSideMargins;
	//        double timeRemainingButtonWidth = m_resTimeButtonWidth; // Margins defined as Padding, already included in the width
	//        double timeElapsedButtonWidth = m_resTimeButtonWidth; // Margins defined as Padding, already included in the width

	//        if (m_isAudioOnly)
	//        {
	//            //
	//            // Dropout threshold widths for Audio mode
	//            //

	//            // 8 is the Full Window button and is not used for audio
	//            dropoutWidths[7] = controlPanelEdgeMargins + playPauseButtonWithMarginsWidth;
	//            dropoutWidths[6] = dropoutWidths[7] + (m_hasMultipleAudioStreams ? audioSelectionButtonWithMarginsWidth : 0);
	//            dropoutWidths[5] = dropoutWidths[6] + muteButtonWithMarginsWidth;
	//            // 4 is the Zoom button and is not used for audio
	//            dropoutWidths[3] = dropoutWidths[5] + horizontalVolumeSliderWithMarginsWidth;
	//            dropoutWidths[2] = dropoutWidths[3] + timeElapsedButtonWidth;
	//            dropoutWidths[1] = dropoutWidths[2] + positionSliderWithMarginsWidth;
	//            dropoutWidths[0] = dropoutWidths[1] + timeRemainingButtonWidth;
	//        }
	//        else
	//        {
	//            //
	//            // Dropout threshold widths for Video mode
	//            //

	//            dropoutWidths[8] = controlPanelEdgeMargins + playPauseButtonWithMarginsWidth;
	//            dropoutWidths[7] = dropoutWidths[8] + fullWindowButtonWithMarginsWidth;
	//            // 6 is the mute button and is not used for video
	//            dropoutWidths[5] = dropoutWidths[7] + (m_hasMultipleAudioStreams ? audioSelectionButtonWithMarginsWidth : 0);
	//            dropoutWidths[4] = dropoutWidths[5] + volumeButtonWithMarginsWidth;
	//            dropoutWidths[3] = dropoutWidths[4] + zoomButtonWithMarginsWidth;
	//            dropoutWidths[2] = dropoutWidths[3] + timeElapsedButtonWidth;
	//            dropoutWidths[1] = dropoutWidths[2] + positionSliderWithMarginsWidth;
	//            dropoutWidths[0] = dropoutWidths[1] + timeRemainingButtonWidth;
	//        }

	//        // Default to dropping everthing, loop below will
	//        // set the right level if this is not true
	//        m_dropOutLevel = 9;

	//        // Test thresholds in decreasing order.If width of controls is larger
	//        // than threshold i, use dropout level i.Take care that unused levels
	//        // in audio and video mode are not tested.
	//        for (INT i = 0; i < MaxDropuOutLevels - 1; i++)
	//        {
	//            if (mediaControlsWidth >= dropoutWidths[i] &&
	//                ((m_isAudioOnly && i != 4 && i != 8) ||   // audio case - levels 4 and 8 are not used
	//                (!m_isAudioOnly && i != 6)))             // video case - level 6 is not used
	//            {
	//                m_dropOutLevel = i;
	//                break;
	//            }
	//        }
	//    }
	//Cleanup:
	//    RRETURN(hr);
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Show (fade in) the vertical volume host border
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::ShowVerticalVolume()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (!m_verticalVolumeIsVisible)
	//        {
	//            m_verticalVolumeIsVisible = TRUE;
	//            m_verticalVolumeVisibilityChanged = TRUE;
	//            IFC(UpdateVisualState());

	//            // Immediately start the timer to hide vertical volume
	//            IFC(StartVerticalVolumeHideTimer());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Hide (fade out) the vertical volume host border,
	////       provided that pre-requisite conditions for hiding it are met.
	////
	////       If forceHide is TRUE, hide even if input state conditions are not met.
	////       This allows consistent expereince in corner cases (for example,
	////       vertical volume is up and has keyboard focus, then volume button is pressed).
	////       In addition, if the input conditions ever get in a bad state, this
	////       forces them to get reset.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::HideVerticalVolume(BOOLEAN forceHide)
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {

	//        if (ShouldHideVerticalVolume() || forceHide)
	//        {
	//            // Reset input state if vertical volume hide is forced
	//            if (forceHide)
	//            {
	//                m_verticalVolumeHasKeyOrProgFocus = FALSE;
	//            }

	//            // Vertical volume will now be hidden, so stop its hide timer.
	//            IFC(StopVerticalVolumeHideTimer());

	//            m_verticalVolumeIsVisible = FALSE;
	//            m_verticalVolumeVisibilityChanged = TRUE;

	//            IFC(UpdateVisualState());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Show (fade in) the control panel
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::ShowControlPanel()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (!m_controlPanelIsVisible)
	//        {
	//            m_controlPanelIsVisible = TRUE;
	//            if (!m_isVSStateChangeExternal) // Skip if Visual State already happen through external
	//            {
	//                m_controlPanelVisibilityChanged = TRUE;
	//            }
	//        }

	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(ShowControlPanelFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(ShowControlPanelFromMPE());
	//        }

	//        // Resume position updates now that CP is visible
	//        IFC(StartPositionUpdateTimer());

	//        // Immediately start the timer to hide control panel
	//        IFC(StartControlPanelHideTimer());

	//        IFC(UpdateVisualState());

	//        m_isVSStateChangeExternal = FALSE;
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Hide (fade out) the control panel, provided that pre-requisite
	////       conditions for hiding it are met.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::HideControlPanel(_In_ bool hideImmediately)
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (m_tpHideControlPanelTimer)
	//        {
	//            if (hideImmediately || ShouldHideControlPanel() || m_isVSStateChangeExternal)
	//            {
	//                // Both CP and Vertical Volume will be hiddden, so stop their hide timers.
	//                IFC(StopControlPanelHideTimer());
	//                IFC(StopVerticalVolumeHideTimer());

	//                // Stop position updates now that CP is not visible
	//                IFC(StopPositionUpdateTimer());

	//                // Flag vertical volume to hide so that it won't get displayed
	//                // next time the ControlPanel becomes visible
	//                if (m_verticalVolumeIsVisible)
	//                {
	//                    m_verticalVolumeIsVisible = FALSE;
	//                    m_verticalVolumeVisibilityChanged = TRUE;
	//                }

	//                // Flag control panel itself to hide
	//                m_controlPanelIsVisible = FALSE;
	//                if (!m_isVSStateChangeExternal) // Skip if Visual State already happen through external
	//                {
	//                    m_controlPanelVisibilityChanged = TRUE;
	//                }

	//                if (MTCParent_MediaElement == m_parentType)
	//                {
	//                    IFC(HideControlPanelFromME());
	//                }
	//                else if (MTCParent_MediaPlayerElement == m_parentType)
	//                {
	//                    IFC(HideControlPanelFromMPE());
	//                }

	//                IFC(UpdateVisualState());
	//            }
	//        }
	//        m_shouldDismissControlPanel = FALSE;
	//        m_isthruScrubber = FALSE;
	//        m_isVSStateChangeExternal = FALSE;
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Loaded event fires on Root UserControl.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootUserControlLoaded()
	//{
	//    RRETURN(UpdateDownloadProgressUI());
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Handler for the SizeChanged event on ProgressSlider
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnProgressSliderSizeChanged()
	//{
	//    RRETURN(UpdateDownloadProgressUI());
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Handler for the SizeChanged event on ProgressSlider
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnProgressSliderFocusDisengaged()
	//{
	//    IFC_RETURN(ShowHideThumbnail(FALSE));
	//    IFC_RETURN(ExitScrubbingMode());

	//    return S_OK;
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when m_tpHideControlPanelTimer fires.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnHideControlPanelTimerTick()
	//{
	//    if (m_transportControlsEnabled)
	//    {
	//        if (IsInLiveTree())
	//        {
	//            IFC_RETURN(HideControlPanel());
	//        }
	//    }

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when pointer enters control panel
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelEntered()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        m_controlPanelHasPointerOver = TRUE;
	//        IFC(StopControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when pointer exits control panel
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelExited()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        m_controlPanelHasPointerOver = FALSE;
	//        IFC(StartControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when tap ControlPanel
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelTapped(
	//    _In_ xaml_input::ITappedRoutedEventArgs *pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN isControlPanelTapped = FALSE;

	//    if (m_transportControlsEnabled)
	//    {
	//        IFC(CompareWithOriginalSource(static_cast<TappedRoutedEventArgs*>(pArgs), ctl::as_iinspectable(m_tpControlPanelGrid.Cast<Grid>()), &isControlPanelTapped));

	//        m_shouldDismissControlPanel |= isControlPanelTapped;
	//        IFC(HideControlPanel());
	//    }

	//Cleanup:
	//    RRETURN(hr);
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when control panel grid (which includes the volume slider host)
	////      lost pointer capture. This ensures correct PointerPressed and PointerOver
	////      state as those events may not fire while an element has capture.
	////      (Mostly this occurs when user pressed down on a control in the panel and
	////      drags the cursor off the panel while holding it).
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelCaptureLost(
	//    _In_ xaml_input::IPointerRoutedEventArgs *pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wui::IPointerPoint> spPointerPointWhenCaptureLost;
	//    ctl::ComPtr<xaml::IUIElement> spControlPanelGridAsUIE;
	//    wf::Point pointWhenCaptureLost = {};
	//    BOOLEAN controlPanelGridHasHit = FALSE;

	//    if (m_transportControlsEnabled )
	//    {

	//        //
	//        // 1. Update PointerPresed state.
	//        //
	//        // If capture was lost on control panel, it is safe to say
	//        // pointer is not pressed over ME, since only the controls
	//        // making up the panel could possibly take capture.
	//        m_rootHasPointerPressed = FALSE;

	//        //
	//        // 2. Update PointerOver state.
	//        //
	//        // If volume slider is dragged with pointer outside the vertical volume host,
	//        // PointerExited event is not fired, however when pointer is released we will
	//        // get a CaptureLost event.
	//        //
	//        IFC(pArgs->GetCurrentPoint(NULL, &spPointerPointWhenCaptureLost));
	//        IFC(spPointerPointWhenCaptureLost->get_Position(&pointWhenCaptureLost));

	//        // Check if control panel grid is still hit
	//        IFC(m_tpControlPanelGrid.As(&spControlPanelGridAsUIE));
	//        IFC(HitTestHelper(pointWhenCaptureLost, spControlPanelGridAsUIE.Get(), &controlPanelGridHasHit));

	//        m_controlPanelHasPointerOver = controlPanelGridHasHit;

	//        // Kick off timers as needed based on updated PointerOver state
	//        if (!m_controlPanelHasPointerOver)
	//        {
	//            IFC(StartControlPanelHideTimer());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when pointer exited Root UserControl.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootExited()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {

	//        // If user presses pointer over root then drags it off while holding down
	//        // we get neither Released nor CaptureLost on the root. Thus, unset
	//        // m_rootHasPointerPressed whenever pointer leaves root.
	//        // For consistency, also enforce Pressed is FALSE for vertical volume host.
	//        m_rootHasPointerPressed = FALSE;

	//        // If pointer exited the root area, it is no longer over the
	//        // vertical volume or the control panel, enforce this here.
	//        m_controlPanelHasPointerOver = FALSE;

	//        IFC(StartControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user pressed the pointer over Root UserControl.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootPressed()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        m_rootHasPointerPressed = TRUE;
	//        IFC(StopControlPanelHideTimer());

	//        // Any click over media area should bring up control panel.
	//        IFC(ShowControlPanel());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user released pointer that was initially pressed
	////      over Root UserControl.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootReleased()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        m_rootHasPointerPressed = FALSE;
	//        IFC(StartControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Root UserControl lost pointer capture.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootCaptureLost()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        m_rootHasPointerPressed = FALSE;
	//        IFC(StartControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when pointer moves over the ME's render area.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnRootMoved()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        BOOLEAN isAutoShowHide = false;
	//        IFC(get_ShowAndHideAutomatically(&isAutoShowHide));
	//        // Check flags to minimize work in this frquently called handler
	//        if (!m_isAudioOnly &&
	//            isAutoShowHide && // ignore if  when auto hide/show is disabled
	//            !m_controlPanelIsVisible &&
	//            !m_hasError)
	//        {
	//            IFC(ShowControlPanel());
	//        }
	//        m_isPointerMove = TRUE;
	//        // timer to detect when pointer move ends.
	//        m_tpPointerMoveEndTimer->Stop();
	//        m_tpPointerMoveEndTimer->Start();
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when m_tpPositionUpdateTimer fires.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionUpdateTimerTick()
	//{
	//    if (m_transportControlsEnabled)
	//    {
	//        if (IsInLiveTree())
	//        {
	//            IFC_RETURN(UpdatePositionUI());
	//        }
	//    }

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Audio Selection button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnAudioSelectionButtonClick()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        IFC(UpdateAudioSelectionFlyout());
	//        IFC(m_tpAvailableAudioTracksMenuFlyout.Cast<MenuFlyout>()->ShowAt(m_tpAvailableAudioTracksMenuFlyoutTarget.Get()));
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Audio Selection button gets clicked in Threshold
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnTHAudioTrackSelectionButtonClick()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MenuFlyout> spNewMenuFlyout;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (!m_tpAvailableAudioTracksMenuFlyout)
	//        {
	//            IFC(ctl::make<MenuFlyout>(&spNewMenuFlyout));
	//            IFC(spNewMenuFlyout->put_ShouldConstrainToRootBounds(TRUE));
	//            SetPtrValue(m_tpAvailableAudioTracksMenuFlyout, spNewMenuFlyout.Get());
	//            IFC(m_tpTHAudioTrackSelectionButton.Cast<Button>()->put_Flyout(m_tpAvailableAudioTracksMenuFlyout.Cast<MenuFlyout>()));
	//        }
	//        IFC(UpdateAudioSelectionFlyout());
	//        IFC(m_tpAvailableAudioTracksMenuFlyout.Cast<MenuFlyout>()->ShowAt(m_tpTHAudioTrackSelectionButton.Cast<Button>()));
	//    }
	//Cleanup:
	//    return hr;
	//}

	//// Called when Close Captioning Selection button gets clicked
	//_Check_return_ HRESULT
	//MediaTransportControls::OnCCSelectionButtonClick()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MenuFlyout> spNewMenuFlyout;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (!m_tpAvailableCCTracksMenuFlyout)
	//        {
	//            IFC(ctl::make<MenuFlyout>(&spNewMenuFlyout));
	//            IFC(spNewMenuFlyout->put_ShouldConstrainToRootBounds(TRUE));
	//            SetPtrValue(m_tpAvailableCCTracksMenuFlyout, spNewMenuFlyout.Get());
	//            IFC(m_tpCCSelectionButton.Cast<Button>()->put_Flyout(m_tpAvailableCCTracksMenuFlyout.Cast<MenuFlyout>()));
	//        }
	//        IFC(UpdateCCSelectionFlyout());
	//        IFC(m_tpAvailableCCTracksMenuFlyout.Cast<MenuFlyout>()->ShowAt(m_tpCCSelectionButton.Cast<Button>()));
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    data.trackId = m_currentTrack; // UpdateCCSelectionFlyout() updates current track as it can be set from outside MTC
	//    m_AggTelemetry.AddData(MTCTelemetryType::CCButtonClick, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when play rate button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPlaybackRateButtonClick()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MenuFlyout> spNewMenuFlyout;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (!m_tpAvailablePlaybackRateMenuFlyout)
	//        {
	//            IFC(ctl::make<MenuFlyout>(&spNewMenuFlyout));
	//            IFC(spNewMenuFlyout->put_ShouldConstrainToRootBounds(TRUE));
	//            SetPtrValue(m_tpAvailablePlaybackRateMenuFlyout, spNewMenuFlyout.Get());
	//            IFC(m_tpPlaybackRateButton.Cast<Button>()->put_Flyout(m_tpAvailablePlaybackRateMenuFlyout.Cast<MenuFlyout>()));
	//        }
	//        IFC(UpdatePlaybackRateFlyout());
	//        IFC(m_tpAvailablePlaybackRateMenuFlyout.Cast<MenuFlyout>()->ShowAt(m_tpPlaybackRateButton.Cast<Button>()));
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Audio-mode mute button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnMuteClick()
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN isMuted = FALSE;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(GetMuted(&isMuted));
	//        // For audio-mode, simply flip the mute value
	//        isMuted = !isMuted;
	//        IFC(SetMuted(isMuted));
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::MuteClick, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Play/Pause button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPlayPauseClick()
	//{
	//    HRESULT hr = S_OK;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(OnPlayPauseFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(OnPlayPauseFromMPE());
	//        }
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::PlayPauseClick, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Full Window toggle button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnFullWindowClick()
	//{
	//    HRESULT hr = S_OK;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        m_isFullScreenClicked = TRUE;
	//        // this state is not valid, as user change the state on tapping fullwindow button.
	//        if (m_isLaunchedAsFullScreen)
	//        {
	//            m_isLaunchedAsFullScreen = FALSE;
	//        }

	//        if (!m_isMiniView)
	//        {
	//            IFC(SetFullWindow(!m_isFullWindow));
	//        }
	//        else
	//        {
	//            // When you are in miniView, then first exits the MiniView State.
	//            // Then update the fullwindow UI.
	//            m_isMiniView = FALSE;
	//            IFC(SetMiniView(false));
	//            IFC(UpdateFullWindowUI());
	//        }

	//        m_shouldDismissControlPanel |= (m_isPlaying && !m_isBuffering);
	//        IFC(HideControlPanel());
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::FullWindowClick, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when hardware Back button gets pressed
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnBackButtonPressedImpl(_Out_ BOOLEAN* returnValue)
	//{
	//    HRESULT hr = S_OK;

	//    ASSERT(m_isFullWindow);

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(SetFullWindow(FALSE));
	//        // only if user changed stretch then restore it.
	//        if (m_stretchOnFullWindowChanged)
	//        {
	//            IFC(SetStretch(m_stretchToRestore));
	//            m_stretchOnFullWindowChanged = FALSE;
	//        }

	//        //Handled
	//        *returnValue = TRUE;
	//    }
	//Cleanup:
	//    RRETURN(hr);
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when Zoom toggle button gets clicked
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnZoomClick()
	//{
	//    HRESULT hr = S_OK;
	//    xaml_media::Stretch stretch;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // Uniform goes to UniformToFill. Everything else goes to Uniform.
	//        IFC(GetStretch(&stretch));
	//        if (m_isFullWindow && !m_stretchOnFullWindowChanged)
	//        {
	//            m_stretchOnFullWindowChanged = TRUE;
	//            m_stretchToRestore = stretch;
	//        }

	//        IFC(SetStretch(
	//            stretch == Stretch_Uniform
	//            ? Stretch_UniformToFill
	//            : Stretch_Uniform
	//            ));
	//    }
	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::ZoomClick, data);
	//    return hr;
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Called when the size of the transport controls changes.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnSizeChanged()
	//{
	//    HRESULT hr = S_OK;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled)
	//    {
	//        IFC(SetMeasureCommandBar());
	//        // If error is showing, may need to switch between long / short / shortest form
	//        IFC(UpdateErrorUI());
	//        IFC(UpdateVisualState());
	//    }

	//    // This is arise when clicks the exit fullscreen screen on the title bar, then reset back from the full window
	//    if (m_isFullWindow && m_isFullScreen)
	//    {
	//        ctl::ComPtr<wuv::IApplicationView3> spAppView3;
	//        BOOLEAN fullscreenmode = FALSE;

	//        IFC(GetFullScreenView(&spAppView3));
	//        if (spAppView3)
	//        {
	//            IFC(spAppView3->get_IsFullScreenMode(&fullscreenmode));
	//        }
	//        if (!fullscreenmode)
	//        {
	//            if (!m_isFullScreenPending) // if true means still we are not under fullscreen, exit through titlebar doesn't occur still
	//            {
	//                if (!m_isMiniView)
	//                {
	//                    IFC(OnFullWindowClick());
	//                }
	//                else
	//                {
	//                    // While switching from Fullscreen to MiniView, just update the fullscren states.
	//                    IFC(UpdateFullWindowUI());
	//                    m_isFullScreen = FALSE;
	//                }
	//            }
	//        }
	//        else
	//        {
	//            // m_isFullScreenPending Complete.
	//            m_isFullScreenPending = FALSE;

	//            // Find out if the API is available (currently behind a velocity key)
	//            ctl::ComPtr<wf::Metadata::IApiInformationStatics> apiInformationStatics;
	//            IFC(ctl::GetActivationFactory(
	//                wrl_wrappers::HStringReference(RuntimeClass_Windows_Foundation_Metadata_ApiInformation).Get(),
	//                &apiInformationStatics));

	//            // we are in full screen, so check for spanning mode
	//            uint32_t regionCount = 0;

	//            boolean isPresent = false;
	//            IFC(apiInformationStatics->IsMethodPresent(
	//                wrl_wrappers::HStringReference(L"Windows.UI.ViewManagement.ApplicationView").Get(),
	//                wrl_wrappers::HStringReference(L"GetDisplayRegions").Get(),
	//                &isPresent));

	//            if (isPresent)
	//            {
	//                // Get regions for current view
	//                ctl::ComPtr<wuv::IApplicationViewStatics2> applicationViewStatics;
	//                IFC(ctl::GetActivationFactory(wrl_wrappers::HStringReference(
	//                                                        RuntimeClass_Windows_UI_ViewManagement_ApplicationView)
	//                                                        .Get(),
	//                                                        &applicationViewStatics));

	//                ctl::ComPtr<wuv::IApplicationView> applicationView;

	//                // Get Display Regions doesn't work on Win32 Apps, because there is no
	//                // application view. For the time being, just don't return an empty vector
	//                // when running in an unsupported mode.
	//                if (SUCCEEDED(applicationViewStatics->GetForCurrentView(&applicationView)))
	//                {
	//                    ctl::ComPtr<wuv::IApplicationView9> applicationView9;
	//                    IFC(applicationView.As(&applicationView9));

	//                    HRESULT hrGetForCurrentView;
	//                    ctl::ComPtr<wfc::IVectorView<wuwm::DisplayRegion*>> regions;
	//                    hrGetForCurrentView = applicationView9->GetDisplayRegions(&regions);
	//                    if (FAILED(hrGetForCurrentView))
	//                    {
	//                        // bug 14084372: APIs currently return a failure when there is only one display region.
	//                        return S_OK;
	//                    }

	//                    IFC(regions->get_Size(&regionCount));
	//                }
	//            }

	//            if (regionCount > 1  &&
	//                !m_isCompact &&
	//                !m_isSpanningCompactEnabled)
	//            {
	//                put_IsCompact(true);
	//                m_isSpanningCompactEnabled = TRUE;
	//            }
	//        }
	//    }
	//    else
	//    {
	//        // not fullscreen, in spanning compact mode is enabled, reset it
	//        if(m_isSpanningCompactEnabled)
	//        {
	//            put_IsCompact(false);
	//            m_isSpanningCompactEnabled = FALSE;
	//        }
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::SizeChanged, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when volume slider is manipulated
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnVolumeSliderValueChanged()
	//{
	//    HRESULT hr = S_OK;
	//    DOUBLE sliderValue = 0.0;
	//    DOUBLE newVolume = 0.0;


	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // Do not update the DP UpdateUIOnly flag for Volume is set
	//        if (m_volumeUpdateUIOnly)
	//        {
	//            goto Cleanup;
	//        }

	//        if (m_isAudioOnly && m_tpHorizontalVolumeSlider)
	//        {
	//            IFC(m_tpHorizontalVolumeSlider.Cast<Slider>()->get_Value(&sliderValue));
	//        }
	//        else if (!m_isAudioOnly && m_tpVerticalVolumeSlider)
	//        {
	//            IFC(m_tpVerticalVolumeSlider.Cast<Slider>()->get_Value(&sliderValue));
	//        }
	//        else if (m_tpTHVolumeSlider)
	//        {
	//            IFC(m_tpTHVolumeSlider.Cast<Slider>()->get_Value(&sliderValue));
	//        }

	//        // Calculate and update target volume
	//        newVolume = (sliderValue - m_volumeSliderMinimum) / DoubleUtil::Max(1, m_volumeSliderMaximum - m_volumeSliderMinimum);
	//        IFC(SetVolume(newVolume));

	//        // Set the Mute State when Volume is zero.
	//        if (m_tpTHVolumeSlider)
	//        {
	//            IFC(SetMuted(newVolume == 0 ? TRUE:FALSE));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when control panel grid (which includes the volume
	////      slider host) got focus.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelGotFocus(
	//    _In_ xaml::IRoutedEventArgs *pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN controlsHaveKeyOrProgFocus = FALSE;

	//    if (m_transportControlsEnabled)
	//    {

	//        IFC(HasKeyOrProgFocus(pArgs, &controlsHaveKeyOrProgFocus));
	//        m_controlsHaveKeyOrProgFocus = controlsHaveKeyOrProgFocus;

	//        if (controlsHaveKeyOrProgFocus)
	//        {
	//            BOOLEAN isVerticalVolumeSliderOriginalSource = FALSE;

	//            IFC(StopControlPanelHideTimer());
	//            IFC(ShowControlPanel());

	//            if (m_tpVerticalVolumeSlider)
	//            {
	//                // Check if vertical volume slider in particular has the focus
	//                IFC(CompareWithOriginalSource(pArgs, ctl::as_iinspectable(m_tpVerticalVolumeSlider.Cast<Slider>()), &isVerticalVolumeSliderOriginalSource));

	//                if (isVerticalVolumeSliderOriginalSource)
	//                {
	//                    m_verticalVolumeHasKeyOrProgFocus = TRUE;
	//                    IFC(StopVerticalVolumeHideTimer());
	//                }
	//            }
	//        }
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when control panel grid (which includes the volume
	////      slider host) lost focus.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnControlPanelLostFocus(
	//    _In_ xaml::IRoutedEventArgs *pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN isVerticalVolumeSliderOriginalSource = FALSE;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpVerticalVolumeSlider)
	//        {
	//            // Check if vertical volume slider in particular lost the focus
	//            IFC(CompareWithOriginalSource(pArgs, ctl::as_iinspectable(m_tpVerticalVolumeSlider.Cast<Slider>()), &isVerticalVolumeSliderOriginalSource));
	//            if (isVerticalVolumeSliderOriginalSource)
	//            {
	//                m_verticalVolumeHasKeyOrProgFocus = FALSE;
	//                IFC(StartVerticalVolumeHideTimer());
	//            }
	//        }

	//        // We do not know if control panel as a whole lost focus until
	//        // the element receiving focus fires its GotFocus event. For now,
	//        // we set m_controlsHaveKeyOrProgFocus to FALSE and kick off
	//        // the ControlPanel hide timer. If focus moves to another control
	//        // in the panel, both the flag and the timer will be corrected via
	//        // OnControlPanelGotFocus().
	//        m_controlsHaveKeyOrProgFocus = FALSE;
	//        IFC(StartControlPanelHideTimer());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      When Position slider value changes, we will apply change to UI and
	////      update the MediaElement DP.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionSliderValueChanged(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml_primitives::IRangeBaseValueChangedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    DOUBLE newSliderValue = 0.0;
	//    wf::TimeSpan newMediaPosition;
	//    BOOLEAN isMediaClosed;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // If slider was updated internally in response to Position DP change,
	//        // do not update the DP again.
	//        if (m_positionUpdateUIOnly)
	//        {
	//            goto Cleanup;
	//        }

	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(IsMediaStateClosedFromME(&isMediaClosed));
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(IsMediaStateClosedFromMPE(&isMediaClosed));
	//        }

	//        // If user tried to set the slider while in Closed state or for live content,
	//        // do not update the DP, but refresh Position UI (snap slider back to 0 position, etc).
	//        if (isMediaClosed || IsLiveContent())
	//        {
	//            IFC(UpdatePositionUI());
	//            goto Cleanup;
	//        }

	//        IFC(pArgs->get_NewValue(&newSliderValue));

	//        // If NaturalDuration is not known (i.e. is 0), new position also evaluates to 0.
	//        newMediaPosition.Duration =
	//            static_cast<INT64>((newSliderValue - m_positionSliderMinimum) / (m_positionSliderMaximum - m_positionSliderMinimum) *
	//                               static_cast<DOUBLE>(m_naturalDuration.TimeSpan.Duration));

	//        // Without below call to EnterScrubbingMode(), the order of events for a single Seek using PositionSlider during playback is:
	//        //
	//        // ... Content is playing ...
	//        // 1. Set Position (user seeks, Xaml  MediaTransportControls layer responds to ValueChanged event on position slider, call SetCurrentPlaybackTime())
	//        // 2. Set PlaybackRate = 0   ( Xaml MTC responds to PointerPressed on position slider, enter scrubbing mode)
	//        //      (i) Get MF_MEDIA_ENGINE_EVENT_SEEKING
	//        //     (ii) Get MF_MEDIA_ENGINE_EVENT_SEEKED
	//        // 3. Set PlaybackRate = 1 ( Xaml MTC responds to PointerReleased on position slider, exits scrubbing mode)
	//        //
	//        // Seek is issued before we set the PlaybackRate, This is due to bubble up pattern for raising routed events.
	//        // Both OnPositionSliderValueChanged() and OnPositionSliderPressed() handlers are called in response to a
	//        // PointerPressed event on a rectangle inside the slider. Slider implementation listens to event directly on
	//        // the rectangle, and gets the event first, calling OnPositionSliderValueChanged() as part of handling.
	//        // Later the event bubble's to MTC OnPositionSliderPressed() handler on the slider.
	//        //
	//        // The order above is not intended, but is acceptable for a single seek since in that case we don't really benefit from entering scrubbing mode.
	//        // However, issuing a seek just before toggling PlaybackRate very frequently reproes the following MediaEngine bug:
	//        // 289704: When changing rate immediately after seeking in MediaEngine during playback we sometimes end up Paused state unexpetedly
	//        //
	//        // To avoid hitting scenario above and work around 289704, we make sure to enter scrub mode before doing the seek.
	//        // The next call to EnterScrubMode()(via OnPositionSlidePressed()) will just no-op. We will leave scrub mode via
	//        // OnPositionSliderReleased(), OnPositionSliderKeyUp() or OnPositionSliderFocusDisengaged() as usual.
	//        IFC(EnterScrubbingMode());
	//        IFC(SetPosition(newMediaPosition));
	//        IFC(FireThumbnailEvent());
	//        m_isthruScrubber = TRUE;
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user pressed the pointer over position slider.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionSliderPressed(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml_input::IPointerRoutedEventArgs* pArgs)
	//{
	//    MTCTelemetryData data;
	//    data.errCode = S_OK;
	//    m_AggTelemetry.AddData(MTCTelemetryType::PositionSliderPressed, data);
	//    IFC_RETURN(ShowHideThumbnail(TRUE));
	//    IFC_RETURN(EnterScrubbingMode());
	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user released pointer that was initially pressed
	////      over position slider (Slider takes pointer capture when pressed
	////      so it gets this event even if pointer is released outside
	////      its hit test area).
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionSliderReleased(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml_input::IPointerRoutedEventArgs* pArgs)
	//{
	//    IFC_RETURN(ShowHideThumbnail(FALSE));
	//    IFC_RETURN(ExitScrubbingMode());
	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user pressed down a key while slider has focus.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionSliderKeyDown(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml_input::IKeyRoutedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    wsy::VirtualKey key = wsy::VirtualKey_None;
	//    wsy::VirtualKey originalKey = wsy::VirtualKey_None;

	//    IFC_RETURN(pArgs->get_Key(&key));
	//    IFC_RETURN(static_cast<KeyRoutedEventArgs*>(pArgs)->get_OriginalKey(&originalKey));

	//    // ignore up & down xbox gamepad keys, those doesn't supports scrubbing on the xbox.
	//    if (key == wsy::VirtualKey_Left  ||
	//        (key == wsy::VirtualKey_Down && !XboxUtility::IsGamepadNavigationDown(originalKey)) ||
	//        key == wsy::VirtualKey_Right ||
	//        (key == wsy::VirtualKey_Up && !XboxUtility::IsGamepadNavigationUp(originalKey)) ||
	//        key == wsy::VirtualKey_Home  ||
	//        key == wsy::VirtualKey_End)
	//    {
	//        IFC_RETURN(ShowHideThumbnail(TRUE));
	//        IFC_RETURN(EnterScrubbingMode());
	//    }
	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when user released a key while slider has focus.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPositionSliderKeyUp(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml_input::IKeyRoutedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    wsy::VirtualKey key = wsy::VirtualKey_None;
	//    wsy::VirtualKey originalKey = wsy::VirtualKey_None;

	//    IFC_RETURN(pArgs->get_Key(&key));
	//    IFC_RETURN(static_cast<KeyRoutedEventArgs*>(pArgs)->get_OriginalKey(&originalKey));

	//    // ignore up & down xbox gamepad keys, those doesn't supports scrubbing on the xbox.
	//    if (key == wsy::VirtualKey_Left  ||
	//        (key == wsy::VirtualKey_Down && !XboxUtility::IsGamepadNavigationDown(originalKey)) ||
	//        key == wsy::VirtualKey_Right ||
	//        (key == wsy::VirtualKey_Up && !XboxUtility::IsGamepadNavigationUp(originalKey)) ||
	//        key == wsy::VirtualKey_Home  ||
	//        key == wsy::VirtualKey_End)
	//    {
	//        IFC_RETURN(ShowHideThumbnail(FALSE));
	//        IFC_RETURN(ExitScrubbingMode());
	//    }

	//    return S_OK;
	//}
	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called when an audio track is selected from the Audio Track MenuFlyout
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnAudioTrackClicked(
	//    _In_ IInspectable* pSender,
	//    _In_ xaml::IRoutedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wfc::IVector<xaml_controls::MenuFlyoutItemBase*>> spMenuFlyoutItems;
	//    ctl::ComPtr<xaml_controls::IMenuFlyoutItemBase> spItem;
	//    UINT selectedTrackIndex = 0;
	//    BOOLEAN isFound = FALSE;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(m_tpAvailableAudioTracksMenuFlyout->get_Items(&spMenuFlyoutItems));

	//        // Determine index of currently selected audio track
	//        IFC(ctl::do_query_interface(spItem, pSender));
	//        IFC(spMenuFlyoutItems->IndexOf(spItem.Get(), &selectedTrackIndex, &isFound));
	//        if (isFound)
	//        {
	//            // Apply user's track selection
	//            if (MTCParent_MediaElement == m_parentType)
	//            {
	//                IFC(SetAudioTrackFromME(selectedTrackIndex));
	//            }
	//            else if (MTCParent_MediaPlayerElement == m_parentType)
	//            {
	//                IFC(SetAudioTrackFromMPE(selectedTrackIndex));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Play/Pause state - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdatePlayPauseUI()
	//{
	//    HRESULT hr = S_OK;
	//    wrl_wrappers::HString strAutomationName;
	//    ctl::ComPtr<xaml_primitives::IToggleButton> spToggleButton;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpPlayPauseButton)
	//        {
	//            IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(m_isPlaying ? UIA_MEDIA_PAUSE : UIA_MEDIA_PLAY, strAutomationName.ReleaseAndGetAddressOf()));
	//            IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpPlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//            IFC(UpdateTooltipText(m_tpPlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//        }

	//        if (m_tpTHLeftSidePlayPauseButton)
	//        {
	//            IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(m_isPlaying ? UIA_MEDIA_PAUSE : UIA_MEDIA_PLAY, strAutomationName.ReleaseAndGetAddressOf()));
	//            IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//            IFC(UpdateTooltipText(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>(), strAutomationName));
	//        }

	//        // Show/Hide PlayPause button based on the CommandManager Behaviour
	//        if (m_parentType == MTCParent_MediaPlayerElement && m_spMediaPlayer)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer3> spMediaPlayerExt;
	//            ctl::ComPtr<wmp::IMediaPlaybackCommandManager> spCommandManager;
	//            BOOLEAN isEnable = FALSE;

	//            IFC(m_spMediaPlayer.As(&spMediaPlayerExt));
	//            IFC(spMediaPlayerExt->get_CommandManager(&spCommandManager));
	//            if (m_isPlaying)
	//            {
	//                ctl::ComPtr<wmp::IMediaPlaybackCommandManagerCommandBehavior> spPauseCommandBehaviour;
	//                IFC(spCommandManager->get_PauseBehavior(&spPauseCommandBehaviour));
	//                IFC(spPauseCommandBehaviour->get_IsEnabled(&isEnable));
	//            }
	//            else
	//            {
	//                ctl::ComPtr<wmp::IMediaPlaybackCommandManagerCommandBehavior> spPlayCommandBehaviour;
	//                IFC(spCommandManager->get_PlayBehavior(&spPlayCommandBehaviour));
	//                IFC(spPlayCommandBehaviour->get_IsEnabled(&isEnable));
	//            }
	//            if (m_tpPlayPauseButton)
	//            {
	//                IFC(m_tpPlayPauseButton.Cast<ButtonBase>()->put_IsEnabled(isEnable));
	//            }
	//            if (m_tpTHLeftSidePlayPauseButton)
	//            {
	//                IFC(m_tpTHLeftSidePlayPauseButton.Cast<Button>()->put_IsEnabled(isEnable));
	//            }
	//        }
	//        // Update Time Elapsed/Remaining Automation value in pause/play state
	//        IFC(UpdateTimeAutomationProperties());
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Audio Selection UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateAudioSelectionUI()
	//{
	//    HRESULT hr = S_OK;
	//    INT audioStreamCount = 0;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if ((m_tpAudioSelectionButton  && m_tpAvailableAudioTracksMenuFlyout) ||
	//            m_tpTHAudioTrackSelectionButton)
	//        {
	//            BOOLEAN hasMultipleAudioStreams = FALSE;
	//            // audioStreamCount is 0 if there is no valid source
	//            IFC(GetAudioTrackCount(&audioStreamCount));
	//            hasMultipleAudioStreams = audioStreamCount > 1;
	//            if (hasMultipleAudioStreams != m_hasMultipleAudioStreams)
	//            {
	//                m_hasMultipleAudioStreams = hasMultipleAudioStreams;
	//                IFC(CalculateDropOutLevel());
	//                IFC(UpdateVisualState());
	//                if (m_tpLeftAppBarSeparator || m_tpRightAppBarSeparator)
	//                {
	//                    IFC(SetMeasureCommandBar());
	//                }
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Update closed caption Selection UI
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateCCSelectionUI()
	//{
	//    HRESULT hr = S_OK;
	//    UINT ccTrackCount = 0;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (m_tpCCSelectionButton)
	//        {
	//            BOOLEAN hasCCTracks = FALSE;
	//            IFC(GetCCTrackCount(&ccTrackCount));
	//            hasCCTracks = ccTrackCount > 0;
	//            if (hasCCTracks != m_hasCCTracks)
	//            {
	//                m_hasCCTracks = hasCCTracks;
	//                IFC(UpdateVisualState());
	//                if (m_tpLeftAppBarSeparator || m_tpRightAppBarSeparator)
	//                {
	//                    IFC(SetMeasureCommandBar());
	//                }
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Full Window state - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateFullWindowUI()
	//{
	//    wrl_wrappers::HString strAutomationName;
	//    BOOLEAN isFullWindow = FALSE;
	//    ctl::ComPtr<xaml_primitives::IToggleButton> spToggleButton;

	//    if (m_transportControlsEnabled  && m_wrOwnerParent.Get())
	//    {
	//        IFC_RETURN(GetFullWindow(&isFullWindow));
	//        m_isFullWindow = isFullWindow;

	//        if (m_isFullWindow)
	//        {
	//            if (!m_isFullScreenClicked) // This condition arise MediaElement launch as fullwindow, so we can skip register backbutton listner.
	//            {
	//                m_isLaunchedAsFullScreen = TRUE;
	//            }
	//            else
	//            {
	//                // Register Backbutton Listener on FullWindow
	//                IFC_RETURN(UdkShim::GetInstance().BackButtonIntegration_RegisterListener(this));
	//            }
	//        }
	//        else
	//        {
	//            // Deregister Backbutton Listener on non-FullWindow
	//            IFC_RETURN(UdkShim::GetInstance().BackButtonIntegration_UnregisterListener(this));
	//        }
	//        if (m_tpFullWindowButton)
	//        {
	//            IFC_RETURN(UpdateFullScreenMode(m_isFullWindow && !m_isMiniView));
	//            IFC_RETURN(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(isFullWindow ? UIA_MEDIA_EXIT_FULLSCREEN : UIA_MEDIA_FULLSCREEN, strAutomationName.ReleaseAndGetAddressOf()));
	//            IFC_RETURN(DirectUI::AutomationProperties::SetNameStatic(m_tpFullWindowButton.Cast<ButtonBase>(), strAutomationName));
	//            IFC_RETURN(UpdateTooltipText(m_tpFullWindowButton.Cast<ButtonBase>(), strAutomationName));
	//        }
	//    }

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update IsMuted - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateIsMutedUI()
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN isMuted = FALSE;

	//    if (m_tpMuteButton)
	//    {
	//        wrl_wrappers::HString strAutomationName;
	//        IFC(GetMuted(&isMuted));
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(isMuted ? UIA_MEDIA_UNMUTE : UIA_MEDIA_MUTE, strAutomationName.ReleaseAndGetAddressOf()));
	//        IFC(DirectUI::AutomationProperties::SetNameStatic(m_tpMuteButton.Cast<ButtonBase>(), strAutomationName));
	//        IFC(AddTooltip(m_tpMuteButton.Cast<ButtonBase>(), strAutomationName));
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Volume level - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateVolumeUI()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_tpActiveVolumeSlider)
	//    {
	//        DOUBLE volume = 0;
	//        DOUBLE targetSliderValue = 0;

	//        if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//        {
	//            IFC(GetVolume(&volume));
	//            targetSliderValue = volume * (m_volumeSliderMaximum - m_volumeSliderMinimum) + m_volumeSliderMinimum;

	//            // Set UpdateUIOnly flag for Volume so that OnVolumeSliderValueChanged() does not try to update the Volume DP
	//            m_volumeUpdateUIOnly = TRUE;
	//            IFC(m_tpActiveVolumeSlider.Cast<Slider>()->put_Value(targetSliderValue));
	//            m_volumeUpdateUIOnly = FALSE;
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Position - related UI (including Remaining Time)
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdatePositionUI()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wf::IPropertyValueStatics> spPropertyValueFactory;
	//    wf::TimeSpan currentMediaPosition;
	//    wrl_wrappers::HString strTimeElapsedText;
	//    wrl_wrappers::HString strTimeRemainingText;
	//    INT64 timeElapsedSeconds = 0;
	//    INT64 timeRemainingSeconds = 0;
	//    INT64 naturalDurationSeconds = 0;
	//    DOUBLE targetSliderValue = 0;
	//    DOUBLE mediaPosRatio = 0;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // TODO junk values for when no source and Changing PlayList enable later when fix it in MediaPlayer
	//        // ASSERT(m_naturalDuration.TimeSpan.Duration >= 0);

	//        if (!m_sourceLoaded)
	//        {
	//            // If source has not loaded yet, report 0 for all Position UI.
	//            currentMediaPosition.Duration = 0;
	//            targetSliderValue = 0.0;
	//        }
	//        else
	//        {
	//            IFC(GetPosition(&currentMediaPosition));

	//            if (IsLiveContent())
	//            {
	//               targetSliderValue = 0.0;
	//            }
	//            else
	//            {
	//                mediaPosRatio = static_cast<DOUBLE>(currentMediaPosition.Duration) / static_cast<DOUBLE> (m_naturalDuration.TimeSpan.Duration);
	//                targetSliderValue = mediaPosRatio * (m_positionSliderMaximum - m_positionSliderMinimum) + m_positionSliderMinimum;
	//                if (DoubleUtil::IsNaN(targetSliderValue) || DoubleUtil::IsInfinity(targetSliderValue))
	//                {
	//                    targetSliderValue = 0;
	//                }
	//            }
	//        }

	//        if (m_tpMediaPositionSlider)
	//        {
	//            // Set UpdateUIOnly flag for Position so that OnPositionSliderValueChanged() does not try to update the Position DP
	//            m_positionUpdateUIOnly = TRUE;
	//            IFC(m_tpMediaPositionSlider.Cast<Slider>()->put_Value(targetSliderValue));
	//            m_positionUpdateUIOnly = FALSE;
	//        }

	//        //
	//        // Get natural duration, elapsed and remaining time in seconds
	//        //
	//        // Note: Since these times are displayed in the UI in whole seconds only,
	//        // truncate the NaturalDuration and TimeElapsed to integer, and obtain
	//        // TimeRemaining from their difference. This guarantees that the displayed
	//        // Elapsed and Remaining Times are updated at the same time.
	//        //
	//        timeElapsedSeconds = static_cast<INT64> (currentMediaPosition.Duration / HNSPerSecond);

	//        if (IsLiveContent())
	//        {
	//            // Duration and RemainingTime don't apply to live content case
	//            naturalDurationSeconds = INT64_MAX;
	//            timeRemainingSeconds = INT64_MAX;
	//        }
	//        else
	//        {
	//            naturalDurationSeconds = static_cast<INT64>(m_naturalDuration.TimeSpan.Duration / HNSPerSecond);
	//            timeRemainingSeconds = naturalDurationSeconds - timeElapsedSeconds;
	//        }

	//        // Get factory for PropertyValue to wrap string for consumption as Button.Content
	//        IFC(wf::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_Foundation_PropertyValue).Get(), spPropertyValueFactory.ReleaseAndGetAddressOf()));

	//        // Update Time Elapsed
	//        if (m_tpTimeElapsedElement)
	//        {
	//            IFC(ConvertSecondsToHString(timeElapsedSeconds, strTimeElapsedText.GetAddressOf()));

	//            if (ctl::is<xaml_controls::IContentControl>(m_tpTimeElapsedElement.Get()))
	//            {
	//                ctl::ComPtr<wf::IPropertyValue> spContentAsPV;
	//                ctl::ComPtr<xaml_controls::IContentControl> spTimeElapsedButton;
	//                IFC(m_tpTimeElapsedElement.As(&spTimeElapsedButton));
	//                IFC(spPropertyValueFactory->CreateString(strTimeElapsedText.Get(), &spContentAsPV));
	//                IFC(spTimeElapsedButton->put_Content(ctl::as_iinspectable(spContentAsPV.Get())));
	//            }
	//            else
	//            {
	//                ctl::ComPtr<xaml_controls::ITextBlock> spTimeElapsedTextBlock;
	//                IFC(m_tpTimeElapsedElement.As(&spTimeElapsedTextBlock));
	//                IFC(spTimeElapsedTextBlock->put_Text(strTimeElapsedText));
	//            }
	//            if (m_isThumbnailEnabled && m_tpTimeElapsedPreview)
	//            {
	//                IFC(m_tpTimeElapsedPreview->put_Text(strTimeElapsedText));
	//            }
	//        }

	//        // Update Time Remaining
	//        if (m_tpTimeRemainingElement)
	//        {
	//            if (!m_sourceLoaded || IsLiveContent())
	//            {
	//                // NaturalDruation not known yet or is infinite (live content), show blank for Remaining Time
	//                strTimeRemainingText.Set(L"");
	//            }
	//            else
	//            {
	//                IFC(ConvertSecondsToHString(timeRemainingSeconds, strTimeRemainingText.GetAddressOf()));
	//            }

	//            if (ctl::is<xaml_controls::IContentControl>(m_tpTimeRemainingElement.Get()))
	//            {
	//                ctl::ComPtr<wf::IPropertyValue> spContentAsPV;
	//                ctl::ComPtr<xaml_controls::IContentControl> spTimeRemainingButton;
	//                IFC(m_tpTimeRemainingElement.As(&spTimeRemainingButton));
	//                IFC(spPropertyValueFactory->CreateString(strTimeRemainingText.Get(), &spContentAsPV));
	//                IFC(spTimeRemainingButton->put_Content(ctl::as_iinspectable(spContentAsPV.Get())));
	//            }
	//            else
	//            {
	//                ctl::ComPtr<xaml_controls::ITextBlock> spTimeRemainingTextBlock;
	//                IFC(m_tpTimeRemainingElement.As(&spTimeRemainingTextBlock));
	//                IFC(spTimeRemainingTextBlock->put_Text(strTimeRemainingText));
	//            }
	//        }

	//        if (m_sourceLoaded && !m_isPlaying)
	//        {
	//            IFC(UpdateTimeAutomationProperties());
	//        }
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update DownloadProgress - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateDownloadProgressUI()
	//{
	//    HRESULT hr = S_OK;
	//    DOUBLE downloadProgress = 0.0;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (m_tpMediaPositionSlider)
	//        {
	//            // If needed, get reference to DownloadProgressIndicator, which is a part of MediaSlider template
	//            // TODO (dkomin 5.5.2013): We should be able to do this once in the Loaded event of the MediaSlider or an
	//            //                         ancestor instead of here. However, the Loaded event in practice fires before
	//            //                         the template is expanded, which is not expected in Jupiter, according to MSDN doc:
	//            //                         http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.frameworkelement.loaded
	//            if (!m_tpDownloadProgressIndicator)
	//            {
	//                ctl::ComPtr<xaml::IDependencyObject> spTemplatePartAsDO;

	//                IFC(m_tpMediaPositionSlider.Cast<Slider>()->GetTemplateChild(wrl_wrappers::HStringReference(STR_LEN_PAIR(L"DownloadProgressIndicator")).Get(), &spTemplatePartAsDO));
	//                SetPtrValueWithQIOrNull(m_tpDownloadProgressIndicator, spTemplatePartAsDO.Get());
	//                if (!m_tpDownloadProgressIndicator)
	//                {
	//                    goto Cleanup;
	//                }
	//            }

	//            IFC(GetDownloadProgress(&downloadProgress));
	//            // Downloadprogress allow non-finite values (INF or NaN) as these can arise in live sources and custom mediasources,
	//            // which do not care about download progress.
	//            if (!DoubleUtil::IsNaN(downloadProgress) && !DoubleUtil::IsInfinity(downloadProgress))
	//            {
	//                IFC(m_tpDownloadProgressIndicator.Cast<ProgressBar>()->put_Value(downloadProgress * 100.0));
	//            }
	//            else
	//            {
	//                IFC(m_tpDownloadProgressIndicator.Cast<ProgressBar>()->put_Value(0));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update Error - related UI
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateErrorUI()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(UpdateErrorUIFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(UpdateErrorUIFromMPE());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Get Resource ID for the appropriate error string to
	////      show in the ErrorTextBlock.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::GetErrorResourceID(
	//    _In_ UINT32 errorCode,
	//    _Out_ UINT32* pResourceID)
	//{
	//    ASSERT(m_hasError && errorCode != MF_MEDIA_ENGINE_ERR_NOERROR);

	//    switch (errorCode)
	//    {
	//        case MF_MEDIA_ENGINE_ERR_ABORTED :
	//        {
	//            *pResourceID = m_isAudioOnly ? AG_E_MEDIA_CONTROLS_LONG_ERR_ABORTED_AUDIO : AG_E_MEDIA_CONTROLS_LONG_ERR_ABORTED_VIDEO;
	//            break;
	//        }

	//        case MF_MEDIA_ENGINE_ERR_DECODE :
	//        {
	//            *pResourceID = m_isAudioOnly ? AG_E_MEDIA_CONTROLS_LONG_ERR_DECODE_AUDIO : AG_E_MEDIA_CONTROLS_LONG_ERR_DECODE_VIDEO;
	//            break;
	//        }

	//        case MF_MEDIA_ENGINE_ERR_SRC_NOT_SUPPORTED :
	//        {
	//            *pResourceID = m_isAudioOnly ? AG_E_MEDIA_CONTROLS_LONG_ERR_SRC_NOT_SUPPORTED_AUDIO : AG_E_MEDIA_CONTROLS_LONG_ERR_SRC_NOT_SUPPORTED_VIDEO;
	//            break;
	//        }

	//        case MF_MEDIA_ENGINE_ERR_NETWORK :
	//        {
	//            *pResourceID = m_isAudioOnly ? AG_E_MEDIA_CONTROLS_LONG_ERR_NETWORK_AUDIO : AG_E_MEDIA_CONTROLS_LONG_ERR_NETWORK_VIDEO;
	//            break;
	//        }

	//        default :
	//        {
	//            *pResourceID = AG_E_MEDIA_CONTROLS_LONG_ERR_DEFAULT;
	//            break;
	//        }
	//    }

	//    return S_OK;//RRETURN_REMOVAL
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Refresh the position UI immediately, then start the position
	////      update timer, if needed.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StartPositionUpdateTimer()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {

	//        // Refresh position immediately to avoid a lag in position reporting and ensure
	//        // latest value even if condition to kick off timer below is not met
	//        IFC(OnPositionUpdateTimerTick());

	//        // Timer updates are only needed if content is playing and the Control Panel is visible
	//        if (m_tpPositionUpdateTimer &&
	//            m_controlPanelIsVisible &&
	//            m_isPlaying)
	//        {
	//            IFC(m_tpPositionUpdateTimer->Start());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Refresh the position UI immediately, then stop the position
	////      update timer.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StopPositionUpdateTimer()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        // Refresh position immediately to ensure final value is the latest
	//        IFC(OnPositionUpdateTimerTick());

	//        if (m_tpPositionUpdateTimer)
	//        {
	//            IFC(m_tpPositionUpdateTimer->Stop());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Start timer responsible for vertical volume host fadeout,
	////      provided that pre-requisite conditions for hiding it are met.
	////
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StartVerticalVolumeHideTimer()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpHideVerticalVolumeTimer &&
	//            ShouldHideVerticalVolume())
	//        {
	//            IFC(m_tpHideVerticalVolumeTimer->Start());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Stop timer responsible for vertical volume host fadeout
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StopVerticalVolumeHideTimer()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpHideVerticalVolumeTimer)
	//        {
	//            IFC(m_tpHideVerticalVolumeTimer->Stop());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Start timer responsible for control panel fadeout,
	////      provided that pre-requisite conditions for hiding it are met.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StartControlPanelHideTimer()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpHideControlPanelTimer &&
	//            ShouldHideControlPanel())
	//        {
	//            IFC(m_tpHideControlPanelTimer->Start());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Stop timer responsible for control panel fadeout
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::StopControlPanelHideTimer()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled)
	//    {
	//        if (m_tpHideControlPanelTimer)
	//        {
	//            IFC(m_tpHideControlPanelTimer->Stop());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Helper to add Tooltip to a component control.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::AddTooltip(
	//    _In_ xaml::IDependencyObject* pTooltipTarget,
	//    _In_ HSTRING hstrTooltipText)
	//{
	//    HRESULT hr = S_OK;

	//    ctl::ComPtr<ToolTip> spToolTip;
	//    ctl::ComPtr<wf::IPropertyValueStatics> spPropertyValueFactory;
	//    ctl::ComPtr<wf::IPropertyValue> spContentAsPV;

	//    IFC(ctl::make<ToolTip>(&spToolTip));

	//    IFC(wf::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_Foundation_PropertyValue).Get(), spPropertyValueFactory.ReleaseAndGetAddressOf()));
	//    IFC(spPropertyValueFactory->CreateString(hstrTooltipText, &spContentAsPV));
	//    IFC(spToolTip->put_Content(ctl::as_iinspectable(spContentAsPV.Get())));

	//    IFC(ToolTipServiceFactory::SetToolTipStatic(pTooltipTarget, ctl::as_iinspectable(spToolTip.Get())));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Helper to update an existing Tooltip text of a component control.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateTooltipText(
	//    _In_ xaml::IDependencyObject* pTooltipTarget,
	//    _In_ HSTRING hstrTooltipText)
	//{
	//    HRESULT hr = S_OK;

	//    ctl::ComPtr<IInspectable> spToolTipAsInsp;
	//    ctl::ComPtr<xaml_controls::IToolTip> spToolTip;
	//    ctl::ComPtr<wf::IPropertyValueStatics> spPropertyValueFactory;
	//    ctl::ComPtr<wf::IPropertyValue> spContentAsPV;

	//    IFC(ToolTipServiceFactory::GetToolTipStatic(pTooltipTarget, &spToolTipAsInsp));
	//    if (spToolTipAsInsp)
	//    {
	//        IFC(wf::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_Foundation_PropertyValue).Get(), spPropertyValueFactory.ReleaseAndGetAddressOf()));
	//        IFC(spPropertyValueFactory->CreateString(hstrTooltipText, &spContentAsPV));
	//        IFC(spToolTipAsInsp.As(&spToolTip));
	//        IFC(spToolTip.Cast<ToolTip>()->put_Content(ctl::as_iinspectable(spContentAsPV.Get())));
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update the list of tracks in AvailableAudioTracksMenuFlyout.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateAudioSelectionFlyout()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(UpdateAudioSelectionFlyoutFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(UpdateAudioSelectionFlyoutFromMPE());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Release the Click Handlers associated with each MenuFlyoutItem
	////      in AvailableAudioTracksMenuFlyout.
	////
	////------------------------------------------------------------------------
	//void
	//MediaTransportControls::ReleaseMenuFlyoutItemClickHandlers()
	//{
	//    std::vector<EventPtr<MenuFlyoutItemClickEventCallback>*>::const_iterator iter;

	//    if (!m_audioTrackClickHandlers.empty())
	//    {
	//        // Delete each event pointer.
	//        for(iter = m_audioTrackClickHandlers.begin(); iter != m_audioTrackClickHandlers.end(); iter++)
	//        {
	//            EventPtr<MenuFlyoutItemClickEventCallback>* pEventPtr = *iter;
	//            delete pEventPtr;
	//        }

	//        // Clear the std::vector
	//        m_audioTrackClickHandlers.clear();
	//    }
	//}

	//// Update the list of tracks in AvailableCCTracksMenuFlyout.
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateCCSelectionFlyout()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (MTCParent_MediaElement == m_parentType)
	//        {
	//            IFC(UpdateCCSelectionFlyoutFromME());
	//        }
	//        else if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(UpdateCCSelectionFlyoutFromMPE());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Helper that create the Flyout item for the menu items
	//_Check_return_ HRESULT
	//MediaTransportControls::CreateCCFlyoutTrack(_In_ HSTRING strLabelTemp, _In_ int id, _In_ int idx)
	//{
	//    ctl::ComPtr<wfc::IVector<xaml_controls::MenuFlyoutItemBase*>> spMenuFlyoutItems;
	//    wrl_wrappers::HString strProcessedLabel;
	//    ctl::ComPtr<MenuFlyoutItem> spNewMenuFlyoutItem;

	//    IFC_RETURN(m_tpAvailableCCTracksMenuFlyout->get_Items(&spMenuFlyoutItems));

	//    if (m_currentTrack == id)
	//    {
	//        IFC_RETURN(MarkLanguageSelection(strLabelTemp, strProcessedLabel.ReleaseAndGetAddressOf()));
	//    }
	//    else
	//    {
	//        strProcessedLabel.Set(strLabelTemp);
	//    }

	//    m_trackIdMappings[idx] = id;

	//    IFC_RETURN(ctl::make<MenuFlyoutItem>(&spNewMenuFlyoutItem));

	//    IFC_RETURN(spNewMenuFlyoutItem->put_Text(strProcessedLabel));
	//    IFC_RETURN(spMenuFlyoutItems->Append(spNewMenuFlyoutItem.Get()));

	//    // Create event handler via EventPtr for this MenuFlyoutItem and add it to m_audioTrackClickHandlers
	//    EventPtr<MenuFlyoutItemClickEventCallback>* pMenuFlyoutItemClickHandler = new EventPtr<MenuFlyoutItemClickEventCallback>();

	//    IFC_RETURN(pMenuFlyoutItemClickHandler->AttachEventHandler(spNewMenuFlyoutItem.Get(),
	//        [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//    {
	//        return OnCCTrackClicked(pSender, pArgs);
	//    }));

	//    m_CCTrackClickHandlers.push_back(pMenuFlyoutItemClickHandler);

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Release the Click Handlers associated with each MenuFlyoutItem
	////      in AvailableCCTracksMenuFlyout.
	////
	////------------------------------------------------------------------------
	//void
	//MediaTransportControls::ReleaseCCSelectionMenuFlyoutItemClickHandlers()
	//{
	//    std::vector<EventPtr<MenuFlyoutItemClickEventCallback>*>::const_iterator iter;

	//    if (!m_CCTrackClickHandlers.empty())
	//    {
	//        // Delete each event pointer.
	//        for (iter = m_CCTrackClickHandlers.begin(); iter != m_CCTrackClickHandlers.end(); iter++)
	//        {
	//            EventPtr<MenuFlyoutItemClickEventCallback>* pEventPtr = *iter;
	//            delete pEventPtr;
	//        }

	//        // Clear the std::vector
	//        m_CCTrackClickHandlers.clear();
	//        m_trackIdMappings.clear();
	//    }
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update the play rate menu in AvailablePlaybackRateMenuFlyout.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdatePlaybackRateFlyout()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wfc::IVector<xaml_controls::MenuFlyoutItemBase*>> spMenuFlyoutItems;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        double playbackRate;
	//        unsigned int i = 0;
	//        BOOLEAN selectItemCompleted = FALSE;
	//        IFC(m_tpAvailablePlaybackRateMenuFlyout->get_Items(&spMenuFlyoutItems));

	//        // Clear all tracks and associated click event handlers
	//        IFC(spMenuFlyoutItems->Clear());
	//        ReleasePlaybackRateMenuFlyoutItemClickHandlers();

	//        m_currentPlaybackRates.reserve(AvailablePlaybackRateCount + 1);
	//        IFC(GetPlaybackRate(&playbackRate));

	//        while(i < AvailablePlaybackRateCount)
	//        {
	//            wrl_wrappers::HString strLabel;
	//            WCHAR szLabelBuffer[5];
	//            wrl_wrappers::HString strProcessedLabel;

	//            if (!selectItemCompleted && playbackRate <= AvailablePlaybackRateList[i])
	//            {
	//                IFCEXPECT(swprintf_s(szLabelBuffer, ARRAYSIZE(szLabelBuffer), L"%.2f", playbackRate) >= 0);
	//                IFC(strLabel.Set(szLabelBuffer));
	//                IFC(MarkLanguageSelection(strLabel.Get(), strProcessedLabel.ReleaseAndGetAddressOf()));
	//                m_currentPlaybackRates.push_back(playbackRate);
	//                if (playbackRate == AvailablePlaybackRateList[i])
	//                {
	//                    i++;
	//                }
	//                selectItemCompleted = TRUE;
	//            }
	//            else
	//            {
	//                IFCEXPECT(swprintf_s(szLabelBuffer, ARRAYSIZE(szLabelBuffer), L"%.2f", AvailablePlaybackRateList[i]) >= 0);
	//                IFC(strProcessedLabel.Set(szLabelBuffer));
	//                m_currentPlaybackRates.push_back(AvailablePlaybackRateList[i]);
	//                i++;
	//            }

	//            ctl::ComPtr<MenuFlyoutItem> spNewMenuFlyoutItem;
	//            IFC(ctl::make<MenuFlyoutItem>(&spNewMenuFlyoutItem));

	//            IFC(spNewMenuFlyoutItem->put_Text(strProcessedLabel.Get()));
	//            IFC(spMenuFlyoutItems->Append(spNewMenuFlyoutItem.Get()));

	//            // Create event handler via EventPtr for this MenuFlyoutItem and add it to m_playbackRateClickHandlers
	//            EventPtr<MenuFlyoutItemClickEventCallback>* pMenuFlyoutItemClickHandler = new EventPtr<MenuFlyoutItemClickEventCallback>();

	//            IFC(pMenuFlyoutItemClickHandler->AttachEventHandler(spNewMenuFlyoutItem.Get(),
	//                [this](IInspectable* pSender, IRoutedEventArgs* pArgs)
	//            {
	//                return OnPlaybackRateMenuClicked(pSender, pArgs);
	//            }));

	//            m_playbackRateClickHandlers.push_back(pMenuFlyoutItemClickHandler);
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Release the Click Handlers associated with each MenuFlyoutItem
	////      in AvailablePlaybackRateMenuFlyout.
	////
	////------------------------------------------------------------------------
	//void
	//MediaTransportControls::ReleasePlaybackRateMenuFlyoutItemClickHandlers()
	//{
	//    std::vector<EventPtr<MenuFlyoutItemClickEventCallback>*>::const_iterator iter;

	//    if (!m_playbackRateClickHandlers.empty())
	//    {
	//        // Delete each event pointer.
	//        for (iter = m_playbackRateClickHandlers.begin(); iter != m_playbackRateClickHandlers.end(); iter++)
	//        {
	//            EventPtr<MenuFlyoutItemClickEventCallback>* pEventPtr = *iter;
	//            delete pEventPtr;
	//        }

	//        // Clear the std::vector
	//        m_playbackRateClickHandlers.clear();
	//        m_currentPlaybackRates.clear();
	//    }
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to convert a duration in seconds to HString in [H]H:mm:ss format
	////      for display in the ProgressTime and RemainingTime textblocks in the UI.
	////
	////      Duration is taken modulo 1 day = 86400 sec, as that is the largest
	////      valid input for GetTimeFormat().
	////
	////      In some cases, RemainingTime could be negative due to nonzero
	////      start times as with some IIS Smooth Streaming content. To avoid a crash
	////      here, we always clamp negative incoming time to 0 in this helper.
	////      See WinBlue Bug 440546 for details.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::ConvertSecondsToHString(
	//    _In_ INT64 totalSeconds,
	//    _Outptr_ HSTRING* pDisplayTime)
	//{
	//    HRESULT hr = S_OK;
	//    WCHAR szDisplayTime[MaxTimeButtonTextLength];
	//    wrl_wrappers::HString strDisplayTime;
	//    INT32 totalSecondsInRange = (totalSeconds > 0) ? (totalSeconds % 86400) : 0;
	//    INT32 numHours = static_cast<INT32> (totalSecondsInRange / 3600);
	//    INT32 remainingSeconds = static_cast<INT32> (totalSecondsInRange % 3600);
	//    INT32 numMinutes = remainingSeconds / 60;
	//    INT32 numSeconds = remainingSeconds % 60;
	//    INT32 getTimeFormatResult = 0;
	//    SYSTEMTIME time = {0};

	//    ASSERT (numHours < 24 && numMinutes < 60 && numSeconds < 60);

	//    time.wSecond = static_cast<WORD>(numSeconds);
	//    time.wMinute = static_cast<WORD>(numMinutes);
	//    time.wHour = static_cast<WORD>(numHours);

	//    ZeroMemory(szDisplayTime, sizeof(WCHAR)* MaxTimeButtonTextLength);

	//    getTimeFormatResult = GetTimeFormat(
	//        LOCALE_USER_DEFAULT,
	//        TIME_NOTIMEMARKER | TIME_FORCE24HOURFORMAT,
	//        &time,
	//        NULL,
	//        szDisplayTime,
	//        MaxTimeButtonTextLength);

	//    // Fall back to unlocalized string in case GetTimeFormat() fails.
	//    if (getTimeFormatResult == 0)
	//    {
	//        IFCEXPECT(swprintf_s(szDisplayTime, MaxTimeButtonTextLength, L"%02d:%02d:%02d", numHours, numMinutes, numSeconds) >= 0);
	//    }

	//    IFC(strDisplayTime.Set(szDisplayTime));
	//    *pDisplayTime = strDisplayTime.Detach();

	//Cleanup:
	//    return hr;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to parent MTC to FullWindowMediaRoot
	////
	////      Precondition - no other ME's MTC is currently parented to FullWindowMediaRoot
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::AddToFullWindowMediaRoot()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;
	//    ctl::ComPtr<wfc::IVector<xaml::UIElement*>> spChildren;
	//    ctl::ComPtr<xaml_controls::IPanel> spFullWindowMediaRoot;

	//    IFC(m_wrOwnerParent.As(&spOwnerParent))
	//    if (m_transportControlsEnabled && spOwnerParent.Get())
	//    {
	//        IFC(VisualTreeHelper::GetFullWindowMediaRootStatic(spOwnerParent.Get(), &spFullWindowMediaRoot));
	//        ASSERT(spFullWindowMediaRoot.Get());

	//        if (spFullWindowMediaRoot)
	//        {
	//            IFC(spFullWindowMediaRoot.Cast<Panel>()->get_ChildrenInternal(&spChildren));
	//            IFC(spChildren->Append(this));
	//        }

	//        IFC(GetXamlDispatcherNoRef()->RunAsync(
	//            MakeCallback(
	//                ctl::ComPtr<MediaTransportControls>(this),
	//                &MediaTransportControls::UpdateAfterEnteringFullWindow)));
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateAfterEnteringFullWindow()
	//{            
	//    if(m_tokLayoutBoundsChanged.value == 0)
	//    {
	//        ctl::WeakRefPtr wrThis;
	//        IFC_RETURN(ctl::AsWeak(this, &wrThis));
	//        DXamlCore::GetCurrent()->GetLayoutBoundsHelperNoRef()->AddLayoutBoundsChangedCallback(
	//        [wrThis]() mutable
	//        { 
	//            ctl::ComPtr<MediaTransportControls> spThis;
	//            IFC_RETURN(wrThis.As(&spThis));
	//            if(spThis.Get())
	//            {
	//                ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;

	//                IFC_RETURN(spThis->m_wrOwnerParent.As(&spOwnerParent))
	//                if (spOwnerParent.Get())
	//                {
	//                    if (spThis->m_isFullWindow && spOwnerParent.Cast<FrameworkElement>()->IsInLiveTree())
	//                    {
	//                        // Update the media transport control's bounds with the available layout bounds.
	//                        // showing or hiding the soft buttons.
	//                        IFC_RETURN(spThis->UpdateMediaTransportBounds());
	//                    }
	//                }
	//            }
	//            return S_OK;
	//        }, &m_tokLayoutBoundsChanged);
	//    }

	//    // Update the media transport control's bounds with the current available layout bounds.
	//    IFC_RETURN(UpdateMediaTransportBounds());

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetFocusAfterEnteringFullWindowMode()
	//{
	//    BOOLEAN focused = FALSE;
	//    BOOLEAN compact = FALSE;
	//    IFC_RETURN(get_IsCompact(&compact));
	//    // In Full Window mode, we give focus to PlayPaus button and set Cycle
	//    // TabNavigation behavior on the root, so that user has a clean way
	//    // to navigate the transport controls. For Windows 8.1 (Blue) IsCompact always false
	//    if (!compact)
	//    {
	//        if (m_tpPlayPauseButton)
	//        {
	//            IFC_RETURN(m_tpPlayPauseButton.Cast<ButtonBase>()->Focus(xaml::FocusState_Pointer, &focused));
	//            ASSERT(focused);
	//            IFC_RETURN(put_TabNavigation(xaml_input::KeyboardNavigationMode_Cycle));
	//        }
	//        else
	//        {
	//            // In case Play/Pause remove button through re-template, then we are loosing focus in that case, we need to set on the Next Focussable Element.
	//            CFocusManager* pFocusManager = VisualTree::GetFocusManagerForElement(this->GetHandle());
	//            if (pFocusManager)
	//            {
	//                IFC_RETURN(pFocusManager->SetFocusOnNextFocusableElement(DirectUI::FocusState::Programmatic, true));
	//            }
	//        }
	//    }
	//    else
	//    {
	//        if (m_tpTHLeftSidePlayPauseButton)
	//        {
	//            IFC_RETURN(m_tpTHLeftSidePlayPauseButton.Cast<ButtonBase>()->Focus(xaml::FocusState_Pointer, &focused));
	//            ASSERT(focused);
	//            IFC_RETURN(put_TabNavigation(xaml_input::KeyboardNavigationMode_Cycle));
	//        }
	//        else
	//        {
	//            // In case Play/Pause remove button through re-template, then we are loosing focus in that case, we need to set on the Next Focussable Element.
	//            CFocusManager* pFocusManager = VisualTree::GetFocusManagerForElement(this->GetHandle());
	//            if (pFocusManager)
	//            {
	//                IFC_RETURN(pFocusManager->SetFocusOnNextFocusableElement(DirectUI::FocusState::Programmatic, true));
	//            }
	//        }
	//    }

	//    return S_OK;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to remove MTC from FullWindowMediaRoot's children
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::RemoveFromFullWindowMediaRoot()
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;
	//    ctl::ComPtr<wfc::IVector<xaml::UIElement*>> spChildren;
	//    ctl::ComPtr<xaml_controls::IPanel> spFullWindowMediaRoot;

	//    IFC(m_wrOwnerParent.As(&spOwnerParent))
	//    if (m_transportControlsEnabled && spOwnerParent.Get())
	//    {
	//        IFC(VisualTreeHelper::GetFullWindowMediaRootStatic(spOwnerParent.Get(), &spFullWindowMediaRoot));
	//        ASSERT(spFullWindowMediaRoot.Get());

	//        if (spFullWindowMediaRoot)
	//        {
	//            IFC(spFullWindowMediaRoot.Cast<Panel>()->get_ChildrenInternal(&spChildren));

	//            unsigned int childrenSize = 0;
	//            IFC(spChildren->get_Size(&childrenSize));
	//            for (unsigned int i = 0; i < childrenSize; i++)
	//            {
	//                ctl::ComPtr<xaml::IUIElement> spUIE;
	//                IFC(spChildren->GetAt(i, &spUIE));
	//                if (spUIE.Get() == this)
	//                {
	//                    IFC(spChildren->RemoveAt(i));
	//                    break;
	//                }
	//            }
	//        }

	//        // Go back to defalt TabNavigation behavior now that we are leaving FW mode.
	//        if (m_tpPlayPauseButton || m_tpTHLeftSidePlayPauseButton)
	//        {
	//            IFC(put_TabNavigation(xaml_input::KeyboardNavigationMode_Local));
	//        }

	//        // Remove the window size changed and app view bounds changed events.
	//        DXamlCore::GetCurrent()->GetLayoutBoundsHelperNoRef()->RemoveLayoutBoundsChangedCallback(&m_tokLayoutBoundsChanged);
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Called by MediaPlayerElement when we're exiting full window mode
	//// TODO: TFS 7990888 -- Factor this better with RemoveFromFullWindowMediaRoot, which is called by MediaElement
	//_Check_return_ HRESULT
	//MediaTransportControls::HandleExitFullWindowMode()
	//{
	//    ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;

	//    IFC_RETURN(m_wrOwnerParent.As(&spOwnerParent))
	//    if (m_transportControlsEnabled && spOwnerParent.Get())
	//    {
	//        // Go back to defalt TabNavigation behavior now that we are leaving FW mode.
	//        if (m_tpPlayPauseButton || m_tpTHLeftSidePlayPauseButton)
	//        {
	//            IFC_RETURN(put_TabNavigation(xaml_input::KeyboardNavigationMode_Local));
	//        }
	//    }

	//    return S_OK;
	//}


	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Obtain the processed language string to display in audio selection menu:
	////         >> Localized language name based on RFC 1766 tag if possible
	////         >> "untitled" if NULL tag is passed in, or we could not get
	////            localized language if from the tag
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::GetLocalizedLanguageName(
	//    _In_opt_ HSTRING languageTag,
	//    _Outptr_ HSTRING* pProcessedLanguageName)
	//{
	//    HRESULT hr = S_OK;
	//    LPCWSTR pszLanguageTag = NULL;
	//    UINT32 cLanguageTag = 0;
	//    WCHAR* pLocalizedNameBuffer = NULL;
	//    BOOLEAN useUntitled = TRUE;
	//    wrl_wrappers::HString strLocalizedLanguage;

	//    *pProcessedLanguageName = NULL;

	//    // If no languageTag is passed, we'll use "untitled" string
	//    if (languageTag)
	//    {
	//        pLocalizedNameBuffer = new WCHAR[MaxProcessedLanguageNameLength];
	//        ZeroMemory(pLocalizedNameBuffer, MaxProcessedLanguageNameLength);

	//        pszLanguageTag = HStringUtil::GetRawBuffer(languageTag, &cLanguageTag);

	//        if (cLanguageTag > 0 && pszLanguageTag)
	//        {
	//            // Success - nonzero return value
	//            if (0 != ::GetLocaleInfoEx(pszLanguageTag, LOCALE_SLOCALIZEDLANGUAGENAME, pLocalizedNameBuffer, MaxProcessedLanguageNameLength))
	//            {
	//                // Extra check to ensure string is always NULL terminated
	//                pLocalizedNameBuffer[MaxProcessedLanguageNameLength - 1] = L'\0';

	//                // We are here if everything succeeded, so use the obtianed localized string.
	//                // All other cases use default "untitled" string.
	//                useUntitled = FALSE;
	//            }
	//            else
	//            {
	//                TRACE(TraceAlways, L"GetLocaleInfoEx() failed to obtain localized language name for language tag %s", pszLanguageTag);
	//            }
	//        }
	//    }

	//    if (useUntitled)
	//    {
	//        IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(TEXT_MEDIA_AUDIO_TRACK_UNTITLED, strLocalizedLanguage.ReleaseAndGetAddressOf()));
	//    }
	//    else
	//    {
	//        IFC(strLocalizedLanguage.Set(pLocalizedNameBuffer));
	//    }

	//    *pProcessedLanguageName = strLocalizedLanguage.Detach();

	//Cleanup:
	//    delete[] pLocalizedNameBuffer;
	//    return hr;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////     Appends localized " (on)" suffix to localizedLanguage to signify
	////     this is the language associated with currently active audio stream.
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::MarkLanguageSelection(
	//    _In_opt_ HSTRING localizedLanguage,
	//    _Outptr_ HSTRING* pMarkedLocalizedLanguage)
	//{
	//    HRESULT hr = S_OK;
	//    wrl_wrappers::HString strSuffix;
	//    wrl_wrappers::HString strResultTemp;
	//    wrl_wrappers::HString strResultFull;

	//    *pMarkedLocalizedLanguage = NULL;

	//    // Get the "(on)" suffix
	//    IFC(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(TEXT_MEDIA_AUDIO_TRACK_SELECTED, strSuffix.ReleaseAndGetAddressOf()));

	//    IFC(::WindowsConcatString(localizedLanguage, wrl_wrappers::HStringReference(L" ").Get(), strResultTemp.GetAddressOf()));

	//    IFC(strResultTemp.Concat(strSuffix, strResultFull));

	//    *pMarkedLocalizedLanguage = strResultFull.Detach();

	//Cleanup:
	//    return hr;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to check if originalSource passed in RoutedEventArgs has
	////      programmatic or keyboard focus (as opposed to pointer or no focus).
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::HasKeyOrProgFocus(
	//    _In_ xaml::IRoutedEventArgs *pArgs,
	//    _Out_ BOOLEAN *pHasKeyOrProgFocus)
	//{
	//    HRESULT hr = S_OK;
	//    xaml::FocusState focusState = xaml::FocusState_Unfocused;
	//    ctl::ComPtr<IInspectable> spOriginalSource;
	//    ctl::ComPtr<xaml::IUIElement> spFocusedElement;

	//    *pHasKeyOrProgFocus = FALSE;

	//    IFC(pArgs->get_OriginalSource(&spOriginalSource));

	//    if (spOriginalSource)
	//    {
	//        // Make sure Orignal source should be derived from control
	//        spFocusedElement = spOriginalSource.AsOrNull<xaml::IUIElement>();
	//        if (spFocusedElement)
	//        {
	//            IFC(spFocusedElement->get_FocusState(&focusState));

	//            if (focusState == xaml::FocusState_Keyboard ||
	//                focusState == xaml::FocusState_Programmatic)
	//            {
	//                *pHasKeyOrProgFocus = TRUE;
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to check if pControlToCompare is the originalSource
	////      passed in RoutedEventArgs.
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::CompareWithOriginalSource(
	//    _In_ xaml::IRoutedEventArgs *pArgs,
	//    _In_ IInspectable *pObjectToCompare,
	//    _Out_ BOOLEAN *pIsEqual)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<IInspectable> spOriginalSource;

	//    *pIsEqual = FALSE;

	//    IFC(pArgs->get_OriginalSource(&spOriginalSource));

	//    *pIsEqual = spOriginalSource.Get() == pObjectToCompare;

	//Cleanup:
	//    return hr;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to hit test pElement against point.
	////
	////---------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::HitTestHelper(
	//    _In_ wf::Point point,
	//    _In_ xaml::IUIElement* pElement,
	//    _Out_ BOOLEAN* pHasHit)
	//{
	//    HRESULT hr =  S_OK;
	//    ctl::ComPtr<wfc::IIterable<xaml::UIElement*>> spElements;
	//    ctl::ComPtr<wfc::IIterator<xaml::UIElement*>> spIterator;
	//    BOOLEAN hasCurrent;

	//    *pHasHit = FALSE;

	//    IFC(VisualTreeHelper::FindAllElementsInHostCoordinatesPointStatic(point, pElement, (m_tpCommandBar) ? FALSE :TRUE /* includeAllElements */, &spElements));
	//    IFC(spElements->First(&spIterator));
	//    IFC(spIterator->get_HasCurrent(&hasCurrent));

	//    while (hasCurrent)
	//    {
	//        ctl::ComPtr<xaml::IUIElement> spElement;
	//        IFC(spIterator->get_Current(&spElement));
	//        if (pElement == spElement.Get())
	//        {
	//            *pHasHit = TRUE;
	//            break;
	//        }
	//        IFC(spIterator->MoveNext(&hasCurrent));
	//    }

	//Cleanup:
	//    return hr;
	//}


	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to check if conditions are met to hide vertical volume UI.
	////
	////---------------------------------------------------------------------------
	//BOOLEAN
	//MediaTransportControls::ShouldHideVerticalVolume()
	//{
	//    return  m_verticalVolumeIsVisible &&
	//           !m_verticalVolumeHasKeyOrProgFocus;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to check if conditions are met to hide control panel.
	////
	////---------------------------------------------------------------------------
	//BOOLEAN
	//MediaTransportControls::ShouldHideControlPanel()
	//{
	//    BOOLEAN isAutoShowHide = false;
	//    IGNOREHR(get_ShowAndHideAutomatically(&isAutoShowHide));

	//    return  m_controlPanelIsVisible &&
	//           !m_isAudioOnly &&
	//           !m_hasError &&
	//           (m_shouldDismissControlPanel || !m_controlPanelHasPointerOver) &&
	//           !m_rootHasPointerPressed &&
	//           // Do not need to check this on the Xbox only if commandbar should exist in the template.
	//           (!m_controlsHaveKeyOrProgFocus || (XboxUtility::IsOnXbox() && m_tpCommandBar.Get())) &&
	//           !m_verticalVolumeHasKeyOrProgFocus &&
	//           ShouldHideControlPanelWhilePlaying() &&
	//           !m_isFlyoutOpen &&
	//           !m_isPointerMove &&
	//           // Hide MTC only if auto hide/Show is enabled
	//           isAutoShowHide;
	//}

	////---------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Helper to check if conditions are met to hide control panel while playing.
	////      It should stay if we aren't playing video.
	////
	////---------------------------------------------------------------------------
	//BOOLEAN
	//MediaTransportControls::ShouldHideControlPanelWhilePlaying()
	//{
	//    return  (m_isPlaying && !m_isBuffering)
	//            || (m_shouldDismissControlPanel);
	//}


	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Enters MediaEngine's scrubbing mode.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::EnterScrubbingMode()
	//{
	//    HRESULT hr = S_OK;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        // Scrub mode is not useful for audio-only or live content
	//        if (!m_isAudioOnly &&
	//            !IsLiveContent() &&
	//            !m_isInScrubMode)
	//        {
	//            IFC(GetPlaybackRate(&m_currentPlaybackRate));
	//            IFC(SetPlaybackRate(0.0));
	//            IFC(EnableValueChangedEventThrottlingOnSliderAutomation(false));
	//            m_isInScrubMode = TRUE;
	//        }
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::ScrubbingMode, data);
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Exits MediaEngine's scrubbing mode.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::ExitScrubbingMode()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (!m_isAudioOnly &&
	//            !IsLiveContent() &&
	//            m_isInScrubMode)
	//        {
	//            IFC(SetPlaybackRate(m_currentPlaybackRate));
	//            IFC(EnableValueChangedEventThrottlingOnSliderAutomation(true));
	//            m_isInScrubMode = FALSE;
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called to update media layout bounds.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateMediaTransportBounds()
	//{
	//    ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;
	//    IFC_RETURN(m_wrOwnerParent.As(&spOwnerParent))
	//    if (spOwnerParent.Get())
	//    {
	//        auto* pFullWindowMediaRoot = GetHandle()->GetContext()->GetMainFullWindowMediaRoot();
	//        if (pFullWindowMediaRoot)
	//        {
	//            // Update the media transport control's bounds when the layout bounds is changed by
	//            // showing or hiding the soft buttons.
	//            // The SystemTray and AppBar will be suppressed on the full windowed media mode
	//            // so the layout bounds is the right bounds of the media transport control.
	//            pFullWindowMediaRoot->InvalidateArrange();
	//            pFullWindowMediaRoot->InvalidateMeasure();
	//        }
	//    }

	//    return S_OK;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Called for property changes via DXaml SetValue()
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPropertyChanged2(_In_ const PropertyChangedParams& args)
	//{
	//    HRESULT hr = S_OK;

	//    IFC(MediaTransportControlsGenerated::OnPropertyChanged2(args));
	//    IFC(UpdateMediaControlState(args.m_pDP->GetIndex()));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Update all MediaControl States
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateMediaControlAllStates()
	//{
	//    HRESULT hr = S_OK;

	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFullWindowButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsZoomButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSeekBarVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsVolumeButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFullWindowEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsVolumeEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsZoomEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSeekEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsPlaybackRateButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsPlaybackRateEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFastForwardButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFastForwardEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFastRewindEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsFastRewindButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsStopEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsStopButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsCompact));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSkipForwardEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSkipBackwardEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSkipForwardButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsSkipBackwardButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsNextTrackButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsPreviousTrackButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsRepeatButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsRepeatEnabled));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsCompactOverlayButtonVisible));
	//    IFC(UpdateMediaControlState(KnownPropertyIndex::MediaTransportControls_IsCompactOverlayEnabled));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Handling common to Dxaml level and core level property changes
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateMediaControlState(_In_ KnownPropertyIndex propertyIndex) noexcept
	//{
	//    HRESULT hr = S_OK;
	//    BOOLEAN value = FALSE;
	//    BOOLEAN compact = FALSE;
	//    ctl::ComPtr<xaml::IDependencyObject> spOwnerParent;
	//    ctl::ComPtr<xaml_controls::ITextBlock> spTimeElapsedTextBlock;
	//    ctl::ComPtr<xaml_controls::ITextBlock> spTimeRemainingTextBlock;

	//    switch (propertyIndex)
	//    {
	//        case KnownPropertyIndex::MediaTransportControls_IsFullWindowButtonVisible:
	//        {
	//            if (m_tpFullWindowButton)
	//            {

	//                // Remove this code to disable and hide only after Deliverable 19012797: Fullscreen media works in ApplicationWindow and Win32 XAML Islands is complete
	//                CContentRoot* contentRoot = VisualTree::GetContentRootForElement(GetHandle());
	//                if( contentRoot->GetType() == CContentRoot::Type::XamlIsland )
	//                {
	//                    IFC(m_tpFullWindowButton.Cast<ButtonBase>()->put_Visibility(xaml::Visibility_Collapsed));
	//                }
	//                else
	//                {
	//                    IFC(get_IsFullWindowButtonVisible(&value));
	//                    IFC(m_tpFullWindowButton.Cast<ButtonBase>()->put_Visibility(
	//                        (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//                }
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsZoomButtonVisible:
	//        {
	//            if (m_tpZoomButton)
	//            {
	//                IFC(get_IsZoomButtonVisible(&value));
	//                IFC(m_tpZoomButton.Cast<ButtonBase>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSeekBarVisible:
	//        {
	//            IFC(get_IsSeekBarVisible(&value));
	//            IFC(get_IsCompact(&compact));
	//            if (m_tpTimeElapsedElement && !compact)
	//            {
	//                IFC(m_tpTimeElapsedElement.As(&spTimeElapsedTextBlock));
	//                IFC(spTimeElapsedTextBlock.Cast<TextBlock>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            if (m_tpTimeRemainingElement && !compact)
	//            {
	//                IFC(m_tpTimeRemainingElement.As(&spTimeRemainingTextBlock));
	//                IFC(spTimeRemainingTextBlock.Cast<TextBlock>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            if (m_tpMediaPositionSlider)
	//            {
	//                IFC(m_tpMediaPositionSlider.Cast<Slider>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsVolumeButtonVisible:
	//        {

	//            if (m_tpTHVolumeButton)
	//            {
	//                IFC(get_IsVolumeButtonVisible(&value));
	//                IFC(m_tpTHVolumeButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsPlaybackRateButtonVisible:
	//        {

	//            if (m_tpPlaybackRateButton)
	//            {
	//                IFC(get_IsPlaybackRateButtonVisible(&value));
	//                IFC(m_tpPlaybackRateButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsFastForwardButtonVisible:
	//        {

	//            if (m_tpFastForwardButton)
	//            {
	//                IFC(get_IsFastForwardButtonVisible(&value));
	//                IFC(m_tpFastForwardButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsFastRewindButtonVisible:
	//        {

	//            if (m_tpFastRewindButton)
	//            {
	//                IFC(get_IsFastRewindButtonVisible(&value));
	//                IFC(m_tpFastRewindButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsStopButtonVisible:
	//        {

	//            if (m_tpStopButton)
	//            {
	//                IFC(get_IsStopButtonVisible(&value));
	//                IFC(m_tpStopButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSkipForwardButtonVisible:
	//        {

	//            if (m_tpSkipForwardButton)
	//            {
	//                IFC(get_IsSkipForwardButtonVisible(&value));
	//                IFC(m_tpSkipForwardButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSkipBackwardButtonVisible:
	//        {

	//            if (m_tpSkipBackwardButton)
	//            {
	//                IFC(get_IsSkipBackwardButtonVisible(&value));
	//                IFC(m_tpSkipBackwardButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsNextTrackButtonVisible:
	//        {

	//            if (m_tpNextTrackButton)
	//            {
	//                IFC(get_IsNextTrackButtonVisible(&value));
	//                IFC(m_tpNextTrackButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsPreviousTrackButtonVisible:
	//        {

	//            if (m_tpPreviousTrackButton)
	//            {
	//                IFC(get_IsPreviousTrackButtonVisible(&value));
	//                IFC(m_tpPreviousTrackButton.Cast<Button>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsRepeatButtonVisible:
	//        {

	//            if (m_tpRepeatButton)
	//            {
	//                IFC(get_IsRepeatButtonVisible(&value));
	//                IFC(m_tpRepeatButton.Cast<ToggleButton>()->put_Visibility(
	//                    (value) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsCompactOverlayButtonVisible:
	//        {
	//            if (m_tpCompactOverlayButton)
	//            {
	//                ctl::ComPtr<wuv::IApplicationView4> spAppView4;
	//                boolean isSupport = false;
	//                IFC(GetMiniView(&spAppView4));
	//                if (spAppView4)
	//                {
	//                    IFC(spAppView4->IsViewModeSupported(wuv::ApplicationViewMode::ApplicationViewMode_CompactOverlay, &isSupport));
	//                }
	//                IFC(get_IsCompactOverlayButtonVisible(&value));

	//                IFC(m_tpCompactOverlayButton.Cast<Button>()->put_Visibility(
	//                    (value && isSupport) ? xaml::Visibility_Visible : xaml::Visibility_Collapsed));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsFullWindowEnabled:
	//        {
	//            if (m_tpFullWindowButton)
	//            {
	//                // Remove this code to disable and hide only after Deliverable 19012797: Fullscreen media works in ApplicationWindow and Win32 XAML Islands is complete
	//                CContentRoot* contentRoot = VisualTree::GetContentRootForElement(GetHandle());
	//                if( contentRoot->GetType() == CContentRoot::Type::XamlIsland )
	//                {
	//                    IFC(m_tpFullWindowButton.Cast<ButtonBase>()->put_IsEnabled(false));
	//                }
	//                else
	//                {
	//                    IFC(get_IsFullWindowEnabled(&value));
	//                    IFC(m_tpFullWindowButton.Cast<ButtonBase>()->put_IsEnabled(value));
	//                }

	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsVolumeEnabled:
	//        {
	//            if (m_tpTHVolumeButton)
	//            {
	//                IFC(get_IsVolumeEnabled(&value));
	//                IFC(m_tpTHVolumeButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsZoomEnabled:
	//        {
	//            if (m_tpZoomButton)
	//            {
	//                IFC(get_IsZoomEnabled(&value));
	//                IFC(m_tpZoomButton.Cast<ButtonBase>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSeekEnabled:
	//        {
	//            if (m_tpMediaPositionSlider)
	//            {
	//                IFC(get_IsSeekEnabled(&value));
	//                IFC(m_tpMediaPositionSlider.Cast<Slider>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsPlaybackRateEnabled:
	//        {
	//            if (m_tpPlaybackRateButton)
	//            {
	//                IFC(get_IsPlaybackRateEnabled(&value));
	//                IFC(m_tpPlaybackRateButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsFastForwardEnabled:
	//        {
	//            if (m_tpFastForwardButton)
	//            {
	//                IFC(get_IsFastForwardEnabled(&value));
	//                IFC(m_tpFastForwardButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsFastRewindEnabled:
	//        {
	//            if (m_tpFastRewindButton)
	//            {
	//                IFC(get_IsFastRewindEnabled(&value));
	//                IFC(m_tpFastRewindButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSkipForwardEnabled:
	//        {
	//            if (m_tpSkipForwardButton)
	//            {
	//                IFC(get_IsSkipForwardEnabled(&value));
	//                IFC(m_tpSkipForwardButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsSkipBackwardEnabled:
	//        {
	//            if (m_tpSkipBackwardButton)
	//            {
	//                IFC(get_IsSkipBackwardEnabled(&value));
	//                IFC(m_tpSkipBackwardButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsStopEnabled:
	//        {
	//            if (m_tpStopButton)
	//            {
	//                IFC(get_IsStopEnabled(&value));
	//                IFC(m_tpStopButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsRepeatEnabled:
	//        {
	//            if (m_tpRepeatButton)
	//            {
	//                IFC(get_IsRepeatEnabled(&value));
	//                IFC(m_tpRepeatButton.Cast<ToggleButton>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsCompactOverlayEnabled:
	//        {
	//            if (m_tpCompactOverlayButton)
	//            {
	//                IFC(get_IsCompactOverlayEnabled(&value));
	//                IFC(m_tpCompactOverlayButton.Cast<Button>()->put_IsEnabled(value));
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_IsCompact:
	//        {
	//            IFC(m_wrOwnerParent.As(&spOwnerParent))
	//            if (m_transportControlsEnabled && spOwnerParent.Get())
	//            {
	//                IFC(get_IsCompact(&compact));
	//                if (m_isCompact != compact)
	//                {
	//                    m_isCompact = compact;
	//                    IFC(UpdateVisualState());
	//                    IFC(SetMeasureCommandBar());
	//                    IFC(SetTabIndex());
	//                }
	//            }
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_FastPlayFallbackBehaviour:
	//        {
	//            IFC(UpdateTrickModeFallbackUI());
	//            break;
	//        }
	//        case KnownPropertyIndex::MediaTransportControls_ShowAndHideAutomatically:
	//        {
	//            BOOLEAN isAutoShowHide = false;
	//            IFC(get_ShowAndHideAutomatically(&isAutoShowHide));
	//            // If MTC is hides and AutoHide is disabled then show immediately
	//            if (!m_controlPanelIsVisible && !isAutoShowHide)
	//            {
	//                IFC(ShowControlPanel());
	//            }
	//            break;
	//        }
	//    }
	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////       Setup the default values for the MediaControls States
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::SetupDefaultProperties()
	//{
	//    HRESULT hr = S_OK;
	//    IFC(put_IsFullWindowButtonVisible(true));
	//    IFC(put_IsFullWindowEnabled(true));
	//    IFC(put_IsZoomButtonVisible(true));
	//    IFC(put_IsZoomEnabled(true));
	//    IFC(put_IsFastForwardButtonVisible(false));
	//    IFC(put_IsFastForwardEnabled(false));
	//    IFC(put_IsFastRewindButtonVisible(false));
	//    IFC(put_IsFastRewindEnabled(false));
	//    IFC(put_IsStopButtonVisible(false));
	//    IFC(put_IsStopEnabled(false));
	//    IFC(put_IsVolumeButtonVisible(true));
	//    IFC(put_IsVolumeEnabled(true));
	//    IFC(put_IsSeekBarVisible(true));
	//    IFC(put_IsSeekEnabled(true));
	//    IFC(put_IsPlaybackRateButtonVisible(false));
	//    IFC(put_IsPlaybackRateEnabled(false));
	//    IFC(put_IsSkipBackwardButtonVisible(false));
	//    IFC(put_IsSkipBackwardEnabled(false));
	//    IFC(put_IsSkipForwardButtonVisible(false));
	//    IFC(put_IsSkipForwardEnabled(false));
	//    IFC(put_IsPreviousTrackButtonVisible(false));
	//    IFC(put_IsNextTrackButtonVisible(false));
	//    IFC(put_FastPlayFallbackBehaviour(xaml_media::FastPlayFallbackBehaviour::FastPlayFallbackBehaviour_Skip));
	//    IFC(put_ShowAndHideAutomatically(true));
	//    IFC(put_IsRepeatEnabled(false));
	//    IFC(put_IsRepeatButtonVisible(false));
	//    IFC(put_IsCompactOverlayEnabled(false));
	//    IFC(put_IsCompactOverlayButtonVisible(false));

	//Cleanup:
	//    return hr;
	//}

	//// Called when a user selects a track from the CC menu, the old value
	//// needs to be deselected and the new value selected
	//_Check_return_ HRESULT
	//MediaTransportControls::OnCCTrackClicked(
	//                _In_ IInspectable* pSender,
	//                _In_ xaml::IRoutedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wfc::IVector<xaml_controls::MenuFlyoutItemBase*>> spMenuFlyoutItems;
	//    ctl::ComPtr<xaml_controls::IMenuFlyoutItemBase> spItem;
	//    UINT selectedTrackIndex = 0;
	//    BOOLEAN isFound = FALSE;
	//    MTCTelemetryData data;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(m_tpAvailableCCTracksMenuFlyout->get_Items(&spMenuFlyoutItems));

	//        // Determine index of currently selected CC track
	//        IFC(ctl::do_query_interface(spItem, pSender));
	//        IFC(spMenuFlyoutItems->IndexOf(spItem.Get(), &selectedTrackIndex, &isFound));
	//        if (isFound)
	//        {
	//            // Apply user's track selection
	//            if (MTCParent_MediaElement == m_parentType)
	//            {
	//                IFC(SetCCTrackFromME(selectedTrackIndex));
	//            }
	//            else if (MTCParent_MediaPlayerElement == m_parentType)
	//            {
	//                IFC(SetCCTrackFromMPE(selectedTrackIndex));
	//            }
	//        }
	//    }

	//Cleanup:
	//    data.errCode = hr;
	//    data.trackId = m_currentTrack;
	//    m_AggTelemetry.AddData(MTCTelemetryType::CCTrackClick, data);
	//    return hr;
	//}

	//// Called when a user selects a play rate from menu, the old value
	//// needs to be deselected and the new value selected
	//_Check_return_ HRESULT
	//MediaTransportControls::OnPlaybackRateMenuClicked(
	//            _In_ IInspectable* pSender,
	//            _In_ xaml::IRoutedEventArgs* pArgs)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wfc::IVector<xaml_controls::MenuFlyoutItemBase*>> spMenuFlyoutItems;
	//    ctl::ComPtr<xaml_controls::IMenuFlyoutItemBase> spItem;
	//    UINT selectedPlaybackRateIndex = 0;
	//    BOOLEAN isFound = FALSE;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(m_tpAvailablePlaybackRateMenuFlyout->get_Items(&spMenuFlyoutItems));

	//        // Determine index of currently selected CC track
	//        IFC(ctl::do_query_interface(spItem, pSender));
	//        IFC(spMenuFlyoutItems->IndexOf(spItem.Get(), &selectedPlaybackRateIndex, &isFound));
	//        if (isFound)
	//        {
	//            double playbackRate = -1;
	//            ASSERT(selectedPlaybackRateIndex < m_currentPlaybackRates.size());
	//            playbackRate = m_currentPlaybackRates[selectedPlaybackRateIndex];
	//            IFC(SetPlaybackRate(playbackRate, false));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Called when fast forward button is clicked
	//_Check_return_ HRESULT
	//MediaTransportControls::OnFastForwardButtonClicked()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled)
	//    {
	//        if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(TrickModeForward());
	//        }
	//        else
	//        {
	//            IFC(SkipForward());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Called when rewind button is clicked
	//_Check_return_ HRESULT
	//MediaTransportControls::OnFastRewindButtonClicked()
	//{
	//    HRESULT hr = S_OK;
	//    if (m_transportControlsEnabled)
	//    {
	//        if (MTCParent_MediaPlayerElement == m_parentType)
	//        {
	//            IFC(TrickModeBackward());
	//        }
	//        else
	//        {
	//            IFC(SkipBackward());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SkipForward()
	//{
	//    HRESULT hr = S_OK;
	//    wf::TimeSpan currentMediaPosition;
	//    wf::TimeSpan newMediaPosition;
	//    INT64 hnsToEnd = 0;
	//    INT64 FFTimeInHNS = static_cast<INT64>(SkipForwardInSecs)* static_cast<INT64>(HNSPerSecond);

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (!IsLiveContent())
	//        {
	//            IFC(GetPosition(&currentMediaPosition));
	//            hnsToEnd = m_naturalDuration.TimeSpan.Duration - currentMediaPosition.Duration;

	//            // Seek +FFandRWTimeInSecs if position > FFandRWTimeInSecs away from the end, to the end otherwise
	//            newMediaPosition.Duration = (hnsToEnd > FFTimeInHNS) ? currentMediaPosition.Duration + FFTimeInHNS : m_naturalDuration.TimeSpan.Duration;
	//            IFC(SetPosition(newMediaPosition, false));

	//        }
	//    }

	//Cleanup:
	//    return hr;

	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SkipBackward()
	//{
	//    HRESULT hr = S_OK;
	//    wf::TimeSpan currentMediaPosition;
	//    wf::TimeSpan newMediaPosition;
	//    INT64 RWTimeInHNS = static_cast<INT64>(SkipBackwardInSecs) * static_cast<INT64>(HNSPerSecond);

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (!IsLiveContent())
	//        {
	//            IFC(GetPosition(&currentMediaPosition));

	//            // Seek -FFandRWTimeInSecs if position > FFandRWTimeInSecs, to 0s otherwise
	//            newMediaPosition.Duration = (currentMediaPosition.Duration > RWTimeInHNS) ? currentMediaPosition.Duration - RWTimeInHNS : 0;
	//            IFC(SetPosition(newMediaPosition, false));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Called when stop button is clicked
	//_Check_return_ HRESULT
	//MediaTransportControls::OnStopButtonClicked()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        IFC(Stop());
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetMeasureCommandBar()
	//{
	//    // We need to complete the event call and then let the Measure happen after that.
	//    // This will ensure that no peers are referenced while Measuring.
	//    IFC_RETURN(GetXamlDispatcherNoRef()->RunAsync(MakeCallback(
	//        ctl::ComPtr<MediaTransportControls>(this), &MediaTransportControls::MeasureCommandBar)));
	//    return S_OK;
	//}


	//// Measure CommandBar to fit the buttons in given width.
	//_Check_return_ HRESULT
	//MediaTransportControls::MeasureCommandBar()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_tpCommandBar)
	//    {
	//        wf::Size desiredSize;
	//        double availableSize;
	//        const wf::Size infiniteBounds = { std::numeric_limits<float>::infinity(), std::numeric_limits<float>::infinity() };

	//        IFC(ResetMargins());
	//        IFC(get_ActualWidth(&availableSize));
	//        IFC(m_tpCommandBar.Cast<CommandBar>()->Measure(infiniteBounds));
	//        IFC(m_tpCommandBar.Cast<CommandBar>()->get_DesiredSize(&desiredSize));

	//        if (availableSize < desiredSize.Width)
	//        {
	//            IFC(Dropout(availableSize, desiredSize));
	//        }
	//        else
	//        {
	//            IFC(Expand(availableSize, desiredSize));
	//            IFC(AddMarginsBetweenGroups());
	//        }

	//        // Remove this code to disable and hide only after Deliverable 19012797: Fullscreen media works in ApplicationWindow and Win32 XAML Islands is complete
	//        // since Expand or Dropout can make the full window button visible again, this code is used to hide it again
	//        CContentRoot* contentRoot = VisualTree::GetContentRootForElement(GetHandle());
	//        if( contentRoot->GetType() == CContentRoot::Type::XamlIsland )
	//        {
	//            IFC(m_tpFullWindowButton.Cast<ButtonBase>()->put_Visibility(xaml::Visibility_Collapsed));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Implement the logic to drop out the command bar based on the Lowest Visible Order, so that lowest should go first
	//_Check_return_ HRESULT MediaTransportControls::Dropout(
	//                                _In_ double availableSize,
	//                                _In_ wf::Size expectSize)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MediaTransportControlsHelperFactory> spFactory;
	//    ctl::ComPtr<wfc::IObservableVector<ICommandBarElement*>> spPrimaryCommandObsVec;
	//    ctl::ComPtr<wfc::IVector<ICommandBarElement*>> spPrimaryButtons;
	//    unsigned int count = 0;

	//    xaml::Visibility visibility = xaml::Visibility_Collapsed;
	//    wf::Size desiredSize = expectSize;
	//    const wf::Size infiniteBounds = { std::numeric_limits<float>::infinity(), std::numeric_limits<float>::infinity() };

	//    IFC(ctl::make<MediaTransportControlsHelperFactory>(&spFactory));
	//    IFC(m_tpCommandBar.Cast<CommandBar>()->get_PrimaryCommands(&spPrimaryCommandObsVec));
	//    IFCPTR(spPrimaryCommandObsVec);
	//    IFC(spPrimaryCommandObsVec.As(&spPrimaryButtons));
	//    IFC(spPrimaryButtons->get_Size(&count));

	//    while (availableSize < desiredSize.Width)
	//    {
	//        int lowestVisibleOrder = INT_MAX;
	//        int lowestElementIndex = 0;

	//        for (unsigned int i = 0; i < count; i++)
	//        {
	//            ctl::ComPtr<ICommandBarElement> spCommandElement;

	//            IFC(spPrimaryButtons->GetAt(i, &spCommandElement));
	//            if (spCommandElement)
	//            {
	//                ctl::ComPtr<IUIElement> spElement;
	//                IFC(spCommandElement.As(&spElement));
	//                IFC(spElement->get_Visibility(&visibility));
	//                if (visibility == xaml::Visibility::Visibility_Visible)
	//                {
	//                    ctl::ComPtr<wf::IReference<int>> spOrder;
	//                    int order = 0;
	//                    IFC(spFactory->GetDropoutOrder(spElement.Get(), &spOrder));
	//                    if (spOrder)
	//                    {
	//                        IFC(spOrder->get_Value(&order));
	//                    }
	//                    if (lowestVisibleOrder > order && order > 0)
	//                    {
	//                        lowestVisibleOrder = order;
	//                        lowestElementIndex = i;
	//                    }
	//                }
	//            }
	//        }
	//        if (lowestVisibleOrder == INT_MAX)
	//        {
	//            break;
	//        }
	//        else
	//        {
	//            ctl::ComPtr<ICommandBarElement> spCommandElement;
	//            ctl::ComPtr<IUIElement> spElement;

	//            IFC(spPrimaryButtons->GetAt(lowestElementIndex, &spCommandElement));
	//            IFC(spCommandElement.As(&spElement));
	//            IFC(spElement->put_Visibility(xaml::Visibility::Visibility_Collapsed));
	//            IFC(m_tpCommandBar.Cast<CommandBar>()->Measure(infiniteBounds));
	//            IFC(m_tpCommandBar.Cast<CommandBar>()->get_DesiredSize(&desiredSize));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Implement the logic to Expand/Show buttons out of the command bar based on the High Collapse Order ,so that higest should retain.
	//_Check_return_ HRESULT MediaTransportControls::Expand(
	//                _In_ double availableSize,
	//                _In_ wf::Size expectSize)
	//{
	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<MediaTransportControlsHelperFactory> spFactory;
	//    ctl::ComPtr<wfc::IObservableVector<ICommandBarElement*>> spPrimaryCommandObsVec;
	//    ctl::ComPtr<wfc::IVector<ICommandBarElement*>> spPrimaryButtons;
	//    unsigned int count = 0;
	//    wf::Size desiredSize = expectSize;

	//    IFC(ctl::make<MediaTransportControlsHelperFactory>(&spFactory));
	//    IFC(m_tpCommandBar.Cast<CommandBar>()->get_PrimaryCommands(&spPrimaryCommandObsVec))
	//    IFCPTR(spPrimaryCommandObsVec);
	//    IFC(spPrimaryCommandObsVec.As(&spPrimaryButtons));
	//    IFC(spPrimaryButtons->get_Size(&count));

	//    while (availableSize > desiredSize.Width)
	//    {
	//        int highestCollapseOrder = -1;
	//        int highestElementIndex = 0;

	//        for (unsigned int i = 0; i < count; i++)
	//        {
	//            ctl::ComPtr<ICommandBarElement> spCommandElement;
	//            xaml::Visibility visibility = xaml::Visibility_Collapsed;

	//            IFC(spPrimaryButtons->GetAt(i, &spCommandElement));
	//            if (spCommandElement)
	//            {
	//                ctl::ComPtr<IUIElement> spElement;
	//                IFC(spCommandElement.As(&spElement));
	//                IFC(spElement->get_Visibility(&visibility));
	//                if (visibility == xaml::Visibility::Visibility_Collapsed && !IsButtonCollapsedbySystem(spElement.Get()))
	//                {
	//                    ctl::ComPtr<wf::IReference<int>> spOrder;
	//                    int order = 0;
	//                    IFC(spFactory->GetDropoutOrder(spElement.Get(), &spOrder));
	//                    if (spOrder)
	//                    {
	//                        IFC(spOrder->get_Value(&order));
	//                    }
	//                    if (order > highestCollapseOrder)
	//                    {
	//                        highestCollapseOrder = order;
	//                        highestElementIndex = i;
	//                    }
	//                }
	//            }
	//        }

	//        if (highestCollapseOrder == -1)
	//        {
	//            break;
	//        }
	//        else
	//        {
	//            ctl::ComPtr<ICommandBarElement> spCommandElement;
	//            ctl::ComPtr<IUIElement> spElement;
	//            double width;
	//            const wf::Size infiniteBounds = { std::numeric_limits<float>::infinity(), std::numeric_limits<float>::infinity() };

	//            IFC(spPrimaryButtons->GetAt(highestElementIndex, &spCommandElement));
	//            IFC(spCommandElement.As(&spElement));
	//            IFC(spElement.Cast<FrameworkElement>()->get_Width(&width));
	//            // Make sure it should be complete space but not partial space to fit the button
	//            if(availableSize >= (desiredSize.Width + width))
	//            {
	//                IFC(spElement->put_Visibility(xaml::Visibility::Visibility_Visible));
	//                IFC(m_tpCommandBar.Cast<CommandBar>()->Measure(infiniteBounds));
	//                IFC(m_tpCommandBar.Cast<CommandBar>()->get_DesiredSize(&desiredSize));
	//            }
	//            else
	//            {
	//                break;
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;

	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::AddMarginsBetweenGroups()
	//{
	//    BOOLEAN compact = FALSE;
	//    HRESULT hr = S_OK;

	//    get_IsCompact(&compact);
	//    if ((m_tpLeftAppBarSeparator || m_tpRightAppBarSeparator) && !compact)
	//    {
	//        ctl::ComPtr<wfc::IObservableVector<ICommandBarElement*>> spPrimaryCommandObsVec;
	//        ctl::ComPtr<wfc::IVector<ICommandBarElement*>> spPrimaryButtons;
	//        unsigned int count = 0;
	//        double totalWidth = 0;
	//        double leftWidth = 0;
	//        double middleWidth = 0;
	//        double rightWidth = 0;
	//        BOOL leftComplete = FALSE;
	//        BOOL rightStart = FALSE;

	//        IFC(get_ActualWidth(&totalWidth))
	//        IFC(m_tpCommandBar.Cast<CommandBar>()->get_PrimaryCommands(&spPrimaryCommandObsVec))
	//        IFCPTR(spPrimaryCommandObsVec);
	//        IFC(spPrimaryCommandObsVec.As(&spPrimaryButtons));
	//        IFC(spPrimaryButtons->get_Size(&count));

	//        for (unsigned int i = 0; i < count; i++)
	//        {
	//            ctl::ComPtr<ICommandBarElement> spCommandElement;
	//            xaml::Visibility visibility = xaml::Visibility_Collapsed;

	//            IFC(spPrimaryButtons->GetAt(i, &spCommandElement));
	//            if (spCommandElement)
	//            {
	//                ctl::ComPtr<IUIElement> spElement;
	//                IFC(spCommandElement.As(&spElement));
	//                IFC(spElement->get_Visibility(&visibility));
	//                if (visibility == xaml::Visibility::Visibility_Visible)
	//                {
	//                    if (spElement.Get() == m_tpLeftAppBarSeparator.AsOrNull<IUIElement>().Get())
	//                    {
	//                        leftComplete = TRUE;
	//                        continue;
	//                    }
	//                    if (spElement.Get() == m_tpRightAppBarSeparator.AsOrNull<IUIElement>().Get())
	//                    {
	//                        rightStart = TRUE;
	//                        continue;
	//                    }

	//                    ctl::ComPtr<IFrameworkElement> spFrmElement;
	//                    double width;
	//                    IFC(spElement.As(&spFrmElement));
	//                    IFC(spFrmElement->get_Width(&width));

	//                    if (!leftComplete)
	//                    {
	//                        leftWidth = leftWidth + width;
	//                    }
	//                    else if (!rightStart)
	//                    {
	//                        middleWidth = middleWidth + width;
	//                    }
	//                    else
	//                    {
	//                        rightWidth = rightWidth + width;
	//                    }
	//                }
	//            }
	//        }

	//        xaml::Thickness cmdMargin = { 0, 0, 0, 0 };
	//        // Consider control panel margin for xbox case
	//        if (m_tpControlPanelGrid)
	//        {
	//            m_tpControlPanelGrid.Cast<Grid>()->get_Margin(&cmdMargin);
	//        }

	//        double leftGap = (totalWidth / 2) - (cmdMargin.Left + leftWidth + (middleWidth / 2));
	//        double rightGap = (totalWidth / 2) - (cmdMargin.Right + rightWidth + (middleWidth / 2));
	//        // If we get negative value, means they are not in equal balance
	//        if (leftGap < 0 || rightGap < 0)
	//        {
	//            leftGap = rightGap = (totalWidth - (leftWidth + middleWidth + rightWidth)) / 2;
	//        }

	//        if (m_tpLeftAppBarSeparator)
	//        {
	//            xaml::Thickness extraMargin = { leftGap / 2, 0, leftGap / 2, 0 };
	//            IFC(m_tpLeftAppBarSeparator.Cast<AppBarSeparator>()->put_Margin(extraMargin));
	//        }
	//        if (m_tpRightAppBarSeparator)
	//        {
	//            xaml::Thickness extraMargin = { rightGap / 2, 0, rightGap / 2, 0 };
	//            IFC(m_tpRightAppBarSeparator.Cast<AppBarSeparator>()->put_Margin(extraMargin));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::ResetMargins()
	//{
	//    HRESULT hr = S_OK;
	//    xaml::Thickness zeroMargin = { 0, 0, 0, 0 };

	//    if (m_tpLeftAppBarSeparator)
	//    {
	//       IFC(m_tpLeftAppBarSeparator.Cast<AppBarSeparator>()->put_Margin(zeroMargin));
	//    }
	//    if (m_tpRightAppBarSeparator)
	//    {
	//       IFC(m_tpRightAppBarSeparator.Cast<AppBarSeparator>()->put_Margin(zeroMargin));
	//    }

	//Cleanup:
	//    return hr;
	//}

	//// Determine whether button collapsed by system.
	//BOOLEAN MediaTransportControls::IsButtonCollapsedbySystem(_In_ IUIElement* element)
	//{
	//    BOOLEAN value;

	//    //In case of Compact mode this button should collapse
	//    if (element == m_tpPlayPauseButton.AsOrNull<IUIElement>().Get() && m_isCompact)
	//    {
	//        return TRUE;
	//    }
	//    else
	//    //In case of the Missing Audio tracks this button should collapse
	//    if (element == m_tpTHAudioTrackSelectionButton.AsOrNull<IUIElement>().Get() && !m_hasMultipleAudioStreams)
	//    {
	//        return TRUE;
	//    }
	//    else
	//    //In case of the Missing CC tracks this button should collapse
	//    if (element == m_tpCCSelectionButton.AsOrNull<IUIElement>().Get() && !m_hasCCTracks)
	//    {
	//        return TRUE;
	//    }
	//    else //Remaining check whether thru APIs Button is collapsed.
	//    if (element == m_tpPlaybackRateButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsPlaybackRateButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpTHVolumeButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsVolumeButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpFullWindowButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsFullWindowButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpZoomButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsZoomButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpFastForwardButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsFastForwardButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpFastRewindButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsFastRewindButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpStopButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsStopButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    // In case of the Cast doesn't supports this button should always collapse
	//    if (element == m_tpCastButton.AsOrNull<IUIElement>().Get() && !m_isCastSupports)
	//    {
	//        return TRUE;
	//    }
	//    else
	//    if (element == m_tpSkipForwardButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsSkipForwardButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpSkipBackwardButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsSkipBackwardButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpNextTrackButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsNextTrackButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpPreviousTrackButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsPreviousTrackButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpRepeatButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsRepeatButtonVisible(&value);
	//        return !value;
	//    }
	//    else
	//    if (element == m_tpCompactOverlayButton.AsOrNull<IUIElement>().Get())
	//    {
	//        get_IsCompactOverlayButtonVisible(&value);
	//        return !value;
	//    }
	//    return FALSE;
	//}

	//// Called when cast button is clicked
	//_Check_return_ HRESULT
	//MediaTransportControls::OnCastButtonClicked()
	//{
	//    HRESULT hr = S_OK;
	//    MTCTelemetryData data;

	//    if (m_wrOwnerParent.Get() && m_tpCastButton)
	//    {
	//        ctl::ComPtr<wm::Casting::ICastingDevicePicker> spCastingDevicePicker;
	//        wf::Point targetPoint{};
	//        wf::Rect rectSelection;
	//        ctl::ComPtr<xaml_media::IGeneralTransform> spTransformToRoot;
	//        double buttonWidth = 0;
	//        double buttonHeight = 0;

	//        // Convert the target point from the target element to the root
	//        IFC(m_tpCastButton.Cast<Button>()->TransformToVisual(nullptr, &spTransformToRoot));
	//        IFC(spTransformToRoot->TransformPoint(targetPoint, &targetPoint));
	//        IFC(m_tpCastButton.Cast<Button>()->get_ActualHeight(&buttonHeight));
	//        IFC(m_tpCastButton.Cast<Button>()->get_ActualWidth(&buttonWidth));
	//        rectSelection.X = targetPoint.X;
	//        rectSelection.Y = targetPoint.Y;
	//        rectSelection.Width = static_cast<float>(buttonWidth);
	//        rectSelection.Height = static_cast<float>(buttonHeight);
	//        // get the cached Device Picker
	//        IFC(GetCastingDevicePicker(spCastingDevicePicker));
	//        if (spCastingDevicePicker)
	//        {
	//            // Before Showing the Device Picker, make sure pause video if playing
	//            if (m_isPlaying)
	//            {
	//                IFC(Pause(true));
	//                m_isPausedForCastingSelection = TRUE;
	//            }
	//            // Show the Device Picker above the Cast Button
	//            IFC(spCastingDevicePicker->ShowWithPlacement(rectSelection, wup::Placement::Placement_Above));
	//        }
	//    }

	//Cleanup:
	//    if (FAILED(hr))
	//    {
	//        ResetPlayBackAfterCasting();
	//    }
	//    data.errCode = hr;
	//    m_AggTelemetry.AddData(MTCTelemetryType::CastButtonClick, data);
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetCastingDevicePicker(_Out_ ctl::ComPtr<wm::Casting::ICastingDevicePicker>& spCastingDevicePicker)
	//{
	//    HRESULT hr = S_OK;

	//    if (!m_spCastingDevicePicker)
	//    {
	//        ctl::ComPtr<wm::Casting::ICastingDevicePickerFilter> spCastingDevicePickerFilter;
	//        ctl::ComPtr<wm::Casting::ICastingSource> spCastingSource;
	//        ctl::ComPtr<wfc::IVector<wm::Casting::CastingSource*>> supportedCastingSources;
	//        Window *pWindow = nullptr;
	//        if (m_wrOwnerParent.Get())
	//        {
	//            IFC(wf::ActivateInstance(wrl_wrappers::HStringReference(RuntimeClass_Windows_Media_Casting_CastingDevicePicker).Get(),
	//                    m_spCastingDevicePicker.ReleaseAndGetAddressOf()));
	//            // Get the HWND of the app's core window if corewindow available
	//            pWindow = DXamlCore::GetCurrent()->GetWindow();
	//            if (pWindow)
	//            {
	//                ctl::ComPtr<wuc::ICoreWindow> spCoreWindow;
	//                ctl::ComPtr<ICoreWindowInterop> spCoreWindowInterop;
	//                ctl::ComPtr<IInitializeWithWindow> spInitialize;
	//                HWND hwndCoreWindow = nullptr;

	//                IFC(pWindow->get_CoreWindowImpl(&spCoreWindow));
	//                IFC(ctl::do_query_interface(spCoreWindowInterop, spCoreWindow.Get()));
	//                IFC(spCoreWindowInterop->get_WindowHandle(&hwndCoreWindow));
	//                // We need to set the HWND on the picker by QI'ing it for IInitializeWithWindow.
	//                // The reason is that the picker will eventually be modal to that window
	//                IFC(m_spCastingDevicePicker.As(&spInitialize));
	//                IFC(spInitialize->Initialize(hwndCoreWindow));
	//            }
	//            // Set the MediaElement Casting Source in the Supported List.
	//            IFC(GetAsCastingSource(&spCastingSource));
	//            IFC(m_spCastingDevicePicker->get_Filter(&spCastingDevicePickerFilter));
	//            if (spCastingDevicePickerFilter)
	//            {
	//                IFC(spCastingDevicePickerFilter->get_SupportedCastingSources(&supportedCastingSources));
	//                IFC(supportedCastingSources->Append(spCastingSource.Get()));
	//            }

	//            IFC(m_spCastingDevicePicker->add_CastingDeviceSelected(
	//                wrl::Callback<wf::ITypedEventHandler<wm::Casting::CastingDevicePicker*, wm::Casting::CastingDeviceSelectedEventArgs*>>(
	//                [this](wm::Casting::ICastingDevicePicker *pCastingDevicePicker, wm::Casting::ICastingDeviceSelectedEventArgs *pArgs) -> HRESULT
	//            {
	//                HRESULT hr = S_OK;
	//                ctl::ComPtr<wm::Casting::ICastingDevice> spCastingDevice;
	//                ctl::ComPtr<wm::Casting::ICastingConnection> spCastingConnection;
	//                ctl::ComPtr<wm::Casting::ICastingSource> spCastingSource;
	//                ctl::ComPtr<wf::IAsyncOperation<wm::Casting::CastingConnectionErrorStatus>> spAsyncOperation;
	//                IFCPTR(pCastingDevicePicker);
	//                IFCPTR(pArgs);
	//                if (m_wrOwnerParent.Get())
	//                {
	//                    IFC(GetAsCastingSource(&spCastingSource));
	//                    IFC(pArgs->get_SelectedCastingDevice(&spCastingDevice));
	//                    if (spCastingDevice)
	//                    {
	//                        IFC(spCastingDevice->CreateCastingConnection(&spCastingConnection));
	//                        if (spCastingConnection)
	//                        {
	//                            IFC(spCastingConnection->RequestStartCastingAsync(spCastingSource.Get(), &spAsyncOperation));
	//                            // Removing previous Connection State change event
	//                            if (m_spCastingConnection && m_castingConnectStateChangeToken.value != 0)
	//                            {
	//                                IFC(m_spCastingConnection->remove_StateChanged(m_castingConnectStateChangeToken));
	//                                m_castingConnectStateChangeToken.value = 0;
	//                            }

	//                            ctl::ComPtr<MediaTransportControls> spThis(this);
	//                            IFC(spCastingConnection->add_StateChanged(
	//                                wrl::Callback<wf::ITypedEventHandler<wm::Casting::CastingConnection*, IInspectable*>>(
	//                                [this, spThis](wm::Casting::ICastingConnection *pCastingConnection, IInspectable *pArgs) -> HRESULT
	//                            {
	//                                HRESULT hr = S_OK;
	//                                wm::Casting::CastingConnectionState state;
	//                                if (pCastingConnection)
	//                                {
	//                                    IFC(pCastingConnection->get_State(&state));
	//                                    if (state == wm::Casting::CastingConnectionState_Connected || state == wm::Casting::CastingConnectionState_Rendering)
	//                                    {
	//                                        IFC(GetXamlDispatcherNoRef()->RunAsync(MakeCallback(
	//                                            this, &MediaTransportControls::ResetPlayBackAfterCasting)));
	//                                        // Hide the picker after successfully connected.
	//                                        if (m_spCastingDevicePicker)
	//                                        {
	//                                            IFC(m_spCastingDevicePicker->Hide());
	//                                        }

	//                                        // Now that we've hidden the picker, unregister for state changes.  Showing the picker triggers state changes to
	//                                        // be fired (so the picker can update all it's device states), so we don't want that to trigger the picker to be hidden
	//                                        // if it is shown again later.
	//                                        if (m_castingConnectStateChangeToken.value != 0)
	//                                        {
	//                                            IFC(pCastingConnection->remove_StateChanged(m_castingConnectStateChangeToken));
	//                                            m_castingConnectStateChangeToken.value = 0;
	//                                        }
	//                                    }
	//                                }
	//                            Cleanup:
	//                                return hr;

	//                            }).Get(), &m_castingConnectStateChangeToken));

	//                            // Attach will release previous reference(if any) and now refer new connection pointer
	//                            m_spCastingConnection.Attach(spCastingConnection.Detach());

	//                        }
	//                    }
	//                }
	//            Cleanup:
	//                return hr;
	//            }).Get(), &m_castingDeviceSelectedToken));

	//            IFC(m_spCastingDevicePicker->add_CastingDevicePickerDismissed(
	//                wrl::Callback<wf::ITypedEventHandler<wm::Casting::CastingDevicePicker*, IInspectable*>>(
	//                [this](wm::Casting::ICastingDevicePicker *pCastingDevicePicker, IInspectable *pArgs) -> HRESULT
	//            {
	//                HRESULT hr = E_FAIL;
	//                if (m_castingPickerDismissedToken.value != 0)
	//                {
	//                    hr = GetXamlDispatcherNoRef()->RunAsync(MakeCallback(this, &MediaTransportControls::ResetPlayBackAfterCasting));
	//                }
	//                return hr;
	//            }).Get(), &m_castingPickerDismissedToken));
	//        }
	//    }
	//    spCastingDevicePicker = m_spCastingDevicePicker;

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::ResetPlayBackAfterCasting()
	//{
	//    HRESULT hr = S_OK;
	//    // If we pause video before trying to casting, now need to resume

	//    if (m_wrOwnerParent.Get() && m_isPausedForCastingSelection)
	//    {
	//        IFC(Play(true));
	//    }
	//Cleanup:
	//    m_isPausedForCastingSelection = FALSE;
	//    return hr;
	//}

	//// Checks if the Casting API is available on the machine, and if not
	//// sets the cast button visibility to collapsed
	//_Check_return_ HRESULT
	//MediaTransportControls::HideCastButtonIfNecessary()
	//{
	//    if (m_tpCastButton)
	//    {
	//        // We only want to return error if we need to hide the button and fail to do so. Any other
	//        // failures we should ignore so that we don't fail to load the entire MediaTransportControls.
	//        ctl::ComPtr<wm::Casting::ICastingDeviceStatics> spCastingDeviceStatics;
	//        if (SUCCEEDED(GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_Media_Casting_CastingDevice).Get(), &spCastingDeviceStatics)))
	//        {
	//            wrl_wrappers::HString deviceSelector;
	//            if(SUCCEEDED(spCastingDeviceStatics->GetDeviceSelector(
	//                (wm::Casting::CastingPlaybackTypes_Audio | 
	//                wm::Casting::CastingPlaybackTypes_Video | 
	//                wm::Casting::CastingPlaybackTypes_Picture), 
	//                deviceSelector.GetAddressOf())))
	//                {
	//                    if (deviceSelector.IsEmpty())
	//                    {
	//                        IFC_RETURN(m_tpCastButton.Cast<Button>()->put_Visibility(xaml::Visibility_Collapsed));
	//                        m_isCastSupports = FALSE;
	//                    }
	//                }
	//        }
	//    }

	//    return S_OK;
	//}

	//// OnLoaded Handler for CommandBar
	//_Check_return_ HRESULT MediaTransportControls::OnCommandBarLoaded()
	//{
	//    HRESULT hr = S_OK;

	//    IFC(HideMoreButtonIfNecessary());
	//    IFC(HideCastButtonIfNecessary());

	//    // Doens't require this event now.
	//    IFC(DetachHandler(m_epCommandBarLoadedHandler, m_tpCommandBar));
	//    // ReMeasure
	//    IFC(MeasureCommandBar());

	//Cleanup:
	//    return hr;
	//}
	//// Check whether More Button require to visible or collapsed
	//// this will be removed when overflow feature enabled on the commandbar.
	//_Check_return_ HRESULT
	//MediaTransportControls::HideMoreButtonIfNecessary()
	//{
	//    HRESULT hr = S_OK;

	//    if (m_tpCommandBar)
	//    {
	//        ctl::ComPtr<wfc::IObservableVector<ICommandBarElement*>> spSecondaryCommandObsVec;
	//        ctl::ComPtr<wfc::IVector<ICommandBarElement*>> spSecondaryButtons;
	//        unsigned int count = 0;

	//        IFC(m_tpCommandBar.Cast<CommandBar>()->get_SecondaryCommands(&spSecondaryCommandObsVec));
	//        IFCPTR(spSecondaryCommandObsVec);
	//        IFC(spSecondaryCommandObsVec.As(&spSecondaryButtons));
	//        IFC(spSecondaryButtons->get_Size(&count));
	//        // if there is no secondary buttons exist in the commandbar, hide the expand button.
	//        // Default MTC doesn't have secondary commands unless some re-template MTC, this is case doesn't arise.
	//        if (count == 0)
	//        {
	//            ctl::ComPtr<IUIElement> spMoreButton;
	//            IFC(m_tpCommandBar.Cast<CommandBar>()->GetTemplatePart<IUIElement>(STR_LEN_PAIR(L"MoreButton"),
	//                                                                        spMoreButton.ReleaseAndGetAddressOf()));

	//            if (spMoreButton)
	//            {
	//                IFC(spMoreButton->put_Visibility(xaml::Visibility_Collapsed));
	//            }
	//        }
	//    }
	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnVolumeSliderPointerWheelChanged(
	//                        _In_ IInspectable* pSender,
	//                        _In_ xaml_input::IPointerRoutedEventArgs* pArgs)
	//{

	//    HRESULT hr = S_OK;
	//    ctl::ComPtr<wui::IPointerPoint> spPointerPoint;
	//    ctl::ComPtr<wui::IPointerPointProperties> spPointerProperties;
	//    ctl::ComPtr<IUIElement> spIUIElement;
	//    int mouseWheelDelta = 0;
	//    DOUBLE sliderValue = 0.0;

	//    ASSERT(pArgs);
	//    ASSERT(pSender);

	//    IFC(ctl::do_query_interface(spIUIElement,pSender));
	//    IFC(pArgs->GetCurrentPoint(this, &spPointerPoint));
	//    IFCEXPECT(spPointerPoint);
	//    IFC(spPointerPoint->get_Properties(&spPointerProperties));
	//    IFCEXPECT(spPointerProperties);
	//    IFC(spPointerProperties->get_MouseWheelDelta(&mouseWheelDelta));

	//    IFC(m_tpTHVolumeSlider.Cast<Slider>()->get_Value(&sliderValue));

	//    sliderValue = sliderValue + VolumeSliderWheelScrollStep * (mouseWheelDelta / WHEEL_DELTA);
	//    IFC(m_tpTHVolumeSlider.Cast<Slider>()->put_Value(sliderValue));

	//Cleanup:
	//    return hr;
	//}

	////------------------------------------------------------------------------
	////
	////  Synopsis:
	////      Update to FullScreenMode in the FullWindow Case.
	////
	////------------------------------------------------------------------------
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateFullScreenMode(BOOLEAN isFullWindow)
	//{
	//    HRESULT hr = S_OK;

	//    ctl::ComPtr<wuv::IApplicationView3> spAppView3;
	//    BOOLEAN isfullScreenmode = FALSE;
	//    BOOLEAN result = FALSE;

	//    IFC(GetFullScreenView(&spAppView3));
	//    if (!spAppView3)
	//    {
	//        goto Cleanup;
	//    }

	//    IFC(spAppView3->get_IsFullScreenMode(&isfullScreenmode));

	//    // If in full window, then we make sure switch it to fullscreen.
	//    if (isFullWindow && !isfullScreenmode)
	//    {
	//        IFC(spAppView3->TryEnterFullScreenMode(&result));
	//        if (result)
	//        {
	//            m_isFullScreen = TRUE;
	//            m_isFullScreenPending = TRUE;
	//        }
	//    }
	//    // If in non-full window, then we make sure reset back from fullscreen only atleast once fullscreen scenario started by tapping fullwindows button or launched as fullscreen
	//    if (!isFullWindow && isfullScreenmode && (m_isFullScreenClicked || m_isLaunchedAsFullScreen))
	//    {
	//        IFC(spAppView3->ExitFullScreenMode());
	//        m_isFullScreen = FALSE;
	//        if (m_isFullScreenPending)
	//        {
	//            m_isFullScreenPending = FALSE;
	//        }

	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetFullScreenView(_Outptr_opt_ wuv::IApplicationView3** ppAppView)
	//{
	//    HRESULT hr = S_OK;

	//    *ppAppView = nullptr;

	//    ctl::ComPtr<wuv::IApplicationViewStatics2> spAppViewStatics;
	//    ctl::ComPtr<wuv::IApplicationView> spAppView;
	//    ctl::ComPtr<wuv::IApplicationView3> spAppView3;

	//    IFC(ctl::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_UI_ViewManagement_ApplicationView).Get(), &spAppViewStatics));
	//    if (SUCCEEDED(spAppViewStatics->GetForCurrentView(&spAppView)))
	//    {
	//        IFC(spAppView.As<wuv::IApplicationView3>(&spAppView3));

	//        *ppAppView = spAppView3.Detach();
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetMuted(_Out_ BOOLEAN *value)
	//{
	//    HRESULT hr = S_OK;

	//    *value = FALSE;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_IsMuted(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            IFC(m_spMediaPlayer->get_IsMuted(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetMuted(_In_ BOOLEAN value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_IsMuted(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            IFC(m_spMediaPlayer->put_IsMuted(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetFullWindow(_Out_ BOOLEAN *value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_IsFullWindow(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaPlayerElement> spOwnerMPE;
	//        IFC(m_wrOwnerParent.As(&spOwnerMPE))
	//        if (spOwnerMPE.Get())
	//        {
	//            IFC(spOwnerMPE.Cast<MediaPlayerElement>()->get_IsFullWindow(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//HRESULT MediaTransportControls::SetMediaPlayerElementFullWindow(ctl::ComPtr<xaml_controls::IMediaPlayerElement> spMediaPlayer, BOOLEAN value)
	//{
	//    IFC_RETURN(spMediaPlayer->put_IsFullWindow(value));
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetFullWindow(_In_ BOOLEAN value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_IsFullWindow(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaPlayerElement> spOwnerMPE;
	//        IFC(m_wrOwnerParent.As(&spOwnerMPE))
	//        if (spOwnerMPE.Get())
	//        {
	//            // Changing IsFullWindow will update the parent of our parent (e.g. the LayoutRoot grid)
	//            // We need to complete the event call and then let the reparenting happen after that.
	//            // This will ensure that no peers are referenced while changing the parent.
	//            IFC(GetXamlDispatcherNoRef()->RunAsync(
	//                MakeCallback(
	//                SetMediaPlayerElementFullWindow, spOwnerMPE, value)));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetStretch(_Out_ xaml_media::Stretch *value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_Stretch(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaPlayerElement> spOwnerMPE;
	//        IFC(m_wrOwnerParent.As(&spOwnerMPE))
	//        if (spOwnerMPE.Get())
	//        {
	//            IFC(spOwnerMPE.Cast<MediaPlayerElement>()->get_Stretch(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}
	//_Check_return_ HRESULT
	//MediaTransportControls::SetStretch(_In_ xaml_media::Stretch value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_Stretch(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaPlayerElement> spOwnerMPE;
	//        IFC(m_wrOwnerParent.As(&spOwnerMPE))
	//        if (spOwnerMPE.Get())
	//        {
	//            IFC(spOwnerMPE.Cast<MediaPlayerElement>()->put_Stretch(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetVolume(_Out_ DOUBLE *value)
	//{
	//    HRESULT hr = S_OK;

	//    *value = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_Volume(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            IFC(m_spMediaPlayer->get_Volume(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetVolume(_In_ DOUBLE value)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_Volume(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            IFC(m_spMediaPlayer->put_Volume(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;

	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetPosition(_Out_ wf::TimeSpan *value)
	//{
	//    HRESULT hr = S_OK;

	//    (*value).Duration = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_Position(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//        IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//        if (spPlaybackSession)
	//        {
	//            IFC(spPlaybackSession->get_Position(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}
	//_Check_return_ HRESULT
	//MediaTransportControls::SetPosition(_In_ wf::TimeSpan value, _In_ bool isScrubber)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_Position(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (isScrubber)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//            IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//            if (spPlaybackSession)
	//            {
	//                IFC(spPlaybackSession->put_Position(value));
	//            }
	//        }
	//        else
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer2> spMediaPlayer2;
	//            IFC(GetMediaPlayer2ForPlaybackDataSource(&spMediaPlayer2));
	//            if (spMediaPlayer2)
	//            {
	//                IFC(MediaPlaybackDataSourceExtension_SendPlaybackPositionChangeRequest(spMediaPlayer2.Get(), value.Duration));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetAudioTrackCount(_Out_ INT *value)
	//{
	//    HRESULT hr = S_OK;

	//    *value = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_AudioStreamCount(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlaybackItem> spPlaybackItem;
	//            if (SUCCEEDED(MediaPlayerExtension_GetCurrentMediaPlaybackItem(m_spMediaPlayer.Get(), &spPlaybackItem)) && spPlaybackItem.Get())
	//            {
	//                UINT audioTracks = 0;
	//                ctl::ComPtr<wfc::IVectorView<wmc::AudioTrack*>> spAudioTracks;
	//                spPlaybackItem->get_AudioTracks(&spAudioTracks);
	//                IFC(spAudioTracks->get_Size(&audioTracks));
	//                *value = audioTracks;
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetCCTrackCount(_Out_ UINT *pValue)
	//{
	//    HRESULT hr = S_OK;

	//    *pValue = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get() && m_spCurrentItem)
	//        {
	//            ctl::ComPtr<wfc::IVectorView<wmc::TimedMetadataTrack*>> spTracks;
	//            IFC(m_spCurrentItem->get_TimedMetadataTracks(&spTracks));
	//            IFC(GetSupportedTrackCount(spTracks.Get(), m_spCurrentItem.Get(), pValue));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlaybackItem> spPlaybackItem;
	//            if (SUCCEEDED(MediaPlayerExtension_GetCurrentMediaPlaybackItem(m_spMediaPlayer.Get(), &spPlaybackItem)) && spPlaybackItem.Get())
	//            {
	//                ctl::ComPtr<wfc::IVectorView<wmc::TimedMetadataTrack*>> spTracks;
	//                IFC(spPlaybackItem->get_TimedMetadataTracks(&spTracks));
	//                IFC(GetSupportedTrackCount(spTracks.Get(), spPlaybackItem.Get(), pValue));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetSupportedTrackCount(_In_ wfc::IVectorView<wmc::TimedMetadataTrack*> *pList,
	//        _In_ wmp::IMediaPlaybackItem* pCurrentItem,
	//        _Out_ UINT *pValue)
	//{
	//    ctl::ComPtr<wfc::IVectorView<wmc::TimedMetadataTrack*>> spTracks = pList;
	//    ctl::ComPtr<wmp::IMediaPlaybackItem> spPlaybackItem = pCurrentItem;
	//    unsigned int trackCount = 0;
	//    unsigned int supportedTrackCount = 0;

	//    *pValue = 0;
	//    IFC_RETURN(spTracks->get_Size(&trackCount));

	//    for (unsigned int i = 0; i < trackCount; i++)
	//    {
	//        ctl::ComPtr<wmc::ITimedMetadataTrack> spTrack;
	//        IFC_RETURN(spTracks->GetAt(i, &spTrack));
	//        if (CTimedTextSource::IsSupportedTrack(spTrack.Get(), spPlaybackItem.Get()))
	//        {
	//            supportedTrackCount++;
	//        }
	//    }

	//    *pValue = supportedTrackCount;
	//    return S_OK;
	//}


	//_Check_return_ HRESULT
	//MediaTransportControls::GetDownloadProgress(_Out_ DOUBLE *value)
	//{
	//    HRESULT hr = S_OK;

	//    *value = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_DownloadProgress(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//        IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//        if (spPlaybackSession)
	//        {
	//            IFC(spPlaybackSession->get_DownloadProgress(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetPlaybackRate(_Out_ DOUBLE *value)
	//{
	//    HRESULT hr = S_OK;

	//    *value = 0;
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->get_PlaybackRate(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//        IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//        if (spPlaybackSession)
	//        {
	//            IFC(spPlaybackSession->get_PlaybackRate(value));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetPlaybackRate(_In_ DOUBLE value, _In_ bool isScrubber)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->put_PlaybackRate(value));
	//            IFC(spOwnerME.Cast<MediaElement>()->put_DefaultPlaybackRate(value));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (isScrubber)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//            IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//            if (spPlaybackSession)
	//            {
	//                IFC(spPlaybackSession->put_PlaybackRate(value));
	//            }
	//        }
	//        else
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer2> spMediaPlayer2;
	//            IFC(GetMediaPlayer2ForPlaybackDataSource(&spMediaPlayer2));
	//            if (spMediaPlayer2)
	//            {
	//                IFC(MediaPlaybackDataSourceExtension_SendPlaybackRateChangeRequest(spMediaPlayer2.Get(), value));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::Stop()
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->Stop());
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<wmp::IMediaPlaybackSession> spPlaybackSession;
	//        IFC(GetCurrentPlaybackSession(&spPlaybackSession));
	//        if (spPlaybackSession)
	//        {
	//            wf::TimeSpan zeroPosition = {};
	//            IFC(spPlaybackSession->put_Position(zeroPosition));
	//            IFC(m_spMediaPlayer->Pause());
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::Play(_In_ bool isCast)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->Play());
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        // While in casting, we directly calling MediaPlayer.
	//        // Also in buffer state we directly calling MediaPlayer , STMC might skip Play/Pause commands.
	//        if (isCast|| m_isBuffering)
	//        {
	//            if (m_spMediaPlayer)
	//            {
	//                IFC(m_spMediaPlayer->Play());
	//            }
	//        }
	//        else
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer2> spMediaPlayer2;
	//            IFC(GetMediaPlayer2ForPlaybackDataSource(&spMediaPlayer2));
	//            if (spMediaPlayer2)
	//            {
	//                IFC(MediaPlaybackDataSourceExtension_SendMediaPlaybackCommand(spMediaPlayer2.Get(), MediaPlaybackDataSourceExtension_MediaPlaybackCommands::MediaPlaybackCommand_Play));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::Pause(_In_ bool isCast)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->Pause());
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        // While in casting, we directly calling MediaPlayer.
	//        // Also in buffer state we directly calling MediaPlayer , STMC might skip Play/Pause commands.
	//        if (isCast || m_isBuffering)
	//        {
	//            if (m_spMediaPlayer)
	//            {
	//                IFC(m_spMediaPlayer->Pause());
	//            }
	//        }
	//        else
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer2> spMediaPlayer2;
	//            IFC(GetMediaPlayer2ForPlaybackDataSource(&spMediaPlayer2));
	//            if (spMediaPlayer2)
	//            {
	//                IFC(MediaPlaybackDataSourceExtension_SendMediaPlaybackCommand(spMediaPlayer2.Get(), MediaPlaybackDataSourceExtension_MediaPlaybackCommands::MediaPlaybackCommand_Pause));
	//            }
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetAsCastingSource(_Outptr_opt_ wm::Casting::ICastingSource** returnValue)
	//{
	//    HRESULT hr = S_OK;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<xaml_controls::IMediaElement> spOwnerME;
	//        IFC(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC(spOwnerME.Cast<MediaElement>()->GetAsCastingSource(returnValue));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        if (m_spMediaPlayer)
	//        {
	//            ctl::ComPtr<wmp::IMediaPlayer3> spMediaPlayer3;
	//            IFC(m_spMediaPlayer.As(&spMediaPlayer3));
	//            IFC(spMediaPlayer3->GetAsCastingSource(returnValue));
	//        }
	//    }

	//Cleanup:
	//    return hr;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::GetRepeatMode(_Out_ MediaPlaybackDataSourceExtension_RepeatMode* value)
	//{
	//    *value = MediaPlaybackDataSourceExtension_RepeatMode::None;

	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<MediaElement> spOwnerME;

	//        IFC_RETURN(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            BOOLEAN isLooping;

	//            IFC_RETURN(spOwnerME->get_IsLooping(&isLooping));
	//            if (isLooping)
	//            {
	//                *value = MediaPlaybackDataSourceExtension_RepeatMode::One;
	//            }
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType && m_spMediaPlayer)
	//    {
	//        BOOLEAN isLoopingEnabled;

	//        IFC_RETURN(m_spMediaPlayer->get_IsLoopingEnabled(&isLoopingEnabled));
	//        if (isLoopingEnabled)
	//        {
	//            *value = MediaPlaybackDataSourceExtension_RepeatMode::One;
	//        }
	//        else if (m_spMediaPlaybackList)
	//        {
	//            // When IsLoopingEnabled isn't set, check for AutoRepeatEnabled on the IMediaPlaybackList.
	//            BOOLEAN isAutoRepeatEnabled;

	//            IFC_RETURN(m_spMediaPlaybackList->get_AutoRepeatEnabled(&isAutoRepeatEnabled));
	//            if (isAutoRepeatEnabled)
	//            {
	//                *value = MediaPlaybackDataSourceExtension_RepeatMode::All;
	//            }
	//        }
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetRepeatMode(_In_ MediaPlaybackDataSourceExtension_RepeatMode value)
	//{
	//    if (MTCParent_MediaElement == m_parentType)
	//    {
	//        ctl::ComPtr<MediaElement> spOwnerME;
	//        IFC_RETURN(m_wrOwnerParent.As(&spOwnerME))
	//        if (spOwnerME.Get())
	//        {
	//            IFC_RETURN(spOwnerME->put_IsLooping(value == MediaPlaybackDataSourceExtension_RepeatMode::One));
	//        }
	//    }
	//    else if (MTCParent_MediaPlayerElement == m_parentType)
	//    {
	//        ctl::ComPtr<wmp::IMediaPlayer2> spMediaPlayer2;
	//        IFC_RETURN(GetMediaPlayer2ForPlaybackDataSource(&spMediaPlayer2));
	//        if (spMediaPlayer2)
	//        {
	//            IFC_RETURN(MediaPlaybackDataSourceExtension_SendRepeatModeChangeRequest(spMediaPlayer2.Get(), value));
	//        }
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnCoreWindowKeyDown(
	//    _In_ wuc::IKeyEventArgs* pArgs)
	//{
	//    // Ignore events if MTC is not enabled.
	//    if (m_transportControlsEnabled)
	//    {
	//        if (IsInLiveTree())
	//        {
	//            wsy::VirtualKey key = {};
	//            IFC_RETURN(pArgs->get_VirtualKey(&key));
	//            if (!m_controlPanelIsVisible) // Make sure only when MTC is not showing up on the screen.
	//            {
	//                if (XboxUtility::IsGamepadNavigationDirection(key) || XboxUtility::IsGamepadNavigationAccept(key))
	//                {
	//                    CFocusManager* pFocusManager = VisualTree::GetFocusManagerForElement(this->GetHandle());
	//                    if(pFocusManager && pFocusManager->GetFocusedElementNoRef() == nullptr)
	//                    {
	//                        if (m_tpPlayPauseButton)
	//                        {
	//                            BOOLEAN focused = FALSE;
	//                            IFC_RETURN(m_tpPlayPauseButton.Cast<ButtonBase>()->Focus(xaml::FocusState_Keyboard, &focused));
	//                            ASSERT(focused);
	//                        }
	//                    }
	//                    IFC_RETURN(StopControlPanelHideTimer());
	//                    IFC_RETURN(ShowControlPanel());
	//                    IFC_RETURN(StartControlPanelHideTimer());
	//                }
	//            }
	//        }
	//    }
	//    return S_OK;
	//}

	//IFACEMETHODIMP
	//MediaTransportControls::add_ThumbnailRequested(
	//    _In_ wf::ITypedEventHandler<xaml_controls::MediaTransportControls*, xaml_media::MediaTransportControlsThumbnailRequestedEventArgs*>* pValue,
	//    _Out_ EventRegistrationToken* ptToken)
	//{
	//    IFC_RETURN(MediaTransportControlsGenerated::add_ThumbnailRequested(pValue, ptToken));
	//    if (!m_isThumbnailEnabled)
	//    {
	//        m_isThumbnailEnabled = TRUE;
	//    }

	//    return S_OK;
	//}

	//IFACEMETHODIMP
	//MediaTransportControls::remove_ThumbnailRequested(_In_ EventRegistrationToken tToken)
	//{
	//    ThumbnailRequestedEventSourceType* pEventSource = nullptr;

	//    IFC_RETURN(MediaTransportControlsGenerated::remove_ThumbnailRequested(tToken));
	//    IFC_RETURN(MediaTransportControlsGenerated::GetThumbnailRequestedEventSourceNoRef(&pEventSource));
	//    if (!pEventSource->HasHandlers())
	//    {
	//        m_isThumbnailEnabled = FALSE;
	//    }

	//    return S_OK;
	//}
	//_Check_return_ HRESULT
	//MediaTransportControls::EnableValueChangedEventThrottlingOnSliderAutomation(bool value)
	//{
	//    if (m_tpMediaPositionSlider)
	//    {
	//        ctl::ComPtr<IAutomationPeer> spAutomationPeer;
	//        ctl::ComPtr<IRangeBaseAutomationPeer> spRangeBaseAutomationPeer;
	//        IFC_RETURN(m_tpMediaPositionSlider.Cast<Slider>()->GetOrCreateAutomationPeer(&spAutomationPeer));
	//        IFC_RETURN(spAutomationPeer.As(&spRangeBaseAutomationPeer));
	//        IFC_RETURN(spRangeBaseAutomationPeer.Cast<RangeBaseAutomationPeer>()->EnableValueChangedEventThrottling(value));
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::EnterImpl(
	//    _In_ XBOOL bLive,
	//    _In_ XBOOL bSkipNameRegistration,
	//    _In_ XBOOL bCoercedIsEnabled,
	//    _In_ XBOOL bUseLayoutRounding
	//)
	//{
	//    IFC_RETURN(__super::EnterImpl(bLive, bSkipNameRegistration, bCoercedIsEnabled, bUseLayoutRounding));

	//    if (bLive)
	//    {
	//        IFC_RETURN(SubscribeMediaPlayerEvents());
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::LeaveImpl(
	//    _In_ XBOOL bLive,
	//    _In_ XBOOL bSkipNameRegistration,
	//    _In_ XBOOL bCoercedIsEnabled,
	//    _In_ XBOOL bVisualTreeBeingReset)
	//{
	//    IFC_RETURN(UnSubscribeMediaPlayerEvents());
	//    if (m_isMiniView)
	//    {
	//        IFC_RETURN(SetMiniView(false));
	//    }

	//    IFC_RETURN(__super::LeaveImpl(bLive, bSkipNameRegistration, bCoercedIsEnabled, bVisualTreeBeingReset));
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnBorderSizeChanged()
	//{
	//    if (m_tpControlPanelVisibilityBorder)
	//    {
	//        // Clip the border for restrict animations rendering within Border.
	//        double height = 0;
	//        double width = 0;
	//        ctl::ComPtr<RectangleGeometry> spClipGeometry;
	//        wf::Rect clipRect = {};

	//        IFC_RETURN(m_tpControlPanelVisibilityBorder.Cast<Border>()->get_ActualHeight(&height));
	//        IFC_RETURN(m_tpControlPanelVisibilityBorder.Cast<Border>()->get_ActualWidth(&width));
	//        clipRect.Width = static_cast<float>(width);
	//        clipRect.Height = static_cast<float>(height);
	//        IFC_RETURN(ctl::make<RectangleGeometry>(&spClipGeometry));
	//        IFC_RETURN(spClipGeometry->put_Rect(clipRect));
	//        IFC_RETURN(m_tpControlPanelVisibilityBorder.Cast<Border>()->put_Clip(spClipGeometry.Get()));
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateTimeAutomationProperties()
	//{
	//    wrl_wrappers::HString strAutomationName;
	//    // Update TimeElapsed/TimeRemaining Automate properties with actual values only when video is paused
	//    if (m_tpTimeElapsedElement && !ctl::is<xaml_controls::IContentControl>(m_tpTimeElapsedElement.Get()))
	//    {
	//        IFC_RETURN(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_TIME_ELAPSED, strAutomationName.ReleaseAndGetAddressOf()));
	//        // Make sure source loaded and content is not playing
	//        if (m_sourceLoaded && !m_isPlaying)
	//        {
	//            wrl_wrappers::HString  strTimeElapsedText;
	//            ctl::ComPtr<xaml_controls::ITextBlock> spTimeElapsedTextBlock;
	//            IFC_RETURN(m_tpTimeElapsedElement.As(&spTimeElapsedTextBlock));
	//            IFC_RETURN(spTimeElapsedTextBlock->get_Text(strTimeElapsedText.ReleaseAndGetAddressOf()));
	//            IFC_RETURN(strAutomationName.Concat(strTimeElapsedText, strAutomationName));
	//        }
	//        IFC_RETURN(DirectUI::AutomationProperties::SetNameStatic(m_tpTimeElapsedElement.Cast<FrameworkElement>(), strAutomationName));
	//    }

	//    if (m_tpTimeRemainingElement && !ctl::is<xaml_controls::IContentControl>(m_tpTimeRemainingElement.Get()))
	//    {
	//        IFC_RETURN(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(UIA_MEDIA_TIME_REMAINING, strAutomationName.ReleaseAndGetAddressOf()));
	//        // Make sure source loaded and content is not playing also not live content
	//        if (m_sourceLoaded && !m_isPlaying && !IsLiveContent())
	//        {
	//            wrl_wrappers::HString strTimeRemainingText;
	//            ctl::ComPtr<xaml_controls::ITextBlock> spTimeRemainingTextBlock;
	//            IFC_RETURN(m_tpTimeRemainingElement.As(&spTimeRemainingTextBlock));
	//            IFC_RETURN(spTimeRemainingTextBlock->get_Text(strTimeRemainingText.ReleaseAndGetAddressOf()));
	//            IFC_RETURN(strAutomationName.Concat(strTimeRemainingText, strAutomationName));
	//        }
	//        IFC_RETURN(DirectUI::AutomationProperties::SetNameStatic(m_tpTimeRemainingElement.Cast<FrameworkElement>(), strAutomationName));
	//    }

	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnVisibilityVisualStateChanged(_In_ IVisualStateChangedEventArgs* pEventArgs)
	//{
	//    ctl::ComPtr<IVisualState> spVisualState;
	//    wrl_wrappers::HString strStateName;

	//    IFC_RETURN(pEventArgs->get_NewState(&spVisualState));
	//    if (spVisualState)
	//    {
	//        IFC_RETURN(spVisualState->get_Name(strStateName.GetAddressOf()));
	//        if (strStateName == wrl_wrappers::HStringReference(L"ControlPanelFadeIn"))
	//        {
	//            if (!m_controlPanelIsVisible)
	//            {
	//                // FadeIn Visual State called thru external, we need to call implicity MTC to Show Panel
	//                m_isVSStateChangeExternal = TRUE;
	//                IFC_RETURN(ShowControlPanel());
	//            }
	//        }
	//        else
	//        if (strStateName == wrl_wrappers::HStringReference(L"ControlPanelFadeOut")) 
	//        {
	//            if (m_controlPanelIsVisible)
	//            {
	//                // FadeOut Visual State called thru external, we need to call implicity MTC to Hide Panel
	//                m_isVSStateChangeExternal = TRUE;
	//                IFC_RETURN(HideControlPanel());
	//            }
	//        }
	//    }
	//    return S_OK;
	//}

	////
	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateRepeatButtonUI()
	//{
	//    if (m_transportControlsEnabled  && m_wrOwnerParent.Get())
	//    {
	//        if (m_tpRepeatButton)
	//        {
	//            wrl_wrappers::HString strAutomationName;
	//            MediaPlaybackDataSourceExtension_RepeatMode repeatMode;
	//            IFC_RETURN(GetRepeatMode(&repeatMode));
	//            IFC_RETURN(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(
	//                (repeatMode == MediaPlaybackDataSourceExtension_RepeatMode::One) ?
	//                    UIA_MEDIA_REPEAT_ONE : 
	//                (repeatMode == MediaPlaybackDataSourceExtension_RepeatMode::All) ?
	//                    UIA_MEDIA_REPEAT_ALL : 
	//                    UIA_MEDIA_REPEAT_NONE,
	//                strAutomationName.ReleaseAndGetAddressOf()));
	//            IFC_RETURN(DirectUI::AutomationProperties::SetNameStatic(m_tpRepeatButton.Cast<ToggleButton>(), strAutomationName));
	//            IFC_RETURN(UpdateTooltipText(m_tpRepeatButton.Cast<ToggleButton>(), strAutomationName));
	//            if (MTCParent_MediaPlayerElement == m_parentType)
	//            {
	//                IFC_RETURN(UpdateRepeatButtonUIFromMPE());
	//            }
	//        }
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnRepeatButtonClicked()
	//{
	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        MediaPlaybackDataSourceExtension_RepeatMode repeatMode;
	//        IFC_RETURN(GetRepeatMode(&repeatMode));
	//        if (!m_spMediaPlaybackList) // if no playlist
	//        {
	//            IFC_RETURN(SetRepeatMode(
	//                repeatMode == MediaPlaybackDataSourceExtension_RepeatMode::None ?
	//                    MediaPlaybackDataSourceExtension_RepeatMode::One :
	//                    MediaPlaybackDataSourceExtension_RepeatMode::None));
	//        }
	//        else
	//        {
	//            IFC_RETURN(SetRepeatMode(
	//                repeatMode == MediaPlaybackDataSourceExtension_RepeatMode::None ?
	//                    MediaPlaybackDataSourceExtension_RepeatMode::One :
	//                    (repeatMode == MediaPlaybackDataSourceExtension_RepeatMode::One) ?
	//                        MediaPlaybackDataSourceExtension_RepeatMode::All : MediaPlaybackDataSourceExtension_RepeatMode::None));
	//        }
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetTabIndex()
	//{
	//    ctl::ComPtr<xaml::IUIElement> spUIElement;
	//    if (m_isCompact)
	//    {
	//        int idx = 0;
	//        if (m_tpTHLeftSidePlayPauseButton)
	//        {
	//            IFC_RETURN(m_tpTHLeftSidePlayPauseButton.As(&spUIElement));
	//            IFC_RETURN(spUIElement->put_TabIndex(idx++));
	//        }
	//        if (m_tpMediaPositionSlider)
	//        {
	//            IFC_RETURN(m_tpMediaPositionSlider.As(&spUIElement));
	//            IFC_RETURN(spUIElement->put_TabIndex(idx++));
	//        }
	//        if (m_tpCommandBar)
	//        {
	//            IFC_RETURN(m_tpCommandBar.As(&spUIElement));
	//            IFC_RETURN(spUIElement->put_TabIndex(idx++));
	//        }
	//    }
	//    else
	//    {
	//        if (m_tpCommandBar)
	//        {
	//            IFC_RETURN(m_tpCommandBar.As(&spUIElement));
	//            IFC_RETURN(spUIElement->put_TabIndex(0));
	//        }
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::OnCompactOverlayButtonClicked()
	//{
	//    if (m_transportControlsEnabled && m_wrOwnerParent.Get())
	//    {
	//        if (m_isFullScreen)
	//        {
	//            // In Full Screen Set the MiniView using existing fullwindow
	//            IFC_RETURN(SetMiniView(m_isFullWindow));
	//        }
	//        else
	//        {
	//            m_isMiniViewClicked = TRUE;
	//            IFC_RETURN(SetFullWindow(!m_isFullWindow));
	//        }
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::UpdateMiniViewUI()
	//{
	//    if (m_transportControlsEnabled  && m_wrOwnerParent.Get())
	//    {
	//        BOOLEAN isFullWindow = FALSE;
	//        IFC_RETURN(GetFullWindow(&isFullWindow));
	//        m_isFullWindow = isFullWindow;
	//        IFC_RETURN(SetMiniView(m_isFullWindow));
	//    }
	//    return S_OK;
	//}

	//_Check_return_ HRESULT
	//MediaTransportControls::SetMiniView(_In_ bool bIsEnable)
	//{
	//    ctl::ComPtr<wf::IAsyncOperation<bool>> spAsyncOperation;
	//    ctl::ComPtr<wuv::IApplicationView4> spAppView4;
	//    wrl_wrappers::HString strAutomationName;

	//    IFC_RETURN(GetMiniView(&spAppView4));
	//    if (spAppView4)
	//    {
	//        if (bIsEnable)
	//        {
	//            if (!m_isMiniView) // Enter MiniView
	//            {
	//                if (m_lastKnownMiniViewWidth > 0 && m_lastKnownMiniViewHeight > 0) //use the last known height/width for Mini View
	//                {
	//                    ctl::ComPtr<wuv::IViewModePreferences> viewModePreference;
	//                    ctl::ComPtr<wuv::IViewModePreferencesStatics> viewModePreferencesStatics;
	//                    wf::Size preferredSize = { static_cast<float>(m_lastKnownMiniViewWidth), static_cast<float>(m_lastKnownMiniViewHeight) };
	//                    IFC_RETURN(ctl::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_UI_ViewManagement_ViewModePreferences).Get(),
	//                        &viewModePreferencesStatics));
	//                    IFC_RETURN(viewModePreferencesStatics->CreateDefault(wuv::ApplicationViewMode::ApplicationViewMode_CompactOverlay, &viewModePreference));
	//                    IFC_RETURN(viewModePreference->put_ViewSizePreference(wuv::ViewSizePreference::ViewSizePreference_Custom));
	//                    IFC_RETURN(viewModePreference->put_CustomSize(preferredSize));
	//                    IFC_RETURN(spAppView4->TryEnterViewModeWithPreferencesAsync(wuv::ApplicationViewMode::ApplicationViewMode_CompactOverlay,
	//                        viewModePreference.Get(), &spAsyncOperation));
	//                }
	//                else
	//                {
	//                    IFC_RETURN(spAppView4->TryEnterViewModeAsync(wuv::ApplicationViewMode::ApplicationViewMode_CompactOverlay, &spAsyncOperation));
	//                }
	//                m_isMiniView = TRUE;
	//            }

	//        }
	//        else // Exit MiniView
	//        {
	//            wf::Rect layoutBounds = {};
	//            IFC_RETURN(DXamlCore::GetCurrent()->GetContentLayoutBoundsForElement(GetHandle(), &layoutBounds));
	//            // Retain Last known MiniView Width/Height before exit the MiniView.
	//            m_lastKnownMiniViewWidth = layoutBounds.Width;
	//            m_lastKnownMiniViewHeight = layoutBounds.Height;

	//            if (m_isMiniView)
	//            {
	//                IFC_RETURN(spAppView4->TryEnterViewModeAsync(wuv::ApplicationViewMode::ApplicationViewMode_Default, &spAsyncOperation));
	//                m_isMiniView = FALSE;
	//            }
	//        }

	//        if (m_tpCompactOverlayButton)
	//        {
	//            IFC_RETURN(DXamlCore::GetCurrentNoCreate()->GetLocalizedResourceString(m_isMiniView ? UIA_MEDIA_EXIT_MINIVIEW : UIA_MEDIA_MINIVIEW, strAutomationName.ReleaseAndGetAddressOf()));
	//            IFC_RETURN(DirectUI::AutomationProperties::SetNameStatic(m_tpCompactOverlayButton.Cast<Button>(), strAutomationName));
	//            IFC_RETURN(AddTooltip(m_tpCompactOverlayButton.Cast<Button>(), strAutomationName));
	//        }
	//    }
	//    return S_OK;
	//}


	//_Check_return_ HRESULT
	//MediaTransportControls::GetMiniView(_Outptr_opt_ wuv::IApplicationView4** ppAppView)
	//{
	//    HRESULT hr = S_OK;
	//    *ppAppView = nullptr;

	//    ctl::ComPtr<wuv::IApplicationViewStatics2> spAppViewStatics;
	//    ctl::ComPtr<wuv::IApplicationView> spAppView;
	//    ctl::ComPtr<wuv::IApplicationView4> spAppView4;

	//    IFC_RETURN(ctl::GetActivationFactory(wrl_wrappers::HStringReference(RuntimeClass_Windows_UI_ViewManagement_ApplicationView).Get(), &spAppViewStatics));
	//    if (SUCCEEDED(spAppViewStatics->GetForCurrentView(&spAppView)))
	//    {
	//        IFC_RETURN(spAppView.As<wuv::IApplicationView4>(&spAppView4));
	//        *ppAppView = spAppView4.Detach();
	//    }

	//    return S_OK;
	//}
}
