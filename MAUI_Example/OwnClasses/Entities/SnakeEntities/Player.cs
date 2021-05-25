using System;

namespace Example1
{
    class Player : BaseModel
    {
        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set {
                if(value!=null && value != "")
                    playerName = value;
                else
                    playerName = "Mister Nobody";
            }
        }
        public void changeMovingDirection(Direction direction, Snake snake)
        {  
            snake.nextDirection = direction;
        }
    }
}
