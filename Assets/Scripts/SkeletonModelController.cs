using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonModelController : MonoBehaviour
{
	public GameObject Bow;
	public GameObject Necktie;
	public GameObject Moustache;

	public void ShowBow()
	{
		Bow.SetActive(true);
		Necktie.SetActive(false);
		Moustache.SetActive(false);
	}

	public void ShowNecktie()
	{
		Bow.SetActive(false);
		Necktie.SetActive(true);
		Moustache.SetActive(false);
	}

	public void ShowMoustache()
	{
		Bow.SetActive(false);
		Necktie.SetActive(false);
		Moustache.SetActive(true);
	}

	public void HideAllAccessories()
	{
		Bow.SetActive(false);
		Necktie.SetActive(false);
		Moustache.SetActive(false);
	}
}
