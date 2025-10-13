using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float timer = 0f;

    public GameObject bulletPrefab;



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * 7f; 
        }
    }
}
