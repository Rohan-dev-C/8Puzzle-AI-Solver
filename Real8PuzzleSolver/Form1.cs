using System;
using System.Runtime.CompilerServices;

namespace Real8PuzzleSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Puzzle<int> puzzle = new Puzzle<int>();
        Button[,] button = new Button[3, 3];
        int[,] FinalGameStateArray =
            { {1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 0 } };
        int[,] currentGameStateArray;
        GameState currentGameState;
        GameState FinalGameState;

        void UpdateScreen()
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    button[i, j].Text = currentGameState.currentState[i, j].ToString();
                }
            }
            
        }

        (int, int) GetBlankCell(GameState gameState)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameState.currentState[i, j] == 0)
                    {
                        return (i,j);
                    }
                }
            }

            return (-1, -1);
        }


        List<(int, int)> findAdjacent(GameState gameState)
        {
            List<(int, int)> adjacent = new List<(int, int)>(0);

            (int, int) blankCellPosition = GetBlankCell(gameState);
            int i = blankCellPosition.Item1;
            int j = blankCellPosition.Item2;

            if (IsInBounds(i, j - 1))
            {
                adjacent.Add((i, j - 1));
            }
            if (IsInBounds(i, j + 1))
            {
                adjacent.Add((i, j + 1));
            }
            if (IsInBounds(i - 1, j))
            {
                adjacent.Add((i - 1, j));
            }
            if (IsInBounds(i + 1, j))
            {
                adjacent.Add((i + 1, j));
            }
            return adjacent;
        }

        bool IsInBounds(int i, int j)
        {
            return i < 3 && j < 3 && i > -1 && j > -1;
        }
        Random random = new Random(69); 

        public void ShuffleTiles(GameState initialGameState, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                List<(int, int)> possibleSwitches = findAdjacent(initialGameState);
                int randomSwitch = random.Next(possibleSwitches.Count);

                (int, int) piont = GetBlankCell(initialGameState);
                (int, int) randomTile = possibleSwitches[randomSwitch];

                int temp = initialGameState.currentState[randomTile.Item1, randomTile.Item2];
                initialGameState.currentState[randomTile.Item1, randomTile.Item2] = initialGameState.currentState[piont.Item1, piont.Item2];
                initialGameState.currentState[piont.Item1, piont.Item2] = temp;
            }
        }

        public void ShowPath(List<GameState> path)
        {
            currentGameState.currentState = path[0].currentState;
            UpdateScreen();
            path.Remove(path[0]); 
        }
        List<GameState> path = new List<GameState>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            button[0, 0] = button1;
            button[0, 1] = button2;
            button[0, 2] = button3;
            button[1, 0] = button4;
            button[1, 1] = button5;
            button[1, 2] = button6;
            button[2, 0] = button7;
            button[2, 1] = button8;
            button[2, 2] = button9;
            currentGameStateArray = FinalGameStateArray;
            currentGameState = new GameState(currentGameStateArray);
            FinalGameState = new GameState(FinalGameStateArray);
            UpdateScreen(); 
        }
        bool finishedSearching = false;
        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            ShuffleTiles(currentGameState, 1000);
            UpdateScreen(); 
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            path = puzzle.BestFirstSearch(currentGameState,FinalGameState, puzzle.AStarSelection, UpdateScreen, timer1);
            finishedSearching = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (finishedSearching)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    ShowPath(path); 
                }
                timer1.Enabled = false; 
            }

        }
    }
}
