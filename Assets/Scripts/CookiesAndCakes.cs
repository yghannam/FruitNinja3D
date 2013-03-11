using UnityEngine;
using System.Collections;

public class CookiesAndCakes : MonoBehaviour {
	
	private Vector3 rotateAxis;
	private float maxCountdown = 30;
	private float countdown;
	private bool isDisabled = false;
	private Vector3 origPosition;

	// Use this for initialization
	void Start () {
		origPosition = transform.position;
		
		if(gameObject.tag == "Cookie")
			rotateAxis = Vector3.up;
		
		if(gameObject.tag == "Cake")
			rotateAxis = Vector3.forward;

	}
	
	// Update is called once per frame
	void Update () {
		if(!isDisabled)
			transform.Rotate(rotateAxis * Time.deltaTime * 100);
		else{
			countdown -= Time.deltaTime;	
			if(countdown <= 0){
				isDisabled = false;
				transform.position = origPosition;
				transform.rotation = Quaternion.identity;
				if(gameObject.tag == "Cake")
					transform.eulerAngles = Vector3.right * 90;
				gameObject.AddComponent("SphereCollider");
				gameObject.AddComponent("Rigidbody");
				gameObject.renderer.enabled = true;				
			}
		}
		
		
	}
	
	void OnCollisionEnter(Collision collision){
		
	}
	
	void Disable(){
		countdown = maxCountdown;
		isDisabled = true;
		gameObject.renderer.enabled = false;
		Destroy(gameObject.rigidbody);
		Destroy(gameObject.collider);
	}
}
