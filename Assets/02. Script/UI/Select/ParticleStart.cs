using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    [SerializeField] private ParticleSystem firePar;
    [SerializeField] private ParticleSystem smokePar;

    [SerializeField] CameraShake camShake;

    [SerializeField] AudioClip clip;
    private AudioManager audioM;
    private void Awake()
    {
        camShake = FindAnyObjectByType<CameraShake>();

        audioM = FindAnyObjectByType<AudioManager>();
    }

    public void CAudio()
    {
        audioM.SelectSPlay(clip);
    }

    public void CStartPar()
    {
        firePar.Play();
        smokePar.Play();
        camShake.Shake(new Vector2(0,2)); // 방향과 세기 지정
    }

    public void CAnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
