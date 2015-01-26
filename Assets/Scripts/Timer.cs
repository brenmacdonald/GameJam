using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerLabel;
	
	private float startTime;
	private float seconds;
	
	
	public float TheTime{
		get{ return seconds;}
	}
	// Use this for initialization
	void Start () {
		startTime = Time.time + PersistentLevelData.time;
		Debug.Log ("start on timer called" + PersistentLevelData.time);
	}
	
	// Update is called once per frame
	void Update () {
		seconds = Mathf.Floor(Time.time + startTime);
		if(seconds < 3600){
			timerLabel.text = "Time: " + string.Format("{0:00}:{1:00}",(seconds/60)%60,seconds%60);
		}
		else{
			timerLabel.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}",seconds/3600,(seconds/60)%60,seconds%60);
		}
	}
}
