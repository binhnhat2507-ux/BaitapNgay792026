using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Cấu hình Xe & Hiệu ứng")]
    public GameObject patical; // Keo Particle System hiệu ứng khói vào đây
    public float speed = 1f;

    private bool isCheckCam = false;
    private bool isTT = false; // Trạng thái tăng tốc

    void Update()
    {
        // --- 1. ĐIỀU KHIỂN DI CHUYỂN XE KHÓA DÙNG MŨI TÊN ---
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * speed * 0.2f * Time.deltaTime * 10f);
        }

        // (Tùy chọn) Điều khiển bằng di chuyển chuột:
        // transform.position += new Vector3(Input.GetAxis("Mouse X"), 0, speed * Time.deltaTime);

        // --- 2. ĐIỀU KHIỂN TỐC ĐỘ CAMERA ---
        if (!isCheckCam)
        {
            Camera.main.transform.position += new Vector3(0, 0, speed * Time.deltaTime * 10f);
        }
        else
        {
            // Khi va chạm vật cản, camera di chuyển rất chậm
            Camera.main.transform.position += new Vector3(0, 0, 0.01f);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed = 0; // Dừng tốc độ xe khi tiếp tục nhấn tiến
            }
        }

        // --- 3. XỬ LÝ TĂNG TỐC KHI ĂN NĂNG LƯỢNG ---
        if (isTT)
        {
            speed *= 1.5f; // Tăng tốc lên 1.5 lần
            Debug.Log("Tốc độ hiện tại là: " + speed);
            isTT = false; // Reset lại để tránh bị nhân x1.5 liên tục ở mỗi Frame
        }
    }

    // --- 4. BẮT VA CHẠM VẬT LÝ KHI ĐÂM VẬT CẢN (Barrier) ---
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Barrier" || other.gameObject.CompareTag("Barrier"))
        {
            if (patical != null)
            {
                patical.SetActive(true); // Bật hiệu ứng bốc khói
            }
            isCheckCam = true; // Kích hoạt trạng thái giảm tốc camera
        }
    }

    // --- 5. BẮT VA CHẠM TRIGGER KHI ĂN NĂNG LƯỢNG (T_enemy) ---
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("T_enemy"))
        {
            Destroy(col.gameObject); // Xóa item năng lượng trên đường
            isTT = true;             // Đánh dấu để tăng tốc
        }
    }
}