using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Obj
{
    [SerializeField]
    GameObject PullWood;
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("������ �̿��� �����̸� ġ������ ���� �ٱⰡ �ʹ� ���� ��ġ�� �ִ�. �� ���� �ö󰡴� ���� Ư���� ����� �ƴϸ� �Ұ����� ���δ�.");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "PullWood")
        {
            PullWood.gameObject.SetActive(true);
            Inventory.Instance.RemoveItem(item);
        }
    }
}
