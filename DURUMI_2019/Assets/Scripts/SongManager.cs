using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager의 상속을 받아 사용하는 노래관리 클래스
/// </summary>

public class SongManager : GameManager
{
    public SongScript songInfo;
    public AudioSource speaker;
    public static readonly float clearRequiredTime = 60f;

    Image progress;
    [HideInInspector]
    public static float playTime;
    int BPM;

    //테스트 코루틴, 나중에 저 밑에 있는 SincMatch쓸거임
    IEnumerator SincToAudio()
    {
        //audio.time * audio.clip.frequency = audio.timeSample(오디오 샘플값을 시간대신 사용한다)
        float timer = 60f / BPM;
        int number = 1;
        while(true)
        {
            if((int)(timer * number * speaker.clip.frequency) <= speaker.timeSamples)
            {
                //여기 밑에 두 줄을 GameManager로 옮기면 깔끔하겠다!!
                backText.text = number.ToString();
                StartCoroutine(BarProgressChange(progress, progress.fillAmount, speaker.time / songInfo.clip.length));

                number++;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// 호출 될 때마다 비트에 맞춰 바 진행, GameManager꺼를 하이딩 하려다 오버로딩됨
    /// </summary>
    IEnumerator BarProgressChange(Image img, float previous, float current)
    {
        float timer = 0;
        while(timer < 1)
        {
            img.fillAmount = Mathf.Lerp(previous, current, timer);
            timer += Time.deltaTime / (60f / BPM);
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// beatNum 번째 비트에 gameEvent 실행
    /// </summary>
    IEnumerator SincMatch(int beatNum, GameEvent gameEvent)
    {
        //audio.time * audio.clip.frequency = audio.timeSample(오디오 샘플값을 시간대신 사용한다)
        float timer = 60f / BPM;
        while (true)
        {
            if ((int)(timer * beatNum * speaker.clip.frequency) <= speaker.timeSamples)
            {
                gameEvent();
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void Awake()
    {
        #region Set SongInfo
        BPM = songInfo.BPM;
        speaker.clip = songInfo.clip;
        backgroundUp.sprite = songInfo.backgroundUp;
        backgroundDown.sprite = songInfo.backgroundDown;
        barOnColor.color = songInfo.barOnColor;
        barOffColor.color = songInfo.barOffColor;
        barLeftText.color = songInfo.barTextColor;
        barRightText.color = songInfo.barTextColor;
        backText.color = songInfo.backTextColor;
        playerCoreColor.color = songInfo.playerCoreColor;
        playerSprite.sprite = songInfo.playerSprite;
        #endregion

        #region TextSetting
        string playMin = ((int)(speaker.clip.length / 60f)).ToString("0");
        string playSec = (speaker.clip.length % 60).ToString("00");
        barRightText.text = playMin + ":" + playSec;
        #endregion

        playTime = 0f;
        progress = barOnColor.GetComponent<Image>();
        progress.fillAmount = 0;


    }

    private new void Start()
    {
        base.Start();
        speaker.Play();
        StartCoroutine(SincToAudio());
    }

    private void Update()
    {
        playTime = speaker.time;
        if(playTime == speaker.clip.length)
        {
            state = GameState.GameClearWithSong;
        }
        string playMin = ((int)(playTime / 60f)).ToString("0");
        string playSec = (playTime % 60).ToString("00.0");
        barLeftText.text = playMin + ":" + playSec;
    }
}
