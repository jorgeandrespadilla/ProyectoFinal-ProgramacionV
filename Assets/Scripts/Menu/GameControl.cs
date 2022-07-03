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

    [SerializeField] 
    private GameObject mainCanvas;
    [SerializeField] 
    private GameObject helpCanvas;
    private bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        SetIsPaused(true);
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        var spaceship = Instantiate(characters[selectedCharacter]);
        spaceship.transform.parent = playerObject.transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        // Handle pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SetIsPaused(!isPaused);
        }
    }

    public void SetIsPaused(bool state) {
        isPaused = state;
        Time.timeScale = isPaused ? 0 : 1;
        mainCanvas.SetActive(!isPaused);
        helpCanvas.SetActive(isPaused);
    }

    public bool GetIsPaused() { 
        return isPaused; 
    }
}
