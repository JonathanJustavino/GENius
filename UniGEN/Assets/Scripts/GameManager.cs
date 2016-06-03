using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager instance;

	private int cycles;
	private bool dnaActive = false;
	private bool menuActive = false;
	private List<Plant> plants;

	public int deadline;
	public GameObject[] flowerPots;
	public GameObject menu;
	public GameObject dnaView;

	public List<Plant> getPlantList{
		get{
			if(plants == null){
				plants = new List<Plant>();
			}
			return plants;
		}
	}

	public static GameManager Instance{
		get{
			if(instance == null){
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void endCycle(){
		
	}

	public void restart(){
		
	}

	public void exit(){
		
	}

	public void toggleSound(){
		if(menu != null){
			menuActive = !menuActive;
			menu.SetActive(menuActive);	
		}
	}

	public void toggleDNA(Plant flowerPower){
		if(dnaView != null){
			dnaActive = !dnaActive;
			dnaView.SetActive(dnaActive);	
		}
	}

}
