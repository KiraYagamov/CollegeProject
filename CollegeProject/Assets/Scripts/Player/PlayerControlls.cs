using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float rotateSpeed = 0.8f;
    [SerializeField] private float gravity = 20.0f;

    private Vector3 _moveDirection = Vector3.zero;

    private CharacterController _controller;
    private Transform _playerCamera;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerCamera = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        _playerCamera.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
        if (_playerCamera.localRotation.eulerAngles.y != 0)
        {
            _playerCamera.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
        }

        _moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, _moveDirection.y,
            Input.GetAxis("Vertical") * speed);

        _moveDirection = transform.TransformDirection(_moveDirection);

        if (_controller.isGrounded)
        {
            if (Input.GetButton("Jump")) _moveDirection.y = jumpForce;
            else _moveDirection.y = 0;
        }

        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }
}
