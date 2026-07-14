using UnityEngine;


public class CoinManager : MonoBehaviour
{
    
    public static CoinManager Instance { get; private set; }

    [Header("--- コイン所持情報 ---")]
    private int currentCoins = 0;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            transform.position = Vector3.zero; 
            InitializeCoins(20); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

   
    public void InitializeCoins(int count)
    {
        currentCoins = count;
        Debug.Log("ゲーム開始！初期所持コイン: " + currentCoins);
    }

   
    public void AddCoin(int amount = 1)
    {
        currentCoins += amount;
        Debug.Log("? コインをゲット！現在の所持コイン: " + currentCoins);
        
    }

    public int GetCurrentCoinCount()
    {
        return currentCoins;
    }
}
