using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Phương thức tắt nhạc nền, dùng khi người dùng nhấn nút "Tắt nhạc" trong Settings
    public void MusicOff()
    {
        audioManager.pauseMusic();
    }

    // Phương thức bật nhạc nền, dùng khi người dùng nhấn nút "Bật nhạc" trong Settings
    public void MusicOn()
    {
        audioManager.playMusic(audioManager.background);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
