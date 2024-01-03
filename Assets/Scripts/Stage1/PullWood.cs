using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PullWood : Obj
{
    public override void OnClick()
    {
        base.OnClick();
        SceneManager.LoadScene("Stage2");
    }
}
