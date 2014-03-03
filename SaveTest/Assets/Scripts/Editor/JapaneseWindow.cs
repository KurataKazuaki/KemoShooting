using UnityEngine;
using UnityEditor;
using System.Collections;

public class JapaneseWindow : EditorWindow
{
	[MenuItem("Window/Japanese")]
	public static void OpenWindow()
	{
		EditorWindow.GetWindow<JapaneseWindow>();
	}

	string text = "";

	void OnGUI()
	{
		Input.imeCompositionMode = (IMECompositionMode)EditorGUILayout.EnumPopup( "IME変換モード", Input.imeCompositionMode );

		switch( Input.imeCompositionMode )
		{
		case IMECompositionMode.Auto:
			EditorGUILayout.HelpBox( "Unityの基本設定です. 現在のバージョンのUnityではバグが確認されており、正常に日本語が入力できません.", MessageType.Warning );
			break;
		case IMECompositionMode.On:
			EditorGUILayout.HelpBox( "IME変換（日本語変換）を強制的にONにしています.", MessageType.Info );
			break;
		case IMECompositionMode.Off:
			EditorGUILayout.HelpBox( "IME変換（日本語変換）を強制的にOFFにしています。数値、英語入力などの補助に使用.", MessageType.Info );
			break;
		}

		GUILayout.Label( "入力テスト領域" );
		text = EditorGUILayout.TextArea( text );
	}
}
