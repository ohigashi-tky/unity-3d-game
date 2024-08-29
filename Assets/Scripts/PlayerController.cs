using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProを使用するために追加
using StarterAssets;

public class PlayerController : MonoBehaviour
{
    public AudioClip endingBGM; // エンディングBGM
    public TextMeshProUGUI goalText; // TextからTextMeshProUGUIに変更
    private AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが "Enemy" であるかを確認する
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(HandleGameOver());
        }
    }

    // ゲームオーバー時の処理
    private IEnumerator HandleGameOver()
    {
        // クリア
        goalText.enabled = true;
        goalText.text = "死亡";

        // プレイヤーの操作を無効にする
        var playerAnimator =  GameObject.FindWithTag("Player").GetComponent<Animator>();
        var playerController = GameObject.FindWithTag("Player").GetComponent<ThirdPersonController>();
        if (playerAnimator != null && playerController != null)
        {
            playerAnimator.enabled = false;
            playerController.enabled = false;
        }

        // // エンディングBGMを再生
        // audioSource.clip = endingBGM;
        // audioSource.Play();

        // 5秒待つ
        yield return new WaitForSeconds(5f);

        // シーンを再読み込みして最初からやり直す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
