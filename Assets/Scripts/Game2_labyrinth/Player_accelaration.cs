using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_accelaration : MonoBehaviour {

	public float speed;
	private Rigidbody rigid;
	private bool isFlat = true;
    public static float labtimer = 0;

	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
		rigid = GetComponent<Rigidbody> ();
	}

	void Update () {
        labtimer += Time.deltaTime;

		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			if (movement.x != 0 || movement.z !=0) {
				soundmanager.instance.PlaySounds ("rolling");
			}
			rigid.AddForce (movement * speed * Time.deltaTime);
		} else {
			Vector3 tilt = Input.acceleration;

			if (isFlat) {
				if (tilt.x != 0 || tilt.z != 0) {
					soundmanager.instance.PlaySounds ("rolling");
				}
				tilt = Quaternion.Euler (90, 0, 0) * tilt;
			}
			rigid.AddForce (tilt);
		}
	}
}
