using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(); // obave�tava GameManager da je coin pokupjen
            Destroy(gameObject); // uklanja coin sa scene
        }
    }
}