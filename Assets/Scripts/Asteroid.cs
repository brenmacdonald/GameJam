using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private Quaternion randomRotation;
	private float randSpeed;
	private SoundPlayer sound;
	
	public GameObject particles;
	// Use this for initialization
	void Start () {
		randomRotation = Random.rotation;
		randSpeed = Random.Range (2, 4);
		sound = GameObject.Find ("SoundHandler").GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(randomRotation.eulerAngles * (Time.deltaTime/randSpeed));
	}
	
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere"){
			Debug.Log("INTERFERENCE!");
			SignalHandler.DeleteSignal();
			Destroy(other.gameObject);
			Vector3 expPos = other.ClosestPointOnBounds(transform.position);
			GameObject explode = (GameObject)Instantiate(particles, expPos, transform.rotation);
			explode.GetComponent<ParticleSystem>().Play();
			sound.PlaySound(gameObject);
			Destroy(explode, 2);
		}
	}
	/*
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "signalSphere"){
			Debug.Log("INTERFERENCE!");
			SignalHandler.DeleteSignal();
			Destroy(other.gameObject);
			ContactPoint ptExplode = other.contacts[0];			
			Vector3 expPos = ptExplode.point;
			GameObject explode = (GameObject)Instantiate(particles, expPos, transform.rotation);
			explode.GetComponent<ParticleSystem>().Play();
			Destroy(explode, 2);
		}
	}
	*/
}
