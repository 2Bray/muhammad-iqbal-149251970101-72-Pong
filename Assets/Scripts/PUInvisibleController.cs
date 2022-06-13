using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUInvisibleController : PowerUp
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private Color color;

    public override void Active(Collider2D col)
    {
        if (col == ball)
        {
            //Menjadikan bola transparant
            ball.GetComponent<BallController>().ActivatePUInvisible(color);
        }
    }
}