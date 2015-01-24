using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignalGui : MonoBehaviour {

	public Text strengthLabel;
	// Update is called once per frame
	void Update () {
		string sendToLabel = Mathf.FloorToInt(SignalHandler.signalStrength * 100).ToString();
		strengthLabel.text = "Signal Strength: " + sendToLabel + "%";
	}
}
