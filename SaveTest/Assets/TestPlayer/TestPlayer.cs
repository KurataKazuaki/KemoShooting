using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPlayer : MonoBehaviour {

	[SerializeField] Transform cachedTransform = null;
	[SerializeField] SpriteRenderer cachedSprite = null;
	[SerializeField] Animator cachedAnimator = null;
	[SerializeField] List<Sprite> sprites = new List<Sprite>();
	public int spriteIndex = 0;
	public float speed = 1f;

	private bool autoSave = true;

	private SaveData saveData = new SaveData();

	public class SaveData
	{
		public Vector3 position;
		public int spriteIndex;

		public void Serialize( TestPlayer testPlayer )
		{
			position = testPlayer.cachedTransform.localPosition;
			spriteIndex = testPlayer.spriteIndex;
		}

		public void Deserialize( TestPlayer testPlayer )
		{
			testPlayer.cachedTransform.localPosition = position;
			testPlayer.spriteIndex = spriteIndex;
			testPlayer.cachedSprite.sprite = testPlayer.sprites[ spriteIndex ];
		}
	}

	// Use this for initialization
	void Start () {
		if( cachedTransform == null )
		{ cachedTransform = this.transform; }

		if( cachedSprite == null )
		{ cachedSprite = gameObject.GetComponent<SpriteRenderer>(); }

		if( cachedAnimator == null )
		{ cachedAnimator = gameObject.GetComponent<Animator>(); }

		saveData = SaveCenter.GetObject<SaveData>( SaveKey.Test.Player, saveData );
		saveData.Deserialize( this );
	}

	public bool isMove = false;

	// Update is called once per frame
	void Update () {

		if( Input.anyKey )
		{ isMove = true; }
		else if( isMove )
		{
			spriteIndex = ( spriteIndex + 1 ) % sprites.Count;
			cachedSprite.sprite = sprites[ spriteIndex ];
			isMove = false;
			if( autoSave )
			{
				saveData.Serialize( this );
				SaveCenter.SetObject( SaveKey.Test.Player, saveData );
				Debug.Log( "Saved." );
				SaveCenter.Save();
			}
		}
		cachedAnimator.SetInteger( "isMove", isMove ? 1 : 0 );

		if( Input.GetKey( KeyCode.W ) )
		{ cachedTransform.localPosition += Vector3.up    * speed * Time.deltaTime; }
		if( Input.GetKey( KeyCode.S ) )
		{ cachedTransform.localPosition += Vector3.down  * speed * Time.deltaTime; }
		if( Input.GetKey( KeyCode.A ) )
		{ cachedTransform.localPosition += Vector3.left  * speed * Time.deltaTime; }
		if( Input.GetKey( KeyCode.D ) )
		{ cachedTransform.localPosition += Vector3.right * speed * Time.deltaTime; }
	}

	void OnGUI()
	{
		//GUILayout.Label( LitJson.JsonMapper.ToJson( saveData ) );
		//autoSave = GUILayout.Toggle( autoSave, "Auto Save" );
	}
}
