using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	int Frame = 0;
	float SpriteFrameTimer =5;
	tk2dSprite sprite;
	bool PlayPause = false;
	void Start () {
		sprite = GetComponent<tk2dSprite>();
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
	
	void Update () {
		if(PlayPause){
			SpriteFrameTimer = SpriteFrameTimer -105*Time.deltaTime;
			if(SpriteFrameTimer<0){
				SpriteFrameTimer=5;
				SetFrame();
			}
		}
	}
	
	void SetFrame(){
		string FrameName;
		if(Frame<13){
			Frame++;
		}else{
			PlayPause = false;
			Frame = 1;
		}
		FrameName= "bounce" + getMissingZeros(Frame) + Frame.ToString();
		sprite.SetSprite(FrameName);
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name=="Player"){
			PlayPause = true;
		}
    }
}


