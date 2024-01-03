using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject window;
    void Start()
    {
        SoundManager.Instance.PlaySound("vampires_piano", SoundType.BGM);
        SoundManager.Instance.PlaySound("", SoundType.BGM2);
        SoundManager.Instance.PlaySound("", SoundType.BGM3);
        SetResoultion();
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


    public void DoStart()
    {
        SoundManager.Instance.PlaySound("Button_Click_by_KorgMS2000B_Id-54405");
        SceneManager.LoadScene("Stage1");
    }

    public void DoGameTool()
    {
        SoundManager.Instance.PlaySound("Button_Click_by_KorgMS2000B_Id-54405");
        window.SetActive(true);
    }

    public void EndGameTool()
    {
        SoundManager.Instance.PlaySound("Button_Click_by_KorgMS2000B_Id-54405");
        window.SetActive(false);
    }
}
