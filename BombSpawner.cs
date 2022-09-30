using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject BombPrefab;
    public float IntervalPerBomb;
    float counter =0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > IntervalPerBomb){
            SpawnBomb();
            counter =0;
        }
        if(Input.GetKeyDown(KeyCode.E)){


        }
    }
    void SpawnBomb(){
        float randomX = Random.Range(PlayerTransform.position.x -12.5f , PlayerTransform.position.x + 12.5f);
        float BombPositionY = PlayerTransform.position.y +10;
        Instantiate(BombPrefab,new Vector3(randomX,BombPositionY,0),Quaternion.identity);
    }
}