using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed Brackeys tutorial on THIRD PERSON MOVEMENT
// https://www.youtube.com/watch?v=4HpC--2iowE
public class ThirdPersonMovement : MonoBehaviour
{
	public CharacterController controller;
	private Transform cameraTransform;

	public JamesAnimationController animationController;

	public float Speed = 6f;
	public float TurnSmoothTime = 0.1f;
	float turnSmoothVelocity;

	private bool isMovementEnabled;

	private void Start()
	{
		cameraTransform = FindObjectOfType<Camera>().transform;
		isMovementEnabled = true;
	}

	private void Update()
	{
		if(isMovementEnabled)
		{
			float horizontal = Input.GetAxisRaw("Horizontal"); //between -1 and 1, (A key, D key)
			float vertical = Input.GetAxisRaw("Vertical"); //between -1 and 1, (W key, S key)

			Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

			bool isRunning = direction.magnitude >= 0.1f;

			if(isRunning)
			{
				float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
				float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);
				transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
				
				Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
				controller.Move(moveDirection * Speed * Time.deltaTime);
				controller.transform.position = new Vector3(transform.position.x, PlayerSize.current_height, transform.position.z);
			}

			animationController.SetRunning(isRunning);
		}
		else
		{
			animationController.SetRunning(false);
		}
		
		//Dedicated wobble button
		if(Input.GetButtonDown("Fire2"))
		{
			animationController.TriggerPickup();
		}
	}

	public void SetMovementEnabled(bool isEnabled)
	{
		isMovementEnabled = isEnabled;
	}
}
