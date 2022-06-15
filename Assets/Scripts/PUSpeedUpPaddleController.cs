﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : PowerUp
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private PaddleController[] paddle;

    public override void Active(Collider2D col)
    {
        if (col == ball)
        {
            paddle[0].LongPaddle();
            paddle[1].LongPaddle();
        }
    }
}