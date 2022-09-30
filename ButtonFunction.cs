using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoversound;
    public AudioClip clickSound;
    // Start is called before the first frame update
    public void HoverSound(){
        mySounds.PlayOneShot(hoversound);
    }
    public void ClickSound(){
        mySounds.PlayOneShot(clickSound);
    }
}
