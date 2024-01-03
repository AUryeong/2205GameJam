using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObj : Obj
{
    [SerializeField]
    GameObject WallBomb;
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("�� ���� ���� �Ѹ�ó�� �����.\n���� �� ������ �ٶ��� ������ ������ ������ �� ������ �����̵��� ���� �ִ�.\n�����̸� ġ�� �� �ִٸ� �ö� �� ������?");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "BombSwitch")
        {
            WallBomb.gameObject.SetActive(true);
            Inventory.Instance.RemoveItem(item);
        }
    }
}
