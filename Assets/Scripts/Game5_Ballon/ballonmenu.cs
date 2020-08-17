using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballonmenu : MonoBehaviour {

    public void triggerMenuBehavior(int i)
    {

        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("ballongame");
                break;
            case (1):
                SceneManager.LoadScene("ballongame2");
                break;
            case (2):
                //SceneManager.LoadScene("");
                break;
            case (3):
                SceneManager.LoadScene("GameList");
                break;
        }
    }
}
