using UnityEngine;
using System.Collections;

public class StartMenu: MonoBehaviour {
	
	public GUISkin mySkin;

	void Start () {
	
	}
	
	
	void OnGUI() {
		
	GUI.skin = mySkin;	
		
	GUI.Box (new Rect(Screen.width / 2 - 100, 10, 200, 50),"Revenge of the Witch kettle");	
		
	GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200,325),"Menu");
		
	if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100,100,50),"New Game")){
		Application.LoadLevel("L_1");}
	if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50,100,50),"How to play")){
		Application.LoadLevel("TutorialScene");}
	}
}
