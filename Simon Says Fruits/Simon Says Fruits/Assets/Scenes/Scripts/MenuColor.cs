using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuColor : MonoBehaviour
{
    public Text titleText;
    public float timeToChange = 0.3f;
    private float timeSinceChange = 0f;


    private void Awake()
    {
        titleText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceChange += Time.deltaTime;

        if (titleText != null && timeSinceChange >= timeToChange)
        {
            Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
                );

            titleText.color = newColor;
            timeSinceChange = 0f;
        }
    }
}
