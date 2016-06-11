using UnityEngine;
using System.Collections;

public class PlantManager : MonoBehaviour {


	public Gene[][][] seedPool { get; set; }
	public Sprite defaultPlantSprite;
	public Sprite defaultSeedSprite;
	public Material plantMaterial;
	public Color blue;
	public Color red;
	public Color purple;
	public Color yellow;
	public Gene[] plant1_left;
	public Gene[] plant1_right;
	public Gene[] plant2_left;
	public Gene[] plant2_right;

	public void getPhenotype(Gene[][] genotype, SpriteRenderer renderer)
	{
		renderer.sharedMaterial = plantMaterial;

		Gene choice = selectGene(genotype[0][0], genotype[0][1]);
		renderer.sprite = Resources.Load<Sprite>(choice.value);

		choice = selectGene(genotype[1][0], genotype[1][1]);
		switch(choice.value)
		{
		case "red":
			{
				renderer.color = red;
			}
			break;
		case "blue":
			{
				renderer.color = blue;
			}
			break;
		case "yellow":
			{
				renderer.color = yellow;
			}
			break;
		case "purple":
			{
				renderer.color = purple;
			}
			break;
		}

	}
	private Gene selectGene(Gene first, Gene second)
	{
		Gene choice;

		if (first.dominant)
		{
			if (second.dominant)
			{
				choice = Random.Range(1, 3) == 1 ? first : second;
			}
			else choice = first;
		}
		else if (second.dominant)
			choice = second;
		else choice = Random.Range(1, 3) == 1 ? first : second;

		return choice;
	}

	public Sprite getSeedImage()
	{
		return defaultSeedSprite;
	}


	public Gene[][] getDefaultGenes(int number){
		if(number == 1){
			Gene[][] g = new Gene[2][];
			g[0] = plant1_left;
			g[1] = plant1_right;
			return g;
		}
		if(number == 2){
			Gene[][] gg = new Gene[2][];
			gg[0] = plant2_left;
			gg[1] = plant2_right;
			return gg;
		}
		return null;
	}


}



[System.Serializable]
public struct Gene{

	public string name;
	public string value;
	public bool dominant;

}