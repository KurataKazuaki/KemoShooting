using UnityEngine;
using System.Collections;

public class EnemyObject : MonoBehaviour {

	public int HP;
	public GameObject ParticleEnemyBreak;

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
			// 破壊エフェクト用オブジェクトをインスタンス化
			Instantiate( ParticleEnemyBreak, transform.position, ParticleEnemyBreak.transform.rotation);
			// オブジェクトを削除
			Destroy(gameObject);
		}
	}
}
