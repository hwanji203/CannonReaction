using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource impulse;

    private void Awake()
    {
        impulse = FindAnyObjectByType<CinemachineImpulseSource>();
    }

    private void Start()
    {
        CinemachineImpulseManager.Instance.IgnoreTimeScale = true;
    }

    public void Shake(Vector2 power)
    {
        // Vector3 방향 지정 + 크기 조절
        Vector3 impulseDir = new Vector3(power.x, power.y, 0f) / 15f;
        impulse.GenerateImpulse(impulseDir);
    }

    public void SetTime(float time)
    {
        CinemachineImpulseManager.Instance.IgnoreTimeScale = true;
        Time.timeScale = time;
    }
}
