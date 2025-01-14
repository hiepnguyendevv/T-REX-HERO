using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Tham chiếu đến UI Pause Menu
    private bool isPaused = false; // Trạng thái tạm dừng

    void Start()
    {
        pauseMenuUI.SetActive(false); // Đảm bảo Pause Menu ẩn khi game bắt đầu
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Nhấn phím ESC
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                GoToPauseMenu();
            }
        }
    }

    public void GoToPauseMenu()
    {
        pauseMenuUI.SetActive(true); // Hiển thị Pause Menu
        Time.timeScale = 0; // Tạm dừng game
        isPaused = true;
    }

    public void ContinueGame()
    {
        pauseMenuUI.SetActive(false); // Ẩn Pause Menu
        Time.timeScale = 1; // Tiếp tục game
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Đảm bảo game không bị dừng khi vào Main Menu
        SceneManager.LoadScene("MainMenu");
    }
}
