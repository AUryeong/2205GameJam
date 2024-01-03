using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SoundType
{
    SE,
    SE2,
    BGM,
    BGM2,
    BGM3,
    END
}
public class SoundManager : Singleton<SoundManager>
{
    Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    Dictionary<SoundType, float> Volumes = new Dictionary<SoundType, float>() { { SoundType.SE, 1 }, { SoundType.BGM, 1 }, { SoundType.BGM2, 1 }, { SoundType.BGM3, 1 }, { SoundType.SE2, 1 } };
    Dictionary<SoundType, AudioSource> AudioSources = new Dictionary<SoundType, AudioSource>();

    protected override void Awake()
    {
        if(Instance == this)
         DontDestroyOnLoad(gameObject);
        GameObject Se = new GameObject("SE");
        Se.transform.parent = transform;
        Se.AddComponent<AudioSource>();
        AudioSources[SoundType.SE] = Se.GetComponent<AudioSource>();
        GameObject Se2 = new GameObject("SE2");
        Se2.transform.parent = transform;
        Se2.AddComponent<AudioSource>();
        AudioSources[SoundType.SE2] = Se2.GetComponent<AudioSource>();

        GameObject Bgm = new GameObject("BGM");
        Bgm.transform.parent = transform;
        Bgm.AddComponent<AudioSource>().loop = true;
        AudioSources[SoundType.BGM] = Bgm.GetComponent<AudioSource>();

        GameObject Bgm2 = new GameObject("BGM2");
        Bgm2.transform.parent = transform;
        Bgm2.AddComponent<AudioSource>().loop = true;
        AudioSources[SoundType.BGM2] = Bgm2.GetComponent<AudioSource>();

        GameObject Bgm3 = new GameObject("BGM3");
        Bgm3.transform.parent = transform;
        Bgm3.AddComponent<AudioSource>().loop = true;
        AudioSources[SoundType.BGM3] = Bgm3.GetComponent<AudioSource>();

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/");
        foreach (AudioClip clip in clips)
            sounds[clip.name] = clip;
    }
    public void PlaySound(string clipName, SoundType ClipType = SoundType.SE, float Volume = 1, float Pitch = 1)
    {
        if (ClipType != SoundType.SE && ClipType != SoundType.END && ClipType != SoundType.SE2)
        {
            if (clipName == "")
            {
                AudioSources[ClipType].Stop();
                return;
            }
            AudioSources[ClipType].clip = sounds[clipName];
            AudioSources[ClipType].volume *= Volume;
            AudioSources[ClipType].Play();
        }
        else
        {
            if (clipName == "")
            {
                AudioSources[ClipType].Stop();
                return;
            }
            AudioSources[ClipType].pitch = Pitch;
            AudioSources[ClipType].PlayOneShot(sounds[clipName], Volume);
        }
    }
    private void Update()
    {
        AudioSources[SoundType.BGM].volume = Volumes[SoundType.BGM];
        AudioSources[SoundType.BGM2].volume = Volumes[SoundType.BGM2];
        AudioSources[SoundType.BGM3].volume = Volumes[SoundType.BGM3];
        AudioSources[SoundType.SE].volume = Volumes[SoundType.SE];
        AudioSources[SoundType.SE2].volume = Volumes[SoundType.SE2];

    }
}