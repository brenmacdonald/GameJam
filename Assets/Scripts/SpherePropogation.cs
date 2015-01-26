using UnityEngine;
using System.Collections;

public class SpherePropogation : MonoBehaviour {

	public GameObject signalSpherePrefab;
	public GameObject boomPrefab;
	public GameObject blackHoleBoom;
	public float boostAmount = 2f;
	public bool preExisting = false;
	public float delayTime = 1f;
	public SoundPlayer sound;
	
	private GameObject spawnedSignal;
	private float activationTime = 0;
	private bool startBlackHoleDeath = false;
	private Transform tfBlackHole;
	//private Vector3 zeroScale;
	
	//private SignalSphere signalHelper;
	private Collider colHelper;
	//private Collision collisionHelper;
	
	// Use this for initialization
	void Start () {
		spawnedSignal = null;
		sound = GameObject.Find("SoundHandler").GetComponent<SoundPlayer>();
		//zeroScale = new Vector3(0,0,0);
		if(!preExisting)
			gameObject.GetComponent<SphereCollider>().enabled = false;
		//timeSpawned = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(startBlackHoleDeath){
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero,Time.deltaTime*2);
			transform.position = Vector3.MoveTowards(transform.position, tfBlackHole.position, Time.deltaTime);
			if(transform.localScale.x < 0.01f){
				Destroy(gameObject);
			}
		}
	}
	
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere"){
			if(SignalHandler.NodeCheck(gameObject.name)){
			Debug.Log ("Fired");
			SignalSphere originSignal = other.GetComponent<SignalSphere>();
			//Debug.Log("Sphere hit me! objInfo: " + originSignal.satParentName+ " ,this object: " + gameObject.name);
			//Debug.Log (originSignal.satParentName != gameObject.name);
			//colHelper = other;
			//signalHelper = originSignal;
			SignalHandler.AddNode(gameObject.name);
			Destroy(other.gameObject);
			//ActivateCollider(false);
			//SignalHandler.ignoreObstacle = true;
			Debug.Log ("Time before yield: " + Time.time);
			StartCoroutine("CustomYield");			
			//Invoke ("Propogation", 0.05f);
			
			
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
		else if(other.tag == "signalSphere"){
			//Do nothing, fix this later
		}
		else{
			if(other.name == "BlackHole"){
				//other.GetComponent<Blackhole>().
				GameObject bhDoom = (GameObject)Instantiate(blackHoleBoom, transform.position, transform.rotation);
				SignalHandler.DeleteSignal();
				sound.SignalDestroyOverride();
				tfBlackHole = other.transform;
				startBlackHoleDeath = true;
			}
			else{
				Debug.Log("BOOOM");
				GameObject boom = (GameObject)Instantiate(boomPrefab, transform.position, transform.rotation);
				SignalHandler.DeleteSignal();
				sound.BoomOverride();
				Destroy(boom, 1);
				Destroy(gameObject);
			}
		}		
	}
	/*
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "signalSphere" && Time.time > activationTime){
			SignalSphere originSignal = other.gameObject.GetComponent<SignalSphere>();
			//collisionHelper = other;
			//signalHelper = originSignal;
			Invoke("Propogation", delayTime);			
		}
	}
	*/
	IEnumerator CustomYield(){
		yield return new WaitForSeconds(0.5f);
		Propogation();
	}
	public void Propogation(){
		if(spawnedSignal == null && SignalHandler.signalActive){
			
				//Debug.Log ("Executing code.");
				SignalHandler.BoostSignal(boostAmount);
				spawnedSignal = (GameObject)Instantiate(signalSpherePrefab, transform.position, transform.rotation);
				//SignalSphere newSignal = spawnedSignal.gameObject.GetComponent<SignalSphere>();
				spawnedSignal.name = "signalRepeat";
				//newSignal.satSenderName = gameObject.name;
				//newSignal.satParentName = originSignal.satSenderName;
				//SignalHandler.AddNode(gameObject.name);
				sound.PlaySound(gameObject);
				//SignalHandler.ignoreObstacle = true;
				//ActivateCollider(true);
				/*
						float boost = originSignal.Hue + 0.15f;
						if(boost > 0.3333f){
							boost = 0.3333f;
						}
						spawnedSignal.GetComponent<SignalSphere>().Hue = boost;
					*/
				//Destroy(spawnedSignal, 5);
				//Destroy (colHelper.gameObject);
			
		}
	}
	
	public void ActivateCollider(bool state){
		activationTime = Time.time + 0.1f;
		Debug.Log ("Collider: " + state);
		gameObject.GetComponent<SphereCollider>().enabled = state;
	}
	
}
