using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndLoad(5f, "Main Menu"));
    }

    private IEnumerator WaitAndLoad(float value, string scene)
    {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene(scene);
    }
}
