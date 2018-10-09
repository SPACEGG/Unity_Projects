using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public float shrinkSpeed = 3f;

    Rigidbody2D rg;

	void Start () {
        rg = GetComponent<Rigidbody2D>();
        rg.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 15f;
	}
	
	void Update () {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if(transform.localScale.x <= 1) { Destroy(gameObject); }
	}
}
