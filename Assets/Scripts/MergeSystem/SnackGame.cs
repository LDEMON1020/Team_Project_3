using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnackGame : MonoBehaviour
{
    public GameObject[] snackPrefabs;                   //과자 프리팹 배열(익스펙터에서 할당)

    public float[] snackSizes = { 0.05f, 0.07f, 0.09f, 0.11f, 0.13f, 0.15f, 0.17f, 0.19f, 0.21f, 0.25f, 0.27f };           //스낵 크기 배열

    public GameObject currentSnack;                 //현재 들고 있는 과자
    public int currentSnackType;

    public float snackStartHeight = 6f;              //과자 시작 높이 (인스펙터에서 조절 가능0

    public float gameWidth = 5f;                     //게임판 정도

    public bool isGameOver = false;                 //게임 상태
    public GameObject GameOverBlackPanel;
    
    public Camera mainCamera;                       //카메라 참조(마우스 위치 변환에 필요)

    public float snackTimer;              //잰 시간 설정을 위한 타이머

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI FinalText;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;        //메인 카메라 참조 가져 오기

        SpawnNewSnack();                    //게임 시작 시 첫 과자 생성
        snackTimer = -3.0f;                 //타이머 시간을 -3으로 보낸다
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
        }//게임 오버면 종료


        if (snackTimer >= 0 )                        //타이머가 0보다 클 경우
        snackTimer -= Time.deltaTime;

        if(snackTimer < 0 && snackTimer > -2)       //타이머 시간이 0 과 - 2 사이에 있을때 잰을 하고
        {
            SpawnNewSnack();
            snackTimer = -3.0f;                     //타이머 시간을 -3으로 보낸다
        }

        if(currentSnack != null)            //현재 과자가 있을 때만 처리
        {
            Vector3 mousePostion = Input.mousePosition;                     //마우스 위치를 따라 X 좌표만 이동 시키기 위해 사용
            Vector3 worldPoision = mainCamera.ScreenToWorldPoint(mousePostion);

            Vector3 newPosition = currentSnack.transform.position;                      //과자 위치 업데이트 (X좌표만,Y는 그대로 유지)
            newPosition.x = worldPoision.x;

            float halfSnackSize = snackSizes[currentSnackType] /2f;                     //과자가 원 ( 아마도? )이기 때문에 반 값을 나눠서 바구니 밖으로 안나가게 설정
            if(newPosition.x < -gameWidth / 2 + halfSnackSize)
            {
                newPosition.x = -gameWidth / 2 + halfSnackSize;
            }
            if (newPosition.x > gameWidth / 2 - halfSnackSize)
            {
                newPosition.x = gameWidth / 2 - halfSnackSize;
            }
            currentSnack.transform.position = newPosition;                          //과자 좌표 갱신

        }
        //마우스를 좌 클릭하면 과자 떨어뜨리기
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

            // 자동으로 떨어진 상태로 간주
            Snack snackScript = newSnack.GetComponent<Snack>();
            if (snackScript != null)
            {
                snackScript.hasDropped = true;
            }

        }
    }



    void SpawnNewSnack()                    //과자 생성 함수
    {   
        if(!isGameOver)                         //게임 오버가 아닐 때만 새 과자 생성
        {
            currentSnackType = Random.Range(0, 3);          // 0 ~ 2 사이의 랜덤 과자 타입

            Vector3 mousePostion = Input.mousePosition;
            Vector3 worldPoision = mainCamera.ScreenToWorldPoint(mousePostion);     //마우스 위치를 월드 좌표로 변환

            Vector3 spawnPosition = new Vector3(worldPoision.x, snackStartHeight, 0);       // X 좌표만 사용하고 Y는 설정된 높이로 , Z는 2D라서 0으로 설정

            float halfSnackSize = snackSizes[currentSnackType] / 2;
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2 + halfSnackSize, gameWidth / 2 - halfSnackSize);  // X 위치가 게임 영역을 벗어나지 않도록 제한

            currentSnack = Instantiate(snackPrefabs[currentSnackType], spawnPosition, Quaternion.identity);         //과자 생성

            currentSnack.transform.localScale = new Vector3(snackSizes[currentSnackType], snackSizes[currentSnackType], 1f);    //과자 크기 설정

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

        //  떨어뜨릴 때만 hasDropped = true 설정
        Snack snackScript = currentSnack.GetComponent<Snack>();
        if (snackScript != null)
        {
            snackScript.hasDropped = true;
        }

        currentSnack = null;
        snackTimer = 1.0f;
    }
}
