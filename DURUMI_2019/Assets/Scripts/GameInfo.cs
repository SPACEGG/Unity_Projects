using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// PlayerPref이나 여러 게임 관련 전역으로 사용하는 데이터, 메서드 관련 클래스
/// </summary>
//절대로 어디다가도 넣지 말것!
public class GameSystem
{
    private static GameSystem instance = new GameSystem();
    public static GameSystem Instance { get { return instance; } }


    #region PlayerPrefs

    void SetCurrentSongName(string name) { PlayerPrefs.SetString("CurrentSongName", name); }
    void GetCurrentSongName() { PlayerPrefs.GetString("CurrentSongName", "Aftermath"); }

    #endregion

    #region Coroutines

    /// <summary>
    /// time 초동안 바를 부드럽게 옮긴다
    /// </summary>
    public IEnumerator BarProgressChange(Image barImg, float previous, float current, float time)
    {
        float timer = 0;
        while (timer < 1)
        {
            barImg.fillAmount = Mathf.Lerp(previous, current, timer);
            timer += Time.deltaTime / time;
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// 인트로에서 로딩 이미지 채우고 씬 로드
    /// </summary>
    public IEnumerator LoadSceneIntro(string sceneName, Image loadingImg)
    {
        yield return null;

        AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);
        oper.allowSceneActivation = false;
        //allowSceneActivation 이 true가 되는 순간이 바로 다음 씬으로 넘어가는 시점

        float timer = 0f;
        while (!oper.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (oper.progress >= 0.9f)      //90%이상 로딩되면 다 채우기
            {
                loadingImg.fillAmount = Mathf.Lerp(loadingImg.fillAmount, 1f, timer);

                if (loadingImg.fillAmount == 1.0f)
                    oper.allowSceneActivation = true;       //로딩 다되면 씬 전환
            }
            else
            {
                loadingImg.fillAmount = Mathf.Lerp(loadingImg.fillAmount, oper.progress, timer);
                if (loadingImg.fillAmount >= oper.progress)
                {
                    timer = 0f;
                }
            }
        }

    }

    #endregion
}
