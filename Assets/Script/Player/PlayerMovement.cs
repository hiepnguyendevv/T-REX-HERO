using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    private float Move;
    public float speed;
    public float jump;
    public bool isJumping;
    private bool facingRight = false;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 25f;
        jump = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(Move*speed, rb.linearVelocity.y);
        if(Move < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3 (0f, -180f, 0f);
            facingRight = false;
        }else if(Move > 0f && !facingRight)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight=true;
        }
        anim.SetFloat("Speed", Mathf.Abs(Move)); 
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJumping == false)
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(rb.linearVelocity.x,jump*10));
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")){
            isJumping = false;
        }
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }


}
