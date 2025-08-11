using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Brzina kretanja igrača
    private Rigidbody2D rb;            // Referenca na Rigidbody2D komponentu
    private Vector2 movement;          // Vektor za čuvanje ulaznih vrednosti za kretanje

    void Start()
    {
        // Uzimamo referencu na Rigidbody2D komponentu sa istog GameObject-a
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Uzimamo ulaz sa tastature za horizontalno i vertikalno kretanje (WASD ili strelice)
        movement.x = Input.GetAxisRaw("Horizontal"); // -1, 0 ili 1 za levo-desno
        movement.y = Input.GetAxisRaw("Vertical");   // -1, 0 ili 1 za dole-gore
    }

    void FixedUpdate()
    {
        // Pomera Rigidbody2D na novu poziciju, koristeći ulaz i brzinu, u skladu sa FixedUpdate frekvencijom
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
