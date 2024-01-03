using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlankObj : Obj
{
    [SerializeField]
    SpriteRenderer Char;
    [SerializeField]
    SpriteRenderer Char2;
    [SerializeField]
    GameObject Monster;
    [SerializeField]
    GameObject Monster2;
    public override void OnClick()
    {
        base.OnClick();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        GameManager.Instance.Clickable = false;
        Char.DOFade(0, 1.2f);
        Char2.gameObject.SetActive(true);
        Char2.DOFade(1, 1.2f);
        yield return new WaitForSeconds(3f);
        if (Monster.activeSelf)
        {
            Monster.gameObject.SetActive(false);
            Monster2.gameObject.SetActive(true);
            Stage2Sound.Instance.Fail();
        }
        else
        {
            SceneManager.LoadScene("Stage3");
        }
    }
}
