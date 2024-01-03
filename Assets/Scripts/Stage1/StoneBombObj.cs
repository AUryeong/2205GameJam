using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBombObj : Obj
{
    [SerializeField]
    GameObject Stone;
    [SerializeField]
    GameObject Human;

    public override void OnClick()
    {
        base.OnClick();
        Stage1Sound.Instance.Fail();
        gameObject.SetActive(false);
    }
}
