using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tool : MonoBehaviour
{
	private Image myImage;

	public bool isActive { get; private set; }


	public Sprite defaultImage;
	public Sprite activeImage;

	public Texture2D cursor;
	public Texture2D defaultGameCursor { get; set; }
	public Vector2 cursorHotSpot;

	public GameObject[] popUps;

	protected virtual void Awake()
	{
		myImage = GetComponent<Image>();
		if (defaultImage == null)
			defaultImage = myImage.sprite;
	}

	public void SetActive()
	{
		isActive = true;
		if (activeImage != null)
			myImage.sprite = activeImage;
		Cursor.SetCursor(cursor, cursorHotSpot, CursorMode.Auto);
		foreach (GameObject go in popUps)
		{
			go.SetActive(true);
		}
	}

	public void Reset()
	{
		isActive = false;
		myImage.sprite = defaultImage;
		foreach(GameObject go in popUps)
		{
			go.SetActive(false);
		}
	}


	void Update()
	{
		if (isActive)
		{
			if (Input.GetButton("Fire2"))
			{
				Reset();
				Cursor.SetCursor(defaultGameCursor, cursorHotSpot, 0);
			}
			else toolUpdate();
		}
	}

	protected virtual void toolUpdate()
	{

	}

}
