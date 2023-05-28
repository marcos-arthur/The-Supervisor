using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunnerGameController : MonoBehaviour
{
    public float[] spawnYs;
    public float totalTime = 60f;
    private float timeLeft;
    public Text timeText;
    public Text scoreText;
    public static int pontos = 0;
    public GameObject[] obstaculos; // Array de obstáculos disponíveis
    public float spawnDelay; // Delay entre o spawn de um obstáculo e outro
    public float minY; // Altura mínima do obstáculo
    public float maxY; // Altura máxima do obstáculo
    public float spawnPosX; // Posição X onde o obstáculo deve ser spawnado

    private float spawnTime; // Tempo do último spawn de obstáculo

    // Start is called before the first frame update
    void Start()
    {
        //instance_Runner_BGM.start();
        timeLeft = totalTime;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + pontos.ToString();
        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(timeLeft).ToString();

        if(timeLeft <= 0)
        {
            SceneManager.LoadScene("RunnerEnd");
        }

        // Verifica se já passou o tempo de spawn do próximo obstáculo
        if (Time.time > spawnTime + spawnDelay + Random.Range(0f,2f))
        {
            // Seleciona um obstáculo aleatório do array
            int randomIndex = Random.Range(0, obstaculos.Length);
            GameObject obstaculo = obstaculos[randomIndex];

            // Calcula a posição e a altura do obstáculo
            
            //float spawnPosY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(spawnPosX, spawnYs[Random.Range(0,3)], 0);

            // Instancia o obstáculo na posição calculada
            Instantiate(obstaculo, spawnPos, Quaternion.identity);

            // Atualiza o tempo do último spawn de obstáculo
            spawnTime = Time.time;
        }
        if(totalTime <= 0)
        {
            Debug.Log("tempo over");
            //instance_Runner_BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //instance_Runner_Win.start();
        }
    }
}

