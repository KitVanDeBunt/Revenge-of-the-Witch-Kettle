using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	GameObject player;
	float maxSpeedCam;
	void Start() {
		player = GameObject.Find("Player");
	}
	
	void Update(){
		maxSpeedCam = 500*Time.deltaTime;
		//transform.LookAt(new Vector3( transform.position.x, player.transform.position.y, transform.position.z ));
		float Dx = player.transform.position.x -transform.position.x;
		float Dy = player.transform.position.y -transform.position.y;
		float newXPos;
		float newYPos;
		if(Dx>maxSpeedCam){
			newXPos = transform.position.x+maxSpeedCam;
		}else if(Dx<-maxSpeedCam){
			newXPos = transform.position.x-maxSpeedCam;
		}else{
			newXPos = player.transform.position.x;
		}
		if(Dy>maxSpeedCam){
			newYPos = transform.position.y+maxSpeedCam;
		}else if(Dy<-maxSpeedCam){
			newYPos = transform.position.y-maxSpeedCam;
		}else{
			newYPos = player.transform.position.y;
		}
		
		transform.position = new Vector3( newXPos, newYPos, -50 );
	}
}