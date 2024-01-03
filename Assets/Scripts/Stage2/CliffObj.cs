using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffObj : Obj
{
    [SerializeField]
    GameObject HardPlank;
    [SerializeField]
    GameObject Plank;
    [SerializeField]
    GameObject Monster;
    public override void OnClick()
    {
        base.OnClick();
        if(Monster.activeSelf)
           GameManager.Instance.ShowText("������� ������ �� ū ������ �Ը��� �ٽð� �ִ�. ���� �Ҿ��ѵ���");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "HardPlank")
        {
            Inventory.Instance.RemoveItem(item);
            HardPlank.SetActive(true);
            GameManager.Instance.ShowText("���� ������ �� �ִ�.");
        }
        else if (item.itemText == "DoublePlank")
        {
            Inventory.Instance.RemoveItem(item);
            Plank.SetActive(true);
            GameManager.Instance.ShowText("���� ������ �� �ִ�.");
        }
    }
}
