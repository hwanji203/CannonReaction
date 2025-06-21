using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject son;

    private void Awake()
    {
        son.SetActive(false);
    }
    public void CFadeEnd()
    {
        son.SetActive(true);
    }

    public void ReStart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
