using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Xposition;

    public Color targetColor; // Cor para a qual o objeto deve mudar
    private SpriteRenderer spriteRenderer; // Referência ao componente Sprite Renderer original

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtém a referência do componente Sprite Renderer
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && GetComponent<Transform>().position.y == 14.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 15.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W) && GetComponent<Transform>().position.y == 15.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 16.7f, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && GetComponent<Transform>().position.y == 14.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 15.5f, 0);  
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && GetComponent<Transform>().position.y == 15.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 16.7f, 0); 
        }




        if (Input.GetKeyDown(KeyCode.S) && GetComponent<Transform>().position.y > 16f)
        {
            gameObject.transform.position = new Vector3(Xposition, 15.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) && GetComponent<Transform>().position.y == 15.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 14.5f, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponent<Transform>().position.y >= 16f)
        {
            gameObject.transform.position = new Vector3(Xposition, 15.5f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponent<Transform>().position.y == 15.5f)
        {
            gameObject.transform.position = new Vector3(Xposition, 14.5f, 0);      
        }


    }
    private System.Collections.IEnumerator ChangeColorCoroutine()
    {
        Color initialColor = spriteRenderer.color; // Armazena a cor inicial do componente Sprite Renderer

        spriteRenderer.color = targetColor; // Muda a cor do componente Sprite Renderer para a cor alvo

        yield return new WaitForSeconds(0.1f); // Espera por 0,5 segundos

        spriteRenderer.color = initialColor; // Retorna à cor inicial
    }
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorCoroutine());
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag != "Obstacle")
        {
            return;
        }
        else if (col.gameObject.tag == "Obstacle")
        {
            RunnerGameController.pontos -= 50;
            Destroy(col.gameObject);
            ChangeColor();
            //instance_Runner_Fail.start();
        }

    }
}
