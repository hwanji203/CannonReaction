using UnityEngine;

public class SelectAnimationEvent : MonoBehaviour
{
    [SerializeField] private StartSelectManager sSM;

    [SerializeField] private bool isThat = false;
    public void CBomb()
    {
        if (isThat)
        {
            sSM.StartSelect();
        }
    }
}
