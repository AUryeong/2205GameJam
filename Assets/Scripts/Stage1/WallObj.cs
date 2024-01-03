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
        GameManager.Instance.ShowText("이 곳은 나무 뿌리처럼 생겼다.\n왼쪽 벽 위에는 바람이 나오는 구멍이 있지만 이 구멍은 돌덩이들이 막고 있다.\n돌덩이를 치울 수 있다면 올라갈 수 있을까?");
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
