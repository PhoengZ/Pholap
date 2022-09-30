using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostEffect : MonoBehaviour
{
    
    public PostProcessVolume postvolume;
    Vignette _ao;
    public float myValue;
    private Vignette vignet;
    CheckItem Chek;
    public GameObject tree;
    // Start is called before the first frame update
    void Start() {
       postvolume.profile.TryGetSettings(out vignet);
       Chek = GameObject.Find("Tree2").GetComponent<CheckItem>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Chek.Psf == 1 )  {
            EnableVignet();
        } 
    }
    void EnableVignet(){
       vignet.intensity.value = 1; 
    }
    
   
}
