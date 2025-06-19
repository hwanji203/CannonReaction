using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    private CameraShake cam;

    private void Awake()
    {
        cam = FindAnyObjectByType<CameraShake>();
    }
    private void Start()
    {
        cam.SetTime(0);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.timeScale == 0)
        {
            cam.SetTime(1);
            enabled = false;
        }
    }
}
