using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    Vector3 mousePos,targetPos;
    public float xLimit;
    public float yLimit;

    void Update()
    {
        mousePos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

        targetPos.x = Mathf.Clamp(targetPos.x, -xLimit, xLimit);
        targetPos.y = Mathf.Clamp(targetPos.y, -yLimit, yLimit);

        transform.position = targetPos;
    }
}
