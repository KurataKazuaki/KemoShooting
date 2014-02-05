using UnityEngine;
using System.Collections;

public class blazeBulletScript : bulletObject {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( speed );
	}
}
