using UnityEngine;
using System.Collections;

public class SpherePropogation : MonoBehaviour {

	public GameObject signalSpherePrefab;
	public float boostAmount = 2f;
	public bool preExisting = false;
	public float delayTime = 0.01f;
	public SoundPlayer sound;
	
	private GameObject spawnedSignal;
	private float activationTime = 0;
	
	//private SignalSphere signalHelper;
	private Collider colHelper;
	//private Collision collisionHelper;
	
	// Use this for initialization
	void Start () {
		spawnedSignal = null;
		sound = GameObject.Find("SoundHandler").GetComponent<SoundPlayer>();
		if(!preExisting)
			gameObject.GetComponent<SphereCollider>().enabled = false;
		//timeSpawned = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere" && Time.time > activationTime){
			SignalSphere originSignal = other.GetComponent<SignalSphere>();
			//Debug.Log("Sphere hit me! objInfo: " + originSignal.satParentName+ " ,this object: " + gameObject.name);
			//Debug.Log (originSignal.satParentName != gameObject.name);
			colHelper = other;
			//signalHelper = originSignal;
			Invoke ("Propogation", delayTime);
			//Propogation(originSignal, other);
			/*	
			if(spawnedSignal == null){
				if(SignalHandler.NodeCheck(gameObject.name)){
					//Debug.Log ("Executing code.");
					SignalHandler.BoostSignal(boostAmount);
					spawnedSignal = (GameObject)Instantiate(signalSpherePrefab, transform.position, transform.rotation);
					SignalSphere newSignal = spawnedSignal.gameObject.GetComponent<SignalSphere>();
					spawnedSignal.name = "signalRepeat";
					//newSignal.satSenderName = gameObject.name;
					//newSignal.satParentName = originSignal.satSenderName;
					SignalHandler.AddNode(gameObject.name);
					
					//Destroy(spawnedSignal, 5);
					Destroy (other.gameObject);
				}
			}
			*/
		}
	}
	
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "signalSphere" && Time.time > activationTime){
			SignalSphere originSignal = other.gameObject.GetComponent<SignalSphere>();
			//collisionHelper = other;
			//signalHelper = originSignal;
			Invoke("Propogation", delayTime);
			
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
				/*
						float boost = originSignal.Hue + 0.15f;
						if(boost > 0.3333f){
							boost = 0.3333f;
						}
						spawnedSignal.GetComponent<SignalSphere>().Hue = boost;
					*/
				//Destroy(spawnedSignal, 5);
				Destroy (colHelper.gameObject);
			}
		}
	}
	
	public void ActivateCollider(bool state){
		activationTime = Time.time + 0.1f;
		gameObject.GetComponent<SphereCollider>().enabled = state;
	}
	
}
