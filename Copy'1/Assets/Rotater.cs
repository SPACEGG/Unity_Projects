using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    public float camRotateSpeed = 30f;
    public float changeDirectionSpeed = 4f;

	void Update () {
        transform.Rotate(Vector3.forward, Time.deltaTime * camRotateSpeed);

        if(Time.time >= changeDirectionSpeed)
        {
            camRotateSpeed *= -1;
            changeDirectionSpeed += Time.time;
        }
	}
}
