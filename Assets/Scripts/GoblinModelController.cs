using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinModelController : MonoBehaviour
{
	public GameObject Hornblin;
	public GameObject Gulum;

	public void ShowHornblin()
	{
		Hornblin.SetActive(true);
		Gulum.SetActive(false);
	}

	public void ShowGulum()
	{
		Hornblin.SetActive(false);
		Gulum.SetActive(true);
	}
}
