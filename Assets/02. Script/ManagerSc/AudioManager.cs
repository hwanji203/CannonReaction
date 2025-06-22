using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource selectSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGM(AudioClip adClip)
    {
        bgmSource.clip = adClip;
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip adClip, float volume)
    {
        sfxSource.PlayOneShot(adClip, volume);
    }

    public void SelectSPlay(AudioClip adClip)
    {
        selectSource.PlayOneShot(adClip);
    }

    public void SelectBgm(AudioClip clip)
    {
        bgmSource.Pause();
        selectSource.clip = clip;
        selectSource.Play();
    }
    public void MainBgm(AudioClip clip)
    {
        bgmSource.UnPause();
        selectSource.Stop();
    }
}
