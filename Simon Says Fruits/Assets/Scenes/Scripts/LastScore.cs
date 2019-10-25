
using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{
    public Text lastScoreText;


    // Start is called before the first frame update
    void Start()
    {
        print("Your last score was: " + LastScoreStatic.LastScore);
    }

    // Update is called once per frame
    void Update()
    {
        lastScoreText.text = LastScoreStatic.LastScore.ToString();
    }
}