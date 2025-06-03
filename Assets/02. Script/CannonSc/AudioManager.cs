using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource bgmSource;
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
        sfxSource.Play();
    }

    public void PlaySFX(AudioClip adClip)
    {
        sfxSource.PlayOneShot(adClip);
    }
}
