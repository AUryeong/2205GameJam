using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BreakPlankObj : Obj
{
    [SerializeField]
    SpriteRenderer Char;
    [SerializeField]
    SpriteRenderer Char2;
    public override void OnClick()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        GameManager.Instance.Clickable = false;
        Char.DOFade(0, 1.2f);
        Char2.DOFade(1, 1.2f);
        Char2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        Char2.gameObject.SetActive(false);
        Stage2Sound.Instance.Fail();
    }
}
