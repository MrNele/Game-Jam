using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 30f; // Ukupno vreme igre u sekundama
    public Text timerText;        // Referenca na UI Text komponentu za prikaz vremena

    private float currentTime;    // Trenutno preostalo vreme

    void Start()
    {
        // Postavljanje početnog vremena na definisanu vrednost
        currentTime = timeLimit;
    }

    void Update()
    {
        // Smanjuje preostalo vreme za vreme proteklo od poslednjeg frame-a
        currentTime -= Time.deltaTime;

        // Ako je UI Text komponenta postavljena, ažuriramo prikaz vremena na ekranu
        if (timerText != null)
        {
            // Math.Ceil zaokružuje vreme na veći ceo broj radi lepšeg prikaza
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
        }

        // Kada vreme istekne (stigne do ili ispod nule)
        if (currentTime <= 0)
        {
            Debug.Log("TIME UP - GAME OVER");
            // Reload trenutne scene radi resetovanja igre
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
