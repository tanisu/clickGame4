using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    
    [SerializeField] GameObject WhiteChipPrefab,BlackChipPrefab;
    BlackChipController blackChipController;
    [SerializeField] int w, h;
    [SerializeField] TargetController target;
    float chipSize;
    List<GameObject> whiteChips;
    int idx;

    void Start()
    {
        whiteChips = new List<GameObject>();
        chipSize = WhiteChipPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float xShift = w / 2 * chipSize;
        float yShift = h / 2 * chipSize;
        for(int x = 0;x < w; x++)
        {
            for(int y = 0;y < h; y++)
            {
                Vector2 pos = new Vector2(
                    x * chipSize - xShift,
                    y * chipSize - yShift
                );
                
                GameObject tmpObj = Instantiate(WhiteChipPrefab, pos, Quaternion.identity, transform);
                whiteChips.Add(tmpObj);
            }
        }

        blackChipController = Instantiate(BlackChipPrefab,transform.position,Quaternion.identity,transform)
            .GetComponent<BlackChipController>();

        idx = Random.Range(0, whiteChips.Count);
        
        blackChipController.Move(whiteChips[idx].transform.position);

        target.xLimit = whiteChips[whiteChips.Count - 1].transform.position.x;
        target.yLimit = whiteChips[whiteChips.Count - 1].transform.position.y;
        
    }

    
    void Update()
    {
        if (!blackChipController.isMoving)
        {
            idx = Random.Range(0, whiteChips.Count);
            blackChipController.Move(whiteChips[idx].transform.position);
        }

        if (blackChipController.isTargetting && Input.GetMouseButtonDown(0))
        {
            blackChipController.TurnColor();
        }
    }
}
