//Desenvolva um jogo da velha utilizando matrizes em C#. Faça com que cada jogador insira a sua jogada em uma interface amigavel. 
//Teste se a posição é válida e caso não seja solicite ao jogador repetir a jogada. Após cada jogada, apresente o tabuleiro com as 
//jogadas representadas por "X" e "O" e faça a verficação se algum jogador venceu.
//Caso seja empate, apresente o resultado na tela. Possilibilite que o jogo seja reinicializado sem a necessidade de reiniciar o jogo. 


//Desafio extra, pode valer por alguma atividade futura: Faça a implementação de um jogo contra o computador. Faça o possível para evitar que o jogador vença do computador. 
//Para facilitar, faça com que o computador inicie jogando.

//Prazo de entrega: 24 / 04
//Forma e envio: Enviar pelo chat o link do github


namespace Desafio_1_JogoDaVelha
{
    internal class Program
    {
        static string[,] tabuleiro = new string[3, 3];
        static string jogoAtivo = "Y";

        static void Main(string[] args)
        {
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

                if (verificaVitoria())
                    Console.WriteLine("Parabéns! Você venceu!");
                else
                    Console.WriteLine("Empate!");

            }

            mensagemFinal();
        }

        //montar o tabuleiro com valores de 1 à 9
        static void montarTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = $"{(i * 3) + j + 1}";
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
                    int linha = (input - 1) / 3;
                    int coluna = (input - 1) % 3;

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

