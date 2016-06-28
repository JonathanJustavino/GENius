using UnityEngine;
using System.Collections;

public class Feeding : MonoBehaviour
{

	public void Feed(Plant p)
	{
		GameManager.Instance.EpicWinning(p.GenoType);
		Destroy(p.gameObject);
	}
}
