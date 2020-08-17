using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {

    public static soundmanager instance;
    public AudioClip[] sounds;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySounds(int i)
    {
        GetComponent<AudioSource>().clip = sounds[i];
        GetComponent<AudioSource>().Play();
    }

    public void PlaySounds(string name)
    {
        GetComponent<AudioSource>().clip = Array.Find(sounds,var => var.name==name);
        GetComponent<AudioSource>().Play();
    }
    public void ChangeVol(float i)
    {
        GetComponent<AudioSource>().volume = i;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
