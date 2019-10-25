
using UnityEngine;
using UnityEngine.UI;

public class MenuHiScores : MonoBehaviour
{
    public Text highestScoreText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highestScoreText.text = HiScore.AHiScore.ToString();
    }
}
