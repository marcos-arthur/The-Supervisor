using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionIcon : MonoBehaviour
{
    public Button selfButon;

    private void Start()
    {
        selfButon = GetComponent<Button>();

        selfButon.onClick.AddListener(delegate { SelectionWindow.Instance.addItem(gameObject); });
    }


}
