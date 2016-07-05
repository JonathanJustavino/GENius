using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

	[SerializeField]
	private string[] condition;
	private int count = 0;
	public bool levelAccomplished
	{
		get
		{
			return count == condition.Length;
		}

	}
	public bool levelLost
	{
		get
		{
			return count < 0;
		}
	}

	public string GetProgress()
	{
		int level = SceneManager.GetActiveScene().buildIndex;
		string start = "";
		switch (level)
		{
			case 1:
			{
				start = "rot; ";
			}
			break;
			case 2:
			{
				start = "orange, ohne Dornen; ";
			}
			break;
			case 3:
			{
				start = "gelb; ";
			}
			break;
			case 4:
			{
				start = condition[count] + "; ";
			}
			break;
			case 5:
			{
				start = "rezessiv; ";
			}
			break;
			case 6:
			{

			}
			break;

		}
		return start + count + "/" + condition.Length;
	}


	public bool checkForWinLevel1(string[] plant)
	{
		if (plant[2] == condition[count])
		{
			count++;
			return true;
		}
		return false;
	}


	public bool checkForWinLevel2(string[] plant)
	{
		string[] cons = condition[count].Split('.');
		string[] thorns = plant[0].Split('.');
		string[] color = plant[2].Split('.');

		if (thorns[0] == thorns[1] && thorns[0] == cons[0]
			&& (color[0] != color[1] || color[0] == cons[1]))
		{
			count++;
			return true;
		}
		count--;
		return false;
	}


	public bool checkForWinLevel3(string[] plant)
	{
		if (plant[2] == condition[count])
		{
			count++;
			return true;
		}
		return false;
	}


	public bool checkForWinLevel4(string[] plant)
	{
		string[] colors = plant[2].Split('.');
		string color;

		if (colors[0] == colors[1])
			color = colors[0];
		else
		{
			if (colors[0] == "rot")
			{
				color = colors[1] == "blau" ? "lila" : "orange";
			}
			else if (colors[1] == "rot")
			{
				color = colors[0] == "blau" ? "lila" : "orange";
			}
			else color = "cyan";
		}

		if (color == condition[count])
		{
			count++;
			return true;
		}
		return false;
	}


	public bool checkForWinLevel5(string[] plant)
	{
		string[] colors = plant[2].Split('.');
		if (!char.IsUpper(colors[0][0]) && !char.IsUpper(colors[1][0]))
		{
			count++;
			return true;
		}
		count--;
		return false;
	}


	public bool checkForWinLevel6(string[] plant)
	{
		for (int i = 0; i < 3; i++)
		{
			if (plant[i] != condition[i])
			{
				return false;
			}
		}
		return true;
	}
}
