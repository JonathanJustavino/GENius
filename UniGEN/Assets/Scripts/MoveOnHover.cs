using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class MoveOnHover : MonoBehaviour {
    public Transform startPos;
    public Transform endPos;
    public Movement movement;
    public float animationTime = 1;

    private Collider2D col;

    void Awake()
    {
        if (movement == null)
            this.enabled = false;
        col = GetComponent<Collider2D>();
        StartCoroutine(mouseCheck());
    }
	
    IEnumerator mouseCheck()
    {
        while(true)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 15f);
            if (hit && hit.collider == col)
            {
                if (transform != endPos && !movement.routineRunning)
                    movement.move(endPos.position, animationTime);

            }
            else
            {
                if (transform != startPos && !movement.routineRunning)
                    movement.move(startPos.position, animationTime);
            }
            yield return null;
        }
    }
}
