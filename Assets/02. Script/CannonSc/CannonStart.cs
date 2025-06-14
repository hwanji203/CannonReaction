using UnityEngine;
using UnityEngine.InputSystem;

public class CannonStart : MonoBehaviour
{
    [SerializeField] private int startWaitTime;
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        Time.timeScale = 1;
        this.enabled = false;
    }

}
