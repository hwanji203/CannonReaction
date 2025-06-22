using System;
using UnityEngine;

public class CannonDead : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject[] expCollectors;

    private CannonEvent[] events;

    private CastleHealthSystem castle;

    private void Awake()
    {
        castle = FindAnyObjectByType<CastleHealthSystem>();
    }
    private void Start()
    {
        events = new CannonEvent[3];

        events[0] = GameObject.Find("CannonL").GetComponent<CannonEvent>();
        events[1] = GameObject.Find("CannonR").GetComponent<CannonEvent>();
        events[2] = GetComponent<CannonEvent>();
    }

    private void OnEnable()
    {
        gameOverUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDeadZone"))
        {
            DeadM();
        }
    }

    public void DeadM()
    {
        castle.IsEnd = true;
        gameOverUI.SetActive(true);
        foreach (GameObject ob in expCollectors)
        {
            ob.SetActive(false);
        }
        foreach (CannonEvent ev in events)
        {
            ev.enabled = false;
        }
    }
}
    