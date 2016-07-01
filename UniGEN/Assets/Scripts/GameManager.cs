using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	private bool dnaActive = false;
	private bool menuActive = false;
	private int elapsedCycles;

	[SerializeField]
	private GameObject[] flowerSlots;
	[SerializeField]
	private int deadline;

	public GameObject winScreen;
	public GameObject menu;
	public GameObject dnaView;
	public GameObject gameOverView;
	private WinCondition win;
	public Text progressText;
	public Text timeLimitInfo;

	void Awake()
	{
		elapsedCycles = 0;
		win = GetComponent<WinCondition>();
		if (plantManager == null)
			plantManager = GetComponent<PlantManager>();
		if (progressText)
			progressText.text = "Fortschritt: " + win.GetProgress();
		if (timeLimitInfo)
			timeLimitInfo.text = "" + elapsedCycles + "/" + deadline;
		if (gameOverView == null)
			Debug.LogError("there is no game over available. Be sure you created a UI and applied it to the GameManager variable!");
	}

	//// Update is called once per frame
	//void Update()
	//{

	//}

	public void EndCycle()
	{
		if (deadline > 0)
			elapsedCycles++;
		Slot s;
		foreach (GameObject go in flowerSlots)
		{
			s = go.GetComponent<Slot>();
			if (s.PlantObject != null)
				s.PlantObject.GetComponent<Plant>().grow();
		}
		if (timeLimitInfo)
			timeLimitInfo.text = "" + elapsedCycles + "/" + deadline;
		if (elapsedCycles > deadline)
			gameOverView.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StartLevel(string levelName)
	{
		SceneManager.LoadScene("Scenes/" + levelName);
	}
	public void NextLevel()
	{
		
		if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex +1)
			SceneManager.LoadScene(0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void ToggleSound()
	{
		if (menu != null)
		{
			menuActive = !menuActive;
			menu.SetActive(menuActive);
		}
	}

	public void ToggleDNA(Plant flowerPower)
	{
		if (dnaView != null)
		{
			dnaActive = !dnaActive;
			dnaView.SetActive(dnaActive);
		}
	}

	public bool EpicWinning(string[] plant){
		bool positiveResult;
		switch(SceneManager.GetActiveScene().name){
		case "Level_1":
			positiveResult = win.checkForWinLevel1(plant);
			break;
		case "Level_2":
			positiveResult = win.checkForWinLevel2(plant);
			break;
		case "Level_3":
			positiveResult = win.checkForWinLevel3(plant);
			break;
		case "Level_4":
			positiveResult = win.checkForWinLevel4(plant);
			break;
		case "Level_5":
			positiveResult = win.checkForWinLevel5(plant);
			break;
		case "Level_6":
			positiveResult = win.checkForWinLevel6(plant);
			break;

		default:
			Debug.LogError("Invalid Level");
			positiveResult = false;
			break;
		}

		if(win.levelAccomplished){
			winScreen.SetActive(true);
		}
		else if (win.levelLost)
		{
			gameOverView.SetActive(true);
		}
		progressText.text = "Fortschritt: " + win.GetProgress();
		return positiveResult;
	}


}
