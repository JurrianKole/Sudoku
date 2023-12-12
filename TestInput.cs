namespace Sudoku;

public static class TestInput
{
    public static readonly string[] EasyPeasyWikipediaExample = 
    {
        "5 3 . . 7 . . . .",
        "6 . . 1 9 5 . . .",
        ". 9 8 . . . . 6 .",
        "8 . . . 6 . . . 3",
        "4 . . 8 . 3 . . 1",
        "7 . . . 2 . . . 6",
        ". 6 . . . . 2 8 .",
        ". . . 4 1 9 . . 5",
        ". . . . 8 . . 7 9"
    };

    public static readonly string[] SudokuDotComEasy =
    {
        "8 . . . 2 . 9 1 .",
        "2 3 4 5 1 . . . 7",
        "7 1 . . 8 . . 5 4",
        "6 . . 1 . . 3 . 5",
        "1 8 5 . . . 7 2 .",
        ". 4 . 6 . 2 8 . .",
        ". 6 8 . . . 4 . .",
        ". . . . . . 1 6 2",
        ". . . 4 . 7 5 3 ."
    };
    
    public static readonly string[] SudokuDotComMedium =
    {
        ". 8 2 3 . 6 7 . .",
        ". 6 . . . . . . 2",
        ". 3 . 2 . 4 1 . .",
        "4 . . 8 3 . 2 . .",
        ". . 5 . . . 9 . 4",
        ". . . . 4 . 6 . .",
        ". . . . 1 . 3 7 .",
        ". 5 . . 6 . . 2 9",
        "7 . . . 2 . . . 1"
    };

    public static readonly string[] SudokuDotComHard =
    {
        ". . 2 . . 7 . . .",
        ". 6 . 9 . . 4 . .",
        ". 9 . 2 5 . . . 3",
        ". . . 4 . . 1 . .",
        "7 3 . . 6 . . . .",
        ". . 9 5 3 . . 6 .",
        ". . 6 3 4 . . 7 .",
        "8 . . . . . . . 9",
        ". . . . . . . 5 ."
    };

    public static readonly string[] SudokuDotComExpert =
    {
        ". . . 4 . . . 9 .",
        ". . . 2 5 3 . . .",
        ". . . 1 . . . 4 7",
        "7 . . . . . 8 6 .",
        ". . 4 . . 8 . . .",
        "1 . . . 3 . . . .",
        ". 2 5 . . . 4 . .",
        ". . . . . . . . 5",
        ". 3 . . . 1 . . 2"
    };

    public static readonly string[] SudokuDotComMaster =
    {
        ". 1 . . . 5 . 9 .",
        ". . 6 8 9 . . . 4",
        "8 . . . . 7 . . .",
        ". 2 . . . . . . 6",
        ". . . . . 9 . . .",
        "5 . . 3 1 . . 4 .",
        "3 . . 4 8 . . 1 .",
        ". . 5 . . . 3 . .",
        ". . . 7 . . . . ."
    };
}