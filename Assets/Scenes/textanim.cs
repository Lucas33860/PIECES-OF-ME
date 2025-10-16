using System.Collections;
using UnityEngine;
using TMPro;
using TMPEffects.Components;
using UnityEngine.Events;

public class DialogueIntro : MonoBehaviour
{
    public TextMeshProUGUI texteUI;
    public TMPWriter tmpWriter;
    public Transform canvas;
    [TextArea(2, 5)]
    public string[] textes; // tableau de textes à afficher
    public float vitesseEcriture = 0.04f; // vitesse d'apparition des lettres
    public float tempsEntreTextes = 1.5f; // temps avant d'effacer et passer au suivant

    public GameObject panel; // 👈 le panel à cacher à la fin

    public int TextIndex = -1;

    public UnityEvent OnEndDialog;

    private void Start()
    {

        if (panel != null)
            panel.SetActive(true); // s'assurer que le panel est visible au début

        ShowNextText();
        // StartCoroutine(AfficherTextes());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (tmpWriter.CurrentIndex == tmpWriter.CharData.Count - 1)
            {
                ShowNextText();
            }

        }
    }

    public void ShowNextText()
    {
        TextIndex++;
        if (TextIndex >= textes.Length)
        {
            // une fois tous les textes terminés, cacher le panel
            if (panel != null)
                panel.SetActive(false);
            canvas.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
            OnEndDialog?.Invoke();
            return;
        }
        texteUI.text = textes[TextIndex];
        tmpWriter.StartWriter();
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

            // effacement progressif beaucoup plus rapide
            for (int i = texteUI.text.Length - 1; i >= 0; i--)
            {
                texteUI.text = texteUI.text.Substring(0, i);
                yield return new WaitForSeconds(0.005f); // vitesse augmentée
            }
        }

        // une fois tous les textes terminés, cacher le panel
        if (panel != null)
            panel.SetActive(false);
    }
}