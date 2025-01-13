using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float delaySecond = 2f; // Thời gian chờ trước khi chuyển scene

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            ModeSelect();
        }
    }

    void ModeSelect()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "GamePlay") // Nếu đang ở màn 1, chuyển sang Level 2
        {
            StartCoroutine(LoadAfterDelay("Level2"));
        }
        else if (currentScene == "Level2") // Nếu đang ở màn 2, hiển thị chiến thắng ngay lập tức
        {
            ShowWinScreen();
        }
    }

    IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(sceneName);
    }

    void ShowWinScreen()
    {
        SceneManager.LoadScene("WinGame"); // Chuyển ngay lập tức mà không cần chờ
    }
}
