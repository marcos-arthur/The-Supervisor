using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreWindow : MonoBehaviour
{
    public static ScoreWindow instance;

    private readonly List<GameObject> CorrectStolenItems = new();
    private readonly List<GameObject> WrongStolenItems = new();
    private List<GameObject> missedStolenItems;

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
        foreach(GameObject item in CorrectStolenItems) Instantiate(item, correctStolenAssetsRow.transform);
        foreach (GameObject item in WrongStolenItems) Instantiate(item, notStolenAssetsRow.transform);
        foreach (GameObject item in missedStolenItems) Instantiate(item, MissedStolenAssetsRow.transform);

        partialScoreTxt.text = individualPoints + "x " + count + " = " + partialScore;
        totalScore.text = GlobalPointsController.instance.globalPoints + " points";
    }

    public void CheckItems(List<GameObject> selectedItems, List<GameObject> stolenItems)
    {
        individualPoints = 500 / selectedItems.Count;

        missedStolenItems = new();
        
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

            item.GetComponent<RectTransform>().position = selectedItems[0].GetComponent<RectTransform>().position;
            item.GetComponent<RectTransform>().sizeDelta = selectedItems[0].GetComponent<RectTransform>().sizeDelta;
            missedStolenItems.Add(item);
            missedStolenItemsNames.Add(item.name);
        }

        foreach (GameObject selectedItem in selectedItems)
        {
            if (stolenItemsNames.Contains(selectedItem.name))
            {
                partialScore += individualPoints;
                CorrectStolenItems.Add(selectedItem);
                count++;
            }
            else
            {
                WrongStolenItems.Add(selectedItem);
            }
        }

        foreach(GameObject CorrectStolenItem in CorrectStolenItems)
        {
            if (missedStolenItemsNames.Contains(CorrectStolenItem.name))
            {
                foreach(GameObject missedItem in missedStolenItems) {
                    if (missedItem.name.Equals(CorrectStolenItem.name))
                    {
                        missedStolenItems.Remove(missedItem);
                        break;
                    }
                }
            }
        }

        if(partialScore >= selectedItems.Count * 3 / 5)
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
