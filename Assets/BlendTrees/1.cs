using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator; //Объявление ссылочной переменной 
    int isWalkingHash; // для повышение производительности, заключается в использовании строки аниматора 
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //ищет в игровом объекте, к которому прикреплен наш скрипт.Любой компонент 
        //который мы передаем в качестве параметра, в данном случаи Аниматор.

        //increases performance
        isWalkingHash = Animator.StringToHash("isWalking"); // заменяем строковые параметры "isWalking" -> isWalkingHash, сохр в более простой тип данных
        isRunningHash = Animator.StringToHash("isRunning");// повторно используем хеш-функцию, для повышения производительности и упрощение кода 
    }

    // Update is called once per frame
    void Update()
    {
        bool isrunning = animator.GetBool(isRunningHash);//переменая работает вместо равно 
        bool isWalking = animator.GetBool(isWalkingHash); // дополнительное условие, мы используем аниматор, чтобы получить логическое значемние 
        //... и передать его в качестве параметра.И мы сохраним это в локальной переменой с тем же именем в нашем состоянии If 
        bool forwardPressed = Input.GetKey("w");// задали новую пременную Вперед нажатие -> ввод получить ключ к W
        // if player presses w key
        bool runPressed = Input.GetKey("left shift");//создание новой переменой для бега, при нажатие будет true 
        if (!isWalking && forwardPressed) //если мы не идем, а наш игрок нажимает вперед, то мы должны устаноить значение true 
        {
            //then set the isWalking boolean to be true
            animator.SetBool(isWalkingHash, true);
        }
        // if player is not pressing w key 
        if (isWalking && !forwardPressed) // ...если мы не идем, и игрок перестает нажимать вперед, тогда уст знач false 
        {
            //then set the isWalking boolean to be false 
            animator.SetBool(isWalkingHash, false);
        }

        //if player is walking and not running and pressed left shift 
        if (!isrunning && (forwardPressed && runPressed))
        {
            //then set the isRunning  boolean to be true 
            animator.SetBool(isRunningHash, true);
        }

        //if playear is running and stops renning or stops walking 
        if (isrunning && (!forwardPressed || !runPressed))
        {
            //then set the isRunning boolean to be false 
            animator.SetBool(isRunningHash, false);
        }
    }
}
