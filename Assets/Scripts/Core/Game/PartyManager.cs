using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public List<Character> ActiveParty { get; private set; } = new List<Character>();

    public void addCharacterToParty(CharacterData characterData)
    {
        if (ActiveParty.Count < 4)
        {
            ActiveParty.Add(new Character(characterData));
        }
    }

    public void SwapCharacters(int indexA, int indexB)
    {
        Character temp = ActiveParty[indexA];
        ActiveParty[indexA] = ActiveParty[indexB];
        ActiveParty[indexB] = temp;
    }
    
    //TODO remove character from party
    //TODO add character in specific slot of party
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
