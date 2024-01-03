using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3Sound : Singleton<Stage3Sound>
{
    [SerializeField]
    GameObject player;
    float delta;
    void Start()
    {
        SoundManager.Instance.PlaySound("Dream_2_Ambience", SoundType.BGM);
        SoundManager.Instance.PlaySound("Village_Ruins_-_isaiah658", SoundType.BGM2);
        SoundManager.Instance.PlaySound("", SoundType.BGM3);
    }
    IEnumerator FailE()
    {
        GameManager.Instance.Clickable = false;
        GameManager.Instance.cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 0.7f, X = 0.3f, Y = 0.24f });
        SoundManager.Instance.PlaySound("Scream", SoundType.SE2);
        player.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Fail3");
    }
    public void Fail()
    {
        StartCoroutine(FailE());
    }
    void Update()
    {
        delta += Time.deltaTime;
        if(delta >= 10)
        {
            delta -= 10;
            SoundManager.Instance.PlaySound("birdchirping071414", SoundType.SE2);
        }
    }
}
