using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Settings")]
	public float moveSpeed = 5f;
	public float lookSensitivity = 2f;

	[Header("References")]
	public Transform cam; // Drag the MainCamera here

	Vector2 moveInput;
	Vector2 lookInput;
	float pitch;

	CharacterController controller;
	InputActionAsset input;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
		input = new InputActionAsset();
	}

	void OnEnable() => input.Player.Enable();
	void OnDisable() => input.Player.Disable();

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		// Look
		lookInput = input.Player.Look.ReadValue<Vector2>() * lookSensitivity;
		pitch -= lookInput.y;
		pitch = Mathf.Clamp(pitch, -90f, 90f);
		cam.localEulerAngles = new Vector3(pitch, 0, 0);
		transform.Rotate(Vector3.up * lookInput.x);

		// Move
		moveInput = input.Player.Move.ReadValue<Vector2>();
		Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
		controller.Move(move * moveSpeed * Time.deltaTime);
	}
}
