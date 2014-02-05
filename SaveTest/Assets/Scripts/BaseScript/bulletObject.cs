using UnityEngine;
using System.Collections;

public class bulletObject : MonoBehaviour {

	public int power;
	public Vector3 speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	// 敵と当たって居る状態
	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("Bullet Hit to something");
		if (other.tag == "Enemy") {
			other.SendMessage ("Damage", power);
			DestroyMyself();
		}
	}

	// 弾が破壊された時に呼び出される
	void DestroyMyself() {
		// オブジェクトを削除
		Destroy (gameObject);
	}
}
