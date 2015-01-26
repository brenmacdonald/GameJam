﻿using UnityEngine;
using System.Collections;

public class EarthHandle : MonoBehaviour {

	private Quaternion randomRotation;
	public float rotSpeed = 10;
	// Use this for initialization
	void Start () {
		//randomRotation = Random.rotation;
		//randSpeed = Random.Range (2, 4);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(randomRotation.eulerAngles * (Time.deltaTime/rotSpeed));
		transform.Rotate(Vector3.forward, Time.deltaTime*rotSpeed);
	}
}
