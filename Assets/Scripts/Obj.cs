using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public virtual void UseItem(Item item)
    {
        
    }
    public virtual void OnClick()
    {
        SoundManager.Instance.PlaySound("Button_Click_by_KorgMS2000B_Id-54405");
    }
}
