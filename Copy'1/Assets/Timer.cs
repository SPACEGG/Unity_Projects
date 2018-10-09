using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () {
        string currentTime = (Mathf.Round(Time.time * 100f) / 100f).ToString();
        text.text = "Time: " + currentTime + "초";

    }
}
