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