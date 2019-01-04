using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///버튼을 눌렀을때 작동하는 클래스 메서드들, Manager 안에 넣어둘것!
/// </summary>

public class ButtonManager : MonoBehaviour
{

    public void AppSetting()
    {
        Debug.Log("설정창");
    }

    public void Quit()
    {
        Debug.Log("게임종료!");
    }

}
