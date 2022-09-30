using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    Key item;
    public GameObject Item;
    public GameObject Door;
    public GameObject PostFX;
    public bool playerPosition;
    public int Xz = 0;
    public GameObject path;
    public GameObject path2;
    public int Psf;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.Find("timber").GetComponent<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        Xz = item.Alevel1;
        if(Input.GetKeyDown(KeyCode.E) && playerPosition ){
            Debug.Log("123");
            CheckId();
            
        }
        
    }
    void CheckId(){
        if(Xz == 1){
            Debug.Log("987");
            path.SetActive(true);
        }else if(Xz == 0) {
            Debug.Log("78910");
            path.SetActive(false);
            PostFX.SetActive(true);
            item.Alevel1 = 2;
        }else if(Xz == 2){
            PostFX.SetActive(false);
            path2.SetActive(false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") ){
            playerPosition = true;
            Debug.Log("5");
            }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerPosition = false;
            Debug.Log("4");
            }
    }
}
