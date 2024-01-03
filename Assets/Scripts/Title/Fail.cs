using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    [SerializeField]
    int stage;
    [SerializeField]
    Image image;
    [SerializeField]
    Image Re;
    
    void Start()
    {
        SetResoultion();
        SoundManager.Instance.PlaySound("", SoundType.BGM);
        SoundManager.Instance.PlaySound("", SoundType.BGM2);
        SoundManager.Instance.PlaySound("", SoundType.BGM3);
        StartCoroutine(FailE());
    }
    void SetResoultion()
    {
        int WIDTH = 1920;
        int HEIGHT = 1440;

        int DEVICE_WIDTH = Screen.width;
        int DEVICE_HEIGHT = Screen.height;

        float RATIO = (float)WIDTH / HEIGHT;
        float DEVICE_RATIO = (float)DEVICE_WIDTH / DEVICE_HEIGHT;

        Screen.SetResolution(WIDTH, (int)(((float)DEVICE_HEIGHT / DEVICE_WIDTH) * WIDTH), true);

        if (RATIO < DEVICE_RATIO)
        {
            float newWidth = RATIO / DEVICE_RATIO;
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
        }
        else
        {
            float newHeight = DEVICE_RATIO / RATIO;
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
        }
    }
    IEnumerator FailE()
    {
        yield return new WaitForSeconds(2);
        image.gameObject.SetActive(true);
        image.DOFade(1, 1);
        yield return new WaitForSeconds(5);
        image.DOFade(0, 3);
        yield return new WaitForSeconds(3);
        Re.gameObject.SetActive(true);
        Re.DOFade(1, 0.5f);
    }
    public void Return()
    {
        SceneManager.LoadScene("Stage" + stage);
    }

    void Update()
    {
        
    }
}
