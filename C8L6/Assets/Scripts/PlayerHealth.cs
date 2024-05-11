using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 5;
    public int health;
    public Image[] heartImages;
    
    public GameManagerScript GameManager;

    

    private void Start()
    {
        health = totalHealth;
        UpdateHearts();
    }

    public void AddDamage(int amount)
    {
        health -= amount;

        StartCoroutine("VisualFeedback");

        if (health <= 0)
        {
            health = 0;
            
            GameManager.gameOver();
            Debug.Log("El jugador ah muerto");
            UpdateHearts();

            
            Time.timeScale = 0f;

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("El jugador ah recibido daño su vida es " + health);
            UpdateHearts();
        }
    }

    public void AddHealth(int amount)
    {
        health += amount;

        if (health > totalHealth)
        {
            health = totalHealth;
        }

        Debug.Log("Player got some life. His current health is " + health);

        UpdateHearts();
    }

    private IEnumerator VisualFeedback()
    {
        foreach (var image in heartImages)
        {
            image.color = Color.red;
        }

        yield return new WaitForSeconds(0.1f);

        foreach (var image in heartImages)
        {
            image.color = Color.white;
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }
}
