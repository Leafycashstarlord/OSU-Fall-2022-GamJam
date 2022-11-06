using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    int currentBalance;
    [SerializeField] int startingLife = 5;
    int currentLife;
    public int CurrentBalance{
        get{
            return currentBalance;
        }
    }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI displayLife;

    void Awake(){
        currentBalance = startingBalance;
        currentLife = startingLife;
        updateDisplay();
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        updateDisplay();
    }

    public void Withdraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        updateDisplay();
    }

    public void looseLife(int amount){
        currentLife -= Mathf.Abs(amount);

        if(currentLife <= 0){
            ReloadScene();
        }

        updateDisplay();
    }

    void updateDisplay(){
        displayBalance.text = "Gold: " + currentBalance;
        displayLife.text = "Life: " + currentLife;
    }

    void ReloadScene(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
