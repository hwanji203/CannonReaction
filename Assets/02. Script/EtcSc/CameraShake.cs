using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource impulse;

    private void Awake()
    {
        impulse = FindAnyObjectByType<CinemachineImpulseSource>();
        CinemachineImpulseManager.Instance.IgnoreTimeScale = true;

    }
    public void Shake(float power)
    {
        impulse.GenerateImpulse(power / 15f);
    }
    public void Shake(Vector2 power)
    {
        impulse.GenerateImpulse(power / 15f);
    }
}
