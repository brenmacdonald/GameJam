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
	
	private int satSpawnCount = 0;
	
	public void OnSpawnSattelite(){
		earth.autoPing = false;
		foreach(Button btn in uiButtons){
			btn.interactable = false;
		}
		buttonState = false;
		spawnedSat = (GameObject)Instantiate(satPrefab);
		spawnedSat.name = "Sat_" + satSpawnCount;
		posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		posMouse.y = 0;
		spawnedSat.transform.position = posMouse;
		satSpawnCount++;
	}
	
	void Update(){
		if(!buttonState && spawnedSat != null){
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			spawnedSat.transform.position = posMouse;
			
			if(Input.GetMouseButtonUp(0)){
				foreach(Button btn in uiButtons){
					btn.interactable = true;
				}
				buttonState = true;
				spawnedSat.GetComponent<SpherePropogation>().ActivateCollider(true);
			}
		}
		
	}
}
