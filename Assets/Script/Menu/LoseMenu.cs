using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    private void Start()
    {
        audioManager.pauseMusic();  // Dừng nhạc nền trước
        Invoke(nameof(PlayGameOverMusic), 0.1f); // Chờ 0.1 giây rồi phát nhạc "Game Over"
    }

    private void PlayGameOverMusic()
    {
        audioManager.playMusic(audioManager.gameOver);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();

    }
    public void Again()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
