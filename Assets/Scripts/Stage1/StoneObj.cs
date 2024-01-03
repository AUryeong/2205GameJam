using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StoneObj : Obj
{
    [SerializeField]
    GameObject StoneBomb;
    [SerializeField]
    SpriteRenderer BlackPeople;
    bool blackpeople;
    public override void OnClick()
    {
        base.OnClick();
        if (blackpeople)
        {
            SoundManager.Instance.PlaySound("ghost", SoundType.SE2);
            GameManager.Instance.ShowText("���� ���캸�� �� �������� �ٶ� �Ҹ��� �鸮�� �� ����.");
        }
        else
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
        GameManager.Instance.ShowText("������.", 1.2f);
        yield return new WaitForSeconds(1.2f);
        BlackPeople.DOFade(0, 0.3f);
        yield return new WaitForSeconds(0.3f);
        BlackPeople.gameObject.SetActive(false);
        GameManager.Instance.Clickable = true;
    }

    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if (item.itemText == "BombSwitch")
        {
            StoneBomb.gameObject.SetActive(true);
            Inventory.Instance.RemoveItem(item);
        }
    }
}
