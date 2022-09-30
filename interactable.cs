using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class interactable : MonoBehaviour
{
    // Start is called before the first frame update
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<ControlCharacter>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<ControlCharacter>().CloseInteractableIcon();
        }
    }
}
