using System;

namespace Strings01
{
    class Program
    {
        public static string Jogador1 = "";
        public static string Jogador2 = "";
        public static byte PontosJogador1;
        public static byte PontosJogador2;
        public static byte RodadaAtual;

        static void Main(string[] args)
        {
            Console.Clear();
            ConfigurarJogo();
            IniciarRodadas();
        }

        public static void ConfigurarJogo()
        {
            RodadaAtual = 0;

            do
            {
                Console.WriteLine("Player 01 digite seu nome: ");
                Jogador1 = Console.ReadLine();
                PontosJogador1 = 0;

                Console.WriteLine("Player 02 digite seu nome: ");
                Jogador2 = Console.ReadLine();
                PontosJogador2 = 0;

                if (Jogador1 == Jogador2)
                {
                    Console.WriteLine("Os nomes precisam ser diferentes!");
                }
                else
                {
                    Console.WriteLine("Vamos começar !");
                }
            } while (Jogador1 == Jogador2); // Repete até que os nomes dos jogadores sejam diferentes

            Console.WriteLine($"\nJogadores {Jogador1} e {Jogador2} criados. Pressione qualquer tecla para iniciar o jogo");
            Console.ReadKey();
        }

        public static void AtualizarPlacar()
        {
            Console.Clear();
            Console.WriteLine($"### Pontos do jogador {Jogador1}: {PontosJogador1}");
            Console.WriteLine($"### Pontos do jogador {Jogador2}: {PontosJogador2}");
            Console.WriteLine();

            if (RodadaAtual == 0)
            {
                Console.WriteLine("### jogo não iniciado...");
            }
        }

        public static void IniciarRodadas()
        {
            AtualizarPlacar();
            if (RodadaAtual == 3)
            {
                FinalizarJogo();
                return;
            }

            RodadaAtual++;

            Console.WriteLine($"Rodada {RodadaAtual} iniciada!\n");

            Console.WriteLine($"Jogador {Jogador1}, pressione ENTER para fazer sua jogada...");
            Console.ReadLine();
            byte valorTiradoJogador1 = JogarDado();
            Console.WriteLine($"Valor do dado jogado pelo {Jogador1}: {valorTiradoJogador1}");

            Console.WriteLine($"Jogador {Jogador2}, pressione ENTER para fazer sua jogada...");
            Console.ReadLine();
            byte valorTiradoJogador2 = JogarDado();
            Console.WriteLine($"Valor do dado jogado pelo {Jogador2}: {valorTiradoJogador2}");

            if (valorTiradoJogador1 == valorTiradoJogador2)
            {
                Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. Empate!");
            }
            else
            {
                string vencedor = (valorTiradoJogador1 > valorTiradoJogador2) ? Jogador1 : Jogador2;
                Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. {vencedor} venceu a rodada {RodadaAtual}");
                
                if (vencedor == Jogador1)
                    PontosJogador1++;
                else
                    PontosJogador2++;
            }

            Console.WriteLine("Pressione ENTER para continuar com o jogo...");
            Console.ReadLine();
            IniciarRodadas();
        }

        public static byte JogarDado()
        {
            Random random = new Random();
            return Convert.ToByte(random.Next(1, 6));
        }

        public static void FinalizarJogo()
        {
            AtualizarPlacar();
            Console.WriteLine("Jogo finalizado!!!");

            if (PontosJogador1 == PontosJogador2)
            {
                Console.WriteLine("Empate!");
            }
            else if (PontosJogador1 > PontosJogador2)
            {
                Console.WriteLine($"O jogador {Jogador1} venceu com {PontosJogador1} pontos!");
            }
            else
            {
                Console.WriteLine($"O jogador {Jogador2} venceu com {PontosJogador2} pontos!");
            }
        }
    }
}
