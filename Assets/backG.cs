using UnityEngine;

public class backG : MonoBehaviour
{
    public Camera cameraReference; // Đổi tên biến từ 'cam' thành 'cameraReference'

    void Start()
    {
        if (cameraReference == null)
        {
            cameraReference = Camera.main;
            if (cameraReference == null)
            {
                Debug.LogError("Không tìm thấy Camera có tag 'MainCamera'.");
            }
        }
    }

    void FixedUpdate()
    {
        if (cameraReference == null) return;

        // Sử dụng cameraReference thay vì cam
        Debug.Log("Đang sử dụng Camera: " + cameraReference.name);
    }
}
