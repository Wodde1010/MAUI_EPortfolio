using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.ObjectModel;

namespace LiveMauiDemo
{
    class Field : BaseModel
    {
        private Random picker = new Random();
        private const int width = 20;
        private const int height = 10;
        private char[,] game_field = new char[height, width];
        
        public const char signForTheFrame = '#';
        public const char signForFood = 'x';
        public const char signForSpace = '+';
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public char[,] Game_field { get { return game_field; } }



        private void generateFrameOfField()
        {
            for (int i = 0; i < width; i++)
            {
                game_field[0, i] = signForTheFrame;
                game_field[(height - 1), i] = signForTheFrame;
            }
            for (int i = 0; i < height; i++)
            {
                game_field[i, 0] = signForTheFrame;
                game_field[i, (width - 1)] = signForTheFrame;
            }
        }

        public void inilializeField()
        {
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    game_field[i, j] = signForSpace;
                }
            }
            generateFrameOfField();
        }

        public List<string> showGameState(string playerName, int snakeLenght, int caTimePerCycle)
        {
            List<string> state = new List<string>();
            state.Add("Hi " + playerName + ". Welcome to Snake!");
            string lenght = "";
            if(snakeLenght/100 <= 0)
                lenght += "0";
            if(snakeLenght/10 <= 0)
                lenght += "0";
            lenght += snakeLenght;
            state.Add("Snake Lenght: " + lenght);
            for (int i = 0; i < height; i++)
            {
                string currentLine = " ";
                for (int j = 0; j < width; j++)
                {
                    currentLine += game_field[i, j];
                }
                currentLine += " ";
                state.Add(currentLine);
            }
            return state;
        }


        public void generateFood(bool theFoodWasPreviouslyEaten)
        {
            /*
             * Es soll eine Liste generiert werden, die alle freien Felder enthält (welche aus dem Spielfeld ausgelesen wurde).
             * Von dieser Liste soll ein zufälliger Index ausgewählt werden. Das Feld, welches an diesem Index hintelegt ist soll das Futter enthalten.
             */
            if (theFoodWasPreviouslyEaten)
            {
                List<int> chosenFieldXCoordinate = new List<int>();
                List<int> chosenFieldYCoordinate = new List<int>();

                for (int a = 0; a < height; a++)
                {
                    for (int b = 0; b < width; b++)
                    {
                        if (game_field[a, b] == signForSpace)
                        {
                            chosenFieldYCoordinate.Add(a);
                            chosenFieldXCoordinate.Add(b);
                        }
                    }
                }
                int foodIndex = picker.Next(0, chosenFieldXCoordinate.Count);
                int foodYCoordinate = chosenFieldYCoordinate[foodIndex];
                int foodXCoordinate = chosenFieldXCoordinate[foodIndex];
                game_field[foodYCoordinate, foodXCoordinate] = signForFood;
            }
        }

        public string endState(int lenght)
        {
            int maxlenght = (width-2)*(height-2);
            if (lenght >= maxlenght)
            {
                return ("You win!");
            }
            else if (lenght>=100)
            {
                return ("You lost!\nBetter luck next time...");
            }
            else
            {
                return ("You lost!");
            }
        }
    }
}
