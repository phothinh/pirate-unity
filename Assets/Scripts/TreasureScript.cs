using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    private int playersTouchingCount = 0;
    private bool keyCollected = false;

    private void OnEnable()
    {
        TreasureEventHandler.OnPlayerTouch.AddListener(PlayerTouching);
        TreasureEventHandler.OnPlayerLeave.AddListener(PlayerLeaving);
        TreasureEventHandler.OnKeyCollected.AddListener(KeyCollected);
    }

    private void OnDisable()
    {
        TreasureEventHandler.OnPlayerTouch.RemoveListener(PlayerTouching);
        TreasureEventHandler.OnPlayerLeave.RemoveListener(PlayerLeaving);
        TreasureEventHandler.OnKeyCollected.RemoveListener(KeyCollected);
    }

    private void PlayerTouching()
    {
        playersTouchingCount++;
        Debug.Log(playersTouchingCount);
        CheckVictory();
    }

    private void PlayerLeaving()
    {
        playersTouchingCount--;
        Debug.Log(playersTouchingCount);
        CheckVictory();
    }

    private void KeyCollected()
    {
        keyCollected = true;
        Debug.Log(keyCollected);
        CheckVictory();
    }

    private void CheckVictory()
    {
        if (playersTouchingCount == 3 && keyCollected)
        {
            Debug.Log("Victory!");
        }
    }
}
