using UnityEngine;
using TMPro;

public class TreasureScript : MonoBehaviour
{
    private int playersTouchingCount = 0;
    private bool keyCollected = false;

    public TextMeshProUGUI playerRemainingText;
    public GameObject victoryCanvas;
    public AudioClip victorySound;
    private AudioSource audioSource;
    public AudioSource backgroundMusic;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdatePlayerRemainingText();
    }

    private void PlayerTouching()
    {
        playersTouchingCount++;
        Debug.Log(playersTouchingCount);
        UpdatePlayerRemainingText();
        CheckVictory();
    }

    private void PlayerLeaving()
    {
        playersTouchingCount--;
        Debug.Log(playersTouchingCount);
        UpdatePlayerRemainingText();
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
            HandleVictory();
        }
    }

    private void UpdatePlayerRemainingText()
    {
        if (playerRemainingText != null)
        {
            int remainingPlayers = 3 - playersTouchingCount;
            playerRemainingText.text = "Player\nRemaining :\n" + remainingPlayers;
        }
    }

    private void HandleVictory()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        Time.timeScale = 0f;

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }

        if (victorySound != null)
        {
            audioSource.PlayOneShot(victorySound);
        }
    }
}
