using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
