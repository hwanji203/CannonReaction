using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthSystem : MonoBehaviour
{
    [SerializeField] private int MaxHp = 30;
    public int Hp { get; private set; }

    private Slider slider;
    [SerializeField] private TextMeshProUGUI hpText;

    private CameraShake cam;

    private CannonDead dead;
    public bool IsEnd { get; set; } = false;
    private void Awake()
    {
        Hp = MaxHp;
        slider = GetComponent<Slider>();
        dead = FindAnyObjectByType<CannonDead>();
        cam = FindAnyObjectByType<CameraShake>();
    }

    private void Start()
    {
        slider.maxValue = MaxHp;
        slider.minValue = 0;

        StartCoroutine(SliderMove());

        GetHeal(10);
    }

    public void GetDamage(int damage)
    {
        if (!IsEnd)
        {
            if (damage < Hp)
            {
                Hp -= damage;
                slider.value = Hp;
                hpText.text = $"{Hp}/{MaxHp}";
                cam.Shake(new Vector2(-1, 0));
            }
            else
            {
                slider.value = 0;
                hpText.text = $"{0}/{MaxHp}";
                dead.DeadM();
            }
        }
    }
    public void GetHeal(int healValue)
    {
        if (!IsEnd)
        {
            if (Hp + healValue >= MaxHp)
            {
                Hp = MaxHp;
            }
            else
            {
                Hp += healValue;
            }
            slider.value = Hp;
            hpText.text = $"{Hp}/{MaxHp}";
        }
    }

    private IEnumerator SliderMove()
    {
        Hp = 0;
        do
        {
            yield return new WaitForSecondsRealtime(0.04f);
            Hp++;
            slider.value = Hp;
            hpText.text = $"{Hp}/{MaxHp}";
        }
        while (slider.value != slider.maxValue);
    }
}
