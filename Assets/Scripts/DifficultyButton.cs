using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private SpawnManager manager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void SetDifficulty()
    {
        print($"Difficulty set: {difficulty}");
        manager.StartGame(difficulty);
    }
}
