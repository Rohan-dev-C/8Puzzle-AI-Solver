namespace Real8PuzzleSolver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            ShuffleButton = new Button();
            SolveButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(26, 12);
            button1.Name = "button1";
            button1.Size = new Size(130, 131);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(162, 12);
            button2.Name = "button2";
            button2.Size = new Size(130, 131);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(298, 12);
            button3.Name = "button3";
            button3.Size = new Size(130, 131);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(26, 149);
            button4.Name = "button4";
            button4.Size = new Size(130, 131);
            button4.TabIndex = 2;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(162, 149);
            button5.Name = "button5";
            button5.Size = new Size(130, 131);
            button5.TabIndex = 5;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(298, 149);
            button6.Name = "button6";
            button6.Size = new Size(130, 131);
            button6.TabIndex = 4;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(26, 286);
            button7.Name = "button7";
            button7.Size = new Size(130, 131);
            button7.TabIndex = 8;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(162, 286);
            button8.Name = "button8";
            button8.Size = new Size(130, 131);
            button8.TabIndex = 7;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(298, 286);
            button9.Name = "button9";
            button9.Size = new Size(130, 131);
            button9.TabIndex = 6;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            // 
            // ShuffleButton
            // 
            ShuffleButton.Location = new Point(26, 423);
            ShuffleButton.Name = "ShuffleButton";
            ShuffleButton.Size = new Size(186, 53);
            ShuffleButton.TabIndex = 9;
            ShuffleButton.Text = "Shuffle";
            ShuffleButton.UseVisualStyleBackColor = true;
            ShuffleButton.Click += ShuffleButton_Click;
            // 
            // SolveButton
            // 
            SolveButton.Location = new Point(233, 423);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new Size(195, 53);
            SolveButton.TabIndex = 10;
            SolveButton.Text = "Solve";
            SolveButton.UseVisualStyleBackColor = true;
            SolveButton.Click += SolveButton_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 562);
            Controls.Add(SolveButton);
            Controls.Add(ShuffleButton);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button ShuffleButton;
        private Button SolveButton;
        private System.Windows.Forms.Timer timer1;
    }
}
