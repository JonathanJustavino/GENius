using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	private GameObject plantObject;
	public Plant plant { get; private set; }
	public GameObject PlantObject {
		get
		{
			return plantObject;
		}
		set
		{
			Plant p = value.GetComponent<Plant>();
			if (p == null)
				return;
			else
			{
				plantObject = value;
				plant = p;
			}
		}
	}
}
