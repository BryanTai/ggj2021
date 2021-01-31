using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreModelController : MonoBehaviour
{
	public GameObject Molar;
	public GameObject MrDoobig;

	public void ShowMolar()
	{
		Molar.SetActive(true);
		MrDoobig.SetActive(false);
	}

	public void ShowMrDoobig()
	{
		Molar.SetActive(false);
		MrDoobig.SetActive(true);
	}
}
