using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnimationEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] smokePars;

    [SerializeField] private bool isThat = false;

    [SerializeField] LookMouse uiCannon;
    private Button button;

    public event Action EndSelect;

    private Vector3 vector;

    private RectTransform rect;
    private void Awake()
    {
        button = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        vector = rect.anchoredPosition;
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

    public void CBomb()
    {
        if (isThat)
        {
            foreach (ParticleSystem par in smokePars)
            {
                par.Play();
                StartCoroutine(uiCannon.Enable());
            }
        }
    }

    public void CEndSelect()
    {
        rect.anchoredPosition = vector;
        gameObject.SetActive(false);        
        if (isThat)
        {
            EndSelect?.Invoke();
        }
    }
    public void CEndSelect1()
    {
        rect.anchoredPosition = vector;
        gameObject.SetActive(false);
        if (isThat)
        {
            EndSelect?.Invoke();
        }
    }
}
