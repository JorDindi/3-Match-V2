using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro
    ;
public class Scoreboard_P2 : MonoBehaviour
{
    public static Scoreboard_P2 Instance { get; private set; }

    private int _score;

    public int Score
    {

        get => _score;

        set
        {
            if (_score == value) return;
            _score = value;

            scoreText.SetText($"Score: {_score}");
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;
}
