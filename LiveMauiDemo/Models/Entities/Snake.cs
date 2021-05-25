using System;
using System.Collections.Generic;
using System.Timers;

namespace LiveMauiDemo
{
    class Snake
    {
        private int currentXDirection = +1;
        private int currentYDirection = +0;
        private bool snakeIsDead = false;
        private int lenghtOfSnake = 0;
        private const int timeBetweenEachMovementAtTheStart = 800;
        private const int speedUpFactor = 20;
        private int timeBetweenEachMovement = 200;
        private List<int> bodyInX = new List<int>();
        private List<int> bodyInY = new List<int>();
        private const char signForTheBodyOfTheSnake = '0';
        private bool foodWasEaten = true;
        public Direction nextDirection;
        public bool FoodWasEaten
        {
            get { return foodWasEaten; }
        }
        public int LenghtOfSnake
        {
            get { return lenghtOfSnake; }
        }
        public bool SnakeIsDead
        {
            get { return snakeIsDead; }
        }
        public int XDirection
        {
            get { return currentXDirection; }
            set { currentXDirection = value; }
        }
        public int YDirection
        {
            get { return currentYDirection; }
            set { currentYDirection = value; }
        }
        public int TimeBetweenEachMovement
        {
            get { return timeBetweenEachMovement; }
            set { timeBetweenEachMovement = value; }
        }
        public int TimeBetweenEachMovementAtTheStart
        {
            get { return timeBetweenEachMovementAtTheStart; }
        }
        public void spawn(char[,] myArray, int xCoordiante, int yCoordinate)
        {
            bodyInX.Insert(0, xCoordiante / 2 + 1);
            bodyInY.Insert(0, yCoordinate / 2);
            bodyInX.Add(xCoordiante / 2);
            bodyInY.Add(yCoordinate / 2);
            lenghtOfSnake = 2;

            for (int i = 0; i < bodyInX.Count && i < bodyInY.Count; i++)
            {
                myArray[bodyInY[i], bodyInX[i]] = signForTheBodyOfTheSnake;
            }
        }

        public void move(char[,] template)
        {
            foodWasEaten = false;
            //Das Ende der Schlange soll gelöscht werden. Der Kopf soll zum Teil des Körpers werden und an diesen ehemals vordersten Block soll der neue Kopf angesetzt werden.
            //Um eine Bewegung des gesamten Körpers zu gewährleisten ist eine Liste notwendig, in der die Positionen/ Indizies dauernd verändert werden können und die Reihenfolge trotzdem erhalten bleibt.

            int newXValue = bodyInX[0] + currentXDirection;
            bodyInX.Insert(0, newXValue);
            int newYValue = bodyInY[0] + currentYDirection;
            bodyInY.Insert(0, newYValue);
            char signWhereTheNewPartWillSpawn = template[bodyInY[0], bodyInX[0]];
            if (signWhereTheNewPartWillSpawn != signForTheBodyOfTheSnake && signWhereTheNewPartWillSpawn != Field.signForTheFrame)
            {
                //Füge neuen Block in das Template ein
                //evtl.: Lösche alten Block aus dem Template
                template[bodyInY[0], bodyInX[0]] = signForTheBodyOfTheSnake;
                if (signWhereTheNewPartWillSpawn != Field.signForFood)
                {
                    template[bodyInY[bodyInY.Count - 1], bodyInX[bodyInX.Count - 1]] = Field.signForSpace;
                    bodyInX.RemoveAt(bodyInX.Count - 1);
                    bodyInY.RemoveAt(bodyInY.Count - 1);
                }
                else
                {
                    foodWasEaten = true;
                    ++lenghtOfSnake;
                    timeBetweenEachMovement = timeBetweenEachMovementAtTheStart - speedUpFactor * lenghtOfSnake;
                }
            }
            else
            {
                snakeIsDead = true;
            }
        }
        public void updateMovingDirection()
        {            
            //The Snake should be unable to turn 180 degrees. Therefor we have to check whether this direction was chosen or not.
            if (nextDirection == Direction.Down && XDirection != 0 && YDirection != -1)
            {
                XDirection = 0;
                YDirection = +1;
                //snake turns down
            }
            else if (nextDirection == Direction.Up && XDirection != 0 && YDirection != +1)
            {
                XDirection = 0;
                YDirection = -1;
                //snake turns up
            }
            else if (nextDirection == Direction.Left && XDirection != +1 && YDirection != 0) 
            {
                XDirection = -1;
                YDirection = 0;
                //snake turns left
            }
            else if (nextDirection == Direction.Right && XDirection != -1 && YDirection != 0)
            {
                XDirection = +1;
                YDirection = 0;
                //snake turns right
            }
        }
    }
}