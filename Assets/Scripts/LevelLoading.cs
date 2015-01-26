using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoading : MonoBehaviour {

	public Image cutscenePanel;
	
	public GameObject anomalyWarning;
	public GameObject cam;
	
	public Timer myTimer;
	public Cost myCost;
	
	public AudioSource whooshSound;
	public AudioSource claxxon;
	
	private bool startCutscene;
	private bool warningCutscene = false;
	private bool warningState = true;
	private bool flip = true;
	private float cutsceneTimer;
	private float flashTimeEnd;
	private Color transitionCol;
	private Color finalCol;
	
	private Vector3 camPos1;
	private Vector3 camPos2;
	
	private SoundPlayer sound;
	
	public int levelNumber = 0;
	// Use this for initialization
	void Start () {
		transitionCol = new Color(1,1,1,0);
		finalCol = new Color(1,1,1,1);
		//camPos1 = new Vector3(-2, 50, 0);
		camPos1 = cam.transform.position;
		camPos2 = new Vector3(2, 50, 0);
		sound = GameObject.Find("SoundHandler").GetComponent<SoundPlayer>();
	}
	
	// Update is called once per frame
	void Update(){
		if(warningCutscene){
			//Debug.Log (Time.time + ", " + cutsceneTimer);
			if(Time.time < cutsceneTimer){
				//Debug.Log("Shaka shaka");
				anomalyWarning.SetActive(Mathf.Floor(Time.time)%2 == 0);				
				if((cam.transform.position.x > (camPos1.x + 0.1)) && flip){
					//Debug.Log("Shaka shaka");
					cam.transform.position = Vector3.Lerp(cam.transform.position, camPos1, Time.deltaTime*2);
				}
				else{
					flip = false;					
					cam.transform.position = Vector3.Lerp(cam.transform.position, camPos2, Time.deltaTime*2);
					if(cam.transform.position.x < (camPos2.x - 0.1)){
						flip = true;
					}
				}
			}
			else{
				warningCutscene = false;
				startCutscene = true;
				flashTimeEnd = Time.time + 2;
				whooshSound.Play();
			}			
		}
		if(startCutscene){
			transitionCol = Color.Lerp(transitionCol, finalCol, Time.deltaTime*3);
			cutscenePanel.color = transitionCol;
			if(Time.time > flashTimeEnd){
				LoadLevel("main_1");
			}			
		}
		
	}
	
	public void TransitionCutscene(){
		cutscenePanel.gameObject.SetActive(true);
		anomalyWarning.SetActive(true);
		SignalHandler.DeleteSignal();
		warningCutscene = true;
		claxxon.Play();
		cutsceneTimer = Time.time + 4;
		//startCutscene = true;
	}
	
	public void LoadLevel(string level){
		PersistentLevelData.cost = myCost.TotalCost;
		PersistentLevelData.time = myTimer.TheTime;
		Debug.Log ("Current costs: " + PersistentLevelData.cost + "Current time: " + PersistentLevelData.time);
		Application.LoadLevel(level);
	}
	public void ResetLevel(){
		if(levelNumber == 0){
			PersistentLevelData.cost = 0;
			PersistentLevelData.time = 0;
			Application.LoadLevel("main_0");
		}
		else{
			Application.LoadLevel("main_1");
		}
	}	
}
