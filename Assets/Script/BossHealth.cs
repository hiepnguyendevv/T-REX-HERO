using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHeath = 100;
    public int health;
    private Animator anim;
    //public Image healBar; // Đối tượng thanh máu
    public GameObject finishFlag;

    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    private void Start()
    {
        health = maxHeath;
        anim = GetComponent<Animator>();
        finishFlag.SetActive(false);
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");
        audioManager.playSFX(audioManager.enemyTakeHit);
        if (health <= 0)
        {
            
            Die();
            
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 1.15f);
        finishFlag.SetActive(true);
    }
}
