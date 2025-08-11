using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(); // obavesti GameManager da je coin pokupjen
            Destroy(gameObject); // Uništava coin kad ga igrač dodirne
        }
    }
}
