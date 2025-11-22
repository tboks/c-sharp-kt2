namespace App.Topics.Indexers.T1_3_Matrix2D;

using System;

public class Matrix2D
{
    private int rows;
    private int cols;
    private double[] data;

    public int Rows => rows;
    public int Cols => cols;

    public Matrix2D(int rows, int cols)
    {
        if (rows <= 0)
            throw new ArgumentOutOfRangeException("строки должны быть больше 0", nameof(rows));
        if (cols <= 0)
            throw new ArgumentOutOfRangeException("столбцы должны быть больше 0", nameof(cols));

        this.rows = rows;
        this.cols = cols;
        data = new double[rows * cols];
    }

    public double this[int row, int col]
    {
        get
        {
            ValidateIndices(row, col);
            return data[row * cols + col];
        }
        set
        {
            ValidateIndices(row, col);
            data[row * cols + col] = value;
        }
    }

    private void ValidateIndices(int row, int col)
    {
        if (row < 0 || row >= rows)
            throw new ArgumentOutOfRangeException(nameof(row));
        if (col < 0 || col >= cols)
            throw new ArgumentOutOfRangeException(nameof(col));
    }
}
