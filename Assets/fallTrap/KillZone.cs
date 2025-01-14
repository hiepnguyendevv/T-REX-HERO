using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    private void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng là nhân vật
        if (other.CompareTag("Player"))
        {

            playerHealth.takeDamagePlayer(5);

        }
    }
}
