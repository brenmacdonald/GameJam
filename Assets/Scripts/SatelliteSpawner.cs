using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SatelliteSpawner : MonoBehaviour {

	public Button[] uiButtons;
	public GameObject satPrefab;
	public SignalStart earth;
	
	private GameObject spawnedSat;
	private Vector3 posMouse;
	private bool buttonState;
	private float delay;
	
	private int satSpawnCount = 0;
	
	public void OnSpawnSattelite(){
		//earth.autoPing = false;
		buttonState = false;
		foreach(Button btn in uiButtons){
			btn.interactable = false;
		}
		SignalHandler.DeleteSignal();
		posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		posMouse.y = 0;
		spawnedSat = (GameObject)Instantiate(satPrefab,posMouse,transform.rotation);
		spawnedSat.name = "Sat_" + satSpawnCount;		
		satSpawnCount++;
		delay = Time.time + 0.1f;
	}
	
	void Update(){
		if(!buttonState && spawnedSat != null){
			//Debug.Log ("Everything OK here");
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			spawnedSat.transform.position = posMouse;
			
			if(Input.GetMouseButtonUp(0) && Time.time > delay){
				Debug.Log ("Done: " + spawnedSat.name);
				if(spawnedSat.GetComponent<SpherePropogation>() != null){
					Debug.Log ("component is true");
				}
				foreach(Button btn in uiButtons){
					btn.interactable = true;
				}
				buttonState = true;
				spawnedSat.GetComponent<SpherePropogation>().ActivateCollider(true);
			}
		}
		
	}
}
