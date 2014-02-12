using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

	public float Duration;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, Duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
