namespace UtuakGames
{
    //UtuakMatrix
    #region Utuak games matrix
    public struct UtuakMatrix
    {
        #region Parametrs
        public int x, y;
        public float[,] matrix;
        #endregion

        #region Operators
        public static UtuakMatrix operator +(UtuakMatrix left, UtuakMatrix right)
        {
            if (left.x != right.x || left.y != right.y) return new UtuakMatrix();
            UtuakMatrix result = new UtuakMatrix(left.x, left.y);
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    result.matrix[i, j] = left.matrix[i, j] + right.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator +(UtuakMatrix mat, float n)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = mat.matrix[i, j] + n;
                }
            }
            return result;
        }

        public static UtuakMatrix operator +(float n, UtuakMatrix mat)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = n + mat.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator -(UtuakMatrix left, UtuakMatrix right)
        {
            if (left.x != right.x || left.y != right.y) return new UtuakMatrix();
            UtuakMatrix result = new UtuakMatrix(left.x, left.y);
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    result.matrix[i, j] = left.matrix[i, j] - right.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator -(UtuakMatrix mat, float n)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = mat.matrix[i, j] - n;
                }
            }
            return result;
        }

        public static UtuakMatrix operator -(float n, UtuakMatrix mat)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = n - mat.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator *(UtuakMatrix left, UtuakMatrix right)
        {
            UtuakMatrix result = new UtuakMatrix(left.x, left.y);
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    result.matrix[i, j] = left.matrix[i, j] * right.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator *(UtuakMatrix mat, float n)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = mat.matrix[i, j] * n;
                }
            }
            return result;
        }

        public static UtuakMatrix operator *(float n, UtuakMatrix mat)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = n * mat.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator /(UtuakMatrix left, UtuakMatrix right)
        {
            UtuakMatrix result = new UtuakMatrix(left.x, left.y);
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    if (right.matrix[i, j] != 0) result.matrix[i, j] = left.matrix[i, j] / right.matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix operator /(UtuakMatrix mat, float n)
        {
            if (n == 0) return new UtuakMatrix(mat.x, mat.y);
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    result.matrix[i, j] = mat.matrix[i, j] / n;
                }
            }
            return result;
        }

        public static UtuakMatrix operator /(float n, UtuakMatrix mat)
        {
            UtuakMatrix result = mat;
            for (int i = 0; i < mat.x; i++)
            {
                for (int j = 0; j < mat.y; j++)
                {
                    if (mat.matrix[i, j] != 0) result.matrix[i, j] = n / mat.matrix[i, j];
                    else result.matrix[i, j] = 0;
                }
            }
            return result;
        }

        public static bool operator !=(UtuakMatrix left, UtuakMatrix right)
        {
            if (left.x != right.x || left.y != right.y) return false;
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    if (left.matrix[i, j] != right.matrix[i, j]) return true;
                }
            }
            return false;
        }

        public static bool operator ==(UtuakMatrix left, UtuakMatrix right)
        {
            if (left.x != right.x || left.y != right.y) return false;
            for (int i = 0; i < left.x; i++)
            {
                for (int j = 0; j < left.y; j++)
                {
                    if (left.matrix[i, j] != right.matrix[i, j]) return false;
                }
            }
            return true;
        }
        #endregion

        #region Functions
        public override bool Equals(object obj) => this == (UtuakMatrix)obj;

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString()
        {
            string str = null;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    str += matrix[i, j];
                    if (j + 1 != y) str += ", ";
                }
                str += "\n";
            }
            return str;
        }

        public UtuakMatrix Transpose()
        {
            UtuakMatrix result = new UtuakMatrix(y, x);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result.matrix[j, i] = matrix[i, j];
                }
            }
            return result;
        }

        public static UtuakMatrix Dot(UtuakMatrix matrix1, UtuakMatrix matrix2)
        {
            UtuakMatrix result = new UtuakMatrix(matrix1.x, matrix2.y);
            for (int i = 0; i < matrix1.x; i++)
            {
                for (int j = 0; j < matrix2.y; j++)
                {
                    for (int k = 0; k < matrix1.y; k++)
                    {
                        result.matrix[i, j] += matrix1.matrix[i, k] * matrix2.matrix[k, j];
                    }
                }
            }
            return result;
        }

        public float[] AsList()
        {
            float[] result = new float[x + y - 1];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i + j] = matrix[i, j];
                }
            }
            return result;
        }

        public static string ListToStr(float[] list)
        {
            string str = null;
            int lght = list.Length;
            for (int i = 0; i < lght; i++)
            {
                str += list[i];
                if (i + 1 != lght) str += ", ";
            }
            return str;
        }
        #endregion

        #region Constructors
        public UtuakMatrix(int x, int y)
        {
            this.x = x;
            this.y = y;
            matrix = new float[x, y];
        }

        public UtuakMatrix(int x, int y, float defaultValues)
        {
            this.x = x;
            this.y = y;
            matrix = new float[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = defaultValues;
                }
            }
        }

        public UtuakMatrix(float[] list)
        {
            x = 1;
            y = list.Length;
            matrix = new float[x, y];
            for (int i = 0; i < y; i++)
            {
                matrix[0, i] = list[i];
            }
        }
        #endregion
    }
    #endregion
}
