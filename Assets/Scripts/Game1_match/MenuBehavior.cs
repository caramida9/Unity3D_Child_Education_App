using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

	public void triggerMenuBehavior(int i){

		switch (i) {
		default:
		case(0):
			SceneManager.LoadScene ("MatchGame_Level1");
			break;
		case(1):
			SceneManager.LoadScene ("MatchGame_Level2");
			break;
		case(2):
			SceneManager.LoadScene ("MatchGame_Level3");
			break;
		case(3):
                SceneManager.LoadScene("GameList");
                break;
		}
	}
}
