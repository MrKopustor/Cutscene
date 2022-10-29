using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator; //Объявление ссылочной переменной 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // if player presses w key
        if (Input.GetKey("w"))
        {
            //then set the isWalking boolean to be true
            animator.SetBool("isWalking", true);
        }
        // if player is not pressing w key 
        if (!Input.GetKey("w")) 
        {
            //then set the isWalking boolean to be false 
            animator.SetBool("isWlking", false);
        }
    }
}
