using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballonmanager2 : MonoBehaviour
{

    public GameObject ballon1;
    public GameObject ballon2;
    public GameObject ballon3;
    public static int score;
    private float time;
    private float timer;
    // Use this for initialization
    void Start()
    {
        score = 0;
        time = 0;
        timer = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            timer += 0.3f;
            int type = Random.Range(1, 4);
            if (type == 1)
            {
                GameObject clone;
                clone = Instantiate(ballon1, new Vector3(Random.Range(-5.5f, 4.5f), -3.5f, 5f), Quaternion.identity);
            }
            else if(type == 2)
            {
                GameObject clone;
                clone = Instantiate(ballon2, new Vector3(Random.Range(-5.5f, 4.5f), -3.5f, 5f), Quaternion.identity);
            }
            else
            {
                GameObject clone;
                clone = Instantiate(ballon3, new Vector3(Random.Range(-5.5f, 4.5f), -3.5f, 5f), Quaternion.identity);
            }
        }
        if (time >= 18f)
        {
            if (score > 10)
            {

                MainMenuBehaviour.kinetic_stat += 2;
                MainMenuBehaviour.space_stat++;
                SceneManager.LoadScene("Main Menu");
            }
            else
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
    public void quit()
    {
        MainMenuBehaviour.kinetic_stat--;
        SceneManager.LoadScene("Main Menu");
    }
}
