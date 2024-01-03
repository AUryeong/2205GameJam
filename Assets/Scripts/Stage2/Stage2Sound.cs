using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Sound : Singleton<Stage2Sound>
{
    [SerializeField]
    GameObject Paper;
    void Start()
    {
        SoundManager.Instance.PlaySound("Dream_2_Ambience", SoundType.BGM);
        SoundManager.Instance.PlaySound("cave_themeb4", SoundType.BGM2);
        SoundManager.Instance.PlaySound("", SoundType.BGM3);
    }
    IEnumerator FailE()
    {
        GameManager.Instance.Clickable = false;
        GameManager.Instance.cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 0.7f, X = 0.3f, Y = 0.24f });
        SoundManager.Instance.PlaySound("Scream", SoundType.SE2);
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Fail2");
    }
    public void Fail()
    {
        StartCoroutine(FailE());
    }

    public void Show()
    {
        Paper.SetActive(true);
    }
}
