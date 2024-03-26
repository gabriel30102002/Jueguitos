using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller3 : MonoBehaviour
{
  public Sprite[] mySprites;
    public GameObject projectilePrefab; // Prefab del objeto que se lanzará
    public float projectileSpeed = 5f; // Velocidad del proyectil
    public float fireRate = 2f; // Tasa de fuego (proyectiles por segundo)
    private SpriteRenderer mySpriteRenderer;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        StartCoroutine(FireRoutine());
    }

    IEnumerator WalkCoRoutine()
    {
         while (true)
    {
        yield return new WaitForSeconds(0.08f);
        if (mySprites.Length > 0)
        {
            mySpriteRenderer.sprite = mySprites[index];
            index = (index + 1) % mySprites.Length;
        }
        else
        {
            Debug.LogWarning("Array 'mySprites' is empty.");
        }
    }
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / fireRate);
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Calcular la dirección del jugador
            Vector2 playerDirection = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized;
            // Asignar la velocidad al proyectil
            rb.velocity = playerDirection * projectileSpeed;
        }
    }
}
