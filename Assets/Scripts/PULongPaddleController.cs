using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddleController : PowerUp
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private PaddleController[] paddle;

    public override void Active(Collider2D col)
    {
        if (col == ball)
        {
            paddle[0].SpeedUpPaddle();
            paddle[1].SpeedUpPaddle();
        }
    }
}