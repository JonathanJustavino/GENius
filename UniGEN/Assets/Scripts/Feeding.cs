using UnityEngine;
using System.Collections;

public class Feeding : MonoBehaviour
{
	public GameObject[] visualProgress;
	int progress = 0;

	public void Feed(Plant p)
	{
		if (GameManager.Instance.EpicWinning(p.GenoType) && visualProgress != null && progress < visualProgress.Length)
		{
			visualProgress[progress].SetActive(false);
			progress++;
		}
		Destroy(p.gameObject);
	}
}
