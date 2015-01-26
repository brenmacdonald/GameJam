using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SatelliteMover : MonoBehaviour {
	
	public Button[] uiButtons;
	public SignalStart earth;

	private RaycastHit hit;
	
	private GameObject satToMove;
	private bool buttonState = true;
	private Vector3 posMouse;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(mouseCast, out hit)){
				if(hit.transform.tag == "node"){
					Debug.Log ("RAYCAST HIT!");
					//earth.autoPing = false;
					SignalHandler.DeleteSignal();
					buttonState = false;
					foreach(Button btn in uiButtons){
						btn.interactable = false;
					}					
					hit.transform.GetComponent<SpherePropogation>().ActivateCollider(false);
				}
				if(hit.transform.tag == "laser"){
					Debug.Log ("RAYCAST HIT!");
					//earth.autoPing = false;
					SignalHandler.DeleteSignal();
					buttonState = false;
					foreach(Button btn in uiButtons){
						btn.interactable = false;
					}
					if(hit.transform.name == "LaserEnd"){
						hit.transform.GetComponent<LaserReceive>().ActivateCollider(false);
					}
					if(hit.transform.name == "LaserStart"){
						hit.transform.GetComponent<LaserSend>().ActivateCollider(false);
					}
				}
			}
		}
		if(Input.GetMouseButtonUp (0) && !buttonState){
			buttonState = true;
			foreach(Button btn in uiButtons){
				btn.interactable = true;
			}
			if(hit.transform.tag == "node"){			
				hit.transform.GetComponent<SpherePropogation>().ActivateCollider(true);
			}
			if(hit.transform.name == "LaserEnd"){
				hit.transform.GetComponent<LaserReceive>().ActivateCollider(true);
			}
			if(hit.transform.name == "LaserStart"){
				hit.transform.GetComponent<LaserSend>().ActivateCollider(true);
			}
		}
		
		if(!buttonState && hit.transform != null){
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			hit.transform.position = posMouse;
			if(hit.transform.name == "LaserStart"){
				hit.transform.gameObject.GetComponent<LaserSend>().LookAtReceiver();
			}
			if(hit.transform.name == "LaserEnd"){
				hit.transform.GetComponent<LaserReceive>().LookAtSender();
			}
		}
	}
}
