using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class JamGenerator : MonoBehaviour
{
    TrailRenderer myTrail;
    EdgeCollider2D myCollider;
    GameObject activePlayer;

    public float collisionOffset = 1;

    static List<EdgeCollider2D> unusedColliders = new List<EdgeCollider2D>();

    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
        myCollider = GetValidCollider();
        activePlayer = GameObject.Find("Berrié");
    }

    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
        FollowPlayer(activePlayer);
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

    void FollowPlayer(GameObject player)
    {
        transform.position = player.transform.position + new Vector3(0, -1, 0);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        //avoid having default points at (-.5,0),(.5,0)

        for (int positionIndex = 0; positionIndex < trail.positionCount; positionIndex++)
        {
            var position = trail.GetPosition(positionIndex);
            var distance = Mathf.Abs(position.x - transform.position.x);
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