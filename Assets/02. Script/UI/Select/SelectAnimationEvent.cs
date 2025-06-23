using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnimationEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] smokePars;

    [field : SerializeField] public bool IsThat { get; set; } = false;

    LookMouse uiCannon;
    private Button button;

    private StartSelect startSelect;

    private Vector3 vector;

    private RectTransform rect;

    [SerializeField] private AudioClip bombClip;

    private void Awake()
    {
        button = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        vector = rect.anchoredPosition;

        uiCannon = FindAnyObjectByType<LookMouse>();

        startSelect = FindAnyObjectByType<StartSelect>();
    }

    private void OnEnable()
    {
        button.interactable = false;
    }

    public void CCanSelect()
    {
        button.interactable = true;
    }
    public void CCantSelect()
    {
        button.interactable = false;
    }

    public void CBombAd()
    {
        if (IsThat)
        {
            AudioManager.Instance.PlaySFX(bombClip, 1);
        }
    }

    public void CBomb()
    {
        if (IsThat)
        {
            foreach (ParticleSystem par in smokePars)
            {
                par.Play();
            }
            uiCannon.gameObject.SetActive(false);
            uiCannon.gameObject.SetActive(true);
            uiCannon.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            StartCoroutine(uiCannon.Enable());
        }
    }

    public void CEndSelect()
    {
        rect.anchoredPosition = vector;
        gameObject.SetActive(false);        
        if (IsThat)
        {
            startSelect.EndSelectSelectM();
        }
    }
    public void CEndSelect1()
    {
        rect.anchoredPosition = vector;
        gameObject.SetActive(false);
        if (IsThat)
        {
            startSelect.EndSelectSelectM();
        }
    }
}
