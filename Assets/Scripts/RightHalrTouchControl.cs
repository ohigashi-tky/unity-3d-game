using UnityEngine;
using Cinemachine;

public class RightHalfTouchControl : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float touchSensitivity = 0.1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // タッチが画面の右半分にあるかをチェック
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = touch.deltaPosition.x * touchSensitivity;

                    freeLookCamera.m_XAxis.Value += deltaX;
                }
            }
        }
    }
}
