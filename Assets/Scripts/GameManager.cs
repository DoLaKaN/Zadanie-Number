using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuView;
    public GameObject gameplayView;
    public TMP_InputField inputText;
    public TextMeshProUGUI responseText;
    public int MIN = 1;
    public int MAX = 100;
    public GameObject LowerButton;
    public GameObject HigherButton;
    public GameObject ResetButton;
    private int randomNumber;
    private int guesses;
    
    public void StartGame()
    {   
        guesses = 0;
        MIN = 1;
        MAX = 100;
        menuView.SetActive(false);
        gameplayView.SetActive(true);
        randomNumber = Random.Range(MIN, MAX);
        responseText.text = "Czy to: " + randomNumber + "? ";
}
    
    public void GetInput(string input)
    {
        Debug.Log("You Entered "+ input);
        if (int.TryParse(input, out int number))
        {
            guesses++;
            if (randomNumber == number)
            {
                responseText.text = "Congratulation, this is correct number. It took you "+ guesses+" guesses";
                menuView.SetActive(true);
            }
            else if (randomNumber > number)
            {
                responseText.text = "My number is higher";
            }
            else if (randomNumber < number)
            {
                responseText.text = "My number is lower";
            }
            
            inputText.text = "";
            
        }
        
    }


    public void Lower(string number)
    {
        guesses++;
        Debug.Log("Lower");

        MAX = randomNumber - 1;


        if (MIN > MAX)
        {
            Debug.Log("Lower" + MAX);
        }
        else if(MIN == MAX)
        {
            Debug.Log("Lower"+MAX);
            responseText.text = "Czy to: " + randomNumber + "?";
        }
        else
        {
            randomNumber = Random.Range(MIN, MAX);
            Debug.Log("Lower"+MIN);
            responseText.text = "Czy to: " + randomNumber + "?";
        }
     }

    public void Higher(string number)
    {
        guesses++;
        Debug.Log("Higher");

        MIN = randomNumber + 1;

        if (MIN > MAX)
        {
            Debug.Log("Lower");
        }
        else if (MIN == MAX)
        {
            Debug.Log("Lower" + MIN);
            responseText.text = "Czy to: " + randomNumber + "?";
        }
        else
        {
            randomNumber = Random.Range(MIN, MAX);
            Debug.Log("Lower" +MIN);
            responseText.text = "Czy to: " + randomNumber + "?";
        }

    }


}
