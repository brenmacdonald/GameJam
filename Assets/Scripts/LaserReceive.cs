using UnityEngine;
using System.Collections;

public class LaserReceive : MonoBehaviour {

	public GameObject signalSphere;
	public GameObject sender;
	public SoundPlayer sound;

	private GameObject spawnedSignal;
	private float activationTime = 0;
	// Use this for initialization
	void Start () {
		spawnedSignal = null;
		sound = GameObject.Find("SoundHandler").GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "signalLaser"){
			spawnedSignal = (GameObject)Instantiate(signalSphere, transform.position, transform.rotation);
			spawnedSignal.GetComponent<SignalSphere>().satParentName = gameObject.name;
			sound.GetComponent<SoundPlayer>().PlaySound(gameObject);
			Destroy(other.gameObject);
		}
		else if(other.tag == "signalSphere"){
			//do nothing
		}
		else{
			transform.parent.GetComponent<LaserExplosionHandler>().OnBoom();
		}
	}
	
	public void ActivateCollider(bool state){
		activationTime = Time.time + 0.1f;
		gameObject.GetComponent<SphereCollider>().enabled = state;
	}
	
	public void LookAtSender(){
		transform.LookAt(sender.transform);
		sender.transform.LookAt(transform);
	}
}
