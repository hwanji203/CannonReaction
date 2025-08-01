using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private float fadeSpeed = 1f;

    private bool isFading = false;
    private Color originColor;

    private GameObject son;

    [SerializeField] private float waitTime;

    private void Awake()
    {
        Cursor.visible = false;

        son = transform.GetChild(0).gameObject;
        son.SetActive(false);

        if (targetImage == null)
            targetImage = GetComponent<Image>();

        originColor = targetImage.color;
        targetImage.color = new Color(originColor.r, originColor.g, originColor.b, 0f); // 시작 시 투명하게
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFading = true;
        }

        if (isFading && targetImage.color.a < 1f)
        {
            float newAlpha = Mathf.MoveTowards(targetImage.color.a, 1f, fadeSpeed * Time.deltaTime);
            targetImage.color = new Color(originColor.r, originColor.g, originColor.b, newAlpha);
        }
        if (targetImage.color.a >= 1f)
        {
            son.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

}
