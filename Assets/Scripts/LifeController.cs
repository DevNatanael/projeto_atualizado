using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int health;
    //public GameObject explosion;
    public Color damageColor;
    public bool isDead = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if(!isDead)
        {
            health -= damage;

            if(health <= 0)
            {
                //Instantiate(explosion, transform.position, transform.rotation);

                if(this.GetComponent<PlayerController>() != null)
                {

                    GetComponent<PlayerController>().Respawn();
                }else
                {
                    isDead = true;
                    Destroy(gameObject);
                }
            }else
            {
                StartCoroutine(TakeDamage());
            }
        }
    }

     IEnumerator TakeDamage()
        {
            sprite.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }
}
