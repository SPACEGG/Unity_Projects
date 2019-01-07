using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/// <summary>
/// 게임내에 가장 기본적인 클래스(메서드, Ui관련)
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 이벤트 작동 메서드 종류(오브젝트 생성 등)
    /// </summary>
    public delegate void GameEvent();

    public enum GameState
    {
        Playing,
        GameOver,
        GameClear,
        GameClearWithSong
    }

    #region 변수들
    public Text barLeftText, barRightText, backText;
    public Image backgroundUp, backgroundDown, barOnColor, barOffColor;
    public SpriteRenderer playerSprite, playerCoreColor;

    public static GameState state;
    #endregion

    #region Static Methods
    /// <summary>
    /// 바 따라서 아래쪽 마스크 크기 조정하기, LateUpdate에다 넣으시오!
    /// </summary>
    public static void MaskMoveOnBar(RectTransform bar, RectTransform mask)
    {
        mask.sizeDelta = new Vector2(mask.sizeDelta.x, bar.anchoredPosition.y);
    }

    /// <summary>
    /// time 초동안 바를 부드럽게 옮긴다
    /// </summary>
    public static IEnumerator BarProgressChange(Image barImg, float previous, float current, float time)
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
    public static IEnumerator LoadSceneIntro(string sceneName, Image loadingImg)
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

    void CheckState()
    {
        switch(state){
            case GameState.GameClear:
                break;

            case GameState.GameClearWithSong:
                break;

            case GameState.GameOver:
                break;

            case GameState.Playing:
                break;
        }
    }

    #region Cycle
    protected void Start()
    {
        state = GameState.Playing;
    }

    private void Update()
    {
        CheckState();
    }
    #endregion
}