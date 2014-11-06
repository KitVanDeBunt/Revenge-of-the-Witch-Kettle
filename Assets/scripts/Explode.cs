using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	
	int Frame;
	float SpriteFrameTimer =5;
	tk2dSprite sprite;
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
		SpriteFrameTimer = SpriteFrameTimer -105*Time.deltaTime;
		if(SpriteFrameTimer<0){
			SpriteFrameTimer=5;
			SetFrame();
		}
	}
	
	void SetFrame(){
		string FrameName;
			if(Frame<15){
				Frame++;
			}else{
				Destroy(gameObject);
			}
			FrameName= "Splode" + getMissingZeros(Frame) + Frame.ToString();
			//Debug.Log ("splode Frame: "+ Frame);
		
		sprite.SetSprite(FrameName);
	}
}
