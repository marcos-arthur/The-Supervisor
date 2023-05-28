using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIcon : MonoBehaviour
{
    [SerializeField] public bool gamedenied = false;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private string windowToOpen = "";

    [SerializeField] private bool isDesktopIcon = true;
    [SerializeField] private bool isGame;

    private bool isAppOpen = false;

    private GameController gameControllerInstance;
    private GameObject iconTaskbarInstance;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance.FinishedGameApps.Contains(gameObject.name))
        {
            gamedenied = true;
        }

        gameControllerInstance = FindObjectOfType<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void ChangeAlphaColor(float alphaValue)
    {
        Color m_color = sr.color;
        m_color.a = alphaValue;
        sr.color = m_color;
    }

    private void InstanceWindow()
    {
        if (isGame) gameControllerInstance.OpenGame(windowToOpen);
        else gameControllerInstance.OpenWindow(windowToOpen);
    }

    private void InstanceTaskBarIcon()
    {
        iconTaskbarInstance = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        iconTaskbarInstance.transform.localScale = new Vector3(0.64f, 0.64f);

        Color tmpColor = iconTaskbarInstance.gameObject.GetComponent<SpriteRenderer>().color;
        tmpColor.a = 0f;
        iconTaskbarInstance.gameObject.GetComponent<SpriteRenderer>().color = tmpColor;

        ObjectIcon iconController = iconTaskbarInstance.GetComponent<ObjectIcon>();

        iconController.isDesktopIcon = false;
        iconController.cursorTexture = cursorTexture;

        iconTaskbarInstance.name = gameObject.name;
        iconTaskbarInstance.transform.SetParent(GameObject.Find("Taskbar").transform, false);

        GameObject taskBar = iconTaskbarInstance.transform.parent.gameObject;
        int openWindows = (taskBar.GetComponentsInChildren<Transform>().Length - 1) / 2;
        iconTaskbarInstance.transform.position = new Vector3(iconTaskbarInstance.transform.position.x + (0.75f * openWindows), iconTaskbarInstance.transform.position.y, 0);

        GameObject iconObject = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
        GameObject newIconObject = iconTaskbarInstance.GetComponentsInChildren<Transform>()[1].gameObject;

        SpriteRenderer icon = iconObject.GetComponent<SpriteRenderer>();
        SpriteRenderer newIcon = newIconObject.GetComponent<SpriteRenderer>();

        newIcon.sprite = icon.sprite;
    }

    private void OnMouseDown()
    {
        ChangeAlphaColor(1f);

        if(gamedenied==false)
        {
            if (isDesktopIcon && !isAppOpen)
            {
                isAppOpen = true;
                GameController.instance.FinishedGameApps.Add(gameObject.name);
                InstanceTaskBarIcon();
                InstanceWindow();
            }
        }
        
    }

    private void OnMouseUp()
    {
        ChangeAlphaColor(0.5f);
    }

    private void OnMouseEnter()
    {
        ChangeAlphaColor(0.5f);
        Cursor.SetCursor(gameControllerInstance.getClickCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        ChangeAlphaColor(0f);
        Cursor.SetCursor(gameControllerInstance.getDefaultCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }
}
