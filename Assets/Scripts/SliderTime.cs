using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider bileşenini kullanabilmek için gerekli kütüphane

public class SliderTime : MonoBehaviour
{
    private PlayerController player_controller;
    private Slider timeSlider; // Slider bileşeni referansı
    public float current_time;
  

    void Start()
    {
        player_controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        timeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>(); // Slider bileşenini al
    }
    
    void Update()
    {
        current_time = player_controller.currentTime;
        Debug.Log("Current time: " + current_time);
        SlideTime();
        if (current_time <= 0)
        {   
            Debug.Log("player's current time is 0");
            timeSlider.gameObject.SetActive(false);
        }
    }

    void SlideTime()
    {
        current_time = player_controller.currentTime;
        timeSlider.value = current_time; // Slider'ın değerini güncelle
    }
}
