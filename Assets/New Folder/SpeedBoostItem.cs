using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    [Header("Cấu hình tăng tốc")]
    public float boostAmount = 10f; // Lượng tốc độ tăng thêm
    public float boostDuration = 5f; // Thời gian hiệu lực (giây)

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem vật thể va chạm có phải là xe không (ví dụ: tag "Player")
        if (other.CompareTag("Player"))
        {
            // Tìm đối tượng điều khiển đường chạy vô tận
            EndlessRoad endlessRoadScript = FindObjectOfType<EndlessRoad>();

            if (endlessRoadScript != null)
            {
                // Tăng tốc độ
                endlessRoadScript.speed += boostAmount;

                // Tạo hiệu ứng (ví dụ: âm thanh, hạt) - tùy chọn
                Debug.Log("Đã ăn vật phẩm! Tốc độ tăng lên: " + endlessRoadScript.speed);

                // Hủy vật phẩm khỏi cảnh
                Destroy(gameObject);

                // Khôi phục tốc độ ban đầu sau một thời gian
                endlessRoadScript.Invoke("ResetSpeed", boostDuration);
            }
        }
    }
}