using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueIntro : MonoBehaviour
{
    public TextMeshProUGUI texteUI;
    [TextArea(2, 5)]
    public string[] textes; // tableau de textes à afficher
    public float vitesseEcriture = 0.04f; // vitesse d'apparition des lettres
    public float tempsEntreTextes = 1.5f; // temps avant d'effacer et passer au suivant

    public GameObject panel; // 👈 le panel à cacher à la fin

    private void Start()
    {
        if (panel != null)
            panel.SetActive(true); // s'assurer que le panel est visible au début

        StartCoroutine(AfficherTextes());
    }

    IEnumerator AfficherTextes()
    {
        foreach (string texte in textes)
        {
            // effacer immédiatement le texte précédent
            texteUI.text = "";

            // écriture lettre par lettre
            foreach (char lettre in texte.ToCharArray())
            {
                texteUI.text += lettre;
                yield return new WaitForSeconds(vitesseEcriture);
            }

            // attendre un peu avant d'effacer
            yield return new WaitForSeconds(tempsEntreTextes);

            // effacement progressif (optionnel, sinon vous pouvez l'enlever)
            for (int i = texteUI.text.Length - 1; i >= 0; i--)
            {
                texteUI.text = texteUI.text.Substring(0, i);
                yield return new WaitForSeconds(0.02f);
            }
        }

        // une fois tous les textes terminés, cacher le panel
        if (panel != null)
            panel.SetActive(false);
    }
}