﻿#nullable enable
// <autogenerated />
using System;
using System.Collections.Generic;
using System.Threading;

#pragma warning disable // Disable all warnings for this generated file

// Register an embedded sources provider for Hot Reload
[assembly: global::System.Reflection.AssemblyMetadata("Uno.HotDesign.HotReloadEmbeddedXamlSourceFilesProvider", "global::MyProject.__Sources__.EmbeddedXamlSourcesProvider")]

namespace MyProject.__Sources__;

/// <summary>
/// Provides access to the embedded XAML sources
/// </summary>
/// <remarks>
/// This class is used to provide the embedded XAML sources to the Hot Reload engine.
/// This is not intended to be used directly by application code.
/// WON'T BE GENERATED ON RELEASE BUILDS
/// </remarks>
internal static class EmbeddedXamlSourcesProvider
{
	// key=absolute file path
	private static IDictionary<string, Func<(string hash, string payload)>>? _XamlSources;

	// hash of all the paths
	private static volatile string? _filesListHash;

	// The content of this method only changes when the file list changes
	private static IDictionary<string, Func<(string hash, string payload)>> EnsureInitialize()
	{
		const string currentListHash = "d6cd66944958ced0c513e0a04797b51d"; // that's the hash of all the paths, used to detect changes in the file list following a HR operation

		// Determine if the sources have been updated or not initialized yet
		var previousHashList = _XamlSources;
		var needsUpdate = previousHashList is null || _filesListHash != currentListHash;

		if (needsUpdate)
		{
			var xamlSources = new Dictionary<string, Func<(string hash, string payload)>>(1, StringComparer.OrdinalIgnoreCase);

			// Use method groups to avoid closure allocation and ensure no lambda is created, to allow proper HR support
			xamlSources["C:/Project/0/MainPage.xaml"] = GetSources_MainPage_d6cd66944958ced0c513e0a04797b51d;

			if (Interlocked.CompareExchange(ref _XamlSources, xamlSources, previousHashList) == previousHashList)
			{
				// The sources were updated successfully (no other thread modified them concurrently)
				_filesListHash = currentListHash;
			}
		}

		return _XamlSources;
	}

	public static IReadOnlyList<string> GetXamlFilesList() => [.. EnsureInitialize().Keys];

	public static (string hash, string payload)? GetXamlFile(string filePath)
		=> EnsureInitialize().TryGetValue(filePath, out var sourcesGetter) ? sourcesGetter() : null;

	#region Sources for C:/Project/0/MainPage.xaml
	private static (string hash, string payload) GetSources_MainPage_d6cd66944958ced0c513e0a04797b51d()
	{
		return (
			"346ee2c4a3294fdba50b4b5daaa042583c405e7a", // hash
			"""
			<Page x:Class="TestRepro.MainPage"
			      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			      xmlns:local="using:TestRepro"
			      Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
			  <Page.Resources>
			    <Style TargetType="TextBlock">
			      <Setter Property="Foreground" Value="Red" />
			    </Style>
			    <Style TargetType="Button" x:Key="MyCustomButtonStyle">
			      <Setter Property="Background" Value="Azure" />
			    </Style>
			    <DataTemplate x:Key="MyItemTemplate">
			      <StackPanel>
			        <TextBlock Text="{Binding }" />
			        <Button Content="DoSomething" Style="{StaticResource MyCustomButtonStyle}" />
			      </StackPanel>
			    </DataTemplate>
			  </Page.Resources>
			  <VisualStateManager.VisualStateGroups>
			    <VisualStateGroup>
			      <VisualState x:Name="WideState">
			        <VisualState.StateTriggers>
			          <AdaptiveTrigger MinWindowWidth="641" />
			        </VisualState.StateTriggers>
			        <VisualState.Setters>
			          <Setter Target="TheListView.Background" Value="Red" />
			        </VisualState.Setters>
			      </VisualState>
			      <VisualState x:Name="NarrowState">
			        <VisualState.StateTriggers>
			          <AdaptiveTrigger MinWindowWidth="0" />
			        </VisualState.StateTriggers>
			        <VisualState.Setters>
			          <Setter Target="TheListView.Background" Value="Green" />
			        </VisualState.Setters>
			      </VisualState>
			    </VisualStateGroup>
			  </VisualStateManager.VisualStateGroups>
			  <ListView x:Name="TheListView" ItemTemplate="{StaticResource MyItemTemplate}">
			    <ListView.HeaderTemplate>
			      <DataTemplate>
			        <TextBlock Text="Header" />
			      </DataTemplate>
			    </ListView.HeaderTemplate>
			  </ListView>
			</Page>
			""");
	}
	#endregion
}
