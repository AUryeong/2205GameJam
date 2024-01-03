using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeObj : Obj
{
    public override void OnClick()
    {
        GameManager.Instance.ShowText("뱀이 길을 가로막고 있다. ");
    }
}
