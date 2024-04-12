using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*Jogar dados
----------------------------------------------------------------------------------------------
Objetivo: usando uma aplicação do tipo console do dotnet, criar um jogo simplificado onde dois jogadores podem jogar dados e a aplicação informa qual dos jogadores tirou o maior número.
----------------------------------------------------------------------------------------------
Usaremos nesse exercício a classe Random do dotnet para simular uma jogada de dados com 6 lados. O random irá possibilitar que tiremos um número aleatório (de 1 a 6 para nosso exemplo). Você pode usar loop para esse exercício, estude sobre loops caso não conheça. Poderá também optar por usar recursão (o exemplo de consulta usa recursão no método "IniciarRodadas"), recomendo estudar sobre recursão também antes de iniciar o exercício.
----------------------------------------------------------------------------------------------
Requisitos para desenvolver a aplicação
Quando o usuário abrir o jogo deverá ser solicitado o nome do primeiro e do segundo jogador. Não será possível jogar com mais do que dois jogadores.

O jogo deverá solicitar um nome para cada jogador e os nome não podem ser iguais.

O jogo terá 3 rodadas, o jogador que tirar o maior número no dados na maioria das jogadas vence a partida.

Em caso de empate (onde os dois tiram o mesmo número) nenhum jogador pontuará.

A cada rodada a aplicação deve informar quem foi o jogador vencedor. Exemplos de mensagens:

João tirou o número 2 e Maria o número 6. Maria venceu a rodada 1.
João tirou o número 1 e Maria o número 1. Empate.
Um placar sempre deve ser exibido até o final do jogo para que os jogadores acompanhem o resultado. Exemplo: Pontos do jogador Maria: 1 Pontos do jogador João: 0

Ao final da rodada 3 a aplicação deve informar quem foi o vencedor ou se foi um empate.
----------------------------------------------------------------------------------------------
Desafios
Se a terceira rodada terminar em empate, faça com que os jogadores continuem jogando dados. O próximo a pontuar ganha o jogo.
Crie uma opção antes de iniciar o jogo que permite que o usuário selecione a quantidade de rodadas. A quantidade deve estar entre 1 e 5.
----------------------------------------------------------------------------------------------
 */
