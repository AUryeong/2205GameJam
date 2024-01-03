using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObj : Obj
{
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("�Ű澲�δ�. ���� ������ �ٰ����� ���� �ʴ�. ");
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
