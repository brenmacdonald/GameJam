using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cost : MonoBehaviour {

	public Text costLabel;
	
	private int totalCost = 0;
	
	public float TotalCost{
		get{ return totalCost;}
	}
	
	void Start(){
		totalCost = (int)PersistentLevelData.cost;
		costLabel.text = "Cost: $" + totalCost.ToString("#,##0");
	}
	
	public void AddToCost(int charge){
		totalCost += charge;
		costLabel.text = "Cost: $" + totalCost.ToString("#,##0");
	}
	
}
