using System;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GameObject center;
    public GameObject coin;
    public List<GameObject> obstacles;
    public List<GameObject> enemies;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        generateCoins();
        generateObstacles();
        //generateEnemies();
    }

    private void generateEnemies()
    {
        if (TilesGenerator.tileCount > Constants.inicioEnemies)
        {
            float probability = UnityEngine.Random.value;
            if (probability <= Constants.guardsProbs)
            {
                Vector3 position;
                do
                {
                    float z = UnityEngine.Random.Range(-3, 3);
                    float[] possibleXPositions = { -1.8f, 0f, 1.8f };
                    float x = possibleXPositions[UnityEngine.Random.Range(0, possibleXPositions.Length)];
                    position = new Vector3(center.transform.position.x + x, 0f, center.transform.position.z + z);
                } while (usedPositions.Contains(position));

                usedPositions.Add(position);

                // Seleccionar un enemigo aleatorio de la lista
                GameObject enemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];

                // Instanciar el enemigo como hijo del objeto TileBehaviour
                GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity, transform);
            }
        }
    }

    private void generateObstacles()
    {
        if (TilesGenerator.tileCount > Constants.inicioObstacles)
        {
            int numObstacles = UnityEngine.Random.Range(1, 4); // Generar entre 1 y 3 obstáculos
            for (int i = 0; i < numObstacles; i++)
            {
                Vector3 position;
                do
                {
                    float z = UnityEngine.Random.Range(-3, 3);
                    float[] possibleXPositions = { -1.8f, 0f, 1.8f };
                    float x = possibleXPositions[UnityEngine.Random.Range(0, possibleXPositions.Length)];
                    position = new Vector3(center.transform.position.x + x, 0f, center.transform.position.z + z);
                } while (usedPositions.Contains(position));

                usedPositions.Add(position);

                // Seleccionar un obstáculo aleatorio de la lista
                GameObject obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Count)];

                // Instanciar el obstáculo como hijo del objeto TileBehaviour
                GameObject newObstacle = Instantiate(obstacle, position, Quaternion.identity, transform);
            }
        }
    }

    private void generateCoins()
    {
        int coins = UnityEngine.Random.Range(1, 6);
        for (int i = 0; i < coins; i++)
        {
            Vector3 position;
            do
            {
                float z = UnityEngine.Random.Range(-3, 3);
                float[] possibleXPositions = { -1.8f, 0f, 1.8f };
                float x = possibleXPositions[UnityEngine.Random.Range(0, possibleXPositions.Length)];
                position = new Vector3(center.transform.position.x + x, 0f, center.transform.position.z + z);
            } while (usedPositions.Contains(position));

            usedPositions.Add(position);

            // Instanciar el coin como hijo del objeto TileBehaviour
            GameObject newCoin = Instantiate(coin, position, Quaternion.identity, transform);
        }
    }
}
