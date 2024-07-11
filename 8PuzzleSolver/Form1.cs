using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing; 

namespace _Failed8PuzzleSolver;

public partial class Form1 : Form
{

    Puzzle<int> Puzzle1 = new Puzzle<int>(3); 

    Random random = new Random(6);

    bool didWin = false;
   

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Puzzle1.tiles[i, j] = new Vertex<int>(j * 3 + i + 1, false);
                if (j * 3 + i + 1 == 9)
                {
                    Puzzle1.tiles[i, j].isBlank = true;
                    Puzzle1.tiles[i, j].button.Text = "";
                }
            }
        }
        Puzzle1.Shuffle(1000);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Puzzle1.tiles[i, j].button.Location = new Point(i * 200, j * 200);
                Puzzle1.tiles[i, j].button.Click += Button_Click;
                Controls.Add(Puzzle1.tiles[i, j].button);
            }
        }
    }


    private void Button_Click(object sender, EventArgs e)
    {
        Button temp = (Button)sender;
        if (int.TryParse(temp.Text, out int buttonClicked))
        {
            List<Point> adjacent = Puzzle1.findAdjacent();

            Point tempTile = Puzzle1.findTile(buttonClicked);

            if (adjacent.Contains(new Point(tempTile.X, tempTile.Y)))
            {

                Vertex<int> temporary = Puzzle1.tiles[tempTile.X, tempTile.Y];
                Point blankCell = Puzzle1.GetBlankCell();
                Vertex<int> currentBlank = Puzzle1.tiles[blankCell.X, blankCell.Y];
                Puzzle1.tiles[blankCell.X, blankCell.Y] = temporary;
                Puzzle1.tiles[tempTile.X, tempTile.Y] = currentBlank;
                temporary.setPosition(blankCell);
                currentBlank.setPosition(tempTile);
            }
            temp = null;
        }
        bool isValid = true;
        for (int i = 0; i < 3 && isValid; i++)
        {
            for (int j = 0; j < 3 && isValid; j++)
            {
                if (int.TryParse(Puzzle1.tiles[i, j].button.Text, out int currentButton))
                {
                    if (currentButton != j * 3 + i + 1)
                    {
                        isValid = false;
                    }
                }
            }
        }
        didWin = isValid;
        if (didWin)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Puzzle1.tiles[i, j].button.Visible = false;
                }
            }
            MessageBox.Show("You WIN!");
        }
    }
}

