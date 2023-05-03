using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameController gameControllerInstance;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerInstance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.56f, 0.56f);

    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.6f, 0.6f);
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.58f, 0.58f);
        Cursor.SetCursor(gameControllerInstance.getClickCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.6f, 0.6f);
        Cursor.SetCursor(gameControllerInstance.getDefaultCursor(), Vector2.zero, CursorMode.ForceSoftware);
    }
}
