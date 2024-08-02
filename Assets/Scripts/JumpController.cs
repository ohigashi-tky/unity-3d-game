using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    public Button jumpButton;
    public GameObject player; // プレイヤーのGameObjectを指定
    private Rigidbody rb;
    public float jumpPower = 3.0f;

    void Start()
    {
        //
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (rb != null && Mathf.Approximately(rb.velocity.y, 0))
        {
            // Unityにスペースキーが押されたと同じように伝える
            Input.GetButtonDown("Jump");
        }
    }
}
