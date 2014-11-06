using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	
	float speed = 2;
	float PlatformTimer =1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 transform.position += new Vector3(Time.deltaTime * speed, 0, 0); // apply movement
	    
		 PlatformTimer = PlatformTimer - 500 * Time.deltaTime;
		if(PlatformTimer<0){
			PlatformTimer=1000;
			speed = -speed;
		}
}
}