using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;
    public bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            if(dialogBox.activeInHierarchy){
                if(dialogText.text == "ROV"){
                    dialogText.text = "ASD";
                    return;
                }
                if(dialogText.text == "ASD"){
                    dialogText.text = "";
                    dialogBox.SetActive(false);      
                }
                
                
                
            }else{
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") ){
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
