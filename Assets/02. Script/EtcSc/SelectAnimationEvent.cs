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
    private void Awake()
    {
        button = GetComponent<Button>();
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
        if (isThat)
        {
            Debug.Log("dsf");
            EndSelect?.Invoke();
        }
    }
}
