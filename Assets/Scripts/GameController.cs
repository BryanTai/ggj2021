using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
	public GameObject PlayerPrefab;

	public DialogueUIController DialogueUIController;

	public GameObject CurrentNPC;

	public GameObject GameoverScreen;
	public Text ItemsReturnText;
	public Text IncorrectItemsText;
	public Text ItemsCleanedText;

	public static int ItemsReturned;
	public static int IncorrectItems;
	public static int ItemsCleaned;

	private void Awake()
	{
		GameoverScreen = GameObject.Find("GameOverScreen");
		
		ItemsReturnText = GameObject.Find("ItemsReturnedCount").GetComponent<Text>();
		IncorrectItemsText = GameObject.Find("WrongItemsGiven").GetComponent<Text>();
		ItemsCleanedText = GameObject.Find("ItemsCleaned").GetComponent<Text>();

		ItemsReturned = 0;
		IncorrectItems = 0;
		ItemsCleaned = 0;

		ItemsReturnText.text = ItemsReturned.ToString();
		IncorrectItemsText.text = IncorrectItems.ToString();
		ItemsCleanedText.text = ItemsCleaned.ToString();

		GameoverScreen.SetActive(false);

	}
	private void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if(GameoverScreen.activeSelf == false)
			{

				GameoverScreen.SetActive(true);
				ItemsReturnText.text = ItemsReturned.ToString();
				IncorrectItemsText.text = IncorrectItems.ToString();
				ItemsCleanedText.text = ItemsCleaned.ToString();
			}
			else
			{
				Application.Quit();
			}
		}
		if(Input.GetButtonDown("Submit"))
		{
			if (GameoverScreen.activeSelf == true)
			{
				GameoverScreen.SetActive(false);
			}
		}
	}
}
