using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimitiveTypes
{
    [TestClass]
    public class WoodFlooring
    {
        [TestMethod]
        public void Test1()
        {
            double roomLenght = 5.5;
            double roomWidth = 4.7;
            double parquetLenght = 1.286;
            double parquetWidth = 0.194;

            int parquetPiecesActual = 120;
            double parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        [TestMethod]
        public void Test2()
        {
            double roomLenght = 10;
            double roomWidth = 10;
            double parquetLenght = 1;
            double parquetWidth = 1;

            int parquetPiecesActual = 115;
            int parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        [TestMethod]
        // Room lenght is 0
        public void Test3()
        {
            double roomLenght = 0;
            double roomWidth = 4.7;
            double parquetLenght = 1.286;
            double parquetWidth = 0.194;

            int parquetPiecesActual = 0;
            double parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        [TestMethod]
        //Room width is 0
        public void Test4()
        {
            double roomLenght = 5.5;
            double roomWidth = 0;
            double parquetLenght = 1.286;
            double parquetWidth = 0.194;

            int parquetPiecesActual = 0;
            double parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        [TestMethod]
        //Parquet piese lenght is 0
        public void Test5()
        {
            double roomLenght = 5.5;
            double roomWidth = 4.7;
            double parquetLenght = 0;
            double parquetWidth = 0.194;

            int parquetPiecesActual = 0;
            double parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        [TestMethod]
        //Parquet piece width is 0
        public void Test6()
        {
            double roomLenght = 5.5;
            double roomWidth = 4.7;
            double parquetLenght = 1.286;
            double parquetWidth = 0;

            int parquetPiecesActual = 0;
            double parquetPiecesExpected = HowManyParquetPieces(roomLenght, roomWidth, parquetLenght, parquetWidth);

            Assert.AreEqual(parquetPiecesExpected, parquetPiecesActual);
        }

        private int HowManyParquetPieces (double roomLenght, double roomWidth, double parquetLenght, double parquetWidth)
        {
            if (parquetLenght <= 0 || parquetWidth <= 0)
            {
                return 0;
            } else
            {
                double roomArea = roomLenght * roomWidth;
                double totalAreaincludingLoses = roomArea * 1.15;
                double oneParquetPieceArea = parquetLenght * parquetWidth;
                      
                return Convert.ToInt32(Math.Ceiling(totalAreaincludingLoses / oneParquetPieceArea));
            }
        }

    }
}
