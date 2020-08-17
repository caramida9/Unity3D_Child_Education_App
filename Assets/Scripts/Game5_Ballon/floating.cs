using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour {

    private float speed;
	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed* Vector3.up*Time.deltaTime);
        if (transform.position.y > 6)
        {
            if (gameObject.name == "Ballon(Clone)")
            {
                ballonmanager.score--;
            }
            Destroy(gameObject);
        }
	}
    private void OnMouseDown()
    {
        if (gameObject.name == "Ballon(Clone)")
        {
			soundmanager.instance.PlaySounds ("pop");
            ballonmanager.score++;
        }
        else
        {
			soundmanager.instance.PlaySounds ("pop");
            ballonmanager.score--;
        }
        Destroy(gameObject);
    }
}
