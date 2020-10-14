using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paginacao_vetor
{
    class Program
    {
        static void Main(string[] args)
        {
            int vlrReserv = 0010101010;
            int qtdEndereco = 12;
            int[] endereco = new int[12] { 1, 3, 5, 2, 8, 8, 4, 1, 0, 7, 0, 2 };
            int[] lru = new int[3] { vlrReserv, vlrReserv, vlrReserv};
            int qtdHit = 0;
            int qtdFalta = 0;

            for (int i = 0; i < qtdEndereco; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green; // alterando cor para verde
                Console.WriteLine("ENDEREÇO DA PÁGINA A SER ACESSADA: " + endereco[i]);
                Console.ResetColor(); // deixando cor padrão

                  if (endereco[i] != lru[0] && endereco[i] != lru[1] && endereco[i] != lru[2])
                  {
                      if (lru[0] == vlrReserv)
                      {
                        lru[0] = endereco[i];
                      }
                          else if (lru[1] == vlrReserv)
                          {
                            lru[1] = endereco[i];
                          }
                              else if (lru[2] == vlrReserv)
                              {
                                lru[2] = endereco[i];
                              }
                                  else if (lru[0] != vlrReserv && lru[1] != vlrReserv && lru[2] != vlrReserv)
                                  {
                                      lru[0] = lru[1];
                                      lru[1] = lru[2];
                                      lru[2] = endereco[i];
                                  }
                      
                      Console.WriteLine("Houve falta da página " +endereco[i]);
                      
                      Console.ForegroundColor = ConsoleColor.Yellow;
                      Console.WriteLine("Contem as seguintes páginas agora: ");
                      for (int j = 0; j < 3; j++)
                      {
                          if (lru[j] != vlrReserv)
                          {
                              Console.WriteLine("-----> " + lru[j]);
                          }
                          else Console.WriteLine("-----> ");
                      }
                      Console.ResetColor();
                      qtdFalta = qtdFalta + 1;
                  }
                  else if (endereco[i] == lru[0] || endereco[i] == lru[1] || endereco[i] == lru[2])
                  {
                      Console.WriteLine("Não houve falta da página: " + endereco[i]);
                      if (lru[0] != vlrReserv && lru[1] != vlrReserv && lru[2] != vlrReserv)
                      {
                          if (endereco[i] == lru[0])
                          {
                              lru[0] = lru[1];
                              lru[1] = lru[2];
                              lru[2] = endereco[i];
                          }
                          else if (endereco[i] == lru[1])
                          {
                              lru[1] = lru[2];
                              lru[2] = endereco[i];
                          }
                      }

                      else if (lru[0] != vlrReserv && lru[1] != vlrReserv && lru[2] == vlrReserv)
                      {
                          if (endereco[i] == lru[0])
                          {
                              lru[0] = lru[1];
                              lru[1] = endereco[i];
                          }
                        
                      }
                      

                      Console.ForegroundColor = ConsoleColor.Yellow;
                      Console.WriteLine("Contem as seguintes páginas agora: ");
                      for (int j = 0; j < 3; j++)
                      {
                          if (lru[j] != vlrReserv)
                          {
                              Console.WriteLine("-----> " + lru[j]);
                          }
                          else Console.WriteLine("-----> ");
                      }
                      Console.ResetColor();
                      qtdHit = qtdHit + 1;
                  }
              

              

            }
            
            Console.WriteLine("\n \n \n \n A quantidade total de faltas foi:----------" + qtdFalta);
            Console.WriteLine("E a quantidade total de hit foi: " + qtdHit);
            Console.ReadKey();
        }

    }
}
