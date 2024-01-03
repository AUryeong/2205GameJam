using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class End : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;
    [SerializeField]
    Image Hole;
    [SerializeField]
    Image Wake;
    [SerializeField]
    Image Fall;
    [SerializeField]
    Image WakeUp;
    void Start()
    {
        SetResoultion();
        StartCoroutine(EndE());
    }
    IEnumerator EndE()
    {
        SoundManager.Instance.PlaySound("vampires_piano", SoundType.BGM);
        SoundManager.Instance.PlaySound("", SoundType.BGM2);
        SoundManager.Instance.PlaySound("", SoundType.BGM3);
        tmp.text = "이제 내려갈 준비가 끝났다.";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Hole.DOFade(1, 1f);
        tmp.text = "구멍을 쳐다보자 구멍 속에서 두 개의 검은 그림자가 손을 흔드는 것이 보였다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "잘 가라고 하는 것일까? 저 존재들은 무엇일까?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Hole.DOFade(0, 1f);
        tmp.text = "알 수 없는 것 투성이다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "툭!";
        Fall.DOFade(1, 1f);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "순간 낙하산 천이 가방으로부터 떨어져 나갔다. 아까 전에 제대로 연결하지 않은 걸까?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "나는… 죽는걸까?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Fall.DOFade(0, 2f);
        Wake.DOFade(1, 2f);
        tmp.text = "눈을 떴다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "침대다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "오늘은 5월 22일 부모님이 사고로 돌아가신지 1년이 되는 날이다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "의사가 나에게 말을 걸었다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "마지막 수면 치료가 끝났습니다. 기분은 어떠신가요? ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "나에게 도움을 준 그 두 존재가 누군지 알 것 같았다. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        WakeUp.DOFade(1, 1);
        tmp.text = "“아직도 많이 그립네요.”";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "";
        GetComponent<Image>().color = Color.white;
        Wake.gameObject.SetActive(false);
        WakeUp.DOFade(0, 8);
        yield return new WaitForSeconds(8);
        Application.Quit();
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

    void Update()
    {
        
    }
}
