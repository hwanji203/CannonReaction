using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonWarp : MonoBehaviour
{
    private float end;
    [SerializeField] private float plus;
    private GameObject clone;

    private static bool oneClone = false;

    private void Start()
    {
        end = EndManager.Instance.RightEnd;
    }

    private void Update()
    {
        MainWarp();

        if (gameObject.transform.position.x + 2 * plus > end && !oneClone)
        {
            Debug.Log("fsdf");
            clone = Instantiate(gameObject);
            clone.GetComponent<CannonWarp>().enabled = false;
            clone.transform.position -= new Vector3(2 * end, gameObject.transform.position.y, 0);
            oneClone = true;
        }
        else if (gameObject.transform.position.x - 2 * plus < -end && !oneClone)
        {
            clone = Instantiate(gameObject);
            clone.GetComponent<CannonWarp>().enabled = false;
            clone.transform.position += new Vector3(2 * end, gameObject.transform.position.y, 0);
            oneClone = true;
        }
    }

    private void MainWarp()
    {
        if (gameObject.transform.position.x - plus > end)
        {
            gameObject.transform.position -= new Vector3(2 * end, gameObject.transform.position.y, 0);
        }
        else if (gameObject.transform.position.x + plus < -end)
        {
            gameObject.transform.position += new Vector3(2 * end, gameObject.transform.position.y, 0);
        }
    }
}
