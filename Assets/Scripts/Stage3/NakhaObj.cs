using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakhaObj : Obj
{
    [SerializeField]
    GameObject Snake;
    [SerializeField]
    GameObject BranchString;
    public override void OnClick()
    {
        base.OnClick();
        if (Snake.activeSelf)
            GameManager.Instance.ShowText("�׳� �ǳʰ��⿡�� �ʹ� �ִ�. ���� ���ڸ� �̿��ؼ� �ǳʰ��� �� �� ����. �ָ� �������� ���� ���ϻ��� ���δ�.");
        else if(BranchString.activeSelf)
        {
            GameManager.Instance.ShowText("�� ���ϻ� õ�� �̿��Ѵٸ� �� ���� ������ �� ���� �� ����. ");
            Inventory.Instance.AddItem(GameManager.Instance.GetItem("Nakha"));
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.ShowText("��⿡�� �ʹ� �ִ�.");
        }
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "BranchString")
        {
            if (Snake.activeSelf)
            {
                Stage3Sound.Instance.Fail();
                return;
            }
            BranchString.SetActive(true);
            Inventory.Instance.RemoveItem(item);
        }
    }
}
