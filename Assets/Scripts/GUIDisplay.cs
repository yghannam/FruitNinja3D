using UnityEngine;
using System.Collections;

public class GUIDisplay : MonoBehaviour {
	
	public Texture sword;
	public Texture stars;
	public Texture hook;
	private Texture currentSelection;
	public GUISkin skinEmpty;
	public GUISkin skinEnergyFull;
	public GUISkin skinHealthFull;
	private float percentEnergy = 1.0f;
	private float percentHealth = 1.0f;
	
	// Use this for initialization
	void Start () {
		currentSelection = sword;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		// Health Bar
		GUI.Box(new Rect(25.0f, 5.0f, Screen.width/5.0f, Screen.height/30.0f), "", skinEmpty.box);
		if(percentHealth > 0.0f)
			GUI.Box(new Rect(25.0f, 5.0f, Screen.width/5.0f * percentHealth, Screen.height/30.0f), "", skinHealthFull.box);
		
		// Energy Bar
		//Debug.Log("Energy: " + Screen.width/10.0f * percentEnergy);
		GUI.Box(new Rect(25.0f, Screen.height/30.0f + 10.0f, Screen.width/10.0f, Screen.height/40.0f), "", skinEmpty.box);
		if(percentEnergy > 0.0f)
			GUI.Box(new Rect(25.0f, Screen.height/30.0f + 10.0f, Screen.width/10.0f * percentEnergy, Screen.height/40.0f), "", skinEnergyFull.box);
		
		// Current Weapon
		//GUI.Box(new Rect(25, Screen.height - Screen.height/10 - 5, Screen.height/10, Screen.height/10), "", skinEmpty.box);
		GUI.DrawTexture(new Rect(25.0f, Screen.height - Screen.height/10.0f - 5.0f, Screen.height/10.0f, Screen.height/10.0f), currentSelection, ScaleMode.StretchToFill, true, 1);
	}
	
	void UpdateEnergy(float pEnergy){
		percentEnergy = pEnergy;
	}
	
	void UpdateHealth(float pHealth){
		percentHealth = pHealth;
	}
	
	void ChangeWeapon(int selection){
		switch(selection){
			
		case 1:
			currentSelection = sword;
			break;
		
		case 2:
			currentSelection = stars;
			break;
			
		case 3:
			currentSelection = hook;
			break;
		
		default:
			break;
		}
	}
}
