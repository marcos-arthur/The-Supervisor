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
    private bool hasSpace = true;

    private void Start()
    {
        selfButon = GetComponent<Button>();

       /* selfButon.onClick.AddListener(delegate { SelectionWindow.Instance.AddItem(gameObject); });
        selfButon.onClick.AddListener(SelectIcon);*/

        selfButon.onClick.AddListener(HandleSelection);
        
    }

    private void HandleSelection()
    {
        hasSpace = SelectionWindow.Instance.AddItem(gameObject);
        SelectIcon();
    }

    public void SelectIcon()
    {
        ColorBlock colors = selfButon.colors;

        if (isSelected)
        {
            colors.normalColor = Color.white;
            selfButon.colors = colors;

            Color originalColor = selfButon.image.color;
            originalColor.a = 0f;
            selfButon.image.color = originalColor;

            isSelected = false;
        } else if (hasSpace)
        {
            colors.normalColor = new Color(0.004f, 0.459f, 0.925f, 0.816f);
            selfButon.colors = colors;

            Color originalColor = selfButon.image.color;
            originalColor.a = 1f;
            selfButon.image.color = originalColor;

            isSelected = true;
        }
    }

}
