using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [Header("슬라이더")]
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider rotationSpeedSlider;

    [Header("SFX")]
    [SerializeField] private float maxSFXVolume = 1.0f;
    [SerializeField] private float defaultSFXVolume = 1.0f;

    [Header("BGM")]
    [SerializeField] private float maxBGMVolume = 1.0f;
    [SerializeField] private float defaultBGMVolume = 1.0f;

    [Header("회전")]
    [SerializeField] private float maxRotationValue = 1.0f;
    [SerializeField] private float defaultRotationValue = 1.0f;

    [Header("바꿀 것")]
    [SerializeField] private AudioSource[] bgmSources;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private CannonRotate[] rotationSpeeds;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI bgmText;
    [SerializeField] private TextMeshProUGUI sfxText;
    [SerializeField] private TextMeshProUGUI rotationSpeedText;

    private void Awake()
    {
        SetupSlider(bgmSlider, "Volume_BGM", OnBGMVolumeChanged, maxBGMVolume, defaultBGMVolume, bgmText);
        SetupSlider(sfxSlider, "Volume_SFX", OnSFXVolumeChanged, maxSFXVolume, defaultSFXVolume, sfxText);
        SetupSlider(rotationSpeedSlider, "RotationSpeed", OnRotationSpeedChanged, maxRotationValue, defaultRotationValue, rotationSpeedText);
    }

    private void SetupSlider(Slider slider, string key, UnityEngine.Events.UnityAction<float> method, float maxValue, float defaultValue, TextMeshProUGUI text)
    {
        slider.maxValue = maxValue;
        float savedValue = PlayerPrefs.GetFloat(key, defaultValue);
        slider.value = savedValue;
        text.text = $"{savedValue:F2}";
        slider.onValueChanged.AddListener(method);

        // 초기 적용도 여기서 해줌
        method.Invoke(savedValue);
    }

    public void OnBGMVolumeChanged(float value)
    {
        float step = 0.1f;
        float snapped = Mathf.Round(value / step) * step;

        bgmSlider.SetValueWithoutNotify(snapped);

        foreach (var source in bgmSources)
        {
            if (source != null)
                source.volume = snapped;
        }

        PlayerPrefs.SetFloat("Volume_BGM", snapped);
        bgmText.text = $"{snapped:F1}";
    }

    public void OnSFXVolumeChanged(float value)
    {
        float step = 0.1f;
        float snapped = Mathf.Round(value / step) * step;

        sfxSlider.SetValueWithoutNotify(snapped);

        sfxSource.volume = snapped;
        PlayerPrefs.SetFloat("Volume_SFX", snapped);
        sfxText.text = $"{snapped:F1}";
    }

    public void OnRotationSpeedChanged(float value)
    {
        float step = 0.1f;
        float snapped = Mathf.Round(value / step) * step;

        rotationSpeedSlider.SetValueWithoutNotify(snapped);

        foreach (var rot in rotationSpeeds)
        {
            if (rot != null)
                rot.RotatePower = snapped;
        }

        PlayerPrefs.SetFloat("RotationSpeed", snapped);
        rotationSpeedText.text = $"{snapped:F1}";
    }
}
