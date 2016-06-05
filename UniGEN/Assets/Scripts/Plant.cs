using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{

	[SerializeField]
	private string[] genoType;
	public string[] GenoType
	{
		get
		{
			return genoType;
		}
		private set
		{
			genoType = value;
		}
	}
	private bool grownUp = false;
	public bool Grown { get { return grownUp; } }


	private SpriteRenderer phenoType;
	private bool phenoActive = false;
	

	public static GameObject create(string[] parent1, string[] parent2)
	{
		if (parent1.Length != parent2.Length)
		{
			Debug.LogError("GenePool consists of plants with different infos (one gene-array is larger than the other).");
			return null;
		}

		GameObject o = new GameObject("Plant");

		string[] newPlantData = new string[parent1.Length];
		for (int i = 0; i < newPlantData.Length; i++)
		{
			newPlantData[i] = parent1[i].Substring(Random.Range(0, 2), 1) + parent2[i].Substring(Random.Range(0, 2), 1);
		}
		Plant p = o.AddComponent<Plant>();
		p.genoType = newPlantData;
		p.phenoType = o.AddComponent<SpriteRenderer>();
		p.phenoType.sprite = GameManager.Instance.getSeedImage();
		return o;
	}


	public void grow()
	{
		if (grownUp)
			return;
		GetComponent<SpriteRenderer>().sprite = GameManager.Instance.getPhenotype(genoType);
		grownUp = true;
	}
}
