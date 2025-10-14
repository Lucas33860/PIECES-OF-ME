using UnityEngine;
using UnityEngine.UI;

public class animationLumiere : MonoBehaviour
{
    public float blinkSpeed = 0.2f; // Vitesse du clignotement
    public bool useSinWave = true; // Optionnel : clignotement doux
    private Image img;
    private SpriteRenderer sprite;

    void Start()
    {
        img = GetComponent<Image>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alpha;

        if (useSinWave)
            alpha = (Mathf.Sin(Time.time * blinkSpeed * Mathf.PI * 2) + 1) / 2f; // Variation douce
        else
            alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f); // On/Off

        if (img != null)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
        else if (sprite != null)
        {
            Color c = sprite.color;
            c.a = alpha;
            sprite.color = c;
        }
    }
}
