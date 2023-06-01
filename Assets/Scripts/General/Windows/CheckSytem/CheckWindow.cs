using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CheckWindow : MonoBehaviour
{
    public static CheckWindow instance;

    private readonly List<GameObject> CorrectStolenItem = new();
    private readonly List<GameObject> WrongStolenItem = new();
    private List<GameObject> missedStolenItem;

    [Header("Rows References")]
    [field: SerializeField] private HorizontalLayoutGroup correctStolenAssetsRow;
    [field: SerializeField] private HorizontalLayoutGroup notStolenAssetsRow;
    [field: SerializeField] private HorizontalLayoutGroup MissedStolenAssetsRow;

    [Header("Texts References")]
    [field: SerializeField] private TMP_Text partialScoreTxt;
    [field: SerializeField] private TMP_Text totalScore;

    private int individualPoints;
    private int count = 0;
    private int partialScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(ExplorerClose.Instance != null)
        {
            ExplorerClose.Instance.windowCloser();
        }
    }

    private void UpdateView()
    {
        foreach(GameObject item in CorrectStolenItem) Instantiate(item, correctStolenAssetsRow.transform);
        foreach (GameObject item in WrongStolenItem) Instantiate(item, notStolenAssetsRow.transform);
        foreach (GameObject item in missedStolenItem) Instantiate(item, MissedStolenAssetsRow.transform);

        partialScoreTxt.text = individualPoints + "x " + count + " = " + partialScore;
        totalScore.text = GlobalPointsController.instance.globalPoints + " points";
    }

    public void CheckItems(List<GameObject> selectedItems, List<GameObject> stolenItems)
    {
        individualPoints = 500 / selectedItems.Count;

        missedStolenItem = new();
        
        List<string> stolenItemsNames = new();
        List<string> missedStolenItemsNames = new();
        foreach (GameObject item in stolenItems)
        {
            Button bItem = item.GetComponent<Button>();
            ColorBlock colors = bItem.colors;

            colors.normalColor = new Color(0.004f, 0.459f, 0.925f, 0.816f);
            bItem.colors = colors;

            Color originalColor = bItem.image.color;
            originalColor.a = 1f;
            bItem.image.color = originalColor;

            stolenItemsNames.Add(item.name);
            missedStolenItem.Add(item);
            missedStolenItemsNames.Add(item.name);
        }

        foreach (GameObject selectedItem in selectedItems)
        {
            if (stolenItemsNames.Contains(selectedItem.name))
            {
                partialScore += individualPoints;
                CorrectStolenItem.Add(selectedItem);
                count++;

                int index = 0;
                if (missedStolenItemsNames.Contains(selectedItem.name))
                {
                    missedStolenItem.RemoveAt(index);
                    index++;
                }
            }
            else
            {
                WrongStolenItem.Add(selectedItem);
            }
        }

        if(partialScore >= selectedItems.Count / 6)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.correctAnswerSound, transform.position);
        }
        else
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.wrongAnswerSound, transform.position);
        }

        GlobalPointsController.instance.addPoints(partialScore);
        UpdateView();
    }
}
