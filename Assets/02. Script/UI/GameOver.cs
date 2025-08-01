using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject son;
    private RecordSystem sys;

    private void Awake()
    {
        sys = FindAnyObjectByType<RecordSystem>();
    }

    private void Start()
    {
        son.SetActive(false);
    }
    public void CFadeEnd()
    {
        sys.UpdateTime();
        son.SetActive(true);
        Cursor.visible = true;
    }
}
