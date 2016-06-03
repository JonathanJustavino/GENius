using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	private string[] genoType{
		get;
		set;
	}

	private GameObject phenoType;
	private bool phenoActive = false;

	public static Plant create(Plant father, Plant mother){
		return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
