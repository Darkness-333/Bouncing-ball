using UnityEngine;

public class DragDirection : MonoBehaviour {
    private Vector3 initialMousePosition;
    private Vector3 initialObjectPosition;
    private LineRenderer lineRenderer;
    private BallMovement movement;
    private BounceCounter bounceCounter;

    private Camera mainCamera;

    Vector3 direction;

    void Start() {
        movement=GetComponent<BallMovement>();
        bounceCounter=GetComponent<BounceCounter>();

        mainCamera = Camera.main;

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")) { color = Color.blue };
        lineRenderer.enabled = false;

    }

    void OnMouseDown() {
        if (movement.isMoving || bounceCounter.GetBouncesNumber()==0) return;
        // ��������� ��������� ������� ���� � �������
        initialMousePosition = GetMouseWorldPosition();
        initialObjectPosition = transform.position;
        lineRenderer.enabled = true;

    }

    void OnMouseDrag() {
        if (movement.isMoving || bounceCounter.GetBouncesNumber() == 0) return;


        // ��������� ������� ������� ����
        Vector3 currentMousePosition = GetMouseWorldPosition();

        // ���������� ���������� Y
        initialMousePosition.y = initialObjectPosition.y;
        currentMousePosition.y = initialObjectPosition.y;

        // ��������� ����������� ������� � ����������� ���
        direction = initialMousePosition - currentMousePosition;

        // ���������� ������ � ������� LineRenderer
        lineRenderer.SetPosition(0, initialObjectPosition);
        lineRenderer.SetPosition(1, initialObjectPosition + direction.normalized*3);
    }

    void OnMouseUp() {
        if (movement.isMoving || bounceCounter.GetBouncesNumber() == 0) return;


        lineRenderer.enabled = false;
        movement.SetStartDirection(direction);
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 screenPosition=Input.mousePosition;
        // ���������� ��������� �� ������ �������
        Plane plane = new Plane(Vector3.up, initialObjectPosition);
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        if (plane.Raycast(ray, out float distance)) {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }

}

