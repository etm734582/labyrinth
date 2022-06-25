using System;
using System.IO;

namespace project{

    class Program{

        static void Main(){
            string player = "Ж";
            string freeplace = " ";
            string obstacle = "█";
            string finish = "O";
            string gamemode = "menu";

            System.Console.WriteLine("Добро пожаловать в игру. В этой игре вам предстоит проходить лабиринты. Управляется персонаж с помощью отправления в консоль букв wasd, буквы должны быть строчные");
            System.Console.WriteLine("Для того чтобы узнать команды, напишите info");

            while (true){
                if(gamemode == "menu"){
                   

                    while(true){
                        string input = Console.ReadLine();
                        if(input=="quit"){
                            Environment.Exit(0);
                        }
                        else if(input=="info"){
                            System.Console.WriteLine("Команды:\n info - посмотреть команды\n quit - ввыйти из игры\n level1 - перейти на первый уровень");
                        }
                        else if(input=="level1"){
                            gamemode = "level1";
                            break;
                        }
                    }
                }

                if(gamemode == "level1"){
                    string[,] map = {
                        {"█","█","█","█","█","█","█","█","█","█","█","E","█","█","█","█","█","█","█","█","█","█","█","█","█"},
                        {"█","█","F","█","█","█","█","█","█","█","█","F","█","█","█","█","█","█","F","█","█","█","█","█","█"},
                        {"█","F","F","F","F","F","F","F","F","F","█","F","F","F","F","F","F","█","F","█","█","F","F","F","█"},
                        {"█","F","█","█","█","█","█","█","█","█","█","█","█","█","█","█","F","█","F","F","F","F","█","F","█"},
                        {"█","F","F","F","F","F","F","F","F","F","█","█","F","F","F","█","F","█","█","█","█","█","█","F","█"},
                        {"█","█","█","█","█","█","█","█","█","F","█","█","F","█","F","█","F","F","F","F","F","█","F","F","█"},
                        {"█","F","F","F","F","F","F","F","F","F","█","█","F","█","F","█","█","█","█","█","F","█","█","F","█"},
                        {"█","F","█","█","█","█","█","█","█","F","F","F","F","█","F","F","F","F","F","█","F","F","█","F","█"},
                        {"█","F","█","F","█","F","F","F","█","F","█","F","█","█","█","█","█","█","F","█","F","F","█","F","█"},
                        {"█","F","█","F","█","F","F","F","█","F","█","F","F","F","F","F","F","F","F","F","F","F","█","F","█"},
                        {"█","F","█","F","█","█","█","F","█","F","█","█","█","█","█","█","█","█","F","█","█","█","█","F","█"},
                        {"█","F","█","F","F","F","█","█","█","F","█","█","█","█","█","█","█","█","F","F","F","F","F","F","█"},
                        {"█","F","█","F","█","F","█","F","F","F","F","F","F","F","F","F","F","█","F","█","█","█","█","F","█"},
                        {"█","F","█","F","█","█","█","█","█","█","█","█","█","█","█","█","F","█","█","█","█","█","█","F","█"},
                        {"█","F","█","F","F","F","F","F","F","█","F","F","F","█","F","█","F","█","F","F","F","█","█","█","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","F","█","F","█","F","█","F","█","F","F","F","F","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","F","█","F","█","F","█","F","█","F","█","█","F","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","F","█","F","F","F","█","F","█","F","█","█","F","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","F","█","F","█","█","█","F","F","F","█","█","F","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","F","█","F","█","█","█","F","█","F","█","█","F","█"},
                        {"█","F","█","█","█","█","F","█","F","█","F","█","█","█","F","█","█","█","f","█","█","█","█","F","█"},
                        {"█","F","█","█","█","█","F","█","F","F","F","F","F","F","F","F","F","F","F","F","F","F","F","F","█"},
                        {"█","F","F","F","F","F","F","█","█","█","█","█","F","█","F","█","█","█","█","█","█","█","█","█","█"},
                        {"█","█","█","█","█","█","█","█","F","F","F","█","█","█","█","█","F","F","F","F","F","F","F","F","F"}
                    }; 
                    int playerx = 12;
                    int playery = 22;
                    int mapsizex = 24;


                    while(true){
                        MapRender(map, freeplace, obstacle, finish, player, playerx, playery, mapsizex);

                        if(map[playery, playerx] == "E"){
                            System.Console.WriteLine("Вы прошли уровень");
                            gamemode = "menu";
                            break;
                        }

                        string input = Console.ReadLine();

                        int[] pos = Movement(map, input, playerx, playery);
                        playerx = pos[0];
                        playery = pos[1];

                        if(input=="quit"){
                            Environment.Exit(0);
                        }
                        else if(input=="menu"){
                            gamemode = "menu";
                            break;
                        }
                        else if(input=="info"){
                            System.Console.WriteLine("Команды:\n info - посмотреть команды\n quit - ввыйти из игры\nmenu - перейти в меню\n w - идти вперёд\n a - идти влево\n s - идти назад\n d - идти вправо");
                        }

                    }
                }
            }
        }

        public static void MapRender(string[,] map, string freeplace, string obstacle, string finish, string player, int playerx, int playery, int mapsizex){
            int xpos = 0;
            int ypos = 0;
            string str = "";

            System.Console.WriteLine("======================");
            foreach(string i in map){
                if(ypos == playery & xpos == playerx){
                    str+=player;
                } 
                else if(i == "F"){
                    str+=freeplace;
                }
                else if(i == "█"){
                    str+=obstacle;
                }
                else if(i == "E"){
                    str+=finish;
                }
                
                xpos+=1;
                if(xpos>mapsizex){
                    System.Console.WriteLine(str);
                    str = "";
                    xpos = 0;
                    ypos+=1;
                }
            }
            System.Console.WriteLine("======================");
        } 
        public static int[] Movement(string[,] map, string input, int playerx, int playery){
            if(input=="w"){
            if(map[playery-1, playerx] == "F" || map[playery-1, playerx] == "E"){
                    playery-=1;
                }
            }
            else if(input=="s"){
                if(map[playery+1, playerx] == "F" || map[playery+1, playerx] == "E"){
                    playery+=1;
                }
            }
            else if(input=="a"){
                if(map[playery, playerx-1] == "F" || map[playery, playerx-1] == "E"){
                    playerx-=1;
                }
            }
            else if(input=="d"){
                if(map[playery, playerx+1] == "F" || map[playery, playerx+1] == "E"){
                    playerx+=1;
                }
            }
            int[] r = {playerx, playery};

            return r;
        }
    }
}