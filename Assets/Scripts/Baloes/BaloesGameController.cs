using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BaloesGameController : MonoBehaviour
{
    public static int pontuacao;

    [field: Header("Main References")]
    public GameObject[] baloes;
    public Vector3 posicaoSpawn;

    [field: Header("Textbox References")]
    public Text pontuacaoTxt;
    public Text tempoTxt;
    public Text jogoFinalizadoTxt;
    public Text texto;

    [field: Header("Game values")]
    public int qtdBaloes;
    public float delaySpawn;
    public float tempoDeJogo;
    
    private float tempoAtual;
    private bool jogoFinalizado;

    private void Start()
    {
        BaloesAudioController.Instance.StartPlaySceneAudios();

        pontuacao = 0;
        tempoAtual = tempoDeJogo;
        jogoFinalizado = false;

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

    private void AtualizarTempo()
    {
        tempoTxt.text = "Time: " + Mathf.RoundToInt(tempoAtual).ToString() + "s";
    }

    private void FinalizarJogo()
    {
        jogoFinalizado = true;
        SceneManager.LoadScene("BaloesEnd");
    }
}