using TMPro;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text cashBalanceText;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private Vector3 rightScale = new Vector3(2f, 1f, 1f);
    [SerializeField] private Vector3 leftScale = new Vector3(-2f, 1f, 1f);
    [SerializeField] private Vector3 idleScale = new Vector3(1f, 1f, 1f);
    
    [Header("Game Data")]
    [SerializeField] private int cash = 0;
    
    // Кэшированные компоненты
    private Transform cachedTransform;
    
    // Константы для монет
    private const string COIN_TAG = "Coin";
    private const string COIN2_TAG = "Coin2";
    private const int COIN_VALUE = 1;
    private const int COIN2_VALUE = 3;
    
    private void Awake()
    {
        // Кэшируем transform для оптимизации
        cachedTransform = transform;
        UpdateCashDisplay();
    }
    
    private void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (horizontal != 0)
        {
            // Движение
            Vector3 movement = new Vector3(horizontal * moveSpeed, 0f, 0f);
            cachedTransform.position += movement;
            
            // Поворот спрайта
            cachedTransform.localScale = horizontal > 0 ? rightScale : leftScale;
        }
        else
        {
            // Состояние покоя
            cachedTransform.localScale = idleScale;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessCoinCollection(other.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCoinCollection(collision.gameObject);
    }
    
    private void ProcessCoinCollection(GameObject coinObject)
    {
        if (coinObject.CompareTag(COIN_TAG))
        {
            CollectCoin(COIN_VALUE);
            Destroy(coinObject);
        }
        else if (coinObject.CompareTag(COIN2_TAG))
        {
            CollectCoin(COIN2_VALUE);
            Destroy(coinObject);
        }
    }
    
    private void CollectCoin(int value)
    {
        cash += value;
        UpdateCashDisplay();
    }
    
    private void UpdateCashDisplay()
    {
        if (cashBalanceText != null)
        {
            cashBalanceText.text = cash.ToString();
        }
    }
    
    // Публичные методы для доступа к данным
    public int GetCash() => cash;
    
    public void AddCash(int amount)
    {
        if (amount > 0)
        {
            cash += amount;
            UpdateCashDisplay();
        }
    }
    
    public bool SpendCash(int amount)
    {
        if (amount > 0 && cash >= amount)
        {
            cash -= amount;
            UpdateCashDisplay();
            return true;
        }
        return false;
    }
}
