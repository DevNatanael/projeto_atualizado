using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
    }

    // Método para detectar a colisão com meteoros
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o tiro colidiu com um meteoro
        if (other.CompareTag("Meteoro"))
        {
            // Destroi o meteoro e o tiro
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
