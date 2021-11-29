//Crie um programa para uma lanchonete que controle mesas e seus pedidos, e que permita a qualquer momento consultar o valor total dos pedidos de uma determinada mesa.
using System;
class MainClass {
 
  public static void Main (string[] args) {
    bool escolheuSair = false;
    int opcao = 0, mesaselecionada = 0, opcaoproduto = 0, troca = 0;
    string confirmar = "";
    int[] mesas = new int[11];
    string[] nomeProduto = {"Hamburguers","Pizzas","Amendoins","Águas", "Caviares"};
    int [] precoproduto = {20, 40, 100,500,2};
    int[,] qtdProduto = new int[11,5];
    

    while(escolheuSair!=true){
      Console.WriteLine("[1] - Mesas\n[2] - Ver pedidos\n[0] - Sair");
      opcao = int.Parse(Console.ReadLine());
      Console.Clear();
      switch(opcao){
        default: //opção inválida
          Console.WriteLine("Essa opção não existe. Pressione ENTER para VOLTAR.");
          Console.ReadLine();
          Console.Clear();
        break;

        case 0: //escolheu sair
          escolheuSair = true;
        break;

        case 1: //opções de mesa
          while(escolheuSair!=true){
            if(mesaselecionada<0){
              Console.WriteLine($"========================\nMESA ATUAL: INDEFINIDA.\n========================");
            }else{
              Console.WriteLine($"========================\nMESA ATUAL: {mesaselecionada}\n========================");
            }
            

            Console.WriteLine("[1] - Selecionar Mesa\n[2] - Adicionar Pedidos\n[3] - Remover Pedidos\n[4] - Ver os Pedidos\n[0] - Voltar");
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch(opcao){
              
              default: //opção inexistente
                Console.Write("OPÇÃO INEXISTENTE! Pressione ENTER para VOLTAR.");
                Console.ReadLine();
                Console.Clear();
              break;
              case 0: //volta para o primeiro menu
                Console.Clear();
                escolheuSair = true;
              break;

              case 1: //seleção de mesas
                Console.Write("Qual mesa deseja selecionar? [0 a 10]: ");
                mesaselecionada = int.Parse(Console.ReadLine());
                
                Console.Clear();
                if(mesaselecionada<0 || mesaselecionada>10){
                  Console.WriteLine("ESSA MESA NÃO EXISTE! Pressione ENTER para VOLTAR.");
                  Console.ReadLine();
                  mesaselecionada = -1;
                }else{
                  Console.Write($" Você selecionou a mesa {mesaselecionada}! Confirmar [S/N]: ");
                  confirmar = Console.ReadLine();
                  if(confirmar.ToUpper() == "S"){
                    Console.WriteLine($"\n Você selecionou a mesa {mesaselecionada}! Pressione ENTER para CONTINUAR.");
                    Console.ReadLine();
                  }else{
                    Console.WriteLine(" Seleção cancelada. Pressione ENTER para VOLTAR.");
                    Console.ReadLine();
                    mesaselecionada = -1;
                  }
                }
                Console.Clear();
              break;

              case 2: //adicionar pedidos
                if(mesaselecionada<0){
                  Console.WriteLine("Você precisa definir uma mesa para selecionar essa opção.\nPressione ENTER para VOLTAR.");
                  Console.ReadLine();
                  Console.Clear();
                }else{ //Momento da compra dos produtos.
                  while(escolheuSair!=true){
                    Console.WriteLine($"====================================\nMESA {mesaselecionada}\n====================================\n[0] - Hamburguer (20.00R$)\n[1] - Pizza (40.00R$)\n[2] - Amendoim (100.00R$)\n[3] - Água (500.00R$)\n[4] - Caviar (2.00R$)\n[5] - Sair");
                    opcaoproduto = int.Parse(Console.ReadLine());
                    Console.Clear();
                    
                    switch(opcaoproduto){
                      default: // se a opção não existir.
                        Console.WriteLine("Essa opção não existe! Pressione ENTER para VOLTAR.");
                        Console.ReadLine();
                        Console.Clear();
                      break;
                      case 5: // se escolher voltar.
                        escolheuSair = true;
                        Console.Clear();
                      break;

                      case 0: // quantidade de hamburguers
                        qtdProduto[mesaselecionada,opcaoproduto] = AdicionarQTD(qtdProduto, mesaselecionada, opcaoproduto, nomeProduto, confirmar, precoproduto);
                      break;

                      case 1: //quantidade de pizza
                        qtdProduto[mesaselecionada,opcaoproduto] = AdicionarQTD(qtdProduto, mesaselecionada, opcaoproduto, nomeProduto, confirmar, precoproduto);
                      break;

                      case 2: // quantidade de amendoim
                        qtdProduto[mesaselecionada,opcaoproduto] = AdicionarQTD(qtdProduto, mesaselecionada, opcaoproduto, nomeProduto, confirmar, precoproduto);
                      break;

                      case 3: // quantidade de água
                        qtdProduto[mesaselecionada,opcaoproduto] = AdicionarQTD(qtdProduto, mesaselecionada, opcaoproduto, nomeProduto, confirmar, precoproduto);
                      break;

                      case 4: // quantidade de caviar
                        qtdProduto[mesaselecionada,opcaoproduto] = AdicionarQTD(qtdProduto, mesaselecionada, opcaoproduto, nomeProduto, confirmar, precoproduto);
                      break;
                    }
                    Console.Clear();
                  }
                  escolheuSair = false;
                }
              break;

              case 3: //remover pedidos
                if(mesaselecionada<0){
                  Console.WriteLine("Você precisa definir uma mesa para selecionar essa opção.\nPressione ENTER para VOLTAR.");
                  Console.ReadLine();
                  Console.Clear();
                }else{
                  while(escolheuSair!=true){
                      Console.Clear();
                      Console.WriteLine($"======================\n PRODUTOS MESA {mesaselecionada}:");
                      for(int j = 0; j<=4; j++){ //exibindo os produtos listados
                        if(qtdProduto[mesaselecionada,j]>0){
                          Console.WriteLine($" {nomeProduto[j]} ({qtdProduto[mesaselecionada,j]}x) PREÇO: {precoproduto[j]*qtdProduto[mesaselecionada,j]}R$\n");
                        }
                      }
                      Console.WriteLine("\n======================\n");
                      Console.WriteLine("\n- - - - - - - - - - - -\nQual produto deseja REMOVER?\n- - - - - - - - - - - -\n[0] - Hamburguer (20.00R$)\n[1] - Pizza (40.00R$)\n[2] - Amendoim (100.00R$)\n[3] - Água (500.00R$)\n[4] - Caviar (2.00R$)\n[5] - Sair");
                      opcao = int.Parse(Console.ReadLine());
                      Console.Clear();
                      if(opcao == 5){
                        escolheuSair = true;
                        Console.Clear();
                      }else{
                        if(qtdProduto[mesaselecionada,opcao]<=0){
                        Console.WriteLine("Essa mesa não contém tal produto. Pressione ENTER para VOLTAR.");
                        Console.ReadLine();
                        Console.Clear();
                        }else{
                          if(opcao>=0 && opcao<=4){
                            qtdProduto[mesaselecionada, opcao] = RemoverProdutos(qtdProduto,nomeProduto, mesaselecionada, precoproduto, opcao);
                            Console.Clear();
                          }else{
                          
                          Console.WriteLine("Essa opção não existe! Pressione ENTER para VOLTAR.");
                          Console.ReadLine();
                          Console.Clear();
                        }
                      }
                    }
                  }
                  
                  

                }
                escolheuSair = false;
              break;

              case 4:
                if(mesaselecionada<0){
                  Console.WriteLine("Deseja ver os pedidos de qual mesa? [0 a 10]: ");
                }else{
                  Console.Write($"Deseja ver os pedidos de qual mesa? [0 a 10] (MESA ATUAL: {mesaselecionada}):");
                }
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                if(opcao>=0 && opcao <=10){
                  troca = mesaselecionada; mesaselecionada = opcao; //troca 1;
                  MostrarProdutos(qtdProduto, mesaselecionada, nomeProduto, precoproduto);
                  mesaselecionada = troca; opcao = troca; // troca 2;
                }else{
                  Console.WriteLine("Essa opção não existe! Pressione ENTER para VOLTAR.");
                  Console.ReadLine();
                  Console.Clear();
                }
                
              break;

              
            }
          }
          escolheuSair = false;
          
        break;

        case 2: // consultar preço, pedidos, etc...
                if(mesaselecionada<0){
                  Console.WriteLine("Deseja ver os pedidos de qual mesa? [0 a 10]: ");
                }else{
                  Console.Write($"Deseja ver os pedidos de qual mesa? [0 a 10] (MESA ATUAL: {mesaselecionada}):");
                }
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                if(opcao>=0 && opcao <=10){
                  troca = mesaselecionada; mesaselecionada = opcao; //troca 1;
                  MostrarProdutos(qtdProduto, mesaselecionada, nomeProduto, precoproduto);
                  mesaselecionada = troca; opcao = troca; // troca 2;
                }else{
                  Console.WriteLine("Essa opção não existe! Pressione ENTER para VOLTAR.");
                  Console.ReadLine();
                  Console.Clear();
                }
        break;
      }
    }
  }

