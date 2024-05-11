using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class timecontroller : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;
    private float restante;
    private bool enMarcha;
    public PlayerHealth playerHealth;
    public GameManagerScript gameManager;
    public GameObject winMenuButtons;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }
    
    void Update()
{
    if (enMarcha)
    {
        restante -= Time.deltaTime;
        if (restante <= 0)
        {
            
            enMarcha = false;
            
            tiempo.text = "00:00";

            
            playerHealth.gameObject.SetActive(false);
            
            gameManager.gameWinUI();

            
            Time.timeScale = 0f;

            
            winMenuButtons.SetActive(true);
            Time.timeScale = 1f;
        }
        else
        {
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{0:00}:{1:00}", tempMin, tempSeg);
        }
    }
}
}
