using UnityEngine;
using System.Collections;

public class SignalSphere : MonoBehaviour {

	public GameObject objInfo;
	public string satParentName;
	public string satSenderName;
	//public float information = 0.3333f;
	public float lerpSpeeds = 1f;
	
	private HSBColor hsbSignalColor;
	private HSBColor hsbStartColor;
	private HSBColor hsbEndColor;
	private float alpha = 0.75f;
	
	//private float timeToDie = 3;	
	private float fltDiameter = 0.0f;	
	//private float oldTime = 0.0f;
	//private float transparencyTime = 0.1f;
	private float startHue = 0.3333f;
	//private float endHue = 0;
	private Color colHelper;
	private Color tmp;
	//private Material tmpMat;
	
	public float Hue{
		get{ return startHue;}
		set{ startHue = value;}
	}
	/*
	public float InformationLevel{
		get{ return information;}
		set{ information = value;}
	}
	*/
	// Use this for initialization
	void Start () {
		Material tmpMat;
		tmpMat = gameObject.renderer.material;
		gameObject.renderer.material = new Material(tmpMat);
		tmp = Color.blue;
		//Debug.Log ("What the hell am I looking for?" + HSBColor.FromColor(tmp).ToString());
		//timeToDie = Time.time + lerpSpeeds;
		//Debug.Log ("Time to die: " + timeToDie + " Time.time: " + Time.time);
		//startHue = information;
		//colHelper = gameObject.renderer.material.color;
		//colHelper.a = 
		startHue = SignalHandler.signalStrength * 0.3333f;
		hsbStartColor = new HSBColor(startHue, 1, 1);
		hsbEndColor = new HSBColor(0, 1, 1);
		fltDiameter = 1;
		hsbSignalColor = hsbStartColor;
		
	}
	
	// Update is called once per frame
	void Update () {
		//DO LERPS YOU MORON
		//for this something like Lerp(startSize, endSize, (Time.deltaTime + priorTime)/timeInterval)
		
		hsbSignalColor = HSBColor.Lerp(hsbSignalColor, hsbEndColor, Time.deltaTime*lerpSpeeds);
		fltDiameter = Mathf.Lerp(fltDiameter, 20, Time.deltaTime*lerpSpeeds);
		alpha = Mathf.Lerp (alpha, 0.05f, Time.deltaTime*lerpSpeeds);
		SignalHandler.signalStrength = Mathf.Lerp(SignalHandler.signalStrength, 0, lerpSpeeds*Time.deltaTime);
		tmp = hsbSignalColor.ToColor();
		gameObject.renderer.material.color = new Color(tmp.r, tmp.g, tmp.b, alpha);		
		transform.localScale = new Vector3(fltDiameter, fltDiameter, fltDiameter);
		if(SignalHandler.signalStrength <= 0.01){
			SignalHandler.signalActive = false;
			SignalHandler.DeleteSignal();
			Destroy (gameObject);
		}
		/*
		if(Time.time > oldTime){
			fltDiameter += 0.1f;
			transform.localScale = new Vector3(fltDiameter, fltDiameter, fltDiameter);			
			oldTime = Time.time + 0.002f;
		}
		if(Time.time > transparencyTime){
			colHelper = gameObject.renderer.material.color;
			//Debug.Log (startHue);
			startHue -= 0.005f;
			information -= 0.005f;
			if(startHue < endHue){
				startHue = endHue;
				information = 0;
			}
			HSBColor hsb = new HSBColor(startHue,1f,1f);
			
			//Debug.Log (hsb.ToString ());
			//Debug.Log (HSBColor.ToColor(hsb));
			tmp = HSBColor.ToColor(hsb);
			//Debug.Log(tmp.ToString());
			colHelper.a -= 0.01f;
			colHelper.r = tmp.r;
			colHelper.g = tmp.g;
			colHelper.b = tmp.b;
			gameObject.renderer.material.color = colHelper;
			transparencyTime = Time.time + 0.05f;
		}
		if(Time.time > timeToDie){
			SignalHandler.signalActive = false;
			SignalHandler.DeleteSignal();
			Destroy (gameObject);
		}
		
		if(Time.time > timeToDie){
			SignalHandler.signalActive = false;
			SignalHandler.DeleteSignal();
			Destroy (gameObject);
		}
		*/
	}	
}
