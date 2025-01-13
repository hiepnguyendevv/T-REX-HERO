    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public int health = 100;                  // Máu của Enemy
        private Animator anim;                   // Animator điều khiển hoạt ảnh
        public float speedEnemy = 1f;            // Tốc độ di chuyển của Enemy
        private float distance;                  // Khoảng cách giữa Enemy và Player
        public GameObject player;                // Đối tượng Player
        public float attackRange = 5f;         // Phạm vi tấn công của Enemy
        public float detectRangle = 20f;
        private bool isAttack;                   // Trạng thái tấn công

        public PlayerHealth playerHealth;        // Tham chiếu đến PlayerHealth script

        public float attackRate = 1f;            // Tốc độ tấn công
        private float nextAttackTime = 0.5f;       // Thời gian cho lần tấn công tiếp theo
        public int damage = 1;
        private Vector3 originalScale;
        private Vector2 initialPosition; // Lưu vị trí ban đầu của Enemy

    AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }
    void Start()
        {
            anim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerHealth = player.GetComponent<PlayerHealth>();
            }
            originalScale = transform.localScale;
            initialPosition = transform.position; // Lưu vị trí ban đầu
    }

        void Update()
        {
            TargetPlayer();
        //LookAtPlayer();
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
            Destroy(gameObject, 0.5f); // Xóa Enemy sau khi chết
        }

        void TargetPlayer()
        {
            if (player == null) return;

            // Tính khoảng cách giữa Enemy và Player
            distance = Vector2.Distance(transform.position, player.transform.position);
      
            Vector2 direction = (player.transform.position - transform.position).normalized;
        Debug.Log(distance);
       
        if (distance < detectRangle)
            {
            LookAtPlayer();

            if (distance > attackRange) {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedEnemy * Time.deltaTime);

                    anim.SetBool("run", true);      // Kích hoạt hoạt ảnh chạy
                    anim.SetBool("isAttack", false); // Tắt hoạt ảnh tấn công
                    isAttack = false;
                }
                else
                {
                    // Nếu trong phạm vi tấn công, dừng di chuyển và tấn công
                    anim.SetBool("run", false);
                    anim.SetBool("isAttack", true); // Kích hoạt hoạt ảnh tấn công
                    isAttack = true;

                    // Gọi tấn công liên tục nếu đủ thời gian
                    if (Time.time >= nextAttackTime)
                    {
                        AttackPlayer();
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
                }
            
        
        }
            else
            {
                // Nếu Player ra khỏi phạm vi, Enemy quay về vị trí ban đầu
                if (Vector2.Distance(transform.position, initialPosition) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, initialPosition, speedEnemy * Time.deltaTime);
                    anim.SetBool("run", true);
                //LookAtInitialPosition();
            }
            else
                {
                    anim.SetBool("run", false);
                }
        }
            
        }

        void AttackPlayer()
        {
            if (playerHealth != null)
            {
                playerHealth.takeDamagePlayer(damage); // Gây sát thương cho Player
            }
        }

       
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player" && isAttack && Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    //public Transform player;

    public bool isFlipped = false;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;

        if (transform.position.x < player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = false;
        }
        else if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            isFlipped = true;
        }
    }
    void LookAtInitialPosition()
    {
        Vector3 flipped = transform.localScale;

        if (transform.position.x > initialPosition.x && !isFlipped) // Enemy đang ở bên trái vị trí ban đầu
        {
            flipped.x *= -1f;
            transform.localScale = flipped;
            isFlipped = true;
        }
        else if (transform.position.x < initialPosition.x && isFlipped) // Enemy đang ở bên phải vị trí ban đầu
        {
            flipped.x *= -1f;
            transform.localScale = flipped;
            isFlipped = false;
        }
    }


    void OnDrawGizmosSelected()
        {
            // Hiển thị phạm vi tấn công của Enemy trong Scene View
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectRangle);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
    }

        
    }
