using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instanca za globalni pristup
    public static GameManager Instance;

    [Header("UI Elements")]
    public Text timerText;              // Običan UI Text za prikaz vremena
    public TextMeshProUGUI coinText;    // TextMeshPro UI za prikaz broja pokupjenih coina
    public Text winText;                // TextMeshPro UI za prikaz poruke pobede
    public Text loseText;               // TextMeshPro UI za prikaz poruke gubitka

    [Header("Game Settings")]
    public float timeLimit = 30f;       // Ukupno vreme trajanja igre u sekundama
    public int totalCoins = 3;          // Ukupan broj coina u sceni

    private float currentTime;          // Trenutno preostalo vreme
    private int collectedCoins = 0;     // Broj pokupjenih coina
    private bool gameOver = false;      // Flag koji označava kraj igre

    private void Awake()
    {
        // Singleton pattern: ako instanca ne postoji, postavi ovu kao instancu
        // Ako postoji, uništi ovu da bi izbegao duplikate
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Postavi početno vreme i broj coina
        currentTime = timeLimit;
        collectedCoins = 0;

        // Automatski prebroj coine na sceni
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Sakrij poruke o pobedi i porazu na početku
        if (winText != null)
            winText.gameObject.SetActive(false);
        if (loseText != null)
            loseText.gameObject.SetActive(false);

        // Prikazi inicijalne vrednosti na UI
        UpdateCoinUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        // Ako je igra završena, ne izvršavaj dalje update logiku
        if (gameOver)
            return;

        // Oduzmi proteklo vreme od trenutnog vremena
        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        // Ako vreme istekne, igrač je izgubio
        if (currentTime <= 0)
        {
            LoseGame();
        }
    }

    // Poziva se kada igrač pokupi coin
    public void AddCoin()
    {
        collectedCoins++;
        UpdateCoinUI();
    }

    // Ažurira UI sa trenutnim brojem pokupjenih coina
    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = $"Coins: {collectedCoins}/{totalCoins}";
    }

    // Ažurira UI sa preostalim vremenom (zaokruženo na gore)
    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = $"Time: {Mathf.Ceil(currentTime)}";
    }

    // Provera da li su svi coini pokupjeni
    public bool AllCoinsCollected()
    {
        return collectedCoins >= totalCoins;
    }

    // Funkcija za završetak igre - gubitak
    public void GameOver()
    {
        // Poziva LoseGame za prikaz poruke i pauziranje
        LoseGame();
    }

    // Funkcija za prikaz pobede
    public void WinGame()
    {
        if (gameOver) return; // Ne radi ništa ako je igra već gotova

        if (winText != null)
        {
            winText.text = "YOU WIN!";
            winText.gameObject.SetActive(true);
        }

        Debug.Log("Igra je pobedjena!");
        gameOver = true;
        Time.timeScale = 0f; // Pauzira igru
    }

    // Funkcija za prikaz poruke gubitka
    public void LoseGame()
    {
        if (gameOver) return; // Ne radi ništa ako je igra već gotova

        if (loseText != null)
        {
            loseText.text = "YOU LOST!";
            loseText.gameObject.SetActive(true);
        }

        Debug.Log("Igra je izgubljena!");
        gameOver = true;
        Time.timeScale = 0f; // Pauzira igru
    }

    // Omogućava restart igre pritiskom na R kada je igra završena
    private void LateUpdate()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; // Vrati vreme na normalu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
        }
    }
}
