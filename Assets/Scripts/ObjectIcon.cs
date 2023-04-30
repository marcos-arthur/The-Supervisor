using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIcon : MonoBehaviour
{
    [SerializeField] private GameObject gameControllerObject;
    [SerializeField] private bool isDesktopIcon = true;
    [SerializeField] private string windowToOpen = "";
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private GameObject objectIcon;
    [SerializeField] private bool isGame;

    private GameController gameControllerInstance;
    private SpriteRenderer sr;

    private GameObject iconTaskbarInstance;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerInstance = gameControllerObject.GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeAlphaColor(float alphaValue)
    {
        Color m_color = sr.color;
        m_color.a = alphaValue;
        sr.color = m_color;
    }

    private void OnMouseDown()
    {
        changeAlphaColor(1f);

        if (isDesktopIcon && !isOpen)
        {
            isOpen = true;

            if (isGame)
            {
                gameControllerInstance.setopenedApp(windowToOpen);
            }
            else
            {
                gameControllerInstance.openWindow(windowToOpen);
            }

            iconTaskbarInstance = Instantiate(objectIcon, new Vector3(0, 0, 0), Quaternion.identity);

            ObjectIcon iconController = iconTaskbarInstance.GetComponent<ObjectIcon>();

            iconController.isDesktopIcon = false;
            iconController.cursorTexture = cursorTexture;
            iconController.gameControllerObject = gameControllerObject;

            iconTaskbarInstance.name = objectIcon.name;
            iconTaskbarInstance.transform.SetParent(GameObject.Find("Taskbar").transform, false);

            GameObject taskBar = iconTaskbarInstance.transform.parent.gameObject;
            int openWindows = (taskBar.GetComponentsInChildren<Transform>().Length - 1) / 2;
            iconTaskbarInstance.transform.position = new Vector3(iconTaskbarInstance.transform.position.x + (0.75f * openWindows), iconTaskbarInstance.transform.position.y, 0);
            // 0.75f

            GameObject iconObject = gameObject.GetComponentsInChildren<Transform>()[1].gameObject;
            GameObject newIconObject = iconTaskbarInstance.GetComponentsInChildren<Transform>()[1].gameObject;

            SpriteRenderer icon = iconObject.GetComponent<SpriteRenderer>();
            SpriteRenderer newIcon = newIconObject.GetComponent<SpriteRenderer>();

            newIcon.sprite = icon.sprite;
        }
    }

    private void OnMouseUp()
    {
        changeAlphaColor(0.5f);
    }

    private void OnMouseEnter()
    {
        changeAlphaColor(0.5f);
        Cursor.SetCursor(gameControllerInstance.getClickCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        changeAlphaColor(0f);
        Cursor.SetCursor(gameControllerInstance.getDefaultCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }
}
