using UnityEngine;
using System.Collections;

public class SatelliteBehaviors : MonoBehaviour {

	public Light smallPoint;
	
	//private float intensity1 = 1;
	//private float intensity2 = 0.5f;
	//private bool flipLight = true;
	private Quaternion randomRotation;
	private float randSpeed;
	//private bool CR_running = false;
	//private float t;
	private float targetIntensity;          // The intensity that the light is aiming for currently.
	
	public float fadeSpeed = 1f;            // How fast the light fades between intensities.
	public float highIntensity = 1f;        // The maximum intensity of the light whilst the alarm is on.
	public float lowIntensity = 0.5f;       // The minimum intensity of the light whilst the alarm is on.
	public float changeMargin = 0.2f;       // The margin within which the target intensity is changed.
	// Use this for initialization
	void Start () {
		randomRotation = Random.rotation;
		randSpeed = Random.Range (5, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(randomRotation.eulerAngles * (Time.deltaTime/randSpeed));
		smallPoint.intensity = Mathf.Lerp(smallPoint.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
		
		// Check whether the target intensity needs changing and change it if so.
		CheckTargetIntensity();
	}
	
	void CheckTargetIntensity ()
	{
		// If the difference between the target and current intensities is less than the change margin...
		if(Mathf.Abs(targetIntensity - smallPoint.intensity) < changeMargin)
		{
			// ... if the target intensity is high...
			if(targetIntensity == highIntensity)
				// ... then set the target to low.
				targetIntensity = lowIntensity;
			else
				// Otherwise set the targer to high.
				targetIntensity = highIntensity;
		}
	}
}
