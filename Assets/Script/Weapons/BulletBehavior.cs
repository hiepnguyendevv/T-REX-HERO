using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 15f;
    [SerializeField] private float destroyTime = 3f;
    private GameObject player;
    private bool isPlayer;
    public int damage = 30;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        SetStraightVelocity();
        SetDestroyTime();
       
    }


    private void SetStraightVelocity()
    {
        rb.linearVelocity = transform.right*speed;

    }
    private void SetDestroyTime()
    {
        Destroy(gameObject,destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("BossDetect"))
        {
            Debug.Log("Bullet hit Player, but not destroyed.");
            return;
        }

        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy.takeDamage(30);

            
        }
        if (hitInfo.CompareTag("Boss"))
        {
            BossHealth bossHealth = hitInfo.GetComponent<BossHealth>();
            bossHealth.takeDamage(30);


        }
        //Debug.Log(hitInfo.name);




        Destroy(gameObject);


    }
}
