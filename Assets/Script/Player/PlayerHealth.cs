using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator anim;
    public Image healBar; // Thanh máu UI
    public GameManagerScript gameManager;
    private AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManagerScript>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        if (healBar == null)
        {
            Debug.LogError("healBar chưa được gán trong Inspector!");
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healBar != null)
        {
            healBar.fillAmount = Mathf.Clamp((float)currentHealth / maxHealth, 0f, 1f);
        }
    }

    public void takeDamagePlayer(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hurt");
        audioManager?.playSFX(audioManager.takeHit);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 2f);
        SceneManager.LoadScene("LoseMenu");
    }

    public void healthPack(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth); 
        UpdateHealthUI();
    }
}
