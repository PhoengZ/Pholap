using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Openable : interactable
{
    // Start is called before the first frame update
    public Sprite open;
    public Sprite closed;
    private SpriteRenderer sr;
    private bool isOpen;
    public int A1;
    public override void Interact()
    {
        if (isOpen)
            sr.sprite = closed;
            
        else 
            sr.sprite = open;
            
        isOpen = !isOpen;
        CheckTax();
    }
    private void Start(){
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }
    void CheckTax(){
        if(sr.sprite == closed){
            A1 = 0;
            Debug.Log(A1);
        }else if(sr.sprite == open){
            A1 =1;
            Debug.Log(A1);
        }
    }
}
