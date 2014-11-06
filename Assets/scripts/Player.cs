using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool Alive;int totalColiders = 0;bool onGround;
	tk2dSprite sprite;
	int playerFrame = 0;
	string lvlName;
	string playerState = "Idle";
	bool shooting = false;
	
	void Start () {
		Alive = true;
		sprite = GetComponent<tk2dSprite>();
		sprite.SetSprite("Idle0001");
		lvlName = Application.loadedLevelName;
	}
	
	string getMissingZeros(int Interger){
		string intTostring = Interger.ToString();
		int lenght = intTostring.Length;
		int missingZerows = 4-lenght;
	switch (missingZerows){
		case 0:
			return "";
			break;
		case 1:
			return "0";
			break;
		case 2:
			return "00";
			break;
		case 3:
			return "000";
			break;
		case 4:
			return "0000";
			break;
		default:
			return "";
			break;
		}
	}
	
	void SetFramePlayer(){
		string FrameName;
		switch(playerState){
		case "walkLeft":
			if(playerFrame<20){
				playerFrame++;
			}else{
				playerFrame = 1;
			}
			FrameName= "WalkLeft" + getMissingZeros(playerFrame) +  playerFrame.ToString();
			break;
		case "walkRight":
			if(playerFrame<20){
				playerFrame++;
			}else{
				playerFrame = 1;
			}
			FrameName= "WalkRight" + getMissingZeros(playerFrame) + playerFrame.ToString();
			break;
		case "Launch":
			if(playerFrame<20){
				playerFrame++;
			}else{
				playerFrame = 1;
			}
			FrameName= "launch" + getMissingZeros(playerFrame) + playerFrame.ToString();
			break;
		case "Idle":
			if(playerFrame<20){
				playerFrame++;
			}else{
				playerFrame = 1;
			}
			FrameName= "Idle" + getMissingZeros(playerFrame) + playerFrame.ToString();
			break;
		default:
			FrameName = "Name_error";
			break;
		}
		sprite.SetSprite(FrameName);
	}
	
	bool RightButtonDown = false;
	bool LeftButtonDown = false;
	//bool MiddelButtonDown = false;
	float SpriteFrameTimer =1;
	void Update () {
		//shoot
		if(shooting){
			Debug.Log ("shoot");
			//GameObject instance = Instantiate(Resources.Load("Bullit"));
			Vector3 bullitPosition = new Vector3(transform.position.x,transform.position.y+100,transform.position.z);
			GameObject instance = Instantiate(Resources.Load("Bullit"), bullitPosition, Quaternion.identity) as GameObject;	
		}
		
		
		// Death
		if(Alive == false){Application.LoadLevel(Application.loadedLevel);}

		// end Death
		
		//Sprite refresh timer
		SpriteFrameTimer = SpriteFrameTimer -105*Time.deltaTime;
		if(SpriteFrameTimer<0){
			SpriteFrameTimer=10;
			SetFramePlayer();
		}
		
		//input
		if(Input.GetMouseButtonDown(0)){
			LeftButtonDown = true;
		}
		if(Input.GetMouseButtonDown(1)){
			RightButtonDown = true;
		}
		if(Input.GetMouseButtonDown(2)){
			shooting = true;
		}
		if(Input.GetKeyDown("n")){
			LeftButtonDown = true;
		}
		if(Input.GetKeyDown("m")){
			RightButtonDown = true;
		}
		
		if(Input.GetMouseButtonUp(0)){
			LeftButtonDown = false;
		}
		if(Input.GetMouseButtonUp(1)){
			RightButtonDown = false;
		}
		if(Input.GetMouseButtonUp(2)){
			shooting = false;
		}
		if(Input.GetKeyUp("n")){
			LeftButtonDown = false;
		}
		if(Input.GetKeyUp("m")){
			RightButtonDown = false;
		}
		
		float currentXForce = rigidbody.velocity.x/Time.deltaTime;
		//Debug.Log ("xforce: "+currentXForce);
		
		if(RightButtonDown&&LeftButtonDown){
			if(onGround){
				onGround=false;
				Debug.Log("jump");
				rigidbody.AddForce(0,40000,0); ///jump
				playerState ="Launch";
				
				Instantiate (Resources.Load ("Explosion"), new Vector3(transform.position.x, transform.position.y, -30),Quaternion.identity);
			}
		}else if(RightButtonDown){
			float newXForce = (28000*Time.deltaTime)+currentXForce;
			//Debug.Log("newForce: "+newXForce);
			if(newXForce<25000&&newXForce>=0){
				rigidbody.AddForce(28000*Time.deltaTime,0,0);
			}else if(newXForce<0){
				if(onGround){
					rigidbody.AddForce(200000*Time.deltaTime,0,0);
				}else{
					rigidbody.AddForce(28000*Time.deltaTime,0,0);
				}
			}
			//sprite.FlipX = false;
			if(onGround){
				playerState = "walkRight";
			}else{
				playerState = "Launch";	
			}
		}else if(LeftButtonDown){
			float newXForce = (-14000*Time.deltaTime)+currentXForce;
			//Debug.Log("newForce: "+newXForce);
			if(newXForce>-25000&&newXForce<=0){
				rigidbody.AddForce(-28000*Time.deltaTime,0,0);
			}else if(newXForce>0){
				if(onGround){
					rigidbody.AddForce(-200000*Time.deltaTime,0,0);
				}else{
					rigidbody.AddForce(-28000*Time.deltaTime,0,0);
				}
			}
			//sprite.FlipX = true;
			if(onGround){
				playerState = "walkLeft";
			}else{
				playerState = "Launch";	
			}
		}else{
			if(onGround){
				playerState = "Idle";	
			}else{
				playerState ="Launch";
			}
		}
		if(!onGround){
			rigidbody.AddForce(0,-40000*Time.deltaTime,0);//extra grafity	
		}
	}
	
	//colision
	void OnCollisionEnter(Collision collision) {
		totalColiders+=1;
        if(collision.contacts[0].normal.y > 0.8f)
		{
			onGround=true;
		}
		if(collision.gameObject.name=="Die"){
			Alive = false;
		}else if(collision.gameObject.name=="NextLevel"){
			if(lvlName=="L_1"){
				Application.LoadLevel("L_2");
			}else{
				Application.LoadLevel("YouWonScene");
			}
		}else if(collision.gameObject.name=="Jump"){//lounchpad
			float yForce = collision.contacts[0].normal.y;
			float xForce = collision.contacts[0].normal.x;
			rigidbody.AddForce(xForce*44000,yForce*64000,0);
		}
        //if (collision.relativeVelocity.magnitude > 2)
            //Debug.Log ("play");
		
    }

	
	void OnCollisionExit(Collision collision){
		totalColiders-=1;
		if(totalColiders<=0){
			onGround=false;
		}
	}
}