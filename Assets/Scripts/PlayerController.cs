using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Adiciona suporte ao TextMeshPro

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public int fireLevel = 1;
    public float fireRate;
    public float speed;
    private Rigidbody2D rig;
    public GameObject playerBullet;
    public Transform[] firePoints;
    public int lives = 3;
    private bool isDead = false;
    private SpriteRenderer sprite;
    private Vector3 startPosition;
    public float spawnTime;
    public float invincibilityTime;

    private float nextFire;
    public Boundary boundary;

    // Variáveis para o contador de tempo
    public TextMeshProUGUI timerText; // Referência ao componente de texto na tela
    private float remainingTime = 60f; // Tempo inicial (60 segundos)

    // Start é chamado antes do primeiro frame
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        startPosition = transform.position;

        // Inicializa o texto do contador
        if (timerText != null)
        {
            UpdateTimerText();
        }
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        GameManager.instance.SetLivesText(lives);
        UpdateTimer();

        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        // Limita o movimento do player
      //  rig.position = new Vector2(
      //      Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax),
      //      Mathf.Clamp(rig.position.y, boundary.yMin, boundary.yMax)
      //  );

        if (!isDead)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                if (fireLevel >= 1)
                {
                    Instantiate(playerBullet, firePoints[0].position, firePoints[0].rotation);
                }
            }
        }
    }

    private void UpdateTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                // Adicione aqui a lógica quando o tempo chegar a zero
                Debug.Log("O tempo acabou!");
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        // Atualiza o texto do tempo na UI
        if (timerText != null)
        {
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    public void Respawn()
    {
        lives--;

        if (lives > 0)
        {
            // Chama o Coroutine
            StartCoroutine(Spawning());
        }
        else
        {
            lives = 0;
            isDead = true;
            sprite.enabled = false;
        }
    }

    IEnumerator Spawning()
    {
        isDead = true;
        sprite.enabled = false;
        fireLevel = 0;
        yield return new WaitForSeconds(spawnTime);
        isDead = false;
        transform.position = startPosition;

        for (float i = 0; i < invincibilityTime; i += 0.1f)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sprite.enabled = true;
        fireLevel = 1;
    }
}
