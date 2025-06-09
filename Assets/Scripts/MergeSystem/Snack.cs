using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Snack : MonoBehaviour              //과자 오브젝트에 부착되는 스크립트
{
    

    public float score;

    //과자 타입을 int로 만든다 
    public int snackType;

    //과자가 이미 합쳐졌는지 확인하는 플레그
    public bool hasMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //이미 합쳐진 과자는 무시
        if (hasMerged)
            return;

        //다른 과자와 충돌했는지 확인
        Snack otherSnack = collision.gameObject.GetComponent<Snack>();

        //충돌한 것이 과자고 타입이 같다면
        if(otherSnack != null && !otherSnack.hasMerged && otherSnack.snackType == snackType)
        {
            //합쳤다고 표시
            hasMerged = true;
            otherSnack.hasMerged = true;

            //두 과자의 중간 위치 계산
            Vector3 mergePosition = (transform.position + otherSnack.transform.position) / 2f;

            //다음 단계 과자로 업그레이드 구현 완성
            SnackGame gameManager = FindObjectOfType<SnackGame>();
            if(gameManager != null )
            {
                gameManager.MergeSnacks(snackType,mergePosition);

                ItemObject item = collision.gameObject.GetComponent<ItemObject>();

                if (gameManager != null)
                {
                    gameManager.score += item.GetPoint(); 
                }
            }

            //기존 과자 제거
            Destroy(otherSnack.gameObject);
            Destroy(gameObject);

        }
    }
}
