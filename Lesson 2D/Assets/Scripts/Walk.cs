using TMPro;
using UnityEngine;


public class Walk : MonoBehaviour
{
    
    public TMP_Text CashBalance; //Текст на вывод
    public int Cash = 0;//Количество монет
    public void OnTriggerEnter2D(Collider2D collider) //Коллайдер с монетой 1
    {
        if (collider.CompareTag("Coin"))
        {
            Cash++;//Прибавление монет
        }
        if (collider.CompareTag("Coin2"))
        {
            Cash++;
            Cash++;
            Cash++;
        }
    }
    public void OnCollisionEnter2D(Collision2D Collision) //Коллизия с монетой 2
    {
        if (Collision.gameObject.CompareTag("Coin"))
        {  
            Cash++;//Прибавление монет
            CashBalance.text = $"{Cash}";//Вывод количества монет в текст на экране
        }
        if (Collision.gameObject.CompareTag("Coin2"))
        {
            Cash++;
            Cash++;
            Cash++;
            CashBalance.text = $"{Cash}";
        }
    }


    
    void Update() //Ходьба с трансформом
    {
        if (Input.GetKey(KeyCode.D))//Ходьба вправо
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.05f,0,0);
            transform.localScale = new Vector3(2, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))//Ходьба влево
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(0.05f, 0, 0);
            transform.localScale = new Vector3(-2, 1, 1);
        }
        else//Ресет растяжения
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
