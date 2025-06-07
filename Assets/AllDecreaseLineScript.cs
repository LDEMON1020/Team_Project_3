using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDecreaseLineScript : MonoBehaviour
{
    public AllInManager allInManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snack"))
        {
            {
                SnackCollisionHandler snack = collision.GetComponent<SnackCollisionHandler>();

                if (snack != null && !snack.LineHit)
                {
                    snack.LineHit = true;
                    allInManager.DecreaseTime(10f);
                    allInManager.DecreaseHP(1f / 3f);
                    Destroy(collision.gameObject); // 과자 제거
                }
            }
        }
    }
}
