using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownloadHandler : MonoBehaviour {

	public int downloadAmount = 0;
	public Text downloadLabel;
	
	public LevelLoading levelLoader;
	
	private bool cutsceneStarted = false;
	private SoundPlayer sound;
	
	private bool isPlayingEndSound = false;
	
	void Start(){
		sound = GameObject.Find("SoundHandler").GetComponent<SoundPlayer>();
	}
		
	// Update is called once per frame
	void Update () {
		if(levelLoader.levelNumber == 0){
			if(downloadAmount < 400){
				downloadLabel.text = "Received: " + downloadAmount + "/800";
			}
			else{
				downloadLabel.text = "Received: " + "400/800";
				if(!cutsceneStarted){
					levelLoader.TransitionCutscene();
					cutsceneStarted = true;
				}
				//end game
			}
		}
		else{
			if(downloadAmount < 800){
				downloadLabel.text = "Received: " + downloadAmount + "/800";
			}
			else{
				downloadLabel.text = "Received: " + "800/800";
				if(!isPlayingEndSound){
					isPlayingEndSound = true;
					sound.OnCongrats();
					SignalHandler.DeleteSignal();
					Invoke ("EndGame", 2);
				}
				//end game
			}
		}
	}
	
	public void EndGame(){
		Application.LoadLevel("end");
	}
}
