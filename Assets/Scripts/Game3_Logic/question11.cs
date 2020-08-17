using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class question11 : MonoBehaviour
{

    public InputField answer;
    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    public void check()
    {
        if (answer.text == "9")
        {
			soundmanager.instance.PlaySounds ("check");
            if (timer < 70f)
            {
                MainMenuBehaviour.logic_stat++;
            }
            SceneManager.LoadScene("logich4");
        }
        else
        {
			soundmanager.instance.PlaySounds ("ohno");
            timer+=5;
        }
    }
    public void quit()
    {
        MainMenuBehaviour.logic_stat--;
        SceneManager.LoadScene("Main Menu");
    }
}
