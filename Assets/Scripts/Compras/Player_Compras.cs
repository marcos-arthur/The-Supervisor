using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Compras : MonoBehaviour
{
    public int speed;


  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(new Vector3(-speed *Time.fixedDeltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(new Vector3(speed * Time.fixedDeltaTime, 0, 0));
        }
    }
}
