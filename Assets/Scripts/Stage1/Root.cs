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
        GameManager.Instance.ShowText("폭약을 이용해 돌덩이를 치웠지만 나무 줄기가 너무 높게 위치해 있다. 저 위로 올라가는 것은 특별한 방법이 아니면 불가능해 보인다.");
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
