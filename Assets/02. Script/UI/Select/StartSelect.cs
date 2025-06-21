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
    }


    private void Start()
    {
        expGauge.LevelUpEvent += StartSelectM;
        aniEvent.EndSelect += EndSelectSelectM;
        UISetActive(false);
        cannonOb.SetActive(false);
        breakOb.SetActive(false);
    }
    private void EndSelectSelectM()
    {
        ImaOb.enabled = true;

        UISetActive(false);
        breakOb.SetActive(false);
        stageMa.enabled = true;
    }

    private void StartSelectM()
    {
        ImaOb.enabled = false;

        cannonOb.SetActive(true);
        UISetActive(true);
        cam.SetTime(0);
    }

}
