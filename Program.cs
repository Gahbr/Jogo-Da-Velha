namespace Desafio_1_JogoDaVelha
{
    internal class Program
    {
        static string tipoJogo = "";
        static string[,] tabuleiro = new string[3, 3];
        static string jogoAtivo = "Y";
        static string jogarNovamenteInput = "";
        static int contadorDeJogadas = -1;

        static void Main(string[] args)
        {
            telaInicial();
            
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

                    if (contadorDeJogadas == 8) break;
                    else
                    {
                        if (int.Parse(tipoJogo) == 1)
                        {
                            receberInput("O");
                        }
                        else if (int.Parse(tipoJogo) == 2)
                        {
                            fazerJogadaMaquina();
                        }
                    }

                    if (verificaVitoria())
                    {
                        jogoAtivo = "N";
                        break;
                    }
                }

                if (verificaVitoria())
                {
                    Console.Clear();
                    Console.WriteLine("Resultado final:");
                    imprimirTabuleiro(); 

                    Console.WriteLine("Parabéns! Você venceu!");
                    jogarNovamente();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Resultado final:");
                    imprimirTabuleiro();

                    Console.WriteLine("Empate!");
                    jogarNovamente();
                    
                    if (jogarNovamenteInput.ToUpper() == "N") break;
                }
            }
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

        static void receberInput(string jogador)
        {
            Console.Clear();
            Console.WriteLine("---JOGO DA VELHA---");
            Console.WriteLine($"Jogador Atual - {jogador}");

            bool validaInput;

            do
            {
                imprimirTabuleiro();
                if (contadorDeJogadas == 8) break;

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

                    if (validaInput)
                    {
                        tabuleiro[linha, coluna] = jogador;
                        contadorDeJogadas++;
                    }

                    if (!validaInput) Console.WriteLine("Posição já escolhida. Escolha outro número.");
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

        static void fazerJogadaMaquina()
        {
            Console.WriteLine("\nVez da máquina:");

            bool jogadaValida = false;
            while (!jogadaValida)
            {
                Random rnd = new Random();
                int linha = rnd.Next(3);
                int coluna = rnd.Next(3);

                if (tabuleiro[linha, coluna] != "X" && tabuleiro[linha, coluna] != "O")
                {
                    tabuleiro[linha, coluna] = "O";
                    jogadaValida = true;
                }
            }

            contadorDeJogadas++;
        }

        static void telaInicial()
        {
            bool validaInput = false;

            while (!validaInput)
            {
                Console.Title = "DESAFIO ACADEMIA .NET - JOGO DA VELHA";
                Console.WriteLine("----JOGO DA VELHA---.\n");
                Console.WriteLine("Escolha seu tipo de jogo:\n1 - PvP\n2 - PC.");

                tipoJogo = Console.ReadLine();
                validaInput = int.TryParse(tipoJogo, out int input);

                if (!validaInput || int.Parse(tipoJogo) > 2 || int.Parse(tipoJogo) < 1)
                {
                    Console.WriteLine("Dado inválido. Escolha a opção 1 ou 2.");
                    validaInput = false;
                }
            }
            Console.Clear();
        }

        static void jogarNovamente()
        {
            Console.WriteLine("Deseja jogar novamente? S ou N");
            string resetGame = Console.ReadLine();

            if (resetGame.ToUpper() == "S")
            {
                contadorDeJogadas = -1;
                jogoAtivo = "Y";
                jogarNovamenteInput = "Y";
            }
            else
            {
                Console.WriteLine("\n||Desafio Academia .NET ATOS.||");
                Console.WriteLine("||Obrigado por jogar!||");
                jogoAtivo = "N";
                jogarNovamenteInput = "N";
            }
        }

    }
}

