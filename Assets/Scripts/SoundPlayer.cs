using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioClip signalBeep;
	public AudioClip signalDestroy;
	public AudioClip signalGoal;
	public AudioClip signalLaser;
	public AudioClip boom;
	public AudioClip claxxon;
	public AudioClip congrats;
	
	public AudioSource mainPlayer;
	
	//private bool playingSound = false;
	//private GameObject lastPlayer = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Claxxon(){
				
		mainPlayer.clip = claxxon;
		mainPlayer.Play();
		
		
	}
	
	public void OnCongrats(){
		if(mainPlayer.isPlaying){
			mainPlayer.Stop ();
		}
		mainPlayer.clip = congrats;
		mainPlayer.Play();
	}
	
	public void BoomOverride(){
		if(mainPlayer.isPlaying){
			mainPlayer.Stop ();
		}
		mainPlayer.clip = boom;
		mainPlayer.Play();
	}
	
	public void SignalDestroyOverride(){
		if(mainPlayer.isPlaying){
			mainPlayer.Stop ();
		}
		mainPlayer.clip = signalDestroy;
		mainPlayer.Play();
	}
	
	public void PlaySound(GameObject sender){		
		//Debug.Log ("Activated");
		if(mainPlayer.isPlaying){
			mainPlayer.Stop ();
		}
		if(sender.tag == "obstacle"){
			mainPlayer.clip = signalDestroy;
		}
		else if(sender.tag == "goal"){
			mainPlayer.clip = signalGoal;
		}
		else if(sender.tag == "laser"){
			mainPlayer.clip = signalLaser;
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
