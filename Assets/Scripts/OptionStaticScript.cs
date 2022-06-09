using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionStaticScript
{
    //script static untuk menyimpan nilai dari 1 scene ke scene yang lain

    private static int ballSpeed = 4;
    private static int paddleSpeed = 4;

    public static void SetBallSpeed(int v) => ballSpeed = v;
    public static void SetPaddleSpeed(int v) => paddleSpeed = v;

    public static int GetBallSpeed() => ballSpeed;
    public static int GetPaddleSpeed() => paddleSpeed;
}
