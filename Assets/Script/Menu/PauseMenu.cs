using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Tham chiếu đến UI Pause Menu

    void Start()
    {
        pauseMenuUI.SetActive(false); // Đảm bảo Pause Menu ẩn khi game bắt đầu
    }

    public void GoToPauseMenu()
    {
        pauseMenuUI.SetActive(true); // Hiển thị Pause Menu
        Time.timeScale = 0; // Tạm dừng game
    }

    public void ContinueGame()
    {
        pauseMenuUI.SetActive(false); // Ẩn Pause Menu
        Time.timeScale = 1; // Tiếp tục game
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Đảm bảo game không bị dừng khi vào Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
