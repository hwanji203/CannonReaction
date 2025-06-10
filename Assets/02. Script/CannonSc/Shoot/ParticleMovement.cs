using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    private Transform particlePo;

    private ParticleSystem myPar;

    public bool making = true;
    public bool endSetting = false;

    void Update()
    {
        if (endSetting && myPar.isPlaying)
        {
            transform.position = particlePo.position;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Setting(Transform parPo)
    {
        myPar = GetComponent<ParticleSystem>();
        particlePo = parPo;
        gameObject.SetActive(false);
        endSetting = true;
    }
    private void OnEnable()
    {
        if (!making)
        {
            myPar.Play();
        }
        making = false;
    }
}
