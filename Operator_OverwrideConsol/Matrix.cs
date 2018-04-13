using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_OverwrideConsol
{
    class Matrix
    {
        public uint Sor { get; }
        public uint Oszlop { get; }
        private int[,] m_MatrixTomb;
        public Matrix(uint s, uint o)
        {
            Sor = s;
            Oszlop = o;
            m_MatrixTomb = new int[Sor, Oszlop];
        }

        public void Generate (Random rand)
        {
            for (int i = 0; i < Sor; i++)
            {
                for (int j = 0; j < Oszlop; j++)
                {
                    m_MatrixTomb[i, j] = rand.Next(-10, 10);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Sor; i++)
            {
                // string sorString = string.Format("{0:D}", m_MatrixTomb[i,0]);
                string sorString = $"{m_MatrixTomb[i, 0]:D}";
                for (int j = 1; j < Oszlop; j++)
                {
                    sorString += $"\t{m_MatrixTomb[i, j]:D}";
                }
                builder.AppendLine(sorString);
            }
            return builder.ToString();
        }
        public static Matrix operator *(Matrix m, int skalar)
        {
            Matrix eredmeny = new Matrix(m.Sor, m.Oszlop);
            for (int i = 0; i < m.Sor; i++)
            {
                for (int j = 0; j < m.Oszlop; j++)
                {
                    eredmeny.m_MatrixTomb[i, j] = m.m_MatrixTomb[i, j] * skalar;
                }
            }
            return eredmeny;
        }

        public static bool operator == (Matrix m1, Matrix m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            Matrix m = obj as Matrix;
            if (object.ReferenceEquals(m, null)||m.Sor != Sor || m.Oszlop != Oszlop)
            {
                return false;
            }
            for (int i = 0; i < m.Sor; i++)
            {
                for (int j = 0; j < m.Oszlop; j++)
                {
                    if (m.m_MatrixTomb[i,j] != m_MatrixTomb[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int this[uint sor, uint oszlop]
        {
            get
            {
                return m_MatrixTomb[sor, oszlop];
            }

            set
            {
                m_MatrixTomb[sor, oszlop] = value;
            }
        }
    }
}
