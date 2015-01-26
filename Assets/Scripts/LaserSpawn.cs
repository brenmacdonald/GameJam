using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaserSpawn : MonoBehaviour {

	public Button[] uiButtons;
	public GameObject laserPrefab;
	
	private GameObject spawnedSat;
	private Vector3 posMouse;
	private bool buttonState;
	
	private GameObject sender;
	private GameObject receiver;
	
	private float delay;
	
	private int satSpawnCount = 0;
	
	private enum LaserInstall{
		Idle,
		Sender,
		Receiver,
		Done
	};
	
	private LaserInstall installStatus;
		
	// Use this for initialization
	void Start () {
		installStatus = LaserInstall.Idle;
	}
	
	public void OnSpawnLaser(){
		//earth.autoPing = false;
		buttonState = false;
		foreach(Button btn in uiButtons){
			btn.interactable = false;
		}
		SignalHandler.DeleteSignal();
		posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		posMouse.y = 0;
		spawnedSat = (GameObject)Instantiate(laserPrefab,posMouse,transform.rotation);
		sender = spawnedSat.transform.FindChild("LaserStart").gameObject;
		receiver = spawnedSat.transform.FindChild("LaserEnd").gameObject;
		receiver.GetComponent<LaserReceive>().ActivateCollider(false);
		sender.GetComponent<LaserSend>().ActivateCollider(false);
		installStatus = LaserInstall.Sender;
		spawnedSat.name = "Laser_" + satSpawnCount;
		delay = Time.time + 0.1f;
		satSpawnCount++;
	}
	
	// Update is called once per frame
	void Update () {
		switch(installStatus){		
		case(LaserInstall.Sender):
			//Debug.Log ("Everything OK here");
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			sender.transform.position = posMouse;
			
			
			if(Input.GetMouseButtonUp(0) && Time.time > delay){
				installStatus = LaserInstall.Receiver;
				spawnedSat.GetComponent<LaserExplosionHandler>().ActivateLineRender();
				delay = Time.time + 0.1f;
			}
			break;
		case(LaserInstall.Receiver):
			posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posMouse.y = 0;
			receiver.transform.position = posMouse;
			
			sender.transform.LookAt(receiver.transform);
			receiver.transform.LookAt(sender.transform);
			
			if(Input.GetMouseButtonUp(0) && Time.time > delay){
				installStatus = LaserInstall.Done;
			}
			break;
		case(LaserInstall.Done):
			receiver.GetComponent<LaserReceive>().ActivateCollider(true);
			sender.GetComponent<LaserSend>().ActivateCollider(true);
			foreach(Button btn in uiButtons){
				btn.interactable = true;
			}
			buttonState = true;			
			installStatus = LaserInstall.Idle;
			//sender.GetComponent<LaserPropogation>().ActivateCollider(true);
			break;
		default:
			break;
		}
		
	}
}
