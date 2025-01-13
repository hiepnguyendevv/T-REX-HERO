using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    private void Start()
    {
        audioManager.pauseMusic();  // Dừng nhạc nền trước
        Invoke(nameof(PlayGameWinMusic), 0.1f); // Chờ 0.1 giây rồi phát nhạc "Game Over"
    }

    private void PlayGameWinMusic()
    {
        audioManager.playMusic(audioManager.winner);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
        
    }
}

