using UnityEngine;
using System.Collections;

public class LaserExplosionHandler : MonoBehaviour {

	public GameObject sender;
	public GameObject receiver;
	
	public GameObject boomPrefab;
	
	private SoundPlayer sound;
	private LineRenderer myLine;
	
	private Vector3 sendPos;
	private Vector3 recPos;
	
	void Start(){
		sound = GameObject.Find ("SoundHandler").GetComponent<SoundPlayer>();
		myLine = gameObject.GetComponent<LineRenderer>();
		myLine.enabled = false;
	}
	
	void Update(){
		if(myLine.renderer.enabled == true){
			sendPos = sender.transform.position;
			sendPos.y = -20;
			recPos = receiver.transform.position;
			recPos.y = -20;
			myLine.SetPosition(0, sendPos);
			myLine.SetPosition(1, recPos);
		}
	}
	
	public void OnBoom(){
		
		GameObject boom1 = (GameObject)Instantiate(boomPrefab, sender.transform.position, sender.transform.rotation);
		GameObject boom2 = (GameObject)Instantiate(boomPrefab, receiver.transform.position, receiver.transform.rotation);
		SignalHandler.DeleteSignal();
		sound.BoomOverride();
		Invoke("DelayBoomSfx", 0.75f);
		Destroy (boom1, 2f);
		Destroy (boom2, 2f);
		Destroy (gameObject);
	}
	
	public void DelayBoomSfx(){
		sound.BoomOverride();
	}
	
	public void ActivateLineRender(){
		myLine.enabled = true;
		
	}
}
