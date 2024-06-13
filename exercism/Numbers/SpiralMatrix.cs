namespace Exercism.Numbers;


/*
 *
  - initialize a variable val = 1.
 - Maintain a direction variable to maintain the direction to move in.
   Starting from the topmost left corner, the sequence of direction is right → down → left → top.
   Keep moving in the above order, each time decrementing/incrementing the current row/column index.
   While moving each time, increment the value of the val variable.
 */

/*
 *
 *  {
    { 1, 2, 3, 4, 5 },
   { 16, 17, 18, 19, 6 },
   { 15, 24, 25, 20, 7 },
   { 14, 23, 22, 21, 8 },
   { 13, 12, 11, 10, 9 }
   };
 */

public class SpiralMatrix
{
    
    private enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }

    private static void GoRight(ref int column) => column++;
    
    private static void GoLeft(ref int column) => column--;
    
    private static void GoDown(ref int row) => row++;
    
    private static void GoUp(ref int row) => row--;

    public static int[,] GetMatrix(int size)
    {
        
        var matrix = new int[size, size];

        if (size == 0) return matrix;
        
        var lastIndex = size - 1;
        var row = 0;
        var column = 0;

        Direction direction  = Direction.Right;
        
        for (int i = 1; i <= Math.Pow(size, 2); i++)
        {
            
            matrix[row, column] = i;

            if (direction == Direction.Right)
            {
                if (column < lastIndex && matrix[row, column + 1] == 0)
                {
                    GoRight(ref column);
                }
                else
                {
                    direction = Direction.Down;
                    GoDown(ref row);
                }
            } else if (direction == Direction.Down)
            {
                if (row < lastIndex && matrix[row + 1, column] == 0)
                {
                    GoDown(ref row);
                }
                else
                {
                    direction = Direction.Left;
                    GoLeft(ref column);
                }
            } else if(direction == Direction.Left)
            {
                if (column > 0 && matrix[row, column - 1] == 0)
                {
                    GoLeft(ref column);
                }
                else
                {
                    direction = Direction.Up;
                    GoUp(ref row);
                }
            } else if (direction == Direction.Up)
            {
                if (row <= lastIndex && matrix[row - 1, column] == 0)
                {
                    GoUp(ref row);
                }
                else
                {
                    direction = Direction.Right;
                    GoRight(ref column);
                }
            }
            
        }

        return matrix;
    }
}