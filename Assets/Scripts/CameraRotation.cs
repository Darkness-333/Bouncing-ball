using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour {
    public float rotationSpeed = 10f;
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer transposer;

    void Start() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update() {
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X");

            OrbitAroundTarget(mouseX);
        }
    }

    void OrbitAroundTarget(float mouseX) {
        float angle = mouseX * rotationSpeed * Time.deltaTime;

        // Вращаем камеру вокруг цели по оси Y
        transform.RotateAround(transform.position, Vector3.up, angle);

        // Обновляем Follow Offset Transposer, чтобы камера следовала за целью
        Vector3 offset = transposer.m_FollowOffset;
        offset = Quaternion.AngleAxis(angle, Vector3.up) * offset;
        transposer.m_FollowOffset = offset;
    }


}
