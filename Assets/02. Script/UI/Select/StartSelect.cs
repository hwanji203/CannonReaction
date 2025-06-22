    using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    private ExpGauge expGauge;

    [SerializeField] private GameObject tarOb;
    [SerializeField] private GameObject cannonOb;
    [SerializeField] private Image ImaOb; 
    [SerializeField] private GameObject breakOb; 

    [SerializeField] private GameObject selectUI;

    private StageManager stageMa;

    private CameraShake cam;

    private SelectManager selectMa;

    [SerializeField] private AudioSource audioS;
    private AudioManager audioM;
    [SerializeField] private AudioClip selectBgm;
    [SerializeField] private AudioClip mainBgm;


    private void Awake()
    {
        stageMa = GetComponent<StageManager>();

        cam = FindAnyObjectByType<CameraShake>();

        expGauge = FindAnyObjectByType<ExpGauge>();

        selectMa = FindAnyObjectByType<SelectManager>()
            ;
        audioM = FindAnyObjectByType<AudioManager>();
    }
    private void Start()
    {
        expGauge.LevelUpEvent += StartSelectM;
        UISetActive(false);
        cannonOb.SetActive(false);
        breakOb.SetActive(false);

        audioM.PlayBGM(mainBgm);
    }

    private void UISetActive( bool a)
    {
        selectUI.SetActive(a);
        tarOb.SetActive(a);
    }
    public void EndSelectSelectM()
    {
        audioM.MainBgm(mainBgm);

        ImaOb.enabled = true;

        UISetActive(false);
        breakOb.SetActive(false);
        stageMa.enabled = true;
    }

    private void StartSelectM()
    {
        audioM.SelectBgm(selectBgm);

        ImaOb.enabled = false;

        cannonOb.SetActive(true);
        UISetActive(true);
        cam.SetTime(0);

        selectMa.StartSelect();
    }

}
