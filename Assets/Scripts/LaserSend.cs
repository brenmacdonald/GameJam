using UnityEngine;
using System.Collections;

public class LaserSend : MonoBehaviour {

	public GameObject laserPrefab;
	public GameObject receiver;
	
	private SoundPlayer sound;
	// Use this for initialization
	void Start(){
		sound = GameObject.Find ("SoundHandler").GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "signalSphere"){
			GameObject bullet = (GameObject)Instantiate(laserPrefab, transform.position, transform.rotation);
			bullet.GetComponent<LaserMove>().destination = receiver.transform;
			SignalHandler.AddNode(gameObject.name);
			sound.PlaySound(gameObject);
			Destroy(other.gameObject);
		}
		else if(other.tag == "signalLaser"){
			//Do nothing
		}
		else{
			Debug.Log ("BOOOM LASERS" + other.name);
			transform.parent.GetComponent<LaserExplosionHandler>().OnBoom();
		}
	}
	
	public void LookAtReceiver(){
		transform.LookAt(receiver.transform);
		receiver.transform.LookAt(transform);
	}
	
	public void ActivateCollider(bool state){
		gameObject.GetComponent<SphereCollider>().enabled = state;
	}
}
