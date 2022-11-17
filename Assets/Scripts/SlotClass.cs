using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotClass : MonoBehaviour
{
    [SerializeField] public int orderNumber;
    [SerializeField] public int blockNumber; // 1-square 2-long 3-jump 4-horizontal 5-vertical 6-empty
    [SerializeField] Sprite squareCube;
    [SerializeField] Sprite longCube;
    [SerializeField] Sprite jumpCube;
    [SerializeField] Sprite horizontalCube;
    [SerializeField] Sprite verticalCube;
    [SerializeField] Sprite emptySlot;
    [SerializeField] SlotClass UP;
    [SerializeField] SlotClass DOWN;
    [SerializeField] Image thisImage;

    private void Awake()
    {
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        switch(blockNumber)
        {
            case 1:
                thisImage.sprite = squareCube;
                thisImage.rectTransform.sizeDelta = new Vector2(30, 30);
                break;
            case 2:
                thisImage.sprite = longCube;
                thisImage.rectTransform.sizeDelta = new Vector2(84, 30);
                break;
            case 3:
                thisImage.sprite = jumpCube;
                thisImage.rectTransform.sizeDelta = new Vector2(30, 35);
                break;
            case 4:
                thisImage.sprite = horizontalCube;
                thisImage.rectTransform.sizeDelta = new Vector2(30, 30);
                break;
            case 5:
                thisImage.sprite = verticalCube;
                thisImage.rectTransform.sizeDelta = new Vector2(30, 30);
                break;
            case 6:
                thisImage.sprite = emptySlot;
                thisImage.rectTransform.sizeDelta = new Vector2(30, 30);
                break;
        }

    }

    public void ClickUP()
    {
        if(blockNumber == 6 || UP.blockNumber == 6) { return; }
        int tempBlockNumber;
        tempBlockNumber = UP.blockNumber;
        UP.blockNumber = blockNumber;
        blockNumber = tempBlockNumber;
    }

    public void ClickDOWN()
    {
        Debug.Log(DOWN.blockNumber);
        if (blockNumber == 6 || DOWN.blockNumber == 6) { return; }
        int tempBlockNumber;
        tempBlockNumber = DOWN.blockNumber;
        DOWN.blockNumber = blockNumber;
        blockNumber = tempBlockNumber;
    }
}
