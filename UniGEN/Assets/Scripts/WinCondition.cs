using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	[SerializeField]
	private string[] condition;
	private int count = 0;
	public bool levelAccomplished{
		get{
			return count == condition.Length-1;
		}

	}

	public bool checkForWinLevel1(string [] plant){

		if(plant[2] == condition[count]){
			count++;
			return true;
		}
		return false;

	}

	/**
	 * Needs to be implemented
	 */

	public bool checkForWinLevel2(string [] plant){
		if(plant[0] == condition[0] && plant[2] == condition[2]){
			count++;
			return true;
		}
		return false;
	}

	public bool checkForWinLevel3(string [] plant){
		for(int i = 0; i < 3; i++){
			if(plant[i] != condition[i]){
				return false;
			}
		}
		return true;
	}

	public bool checkForWinLevel4(string [] plant){
		for(int i = 0; i < 3; i++){
			if(plant[i] != condition[i]){
				return false;
			}
		}
		return true;
	}

	public bool checkForWinLevel5(string [] plant){
		for(int i = 0; i < 3; i++){
			if(plant[i] != condition[i]){
				return false;
			}
		}
		return true;
	}

	public bool checkForWinLevel6(string [] plant){
		for(int i = 0; i < 3; i++){
			if(plant[i] != condition[i]){
				return false;
			}
		}
		return true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
