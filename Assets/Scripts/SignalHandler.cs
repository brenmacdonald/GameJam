using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SignalHandler : MonoBehaviour {

	public static List<string> nodesIntercepted;
	public static bool signalActive = false;	
	
	public static float signalStrength;
	public static float loopStartTime = 0;
	public static bool loopComplete = false;
	public static bool ignoreObstacle = false;
	public static float networkStrength = 0;
	// Use this for initialization
	void Start () {
		nodesIntercepted = new List<string>();
		//tfPreexistingNodes = GameObject.Find("Earth").transform.child
	}
			
	public static void NewSignal(){
		nodesIntercepted = new List<string>();
		signalActive = true;
		signalStrength = 1;
	}
	
	public static void AddNode(string nodeName){
		nodesIntercepted.Add(nodeName);
	}
	
	public static bool NodeCheck(string nodeName){		
		return !nodesIntercepted.Contains(nodeName);
	}
	
	public static void DeleteSignal(){
		nodesIntercepted = new List<string>();
		signalActive = false;
		loopComplete = false;
		//GameObject.Find("Earth").GetComponent<SignalStart>().autoPing = false;
		signalStrength = 0;
		networkStrength = 0;
	}
	
	public static void CompleteSignal(){
		networkStrength = signalStrength;
		nodesIntercepted = new List<string>();
		signalActive = false;
		signalStrength = 0;
	}
	
	public static void BoostSignal(float percent){
		//signalStrength += percent*5;
		signalStrength = signalStrength * percent * 50;
		if(signalStrength > 1){
			signalStrength = 1;
		}
	}
}
