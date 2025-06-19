    using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    private ExpGauge expGauge;

    [SerializeField] private GameObject tarOb;
    [SerializeField] private GameObject cannonOb;
    [SerializeField] private GameObject ImaOb; 
    [SerializeField] private GameObject breakOb; 

    private readonly int startSelectHash = Animator.StringToHash("startSelect");

    [SerializeField] private Animator[] selects;

    [SerializeField] private SelectAnimationEvent aniEvent;
    [SerializeField] private GameObject selectUI;

    private StageManager stageMa;

    private CameraShake cam;
    private void Awake()
    {
        stageMa = GetComponent<StageManager>();

        cam = FindAnyObjectByType<CameraShake>();

        expGauge = FindAnyObjectByType<ExpGauge>();
    }

   

    private void UISetActive( bool a)
    {
        selectUI.SetActive(a);
        tarOb.SetActive(a);
        cannonOb.SetActive(a);
    }


    private void Start()
    {
        foreach (Animator g in selects)
        {
            g.updateMode = AnimatorUpdateMode.UnscaledTime;
            g.gameObject.SetActive(false);
        }
        expGauge.LevelUpEvent += StartSelectM;
        aniEvent.EndSelect += EndSelectSelectM;
        UISetActive(false);
        breakOb.SetActive(false);
    }
    private void EndSelectSelectM()
    {
        ImaOb.SetActive(true);

        UISetActive(false);
        breakOb.SetActive(false);
        stageMa.enabled = true;
    }

    private void StartSelectM()
    {
        ImaOb.SetActive(false);

        UISetActive(true);
        cam.SetTime(0);

        StartAnimation();
    }
    private void StartAnimation()
    {
        foreach (Animator g in selects)
        {
            g.gameObject.GetComponent<Button>().interactable = true;
            g.gameObject.SetActive(true);
            g.SetTrigger(startSelectHash);
        }
    }
}
