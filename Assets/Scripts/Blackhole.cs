using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {

	private SoundPlayer sound;	
	public GameObject particles;
	// Use this for initialization
	void Start () {
		sound = GameObject.Find ("SoundHandler").GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){		
		if(!SignalHandler.ignoreObstacle && (other.tag == "signalSphere" || other.tag == "signalLaser")){
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
}
