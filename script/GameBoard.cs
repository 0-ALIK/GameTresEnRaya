using System;
using System.Collections.Generic;
using System.Text;

namespace xCeroGame
{
    class GameBoard
    {
        //Párametros de clase
        private const int FILL = 5;
        private const int COLUM = 5;
        private char[,] Board = new char[FILL, COLUM] {
            {' ','║',' ','║',' '},
            {'═','╬','═','╬','═'},
            {' ','║',' ','║',' '},
            {'═','╬','═','╬','═'},
            {' ','║',' ','║',' '}
        };

        //Método para comprobar vistoria en alguna fila
        public bool checkVictoryFill(char Xor0)
        {
            bool victoryHaz = false;
            byte victoryCont = 0;

            for (int i = 0; i < FILL; i += 2)
            {
                victoryCont = 0;

                for(int j = 0; j < COLUM; j += 2)
                {
                    if (Board[i,j] == Xor0)
                    {
                        victoryCont++;
                    }
                }

                if(victoryCont == 3)
                {
                    victoryHaz = true;
                    break;
                }
            }
                
            return victoryHaz;

        }

        //Método para comprobar victoria en alguna columna
        public bool checkVictoryColum (char Xor0)
        {

            bool victoryHaz = false;
            byte victoryCont = 0;

            for (int i = 0; i < COLUM; i += 2)
            {
                victoryCont = 0;

                for (int j = 0; j < FILL; j += 2)
                {
                    if (Board[j, i] == Xor0)
                    {
                        victoryCont++;
                    }
                }

                if (victoryCont == 3)
                {
                    victoryHaz = true;
                    break;
                }
            }

            return victoryHaz;
        }

        //Método para comprobar victoria cruzada
        public bool checkVictoryCross(char Xor0)
        {
            bool victoryHaz = false;

            if(Board[0,0] == Xor0 && Board[2, 2] == Xor0 && Board[4, 4] == Xor0)
            {
                victoryHaz = true;
            }
            else if (Board[0, 4] == Xor0 && Board[2, 2] == Xor0 && Board[4, 0] == Xor0)
            {
                victoryHaz = true;
            }

            return victoryHaz;
        }

        //Método para añadir movimiento
        public void setMove()
        {
            bool correcto = false;
            while (correcto == false)
            {
                byte move = byte.Parse(Console.ReadLine());
                switch (move)
                {
                    case 1:
                        if (Board[0, 0] != '0' && Board[0,0] != 'X')
                        {
                            Board[0, 0] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 2:
                        if (Board[0, 2] != '0' && Board[0, 2] != 'X')
                        {
                            Board[0, 2] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 3:
                        if (Board[0, 4] != '0' && Board[0, 4] != 'X')
                        {
                            Board[0, 4] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 4:
                        if (Board[2, 0] != '0' && Board[2, 0] != 'X')
                        {
                            Board[2, 0] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 5:
                        if (Board[2, 2] != '0' && Board[2, 2] != 'X')
                        {
                            Board[2, 2] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 6:
                        if (Board[2, 4] != '0' && Board[2, 4] != 'X')
                        {
                            Board[2, 4] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 7:
                        if (Board[4, 0] != '0' && Board[4, 0] != 'X')
                        {
                            Board[4, 0] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    case 8:
                        if (Board[4, 2] != '0' && Board[4, 2] != 'X')
                        {
                            Board[4, 2] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }
              
                    case 9:
                        if (Board[4, 4] != '0' && Board[4, 4] != 'X')
                        {
                            Board[4, 4] = 'X';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("el oponente uso ese o ya usaste ese");
                            break;
                        }

                    default:
                        Console.WriteLine("posición incorrecta");
                        break;
                }
            }
        }

        //Método para imprimir el tablero
        public void printBoard()
        {
            char[] mostrar = new char[5];

            for(int i=0; i<FILL; i++)
            {
                for(int j=0; j<COLUM; j++)
                {
                    mostrar[j] = Board[i, j];
                }
                Console.WriteLine($"{mostrar[0]}{mostrar[1]}{mostrar[2]}{mostrar[3]}{mostrar[4]}");
            }
        }



        //====== METODOS PARA EL OPONENTE =============//

        //Método para movimiento del oponente
        public void setMoveOponent()
        {
            int movimiento;
            Random ran = new Random();
            bool correcto = false;
            while (correcto == false)
            {
                movimiento = ran.Next(1,9);
                switch (movimiento)
                {
                    case 1:
                        if (Board[0, 0] != 'X' && Board[0, 0] != '0')
                        {
                            Board[0, 0] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 2:
                        if (Board[0, 2] != 'X' && Board[0, 2] != '0')
                        {
                            Board[0, 2] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 3:
                        if (Board[0, 4] != 'X' && Board[0, 4] != '0')
                        {
                            Board[0, 4] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 4:
                        if (Board[2, 0] != 'X' && Board[2, 0] != '0')
                        {
                            Board[2, 0] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 5:
                        if (Board[2, 2] != 'X' && Board[2, 2] != '0')
                        {
                            Board[2, 2] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 6:
                        if (Board[2, 4] != 'X' && Board[2, 4] != '0')
                        {
                            Board[2, 4] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 7:
                        if (Board[4, 0] != 'X' && Board[4, 0] != '0')
                        {
                            Board[4, 0] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 8:
                        if (Board[4, 2] != 'X' && Board[4, 2] != '0')
                        {
                            Board[4, 2] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 9:
                        if (Board[4, 4] != 'X' && Board[4, 4] != '0')
                        {
                            Board[4, 4] = '0';
                            correcto = true;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    default:
                        Console.WriteLine("posición incorrecta");
                        break;
                }
            }
        }
    }
}
