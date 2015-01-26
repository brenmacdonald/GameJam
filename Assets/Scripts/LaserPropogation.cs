using UnityEngine;
using System.Collections;

public class LaserPropogation : MonoBehaviour {

	private float activationTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ActivateCollider(bool state){
		activationTime = Time.time + 0.1f;
		gameObject.GetComponent<SphereCollider>().enabled = state;
	}
	/*
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere" && Time.time > activationTime){
			SignalSphere originSignal = other.GetComponent<SignalSphere>();			
			colHelper = other;
			
			Invoke ("Propogation", delayTime);
			
		}
	}
	
	public void Propogation(){
		if(spawnedSignal == null && SignalHandler.signalActive){
			if(SignalHandler.NodeCheck(gameObject.name)){
				//Debug.Log ("Executing code.");
				SignalHandler.BoostSignal(boostAmount);
				spawnedSignal = (GameObject)Instantiate(signalSpherePrefab, transform.position, transform.rotation);
				//SignalSphere newSignal = spawnedSignal.gameObject.GetComponent<SignalSphere>();
				spawnedSignal.name = "signalRepeat";
				//newSignal.satSenderName = gameObject.name;
				//newSignal.satParentName = originSignal.satSenderName;
				SignalHandler.AddNode(gameObject.name);
				sound.PlaySound(gameObject);
				
				//Destroy(spawnedSignal, 5);
				Destroy (colHelper.gameObject);
			}
		}
	}
	*/
}
