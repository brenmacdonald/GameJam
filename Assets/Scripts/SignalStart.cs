using UnityEngine;
using System.Collections;

public class SignalStart : MonoBehaviour {

	
	public GameObject signalSphere;
	public GameObject sound;
	public bool autoPing = false;
	
	private GameObject spawnedSignal;
	//private bool startSignal = false;
	private RaycastHit hit;
	//private bool signalActive = false;
	// Use this for initialization
	void Start () {
		spawnedSignal = null;
	}
	
	// Update is called once per frame
	void Update(){
		if(spawnedSignal == null && !SignalHandler.signalActive){
			if(Input.GetMouseButtonUp (0)){
				//Vector3 posMouse;
				Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(mouseCast, out hit)){
					if(hit.transform.tag == "home"){
						spawnedSignal = (GameObject)Instantiate(signalSphere, transform.position, transform.rotation);
						//spawnedSignal.GetComponent<SignalSphere>().objInfo = gameObject;
						spawnedSignal.GetComponent<SignalSphere>().satParentName = "none";
						spawnedSignal.GetComponent<SignalSphere>().satParentName = gameObject.name;
						SignalHandler.signalActive = true;
						SignalHandler.AddNode(gameObject.name);
						sound.GetComponent<SoundPlayer>().PlaySound(gameObject);
					}
				}
			}				
		}
		if(SignalHandler.loopComplete && (Time.time > SignalHandler.loopStartTime)){
			SignalHandler.loopComplete = false;
			StartTheSignal();
		}
	}
	
	public void StartTheSignal(){
		if(spawnedSignal == null && !SignalHandler.signalActive){			
			spawnedSignal = (GameObject)Instantiate(signalSphere, transform.position, transform.rotation);
			//spawnedSignal.GetComponent<SignalSphere>().objInfo = gameObject;
			//spawnedSignal.GetComponent<SignalSphere>().satParentName = "none";
			spawnedSignal.GetComponent<SignalSphere>().satParentName = gameObject.name;
			//SignalHandler.signalActive = true;
			SignalHandler.NewSignal();
			SignalHandler.AddNode(gameObject.name);
			sound.GetComponent<SoundPlayer>().PlaySound(gameObject);
		}
	}
}
