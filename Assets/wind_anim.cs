using UnityEngine;
using UnityEngine.UI;

public class wind_anim : MonoBehaviour
{
    private Image img;
    private SpriteRenderer sprite;

    public float speed = 2f;     // vitesse du mouvement
    public bool bolanim = true;

    public float minX = -108f;    // position de départ
    public float maxX = 48f;     // position de fin

    void Start()
    {
        img = GetComponent<Image>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!bolanim) return;

        // --- Déplacement vers la droite ---
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; // avance progressivement
        transform.position = pos;

        // --- Quand on atteint x = 48, on repart à x = -48 ---
        if (pos.x >= maxX)
        {
            pos.x = minX;
            transform.position = pos;
        }
    }
}
