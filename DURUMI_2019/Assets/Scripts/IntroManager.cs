using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 인트로 전용 스크립트
/// </summary>

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(GameManager.LoadSceneIntro(sceneName: "Main", loadingImg: progressBar));
    }


}
