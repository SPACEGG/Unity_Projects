using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 이동 및 상태 관리 클래스, Player안에 넣으세요!
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    const float speed = 1.2f;

    Collider2D coreCol;
    Vector3 firstPos, firstDelta, moveDelta, mousePos, touchPos;
    Touch touch;

    private void Awake()
    {
        coreCol = GetComponent<Collider2D>();
        firstDelta = Vector3.zero;
        moveDelta = Vector3.zero;
    }

    #region Touch & Mouse
    void MouseEvent()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (firstDelta != Vector3.zero)
            {
                moveDelta = -(firstDelta - mousePos);
                transform.position = GetPosition(transform.position, moveDelta);
            }
            firstDelta = mousePos;
        }
        if (Input.GetMouseButtonUp(0)) { firstDelta = Vector3.zero; }
    }

    void TouchEvent()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (firstDelta != Vector3.zero)
            {
                moveDelta = -(firstDelta - touchPos);
                transform.position = GetPosition(transform.position, moveDelta);
            }
            firstDelta = touchPos;
        }
        if (touch.phase == TouchPhase.Ended) { firstDelta = Vector3.zero; }
    }

    /// <summary>
    /// 속도값을 곱하고, 스크린 밖으로 못벗어나는 위치값
    /// </summary>
    Vector3 GetPosition(Vector3 pos, Vector3 delta)
    {
        Vector3 coreSize = coreCol.bounds.extents;
        Vector3 minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        pos += delta * speed;
        pos.x = Mathf.Clamp(pos.x, minPos.x + coreSize.x, maxPos.x - coreSize.x);
        pos.y = Mathf.Clamp(pos.y, minPos.y + coreSize.y, maxPos.y - coreSize.y);
        return pos;
    }
    
    #endregion

    private void Update()
    {
        TouchEvent();
        MouseEvent();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            //플레이어가 부딪혔는데 클리어 시간이 지났으면 클리어플래그, 안지났으면 게임오버플래그
            if(SongManager.playTime >= SongManager.clearRequiredTime) { GameManager.state = GameManager.GameState.GameClear; }
            else { GameManager.state = GameManager.GameState.GameOver; }
        }
    }
}
