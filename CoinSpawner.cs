using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
   
    [Header("--- スポナーのアイテム設定 ---")]
    public GameObject coinPrefab;
    public Transform spawnPoint; 
    public Vector3 spawnPosition = new Vector3(0, 0, 0); 

    [Header("--- スポナーのエリア設定 ---")]
    
    public float spawnWidth = 20f;
    public float spawnDepth = 30f;
    public int numberOfCoins = 50;
    public float spawnDelay = 0.1f;

    [Header("--- プレイヤーの所持コイン ---")]
   
    public int initialCoinCount = 20;
    private int currentCoins;


    void Start()
    {
        
        currentCoins = initialCoinCount;

        StartCoroutine(SpawnCoins());

        Debug.Log("ゲームスタート！現在の所持コイン: " + currentCoins);
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryDepositCoin(); // コイン投入処理を呼び出す関数を実行
        }

        
    }


    /// スペースキーが押されたときに実行
    
    void TryDepositCoin()
    {
      
        if (currentCoins > 0)
        {
           
            currentCoins -= 1;

           
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        }
        else
        {
           
            Debug.Log("コインがありません！投入できません。");
        }
    }


    
    IEnumerator SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            float randomX = Random.Range(-spawnWidth / 2f, spawnWidth / 2f);
            float randomZ = Random.Range(-spawnDepth / 2f, spawnDepth / 2f);

            float randomY = 1f;
            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            GameObject spawnedCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
   
}
