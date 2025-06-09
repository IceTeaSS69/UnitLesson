using TMPro;
using UnityEngine;


public class Walk : MonoBehaviour
{
    
    public TMP_Text CashBalance; //����� �� �����
    public int Cash = 0;//���������� �����
    public void OnTriggerEnter2D(Collider2D collider) //��������� � ������� 1
    {
        if (collider.CompareTag("Coin"))
        {
            Cash++;//����������� �����
        }
        if (collider.CompareTag("Coin2"))
        {
            Cash++;
            Cash++;
            Cash++;
        }
    }
    public void OnCollisionEnter2D(Collision2D Collision) //�������� � ������� 2
    {
        if (Collision.gameObject.CompareTag("Coin"))
        {  
            Cash++;//����������� �����
            CashBalance.text = $"{Cash}";//����� ���������� ����� � ����� �� ������
        }
        if (Collision.gameObject.CompareTag("Coin2"))
        {
            Cash++;
            Cash++;
            Cash++;
            CashBalance.text = $"{Cash}";
        }
    }


    
    void Update() //������ � �����������
    {
        if (Input.GetKey(KeyCode.D))//������ ������
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.05f,0,0);
            transform.localScale = new Vector3(2, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))//������ �����
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(0.05f, 0, 0);
            transform.localScale = new Vector3(-2, 1, 1);
        }
        else//����� ����������
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
