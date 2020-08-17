using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class question1 : MonoBehaviour {

    private float duration;
	// Update is called once per frame
	void Update () {
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
				soundmanager.instance.PlaySounds ("check");
                if(duration <= 2.0f)
                {
                    MainMenuBehaviour.logic_stat++;
                }
                SceneManager.LoadScene("logic2");
                break;
            case (2):
				soundmanager.instance.PlaySounds ("ohno");
                duration += 1;
                break;
            case (3):
				soundmanager.instance.PlaySounds ("ohno");
                duration += 1;
                break;
        }
    }
}
