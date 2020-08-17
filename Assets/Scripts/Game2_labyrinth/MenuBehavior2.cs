using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior2 : MonoBehaviour {

	public void triggerMenuBehavior(int i){

		switch (i) {
		default:
		case(0):
			SceneManager.LoadScene ("LabyrinthGame_Level1");
			break;
		case(1):
			SceneManager.LoadScene ("LabyrinthGame_Level2");
			break;
		case(2):
			SceneManager.LoadScene ("LabyrinthGame_Level3");
			break;
		case(3):
                SceneManager.LoadScene("GameList");
                break;
		}
	}
}
