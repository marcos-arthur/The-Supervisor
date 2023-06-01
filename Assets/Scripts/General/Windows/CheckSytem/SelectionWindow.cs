using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionWindow : MonoBehaviour
{
    public static SelectionWindow Instance;

    [field: Header("Assets Lists")]
    [field: SerializeField] public List<GameObject> StolenItems { get; private set; }
    [field: SerializeField] public List<GameObject> selectedItems = new();

    [Header("Game Object references")]
    [field: SerializeField] private Button confirmButton;

    [Header("Text references")]
    [field: SerializeField] private TMP_Text selectedText;
    [field: SerializeField] private TMP_Text angryText;

    public int SelectLimit { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        confirmButton.onClick.AddListener(GameController.instance.OpenScoreWindow);
    }

    public void SetValues(List<GameObject> m_stolenItems)
    {
        StolenItems = m_stolenItems;
        SelectLimit = m_stolenItems.Count;

        selectedText.text = "0 / " + SelectLimit;
    }

    /*
     Returns true if was possible to select an asset
     */
    public bool AddItem(GameObject go)
    {
        bool returnValue = false;

        bool isSelected = selectedItems.Remove(go);
        if (!isSelected) { 
            if (selectedItems.Count >= SelectLimit) {
                // do something
                returnValue = false;
            }
            else
            {
                selectedItems.Add(go);
                returnValue = true;
            }
        }

        selectedText.text = selectedItems.Count + " / " + SelectLimit;

        return returnValue;
    }

    public void ShowAngryText()
    {
        angryText.gameObject.SetActive(true);
    }
}