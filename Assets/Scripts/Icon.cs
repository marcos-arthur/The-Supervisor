using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameControllerObject;
    private GameController gameControllerInstance;
    public GameObject iconGameObject;

    public bool isDeskTopIcon = true;

    public Texture2D cursorTexture;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDeskTopIcon)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {

            }

            //Use this to tell when the user left-clicks on the Button
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                gameControllerInstance.setopenedApp("Explorer");

                GameObject newIcon = Instantiate(iconGameObject, new Vector3(0, 0, 0), Quaternion.identity);
                IconController iconController = newIcon.GetComponent<IconController>();

                iconController.isDeskTopIcon = false;
                iconController.cursorTexture = cursorTexture;

                newIcon.name = iconGameObject.name;
                newIcon.transform.SetParent(GameObject.Find("TaskBar Icons").transform, false);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(gameControllerInstance.getdefaultCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameControllerInstance = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
