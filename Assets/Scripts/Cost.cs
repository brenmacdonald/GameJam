using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cost : MonoBehaviour {

	public Text costLabel;
	
	private int totalCost = 0;
	
	public float TotalCost{
		get{ return totalCost;}
	}
	
	public void AddToCost(int charge){
		totalCost += charge;
		costLabel.text = "Cost: $" + totalCost.ToString("#,##0");
	}
	
}
