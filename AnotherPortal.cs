using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnotherPortal : MonoBehaviour
{
    BattleSystem Turn1;
    public GameObject CharacterFox;
    public bool playerInPosRange;
    // Start is called before the first frame update
    void Start()
    {
        Turn1 = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInPosRange){
            Debug.Log("469");
            CheckEmote();
        }
    }
    void CheckEmote(){
        Debug.Log("51");
        if(Turn1.G1 == 1){
            Debug.Log("49");
            SceneManager.LoadScene("Scene3");
        }

        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") ){
            playerInPosRange = true;
            Debug.Log("5");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerInPosRange = false;
            Debug.Log("4");
            
        }
    }
}


