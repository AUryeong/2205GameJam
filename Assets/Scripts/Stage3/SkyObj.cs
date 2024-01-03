using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyObj : Obj
{
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.ShowText("�ʹ��� ���� ��ġ�̴�. ������ �� ������ ���ؼ� ���� ������ �ٰ����� �𸥴�.\n�� ���� �������� �Ѵ�. ");
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
