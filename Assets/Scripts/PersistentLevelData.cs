using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentLevelData : MonoBehaviour {
	public static float time = 0;
	public static float cost = 0;
	public static Dictionary<string, float> playerInfo;
	public static string playerName = "";
	
	
	void Start(){
		if(playerInfo == null){
			playerInfo = new Dictionary<string, float>();
		}
	}
}
