using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonModelController : MonoBehaviour
{
	public GameObject Regular;
	public GameObject Bow;
	public GameObject Necktie;
	public GameObject Moustache;

	public void ShowBow()
	{
		Regular.SetActive(false);
		Bow.SetActive(true);
		Necktie.SetActive(false);
		Moustache.SetActive(false);
	}

	public void ShowNecktie()
	{
		Regular.SetActive(false);
		Bow.SetActive(false);
		Necktie.SetActive(true);
		Moustache.SetActive(false);
	}

	public void ShowMoustache()
	{
		Regular.SetActive(false);
		Bow.SetActive(false);
		Necktie.SetActive(false);
		Moustache.SetActive(true);
	}

	public void HideAllAccessories()
	{
		Regular.SetActive(true);
		Bow.SetActive(false);
		Necktie.SetActive(false);
		Moustache.SetActive(false);
	}
}
