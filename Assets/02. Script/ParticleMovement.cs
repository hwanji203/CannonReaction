using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    [SerializeField] private string paName;
    private Transform paTransform;
    private ParticleSystem myPar;

    private void Awake()
    {
        paTransform = GameObject.Find(paName).GetComponent<Transform>();
        myPar = GetComponent<ParticleSystem>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (myPar.isPlaying)
        {
            transform.rotation = paTransform.rotation;
            transform.position = paTransform.position;
        }
        if (!myPar.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        transform.rotation = paTransform.rotation;
        transform.position = paTransform.position;
        myPar.Play();
    }
}
