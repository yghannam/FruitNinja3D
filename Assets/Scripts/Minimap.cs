using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {
	
	private GameObject[] objectives;
//	private GameObject[] objectiveMarkers;
//	public Transform target;
//	public Transform marker;
	public Transform player;
	public Transform playermarker;
	private float height;
	private float width;
	private float forwardPlane;
	private float backPlane;
	private float rightPlane;
	private float leftPlane;
	private Rect smallRect = new Rect(0.8f, 0.0f, 0.2f, 0.35f);
	private bool largeMap = false;

	// Use this for initialization
	void Start () {
		camera.rect = smallRect;
		camera.orthographicSize = 100;
		largeMap = false;
		
		height = camera.orthographicSize;
		width = height * camera.aspect;
		
		playermarker.position = player.position + (50.0f * Vector3.up);	
		playermarker.rotation = player.rotation;
		
		forwardPlane = player.position.z + height - 5;
		backPlane = player.position.z - height + 5;
		rightPlane = player.position.x + width - 5;
		leftPlane = player.position.x - width + 5;
		
		objectives = GameObject.FindGameObjectsWithTag("Objective");
//		objectiveMarkers = GameObject.FindGameObjectsWithTag("ObjectiveMarkers");
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!largeMap){
			transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
		
			forwardPlane = player.position.z + height - 5;
			backPlane = player.position.z - height + 5;
			rightPlane = player.position.x + width - 5;
			leftPlane = player.position.x - width + 5;
			
			foreach(GameObject objective in objectives){
				GameObject marker = GameObject.Find ("Minimap"+objective.name);
				marker.transform.position = new Vector3(Mathf.Clamp(objective.transform.position.x, leftPlane, rightPlane), 
												5.0f, 
												Mathf.Clamp(objective.transform.position.z, backPlane, forwardPlane));
			}

		}
		playermarker.position = player.position + (50.0f * Vector3.up);	
		playermarker.rotation = player.rotation;
		
	}
	
	void ChangeMapSize(){
		if(largeMap){
			camera.rect = smallRect;
			camera.orthographicSize = 100;
			largeMap = false;
		}
		else{
			camera.transform.position = new Vector3(500, 100, 500);
			foreach(GameObject objective in objectives){
				GameObject marker = GameObject.Find ("Minimap"+objective.name);
				marker.transform.position = objective.transform.position;
			}
			camera.rect = new Rect(0, 0, 1, 1);
			camera.orthographicSize = 500;
			largeMap = true;
		}
	}
	
}
