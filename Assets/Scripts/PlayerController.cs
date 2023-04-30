using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    static int totalPoints = 0,copyrights = 0;   
    FishBehaviour fishBehaviour;
    public FishController fishController;
    public Text points,time;
    private bool isButtonDown = false;
    private float bTimer, timeLeft = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("fish"))
        {
            if (isButtonDown) // 0 para o botão esquerdo do mouse, 1 para o botão direito, 2 para o botão do meio
            {
                fishBehaviour = collision.gameObject.GetComponent<FishBehaviour>();
                totalPoints += fishBehaviour.getPoints();   
                if(fishBehaviour.copyright) copyrights++;
                Destroy(collision.gameObject);
                FishController temp = FindObjectOfType<FishController>();
                temp.DestroyFish();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            time.text = "Time : " + string.Format("{0:N0}", timeLeft) + " s";
            isButtonDown = Input.GetMouseButton(0);
            if (Input.GetMouseButton(0))
            {
                bTimer += Time.deltaTime;
                if (bTimer > 0.3)
                {
                    isButtonDown = false;
                }
            }
            else
            {
                bTimer = 0;
            }
        }
    }
    private void FixedUpdate()
    {        
        points.text = "Score: " + totalPoints.ToString();
    }
}
