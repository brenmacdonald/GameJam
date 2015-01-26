using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignalGui : MonoBehaviour {

	public Text strengthLabel;
	public Text notificationLabel;
	public Text connectionEstLabel;
	
	public Color connectionErrorCol;
	
	private bool firstNetwork = true;
	private Color startConnCol;
	
	void Start(){
		startConnCol = connectionEstLabel.color;
	}
	
	// Update is called once per frame
	void Update () {
		string sendToLabel = Mathf.FloorToInt(SignalHandler.signalStrength * 100).ToString();
		strengthLabel.text = "Current Strength: " + sendToLabel + "%";
		notificationLabel.text = "Network Strength: " + Mathf.FloorToInt(SignalHandler.networkStrength * 100).ToString() + "%";
		if(SignalHandler.networkStrength > 0){
			firstNetwork = false;
		}
		if(firstNetwork){
			connectionEstLabel.text = "";
		}
		else{
			if(SignalHandler.networkStrength > 0){
				connectionEstLabel.color = startConnCol;
				connectionEstLabel.text = "Network Established!";
			}
			else{
				connectionEstLabel.color = connectionErrorCol;
				connectionEstLabel.text = "Network Disrupted";
			}
			
		}
	}
}
