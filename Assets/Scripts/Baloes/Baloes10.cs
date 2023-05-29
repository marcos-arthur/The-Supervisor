using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloes10 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite novoSprite;
    public ConstantForce2D forcaConstante;

    public int valor = 10;

    private IEnumerator metodo_destruir()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        if (gameObject)
        {
            BaloesAudioController.Instance.PlayPointSound();
            BaloesGameController.pontuacao += valor;

            novoSprite = Resources.Load<Sprite>("POPbalao");
            spriteRenderer.sprite = novoSprite;

            forcaConstante.force = new Vector2(0f, 0f);
            StartCoroutine(metodo_destruir());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        forcaConstante = GetComponent<ConstantForce2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
