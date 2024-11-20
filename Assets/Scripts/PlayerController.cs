using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.SetLivesText(lives);
        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        // limite do movimento do player
        rig.position = new Vector2(Mathf.Clamp(rig.position.x, boundary.xMin,boundary.xMax),
                                   Mathf.Clamp(rig.position.y, boundary.yMin, boundary.yMax));

        if(!isDead)
        {
            if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                if(fireLevel >= 1)
                {
                    Instantiate(playerBullet, firePoints[0].position, firePoints[0].rotation);
                }
            }
        }
    }

    public void Respawn()
    {
        lives--;

        if(lives > 0)
        {
            // chamar o corotine
            StartCoroutine(Spawning());
        }else
        {
            lives = 0;
            isDead = true;
            sprite.enabled = false;
        }

        //GameManager.instance.SetLivesText(lives);
    }

    IEnumerator Spawning()
    {
        isDead = true;
        sprite.enabled = false;
        fireLevel = 0;
        yield return new WaitForSeconds(spawnTime);
        isDead = false;
        transform.position = startPosition;

        for(float i = 0; i < invincibilityTime; i+=0.1f)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sprite.enabled = true;
        fireLevel = 1;
    }
}
