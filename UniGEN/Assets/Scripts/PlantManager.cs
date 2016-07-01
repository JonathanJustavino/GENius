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

		//----------check for thorns-------------
		string[] dornen = genotype[0].Split('.');

		if (dornen[0] == "1" || dornen[1] == "1")
			renderer.sprite = Resources.Load<Sprite>("Rose_thorns");
		else
			renderer.sprite = defaultPlantSprite;

		// ----------choose color-----------------
		string[] colors = genotype[2].Split('.');
		string color = "";

		if (!intermediäreFärbung)
		{
			if (char.IsUpper(colors[0][0]))
				color = colors[0];
			else
				color = colors[1];
		}
		else    // intermedäreFärbung := true
		{
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
		}
		renderer.color = chooseColor(color);
	}

	public Color chooseColor(string color)
	{
		switch (color.ToLower())
		{
			case "lila":
			{
				return purple;
			}
			case "rot":
			{
				return red;
			}
			case "orange":
			{
				return orange;
			}
			case "gelb":
			{
				return yellow;
			}
			case "cyan":
			{
				return cyan;
			}
			case "blau":
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