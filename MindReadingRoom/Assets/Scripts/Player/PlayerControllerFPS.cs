using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerFPS : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraPivot; // 카메라 부모 (Camera 직접 회전용)

    private Rigidbody rb;
    private float pitch = 0f; // 상하 회전용

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 마우스 입력
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 좌우 회전 (플레이어 전체)
        transform.Rotate(Vector3.up * mouseX);

        // 상하 회전 (카메라만)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.forward * v + transform.right * h;
        Vector3 velocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
        rb.linearVelocity = velocity;
    }
}