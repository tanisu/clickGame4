using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackChipController : MonoBehaviour
{
    List<GameObject> whiteChips = new List<GameObject>();
    Vector3 targetPos;
    int moveSpeed = 1;
    public bool isMoving;
    public bool isTargetting;

    public void Move(Vector3 _targetPos)
    {
        targetPos = _targetPos;
        StartCoroutine(_move());
    }

    public void TurnColor()
    {
        foreach(GameObject whiteChip in whiteChips)
        {
            whiteChip.GetComponent<SpriteRenderer>().color = Color.black;
            whiteChip.tag = "Black";
        }
        whiteChips.Clear();
        moveSpeed = Random.Range(1, 8);
    }

    IEnumerator _move()
    {
        isMoving = true;
        while((transform.position - targetPos).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("White"))
        {
            whiteChips.Add(collision.gameObject);
        }
        if (collision.CompareTag("Target"))
        {
            isTargetting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("White"))
        {
            whiteChips.Remove(collision.gameObject);
        }
        if (collision.CompareTag("Target"))
        {
            isTargetting = false;
        }
    }


}
