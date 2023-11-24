using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TrailRenderer))]
public class PlayerTrail : MonoBehaviour
{
    TrailRenderer _tr;
    void Awake()
    {
        _tr = this.GetComponent<TrailRenderer>();
    }
    void Update()
    {
        //not ideal since it happens when clicking anywhere.
        //good enough for test/showcasing purposes
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DrawTrail());
        }
    }

    IEnumerator DrawTrail()
    {
        transform.position = GetWorldPositionFromMouse();
        _tr.Clear();
        while (true)
        {
            transform.position = GetWorldPositionFromMouse();
            if (Input.GetMouseButtonUp(0))
            {
                yield break;
            }
            yield return null;
        }
    }

    //Gets mouse position in 2dWorldSpace
    Vector2 GetWorldPositionFromMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 transformPos = Camera.main.ScreenToWorldPoint(mousePos);
        transformPos.z = 0;
        return transformPos;
    }
}