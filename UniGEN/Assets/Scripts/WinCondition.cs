using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	[SerializeField]
	private string[] condition;
	private int count = 0;
	public bool levelAccomplished{
		get{
			return count == condition.Length;
		}

	}

	public string GetProgress()
	{
		return "" + count + "/" + condition.Length;
	}


	public bool checkForWinLevel1(string [] plant){
		if(plant[2] == condition[count]){
			count++;
			return true;
		}
		return false;
	}


	public bool checkForWinLevel2(string [] plant){
		string[] cons = condition[count].Split('.');
		string[] thorns = plant[0].Split('.');
		string[] color = plant[2].Split('.');

		if(thorns[0] == thorns[1] && thorns[0] == cons[0]
			&& (color[0] != color[1] || color[0] == cons[1])){
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
