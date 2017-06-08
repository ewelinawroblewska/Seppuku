using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public int Value;
    public List<int> Guessings;
    public Text ButtonText;
    public Button CellButton;
    
    public Text GuessingButtonText;
    public Button CellGuessingButton;

    void Start()
    {
        Value = 0;
        CellButton.onClick.AddListener(CellButtonListener);
        CellGuessingButton.onClick.AddListener(GuessingButtonListener);
    }

    public void SetButtonValue(int valueToSet)
    {
        Value = valueToSet;
        if (valueToSet != 0)
        {
            ButtonText.text = valueToSet.ToString();
        }
    }

    private void CellButtonListener()
    {
        SudokuController.VictoryCondition();
        SetButtonValue(SudokuController.ActiveValue);
    }

    private void GuessingButtonListener()
    {
        if (Guessings.Exists(x => x == SudokuController.ActiveGuessingValue))
        {
            Guessings.Remove(SudokuController.ActiveGuessingValue);
        }
        else
        {
            Guessings.Add(SudokuController.ActiveGuessingValue);
        }

        UpdateButtonText();
    }
    private void UpdateButtonText()
    {
        GuessingButtonText.text = "";
        foreach(var i in Guessings)
        {
            GuessingButtonText.text += i+" ";
        }
    }
}
