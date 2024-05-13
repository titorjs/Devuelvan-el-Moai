using System;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GameObject center;
    public GameObject coin;

    void Start()
    {
        generateCoins();
        generateObstacles();
    }

    private void generateObstacles()
    {
        
    }

    private void generateCoins()
    {
        int coins = UnityEngine.Random.Range(1, 6);
        for (int i = 0; i < coins; i++)
        {
            float z = UnityEngine.Random.Range(-3, 3);
            float x = UnityEngine.Random.Range(-5, 5);

            Vector3 position = new Vector3(center.transform.position.x + x, 1f, center.transform.position.z + z);

            // Instanciar el coin como hijo del objeto TileBehaviour
            GameObject newCoin = Instantiate(coin, position, Quaternion.identity, transform);
        }
    }
}
