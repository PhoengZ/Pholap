using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    Openable Open1;
    Openable Open2;
    public bool playerInPosRange;
    // Start is called before the first frame update
    void Start()
    {
        Open1 = GameObject.Find("Mine").GetComponent<Openable>();
        Open2 = GameObject.Find("Mine (1)").GetComponent<Openable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInPosRange){
            Debug.Log(Open1.A1);
            CheckInteract();
        }
    }
    public void LoadScene(){
        SceneManager.LoadScene("Scene2");

    }
    void CheckInteract(){
        if(Open2.A1 == 1 && Open1.A1 == 1 ){
            Debug.Log("50");
            SceneManager.LoadScene("Scene2");
            
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
