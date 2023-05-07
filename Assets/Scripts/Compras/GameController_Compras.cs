using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController_Compras : MonoBehaviour
{

    public static int pontuacao = 0;

    public GameObject[] baloes;
    public Vector3 posicaoSpawn;
    public int qtdCompras;
    public float delaySpawn;
    public float tempoDeJogo;
    public Text pontuacaoTxt;
    public Text tempoTxt;
    public Text jogoFinalizadoTxt;
    //private int pontuacao;
    private float tempoAtual;
    private bool jogoFinalizado;

    public Text texto;

   // public FMOD.Studio.EventInstance instance_Compras_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/BGM");

    private void Start()
    {
        FMOD.Studio.EventInstance instance_Compras_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/BGM");
        instance_Compras_BGM.start();
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
            Vector3 positionspawner = new Vector3(Random.Range(-6f, 5.2f), 6, 0);
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
        FMOD.Studio.EventInstance instance_Compras_BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/BGM");
        instance_Compras_BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene("ComprasGameOver");
        jogoFinalizado = true;
        jogoFinalizadoTxt.gameObject.SetActive(true);
    }
}
