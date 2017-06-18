using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SudokuController : MonoBehaviour {

    public static int ActiveValue;
    public static int ActiveGuessingValue;

    public GameObject YouWinPanel;
    public GameObject SudokuPanel;
    public Cell Cell;
    static Cell[,] Sudoku;

    private static bool GameWon=false;

	void Start () {
        Sudoku = new Cell[9, 9];
        ActiveValue = 0;

        for(int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                var newCell = Instantiate(Cell,SudokuPanel.transform);
                newCell.GetComponent<RectTransform>().anchoredPosition=new Vector2((x*75)-Screen.width/3, (-y*75)+Screen.height/3);

                Sudoku[x, y] = newCell;
            }
        }

        RandomizeFields();
	}

    public static void VictoryCondition()
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if (Sudoku[x, y].Value == 0) return;
            }
        }

        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if (DoesRowHasValue(y, Sudoku[x, y].Value) || DoesColumnHasValue(x, Sudoku[x, y].Value)) return;
            }
        }
        GameWon = true;
    }

    void Update()
    {
        if (GameWon)
        {
            YouWinPanel.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            ActiveValue = 9;
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            ActiveValue = 8;
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            ActiveValue = 7;
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            ActiveValue = 6;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            ActiveValue = 5;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            ActiveValue = 4;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ActiveValue = 3;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ActiveValue = 2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ActiveValue = 1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            ActiveValue = 0;
        }

        if (Input.GetKeyUp(KeyCode.Keypad9))
        {
            ActiveGuessingValue = 9;
        }
        if (Input.GetKeyUp(KeyCode.Keypad8))
        {
            ActiveGuessingValue = 8;
        }
        if (Input.GetKeyUp(KeyCode.Keypad7))
        {
            ActiveGuessingValue = 7;
        }
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            ActiveGuessingValue = 6;
        }
        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            ActiveGuessingValue = 5;
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            ActiveGuessingValue = 4;
        }
        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            ActiveGuessingValue = 3;
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            ActiveGuessingValue = 2;
        }
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            ActiveGuessingValue = 1;
        }
    }

    private void RandomizeFields()
    {
        for (int i = 0; i < 17; i++)
        {
            var valueToSet = Random.Range(1, 10);

            var x = Random.Range(0, 9);
            var y = Random.Range(0, 9);

            while (Sudoku[x, y].Value !=0)
            {
                x = Random.Range(0, 9);
                y = Random.Range(0, 9);
            }
            
            while (DoesRowHasValue(y, valueToSet) || DoesColumnHasValue(x, valueToSet))
            {
                valueToSet = Random.Range(1, 10);
            }
            Sudoku[x, y].SetButtonValue(valueToSet);
        }
    }

    private static bool DoesRowHasValue(int y,int value)
    {
        for(int x = 0; x < 9; x++)
        {
            if (Sudoku[x, y].Value == value)
            {
                return true;
            }
        }
        return false; 
    }

    private static bool DoesColumnHasValue(int x, int value)
    {
        for (int y = 0; y < 9; y++)
        {
            if (Sudoku[x, y].Value == value)
            {
                return true;
            }
        }
        return false;
    }
}
