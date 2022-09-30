using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    public GameObject interactIcon;
    public float Speed;
    public GameObject GameOverObject;
    Animator playerAnimatorController;
    private Vector2 boxSize = new Vector2(0.1f,1f);
    
    public Sprite FoxVerse;
    public Sprite FoxMain;
    public bool Split = true;
    public SpriteRenderer spriteRenderer;
    public Sprite newsprite;
    public Sprite oldsprite;
    public Animator animator;
    
    public RuntimeAnimatorController newController;
    public RuntimeAnimatorController oldController;
    
    // Start is called before the first frame update
    
    void Start()
    {
        playerAnimatorController = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            CheckInteraction();
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.localScale = new Vector3(-0.6f ,0.6f,1);
            transform.Translate(Vector3.left* Speed* Time.deltaTime);
            playerAnimatorController.SetBool("IsLeftRight", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.localScale = new Vector3(0.6f ,0.6f,1);
            transform.Translate(Vector3.right *Speed* Time.deltaTime);
            playerAnimatorController.SetBool("IsLeftRight", true);
        }else if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up *Speed* Time.deltaTime);
            playerAnimatorController.SetBool("IsUP", true);
        }else if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down *Speed* Time.deltaTime);
            playerAnimatorController.SetBool("IsDown", true);
        }if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
            playerAnimatorController.SetBool("IsLeftRight", false);
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            playerAnimatorController.SetBool("IsUP", false);
        }if(Input.GetKeyUp(KeyCode.DownArrow)){
            playerAnimatorController.SetBool("IsDown", false);
        }
        if(Input.GetKey(KeyCode.R)){
            Debug.Log("x");
            playerAnimatorController.runtimeAnimatorController = newController as RuntimeAnimatorController;
            
        }
        if(Input.GetKey(KeyCode.T)){
            Debug.Log("y");
            playerAnimatorController.runtimeAnimatorController = oldController as RuntimeAnimatorController;
            
        }
        
    }
    void ChangeSprite(Sprite newsprite){
        spriteRenderer.sprite = newsprite;
        Debug.Log("xd");
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Object")){
            Debug.Log("hit");    
        }
    }
    public void OpenInteractableIcon(){
        interactIcon.SetActive(true);
    }
    public void CloseInteractableIcon(){
        interactIcon.SetActive(false);
    }
    private void CheckInteraction(){
        RaycastHit2D[]hits = Physics2D.BoxCastAll(transform.position,boxSize,0,Vector2.zero);
        if(hits.Length > 0 ){
            foreach(RaycastHit2D rc in hits){
                if(rc.transform.GetComponent<interactable>()){
                    rc.transform.GetComponent<interactable>().Interact();
                    return;
                }
            }
        }    
    }
}
