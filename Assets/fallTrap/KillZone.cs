using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng là nhân vật
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");


        }
    }
}
