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
            GameManager.Instance.ShowText("그냥 건너가기에는 너무 멀다. 나무 판자를 이용해서 건너가야 할 것 같다. 멀리 찢어지지 않은 낙하산이 보인다.");
        else if(BranchString.activeSelf)
        {
            GameManager.Instance.ShowText("이 낙하산 천을 이용한다면 이 곳을 내려갈 수 있을 것 같다. ");
            Inventory.Instance.AddItem(GameManager.Instance.GetItem("Nakha"));
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.ShowText("닿기에는 너무 멀다.");
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
