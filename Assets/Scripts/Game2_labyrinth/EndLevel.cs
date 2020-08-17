using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player"){
            if (Player_accelaration.labtimer <= 120f)
            {
                MainMenuBehaviour.logic_stat++;
                MainMenuBehaviour.kinetic_stat+=2;
                SceneManager.LoadScene("Main Menu");
                return;
            }
            else
            {
                SceneManager.LoadScene("Main Menu");
                return;
            }
		}
	}

    public void Quit()
    {
        MainMenuBehaviour.logic_stat--;
        MainMenuBehaviour.kinetic_stat--;
        SceneManager.LoadScene("Main Menu");
    }
}
