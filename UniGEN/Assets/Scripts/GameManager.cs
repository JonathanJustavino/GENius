using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}
	}

	private int cycles;
	private bool dnaActive = false;
	private bool menuActive = false;

	[SerializeField]
	private GameObject[] flowerSlots;
	[SerializeField]
	private int deadline;

	public GameObject menu;
	public GameObject dnaView;

	public string[][] seedPool { get; set; }
	public Sprite defaultPlantSprite;
	public Sprite defaultSeedSprite;
	public Material plantMaterial;
	public Color c_a;
	public Color c_A;
	public Color c_b;
	public Color c_B;

	public string currentLevel;
	public string winCondition;

	// Use this for initialization
	void Start()
	{
		cycles = deadline;
		if (currentLevel == "")
			currentLevel = "Main";
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void endCycle()
	{
		cycles--;
		Slot s;
		foreach (GameObject go in flowerSlots)
		{
			s = go.GetComponent<Slot>();
			if (s.PlantObject != null)
				s.PlantObject.GetComponent<Plant>().grow();
		}
	}

	public void restart()
	{
		SceneManager.LoadScene("Scenes/" + currentLevel);
	}

	public void StartLevel(string levelName)
	{
		SceneManager.LoadScene("Scenes/" + levelName);
	}

	public void quit()
	{
		Application.Quit();
	}

	public void toggleSound()
	{
		if (menu != null)
		{
			menuActive = !menuActive;
			menu.SetActive(menuActive);
		}
	}

	public void toggleDNA(Plant flowerPower)
	{
		if (dnaView != null)
		{
			dnaActive = !dnaActive;
			dnaView.SetActive(dnaActive);
		}
	}

	public void getPhenotype(string[] genotype, SpriteRenderer renderer)
	{
		renderer.sharedMaterial = plantMaterial;

		char choice = selectGene(genotype[0][0], genotype[0][1]);
		renderer.sprite = Resources.Load<Sprite>(choice.ToString());

		choice = selectGene(genotype[1][0], genotype[1][1]);
		switch(choice)
		{
			case 'A':
			{
				renderer.color = c_A;
			}
			break;
			case 'a':
			{
				renderer.color = c_a;
			}
			break;
			case 'B':
			{
				renderer.color = c_B;
			}
			break;
			case 'b':
			{
				renderer.color = c_b;
			}
			break;
		}

	}
	private char selectGene(char first, char second)
	{
		char choice;

		if (first < 'a')
		{
			if (second < 'a')
			{
				choice = Random.Range(1, 3) == 1 ? first : second;
			}
			else choice = first;
		}
		else if (second < 'a')
			choice = second;
		else choice = Random.Range(1, 3) == 1 ? first : second;

		return choice;
	}

	public Sprite getSeedImage()
	{
		return defaultSeedSprite;
	}
}
