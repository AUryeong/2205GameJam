using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperObj : Obj
{
    [SerializeField]
    string text;
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText(text);
    }
}
