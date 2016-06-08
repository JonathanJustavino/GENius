using UnityEngine;
using System.Collections;

public class PlantManager : MonoBehaviour {


	public Gene[][] seedPool { get; set; }
	public Sprite defaultPlantSprite;
	public Sprite defaultSeedSprite;
	public Material plantMaterial;
	public Color c_a;
	public Color c_A;
	public Color c_b;
	public Color c_B;

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

public struct Gene{

	public string type;
	public string value;
	public bool dominant;

}