using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Example1
{
    /*
    class SnakeGame
    {
        public SnakeGame(){
            initAndReset();
        }
        Field myGameField; 
        Snake starvingSnake;
        Player mySelf;
        private Direction nextDirection;
        public void initAndReset(){
            myGameField = new Field();
            starvingSnake = new Snake();
            mySelf = new Player();
            //Generating all objects

            //Starting Sequence
            mySelf.PlayerName = "Tester";
            myGameField.inilializeField();
            starvingSnake.spawn(myGameField.Game_field, myGameField.Width, myGameField.Height);
            myGameField.generateFood(starvingSnake.FoodWasEaten);
            starvingSnake.TimeBetweenEachMovement = starvingSnake.TimeBetweenEachMovementAtTheStart;
        }
        public List<string> getUI(){
           return myGameField.showGameState(mySelf.PlayerName, starvingSnake.LenghtOfSnake, starvingSnake.TimeBetweenEachMovementAtTheStart);
        }

        private void run()
        {
            //Game Play
            while (!starvingSnake.SnakeIsDead && starvingSnake.LenghtOfSnake < (myGameField.Width-2)*(myGameField.Height-2))
            {
                mySelf.changeMovingDirection(nextDirection, starvingSnake);                        
                starvingSnake.move(myGameField.Game_field);
                myGameField.generateFood(starvingSnake.FoodWasEaten);
                myGameField.showGameState(mySelf.PlayerName, starvingSnake.LenghtOfSnake, starvingSnake.TimeBetweenEachMovement);
                Thread.Sleep(starvingSnake.TimeBetweenEachMovement);
            }
            myGameField.endState(starvingSnake.LenghtOfSnake);
        }
    }*/
}


/*TO DO
 * 
 * Console.ReadKey().Key soll immer nur einen Key speichern, nicht alle und hintereinander ausführen (-> blockiert sonst nächste Eingabe)  => relevant for close function and change direction of the snake
 *      => wurde umgangen aber nicht elegant...
 * maybe go through walls
 * speeding up of the snake should be antiproportional
 */


/*Comments
 * 
 * Mousclick can be used as pause function!!!
 * Check for snake.IsDead was implemented but was removed because it didn't seem neccassary/useful anymore. -> look for differences
 * overwriting the previous image is now possible without adding spaces and without correcting the cursor position, because only one task at a time is done.
 * foodExists was removed from Field, because I assigned the value in Snake and only used a get method for the Field class (the set method in Snake class didn't work)
 *      -> a similar porblem occures in Player.changeMovement, but here I just gave the method the hole class Snake => better Solutions?
 */
