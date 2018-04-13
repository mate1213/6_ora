using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overwrite
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
                for (int j = 0; j < Oszlop; j++)
                {
                    sorString += $"\t{m_MatrixTomb[i, 0]:D}";
                }
                builder.AppendLine(sorString);
            }
            return builder.ToString();
        }
       
    }
}
