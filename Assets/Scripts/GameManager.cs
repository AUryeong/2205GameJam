using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameManager : Singleton<GameManager>
{
    [Header("아이템")]
    public List<Item> allItems = new List<Item>();
    [SerializeField]
    string[] ItemList;
    

    [Header("타이머")]
    [SerializeField]
    TextMeshProUGUI alarm;
    [SerializeField]
    TextMeshProUGUI timerText;
    Coroutine alarmCoroutine;
    public int timer;
    float timerDelay;

    [Header("모시깽이")]
    [SerializeField]
    PostProcessProfile profile;
    [SerializeField]
    PostProcessProfile profile2;

    [Header("이외")]
    public List<CameraFilter_EarthQuake> cameraFilter_EarthQuakes = new List<CameraFilter_EarthQuake>();
    int earthQuakeDelay;
    public bool Clickable = true;

    void Start()
    {
        timerText.text = (timer / 60).ToString("D2") + ":" + (timer % 60).ToString("D2");
        CameraControl();
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

    public Item GetItem(string text)
    {
        return allItems.Find((Item x) => x.itemText == text);
    }
    void CameraControl()
    {
        Vector3 shake = Vector3.zero;
        if (cameraFilter_EarthQuakes.Count > 0)
        {
            List<CameraFilter_EarthQuake> filters = new List<CameraFilter_EarthQuake>();
            foreach (CameraFilter_EarthQuake cameraFilter in cameraFilter_EarthQuakes)
            {
                cameraFilter.Time -= Time.deltaTime;
                if (cameraFilter.Time <= 0)
                {
                    filters.Add(cameraFilter);
                }
                else
                {
                    Vector2 rand = UnityEngine.Random.insideUnitCircle;
                    shake += new Vector3(rand.x * cameraFilter.X, rand.y * cameraFilter.Y, 0);
                }
            }
            foreach (CameraFilter_EarthQuake cameraFilter in filters)
            {
                cameraFilter_EarthQuakes.Remove(cameraFilter);
            }
        }
        Camera.main.transform.localPosition = shake + new Vector3(0,0,-10);
    }
    void Update()
    {
        TimerControl();
        CameraControl();
        ClickCheck();
    }
    void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0) && Clickable)
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider != null)
            {
                rayHit.collider.GetComponent<Obj>().OnClick();
            }
        }
    }
    void TimerControl()
    {
        if(Clickable)
        timerDelay += Time.deltaTime;
        if (timerDelay >= 1)
        {
            if (--timer <= 0)
            {
                if(allItems[0].itemText == "Rope")
                {
                    Stage1Sound.Instance.Fail();
                }
                else if (allItems[0].itemText == "Plank")
                {
                    Stage2Sound.Instance.Fail();
                }
                else
                {
                    Stage3Sound.Instance.Fail();
                }
                return;
            }
            timerText.text = (timer / 60).ToString("D2") + ":" + (timer % 60).ToString("D2");
            timerDelay--;
            if(++earthQuakeDelay >= 15)
            {
                earthQuakeDelay -= 15;
                cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 1, X = 0.2f, Y = 0.16f });
                SoundManager.Instance.PlaySound("14", SoundType.SE);
            }
            if (timer <= 30)
            {
                if(Camera.main.GetComponent<PostProcessVolume>().profile != profile2)
                {
                    Camera.main.GetComponent<PostProcessVolume>().profile = profile2;
                    cameraFilter_EarthQuakes.Add(new CameraFilter_EarthQuake() { Time = 1, X = 0.2f, Y = 0.16f });
                }
            }
            else
            {
                if (Camera.main.GetComponent<PostProcessVolume>().profile != profile)
                {
                    Camera.main.GetComponent<PostProcessVolume>().profile = profile;
                }
            }
        }
    }


    public void ShowText(string text, float duration = 4)
    {
        if(alarmCoroutine != null)
          StopCoroutine(alarmCoroutine);
        alarmCoroutine = StartCoroutine(alarmFadeOut(text.Replace("/n", "\n"), duration));
    }

    IEnumerator alarmFadeOut(string text, float duration)
    {
        alarm.color = new Color(1, 1, 1, 0);
        alarm.text = text;
        alarm.gameObject.SetActive(true);
        while (alarm.color.a < 0.98f)
        {
            alarm.color = new Color(1, 1, 1, Mathf.Lerp(alarm.color.a, 1, Time.deltaTime * 16));
            yield return null;
        }
        yield return new WaitForSeconds(duration);
        while(alarm.color.a > 0.02f)
        {
            alarm.color = new Color(1, 1, 1, Mathf.Lerp(alarm.color.a, 0f, Time.deltaTime * 8));
            yield return null;
        }
        alarm.gameObject.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();
        string[] strings = ItemList;
        foreach (string item in strings)
        {
            string[] itemarr = item.Split('@');
            if (itemarr.Length > 1)
            {
                allItems.Add(new Item(itemarr[0], itemarr[1], itemarr[2], (itemarr.Length > 3 ? itemarr[3] : "")));
            }
            else
            {
                allItems.Add(new Item(itemarr[0]));
            }
        }
    }
}
