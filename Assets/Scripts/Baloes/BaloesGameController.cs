using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaloesGameController : MonoBehaviour
{
    public static int pontuacao;

    public GameObject[] baloes;
    public Vector3 posicaoSpawn;
    public int qtdBaloes;
    public float delaySpawn;
    public float tempoDeJogo;
    public Text pontuacaoTxt;
    public Text tempoTxt;
    public Text jogoFinalizadoTxt;
    //private int pontuacao;
    private float tempoAtual;
    private bool jogoFinalizado;

    public Text texto;

    private void Start()
    {
        //instance_Baloes_BGM.start();
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
        if (qtdBaloes >= 0)
        {
            Vector3 positionspawner = new Vector3(Random.Range(-6.58f, -0.79f), 5.51f);
            int indiceBalao = Random.Range(0, baloes.Length);
            Instantiate(baloes[indiceBalao], positionspawner, Quaternion.identity);
            qtdBaloes++;
        }
        else
        {
            CancelInvoke("SpawnarBaloes");
        }
    }
    
    public void AtualizarPontuacao(int valor)
    {
        if(valor == 0)
        {
            pontuacao = 0;
        }
        else
            pontuacao += valor;
        Debug.Log(pontuacao);
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
        //instance_Baloes_BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //instance_Baloes_Win.start();
        jogoFinalizado = true;
        jogoFinalizadoTxt.gameObject.SetActive(true);
    }
}