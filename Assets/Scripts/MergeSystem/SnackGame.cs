using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnackGame : MonoBehaviour
{
    public GameObject[] snackPrefabs;                   //���� ������ �迭(�ͽ����Ϳ��� �Ҵ�)

    public float[] snackSizes = { 0.05f, 0.07f, 0.09f, 0.11f, 0.13f, 0.15f, 0.17f, 0.19f, 0.21f, 0.25f, 0.27f };           //���� ũ�� �迭

    public GameObject currentSnack;                 //���� ��� �ִ� ����
    public int currentSnackType;

    public float snackStartHeight = 6f;              //���� ���� ���� (�ν����Ϳ��� ���� ����0

    public float gameWidth = 5f;                     //������ ����

    public bool isGameOver = false;                 //���� ����
    public GameObject GameOverBlackPanel;
    
    public Camera mainCamera;                       //ī�޶� ����(���콺 ��ġ ��ȯ�� �ʿ�)

    public float snackTimer;              //�� �ð� ������ ���� Ÿ�̸�

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI FinalText;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;        //���� ī�޶� ���� ���� ����

        SpawnNewSnack();                    //���� ���� �� ù ���� ����
        snackTimer = -3.0f;                 //Ÿ�̸� �ð��� -3���� ������
    }
    private void Awake()
    {
        score = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            GameOver();
            return;
        }//���� ������ ����


        if (snackTimer >= 0 )                        //Ÿ�̸Ӱ� 0���� Ŭ ���
        snackTimer -= Time.deltaTime;

        if(snackTimer < 0 && snackTimer > -2)       //Ÿ�̸� �ð��� 0 �� - 2 ���̿� ������ ���� �ϰ�
        {
            SpawnNewSnack();
            snackTimer = -3.0f;                     //Ÿ�̸� �ð��� -3���� ������
        }

        if(currentSnack != null)            //���� ���ڰ� ���� ���� ó��
        {
            Vector3 mousePostion = Input.mousePosition;                     //���콺 ��ġ�� ���� X ��ǥ�� �̵� ��Ű�� ���� ���
            Vector3 worldPoision = mainCamera.ScreenToWorldPoint(mousePostion);

            Vector3 newPosition = currentSnack.transform.position;                      //���� ��ġ ������Ʈ (X��ǥ��,Y�� �״�� ����)
            newPosition.x = worldPoision.x;

            float halfSnackSize = snackSizes[currentSnackType] /2f;                     //���ڰ� �� ( �Ƹ���? )�̱� ������ �� ���� ������ �ٱ��� ������ �ȳ����� ����
            if(newPosition.x < -gameWidth / 2 + halfSnackSize)
            {
                newPosition.x = -gameWidth / 2 + halfSnackSize;
            }
            if (newPosition.x > gameWidth / 2 - halfSnackSize)
            {
                newPosition.x = gameWidth / 2 - halfSnackSize;
            }
            currentSnack.transform.position = newPosition;                          //���� ��ǥ ����

        }
        //���콺�� �� Ŭ���ϸ� ���� ����߸���
        if(Input.GetMouseButtonDown(0) && snackTimer == -3.0f)
        {
            DropSnack();
        }

        ScoreText.text = "" + score;
        FinalText.text = "Score : " + score;
    }

    public void MergeSnacks(int snackType, Vector3 position)
    {
        if (snackType < snackPrefabs.Length - 1)          
        {
            GameObject newSnack = Instantiate(snackPrefabs[snackType + 1], position, Quaternion.identity); 
                                                                                                           
            newSnack.transform.localScale = new Vector3(snackSizes[snackType + 1], snackSizes[snackType + 1], 1.0f);

            // �ڵ����� ������ ���·� ����
            Snack snackScript = newSnack.GetComponent<Snack>();
            if (snackScript != null)
            {
                snackScript.hasDropped = true;
            }

        }
    }



    void SpawnNewSnack()                    //���� ���� �Լ�
    {   
        if(!isGameOver)                         //���� ������ �ƴ� ���� �� ���� ����
        {
            currentSnackType = Random.Range(0, 3);          // 0 ~ 2 ������ ���� ���� Ÿ��

            Vector3 mousePostion = Input.mousePosition;
            Vector3 worldPoision = mainCamera.ScreenToWorldPoint(mousePostion);     //���콺 ��ġ�� ���� ��ǥ�� ��ȯ

            Vector3 spawnPosition = new Vector3(worldPoision.x, snackStartHeight, 0);       // X ��ǥ�� ����ϰ� Y�� ������ ���̷� , Z�� 2D�� 0���� ����

            float halfSnackSize = snackSizes[currentSnackType] / 2;
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halfSnackSize, gameWidth / 2 - halfSnackSize);  // X ��ġ�� ���� ������ ����� �ʵ��� ����

            currentSnack = Instantiate(snackPrefabs[currentSnackType], spawnPosition, Quaternion.identity);         //���� ����

            currentSnack.transform.localScale = new Vector3(snackSizes[currentSnackType], snackSizes[currentSnackType], 1f);    //���� ũ�� ����

            Rigidbody2D rb = currentSnack.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0f;
            }           
        }
       
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        HighScore.Tryset(SceneManager.GetActiveScene().buildIndex, (int)score);
        GameOverBlackPanel.SetActive(true);
    }

    void DropSnack()
    {
        if (currentSnack == null) return;

        Rigidbody2D rb = currentSnack.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1f;
        }

        //  ����߸� ���� hasDropped = true ����
        Snack snackScript = currentSnack.GetComponent<Snack>();
        if (snackScript != null)
        {
            snackScript.hasDropped = true;
        }

        currentSnack = null;
        snackTimer = 1.0f;
    }
}
