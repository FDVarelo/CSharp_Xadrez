﻿using System;
using tabuleiro;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Posicao P;
            P = new Posicao(3, 4);

            Console.WriteLine("Posição: " + P);
            Console.WriteLine();*/

            Tabuleiro tab = new Tabuleiro(8, 8);


            Tela.imprimirTabuleiro(tab);
        }
    }
}