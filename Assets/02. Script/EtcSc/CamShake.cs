using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource impulse;

    private void Awake()
    {
        impulse = FindAnyObjectByType<CinemachineImpulseSource>();
    }
    public void Shake(float power)
    {
        impulse.GenerateImpulse(power / 15f);
    }
}
