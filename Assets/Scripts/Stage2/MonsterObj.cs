using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterObj : Obj
{
    bool blackpeople;
    [SerializeField]
    SpriteRenderer BlackPeople;
    public override void OnClick()
    {
        if (!blackpeople)
        {
            StartCoroutine(BPFade());
        }

    }
    IEnumerator BPFade()
    {
        GameManager.Instance.Clickable = false;
        blackpeople = true;
        BlackPeople.DOFade(1, 0.5f);
        BlackPeople.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.ShowText("배고파보여.", 1.2f);
        yield return new WaitForSeconds(1.2f);
        BlackPeople.DOFade(0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        BlackPeople.gameObject.SetActive(false);
        GameManager.Instance.Clickable = true;
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "MouseKill")
        {
            gameObject.SetActive(false);
            Inventory.Instance.RemoveItem(item);
        }
    }
}