namespace Jogar_Dados
{
    internal class Program
    /*
     * Em C#, uma classe interna é um objeto que só pode ser usado pela classe que está a ser escrita. Uma classe interna tem acesso a todas as variáveis e métodos da classe que a contém.
     * 
     * O modificador de acesso "internal" é o padrão se nenhum modificador de acesso for especificado. O modificador de acesso "internal" restringe o acesso a classes dentro do mesmo projeto ou assembly.
     * 
     * Os modificadores de acesso são importantes para controlar a visibilidade e o acesso a membros num programa. 
       Aqui estão alguns outros modificadores de acesso em C#:
       ---------------------------------------------------------------------------------------
       Public: Acesso irrestrito
       ---------------------------------------------------------------------------------------
       Protected: Acesso limitado à classe ou a tipos que derivem da mesma classe
       ---------------------------------------------------------------------------------------
       Protected internal: Acesso limitado ao assembly, à própria classe ou a tipos derivados dela
       ---------------------------------------------------------------------------------------
       Private: Acesso limitado à própria classe
       ---------------------------------------------------------------------------------------
       Private protected: Acesso limitado à classe que o contém ou a tipos derivados da classe que o contém no assembly atual
       ---------------------------------------------------------------------------------------
       File: O tipo declarado apenas é visível no arquivo de origem atual 
       As classes com visibilidade interna são usadas quando se têm soluções mais complexas.
       ---------------------------------------------------------------------------------------
       Em alguns casos, podem ser usados para ofuscação de código e dificultar o acesso indevido.
     
     */
    {
        //Criação de variáveis para acessar os jogadores de qualquer método.
        public static string jogador1;
        public static string jogador2;

        //Variáveis para armazenar os pontos dos jogadores.
        public static byte pontosJogador1;
        public static byte pontosJogador2;

        //Variável para armazenar a rodada atual.
        public static byte rodadaAtual;

        //Na linguagem C#, a palavra-chave "byte" é usada para declarar variáveis que armazenam valores inteiros entre 0 e 255. É um tipo de inteiro sem sinal que ocupa 1 byte de memória.

        static void Main(string[] args)
        {
            Console.Clear();
            ConfigurarJogo();
            IniciarRodadas();
        }

        public static void ConfigurarJogo() 
        {
            rodadaAtual = 0;

            CriarJogadores();
            AtualizarPlacar();

            Console.WriteLine($"\n Jogadores {jogador1} e {jogador2} criados. Pressione qualquer tecla para iniciar o jogo : ");
            Console.ReadKey();

        }

        public static void CriarJogadores() 
        {
            Console.WriteLine("Informe o nome do primeiro jogador : ");
            jogador1 = Console.ReadLine();
            pontosJogador1 = 0;
            Console.WriteLine("Informe o nome do segundo jogador : ");
            jogador2 = Console.ReadLine();
            pontosJogador2 = 0;

        }

        public static void AtualizarPlacar()
        {
            Console.Clear();
            Console.WriteLine($"### Pontos do jogador {jogador1} : {pontosJogador1}");
            Console.WriteLine($"### Pontos do jogador {jogador2} : {pontosJogador2}");
            Console.WriteLine();

            if(rodadaAtual == 0)
            {
                Console.WriteLine(" ### Jogo não iniciado ...");
            }
        }

        //Esse método faz uso de recursão pesquisar sobre o assunto!!!
        public static void IniciarRodadas()
        {
            

            AtualizarPlacar();
            if (rodadaAtual == 3){
                FinalizarJogo();
                return;
            }

            rodadaAtual++;


            Console.WriteLine($"Rodada {rodadaAtual} iniciada\n");

            Console.WriteLine($"Jogador {jogador1}, pressione ENTER para fazer sua jogoda... ");
            Console.ReadLine();
            byte valorTiradoJogador1 = JogarDado();
            Console.WriteLine($"O valor do DADO tirado pelo {jogador1} : {valorTiradoJogador1}");

            Console.WriteLine($"Jogador {jogador2}, pressione ENTER para fazer sua jogada... ");
            Console.ReadLine();
            byte valorTiradoJogador2 = JogarDado();
            Console.WriteLine($"O valor do DADO tirado pelo {jogador2} : {valorTiradoJogador2}");

            if(valorTiradoJogador1 == valorTiradoJogador2)
            {
                Console.WriteLine($"\n{jogador1} tirou o número {valorTiradoJogador1} e {jogador2} tirou o número {valorTiradoJogador2} EMPATE !!!");
                Console.WriteLine("Pressione enter para continuar com o jogo !");
                Console.ReadLine();
            }
            else
            {
                string vencedor;
                if(valorTiradoJogador1 > valorTiradoJogador2)
                {
                    vencedor = jogador1;
                    pontosJogador1++;
                }
                else
                {
                    vencedor = jogador2;
                    pontosJogador2++;
                }

                Console.WriteLine($"\n{jogador1} tirou o número {valorTiradoJogador1} e {jogador2} tirou o número {valorTiradoJogador2}. {vencedor} !!!");
                Console.WriteLine("Pressione enter para continuar com o jogo !");
                Console.ReadLine();

            }

            IniciarRodadas();
        }

        public static byte JogarDado()
        {
            Random random = new Random();
            return Convert.ToByte(random.Next(1, 6));
        }

        public static void FinalizarJogo() 
        {
            Console.WriteLine("Jogo finalizado!!!");
            if(pontosJogador1 == pontosJogador2)
            {
                Console.WriteLine("Empate!!!");
            }
            else if(pontosJogador1 > pontosJogador2)
            {
                Console.WriteLine($"O jogador {jogador1} venceu com {pontosJogador1} pontos !");
            }
            else
            {
                Console.WriteLine($"O jogador {jogador2} venceu com {pontosJogador2} pontos !");
            }
            Console.ReadKey();
        }

    }

}
