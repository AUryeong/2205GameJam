using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEggObj : Obj
{
    [SerializeField]
    GameObject HardPlank;
    [SerializeField]
    GameObject Snake;
    [SerializeField]
    GameObject Snake2;
    [SerializeField]
    GameObject Bird;
    public override void OnClick()
    {
        base.OnClick();
        if(!HardPlank.activeSelf)
           GameManager.Instance.ShowText("새알이 들어있는 둥지이다. 새가 주변을 날아다니며 지키고 있다. ");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if (item.itemText == "HardPlank")
        {
            Inventory.Instance.RemoveItem(item);
            HardPlank.SetActive(true);
        }
        else if (item.itemText == "Fruit" && HardPlank.activeSelf)
        {
            Inventory.Instance.RemoveItem(item);
            Bird.gameObject.SetActive(true);
            Snake.gameObject.SetActive(false);
            Snake2.gameObject.SetActive(true);
        }
    }
}
