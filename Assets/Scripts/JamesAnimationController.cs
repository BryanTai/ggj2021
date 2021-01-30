using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamesAnimationController : MonoBehaviour
{
	private const string IS_RUNNING = "IsRunning";
	private const string PICKUP_TRIGGER = "PickedUpItem";

	public Animator JamesAnimator;

	public void SetRunning(bool isRunning)
	{
		JamesAnimator.SetBool(IS_RUNNING, isRunning);
	}

	public void TriggerPickup()
	{
		JamesAnimator.SetTrigger(PICKUP_TRIGGER);
	}
}
