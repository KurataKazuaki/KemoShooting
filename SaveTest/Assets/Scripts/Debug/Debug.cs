
#if !CLASS_DEBUG_WRAPPER_AUTOSETTINGS

#define CLASS_DEBUG_WRAPPER_USE

#define CLASS_DEBUG_WRAPPER_OBSOLATE

#define CLASS_DEBUG_WRAPPER_ENABLE

#endif

using UnityEngine;
using System.Collections;
using System.Diagnostics;

using UnityDebug = UnityEngine.Debug;

#if CLASS_DEBUG_WRAPPER_USE
#if CLASS_DEBUG_WRAPPER_OBSOLATE
[System.Obsolete( "Remove this for parformance issue." )]
#endif
public class Debug
{
	Debug()
	{}

	public static bool developerConsoleVisible
	{
		get{ return UnityDebug.developerConsoleVisible; }
		set{ UnityDebug.developerConsoleVisible = value; }
	}

	public static bool isDebugBuild
	{ get{ return UnityDebug.isDebugBuild; } }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void ClearDeveloperConsole()
	{ UnityDebug.ClearDeveloperConsole(); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void Log( object message )
	{ UnityDebug.Log ( message ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void Log( object message, Object context )
	{ UnityDebug.Log ( message, context ); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogWarning( object message )
	{ UnityDebug.LogWarning ( message ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogWarning( object message, Object context )
	{ UnityDebug.LogWarning ( message, context ); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogError( object message )
	{ UnityDebug.LogError ( message ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogError( object message, Object context )
	{ UnityDebug.LogError ( message, context ); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogException( System.Exception exception )
	{ UnityDebug.LogException ( exception ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void LogException( System.Exception exception, Object context )
	{ UnityDebug.LogException ( exception, context ); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void Break()
	{ UnityDebug.Break(); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DebugBreak()
	{ UnityDebug.DebugBreak(); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawLine( Vector3 start, Vector3 end )
	{ UnityDebug.DrawLine( start, end ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawLine( Vector3 start, Vector3 end, Color color )
	{ UnityDebug.DrawLine( start, end, color ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawLine( Vector3 start, Vector3 end, Color color, float duration )
	{ UnityDebug.DrawLine( start, end, color, duration ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawLine( Vector3 start, Vector3 end, Color color, float duration, bool depthTest )
	{ UnityDebug.DrawLine( start, end, color, duration, depthTest ); }

	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawRay( Vector3 start, Vector3 dir )
	{ UnityDebug.DrawRay( start, dir ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawRay( Vector3 start, Vector3 dir, Color color )
	{ UnityDebug.DrawRay( start, dir, color ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawRay( Vector3 start, Vector3 dir, Color color, float duration )
	{ UnityDebug.DrawRay( start, dir, color, duration ); }
	[Conditional( "CLASS_DEBUG_WRAPPER_ENABLE" )]
	public static void DrawRay( Vector3 start, Vector3 dir, Color color, float duration, bool depthTest )
	{ UnityDebug.DrawRay( start, dir, color, duration, depthTest ); }
}
#endif