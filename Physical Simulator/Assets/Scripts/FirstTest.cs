using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTest : MonoBehaviour
{
    public float vzero = 1;
    Rigidbody rgd;
    float timer, startHeight;
    float startVelocity = 0;

    float GetAbsVelocity(Vector3 vec)
    {
        return Mathf.Pow((vec.x * vec.x) + (vec.y * vec.y) + (vec.z * vec.z), 0.5f);
    }

    private void Awake()
    {
        rgd = GetComponent<Rigidbody>();
    }

    void Start()
    {
        timer = 0f;
        startHeight = transform.position.y - 0.5f;
        rgd.AddForce((1 / .7145f) * vzero * new Vector3(1, 0, 0), ForceMode.Impulse);
    }

    void Update()
    {
        if(startVelocity == 0)  startVelocity = GetAbsVelocity(rgd.velocity);

        timer += Time.deltaTime;

        Debug.Log(GetAbsVelocity(rgd.velocity));
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("시간: " + timer);
        Debug.Log("초기높이: " + startHeight.ToString("0.0"));
        Debug.Log("공식으로 구한 높이 1 : " + (0.5f * 9.81 * timer * timer).ToString("0.0"));
        Debug.Log("공식으로 구한 높이 2 : " + (2f * vzero * vzero / 9.81));
    }
}
