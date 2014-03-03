using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class BuildWizard : EditorWindow {

	[MenuItem("Build/Wizard")]
	static void OpenWindow()
	{
		EditorWindow.GetWindow<BuildWizard>();
	}

	public enum RomMode
	{
		ReleaseRom,
		DebugRom
	}

	public enum ClassDebugMode
	{
		StackTrace,
		Obsolate,
		Disable
	}

	BuildTargetGroup targetGroup;
	RomMode romMode;
	ClassDebugMode classDebugMode;

	// Use this for initialization
	void OnGUI()
	{
		bool guiDisable = EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode;
		EditorGUI.BeginDisabledGroup( guiDisable );

		EditorGUI.BeginChangeCheck();
		targetGroup = (BuildTargetGroup)EditorGUILayout.EnumPopup( "target", targetGroup );
		romMode = (RomMode)EditorGUILayout.EnumPopup( "romMode", romMode );
		classDebugMode = (ClassDebugMode)EditorGUILayout.EnumPopup( "classDebugMode", classDebugMode );
		if( EditorGUI.EndChangeCheck() )
		{
			var tmpSymbols = CreateSymbols();
			PlayerSettings.SetScriptingDefineSymbolsForGroup( targetGroup, tmpSymbols );
		}

		var symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup( targetGroup );

		GUI.enabled = true;
		var newSymbols = EditorGUILayout.TextArea( symbols, GUILayout.ExpandHeight( true ) );
		GUI.enabled = !guiDisable;
		if( symbols != newSymbols )
		{
			PlayerSettings.SetScriptingDefineSymbolsForGroup( targetGroup, newSymbols );
		}

		var scenes = EditorBuildSettings.scenes;
		foreach( var scene in scenes )
		{
			GUILayout.Label( scene.path + " " + scene.enabled );
		}

		EditorGUI.EndDisabledGroup();
	}

	string CreateSymbols()
	{
		List<string> symbols = new List<string>();

		switch( romMode )
		{
		case RomMode.ReleaseRom:
			break;

		case RomMode.DebugRom:
			symbols.Add( "DEBUG_ROM" );
			break;
		}

		symbols.Add( "CLASS_DEBUG_WRAPPER_AUTOSETTINGS" );
		switch( classDebugMode )
		{
		case ClassDebugMode.StackTrace:
			break;
		case ClassDebugMode.Obsolate:
			symbols.Add( "CLASS_DEBUG_WRAPPER_USE" );
			symbols.Add( "CLASS_DEBUG_WRAPPER_ENABLE" );
			symbols.Add( "CLASS_DEBUG_WRAPPER_OBSOLATE" );
			break;
		case ClassDebugMode.Disable:
			symbols.Add( "CLASS_DEBUG_WRAPPER_USE" );
			break;
		}

		return string.Join( ";", symbols.ToArray() );
	}
}
