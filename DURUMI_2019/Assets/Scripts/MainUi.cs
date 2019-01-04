using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MainUi 전용 스크립트
/// </summary>

public class MainUi : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform mask;

    Image barImg;

    private void Start()
    {
        barImg = bar.transform.GetChild(1).GetComponent<Image>();
        barImg.fillAmount = 0f;
        Invoke("Change", 2f);
    }
    //처음에 애니메이션 때문에 2초 후 시작되게 Invoke 걸어둠
    void Change() { StartCoroutine(GameManager.BarProgressChange(barImg, 0f, 0.75f, 2f)); }

    void LateUpdate()
    {
        GameManager.MaskMoveOnBar(bar, mask);
    }
}
