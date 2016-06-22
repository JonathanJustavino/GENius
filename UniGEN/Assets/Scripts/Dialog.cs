using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Dialog : MonoBehaviour
{
    public Text textArea;
    public string[] strings;
    public float speed = 0.1f;

    int stringIndex = 0;
    int characterIndex = 0;

	public Action allTextsDisplayed;
	public Action wholeTextDisplayed;

    IEnumerator DisplayTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            if (characterIndex > strings[stringIndex].Length)
            {
				if(wholeTextDisplayed != null)
					wholeTextDisplayed();
				yield break;
            }
            textArea.text = strings[stringIndex].Substring(0, characterIndex);
            characterIndex++;
			
        }
    }

	public void displayCurrentTask(int substringStart, int substringEnd)
	{
		if (substringEnd == 0)
		{
			textArea.text = strings[stringIndex];
		}
		else if (substringStart < 0 || substringStart > substringEnd)
		{
			Debug.LogError("Function was called with invalid arguments." + this.GetInstanceID());
			return;
		}
		else
		{
			textArea.text = strings[stringIndex].Substring(substringStart, substringEnd);
		}
	}

	public void startTextDisplaying()
	{
		StartCoroutine(DisplayTimer());
		StartCoroutine(checkForContinue());
	}

	IEnumerator checkForContinue()
	{
		while(true)
		{
			yield return null;
			if (Input.GetButtonDown("Fire1"))
			{
				if (characterIndex < strings[stringIndex].Length)
				{
					characterIndex = strings[stringIndex].Length;
				}
				else if (stringIndex < strings.Length)
				{
					stringIndex++;
					characterIndex = 0;
					StartCoroutine(DisplayTimer());
				}
				if (stringIndex == strings.Length)
				{
					StopCoroutine(DisplayTimer());
					if (allTextsDisplayed != null)
						allTextsDisplayed();
					break;
				}
			}
			
		}
	}

	public void SubscribeAllTextsDone(Action action)
	{
		allTextsDisplayed += action;
	}

	public void UnsubscribeAllTextsDone(Action action)
	{
		allTextsDisplayed -= action;
	}

	public void SubscribeCurrentTextWhole(Action action)
	{
		wholeTextDisplayed += action;
	}

	public void UnsubscribeCurrentTextWhole(Action action)
	{
		wholeTextDisplayed -= action;
	}

	public void ClearActions()
	{
		if (allTextsDisplayed != null)
			allTextsDisplayed = null;
		if (wholeTextDisplayed != null)
			wholeTextDisplayed = null;
	}

	public void writeStringsToText(Text t)
	{
		string wholeText = "";
		for (int i = 0; i < strings.Length; i++)
		{
			wholeText += strings[i];
			if (i-1 != strings.Length)
			{
				wholeText += "\n\n";
			}
		}

		t.text = wholeText;
	}
}

