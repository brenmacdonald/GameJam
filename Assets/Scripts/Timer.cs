using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerLabel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int seconds = Mathf.FloorToInt(Time.time);
		if(seconds < 3600){
			timerLabel.text = "Time: " + string.Format("{0:00}:{1:00}",(seconds/60)%60,seconds%60);
		}
		else{
			timerLabel.text = "Time: " + string.Format("{0:00}:{1:00}:{2:00}",seconds/3600,(seconds/60)%60,seconds%60);
		}
	}
}
