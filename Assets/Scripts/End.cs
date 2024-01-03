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
        tmp.text = "���� ������ �غ� ������.";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Hole.DOFade(1, 1f);
        tmp.text = "������ �Ĵٺ��� ���� �ӿ��� �� ���� ���� �׸��ڰ� ���� ���� ���� ������. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "�� ����� �ϴ� ���ϱ�? �� ������� �����ϱ�?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Hole.DOFade(0, 1f);
        tmp.text = "�� �� ���� �� �����̴�. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "��!";
        Fall.DOFade(1, 1f);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "���� ���ϻ� õ�� �������κ��� ������ ������. �Ʊ� ���� ����� �������� ���� �ɱ�?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "���¡� �״°ɱ�?";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        Fall.DOFade(0, 2f);
        Wake.DOFade(1, 2f);
        tmp.text = "���� ����. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "ħ���. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "������ 5�� 22�� �θ���� ���� ���ư����� 1���� �Ǵ� ���̴�. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "�ǻ簡 ������ ���� �ɾ���. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "������ ���� ġ�ᰡ �������ϴ�. ����� ��Ű���? ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        tmp.text = "������ ������ �� �� �� ���簡 ������ �� �� ���Ҵ�. ";
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;
        WakeUp.DOFade(1, 1);
        tmp.text = "�������� ���� �׸��׿�.��";
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
