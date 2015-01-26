using UnityEngine;
using System.Collections;

public class BlackHoleBehavior : MonoBehaviour {

	//private Quaternion randomRotation;
	private float randSpeed;
	//public float rotSpeed = 10;
	
	public float[] layerSpeeds;
	public Transform[] bhLayers;
	// Use this for initialization
	void Start () {
		//randomRotation = Random.rotation;
		randSpeed = Random.Range(30, 50);
		layerSpeeds = new float[bhLayers.Length];
		for(int i=0; i < layerSpeeds.Length; i++){
			layerSpeeds[i] = Random.Range(20, 70);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, Time.deltaTime*randSpeed);
		for(int i=0; i < bhLayers.Length; i++){
			bhLayers[i].Rotate(Vector3.forward, Time.deltaTime*layerSpeeds[i]);
		}
	}
}
