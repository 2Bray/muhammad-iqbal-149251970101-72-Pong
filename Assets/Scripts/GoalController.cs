using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] int idx;
    [SerializeField] private Collider2D Ball;
    [SerializeField] private ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //idx berisi siapa yang mencetak goal.
        //jika script ini ada di gawang kiri maka idx akan diisi oleh idx kanan (1)
        if (collision == Ball) scoreManager.AddScore(idx);
    }
}
