using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class enemyHealth : MonoBehaviour
{
    [Tooltip("Adds amount to enemy maxHP when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int maxHP = 5;
    int currentHP = 0;
    
    Enemy enemy;

    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) {
        processHit();
    }

    void processHit(){
        currentHP--;
        if(currentHP <= 0 && enemy.tag == "Car"){
            enemy.DropCoin();
            gameObject.SetActive(false);
            maxHP += difficultyRamp;
        }
        if(currentHP <= 0 && enemy.tag == "Plane"){
            enemy.DropCoin();
            enemy.DropCoin();
            gameObject.SetActive(false);
            maxHP += (difficultyRamp * 2);
        }
        if(currentHP <= 0 && enemy.tag == "Tank"){
            enemy.DropCoin();
            enemy.DropCoin();
            enemy.DropCoin();
            gameObject.SetActive(false);
            maxHP += (difficultyRamp * 3);
        }
    }
}
