﻿using System.Xml;

namespace Desafio_1_JogoDaVelha
{
    internal class Program
    {
        static string[,] tabuleiro = new string[3, 3];
        static string jogoAtivo = "Y";

        static void Main(string[] args)
        {
            Console.Title = "DESAFIO JOGO DA VELHA";

            while (jogoAtivo == "Y")
            {
                montarTabuleiro();

                while (!verificaVitoria())
                {
                    receberInput("X");
                    if (verificaVitoria())
                    {
                        jogoAtivo = "N";
                        break;
                    }

                    receberInput("O");
                    if (verificaVitoria())
                    {
                        jogoAtivo = "N";
                        break;
                    }
                }

                if (verificaVitoria()) Console.WriteLine("Parabéns! Você venceu!");
                else  Console.WriteLine("Empate!");

            }

            mensagemFinal();
        }

        //montar o tabuleiro com valores de 1 à 9
        static void montarTabuleiro()
        {
            int tamanho = 3;
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    tabuleiro[i, j] = ((i * tamanho) + j + 1).ToString();
                }
            }
        }


        static void mensagemFinal()
        {
            Console.WriteLine("Desafio Academia .NET ATOS.");
        }

        static void receberInput(string jogador)
        {
            Console.Clear();
            Console.WriteLine("---JOGO DA VELHA---");
            Console.WriteLine($"Jogador Atual - {jogador}");

            bool validaInput;

            do
            {
                imprimirTabuleiro();
                Console.Write("Digite um número :");

                //valida a entrada de dados
                validaInput = int.TryParse(Console.ReadLine(), out int input);

                if (validaInput)
                {
                    int linha = 0;
                    int coluna = 0;

                    //localizar o input no tabuleiro
                    if (input == 1 || input == 2 || input == 3) linha = 0;
                    if (input == 4 || input == 5 || input == 6) linha = 1;
                    if (input == 7 || input == 8 || input == 9) linha = 2;
                    
                    if (input == 1 || input == 4 || input == 7) coluna = 0;
                    if (input == 2 || input == 5 || input == 8) coluna = 1;
                    if (input == 3 || input == 6 || input == 9) coluna = 2;
                   

                    validaInput = tabuleiro[linha, coluna] != "X" && tabuleiro[linha, coluna] != "O";
                    tabuleiro[linha, coluna] = jogador;

                    if (!validaInput)
                    {
                        Console.WriteLine("Posição já escolhida. Escolha outro número.");
                    }
                }
                else
                {
                    Console.WriteLine("Dado inválido. Escolha um número válido de 1-9.");
                }
            } while (!validaInput);

        }

        static void imprimirTabuleiro()
        {
            Console.WriteLine();
            Console.Write($"{tabuleiro[0, 0]}  | {tabuleiro[0, 1]}  | {tabuleiro[0, 2]}");
            Console.WriteLine();
            Console.WriteLine("_____________\n");

            Console.Write($"{tabuleiro[1, 0]}  | {tabuleiro[1, 1]}  | {tabuleiro[1, 2]}");
            Console.WriteLine();
            Console.WriteLine("_____________\n");

            Console.Write($"{tabuleiro[2, 0]}  | {tabuleiro[2, 1]}  | {tabuleiro[2, 2]}");
            Console.WriteLine();
            Console.WriteLine("_____________\n");
        }


        static bool verificaVitoria()
        {
            // checando se as linhas sao iguais

            if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2]) return true;
            if (tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2]) return true;
            if (tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2]) return true;

            // verificando as colunas
            if (tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0]) return true;
            if (tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1]) return true;
            if (tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2]) return true;

            // verificando as diagonais
            if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2]) return true;
            if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0]) return true;

            return false;
        }

    }
}

