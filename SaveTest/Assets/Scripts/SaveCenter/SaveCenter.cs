
/// <summary>
/// Save Center.
/// author : Kubiwak
/// </summary>

using UnityEngine;
using System.Collections;
using LitJson;

public static class SaveCenter
{
	public static void Save()
	{ PlayerPrefs.Save(); }

	public static void DeleteAll()
	{ PlayerPrefs.DeleteAll(); }

	public static bool HasKey( string key )
	{ return PlayerPrefs.HasKey( key ); }

	public static void DeleteKey( string key )
	{ PlayerPrefs.DeleteKey( key ); }

	public static int GetInt( string key )
	{ return PlayerPrefs.GetInt( key ); }

	public static int GetInt( string key, int defaultValue )
	{ return PlayerPrefs.GetInt( key, defaultValue ); }

	public static void SetInt( string key, int value )
	{ PlayerPrefs.SetInt( key, value ); }

	public static float GetFloat( string key )
	{ return PlayerPrefs.GetFloat( key ); }
	
	public static float GetFloat( string key, float defaultValue )
	{ return PlayerPrefs.GetFloat( key, defaultValue ); }
	
	public static void SetFloat( string key, int value )
	{ PlayerPrefs.SetInt( key, value ); }
	
	public static string GetString( string key )
	{ return PlayerPrefs.GetString( key ); }
	
	public static string GetString( string key, string defaultValue )
	{ return PlayerPrefs.GetString( key, defaultValue ); }
	
	public static void SetString( string key, string value )
	{ PlayerPrefs.SetString( key, value ); }

	public static void SetObject<T>( string key, T value )
	{ SetString( key, JsonMapper.ToJson( value ) ); }

	public static T GetObject<T>( string key )
	{ return JsonMapper.ToObject<T>( GetString( key ) ); }

	public static T GetObject<T>( string key, T defaultValue )
	{
		if( HasKey( key ) )
		{ return GetObject<T>( key ); }
		return defaultValue;
	}

	public static void RegisterLitJsonFunctions()
	{
		// basic imp-exp.
		LitJson.JsonMapper.RegisterExporter<float>( (obj, writer) => { writer.Write( System.Convert.ToDouble( obj ) ); } );
		LitJson.JsonMapper.RegisterImporter<double,float>( (input) => { return System.Convert.ToSingle( input ); } );
		LitJson.JsonMapper.RegisterImporter<System.Int32,long>( (input) => { return System.Convert.ToInt64( input ); } );
		
		// exp Vector2.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Vector2>( (obj, writer) => { 
			var value = (UnityEngine.Vector2)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "x" );
			writer.Write ( value.x );
			writer.WritePropertyName( "y" );
			writer.Write ( value.y );
			writer.WriteObjectEnd();
		} );
		
		// exp Vector3.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Vector3>( (obj, writer) => { 
			var value = (UnityEngine.Vector3)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "x" );
			writer.Write ( value.x );
			writer.WritePropertyName( "y" );
			writer.Write ( value.y );
			writer.WritePropertyName( "z" );
			writer.Write ( value.z );
			writer.WriteObjectEnd();
		} );
		
		// exp Vector4.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Vector4>( (obj, writer) => { 
			var value = (UnityEngine.Vector4)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "x" );
			writer.Write ( value.x );
			writer.WritePropertyName( "y" );
			writer.Write ( value.y );
			writer.WritePropertyName( "z" );
			writer.Write ( value.z );
			writer.WritePropertyName( "w" );
			writer.Write ( value.w );
			writer.WriteObjectEnd();
		} );
		
		// exp Quaternion.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Quaternion>( (obj, writer) => { 
			var value = (UnityEngine.Quaternion)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "x" );
			writer.Write ( value.x );
			writer.WritePropertyName( "y" );
			writer.Write ( value.y );
			writer.WritePropertyName( "z" );
			writer.Write ( value.z );
			writer.WritePropertyName( "w" );
			writer.Write ( value.w );
			writer.WriteObjectEnd();
		} );
		
		// exp Color.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Color>( (obj, writer) => { 
			var value = (UnityEngine.Color)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "r" );
			writer.Write ( value.r );
			writer.WritePropertyName( "g" );
			writer.Write ( value.g );
			writer.WritePropertyName( "b" );
			writer.Write ( value.b );
			writer.WritePropertyName( "a" );
			writer.Write ( value.a );
			writer.WriteObjectEnd();
		} );
		
		// exp Rect.
		LitJson.JsonMapper.RegisterExporter<UnityEngine.Rect>( (obj, writer) => { 
			var value = (UnityEngine.Rect)obj;
			writer.WriteObjectStart();
			writer.WritePropertyName( "x" );
			writer.Write ( value.x );
			writer.WritePropertyName( "y" );
			writer.Write ( value.y );
			writer.WritePropertyName( "width" );
			writer.Write ( value.width );
			writer.WritePropertyName( "height" );
			writer.Write ( value.height );
			writer.WriteObjectEnd();
		} );
	}
}