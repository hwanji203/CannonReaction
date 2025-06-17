using Unity.VisualScripting;
using UnityEngine;

public class StartSelectManager : MonoBehaviour
{
    private ExpGauge expGauge;
    [SerializeField] private ParticleSystem[] particle;

    [SerializeField] private GameObject tarOb;
    [SerializeField] private GameObject colOb; 
    [SerializeField] private GameObject ImaOb; 

    private readonly int startSelectHash = Animator.StringToHash("startSelect");

    [SerializeField] private Animator[] selects;
    private void Awake()
    {
        expGauge = FindAnyObjectByType<ExpGauge>();
        for (int i = 0; i < particle.Length; i++)
        {
            var main = particle[i].main;
            main.useUnscaledTime = true;
        }

        foreach (Animator g in selects)
        {
            g.updateMode = AnimatorUpdateMode.UnscaledTime;
            g.gameObject.SetActive(false);
        }
        expGauge = FindAnyObjectByType<ExpGauge>();
    }

    private void Start()
    {
        expGauge.LevelUpEvent += StartAnimation;
    }

    public void StartSelect()
    {
        colOb.SetActive(false);
        ImaOb.SetActive(false);
        tarOb.SetActive(true);
        Time.timeScale = 0;
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].Play();
        }
    }
    private void StartAnimation()
    {
        foreach (Animator g in selects)
        {
            g.gameObject.SetActive(true);
            g.SetTrigger(startSelectHash);
        }
    }
}
