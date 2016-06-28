using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	[SerializeField]
	private GameObject plantObject;
	public GameObject PlantObject
	{
		get
		{
			return plantObject;
		}
		set
		{
			plantObject = value;
		}
	}

	
}
