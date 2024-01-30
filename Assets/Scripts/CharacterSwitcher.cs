using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public PlayerMovement[] players;
    public AudioClip[] switchCharacterSounds;
    private AudioSource audioSource;

    private int activePlayerIndex = 0;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        if (switchCharacterSounds != null && switchCharacterSounds.Length > newIndex && switchCharacterSounds[newIndex] != null)
        {
            audioSource.PlayOneShot(switchCharacterSounds[newIndex]);
        }
    }
}