using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionIcon : MonoBehaviour
{
    private Button selfButon;
    private bool isSelected = false;

    private void Start()
    {
        selfButon = GetComponent<Button>();

        selfButon.onClick.AddListener(SelectIcon);
        selfButon.onClick.AddListener(delegate { SelectionWindow.Instance.addItem(gameObject); });
    }

    public void SelectIcon()
    {
        // selfButon.colors.normalColor = new Color(17, 147, 190, 208);

        ColorBlock colors = selfButon.colors;
        if (isSelected)
        {
            colors.normalColor = Color.white;
            selfButon.colors = colors;

            isSelected = false;
        } else
        {
            colors.normalColor = new Color(0.004f, 0.459f, 0.925f, 0.816f);
            selfButon.colors = colors;

            isSelected = true;
        }
    }

}
