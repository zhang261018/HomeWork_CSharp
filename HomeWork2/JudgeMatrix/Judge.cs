using System;
using System.Collections.Generic;
using System.Text;

namespace JudgeMatrix
{
    class Judge
    {
        public static bool JudgeToeplitz(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            //BP，第二行开始每一行判断与前一行对角是否相等即可
            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((i - 1) < 0 || (j - 1) < 0)
                        continue;                        
                    else if (matrix[i, j] == matrix[i - 1, j - 1])
                        continue;
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
