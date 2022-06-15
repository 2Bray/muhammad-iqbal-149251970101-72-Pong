using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    //Class Parent Untuk Seluruh Power Up

    private PowerUpManager manager;
    private float timer = 0;

    private void Start()
    {
        manager = FindObjectOfType<PowerUpManager>();
        timer = 0;
    }

    private void Update()
    {
        //Menghapus Power Up Jika Tidak Juga Terkena Bola Dalam 20sec
        timer += Time.deltaTime;

        if (timer > manager.spawnInterval * 2)
        {
            manager.RemovePowerUp(this);
            timer -= manager.spawnInterval * 2;
        }
    }

    //Akan diisi oleh masing-masing power up dengan masing-masing powernya.
    public abstract void Active(Collider2D col);

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            //Eksekusi ketika mengenai bola
            Active(collision);
            manager.RemovePowerUp(this);
        }
    }
}
