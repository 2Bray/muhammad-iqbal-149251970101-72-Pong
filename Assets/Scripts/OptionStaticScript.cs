using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionStaticScript
{
    //script static untuk menyimpan nilai dari 1 scene ke scene yang lain


    //Singleton
    private static OptionStaticScript instance = null;
    public static OptionStaticScript Instance
    {
        get => instance ?? new OptionStaticScript();
    }

    private static int ballSpeed = 4;
    private static int paddleSpeed = 4;

    public void SetBallSpeed(int v) => ballSpeed = v;
    public void SetPaddleSpeed(int v) => paddleSpeed = v;

    public int GetBallSpeed() => ballSpeed;
    public int GetPaddleSpeed() => paddleSpeed;
}
