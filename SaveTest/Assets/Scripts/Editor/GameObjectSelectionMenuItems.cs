using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public static class GameObjectSelectionMenuItems
{
	[MenuItem("GameObject/Selection/Add Child")]
	public static void AddChild()
	{
		var go = Selection.activeGameObject;

		if( go == null )
		{
			Debug.LogWarning( "Need to select GameObject." );
			return;
		}

		var child = new GameObject( "Child" );
		child.transform.parent = go.transform;
		child.transform.localScale = Vector3.one;
		child.transform.localRotation = Quaternion.identity;
		child.transform.localPosition = Vector3.zero;
	}

	[MenuItem("GameObject/Selection/Remove All Children")]
	public static void RemoveAllChildren()
	{
		var go = Selection.activeGameObject;
		
		if( go == null )
		{
			Debug.LogWarning( "Need to select GameObject." );
			return;
		}

		List<GameObject> toBeRemoved = new List<GameObject>();

		foreach( Transform t in go.transform )
		{
			toBeRemoved.Add( t.gameObject );
		}

		foreach( var rem in toBeRemoved )
		{
			GameObject.DestroyImmediate( rem );
		}
	}
}
