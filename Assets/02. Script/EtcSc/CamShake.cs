using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource impulse;

    private CannonEvent cannonEvent;

    private void Awake()
    {
        cannonEvent = FindAnyObjectByType<CannonEvent>();
    }
    void Start()
    {
        cannonEvent.TakeDamageEvent += Shake;
    }

    private void Shake()
    {
        impulse.GenerateImpulse();
    }
}
