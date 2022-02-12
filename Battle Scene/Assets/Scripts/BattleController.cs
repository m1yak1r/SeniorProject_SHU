using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState
{
    START,
    EXECUTE,
    PLAYER, ENEMY,
    OUTCOME,
    WIN, LOSE, ESCAPE
}

public enum RoundControl
{
    FIGHT,
    TALK,
    SPECIAL,
    SPECIALCONF,
    PARTYSWAP,
    PARTYSWAPCONF,
    ESCAPE,
    ESCAPECONF,
    AUTO,
    AUTOCONF,
    ROUNDCONF
}

public enum RufioTurnCommand
{
    OFF, //Disables this enum
    MELEE,
    MELEECONF,
    GUN,
    GUNCONF,
    DEFEND,
    SKILL,
    SKILLCONF,
    ITEM,
    ITEMCONF
}

public enum AllyTurnCommand
{
    OFF, //Disables this enum
    ATTACK,
    ATTACKCONF,
    DEFEND,
    SKILL,
    SKILLCONF
}

public class BattleController : MonoBehaviour
{
    public BattleState state;
    public RoundControl command;
    public RufioTurnCommand rufioTurn;
    public AllyTurnCommand allyTurn;
    public Rufio rufio;
    public Button yesButton;
    public int mobValue = 1;
    public int extensions;
    Enemy enemy;

    private string turnList;
    public List<GameObject> PlayerParty = new List<GameObject> ();
    public List<GameObject> EnemyParty = new List<GameObject>();

    LinkedList<string> TurnOrder = new LinkedList<string>();
    private bool turnSuccess;
    private bool battleOutcome;
    public bool startTurn;

    [HideInInspector]
    public bool onClickBool;

    string rName = "Rufio";
    private bool rAlive = true;

    // Enemy
    // Ogre
    private string e1Name = "Ogre";
    private int e1MaxHealth = 50;
    private int e1Health = 50;
    private bool e1Alive = true;

    // Start is called before the first frame update
    void Start()
    {
        EnemyParty.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        PlayerParty.AddRange(GameObject.FindGameObjectsWithTag("Ally"));

        // Have to hard code things for now
        state = BattleState.START;
        command = RoundControl.FIGHT;
        rufioTurn = RufioTurnCommand.OFF;
        allyTurn = AllyTurnCommand.OFF;
        startTurn = false;
        turnSuccess = false;
        battleOutcome = false;
    }

    // Update is called once per frame
    void Update()
    {
        // detects whether party or enemy team is defeated
        battleOutcome = IsDefeated();
        if (!battleOutcome)
        {
            switch (state)
            {
                case BattleState.START:
                    startTurn = true;
                    if (onClickBool == true)
                    {
                        state = BattleState.EXECUTE;
                        onClickBool = false;
                    }
                    break;
                case BattleState.EXECUTE:
                    Debug.Log("Executing turn");
                    Debug.Log("Next Turn");
                    state = BattleState.START;
                    break;
                case BattleState.PLAYER:
                    break;
                case BattleState.ENEMY:
                    break;
                case BattleState.OUTCOME:
                    break;
                case BattleState.WIN:
                    break;
                case BattleState.LOSE:
                    break;
                case BattleState.ESCAPE:
                    Escaping();
                    break;
            }
        }
        else
        {
            bool outcome = Victory();
            // changes the scene here depending on outcome of battle
            if (outcome == true)
            {
                SceneManager.LoadScene("Out", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("Out", LoadSceneMode.Single);
            }
        }
    }

    void RInput()
    {
        
    }

    void AInput()
    {

    }

    public void TurnExecution()
    {
        onClickBool = true;
        Debug.Log(onClickBool);
    }

    void BattleEvent()
    {

    }

    void Escaping()
    {
        int escapeValue = 1;
        int randomValue = Random.Range(1, 11);

        if (escapeValue == randomValue)
        {
            e1Alive = false;
            Debug.Log("Escape Successful");
        }
        else
        {
            Debug.Log("Escape Failed");
        }
    }

    private bool IsDefeated()
    {
        if (rAlive && e1Alive == true)
        {
            return false;
        }
        else
        {
            Debug.Log("Battle Ended");
            return true;
        }
    }

    private bool Victory()
    {
        if (rAlive == true)
        {
            return true;
        }
        else { return false; }
    }

    void DetectPlayerParty()
    {

    }

    void DetectEnemyParty()
    {

    }
}
