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
    public GameObject[] obstaculos; // Array de obst�culos dispon�veis
    public float spawnDelay; // Delay entre o spawn de um obst�culo e outro
    public float minY; // Altura m�nima do obst�culo
    public float maxY; // Altura m�xima do obst�culo
    public float spawnPosX; // Posi��o X onde o obst�culo deve ser spawnado

    private float spawnTime; // Tempo do �ltimo spawn de obst�culo

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

        // Verifica se j� passou o tempo de spawn do pr�ximo obst�culo
        if (Time.time > spawnTime + spawnDelay + Random.Range(0f,2f))
        {
            // Seleciona um obst�culo aleat�rio do array
            int randomIndex = Random.Range(0, obstaculos.Length);
            GameObject obstaculo = obstaculos[randomIndex];

            // Calcula a posi��o e a altura do obst�culo
            
            //float spawnPosY = Random.Range(minY, maxY);

            Vector3 spawnPos = new Vector3(spawnPosX, spawnYs[Random.Range(0,3)], 0);

            // Instancia o obst�culo na posi��o calculada
            Instantiate(obstaculo, spawnPos, Quaternion.identity);

            // Atualiza o tempo do �ltimo spawn de obst�culo
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

