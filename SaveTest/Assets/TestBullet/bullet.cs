using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 弾が破壊された時に呼び出される
	void Destroy() {
		// オブジェクトを削除
		Destroy (gameObject);
	}
}
