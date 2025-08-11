using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerZone : MonoBehaviour
{
    // Ova metoda se poziva kada neki collider uđe u trigger zonu ovog objekta
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Proveravamo da li je objekat koji je ušao označen kao "Player"
        if (other.CompareTag("Player"))
        {
            // Ispisujemo poruku u konzolu da je igra gotova
            Debug.Log("GAME OVER");

            // Ponovo učitavamo aktivnu scenu da restartujemo igru
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
