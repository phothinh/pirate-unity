using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public PlayerMovement[] players;

    private int activePlayerIndex = 0;

    void Start()
    {
        SwitchPlayer(activePlayerIndex);
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchCharacter"))
        {
            activePlayerIndex = (activePlayerIndex + 1) % players.Length;
            SwitchPlayer(activePlayerIndex);
        }
    }

    void SwitchPlayer(int newIndex)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].isControlled = (i == newIndex);
        }
    }
}