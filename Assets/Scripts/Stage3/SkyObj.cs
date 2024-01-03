using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyObj : Obj
{
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("너무나 높은 위치이다. 하지만 저 구멍을 통해서 언제 위협이 다가올지 모른다.\n이 곳을 내려가야 한다. ");
    }
    public override void UseItem(Item item)
    {
        base.UseItem(item);
        if(item.itemText == "PefectNakha")
        {
            SceneManager.LoadScene("End");
        }
    }
}
