using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private const int MIN = 0;
    private const int MAX = 100;

    [SerializeField]
    InputField _input;

    [SerializeField]
    Text _prompt;

    int _numberToGuess;
    int _totalGuesses;
    public void Awake()
    {
        _totalGuesses = 0;
        _numberToGuess = newNumber();
        
    }

    private int newNumber(bool appendPrompt = false)
    {
        if (appendPrompt)
            _prompt.text += Environment.NewLine + string.Format("Enter Value Between {0} - {1}.", MIN, MAX);
        else
            _prompt.text = string.Format("Enter Value Between {0} - {1}.", MIN, MAX);
        _input.Select();
        return UnityEngine.Random.Range(MIN, MAX) + 1;
    }

    public void GetInput(string strGuess)
    {
        int guess;

        Debug.Log("You Entered: " + strGuess);
        if (int.TryParse(strGuess, out guess))
        {
            ++_totalGuesses;
            if (guess == _numberToGuess)
            {
                _prompt.text = string.Format("Congratulation! You found it in only {0} guesses!", _totalGuesses);
                _numberToGuess = newNumber(true);
            }
            else
            {
                if (guess < _numberToGuess)
                {
                    _prompt.text = "Guess too Small.";
                }
                else
                    _prompt.text = "Guess too Large.";
            }
        }
        else
            _prompt.text = "Please Use Numbers.";

        _input.text = "";
        _input.Select();
    }


}
