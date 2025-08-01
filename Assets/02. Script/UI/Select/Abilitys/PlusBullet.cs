using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlusBullet : BrickAbility
{
    private TextMeshProUGUI[] texts;

    private Button button;
    [SerializeField] Sprite[] sprite;
    SpriteState spriteState;
    private Image image;

    private void Awake()
    {
        MaxCount = 2;

        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.transition = Selectable.Transition.SpriteSwap;
        spriteState = new SpriteState
        {
            highlightedSprite = sprite[1]
        };


        texts = new TextMeshProUGUI[4];
        for (int i = 0; i < 4; i++)
        {
            texts[i] = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }
    public override void Ability()
    {
        CountPlus();
        GameObject cannons = GameObject.Find("Cannons");
        for (int i = 0; i < 3; i++)
        {
            if (Count == 1)
            {
                cannons.transform.GetChild(i).GetComponent<CannonShoot>().ChangeFire(2);
            }
            else
            {
                cannons.transform.GetChild(i).GetComponent<CannonShoot>().ChangeFire(3);
            }
        }
    }

    private void OnEnable()
    {
        if (Count == 1)
        {
            texts[0].gameObject.SetActive(false);
            texts[1].gameObject.SetActive(false);
            texts[2].gameObject.SetActive(true);
            texts[3].gameObject.SetActive(true);
            button.spriteState = spriteState;
            image.sprite = sprite[0];
        }
    }
}
