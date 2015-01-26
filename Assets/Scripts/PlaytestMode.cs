using UnityEngine;
using System.Collections;

public class PlaytestMode : MonoBehaviour {

	public GameObject[] asteroids;
	bool activate = true;
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp (KeyCode.Space)){
			foreach(GameObject child in asteroids){
				child.SetActive(activate);
				activate = !activate;
			}
		}
	}
}
