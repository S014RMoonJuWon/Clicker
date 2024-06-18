using TMPro;
using UnityEngine;

public class ScoreTxt : MonoBehaviour
{
    private Score Score;
    public TextMeshProUGUI scoreTxt;

    private void Start()
    {
        scoreTxt.text = Score.score.ToString();
    }

    private void Update()
    {
        
    }

}