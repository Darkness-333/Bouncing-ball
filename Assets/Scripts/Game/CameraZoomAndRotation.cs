using Cinemachine;
using UnityEngine;

public class CameraZoomAndRotation : MonoBehaviour {
    public float rotationSpeed = 10f;
    public float zoomSpeed = 2f;
    public float minZoom = 1f;
    public float maxZoom = 20f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer transposer;

    private string key = "CameraOffset";

    void Start() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = LoadCameraOffset();
    }

    void Update() {
        if (Input.GetMouseButton(1)) {
            OrbitAroundTarget();
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f) {
            // Получаем текущую позицию Follow Offset
            Vector3 followOffset = transposer.m_FollowOffset;

            // Вычисляем новое расстояние, изменяя длину вектора
            float distance = followOffset.magnitude;
            distance -= scrollInput * zoomSpeed;
            distance = Mathf.Clamp(distance, minZoom, maxZoom);

            // Обновляем Follow Offset на основе нового расстояния
            transposer.m_FollowOffset = followOffset.normalized * distance;
            SaveCameraOffset(transposer.m_FollowOffset);

        }
    }

    void OrbitAroundTarget() {
        float mouseX = Input.GetAxis("Mouse X");

        float angle = mouseX * rotationSpeed;

        // Вращаем камеру вокруг цели по оси Y
        transform.RotateAround(transform.position, Vector3.up, angle);

        // Обновляем Follow Offset Transposer, чтобы камера следовала за целью
        Vector3 offset = transposer.m_FollowOffset;
        offset = Quaternion.AngleAxis(angle, Vector3.up) * offset;
        transposer.m_FollowOffset = offset;
        SaveCameraOffset(transposer.m_FollowOffset);
    }

    private void SaveCameraOffset(Vector3 offset) {
        PlayerPrefs.SetFloat(key + "_x", offset.x);
        PlayerPrefs.SetFloat(key + "_y", offset.y);
        PlayerPrefs.SetFloat(key + "_z", offset.z);
    }

    private Vector3 LoadCameraOffset() {
        Vector3 offset = new Vector3();
        offset.x = PlayerPrefs.GetFloat(key + "_x", 5);
        offset.y = PlayerPrefs.GetFloat(key + "_y", 5);
        offset.z = PlayerPrefs.GetFloat(key + "_z", 0);
        return offset;
    }



}
