using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class question4 : MonoBehaviour {

    private float duration;
    void Update()
    {
        duration += Time.deltaTime;
    }

    public void triggerquestion(int i)
    {
        switch (i)
        {
            default:
            case (0):
				soundmanager.instance.PlaySounds ("ohno");
                duration += 1;
                break;
            case (1):
				soundmanager.instance.PlaySounds ("ohno");
                duration += 1;
                break;
            case (2):
				soundmanager.instance.PlaySounds ("check");
                if (duration <= 4.0f)
                {
                    MainMenuBehaviour.logic_stat++;
                }
                SceneManager.LoadScene("Main Menu");
                break;
            case (3):
				soundmanager.instance.PlaySounds ("ohno");
                duration += 1;
                break;
        }
    }
}
