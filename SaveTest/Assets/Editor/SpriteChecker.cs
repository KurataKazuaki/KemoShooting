using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpriteChecker : EditorWindow {

	[MenuItem( "Kubiwak/Sprite Checker" )]
	public static void Open()
	{
		EditorWindow.GetWindow<SpriteChecker>();
	}

	public void OnGUI()
	{
		UnityEngine.Object activeObject = Selection.activeObject;
		if( activeObject )
		{ GUILayout.Label( activeObject.ToString() ); }
		else
		{ GUILayout.Label( "no selection" ); }
		//GUILayout.Label( "TEST" );

		if( activeObject is Texture2D )
		{
			var activeTexture = (Texture2D)activeObject;
			GUI.DrawTexture( 
			                GUILayoutUtility.GetRect( 
			                         activeTexture.width,
			                         activeTexture.height,
			                         GUILayout.ExpandWidth( false ) ),
			                activeTexture );
		}
		else if( activeObject is Sprite )
		{
			var activeSprite = (Sprite)activeObject;
			GUILayout.Label( "Source Texture:" + activeSprite.texture.name );
			GUI.DrawTexture( 
				GUILayoutUtility.GetRect( 
									activeSprite.texture.width,
									activeSprite.texture.height,
									GUILayout.ExpandWidth( false ) ),
				activeSprite.texture );
			EditorGUILayout.RectField( "rect", activeSprite.rect );
			EditorGUILayout.RectField( "textureRect", activeSprite.textureRect );
			EditorGUILayout.Vector2Field( "textureRectOffset", activeSprite.textureRectOffset );
			Rect rTC = activeSprite.textureRect;
			rTC.xMin /= activeSprite.texture.width;
			rTC.yMin /= activeSprite.texture.height;
			rTC.xMax /= activeSprite.texture.width;
			rTC.yMax /= activeSprite.texture.height;
			GUI.DrawTextureWithTexCoords(
				GUILayoutUtility.GetRect( 
			                         activeSprite.rect.width,
			                         activeSprite.rect.height,
			                         GUILayout.ExpandWidth( false ) ),
				activeSprite.texture, rTC );

		}
	}

	public void OnSelectionChange()
	{
		Repaint();
	}
}
