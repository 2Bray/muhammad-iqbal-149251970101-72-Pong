using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : PowerUp
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private float magnitude;

    public override void Active(Collider2D col)
    {
        if (col == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
        }
    }
}