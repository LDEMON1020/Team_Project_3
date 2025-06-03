using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpLine : MonoBehaviour
{
    public HpManager hpmanager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snack"))
        {
            {
                SnackCollisionHandler snack = collision.GetComponent<SnackCollisionHandler>();

                if(snack != null && !snack.LineHit)
                {
                    snack.LineHit = true;
                    hpmanager.DecreaseHP(1f / 3f);
                    Destroy(collision.gameObject); // 과자 제거
                }
            }
        }
    }

}
