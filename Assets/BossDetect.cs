using UnityEngine;

public class BossDetect : MonoBehaviour
{
    public Transform player;            // Tham chiếu đến Player
    public GameObject boss;            // Tham chiếu đến Boss (boss có thể là đối tượng toàn bộ hoặc chỉ phần nào đó như sprite)

    void Start()
    {
        boss.SetActive(false);         // Boss ẩn khi bắt đầu trò chơi
    }

    
    

    // Khi Player vào vùng trigger của Boss, Boss sẽ xuất hiện
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra xem có phải Player không
        {
            boss.SetActive(true); // Hiển thị Boss
        }
    }

    // Nếu Player ra khỏi vùng trigger, bạn có thể ẩn Boss lại nếu cần
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boss.SetActive(false); // Ẩn Boss khi Player ra khỏi khu vực
        }
    }
}
