using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("References")]
	public Transform playerCamera;

	[Header("Movement Settings")]
	public float moveSpeed = 5f;
	public float mouseSensitivity = 2f;

	[Header("Look Limits")]
	public float minPitch = -90f;
	public float maxPitch = 90f;

	private float pitch = 0f;

	void Update()
	{
		HandleLook();
		HandleMovement();
	}

	void HandleLook()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

		pitch -= mouseY;
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

		playerCamera.localEulerAngles = new Vector3(pitch, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX);
	}

	void HandleMovement()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		transform.position += move * moveSpeed * Time.deltaTime;
	}
}
