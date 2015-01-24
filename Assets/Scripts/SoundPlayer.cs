using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioClip signalBeep;
	public AudioClip signalDestroy;
	
	public AudioSource mainPlayer;
	
	//private bool playingSound = false;
	//private GameObject lastPlayer = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlaySound(GameObject sender){		
		Debug.Log ("Activated");
		if(mainPlayer.isPlaying){
			mainPlayer.Stop ();
		}
		if(sender.tag == "obstacle"){
			mainPlayer.clip = signalDestroy;
		}
		else{
			mainPlayer.clip = signalBeep;
		}
		mainPlayer.Play();
		/*
		if(lastPlayer = null){
			Debug.Log ("Activated2");
			lastPlayer = sender;
			//sender.GetComponent<AudioSource>().Play();
			mainPlayer.Play();
		}
		else{
			if(!mainPlayer.isPlaying){
				Debug.Log ("Activated3");
				mainPlayer.clip = signalBeep;
				mainPlayer.Play();
				lastPlayer = sender;
				//sender.GetComponent<AudioSource>().Play();
			}
		}
		*/
	}
}
