/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - Player.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer PlayerSpriteRenderer;
    public Transform PlayerTransform;
    public SpriteTools SpriteTools;
    public Sprite NormalSprite;
    public Sprite UnderFishSprite;

    private bool isCrushed = false;
    private bool isPlayerDisabled = false;
    private float PlayerMoveAmount = GameplayParameters.PlayerMoveAmount;
    
    private PlayerStates currentState;
    
    [HideInInspector] public static PlayerStateOff stateOff;
    [HideInInspector] public static PlayerStatePlaying statePlaying;
    [HideInInspector] public static PlayerStateKnockedDown stateKnockedDown;

    private void Awake()
    {
        stateOff = new PlayerStateOff(this);
        statePlaying = new PlayerStatePlaying(this);
        stateKnockedDown = new PlayerStateKnockedDown(this);
    }
    
    void Start()
    {
        NewPlayerState(stateOff);
        Cursor.visible = false;
    }
    
    private void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }
    
    public void Enable()
    {
        isPlayerDisabled = false;
        gameObject.SetActive(true);
        NewPlayerState(statePlaying);
    }

    public void Disable()
    {
        isPlayerDisabled = true;
        gameObject.SetActive(false);
        NewPlayerState(stateOff);
    }
    
    public void NewPlayerState(PlayerStates newState)
    {
        if (null != currentState)
        {
            currentState.OnMyStateExit();
        }

        currentState = newState;
        currentState.OnMyStateEntered();
    }
    
    public void EnterStateOff()
    {
        Debug.Log("Entered State Off");
    }
    
    public void EnterStatePlaying()
    {
        Debug.Log("Entered State Playing");
    }
    
    public void EnterStateKnockedDown()
    {
        Debug.Log("Entered State KnockedDow ");
    }
    
    public void ExitStateOff()
    {
        Debug.Log("Exited State Off");
    }
    
    public void ExitStatePlaying()
    {
        Debug.Log("Exited State Playing");
    }
    
    public void ExitStateKnockedDown()
    {
        Debug.Log("Exited State KnockedDown");
    }
    
    public void MoveLeft()
    {
        TryToMove(new Vector2(-1, 0));
    }
    public void MoveRight()
    { 
        TryToMove(new Vector2(1, 0));
    }
    
    public void TryToMove(Vector2 direction)
    {
        if (IsOkToMove())
        {
            Move(direction, PlayerMoveAmount);
        }
    }

    public void Move(Vector2 direction, float moveAmount)
    {
        Vector3 amountToMove = CalculateAmountToMove(direction, moveAmount);
        PlayerSpriteRenderer.transform.Translate(amountToMove);
        ConstrainPosition();
    }
    
    private bool IsOkToMove()
    {
        if (isCrushed)
            return false;
        return true;
    }

    private Vector3 CalculateAmountToMove(Vector2 direction, float moveAmount)
    {
        float amountX = direction.x * moveAmount;
        float amountY = 0;

        Vector2 amountToMove = new Vector2(amountX, amountY);

        return new Vector3(amountToMove.x, amountToMove.y, 0);
    }

    private void ConstrainPosition()
    {
        PlayerSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(PlayerSpriteRenderer);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coffee"))
        {
            //Destroy(collision.gameObject);
            //GetUp();
        }
        else if (collision.gameObject.CompareTag("Fish"))
        {
            //Destroy(collision.gameObject);
            isCrushed = true;
            NewPlayerState(stateKnockedDown);
            StartCoroutine(WaitToGetUp());
        }
    }

    IEnumerator WaitToGetUp()
    {
        SwitchToUnderFishSprite();
        yield return new WaitForSeconds(GameplayParameters.SecondsUnderFish);

        GetUp();
    }

    private void GetUp()
    {
        isCrushed = false;
        NewPlayerState(statePlaying);
        SwitchToNormalSprite();
    }

    private void SwitchToNormalSprite()
    {
        PlayerSpriteRenderer.sprite = NormalSprite;
        PlayerTransform.Translate(Vector3.up);
        PlayerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void SwitchToUnderFishSprite()
    {
        PlayerSpriteRenderer.sprite = UnderFishSprite;
        PlayerTransform.Translate(Vector3.down);
        PlayerTransform.localScale = new Vector3(1.6f, 1.6f, 1.0f);
    }
}
