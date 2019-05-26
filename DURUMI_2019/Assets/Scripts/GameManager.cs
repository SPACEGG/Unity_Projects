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

    /// <summary>
    /// 바 따라서 아래쪽 마스크 크기 조정하기, LateUpdate에다 넣으시오!
    /// </summary>
    public static void MaskMoveOnBar(RectTransform bar, RectTransform mask)
    {
        mask.sizeDelta = new Vector2(mask.sizeDelta.x, bar.anchoredPosition.y);
    }

    /// <summary>
    /// 플레이어의 상태 체크, 여기 구현해주세요!!!
    /// </summary>
    void CheckState()
    {
        switch(state){
            case GameState.GameClear:
                backText.text = "CLEARED";
                break;

            case GameState.GameClearWithSong:
                backText.text = "CLEAR ALL";
                break;

            case GameState.GameOver:
                backText.text = "GAMEOVER";
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

    protected void Update()
    {
        CheckState();
    }
    #endregion
}