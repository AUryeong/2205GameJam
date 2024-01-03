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
           GameManager.Instance.ShowText("멧돼지의 형상을 한 큰 괴물이 입맛을 다시고 있다. 뭔가 불안한데…");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "HardPlank")
        {
            Inventory.Instance.RemoveItem(item);
            HardPlank.SetActive(true);
            GameManager.Instance.ShowText("이제 지나갈 수 있다.");
        }
        else if (item.itemText == "DoublePlank")
        {
            Inventory.Instance.RemoveItem(item);
            Plank.SetActive(true);
            GameManager.Instance.ShowText("이제 지나갈 수 있다.");
        }
    }
}
