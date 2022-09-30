using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newsprite;
    public Sprite oldsprite;
    // Start is called before the first frame update
    void ChangeSprite(){
        spriteRenderer.sprite = newsprite;
    }
}
