using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour {

	public Text playerScoreLabel;
	
	public Text[] highScoreNames;
	public Text[] highScoreValues;
	
	private List<string> highScoreKeys;
	private List<float> highScoreVals;
	private int index =0;
	// Use this for initialization
	void Start () {
		float playerScore = CalculatePlayerScore();
		playerScoreLabel.text = PersistentLevelData.playerName + "'s rating: " + CustomRound(playerScore);
		
		
		/*
		if(!PersistentLevelData.playerInfo.ContainsKey(PersistentLevelData.playerName)){
			PersistentLevelData.playerInfo.Add(PersistentLevelData.playerName, 0);
		}
		*/
		//CalculateHighScores ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	float CalculatePlayerScore(){
		float cost = PersistentLevelData.cost;
		float time = PersistentLevelData.time;
		
		float score = 100 * ((240/time) * (30000000/cost));
		if(score < 0){
			score = 0;
		}
		return score;
	}
	
	
	
	float CustomRound(float toRound){
		return Mathf.Round(toRound * 1000.0f) / 1000.0f;
	}
	
	public void OnMainMenuButton(){
		Application.LoadLevel("start");
	}
}
