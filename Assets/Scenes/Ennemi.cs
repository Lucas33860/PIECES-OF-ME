using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float timer = 0f;

    public GameObject bulletPrefab;

    public AudioSource EnemyShootSound;



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            SpawnBullet();
            if (EnemyShootSound != null && EnemyShootSound.clip != null)
            {
                AudioSource.PlayClipAtPoint(EnemyShootSound.clip, transform.position);
            }
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
