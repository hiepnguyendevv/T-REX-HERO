using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Kéo Panel chứa thông tin (nếu bạn có) vào ô này trong Inspector
    [SerializeField] private GameObject infoPanel;

    // Gọi khi ấn nút PLAY
    public void PlayGame()
    {
        // Tên Scene phải trùng với tên Scene bạn dùng
        SceneManager.LoadScene("GamePlay");
    }

    // Gọi khi ấn nút EXIT
    public void ExitGame()
    {
        Application.Quit();
        // #if UNITY_EDITOR
        // UnityEditor.EditorApplication.isPlaying = false;
        // #endif
    }

    // Gọi khi ấn nút INFO để bật Panel

    public void Info()
    {
        SceneManager.LoadScene("INFO");
    }
    public void setting()
    {
        SceneManager.LoadScene("Setting");
    }

}
