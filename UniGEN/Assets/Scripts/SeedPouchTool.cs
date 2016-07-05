using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeedPouchTool : Tool
{

	protected override void Awake()
	{
		base.Awake();
		GetComponent<Button>().interactable = false;
	}

	protected override void toolUpdate()
	{
		if (Input.GetButton("Fire1"))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

			if (hit.collider == null || hit.collider.tag != "Slot")
				return;

			Slot s = hit.collider.GetComponent<Slot>();
			if (s.PlantObject == null)
			{
				source.Play();
				GameObject g = Plant.create(GameManager.Instance.GetPlantManager.seedPool[0], GameManager.Instance.GetPlantManager.seedPool[1]);
				s.PlantObject = g;
				g.transform.parent = s.transform;
				g.transform.localPosition = Vector3.zero;
			}
		}
	}
}
