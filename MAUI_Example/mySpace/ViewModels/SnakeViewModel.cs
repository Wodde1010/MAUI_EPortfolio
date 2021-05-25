using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Threading.Tasks;
using System.Threading;

namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SnakeModel : BaseModel
	{
		public SnakeModel(){
			Start = new Command(startGame);
			Pause = new Command(pauseGame);
			GoRight = new Command(changeDirectionToRight);//could be done with a single command and parameters - but much more work without real debugging
			GoLeft = new Command(changeDirectionToLeft);
			GoUp = new Command(changeDirectionToUp);
			GoDown = new Command(changeDirectionToDown);
			initAndReset();
		}

		public Command Start{ get ; private set;}
		public Command Pause{ get ; private set;}
		public Command GoRight{ get ; private set;}
		public Command GoLeft{ get ; private set;}
		public Command GoUp{ get ; private set;}
		public Command GoDown{ get ; private set;}
		public List<string> UILines {get {return myGameField.showGameState(mySelf.PlayerName, starvingSnake.LenghtOfSnake, starvingSnake.TimeBetweenEachMovement);} }
		public string FieldBackgroundColor {get {return "Black";}}
		public string FieldTextColor {get {return "Yellow";}}
		public Direction NextDirection {get {return starvingSnake.nextDirection;}}
		private bool shouldRun = false;
		private bool gameIsStillRunning = false;
		public bool startBtnVisible{ get {return !shouldRun;}}
		public bool stopBtnVisible{ get {return shouldRun;}}
		public bool YouDied { get {return starvingSnake.SnakeIsDead; }}
		public string Banner {get; private set;}

		private void updateGUI(){
			OnPropertyChanged(nameof(UILines));
			OnPropertyChanged(nameof(NextDirection));
			OnPropertyChanged(nameof(startBtnVisible));
			OnPropertyChanged(nameof(stopBtnVisible));
			OnPropertyChanged(nameof(YouDied));
			OnPropertyChanged(nameof(Banner));
		}
		private void startGame(object sender){
			if(YouDied)
				initAndReset();
			shouldRun = true;
			updateGUI();
			runGameAsync();
		}
		private void pauseGame(object sender){
			shouldRun = false;
			while(gameIsStillRunning)
				Thread.Sleep(10);
			updateGUI();
		}
        Field myGameField; 
        Snake starvingSnake;
        Player mySelf;
        public void initAndReset(){
            myGameField = new Field();
            starvingSnake = new Snake();
            mySelf = new Player();
            //Generating all objects

            //Starting Sequence
			Banner = "                                   ";
            mySelf.PlayerName = "Tester";
            myGameField.inilializeField();
			starvingSnake.nextDirection = Direction.Right;
            starvingSnake.spawn(myGameField.Game_field, myGameField.Width, myGameField.Height);
            starvingSnake.TimeBetweenEachMovement = starvingSnake.TimeBetweenEachMovementAtTheStart;
            myGameField.generateFood(starvingSnake.FoodWasEaten);
        }

		public async void runGameAsync(){
			if(gameIsStillRunning)//blocks more execution threads
				return;
			Task.Run(()=>{
				gameIsStillRunning = true;
				while(shouldRun && !starvingSnake.SnakeIsDead && starvingSnake.LenghtOfSnake < (myGameField.Width-2)*(myGameField.Height-2))
				{
					runGameStep();
					if(YouDied)
					{
						shouldRun = false;
						Banner = myGameField.endState(starvingSnake.LenghtOfSnake);			
						updateGUI();
						break;//don't wait for the sleep when the player died...
					}
					updateGUI();
					Thread.Sleep(starvingSnake.TimeBetweenEachMovement);
				}
				gameIsStillRunning = false;	
			});
		}

		public void runGameStep(){
			starvingSnake.updateMovingDirection();
			starvingSnake.move(myGameField.Game_field);
			myGameField.generateFood(starvingSnake.FoodWasEaten);
		}
		private void changeDirectionToRight(){
			mySelf.changeMovingDirection(Direction.Right, starvingSnake);
		}
		private void changeDirectionToLeft(){
			mySelf.changeMovingDirection(Direction.Left, starvingSnake);
		}
		private void changeDirectionToUp(){
			mySelf.changeMovingDirection(Direction.Up, starvingSnake);
		}
		private void changeDirectionToDown(){
			mySelf.changeMovingDirection(Direction.Down, starvingSnake);
		}
	}
}
