using UnityEngine;
using System.Collections;

public class NewPlayer : MonoBehaviour {

	private string playerName = "No name entered";
	
	public void OnUpdateInput(string inputField){
		playerName = inputField;
	}
	public void OnSubmit(string inputField){
		playerName = inputField;
		NewPlayerStart();
	}
	
	public void StartButton(){
		NewPlayerStart();
	}
	
	void NewPlayerStart(){
		PersistentLevelData.cost = 0;
		PersistentLevelData.time = 0;
		PersistentLevelData.playerName = playerName;
		
		Application.LoadLevel("instructions");		
	}
}
