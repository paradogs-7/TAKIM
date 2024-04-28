using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector2 movement;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float activeSpeed;
    public float dashSpeed;
    public float dashLenght = 5f, dashCooldown = 1f;
    public float dashCounter;
    public float dashCoolCounter;
    public float maxTime = 80f; // Maksimum zaman
    public float currentTime; // Geçen zaman
    public float timeDecreaseSpeed = 1f; // Zaman azalma hızı
    public float damageAmount = 10f; // Zarar miktarı
    private float timer = 1f; // Timer
    public Text TimeText;
    private bool isGameOver = false;
    public GameObject gameOverPanel;
    public int score = 0;
    void Start()
    {
        currentTime = 80f;
        gameOverPanel.SetActive(false); // gameOverPanel'i başlangıçta kapalı yap
        activeSpeed = moveSpeed;
    }
    void Update()
    {
        // Timer'ı azalt
        timer -= Time.deltaTime;
        // Eğer timer 0'a ulaşırsa
        if (timer <= 0)
        {
            // Zamanı azalt
            currentTime -= timeDecreaseSpeed;
            UpdateTimeText();
            // Timer'ı sıfırla
            timer = 1f;
        }
        // Oyuncu öldü mü kontrol et
        if (currentTime <= 0)
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            // Player'ın yatay ve dikey hareketini al
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            // Hareket vektörünü oluştur
            Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

            // Player'ı hareket ettir
            GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Oyun bitti! Yeniden başlatılıyor...");
                RestartGame();
            }
        }
    }
    void Die()
    {
        gameOverPanel.SetActive(true); // gameOverPanel'i aktifleştir
        TimeText.text = "Time's up! Press R to try again"; // TimeText'i güncelle
        isGameOver = true;
        // Oyuncu öldüğünde yapılacak işlemler
        // Bu kısımda oyunu yeniden başlatan veya oyunu bitiren kodlar yer alır
    }
    void UpdateTimeText()
    {
        TimeText.text = "TIME LEFT: " + currentTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer Player düşman objesiyle temas ederse
        if (other.CompareTag("Enemy1"))
        {
            Debug.Log("Enemy ile temasss");
            // Zamanı azalt
            currentTime -= damageAmount;
        }
        if (other.CompareTag("EnemyBullet"))
        {
            Debug.Log("EnemyBullet ile temasss");
            // Zamanı azalt
            // Zamanı azalt
            currentTime -= damageAmount;
        }
    }
    void RestartGame()
    {
        // Aktif olan sahneyi tekrar yükle
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

