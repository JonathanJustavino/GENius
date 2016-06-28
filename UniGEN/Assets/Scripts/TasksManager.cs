using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TasksManager : MonoBehaviour
{
	public Movement horsePos;
	public Dialog dialog;

	public Text newTextArea;

	private Vector3 startPos;

	void Awake()
	{
		if (horsePos == null || dialog == null || newTextArea == null)
		{
			Debug.LogError("Please assign the public variables of the tasksmanager manually");
			this.gameObject.SetActive(false);
			return;
		}

		startPos = horsePos.transform.position;
		horsePos.SubscribeToReachAction(dialog.StartTextDisplaying);
		horsePos.move((Vector2) horsePos.transform.position + Vector2.right, 0.25f, 0.5f);

		dialog.SubscribeAllTextsDone(() => horsePos.UnsubscribeToReachedAction(dialog.StartTextDisplaying));
		dialog.SubscribeAllTextsDone(moveHorseBack);
		dialog.SubscribeAllTextsDone(() => dialog.transform.parent.gameObject.SetActive(false));

		
	}

	void moveHorseBack()
	{
		horsePos.move(startPos, 0.25f);
		dialog.UnsubscribeAllTextsDone(moveHorseBack);
		horsePos.SubscribeToReachAction(lastStep);
	}
	void lastStep()
	{
		unsubscribeAll();
		dialog.writeStringsToText(newTextArea);
	}
	void unsubscribeAll()
	{
		dialog.ClearActions();
		horsePos.ClearAction();
	}
}
