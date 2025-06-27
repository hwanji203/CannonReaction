using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    [SerializeField] private ParticleSystem firePar;
    [SerializeField] private ParticleSystem smokePar;

    [SerializeField] CameraShake camShake;

    [SerializeField] AudioClip clip;
    private void Awake()
    {
        camShake = FindAnyObjectByType<CameraShake>();
    }

    public void CAudio()
    {
        AudioManager.Instance.PlaySFX(clip, 1);
    }

    public void CStartPar()
    {
        firePar.Play();
        smokePar.Play();
        camShake.Shake(new Vector2(0,-2)); // 방향과 세기 지정
    }

    public void CAnimationEnd()
    {
        gameObject.GetComponent<LookMouse>().Fade();
    }
}
