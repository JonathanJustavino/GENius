using UnityEngine;
using System.Collections.Generic;

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

	// Use this for initialization
	void Start()
	{
		cycles = deadline;
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
			if (s.plant != null)
				s.plant.GetComponent<Plant>().grow();
		}
	}

	public void restart()
	{

	}

	public void exit()
	{

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

	public Sprite getPhenotype(string[] genotype)
	{
		return defaultPlantSprite;
	}

	public Sprite getSeedImage()
	{
		return defaultSeedSprite;
	}
}
