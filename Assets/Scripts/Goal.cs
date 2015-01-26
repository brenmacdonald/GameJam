using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public Text notifyLabel;
	public SignalStart earth;
	public GameObject dnaExplode;
	public SoundPlayer sound;
	public DownloadHandler downloadHandle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){		
		if(other.tag == "signalSphere"){
			Debug.Log ("SIGNAL RECEIVED!");
			//notifyLabel.text = "Connection established: " + Mathf.FloorToInt(SignalHandler.networkStrength*100) + "%";
			SignalHandler.networkStrength = SignalHandler.signalStrength;
			downloadHandle.downloadAmount += Mathf.FloorToInt(SignalHandler.networkStrength*100);
			Destroy (other.gameObject);
			Vector3 spawnPos = transform.position;
			spawnPos.y = -5;
			GameObject newDna = (GameObject)Instantiate(dnaExplode, spawnPos, transform.rotation);
			Destroy(newDna, 1.5f);
			sound.PlaySound (gameObject);
			SignalHandler.CompleteSignal();
			SignalHandler.loopComplete = true;
			SignalHandler.loopStartTime = Time.time + 2;
			//earth.autoPing = true;
		}
	}
}