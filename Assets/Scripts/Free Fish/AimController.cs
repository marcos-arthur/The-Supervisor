using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lineTop;
    public GameObject lineBottom;
    public float speed;
    void Start()
    {
        
    }

    private bool wait = false;
    private IEnumerator timing(float limit, float calc, Vector2 mousePosition)
    {
        wait = true;
        //Debug.Log("limit" + limit);

        Debug.Log(lineTop.transform.localScale.y);
        Debug.Log(lineBottom.transform.localScale.y);

        Debug.Log("calc" + calc);
        Debug.Log(mousePosition);
        Debug.Log("-----------------------------");

        yield return new WaitForSeconds(1f);
        
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        float top_limit = 18;
        float bottom_limit = 14.5f;
        // float top_limit = 18;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!wait) StartCoroutine(timing(bottom_limit, top_limit, mousePosition));

        if (mousePosition.y <= bottom_limit) transform.position = new Vector3(transform.position.x, bottom_limit, transform.position.z);
        else if (mousePosition.y < top_limit) transform.position = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
        else transform.position = new Vector3(transform.position.x, top_limit, transform.position.z);
     
    }
}
