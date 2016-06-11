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

	[SerializeField]
	private PlantManager plantManager;
	public PlantManager GetPlantManager{get{return plantManager;}}
	private int cycles;
	private bool dnaActive = false;
	private bool menuActive = false;

	[SerializeField]
	private GameObject[] flowerSlots;
	[SerializeField]
	private int deadline;

	public GameObject menu;
	public GameObject dnaView;


	public string currentLevel;
	public string winCondition;

	// Use this for initialization
	void Start()
	{
		cycles = deadline;
		if (currentLevel == "")
			currentLevel = "Main";
	}

	void Awake()
	{
		if (plantManager == null)
			plantManager = GetComponent<PlantManager>();
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


}
