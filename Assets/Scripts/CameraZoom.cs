using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    public float zoomSpeed = 2f;
    public float minZoom = 1f; 
    public float maxZoom = 20f;

    private CinemachineVirtualCamera virtualCamera;

    private CinemachineTransposer transposer;

    void Start() {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

    }

    void Update() {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f) {
            // �������� ������� ������� Follow Offset
            Vector3 followOffset = transposer.m_FollowOffset;

            // ��������� ����� ����������, ������� ����� �������
            float distance = followOffset.magnitude;
            distance -= scrollInput * zoomSpeed;
            distance = Mathf.Clamp(distance, minZoom, maxZoom);

            // ��������� Follow Offset �� ������ ������ ����������
            transposer.m_FollowOffset = followOffset.normalized * distance;
        }
    }

}
