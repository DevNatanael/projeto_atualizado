using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController life = other.GetComponent<LifeController>();

        if(life != null)
        {
            life.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
