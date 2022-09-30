using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum BattleState{START, PLAYERTURN , ENEMYTURN , WON , LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleState state ;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    Unit playerUnit;
    Unit enemyUnit;
    public Text dialougeText;
    public BattleHud playerHUD;
    public BattleHud enemyHUD;
    public GameObject dialogBox;
    public GameObject FoxVerse;
    public GameObject Squid;
    public GameObject snake;

    Turnbase turnbase;
    Turnbase turnbase1; 
    Turnbase turnbase2;
    
    public bool Eng;
    public AudioSource mySounds;
    public AudioClip hitsound;
    public AudioClip healsound;
    public AudioClip buffsound;
    public AudioClip debuffsound;
    public int G1 =0 ;
    
    
    public int Nextint;
    private void Awake() {
      state = BattleState.START; 
      turnbase = FoxVerse.GetComponent<Turnbase>();
      
      
      Eng = turnbase.Indie;
      Debug.Log(Eng);
      if(Eng == true){
        Debug.Log("eror");
        StartCoroutine(SetupBattle());  
    }
    
      
    }
    void Update() {
        if(turnbase.Indie == true){
            Debug.Log("eror");
            turnbase.Indie = false;
            StartCoroutine(SetupBattle());
        }
    }
    IEnumerator SetupBattle(){
        
        GameObject playerGO =  Instantiate(playerPrefab , playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        
        
        dialougeText.text = "A wild "+ enemyUnit.unitName + " approach";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        Debug.Log("Rov");
        PlayerTurn();

    }
    IEnumerator PlayerAttack(){
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        mySounds.PlayOneShot(hitsound);
        dialougeText.text = "The attack is succesfulls";
        yield return new WaitForSeconds(2f);

        if(isDead){
            state = BattleState.WON;
            EndBattle();
        }else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }

    }
    IEnumerator PlayerBuff(){
        playerUnit.Buff(5);
        dialougeText.text = "So good";
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

       

    }
    IEnumerator EnemyTurn(){
        Nextint = Random.Range(1,5); 
        if(Nextint == 1 ){
            Debug.Log(Nextint);
            dialougeText.text = enemyUnit.unitName + " attacks! ";
            yield return new WaitForSeconds(1f);
            bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
            playerHUD.SetHP(playerUnit.currentHP);
            yield return new WaitForSeconds(1f);
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }else {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
                }
        }else if(Nextint == 2){
            Debug.Log(Nextint);
            dialougeText.text = enemyUnit.unitName + " Heal ";
            yield return new WaitForSeconds(1f);
            enemyUnit.Heal(5);
            enemyHUD.SetHP(enemyUnit.currentHP);
            bool isDead = playerUnit.TakeDamage(0);
            playerHUD.SetHP(playerUnit.currentHP);
            yield return new WaitForSeconds(1f);
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }else {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            }    
        }else if(Nextint == 3 ){
            Debug.Log(Nextint);
            dialougeText.text = enemyUnit.unitName + " Buff ";
            yield return new WaitForSeconds(1f);
            enemyUnit.Buff(5);
            enemyHUD.SetHP(enemyUnit.currentHP);
            bool isDead = playerUnit.TakeDamage(0);
            playerHUD.SetHP(playerUnit.currentHP);
            yield return new WaitForSeconds(1f);
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }else {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            } 
        }else if(Nextint == 4 ){
            Debug.Log(Nextint);
            dialougeText.text = enemyUnit.unitName + " DeBuff ";
            yield return new WaitForSeconds(1f);
            enemyUnit.Debuff(5);
            enemyHUD.SetHP(enemyUnit.currentHP);
            bool isDead = playerUnit.TakeDamage(0);
            playerHUD.SetHP(playerUnit.currentHP);
            yield return new WaitForSeconds(1f);
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }else {
                state = BattleState.PLAYERTURN;
                PlayerTurn();
            } 
        }
    }
    void EndBattle(){
        if(state == BattleState.WON){
            dialougeText.text = "END";
            G1 = 1;  
        }else if(state == BattleState.LOST){
            dialougeText.text = "you were defeated";
            dialougeText.text = "ENG";
            FoxVerse.SetActive(true);
        }
    }

    void PlayerTurn(){
        dialougeText.text = "choose an action";

    }
    IEnumerator PlayerDebuff(){
        enemyUnit.Debuff(5);
        dialougeText.text = "Enemy look bad";
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator PlayerHeal(){
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialougeText.text = "You fell renewed strength";
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void OnAttackButton(){
        if(state != BattleState.PLAYERTURN)
            return;
        if(dialougeText.text != "choose an action"){
            return;
        }
        Debug.Log("inw");
        StartCoroutine(PlayerAttack());
        
    }
    public void OnBuffButton(){
        if(state != BattleState.PLAYERTURN)
            return;
        if(dialougeText.text != "choose an action"){
            return;
        }
        StartCoroutine(PlayerBuff());
        
    }
    public void OnHealButton(){
        if(state != BattleState.PLAYERTURN)
            return;
        if(dialougeText.text != "choose an action"){
            return;
        }
        StartCoroutine(PlayerHeal());
        
    }
    public void OnDebuffButton(){
        if(state != BattleState.PLAYERTURN)
            return;
        if(dialougeText.text != "choose an action"){
            return;
        }
        StartCoroutine(PlayerDebuff());
        
    }
    
    
    
}
