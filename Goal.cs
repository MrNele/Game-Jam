using UnityEngine;

public class Goal : MonoBehaviour
{
    // Kada neki objekat uđe u trigger zonu cilja
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Proveravamo da li je to Player
        if (other.CompareTag("Player"))
        {
            // Ako su svi coini prikupljeni
            if (GameManager.Instance.AllCoinsCollected())
            {
                // Pokreni proceduru za pobedu
                GameManager.Instance.WinGame();
            }
            else
            {
                // Ako igrač još nije pokupio sve coine
                Debug.Log("Pokupi sve coine pre nego što odeš do cilja!");
            }
        }
    }
}
