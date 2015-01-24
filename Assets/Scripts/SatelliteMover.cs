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
					earth.autoPing = false;
					buttonState = false;
					foreach(Button btn in uiButtons){
						btn.interactable = false;
					}
					
					hit.transform.GetComponent<SpherePropogation>().ActivateCollider(false);
				}
			}
		}
		if(Input.GetMouseButtonUp (0) && !buttonState){
			buttonState = true;
			foreach(Button btn in uiButtons){
				btn.interactable = true;
			}			
			hit.transform.GetComponent<SpherePropogation>().ActivateCollider(true);
		}
		
		if(!buttonState && hit.transform != null){
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			hit.transform.position = posMouse;
		}
	}
}
