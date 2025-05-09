using System.Collections;
using UnityEngine;

public class AniLeft : MonoBehaviour
{
    private Animator ani;
    private int shootHash = Animator.StringToHash("Shoot");

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Shoot()
    {
        ani.SetTrigger(shootHash);
    }
}
