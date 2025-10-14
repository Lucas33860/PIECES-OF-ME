using System.Collections;
using UnityEngine;
using TMPro; // important si vous utilisez TextMeshPro

public class DialogueIntro : MonoBehaviour
{
    public TextMeshProUGUI texteUI;
    [TextArea(2, 5)]
    public string[] textes; // tableau de textes à afficher
    public float vitesseEcriture = 0.04f; // vitesse d'apparition des lettres
    public float tempsEntreTextes = 1.5f; // temps avant d'effacer et passer au suivant

    private void Start()
    {
        StartCoroutine(AfficherTextes());
    }

    IEnumerator AfficherTextes()
    {
        foreach (string texte in textes)
        {
            // écriture lettre par lettre
            texteUI.text = "";
            foreach (char lettre in texte.ToCharArray())
            {
                texteUI.text += lettre;
                yield return new WaitForSeconds(vitesseEcriture);
            }

            // attendre un peu avant d'effacer
            yield return new WaitForSeconds(tempsEntreTextes);

            // effacement progressif
            for (int i = texteUI.text.Length - 1; i >= 0; i--)
            {
                texteUI.text = texteUI.text.Substring(0, i);
                yield return new WaitForSeconds(0.02f);
            }
        }

        // une fois terminé
        texteUI.text = ""; // ou vous pouvez désactiver le panel si vous voulez
    }
}