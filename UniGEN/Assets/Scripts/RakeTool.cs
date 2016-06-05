using UnityEngine;
using System.Collections;

public class RakeTool : Tool
{

	protected override void toolUpdate()
	{
		if(Input.GetButton("Fire1"))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

			if (hit.collider == null || hit.collider.tag != "Slot")
				return;
			else
			{
				Slot s = hit.collider.GetComponent<Slot>();
				if (s.PlantObject!= null)
					Destroy(s.PlantObject.gameObject);
			}
		}
	}
}
