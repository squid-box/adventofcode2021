namespace AdventOfCode2021.Problems;

using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode2021.Utils;
using AdventOfCode2021.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2021/day/4">Day 4</a>.
/// </summary>
public class Problem4 : ProblemBase
{
    public Problem4(InputDownloader inputDownloader = null) : base(4, inputDownloader) { }

    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    internal static int PartOne(ICollection<string> input)
    {
        var (draws, boards) = ParseInput(input.ToList());

        BingoBoard winningBoard = null;
        int lastDraw = -1;

        foreach (var draw in draws)
        {
            lastDraw = draw;

            foreach (var board in boards)
            {
                board.MarkCell(draw);

                if (board.HasCompleteRowOrColumn())
                {
                    winningBoard = board;
                    break;
                }
            }

            if (winningBoard != null)
            {
                break;
            }
        }

        return winningBoard.CalculateUnmarkedSum() * lastDraw;
    }

    internal static int PartTwo(ICollection<string> input)
    {
        var (draws, boards) = ParseInput(input.ToList());

        var completedBoards = new HashSet<BingoBoard>();
        BingoBoard lastWinningBoard = null;
        int lastDraw = -1;

        foreach (var draw in draws)
        {
            lastDraw = draw;

            foreach (var board in boards)
            {
                if (completedBoards.Contains(board))
                {
                    continue;
                }

                board.MarkCell(draw);

                if (board.HasCompleteRowOrColumn())
                {
                    lastWinningBoard = board;
                    completedBoards.Add(board);

                    if (completedBoards.Count == boards.Count)
                    {
                        break;
                    }
                }
            }

            if (completedBoards.Count == boards.Count)
            {
                break;
            }
        }

        return lastWinningBoard.CalculateUnmarkedSum() * lastDraw;
    }

    internal static (IList<int> draws, IList<BingoBoard> boards) ParseInput(IList<string> input)
    {
        var drawNumbers = input[0].Split(',').Select(num => num.ToInt()).ToList();

        var boards = new List<BingoBoard>();

        for (var i = 1; i < input.Count; i += 6)
        {
            var fiveLines = new List<string>
            {
                input[i + 1],
                input[i + 2],
                input[i + 3],
                input[i + 4],
                input[i + 5]
            };

            boards.Add(new BingoBoard(fiveLines.Count, fiveLines));
        }
        
        return (drawNumbers, boards);
    }

    internal class BingoBoard
    {
        private readonly int _size;

        private readonly Matrix<int> _cells;
        private readonly Matrix<bool> _markedCells;

        public BingoBoard(int size, IList<string> input)
        {
            _size = size;
            _cells = new Matrix<int>(size);
            _markedCells = new Matrix<bool>(size);
            
            for (var y = 0; y < size; y++)
            {
                var row = input[y].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (var x = 0; x < size; x++)
                {
                    _cells.SetElement(x, y, row[x].ToInt());
                }
            }
        }

        public void MarkCell(int value)
        {
            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    if (_cells.GetElement(x, y).Equals(value))
                    {
                        _markedCells.SetElement(x, y, true);

                        return;
                    }
                }
            }
        }

        public int CalculateUnmarkedSum()
        {
            var sum = 0;

            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    if (!_markedCells.GetElement(x, y))
                    {
                        sum += _cells.GetElement(x, y);
                    }
                }
            }

            return sum;
        }

        public bool HasCompleteRowOrColumn()
        {
            // Check rows:
            for (var y = 0; y < _size; y++)
            {
                if  (_markedCells.GetColumn(y).All(cell => cell == true))
                {
                    return true;
                }
            }

            // Check columns:
            for (var x = 0; x < _size; x++)
            {
                if (_markedCells.GetRow(x).All(cell => cell == true))
                {
                    return true;
                }
            }

            return false;
        }
    }
}