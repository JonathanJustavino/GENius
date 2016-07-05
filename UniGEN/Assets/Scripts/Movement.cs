using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{
    public bool routineRunning { get; private set; }

	Action reachedTarget;

	public void move(Vector2 targetPosition, float duration, float delay = 0)
	{
		StartCoroutine(moveRoutine(targetPosition, duration, delay));

	}

	IEnumerator moveRoutine(Vector2 targetPos, float time, float delay)
    {
		yield return new WaitForSeconds(delay);
        routineRunning = true;
        float runTime = 0;
        Vector2 startPos = transform.position;
        while ((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, runTime / time);
            runTime += Time.deltaTime;
            yield return null;
        }

		if (reachedTarget != null)
			reachedTarget.Invoke();
		routineRunning = false;
    }

	public void SubscribeToReachAction(Action myFunc)
	{
		reachedTarget += myFunc;
	}

	public void UnsubscribeToReachedAction(Action myFunc)
	{
		reachedTarget -= myFunc;
	}
	public void ClearAction()
	{
		reachedTarget = null;
	}
}
