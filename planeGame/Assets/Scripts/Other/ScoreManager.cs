using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;
    public void submitScore()
    {
        submitScoreEvent.Invoke(inputName.text, GlobalScore.GetScore());
    }
}
