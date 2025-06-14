using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        // 중복 방지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환해도 파괴 안됨
            Application.targetFrameRate = 144;
        }
        else
        {
            Destroy(gameObject); // 중복 GameManager 제거
        }
    }
}
