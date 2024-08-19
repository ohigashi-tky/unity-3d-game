using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProを使用するために追加
using StarterAssets;

public class EnemyCollisionTrigger : MonoBehaviour
{
    public AudioClip endingBGM; // エンディングBGM
    public TextMeshProUGUI goalText; // TextからTextMeshProUGUIに変更

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        goalText.enabled = false; // 初めは非表示
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleGoal());
        }
    }

    private IEnumerator HandleGoal()
    {
        // クリア
        goalText.enabled = true;
        goalText.text = "死亡";

        // プレイヤーの操作を無効にする
        var playerController = GameObject.FindWithTag("Player").GetComponent<ThirdPersonController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // エンディングBGMを再生
        audioSource.clip = endingBGM;
        audioSource.Play();

        // 5秒待つ
        yield return new WaitForSeconds(5f);

        // シーンを再読み込みして最初からやり直す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
