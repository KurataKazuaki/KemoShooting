using UnityEngine;
using System.Collections;

public class EnemyObject : MonoBehaviour {

	public int HP;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ダメージを受ける
	void Damage (int amount) {
		HP -= amount;
		if (HP <= 0) {
			// オブジェクトを削除
			Destroy(gameObject);
		}
	}
}
