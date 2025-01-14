using UnityEngine;

public class upHealth : MonoBehaviour
{
    int amount;
    PlayerHealth playerH;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerH = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra va chạm với nhân vật
        {
            
            if (playerH != null)
            {
                playerH.healthPack(20); // Hồi máu với giá trị healAmount
                Destroy(gameObject); // Xóa vật phẩm sau khi sử dụng
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // Kiểm tra va chạm với nhân vật
        {

            if (playerH != null)
            {
                playerH.healthPack(20); // Hồi máu với giá trị healAmount
                Destroy(gameObject); // Xóa vật phẩm sau khi sử dụng
            }
        }
    }

}
