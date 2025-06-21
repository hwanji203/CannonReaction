using UnityEngine;

public class ExpCollect : MonoBehaviour
{
    private ExpGauge expGauge;

    private void Awake()
    {
        expGauge = GetComponent<ExpGauge>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ExpEnable>(out ExpEnable exp))
        {
            if (!exp.gameObject.GetComponent<ExpMove>().FirstMove)
            {
                expGauge.ExpUp();
                exp.gameObject.SetActive(false);
                exp.PushExp();
            }
        }
    }
}