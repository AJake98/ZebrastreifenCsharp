/*Zebrastreifen Release 1 
  Version 1.0.0
  Maturity Release Candidate

  Zur Vorlage beim Kunden
*/
using System;
using System.Linq;
using System.Web;

namespace ZebraStreifen
{
    public class Program
    {
        private const int zebraWidth = 0;
        private const int zebraHeight = 1;
        private const int zebraColumnWidth = 2;
        private const int zebraMinWidth = 3;

        public static void minimumWidth(int[] zebraParams)
        {
            zebraParams[zebraMinWidth] = (zebraParams[zebraWidth] / (zebraParams[zebraColumnWidth]));
        }


        public static string generateZebraStreifenNucleus(int[] zebraParams)
        {
            string zebraStreifenNucleus = "";
            zebraStreifenNucleus += String.Concat(Enumerable.Repeat("*", zebraParams[zebraColumnWidth]));
            zebraStreifenNucleus += String.Concat(Enumerable.Repeat(" ", zebraParams[zebraColumnWidth]));
            return zebraStreifenNucleus;
        }

        public static string generateZebraStreifenLine(string zebraStreifenNucleus, int[] zebraParams)
        {
            if (zebraStreifenNucleus == "") throw new IllegalArgumentException();
            string zebraStreifenRow = "";
            zebraStreifenRow = String.Concat(Enumerable.Repeat(zebraStreifenNucleus, zebraParams[zebraMinWidth]));
            zebraStreifenRow = zebraStreifenRow.Substring(0, zebraParams[zebraWidth]) + "\n";
            return zebraStreifenRow;
        }

        public static string generateZebraStreifen(string zebraStreifenLine, int[] zebraParams)
        {
            if (zebraParams.Contains(0)||zebraStreifenLine=="")
            {
                throw new IllegalArgumentException();
            }
            string zebraStreifen = "";
            zebraStreifen += String.Concat(Enumerable.Repeat(zebraStreifenLine, zebraParams[zebraHeight]));
            return zebraStreifen;
        }

        public static bool prerequisitsForGenerateZebraStreifen(int[] zebraParams)
        {
            //width <= 2* columnSize
            //height >= 4
            //columnSize >=3 && columnSize <=5

            return true;
        }

        public static int[] zebraParamsUserInput()
        {
            int[] zebraParams = new int[4];
            Console.WriteLine("Parameter für Zebrastreifen eingeben:\n1.Breite in Zeichen:\n");
            zebraParams[zebraWidth] = Int16.Parse(Console.ReadLine());
            Console.WriteLine("2.Höhe in Zeilen\n");
            zebraParams[zebraHeight] = Int16.Parse(Console.ReadLine());
            Console.WriteLine("3.Breite der Streifen in Zeichen:\n");
            zebraParams[zebraColumnWidth] = Int16.Parse(Console.ReadLine());
            //minimumWidth(zebraParams);
            return zebraParams;
        }
        public static void Main(String[] args)
        {
            int[] zebraParams = zebraParamsUserInput();
            prerequisitsForGenerateZebraStreifen(zebraParams);
            minimumWidth(zebraParams);
            string zebraStreifenNucleus=generateZebraStreifenNucleus(zebraParams);
            string zebraStreifenLine = generateZebraStreifenLine(zebraStreifenNucleus, zebraParams);
            string zebraStreifen = generateZebraStreifen(zebraStreifenLine, zebraParams);
            Console.WriteLine(zebraStreifen);
            Console.ReadLine();
        }
    }

    public class IllegalArgumentException:Exception
    {
        public IllegalArgumentException() { }
    }
}