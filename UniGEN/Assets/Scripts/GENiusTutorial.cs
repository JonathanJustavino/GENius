using UnityEngine;
using UnityEngine.UI;
using System;

public class GENiusTutorial : MonoBehaviour
{

	public Button[] buttons;
	int segments = 0;

	public Text dialoge;
	public GameObject textPanel;
	public string[] segmentTexts;
	public Action continuing;

	// Use this for initialization
	void Start()
	{
		buttons[segments].onClick.AddListener(continueTutorial);
		for (int i = 1; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
		}
		if (dialoge.gameObject.activeSelf == false)
			dialoge.gameObject.SetActive(true);
		dialoge.text = segmentTexts[segments];
	}

	void continueTutorial()
	{
		buttons[segments].onClick.RemoveListener(continueTutorial);
		segments++;
		if (segments >= buttons.Length && segments >= segmentTexts.Length)
		{
			continuing = null;
			return;
		}
		else
		{
			textPanel.SetActive(true);
			if (continuing != null)
				continuing.Invoke();

			if (segments < buttons.Length)
			{
				buttons[segments].interactable = true;
				buttons[segments].onClick.AddListener(continueTutorial);
			}

			if (segments < segmentTexts.Length)
				dialoge.text = segmentTexts[segments];
		}
	}

	public void SkipTutorial()
	{
		for (int i = 0; i < buttons.Length; i++)
			buttons[i].interactable = true;
	}

	public void OK()
	{
		textPanel.SetActive(false);
	}
}
