using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    [SerializeField] private ParticleSystem firePar;
    [SerializeField] private ParticleSystem smokePar;

    [SerializeField] CameraShake camShake;

    private void Awake()
    {
        camShake = FindAnyObjectByType<CameraShake>();
    }

    public void CStartPar()
    {
        firePar.Play();
        smokePar.Play();
        camShake.Shake(new Vector2(0,11)); // 방향과 세기 지정
    }
}
