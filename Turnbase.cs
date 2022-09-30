using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turnbase : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;
    public bool playerInRange;
    public bool Indie = false;
    BattleSystem battleSystem;
    public GameObject FoxVerse;
    public GameObject dialogBox1;
    public bool Gem1;
    
    // Start is called before the first frame update
    void Start()
    {
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange){
            if(dialogBox.activeInHierarchy){
                return;
            }else{
                
                Indie = true;
                dialogBox.SetActive(true);
                
            }if(dialogBox1.activeInHierarchy){
                if(dialogText.text == "You can defeat the Fox"){
                    dialogText.text = dialog;
                    return;
            }
                if(dialogText.text == dialog){
                    dialogText.text = "";
                    dialogBox.SetActive(false);      
                }
            }
        }
        if(battleSystem.dialougeText.text == "ENG"){
            dialogBox.SetActive(false);
            dialogBox1.SetActive(false);
            FoxVerse.SetActive(true);
            
            
        }else if(battleSystem.dialougeText.text == "END"){
            dialogBox.SetActive(false);
            FoxVerse.SetActive(false);
            dialogBox1.SetActive(true);
            dialogText.text = "You can defeat the Fox";
            Gem1 = true;
            Invoke("Texting", 1f);
        }

    }
    public void Texting(){
        dialogText.text = dialog;
        Invoke("Endtag",1f);
    }
    void Endtag (){
        dialogBox1.SetActive(false);
    }
    void Ending (){
        dialogBox1.SetActive(false);
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