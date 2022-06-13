using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private Transform spawnArea;
    [SerializeField] private int maxPowerUpAmount;
    [SerializeField] private Vector2 powerUpAreaMin;
    [SerializeField] private Vector2 powerUpAreaMax;

    [SerializeField]private List<GameObject> powerUpTemplateList;
    private List<PowerUp> powerUpList;

    [SerializeField] private int spawnInterval;
    private float timer;

    private void Start()
    {
        powerUpList = new List<PowerUp>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        Vector3 pos = position;
        pos.z = powerUpTemplateList[randomIndex].transform.position.z;

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], pos, Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp.GetComponent<PowerUp>());
    }

    public void RemovePowerUp(PowerUp powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp.gameObject);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
} 
