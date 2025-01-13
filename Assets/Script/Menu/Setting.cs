using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    // Tham chiếu đến AudioSource của nhạc nền (gán trong Inspector)
    public AudioSource bgMusic;

    // Phương thức tắt nhạc nền, dùng khi người dùng nhấn nút "Tắt nhạc" trong Settings
    public void MusicOff()
    {
        if (bgMusic != null && bgMusic.isPlaying)
        {
            bgMusic.Stop();
        }
    }

    // Phương thức bật nhạc nền, dùng khi người dùng nhấn nút "Bật nhạc" trong Settings
    public void MusicOn()
    {
        if (bgMusic != null && !bgMusic.isPlaying)
        {
            bgMusic.Play();
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
