using UnityEngine;
using System.Collections;

public class TutorialMenu : MonoBehaviour {

void OnGUI(){
		GUI.Box(new Rect(Screen.width / 2 - 150,Screen.height / 2 - 200, 400, 50),"Left mouse = move left");
		GUI.Box(new Rect(Screen.width / 2 - 150,Screen.height / 2 - 150, 400, 50),"Right mouse = move right");
		GUI.Box(new Rect(Screen.width / 2 - 150,Screen.height / 2 - 100, 400, 50),"Left & right mouse = jump");	
		
		if(GUI.Button(new Rect(Screen.width / 2 - 50, 450, 100,50),"Back")){Application.LoadLevel("MenuScene");}
	}
}
