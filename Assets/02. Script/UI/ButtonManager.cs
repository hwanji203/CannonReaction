using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private SettingCon setting;

    private void Awake()
    {
        setting = FindAnyObjectByType<SettingCon>();
    }

    public void ReStart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Continue()
    {
        setting.Continue();
    }
}
