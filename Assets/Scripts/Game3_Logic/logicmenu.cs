using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicmenu : MonoBehaviour {

    public void triggerMenuBehavior(int i)
    {

        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("logic1");
                break;
            case (1):
                SceneManager.LoadScene("logicm1");
                break;
            case (2):
                SceneManager.LoadScene("logich1");
                break;
            case (3):
                SceneManager.LoadScene("GameList");
                break;
        }
    }
}
