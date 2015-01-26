using UnityEngine;
using System.Collections;

public class LaserMove : MonoBehaviour {

	public Transform destination;
	public GameObject capsuleToChange;
	public Light myPointLight;
	private float speed = 50;
	private float startHue;
	private HSBColor hsbStartColor;
	private Color tmp;

	// Use this for initialization
	void Start () {
		Color startColor;
		startColor = capsuleToChange.renderer.material.color;
		startHue = SignalHandler.signalStrength * 0.3333f;
		hsbStartColor = new HSBColor(startHue, 1, 1);
		tmp = hsbStartColor.ToColor();
		capsuleToChange.renderer.material.color = new Color(tmp.r, tmp.g, tmp.b, startColor.a);
		myPointLight.color = capsuleToChange.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, destination.position, speed*Time.deltaTime);
	}
}
