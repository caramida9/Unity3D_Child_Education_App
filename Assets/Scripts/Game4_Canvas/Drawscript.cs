using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drawscript : MonoBehaviour {

    public GameObject trailPrefab;
    private GameObject thisTrail;
    private Vector3 startPos;
    private Plane objPlane;
    private Color color=Color.black;
    private TrailRenderer m_renderer;
    private float duration;
    private int order = 0;
    // Use this for initialization 
    void Start ()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }
    // Update is called once per frame 
    void Update ()
    {
        duration += Time.deltaTime;
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                startPos = mRay.GetPoint(rayDistance);
                thisTrail = (GameObject)Instantiate(trailPrefab, startPos, Quaternion.identity);
                m_renderer=thisTrail.GetComponent<TrailRenderer>();
                m_renderer.material.color = color;
                m_renderer.sortingOrder = order;
                order++;
            }
        }
        else if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
            }
        }
        else if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                Destroy(thisTrail);
            }
        }
    }﻿
    public void changecolor(int i)
    {
        switch (i)
        {
            default:
            case (0):
                color = Color.black;
                break;
            case (1):
                color = Color.white;
                break;
            case (2):
                color = Color.red;
                duration += 5;
                break;
            case (3):
                color = Color.green;
                duration += 5;
                break;
            case (4):
                color = Color.yellow;
                duration += 5;
                break;
            case (5):
                color = Color.blue;
                duration += 5;
                break;
            case (6):
                if (duration >= 120f)
                {
                    MainMenuBehaviour.space_stat += 2;
                }
                SceneManager.LoadScene("Main Menu");
                break;
        }
    }
}
