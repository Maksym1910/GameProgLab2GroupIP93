using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI info;
    [SerializeField] int minLevelScore = 5;
    private int score;
    
    // Update is called once per frame
    void Update()
    {
        info.text = $"Score: {score}";
    }

    public void Increment()
    {
        score += 1;
        if (score == minLevelScore)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
