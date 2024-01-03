using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : Obj
{
    [SerializeField]
    string ItemText;
    [SerializeField]
    string Text;
    public override void OnClick()
    {
        base.OnClick();
        Inventory.Instance.AddItem(GameManager.Instance.GetItem(ItemText));
        GameManager.Instance.ShowText(Text);
        gameObject.SetActive(false);
    }
}
