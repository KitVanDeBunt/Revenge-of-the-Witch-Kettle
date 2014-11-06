using UnityEngine;
using System.Collections;

public class YouWon : MonoBehaviour {

void OnGUI(){
		GUI.Box(new Rect(Screen.width / 2 - 150,Screen.height / 2 - 200, 400, 50),"Congratulations! You won!");
			
		
		if(GUI.Button(new Rect(Screen.width / 2 - 50, 450, 100,50),"Play again")){Application.LoadLevel("MenuScene");}
	}
}
