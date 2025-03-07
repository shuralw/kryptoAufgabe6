﻿using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xeuclid.Tests
{
    [TestClass]
    public class AufgabenKontrolle
    {
        [TestMethod]
        public void Aufgabe1_Dechiffrieren()
        {
            RSASolver rsaSolver = new RSASolver();
            BigInteger M = rsaSolver.BerechneMessageAnhandEinesChiffratsUndPublicKeys(Arthurs_Key_Aufgabe1, Fords_Key_Aufgabe1, chiffre_Aufgabe1);

            // 112 soll herauskommen, prüfe ob dies gegeben ist.
            Assert.AreEqual(112, M);
        }

        [TestMethod]
        public void Aufgabe2_Dechiffrieren()
        {
            // Arrange
            RSASolver rsaSolver = new RSASolver();

            // Act
            BigInteger M = rsaSolver.BerechneMessageAnhandEinesChiffratsUndPublicKeys(Fords_Key_Aufgabe2, Arthurs_Key_Aufgabe2, chiffre_Aufgabe2);

            // Assert
            // 42 soll herauskommen, prüfe ob dies gegeben ist.
            Assert.AreEqual(42, M);
        }

        [TestMethod]
        public void Aufgabe1_ChiffreZurKontrolle()
        {
            // Arrange
            RSASolver rsaSolver = new RSASolver();
            BigInteger M = 112;

            // Act 
            BigInteger C_Kontrolle = rsaSolver.BerechneChiffrat(Arthurs_Key_Aufgabe1, M);

            // Assert
            Assert.AreEqual(chiffre_Aufgabe1, C_Kontrolle);
        }

        [TestMethod]
        public void Aufgabe2_ChiffreZurKontrolle()
        {
            // Arrange
            RSASolver rsaSolver = new RSASolver();
            BigInteger M = 42;

            // Act 
            BigInteger C_Kontrolle = rsaSolver.BerechneChiffrat(Fords_Key_Aufgabe2, M);

            // Assert
            Assert.AreEqual(chiffre_Aufgabe2, C_Kontrolle);
        }


        static public_key Arthurs_Key_Aufgabe1 = new public_key()
        {
            N = 221,
            e = 55
        };


        static public_key Fords_Key_Aufgabe1 = new public_key()
        {
            N = 391,
            e = 3
        };


        static BigInteger chiffre_Aufgabe1 = 5;
        static BigInteger chiffre_Aufgabe2 = BigInteger.Parse("8268015551976081976349298826528580837930452617987975384355237605082111651036516740772520405265785953221210032057066003337181623841293788447406116611877460581540995824477867363480928810705248879687632234719681504924675920519027623025538381448306347263928111720884156712384626872770730588045483464195829585202301564439061360519474480854831507468323867099118764888968515234371415120333770395306846503016793830620598831962042909522821314632391674879210542451463665178367408834934336819719234337898366158589442544970734938971999129680602499430990221846731725574146429511926240006248492415088789822969694283049443553696006");

        static public_key Arthurs_Key_Aufgabe2 = new public_key()
        {
            N = BigInteger.Parse("22110353244313571990253947726448700077443799253406660177539041122286765386297310000624571255327108496704433541802282181077577052293207873618616856325300481078151287575967405833226335344276559322617210444468625925561175939075849496718494786067062535178871669751762240085850774614288584598896914586928107067984493428904565220859347561525719531741217278287666243358923774175067649151386827137528823240283946807493177939741504278807764069512011353961858632308604834276891354166708590024569596034499839659092216324314789282948363742579018085735215693697393708782328192259892300038044916383109648663926619841075984159391291"),
            e = 65537
        };

        static public_key Fords_Key_Aufgabe2 = new public_key()
        {
            N = BigInteger.Parse("8426787171468382497075769357030611980814685788816257398102710770897246707635297760774759792373215209813848976420620420784548514222696366158140174407697178456459496638227776376886099407473515210480211767300220008668414377545044685658970131856283919959367080468375610676782674134025062853802165025709299151440079688790957995816451657881792767625455020761844813293082113111815333796507322859004543179840288109175394621725262012835735899917596920833597957719961691988259685474684646672054835590480479532791649613390772338664115220731756733799369417161132341744402629093797964181079824578424248571013550675119181587766747"),
            e = 65537
        };
    }
}
