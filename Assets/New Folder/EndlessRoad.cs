using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    [Header("Cấu hình con đường")]
    public Transform[] roadPlanes; // Kéo 3 tấm Plane vào danh sách này
    public float speed = 15f;       // Tốc độ di chuyển con đường
    public float planeLength = 10f; // Độ dài thực tế của 1 tấm Plane (trục Z)

    void Update()
    {
        // Tổng độ dài của cả 3 tấm gom lại
        float totalLength = planeLength * roadPlanes.Length;

        for (int i = 0; i < roadPlanes.Length; i++)
        {
            // Di chuyển Plane về phía sau theo trục Z
            roadPlanes[i].Translate(Vector3.back * speed * Time.deltaTime);

            // Kiểm tra nếu Plane bị trôi qua phía sau điểm mốc
            if (roadPlanes[i].position.z <= -planeLength)
            {
                // Đẩy vị trí Plane lên phía trước thêm một khoảng bằng tổng độ dài 3 tấm
                Vector3 newPos = roadPlanes[i].position;
                newPos.z += totalLength;
                roadPlanes[i].position = newPos;
            }
        }
    }
}