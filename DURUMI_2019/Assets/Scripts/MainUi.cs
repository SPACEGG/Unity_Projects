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

    void LateUpdate()
    {
        GameManager.MaskMoveOnBar(bar, mask);
    }
}
