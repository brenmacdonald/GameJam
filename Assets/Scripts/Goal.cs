using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public Text notifyLabel;
	public SignalStart earth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere"){
			Debug.Log ("SIGNAL RECEIVED!");
			notifyLabel.text = "Signal Received! " + Mathf.FloorToInt(SignalHandler.signalStrength*100) + "%";
			Destroy (other.gameObject);
			SignalHandler.DeleteSignal();
			earth.autoPing = true;
		}
	}
}