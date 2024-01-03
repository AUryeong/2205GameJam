using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObj : Obj
{
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("신경쓰인다. 별로 가까이 다가가고 싶지 않다. ");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if (item.itemText == "PerfectKillMouse")
        {
            gameObject.SetActive(false);
            Inventory.Instance.RemoveItem(item);
            Inventory.Instance.AddItem(GameManager.Instance.GetItem("MouseKill"));
        }
    }
}
