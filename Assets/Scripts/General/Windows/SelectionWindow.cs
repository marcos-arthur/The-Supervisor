using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWindow : MonoBehaviour
{
    public static SelectionWindow Instance;

    [field: SerializeField] public List<GameObject> selectedItems = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void addItem(GameObject go)
    {
        if (selectedItems.Contains(go))
        {
            selectedItems.Remove(go);
            // go.GetComponentsInChildren<GameObject>()[1].Color;
        }
        else
        {
            selectedItems.Add(go);
        }
    }
}
