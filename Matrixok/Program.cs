using System;

namespace Matrixok
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Matrix m = new Matrix(5, 5);
            m.General(random);
            Console.WriteLine("-----------Mátrix szorzása skalárral----------------------");
            Console.WriteLine(m);

            Console.WriteLine("* ( -3)");
            Matrix skalarMatrix = m * (-3);
            Console.WriteLine(skalarMatrix);

            Console.WriteLine("-----------Mátrixok összeadása----------------------");
            Matrix m1 = new Matrix(3, 3);
            m1.General(random);
            Console.WriteLine(m1);

            Matrix m2 = new Matrix(3, 3);
            m2.General(random);
            Console.WriteLine("+");
            Console.WriteLine(m2);

            Matrix osszegMatrix = m1 + m2;
            Console.WriteLine("=");
            Console.WriteLine(osszegMatrix);

            Console.WriteLine("-----------Mátrixok szorzása----------------------");
            Matrix szorzandoMatrix = new Matrix(2, 3);
            szorzandoMatrix.General(random);
            Console.WriteLine(szorzandoMatrix);

            Matrix szorzoMatrix = new Matrix(3, 2);
            szorzoMatrix.General(random);
            Console.WriteLine("*");
            Console.WriteLine(szorzoMatrix);

            Matrix szorzatMatrix = szorzandoMatrix * szorzoMatrix;
            Console.WriteLine("=");
            Console.WriteLine(szorzatMatrix);


            Matrix m4 = new Matrix(1, 2);
            m4[0, 0] = 1;
            m4[0, 1] = 1;

            Matrix m5 = new Matrix(1, 2);
            m5[0, 0] = 1;
            m5[0, 1] = 1;

            Console.WriteLine(m4 == m5 ? "A két mátrix egyezik" : "A két mátrix különböző");
            Console.Read();
        }
    }
}
