using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject[ ]  characters;
    public string MenuScene = "SelectionMenu";
    private string selectedCharacterDataName = "SelectedCharacter";
    int selectedCharacter;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        
        var spaceship = Instantiate(characters[selectedCharacter]);
        spaceship.transform.parent = playerObject.transform;

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
