using UnityEngine;
using System.Collections;

public class ShovelTool : Tool
{

	private GameObject target = null;
	private Slot slot = null;

	// Update is called once per frame
	protected override void toolUpdate()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			RaycastHit2D hit = new RaycastHit2D();
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			if (hit.collider == null)
				return;
			else if (hit.collider.gameObject.tag == "Slot")
			{
				slot = hit.collider.GetComponent<Slot>();
				if (slot.PlantObject != null)
				{
					target = slot.PlantObject;
					slot.PlantObject = null;
				}
				else target = null;
			}
		}

		if (target != null)
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.transform.position = pos;
		}

		if (Input.GetButtonUp("Fire1") && target != null)
		{
			RaycastHit2D hit = new RaycastHit2D();
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			if (hit.collider == null || hit.collider.tag != "Slot")
			{
				slot.PlantObject = target;
				target.transform.position = slot.transform.position;
				target = null;
			}
			else
			{
				Slot mySlot = hit.collider.GetComponent<Slot>();
				if (mySlot.PlantObject != null)
				{
					slot.PlantObject = target;
					target.transform.position = slot.transform.position;
					target = null;
				}
				else
				{
					slot = mySlot;
					slot.PlantObject = target;
					target.transform.position = slot.transform.position;
					target = null;
				}
			}
		}
	}
}
