using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{

	[SerializeField]
	private Gene[][] genoType;
	public Gene[][] GenoType
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
	[SerializeField]
	private bool grownUp = false;
	public bool Grown { get { return grownUp; } }


	private SpriteRenderer phenoType;
	private bool phenoActive = false;
	

	public static GameObject create(Gene[][] parent1, Gene[][] parent2)
	{
		if (parent1.Length != parent2.Length)
		{
			Debug.LogError("GenePool consists of plants with different infos (one gene-array is larger than the other).");
			return null;
		}

		GameObject o = new GameObject("Plant");

		Gene[][] newPlantData = new Gene[parent1.Length][];
		for (int i = 0; i < newPlantData.Length; i++)
		{
			newPlantData[i] = new Gene[2];

			newPlantData[i][0] = parent1[i][Random.Range(0, 2)];
			newPlantData[i][1] = parent2[i][Random.Range(0, 2)];
		}
		Plant p = o.AddComponent<Plant>();
		p.genoType = newPlantData;
		p.phenoType = o.AddComponent<SpriteRenderer>();
		p.phenoType.sprite = GameManager.Instance.GetPlantManager.getSeedImage();
		return o;
	}

	public void Start(){
		//müsste noch zugewiesen werden
		int plantNumber = 1;
		genoType = GameManager.Instance.GetPlantManager.getDefaultGenes(plantNumber);
		GameManager.Instance.GetPlantManager.getPhenotype(genoType, phenoType);
	}

	public void grow()
	{
		if (grownUp)
			return;
		GameManager.Instance.GetPlantManager.getPhenotype(genoType, GetComponent<SpriteRenderer>());
		grownUp = true;
	}
}
