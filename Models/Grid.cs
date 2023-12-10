namespace Sudoku.Models;

public record Grid(SubGrid[] SubGrids)
{
    protected Grid(Grid oldItem)
    {
        this.SubGrids = oldItem.SubGrids;
    }
};
