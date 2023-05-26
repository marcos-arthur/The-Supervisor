using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class FishingPlayerController : MonoBehaviour
{
    FreeFishController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FreeFishController.Instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameController != null)
        {
            if (collision.CompareTag("fish"))
            {
                gameController.CatchFish(collision.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
