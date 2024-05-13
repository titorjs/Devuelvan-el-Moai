using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed;
    public Rigidbody rb;
    private float hInput;
    public float hmulti;
    TilesGenerator tilesGenerator;
    public int coins;

    void Start()
    {
        speed = Constants.initialPlayerSpeed;
        hmulti = Constants.hmulti;
        tilesGenerator = GameObject.FindObjectOfType<TilesGenerator>();
        coins = 0;
    }

    private void FixedUpdate()
    {
        Vector3 fwMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 hMove = transform.right * speed * hInput * Time.fixedDeltaTime * hmulti;
        rb.MovePosition(rb.position + fwMove + hMove);
    }

    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.museumHallTag))
        {
            tilesGenerator.SpawnTile();
            Destroy(other.gameObject ,2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.moaiCoinTag))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }
}
