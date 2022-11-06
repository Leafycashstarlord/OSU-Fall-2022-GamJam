using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject coinModel;
    [SerializeField] int lifePenalty = 1;

    Bank bank;
    
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void DropCoin(){
        Vector3 position = transform.position;
        GameObject coin = Instantiate(coinModel, position, Quaternion.identity);
        coin.SetActive(true);
        Destroy(coin, 20f);
    }

    public void LooseLife(){
        if(bank == null){
            return;
        }
        bank.looseLife(lifePenalty);
    }
}
