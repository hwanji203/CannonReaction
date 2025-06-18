using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    [SerializeField] private ParticleSystem firePar;
    [SerializeField] private ParticleSystem smokePar;

    [SerializeField] CameraShake camShake;

    public void CStartPar()
    {
        firePar.Play();
        smokePar.Play();
        camShake.Shake(new Vector2(0, -50));
    }
}
