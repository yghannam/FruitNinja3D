using UnityEngine;
using System.Collections;

public class EnergySystem : MonoBehaviour {
	
	public float energy = 5.0f;
	public float cookieEnergy = 5.0f;
	public float cakeEnergy = 100.0f;
	private GameObject GUIDisplay;
	

	// Use this for initialization
	void Start () {
		GUIDisplay = GameObject.Find("GUIDisplay");
		GUIDisplay.SendMessage("UpdateEnergy", energy/100.0f);
		gameObject.SendMessage("UpdateEnergy", energy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag == "Cookie"){
			energy = Mathf.Min(energy+cookieEnergy, 100.0f);		
			collision.gameObject.SendMessage("Disable");
			GUIDisplay.SendMessage("UpdateEnergy", energy/100.0f);
			gameObject.SendMessage("UpdateEnergy", energy);
			Debug.Log("Nom Nom");
		}
		
		else if(collision.gameObject.tag == "Cake"){
			energy = Mathf.Min(energy+cakeEnergy, 100.0f);			
			collision.gameObject.SendMessage("Disable");
			GUIDisplay.SendMessage("UpdateEnergy", energy/100.0f);
			gameObject.SendMessage("UpdateEnergy", energy);
			Debug.Log("Cake!!!");
		}		
	}
	
	void DecreaseEnergy(float amount){
		energy = Mathf.Max(energy - amount, 0.0f);
		GUIDisplay.SendMessage("UpdateEnergy", energy/100.0f);	
		gameObject.SendMessage("UpdateEnergy", energy);
	}
	
	public float ReturnEnergy(){
		return energy;	
	}
	
	public void PrintHello(){
		Debug.Log("HELLO!");	
	}
}
