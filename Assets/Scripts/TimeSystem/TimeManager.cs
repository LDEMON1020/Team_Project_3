using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f; // 다시하기 버튼 눌렀을때 버튼에 시간이 흐르는 스크립트를 적용해도 안되길래 , 아예 씬을 불러올 때 시간이 흐르게 타임 매니저 설정함.
    }
}
