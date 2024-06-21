using UnityEngine;

public class MoaiCoin : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto sobre su propio eje
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Constants.coinRotation);
    }
}