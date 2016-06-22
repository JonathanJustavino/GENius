using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrushTool : Tool
{
	private int currentTarget = 1;
	[SerializeField]
	private Plant target1;
	[SerializeField]
	private Plant target2;
	private Sprite defaultSprite;

	public Image t1;
	public Image t2;
	public Button createButton;


	protected override void Awake()
	{
		base.Awake();
		if (createButton != null)
			createButton.interactable = false;
		if (t1 != null)
			defaultSprite = t1.sprite;
	}

	protected override void toolUpdate()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			RaycastHit2D hit;
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

			if (hit.collider == null || hit.collider.tag != "Slot")
				return;

			GameObject g;
			if ((g = hit.collider.GetComponent<Slot>().PlantObject) != null)
			{
				if (currentTarget == 1)
				{
					target1 = g.GetComponent<Plant>();
					if (target2 == target1)
						target1 = null;

					else 
					{
						if (t1 != null)
						{
							t1.sprite = target1.GetComponent<SpriteRenderer>().sprite;
							t1.material = target1.GetComponent<SpriteRenderer>().material;
							t1.color = target1.GetComponent<SpriteRenderer>().color;
						}
						currentTarget = 2;
					}
				}
				else if (currentTarget == 2)
				{
					target2 = g.GetComponent<Plant>();
					if (target1 == target2)
						target2 = null;

					else 
					{
						if (t2 != null)
						{
							t2.sprite = target2.GetComponent<SpriteRenderer>().sprite;
							t2.material = target2.GetComponent<SpriteRenderer>().material;
							t2.color = target2.GetComponent<SpriteRenderer>().color;
						}
						currentTarget = 1;
					}
				}

				if (target1 != null && target2 != null)
				{
					createButton.interactable = true;
				}
				else
				{
					createButton.interactable = false;
				}
			}
		}
	}

	public void ChoseTarget1()
	{
		currentTarget= 1;
	}

	public void ChoseTarget2()
	{
		currentTarget = 2;
	}


	public void CreateSeeds()
	{
		if (target1 == null || target2 == null)
			return;

		GameManager.Instance.GetPlantManager.seedPool = new string[2][];
		GameManager.Instance.GetPlantManager.seedPool[0] = target1.GenoType;
		GameManager.Instance.GetPlantManager.seedPool[1] = target2.GenoType;

		target1 = null;
		target2 = null;
		if (createButton != null)
		{
			t1.sprite = defaultSprite;
			t2.sprite = defaultSprite;
			createButton.interactable = false;
		}
	}
}
