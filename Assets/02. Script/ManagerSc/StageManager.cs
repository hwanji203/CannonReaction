using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    private GameObject cannon;
    private Rigidbody2D cannonRb;

    private GameObject Spawner;

    private GameObject expCollector;
    private void Awake()
    {
        cannon = GameObject.Find("Cannon");
        cannonRb = cannon.GetComponent<Rigidbody2D>();

        Spawner = GameObject.Find("SlimeSpawner");

        expCollector = GameObject.Find("ExpCollector");
    }

    private void Start()
    {
        cannonRb.gravityScale = 0;
        Spawner.gameObject.SetActive(false);
        expCollector.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            expCollector.SetActive(true);
            Spawner.gameObject.SetActive(true);
            cannonRb.gravityScale = cannon.GetComponent<CannonReaction>().MyGravityScale;
            enabled = false;
        }
    }
}
