using System.Collections;
using TMPro;
using UnityEngine;

public class TextAppearEffect : MonoBehaviour
{
    public float revealDuration = 100f; // Duration of the text reveal in seconds

    private TextMeshProUGUI textMeshPro;
    private string fullText;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = textMeshPro.text;
        textMeshPro.text = ""; // Clear the text initially
        StartCoroutine(RevealTextRoutine());
    }

    private IEnumerator RevealTextRoutine()
    {
        float elapsedTime = 0f;
        int characterIndex = 0;

        while (elapsedTime < revealDuration && characterIndex < fullText.Length)
        {
            // Add one character at a time
            textMeshPro.text += fullText[characterIndex];

            characterIndex++;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the full text is shown
        textMeshPro.text = fullText;
    }
}

