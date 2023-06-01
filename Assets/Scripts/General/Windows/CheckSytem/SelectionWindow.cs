using System.Collections;
using System.Collections.Generic;
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

    public int SelectLimit { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        confirmButton.onClick.AddListener(delegate { GameController.instance.OpenScoreWindow(); });
    }

    public void SetValues(List<GameObject> m_stolenItems)
    {
        StolenItems = m_stolenItems;
        SelectLimit = m_stolenItems.Count;
    }

    /*
     Returns true if was possible to select an asset
     */
    public bool AddItem(GameObject go)
    {
        print(selectedItems.Count);
        print(SelectLimit);

        bool isSelected = selectedItems.Remove(go);
        if (!isSelected) { 
            if (selectedItems.Count >= SelectLimit) {
                // do something
                return false;
            }
            else
            {
                selectedItems.Add(go); 
                return true;
            }
        }

        return false;
    }
}