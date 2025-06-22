using TMPro;
using UnityEngine;

public class RecordSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI TimeText; 

    [SerializeField] private TextMeshProUGUI killRecord;
    [SerializeField] private TextMeshProUGUI timeRecord;

    private int killCount = 0;
    private int bestKillCount = 0;
    private float nowTime = 0;
    private float bestTime = 0;

    private const string BEST_KILL_KEY = "BestKillCount";
    private const string BEST_TIME_KEY = "BestTime";

    private void Awake()
    {
        Active(false);
    }

    private void Active(bool b)
    {
        killRecord.enabled = b;
        timeRecord.enabled = b;
    }

    private void Start()
    {
        bestKillCount = PlayerPrefs.GetInt(BEST_KILL_KEY, 0);
        bestTime = PlayerPrefs.GetFloat(BEST_TIME_KEY, 0f);
        UpdateText();
    }

    public void KillCountPlus()
    {
        killCount++;
        UpdateText();

        if (killCount > bestKillCount)
        {
            killRecord.enabled = true;
            bestKillCount = killCount;
            PlayerPrefs.SetInt(BEST_KILL_KEY, bestKillCount);
        }
    }
    public void UpdateTime()
    {
        nowTime = Time.time;
        UpdateText();

        if (nowTime > bestTime)
        {
            timeRecord.enabled = true;
            bestTime = nowTime;
            PlayerPrefs.SetFloat(BEST_TIME_KEY, bestTime);
        }
    }

    private void UpdateText()
    {
        killCountText.text = $"처치한 슬라임 수 : <size=150%>{killCount}</size>";
        TimeText.text = $"버틴 시간 :  <size=150%>{nowTime:F2}</size>";
    }
}
