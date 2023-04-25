using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public int livesCount = 3;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtScore;
    public int CoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtLives.text = livesCount.ToString();
    }

    private void Update()
    {
        txtLives.text = livesCount.ToString();
        Debug.Log(CoinCount);
        
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.name == "Ventilador" || collision.gameObject.CompareTag("Damager"))
        {
            LoseALife();
        }
        if (collision.gameObject.CompareTag ("Coin"))
        {
            ScorePoint();
            Destroy(collision.gameObject);
        } 
        
    }
    void LoseALife()
    {
        transform.position = initialPosition;
        livesCount--;
        if (livesCount == 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        Destroy(gameObject);
    }
    void ScorePoint()
    {
        CoinCount++;
        txtScore.text = CoinCount.ToString();
        if(CoinCount == 3)
        {
            txtScore.text = "Ganaste";
        }
    }
}
