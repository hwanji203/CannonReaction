using UnityEngine;

public class ShootSFX : MonoBehaviour
{
    private Transform parPoolPa;
    [SerializeField] private ParticleSystem smokePar;
    [SerializeField] private ParticleSystem firePar;
    private ParticleSystem[] smokeParPool;
    private ParticleSystem[] fireParPool;
    private readonly int parPoolSize = 5;

    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    [SerializeField] private AudioSource audioSo;
    [SerializeField] private AudioClip shootAdClip;

    private Player player;
    private void Awake()
    {
        audioSo = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        player = GetComponent<Player>();
        player.shootEvnet += ParPlay;
        player.shootEvnet += AudioPlay;

        parPoolPa = GameObject.Find("ParPoolPa").transform;
        PoolMake(parPoolPa, smokePar, ref smokeParPool, parPoolSize);
        PoolMake(parPoolPa, firePar, ref fireParPool, parPoolSize);
    }

    public void AudioPlay()
    {
        AudioManager.Instance.PlaySFX(shootAdClip);
    }

    private void ParPlay()
    {
        for (int i = 0; i < fireParPool.Length; i++)
        {
            GameObject par = fireParPool[i].gameObject;
            if (!par.activeSelf)
            {
                par.gameObject.SetActive(true);
                break;
            }
        }
        for (int i = 0; i < smokeParPool.Length; i++)
        {
            GameObject par = smokeParPool[i].gameObject;
            if (!par.activeSelf)
            {
                par.gameObject.SetActive(true);
                break;
            }
        }
    }
    private void PoolMake(Transform father, ParticleSystem particle, ref ParticleSystem[] parPool, int size)
    {
        parPool = new ParticleSystem[size];
        for (int i = 0; i < size; i++)
        {
            parPool[i] = Instantiate(particle, father);
        }
    }
}
