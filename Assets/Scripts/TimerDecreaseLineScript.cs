using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDecreaseLineScript : MonoBehaviour
{
    public TimerManager TimerManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snack"))
        {
            {
                SnackCollisionHandler snack = collision.GetComponent<SnackCollisionHandler>();

                if (snack != null && !snack.LineHit)
                {
                    snack.LineHit = true;
                    TimerManager.DecreaseTime(10f);
                    Destroy(collision.gameObject); // 과자 제거
                }
            }
        }
    }
}
