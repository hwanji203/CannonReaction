using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    private CameraShake cam;
    private SettingCon con;

    private void Awake()
    {
        cam = FindAnyObjectByType<CameraShake>();
        Cursor.visible = false;
        con = FindAnyObjectByType<SettingCon>();
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
            con.IsFirst = false;
            enabled = false;
        }
    }
}
