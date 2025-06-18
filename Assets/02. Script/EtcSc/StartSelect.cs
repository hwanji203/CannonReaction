    using Unity.VisualScripting;
using UnityEngine;

public class StartSelect : MonoBehaviour
{
    private ExpGauge expGauge;

    [SerializeField] private GameObject tarOb;
    [SerializeField] private GameObject cannonOb;
    [SerializeField] private GameObject colOb; 
    [SerializeField] private GameObject ImaOb; 

    private readonly int startSelectHash = Animator.StringToHash("startSelect");

    [SerializeField] private Animator[] selects;

    [SerializeField] private SelectAnimationEvent aniEvent;
    [SerializeField] private GameObject selectUI;

    private StageManager stageMa;
    private void Awake()
    {
        stageMa = GetComponent<StageManager>();

        foreach (Animator g in selects)
        {
            g.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        expGauge = FindAnyObjectByType<ExpGauge>();
        UISetActive(false);
    }

    private void UISetActive( bool a)
    {
        selectUI.SetActive(a);
        tarOb.SetActive(a);
        cannonOb.SetActive(a);
    }

    private void Start()
    {
        expGauge.LevelUpEvent += StartSelectM;
        aniEvent.EndSelect += EndSelectSelectM;
    }
    private void EndSelectSelectM()
    {
        colOb.SetActive(true);
        ImaOb.SetActive(true);

        UISetActive(false);
        stageMa.enabled = true;
    }

    private void StartSelectM()
    {
        colOb.SetActive(false);
        ImaOb.SetActive(false);

        UISetActive(true);
        Time.timeScale = 0;

        StartAnimation();
    }
    private void StartAnimation()
    {
        foreach (Animator g in selects)
        {
            g.SetTrigger(startSelectHash);
        }
    }
}
