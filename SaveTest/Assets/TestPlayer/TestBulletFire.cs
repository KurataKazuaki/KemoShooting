using UnityEngine;
using System.Collections;

public class TestBulletFire : MonoBehaviour {

	// メインショット プレハブ
	public bullet mainShot;
	// 同時発射弾数
	public int ways = 1;
	// 発射間隔
	public float interval = 1f;

	// 発射フラグ
	private bool isFire = true;

	// 発射開始
	void StartShot (){
		if (!isFire) {
			isFire = true;
			StartCoroutine ("FireBullet");
		}
	}
	// 発射停止
	void StopShot (){
		if (isFire) {
			isFire = false;
			StopCoroutine ("FireBullet");
		}
	}

	// ショット発射
	IEnumerator FireBullet(){
		// 無限ループ
		while (true) {
			// メインショットプレハブを、プレイヤーオブジェクトの位置にインスタンス化
			Instantiate(mainShot, transform.position, Quaternion.identity);
			// interval分だけ処理を停止
			yield return new WaitForSeconds(interval);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
