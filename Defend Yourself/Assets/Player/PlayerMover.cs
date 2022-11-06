using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    Player player;
    float steerSpeed = 200f;
    float moveSpeed = 50f;
    
    void Start(){
        player = GetComponent<Player>();
    }
    
    void Update()
    {
        float yval = Input.GetAxis("Horizontal") * Time.deltaTime * steerSpeed;
        float zval = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Rotate(0, yval, 0);
        transform.Translate(0, 0, zval);
    }
}
