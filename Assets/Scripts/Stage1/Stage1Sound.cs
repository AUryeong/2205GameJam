using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Sound : Singleton<Stage1Sound>
{
    [SerializeField]
    GameObject Human;
    [SerializeField]
    GameObject Stone;
    IEnumerator FailE()
    {
        GameManager.Instance.Clickable = false;
        GameManager.Instance.cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 0.7f, X = 0.3f, Y = 0.24f });
        SoundManager.Instance.PlaySound("Scream", SoundType.SE2);
        Human.SetActive(true);
        Stone.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Fail1");
    }
    public void Fail()
    {
        if(GameManager.Instance.Clickable)
        StartCoroutine(FailE());
    }
    void Start()
    {
        SoundManager.Instance.PlaySound("Dream_2_Ambience", SoundType.BGM);
        SoundManager.Instance.PlaySound("atmosbasement.mp3_", SoundType.BGM2);
        SoundManager.Instance.PlaySound("spacelifeNo14", SoundType.BGM3);
    }
}
