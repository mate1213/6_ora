using System;
using System.ComponentModel;
using System.Text;

namespace Matrixok
{
    class Matrix
    {
        public uint Sor { get; private set; }
        public uint Oszlop { get; private set; }
        private readonly int[,] matrixTomb;
        public Matrix(uint sor, uint oszlop)
        {
            Sor = sor;
            Oszlop = oszlop;
            matrixTomb = new int[sor, oszlop];

        }

        public void General(Random rnd)
        {
            for (uint i = 0; i < Sor; i++)
            {
                for (uint j = 0; j < Oszlop; j++)
                {
                    matrixTomb[i, j] = rnd.Next(-10, 10);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();

            for (uint i = 0; i < Sor; i++)
            {
                string aktsor = string.Format("{0:D}", matrixTomb[i, 0]);
                for (uint j = 1; j < Oszlop; j++)
                {
                    aktsor += string.Format("\t{0:D}", matrixTomb[i, j]);
                }

                sbuilder.AppendLine(aktsor);
            }

            return sbuilder.ToString();
        }

        /// <summary>
        /// összehasonlítja az aktuális  mátrix objektumot egy másik mátrix objektummal
        /// </summary>
        /// <param name="obj">összehasonlító objektum</param>
        /// <returns> skalár szorzat mátrix</returns>

        public override bool Equals(object obj)
        {
            Matrix masikMatrix = obj as Matrix;

            if (object.ReferenceEquals(masikMatrix, null) || Sor != masikMatrix.Sor || Oszlop != masikMatrix.Oszlop)
            {
                return false;
            }

            for (int i = 0; i < Sor; i++)
            {
                for (int j = 0; j < Oszlop; j++)
                {
                    if (matrixTomb[i, j] != masikMatrix.matrixTomb[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Operátor függvény, amely két mátrixot hasonlít össze
        /// </summary>
        /// <param name="m">Szorzandó mátrix</param>
        /// <param name="skalar">Skalár szorzó</param>
        /// <returns> skalár szorzat mátrix</returns>

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }

        /// <summary>
        /// Operátor függvény, amely megvalósítja a mátrix szórzást skalárral
        /// </summary>
        /// <param name="m">Szorzandó mátrix</param>
        /// <param name="skalar">Skalár szorzó</param>
        /// <returns> skalár szorzat mátrix</returns>
        public static Matrix operator *(Matrix m, int skalar)
        {
            Matrix eredmenyMatrix = new Matrix(m.Sor, m.Oszlop);

            for (uint i = 0; i < m.Sor; i++)
            {
                for (uint j = 0; j < m.Oszlop; j++)
                {
                    eredmenyMatrix.matrixTomb[i, j] = m.matrixTomb[i, j] * skalar;
                }
            }
            return eredmenyMatrix;
        }

        /// <summary>
        /// Szorzás operátor, amely két mátrixot szoroz össze
        /// </summary>
        /// <param name="m1Matrix">Szorzandó</param>
        /// <param name="m2Matrix">Szorzó</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1Matrix, Matrix m2Matrix)
        {
            // lehet önálló feladat, vagy házi feladat
            if (m1Matrix.Oszlop != m2Matrix.Sor)
            {
                throw new InvalidEnumArgumentException("A szorzandó mátrix oszlop számának meg kell egyeznie a szorzó mátrix sorainak számával!");
            }

            Matrix eredmenyMatrix = new Matrix(m1Matrix.Sor, m2Matrix.Oszlop);

            for (uint i = 0; i < eredmenyMatrix.Sor; i++)
            {
                for (uint j = 0; j < eredmenyMatrix.Oszlop; j++)
                {
                    int sum = 0;
                    for (uint k = 0; k < m1Matrix.Oszlop; k++)
                    {
                        sum += m1Matrix.matrixTomb[i, k] * m2Matrix.matrixTomb[k, j];
                    }
                    eredmenyMatrix.matrixTomb[i, j] = sum;
                }
            }

            return eredmenyMatrix;
        }


        /// <summary>
        /// Operátor függvény két mátrix összeadásához
        /// </summary>
        /// <param name="m1">Első mátrix</param>
        /// <param name="m2">második mátrix</param>
        /// <returns>Összegzett mátrix</returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix eredmenyMatrix = new Matrix(m1.Sor, m1.Oszlop);
            if (m1.Sor != m2.Sor || m1.Oszlop != m2.Oszlop)
            {
                //Mátrixokat csak akkor lehet összeadni, ha dimenziójuk megegyezik.
                // Ha nem egyezik meg, akkor kivételt dobunk.
                throw new InvalidOperationException("A mátrixok dimenziójának meg kell egyeznie");
            }

            for (uint i = 0; i < m1.Sor; i++)
            {
                for (uint j = 0; j < m1.Oszlop; j++)
                {
                    eredmenyMatrix.matrixTomb[i, j] = m1.matrixTomb[i, j] + m2.matrixTomb[i, j];
                }
            }
            return eredmenyMatrix;
        }

        /// <summary>
        /// Indexer property adott elem lekérdezéséhez, módosításához
        /// </summary>
        /// <param name="sor">Sorszám</param>
        /// <param name="oszlop">Oszlopszám</param>
        /// <returns>Összegzett mátrix</returns>
        public int this[int sor, int oszlop]
        {
            get
            {
                return matrixTomb[sor, oszlop];
            }

            set
            {
                matrixTomb[sor, oszlop] = value;
            }
        }
    }
}
