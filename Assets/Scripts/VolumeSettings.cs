using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerVolume : MonoBehaviour
{
    public AudioMixer audioMixer;    // 인스펙터에서 오디오믹서 연결
    public Slider musicSlider;       // 배경음악 슬라이더
    public Slider sfxSlider;         // 효과음 슬라이더

    private const string MUSIC_PARAM = "MusicVolume";
    private const string SFX_PARAM = "SFXVolume";

    void Start()
    {
        // 저장된 값이 없으면 1로 기본 세팅
        float musicValue = PlayerPrefs.GetFloat(MUSIC_PARAM, 1f);
        float sfxValue = PlayerPrefs.GetFloat(SFX_PARAM, 1f);

        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;

        SetMusicVolume(musicValue);
        SetSfxVolume(sfxValue);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    public void SetMusicVolume(float sliderValue)
    {
        // 슬라이더 값(0~1)을 데시벨(-80~0)으로 변환
        float dB = Mathf.Lerp(-80f, 0f, sliderValue);
        audioMixer.SetFloat(MUSIC_PARAM, dB);
        PlayerPrefs.SetFloat(MUSIC_PARAM, sliderValue);
    }

    public void SetSfxVolume(float sliderValue)
    {
        float dB = Mathf.Lerp(-80f, 0f, sliderValue);
        audioMixer.SetFloat(SFX_PARAM, dB);
        PlayerPrefs.SetFloat(SFX_PARAM, sliderValue);
    }

    void Awake()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxValue = PlayerPrefs.GetFloat("SFXVolume", 1f);

        audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, musicValue));
        audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80f, 0f, sfxValue));
    }
}