using UnityEngine;
using System.Collections;

public class ShovelTool : Tool {

	private GameObject target;
	private Slot oldSlot;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			RaycastHit2D hit = new RaycastHit2D();
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			if (hit.collider == null)
				return;
			else if (hit.collider.gameObject.tag == "Slot"){
				oldSlot = hit.collider.GetComponent<Slot>();
				target = oldSlot.plant;
				oldSlot.plant = null;
			}
		}

		if (target != null){
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.transform.position = pos;
		}

		if (Input.GetButtonUp("Fire1")){
			RaycastHit2D hit = new RaycastHit2D();
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			if (hit.collider == null || hit.collider.tag != "Slot"){
				oldSlot.plant = target;
				target.transform.position = oldSlot.transform.position;
				target = null;
			}
			else{
				oldSlot = hit.collider.GetComponent<Slot>();
				oldSlot.plant = target;
				target.transform.position = oldSlot.transform.position;
				target = null;
			}
		}
	}
}