  static int AdicionarQTD(int[,]qtdProduto, int mesaselecionada, int opcaoproduto, string[]nomeProduto, string confirmar, int[] precoproduto){
      Console.WriteLine($"Insira a quantidade de {nomeProduto[opcaoproduto]} que quer comprar: ");
        qtdProduto[mesaselecionada, opcaoproduto] = int.Parse(Console.ReadLine());
        if(qtdProduto[mesaselecionada, opcaoproduto]<0){ //verifica se o número é negativo, convertendo-o para positivo.
          qtdProduto[mesaselecionada, opcaoproduto] = Math.Abs(qtdProduto[mesaselecionada, opcaoproduto]);
        }
        Console.WriteLine($"Você tem certeza que deseja comprar {qtdProduto[mesaselecionada,opcaoproduto]} ({(qtdProduto[mesaselecionada,opcaoproduto]) * precoproduto[opcaoproduto]}R$) de {nomeProduto[opcaoproduto]}? [S/N]: ");
        confirmar = Console.ReadLine();                
        if(confirmar.ToUpper() == "S"){
          Console.WriteLine("Compra efetuada com sucesso! Pressione ENTER para CONTINUAR.");
          Console.ReadLine();
        }else{
          Console.WriteLine("Compra cancelada com sucesso! Pressione ENTER para CONTINUAR.");
          Console.ReadLine();
    }
    return qtdProduto[mesaselecionada,opcaoproduto];
  }

