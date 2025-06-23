using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingCon : MonoBehaviour
{
    private GameObject settingUI;
    private StartSelect select;

    [SerializeField] Image image;

    public bool IsFirst { get; set; } = true;
    private void Awake()
    {
        settingUI = transform.GetChild(0).gameObject;
        settingUI.SetActive(false);

        select = FindAnyObjectByType<StartSelect>();
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !select.Selecting)
        {
            Continue();
        }
    }

    public void Continue()
    {
        settingUI.SetActive(!settingUI.activeSelf);
        if (settingUI.activeSelf)
        {
            Cursor.visible = true;
            image.enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            image.enabled = true;
            if (!IsFirst)
            {
                Time.timeScale = 1;
            }
        }
    }
}
