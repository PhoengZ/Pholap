using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour
{
    public Text pickUpText;
    private bool pickUpAllowed;
    public int Alevel1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed == true && Input.GetKeyDown(KeyCode.Space)){
            PickUp();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
        
    }
    void PickUp(){
        Alevel1 = 1;
        Destroy(gameObject);
        
    }
}
