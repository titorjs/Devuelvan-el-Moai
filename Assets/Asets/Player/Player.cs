using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    public Rigidbody rb;
    private float hInput;
    public float hmulti;
    TilesGenerator tilesGenerator;
    public static int coins;
    public static float distancia;
    public TMP_Text coinText;
    public TMP_Text distanciaText;

    private float maxHorizontalDisplacement = 2.5f;
    private Vector3 lastPosition;

    public GameObject ingameCoins;
    public GameObject ingameDistance;
    public GameObject finalMessage;
    public TMP_Text coinTextFinis;
    public TMP_Text distanciaTextFinish;

    private float centralZoneWidth = 200f; // Ancho de la zona central en píxeles

    void Start()
    {
        speed = Constants.initialPlayerSpeed;
        hmulti = Constants.hmulti;
        tilesGenerator = GameObject.FindObjectOfType<TilesGenerator>();
        coins = 0;
        distancia = 0;
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 fwMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 hMove = transform.right * hInput * speed * Time.fixedDeltaTime * hmulti;

        Vector3 newPosition = rb.position + fwMove + hMove;

        // Limitar el desplazamiento horizontal
        newPosition.x = Mathf.Clamp(newPosition.x, -maxHorizontalDisplacement, maxHorizontalDisplacement);

        // Actualizar la distancia recorrida
        distancia += Vector3.Distance(lastPosition, newPosition);
        lastPosition = newPosition;

        // Actualizar la UI de distancia
        distanciaText.text = "Distancia: " + Mathf.FloorToInt(distancia).ToString() + "m";

        rb.MovePosition(newPosition);
    }

    private void Update()
    {
        hInput = 0; // Resetear hInput cada frame

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                float screenWidth = Screen.width;
                float touchPositionX = touch.position.x;
                float centralZoneMin = (screenWidth / 2) - (centralZoneWidth / 2);
                float centralZoneMax = (screenWidth / 2) + (centralZoneWidth / 2);

                if (touchPositionX < centralZoneMin)
                {
                    hInput = -1; // Mover a la izquierda
                }
                else if (touchPositionX > centralZoneMax)
                {
                    hInput = 1; // Mover a la derecha
                }
                // Si está en la zona central, no se hace nada
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.museumHallTag))
        {
            tilesGenerator.SpawnTile();
            Destroy(other.gameObject, 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.moaiCoinTag))
        {
            coins++;
            coinText.text = "Moais: " + coins.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag(Constants.obstacleTag))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        ingameCoins.SetActive(false);
        ingameDistance.SetActive(false);

        coinText.text = "Moais: " + Player.coins.ToString();
        distanciaText.text = "Distancia: " + Mathf.FloorToInt(Player.distancia).ToString() + "m";
        finalMessage.SetActive(true);

        Time.timeScale = 0;
    }
}
