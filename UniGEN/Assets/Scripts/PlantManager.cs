using UnityEngine;
using System.Collections;
using System;

public class PlantManager : MonoBehaviour
{


	public string[][] seedPool { get; set; }
	public Sprite defaultPlantSprite;
	public Sprite defaultSeedSprite;
	public Material plantMaterial;
	public Color purple;
	public Color red;
	public Color orange;
	public Color yellow;
	public Color cyan;
	public Color blue;

	[SerializeField]
	private bool intermediäreFärbung = false;


	public void getPhenotype(string[] genotype, SpriteRenderer renderer)
	{
		renderer.sharedMaterial = plantMaterial;

		string[] dornen = genotype[0].Split('.');
		if (dornen[0] == "1" || dornen[1] == "1")
			renderer.sprite = Resources.Load<Sprite>("Rose_thorns");
		else
			renderer.sprite = defaultPlantSprite;

		if (!intermediäreFärbung)
		{
			string[] farben = genotype[2].Split('.');
			if (char.IsUpper(farben[0][0]))
			{
				renderer.color = chooseColor(farben[0]);
				return;
			}
			renderer.color = chooseColor(farben[1]);
			return;
		}
		// TODO: intermediäre geschichten und so. machen.
		
	}

	public Color chooseColor(string color)
	{
		switch(color.ToLower())
		{
			case "purple":
			{
				return purple;
			}
			case "red":
			{
				return red;
			}
			case "orange":
			{
				return orange;
			}
			case "yellow":
			{
				return yellow;
			}
			case "cyan":
			{
				return cyan;
			}
			case "blue":
			{
				return blue;
			}
			default:
			return Color.black;
		}
	}


	public Sprite getSeedImage()
	{
		return defaultSeedSprite;
	}



}