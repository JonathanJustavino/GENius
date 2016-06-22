using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public bool routineRunning { get; private set; }

    public void move(Vector2 targetPosition, float time)
    {
        StartCoroutine(moveRoutine(targetPosition, time));

    }

    IEnumerator moveRoutine(Vector2 targetPos, float time)
    {
        routineRunning = true;
        float runTime = 0;
        Vector2 startPos = transform.position;
        while ((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, runTime);
            runTime += Time.deltaTime;
            yield return null;
        }
        routineRunning = false;
    }
}
