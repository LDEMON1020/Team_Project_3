using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    // Start is called before the first frame update
    public SnackGame snackGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snack"))
        {
                SnackCollisionHandler snack = collision.GetComponent<SnackCollisionHandler>();

                if (snack != null && !snack.LineHit)
                {
                    snack.LineHit = true;                   
                    Destroy(collision.gameObject); // 과자 제거
                snackGame.isGameOver = true;
            }
        }
    }
}
