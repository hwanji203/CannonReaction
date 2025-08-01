using UnityEngine;

public class ShootSFX : MonoBehaviour
{
    [SerializeField] private Transform parPoolPa;
    [SerializeField] private GameObject smokePar;
    [SerializeField] private GameObject firePar;
    private GameObject[] smokeParPool;
    private GameObject[] fireParPool;
    private readonly int parPoolSize = 8;
    [SerializeField] private AudioClip shootAdClip;

    private Transform particlePo;

    private GameObject parGameO;

    private CannonEvent player;

    [SerializeField] private bool isMain = false;
    private void Awake()
    {
        particlePo = transform.Find("ParticlePo");
        PoolMake(parPoolPa, smokePar, out smokeParPool, parPoolSize);
        PoolMake(parPoolPa, firePar, out fireParPool, parPoolSize);
        player = GetComponent<CannonEvent>();

    }

    void Start()
    {
        player.shootEvnet += ParPlay;
    }

    public void AudioPlay()
    {
        if (isMain)
        {
            AudioManager.Instance.PlaySFX(shootAdClip, 1f);
        }
    }

    private void ParPlay()
    {
        for (int i = 0; i < fireParPool.Length; i++)
        {
            GameObject particle = fireParPool[i];
            if (!particle.activeSelf)
            {
                parGameO = particle.gameObject;
                parGameO.transform.position = gameObject.transform.position;
                parGameO.SetActive(true);
                break;
            }
        }
        for (int i = 0; i < smokeParPool.Length; i++)
        {
            GameObject particle = smokeParPool[i];
            if (!particle.activeSelf)
            {
                parGameO = particle.gameObject;
                parGameO.transform.position = gameObject.transform.position;
                parGameO.SetActive(true);
                break;
            }
        }
    }

    private void PoolMake(Transform father, GameObject particle, out GameObject[] parPool, int size)
    {
        parPool = new GameObject[size];
        for (int i = 0; i < size; i++)//:P
        {
            parPool[i] = Instantiate(particle, father);
            parPool[i].GetComponent<ParticleMovement>().Setting(particlePo);
        }
    }
}
