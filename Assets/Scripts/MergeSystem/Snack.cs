using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Snack : MonoBehaviour              //���� ������Ʈ�� �����Ǵ� ��ũ��Ʈ
{
    

    public float score;

    //���� Ÿ���� int�� ����� 
    public int snackType;

    //���ڰ� �̹� ���������� Ȯ���ϴ� �÷���
    public bool hasMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�̹� ������ ���ڴ� ����
        if (hasMerged)
            return;

        //�ٸ� ���ڿ� �浹�ߴ��� Ȯ��
        Snack otherSnack = collision.gameObject.GetComponent<Snack>();

        //�浹�� ���� ���ڰ� Ÿ���� ���ٸ�
        if(otherSnack != null && !otherSnack.hasMerged && otherSnack.snackType == snackType)
        {
            //���ƴٰ� ǥ��
            hasMerged = true;
            otherSnack.hasMerged = true;

            //�� ������ �߰� ��ġ ���
            Vector3 mergePosition = (transform.position + otherSnack.transform.position) / 2f;

            //���� �ܰ� ���ڷ� ���׷��̵� ���� �ϼ�
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

            //���� ���� ����
            Destroy(otherSnack.gameObject);
            Destroy(gameObject);

        }
    }
}