  static void MostrarProdutos(int[,] qtdProduto, int mesaselecionada, string[] nomeProduto, int[] precoproduto){
    int contaTotal = 0;
    Console.WriteLine($"======================\n PRODUTOS MESA {mesaselecionada}\n======================\n");
    for(int j = 0; j<=4; j++){
      if(qtdProduto[mesaselecionada,j]>0){
        Console.WriteLine($"{nomeProduto[j]} ({qtdProduto[mesaselecionada,j]}x) PREÇO: {precoproduto[j]*qtdProduto[mesaselecionada,j]}R$\n");
      }
    }

    for(int j = 0; j<=4; j++){
      contaTotal+= (qtdProduto[mesaselecionada,j] * precoproduto[j]);
    }
    if(contaTotal<=0){
      Console.WriteLine("Não há compras nesta mesa.\n");
    }else{
      Console.WriteLine($"CONTA TOTAL: {contaTotal}R$");
    }
    


    Console.WriteLine("Pressione ENTER para VOLTAR.");
    Console.ReadLine();
    Console.Clear();
  }

  static int RemoverProdutos (int[,] qtdProduto, string[] nomeProduto, int mesaselecionada, int[] precoproduto, int opcao){
    int quantidade = 0;
    string confirmar = "";
    Console.Clear();
    Console.WriteLine($"Insira quantas unidades de '{nomeProduto[opcao]}' serão removidas (atual {qtdProduto[mesaselecionada, opcao]}x): ");
    quantidade = int.Parse(Console.ReadLine());
    
    if(quantidade<0){
      quantidade = quantidade * -1; // passando de positivo para negativo
    }

    Console.WriteLine("Confirmar [S/N]: \n");
    confirmar = Console.ReadLine();
    if(confirmar.ToUpper() == "S"){
      qtdProduto[mesaselecionada,opcao]-= quantidade;
      if(qtdProduto[mesaselecionada, opcao]<0){ //zerando os produtos negativos
        qtdProduto[mesaselecionada, opcao] = 0;
      }
      Console.WriteLine("\nRemovido com sucesso! Pressione ENTER para CONTINUAR.");
      
    }else{
      Console.WriteLine("\nRemoção cancelada com sucesso! Pressione ENTER para CONTINUAR.");
    }
    Console.ReadLine();
    Console.Clear();
    
    return qtdProduto[mesaselecionada, opcao];

  }
}
