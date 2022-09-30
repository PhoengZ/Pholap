using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Animator animator;
    void Start()
    {
       animator = gameObject.GetComponent<Animator>(); 
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Explode");
        Invoke("DestroyBomb" , 0.11f);
    }

    void DestroyBomb(){
        Destroy(gameObject);

    }





    void Update()
    {

    }
}