using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController_Compras : MonoBehaviour
{
    public static int pontuacao = 0;

    [field: Header("Values")]
    public GameObject[] baloes;
    public Vector3 posicaoSpawn;
    public int qtdCompras;
    public float delaySpawn;
    public float tempoDeJogo;

    [field: Header("Textfield references")]
    public Text pontuacaoTxt;
    public Text tempoTxt;
    public Text texto;

    private float tempoAtual;
    private bool jogoFinalizado;

    private void Start()
    {
        pontuacao = 0;
        tempoAtual = tempoDeJogo;
        jogoFinalizado = false;
        
        AtualizarPontuacaoTXT();
        AtualizarTempo();
        InvokeRepeating("SpawnarBaloes", delaySpawn, delaySpawn);
    }

    private void Update()
    {
        if (!jogoFinalizado)
        {
            tempoAtual -= Time.deltaTime;
            AtualizarTempo();

            if (tempoAtual <= 0)
            {
               
                FinalizarJogo();
            }
        }
        texto.text = "Score: " + pontuacao.ToString();

    }

    private void SpawnarBaloes()
    {
        if (qtdCompras >= 0)
        {
            GlobalPointsController.instance.currentGameHasStolenAssets = true;
         
            Vector3 positionspawner = new Vector3(Random.Range(-6.58f, -0.62f), 20.67f, 0);
            int indiceBalao = Random.Range(0, baloes.Length);
            Instantiate(baloes[indiceBalao], positionspawner, Quaternion.identity);
            qtdCompras++;
        }
        else
        {
            CancelInvoke("SpawnarBaloes");
        }
    }

    public void AtualizarPontuacao(int valor)
    {
        if (valor == 0)
        {
            pontuacao = 0;
        }
        else
            pontuacao += valor;
        AtualizarPontuacaoTXT();
    }

    private void AtualizarPontuacaoTXT()
    {
        //pontuacaoTxt.text = "Pontuação: " + pontuacao.ToString();
    }

    private void AtualizarTempo()
    {
        tempoTxt.text = "Time: " + Mathf.RoundToInt(tempoAtual).ToString() + "s";
    }

    private void FinalizarJogo()
    {
        jogoFinalizado = true;
        SceneManager.LoadScene("ComprasGameOver");
    }
}
