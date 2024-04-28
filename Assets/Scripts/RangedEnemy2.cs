using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{
    public float moveSpeed; // Düşmanın hareket hızı
    public Transform player; // Oyuncu referansı
    public Transform shotPoint; // Mermi çıkış noktası
    public Transform gun; // Silahın transformu
    public GameObject enemyProjectile; // Düşmanın ateş ettiği mermi prefab'ı
    public float maxHealth = 500f; // Düşmanın maksimum canı
    public float followPlayerRange; // Oyuncuyu takip etme menzili
    public float damage = 50f;
    private bool inRange; // Oyuncu menzilde mi?
    public float attackRange; // Ateş etme menzili
    public float startTimeBtwnShots; // Mermi atma aralığı
    private float timeBtwnShots; // Sonraki mermi atışı için zaman sayacı
    private bool isFlipped;
    void Update()
    {
        Flip();
        // Silahın oyuncuya doğru dönmesi
        Vector3 differance = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        // Oyuncu menzilde mi kontrolü
        if (Vector2.Distance(transform.position, player.position) <= followPlayerRange && Vector2.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        // Oyuncu menzildeyse ve ateş menziline girmişse
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Mermi atma aralığı kontrolü
            if (timeBtwnShots <= 0)
            {
                // Mermi oluşturma
                Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
                // Zamanı sıfırla
                timeBtwnShots = startTimeBtwnShots;
            }
            else
            {
                // Zamanı azalt
                timeBtwnShots -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        // Oyuncu menzildeyse, oyuncuyu takip et
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer Player düşman objesiyle temas ederse
        if (other.CompareTag("PlayerBullet"))
        {
            // Debug mesajı
            Debug.Log("PlayerBullet Enemy'e temas etti");
            // Canı azalt
            maxHealth -= damage; ;
            // Canı 0'dan küçük veya eşitse
            if (maxHealth <= 0)
            {
                // Ölüm fonksiyonunu çağır
                Die();
            }
        }
    }

    private void Die()
    {
        // Düşmanı yok et
        Destroy(gameObject);
    }

    // Gizmos çizimi
    void OnDrawGizmos()
    {
        // Takip menzili çizimi
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        // Ateş menzili çizimi
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public void Flip()
    {
        // Fare konumunu dünya koordinatlarına dönüştür.
        // Silahın konumunu ve fare konumu arasındaki yönü bul.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Vector2 lookDirection = (Vector2)playerObject.transform.position - (Vector2)transform.position;

            // Yön vektöründen açıyı hesapla.
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            if (angle < -90 && angle > -180) // 3. bolge
            {
                if (!isFlipped)
                {
                    FlipEnemy();
                }
            }
            else if (angle > 90 && angle < 180) // 2. bolge
            {
                if (!isFlipped)
                {
                    FlipEnemy();
                }
            }
            else
            {
                if (isFlipped)
                {
                    FlipEnemy();
                }
            }
        }
        void FlipEnemy()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFlipped = !isFlipped;

        }
    }
}
