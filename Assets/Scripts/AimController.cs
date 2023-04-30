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

    // Update is called once per frame
    void Update()
    {
        float limit = -2;
        float calc = lineTop.transform.localScale.y - lineBottom.transform.localScale.y;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.y <= limit) transform.position = new Vector3(transform.position.x, limit-2, transform.position.z);        
        else if (mousePosition.y < calc) transform.position = new Vector3(transform.position.x, mousePosition.y * speed, transform.position.z);
        else transform.position = new Vector3(transform.position.x, calc, transform.position.z);
    }
}
