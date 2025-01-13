using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeath = 100;
    public int health;
    private Animator anim;
    public Image healBar; // Đối tượng thanh máu
    public GameManagerScript gameManager;
    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Start()
    {
        health = maxHeath;
        anim = GetComponent<Animator>();
        
        if (healBar == null)
        {
            Debug.LogError("healBar chưa được gán trong Inspector!");
        }
    }

    void Update()
    {
        // Cập nhật thanh máu
        healBar.fillAmount = Mathf.Clamp((float)health / maxHeath, 0f, 1f);
        if (healBar == null)
        {
            Debug.LogError("healBar chưa được gán trong Inspector!");
        }
    }

    public void takeDamagePlayer(int damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");
        audioManager.playSFX(audioManager.takeHit);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 2f);
        

        SceneManager.LoadScene("LoseMenu");
    }
}
