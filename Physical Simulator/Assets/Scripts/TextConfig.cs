using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConfig : MonoBehaviour
{
    public Text velocityText, heightText;
    public Rigidbody ball;

    float GetAbsVelocity(Vector3 vec)
    {
        return Mathf.Pow((vec.x * vec.x) + (vec.y * vec.y) + (vec.z * vec.z), 0.5f);
    }

    void Update()
    {
        velocityText.text = GetAbsVelocity(ball.velocity).ToString("0.0");
        heightText.text = (ball.transform.position.y - 0.5f).ToString("0.0");
    }
}
