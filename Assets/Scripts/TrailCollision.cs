using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailCollisions : MonoBehaviour
{
    TrailRenderer myTrail;
    EdgeCollider2D myCollider;

    public float collisionOffset = 1;

    static List<EdgeCollider2D> unusedColliders = new List<EdgeCollider2D>();

    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
        myCollider = GetValidCollider();
    }

    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
    }

    //Gets from unused pool or creates one if none in pool
    EdgeCollider2D GetValidCollider()
    {
        EdgeCollider2D validCollider;
        if (unusedColliders.Count > 0)
        {
            validCollider = unusedColliders[0];
            validCollider.enabled = true;
            unusedColliders.RemoveAt(0);
        }
        else
        {
            validCollider = new GameObject("TrailCollider", typeof(EdgeCollider2D)).GetComponent<EdgeCollider2D>();
        }
        return validCollider;
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        //avoid having default points at (-.5,0),(.5,0)

        for (int positionIndex = 0; positionIndex < trail.positionCount; positionIndex++)
        {
            var position = trail.GetPosition(positionIndex);
            var distance = Vector3.Distance(position, transform.position);
            if (distance > collisionOffset)
            {
                points.Add(position);
            }
        }
        collider.SetPoints(points);
    }

    void OnDestroy()
    {
        if (myCollider != null)
        {
            myCollider.enabled = false;
            unusedColliders.Add(myCollider);
        }
    }
}