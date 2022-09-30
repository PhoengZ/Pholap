using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManeger : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float Speed = 7;
    Animator playerAnimatorController;
    public Transform BodyTransform;
    public float JumpForce = 250;
    bool isJumping =false;
    Vector2 startPosition;
    Vector3 startScale;
    public Text ItemNumberText;
    int ItemQuantity= 0;
    AudioSource audioSource;
    public AudioClip GetItemSound;
    public AudioClip BombSound;
    public GameObject GameOverObject;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        playerAnimatorController = gameObject.GetComponent<Animator>();

        startPosition = transform.position;
        startScale = BodyTransform.localScale;
        audioSource =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            playerAnimatorController.SetBool("IsMoving", true);
            rigid2D.AddForce(Vector3.right * Speed);
            BodyTransform.localScale = new Vector3(-0.6f,0.6f,0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            playerAnimatorController.SetBool("IsMoving", true);
            rigid2D.AddForce(Vector3.left * Speed);
            BodyTransform.localScale = new Vector3(0.6f,0.6f,0);
            
        }
        if(rigid2D.velocity == Vector2.zero){
            playerAnimatorController.SetBool("IsMoving", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false){
            playerAnimatorController.SetBool("IsJumping", true);
            rigid2D.AddForce(Vector2.up * JumpForce);
            isJumping = true;
        }
        if(transform.position.y < -7 ){
            ResetPlayer();
            
        }
    }
    void ResetPlayer(){
        transform.position = startPosition;
        BodyTransform.localScale = startScale;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Ground")){
            isJumping = false;
            playerAnimatorController.SetBool("IsJumping", false);
        }
        if(collision.collider.CompareTag("Bomb")){
            audioSource.PlayOneShot(BombSound);
            ResetPlayer();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Item")){
            collision.gameObject.SetActive(false);
            ItemQuantity += 1;
            ItemNumberText.text = ItemQuantity + " / " + "5";
            audioSource.PlayOneShot(GetItemSound);
        }
        if(collision.CompareTag("Portal")){
            if(ItemQuantity >= 5){
                SceneManager.LoadScene("Scene2");

                
            }
        }
        if(collision.CompareTag("EndGame")){
            if(ItemQuantity == 5){
                GameOverObject.SetActive(true);
            }
        }
    }
    public void Restart(){
        SceneManager.LoadScene("Scene1");
    }
    public void ExitToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}