using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int lifePenalty = 1;
    [SerializeField] int goldReward = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject, 0.1f);
        bank.Deposit(goldReward);
    }

    public void LooseLife(){
        if(bank == null){
            return;
        }
        bank.looseLife(lifePenalty);
    }
}
