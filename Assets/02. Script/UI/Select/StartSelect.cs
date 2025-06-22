    using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    private ExpGauge expGauge;

    [SerializeField] private GameObject tarOb;
    [SerializeField] private GameObject cannonOb;
    [SerializeField] private GameObject breakOb; 

    [SerializeField] private GameObject selectUI;

    private StageManager stageMa;

    private CameraShake cam;

    private SelectManager selectMa;

    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip selectBgm;
    [SerializeField] private AudioClip mainBgm;

    public bool Selecting { get; private set; } = false;

    private void Awake()
    {
        stageMa = GetComponent<StageManager>();

        cam = FindAnyObjectByType<CameraShake>();

        expGauge = FindAnyObjectByType<ExpGauge>();

        selectMa = FindAnyObjectByType<SelectManager>();
    }
    private void Start()
    {
        expGauge.LevelUpEvent += StartSelectM;
        UISetActive(false);
        cannonOb.SetActive(false);
        breakOb.SetActive(false);

        AudioManager.Instance.PlayBGM(mainBgm);
    }

    private void UISetActive( bool a)
    {
        selectUI.SetActive(a);
        tarOb.SetActive(a);
    }
    public void EndSelectSelectM()
    {
        Selecting = false;

        AudioManager.Instance.MainBgm(mainBgm);

        UISetActive(false);
        breakOb.SetActive(false);
        stageMa.enabled = true;
    }

    private void StartSelectM()
    {
        Selecting = true;

        AudioManager.Instance.SelectBgm(selectBgm);

        cannonOb.SetActive(true);
        UISetActive(true);
        cam.SetTime(0);

        selectMa.StartSelect();
    }

}
