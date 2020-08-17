using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameListMenu : MonoBehaviour {

    public void triggerMenuBehavior(int i)
    {

        switch (i)
        {
			default:
			case (0):
			    soundmanager.instance.PlaySounds ("match");
                SceneManager.LoadScene("MatchGame_Menu");
                break;
			case (1):
				soundmanager.instance.PlaySounds ("labyrinth");
                SceneManager.LoadScene("LabyrinthGame_Menu");
                break;
			case (2):
				soundmanager.instance.PlaySounds ("logic");
                SceneManager.LoadScene("logicmenu");
                break;
            case (3):
				soundmanager.instance.PlaySounds ("canvas");
                SceneManager.LoadScene("SimpleCanvas");
                break;
            case (4):
				soundmanager.instance.PlaySounds ("ballon");
                SceneManager.LoadScene("ballonmenu");
                break;
            case (5):
				soundmanager.instance.PlaySounds ("reader");
                SceneManager.LoadScene("Menu");
                break;
            case (6):
                SceneManager.LoadScene("Main Menu");
                break;
            case (7):
                Application.Quit();
                break;
        }
    }
}
