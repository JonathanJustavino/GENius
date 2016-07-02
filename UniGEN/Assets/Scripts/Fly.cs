using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

    public Transform collectable;
    public Transform startTransform;
    public Transform endTransform;
    public float moveSpeed;
    private Vector3 direction;
    private Transform destination;
    // Use this for initialization

    void Start()
    {
        SetDestination(startTransform);
    }

    void FixedUpdate()
    {
        collectable.GetComponent<Rigidbody>().MovePosition(collectable.position + direction * moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(collectable.position, destination.position) < moveSpeed * Time.fixedDeltaTime)
        {
            SetDestination(endTransform);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(endTransform.position, collectable.localScale);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(startTransform.position, collectable.localScale);
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - collectable.position).normalized;
    }


}
