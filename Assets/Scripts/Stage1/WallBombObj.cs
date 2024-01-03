using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBombObj : Obj
{
    [SerializeField]
    GameObject Wall;
    [SerializeField]
    GameObject Root;
    [SerializeField]
    GameObject Paper;
    
    public override void OnClick()
    {
        base.OnClick();
        GameManager.Instance.cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 2, X = 0.1f, Y = 0.08f });
        Root.SetActive(true);
        Wall.SetActive(false);
        Paper.SetActive(true);
        gameObject.SetActive(false);
    }
}
