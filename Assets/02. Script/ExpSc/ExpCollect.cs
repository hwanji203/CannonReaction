using UnityEngine;

public class ExpCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ExpEnable>(out ExpEnable exp))
        {
            Debug.Log("ÄÝ·ºÆ® µÊ");
            exp.gameObject.SetActive(false);
            exp.PushExp();
        }
    }
}