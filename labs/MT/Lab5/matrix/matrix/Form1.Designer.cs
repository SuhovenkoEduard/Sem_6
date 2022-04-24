namespace lab5
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbGrammar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLeftSymbolsSet = new System.Windows.Forms.TextBox();
            this.tbRightSymbolsSet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bBuildPrecendenceMatrix = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrecendenceMatrix = new System.Windows.Forms.TextBox();
            this.lResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходная грамматика:";
            // 
            // tbGrammar
            // 
            this.tbGrammar.BackColor = System.Drawing.Color.Gold;
            this.tbGrammar.Location = new System.Drawing.Point(608, 44);
            this.tbGrammar.Multiline = true;
            this.tbGrammar.Name = "tbGrammar";
            this.tbGrammar.ReadOnly = true;
            this.tbGrammar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGrammar.Size = new System.Drawing.Size(231, 538);
            this.tbGrammar.TabIndex = 1;
            this.tbGrammar.Text = "S→B\r\nB→W\r\nB→B-W\r\nW→X\r\nX→Z\r\nX→X^Z\r\nZ→N\r\nZ→(C\r\nC→B)\r\nN→L\r\nN→NL\r\nL→a\r\nL→b\r\nL→c\r\nL→d\r" +
    "\nL→e\r\nL→f\r\nL→g\r\nL→h\r\nL→i\r\nL→j\r\nL→k\r\nL→l\r\nL→m\r\nL→n\r\nL→o\r\nL→p\r\nL→q\r\nL→r\r\nL→s\r\nL→t\r" +
    "\nL→u\r\nL→v\r\nL→w\r\nL→x\r\nL→y\r\nL→z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Множество левых символов:";
            // 
            // tbLeftSymbolsSet
            // 
            this.tbLeftSymbolsSet.BackColor = System.Drawing.Color.Gold;
            this.tbLeftSymbolsSet.Location = new System.Drawing.Point(2, 41);
            this.tbLeftSymbolsSet.Multiline = true;
            this.tbLeftSymbolsSet.Name = "tbLeftSymbolsSet";
            this.tbLeftSymbolsSet.ReadOnly = true;
            this.tbLeftSymbolsSet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLeftSymbolsSet.Size = new System.Drawing.Size(600, 251);
            this.tbLeftSymbolsSet.TabIndex = 3;
            // 
            // tbRightSymbolsSet
            // 
            this.tbRightSymbolsSet.BackColor = System.Drawing.Color.Gold;
            this.tbRightSymbolsSet.Location = new System.Drawing.Point(2, 328);
            this.tbRightSymbolsSet.Multiline = true;
            this.tbRightSymbolsSet.Name = "tbRightSymbolsSet";
            this.tbRightSymbolsSet.ReadOnly = true;
            this.tbRightSymbolsSet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRightSymbolsSet.Size = new System.Drawing.Size(600, 251);
            this.tbRightSymbolsSet.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Множество правых символов:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 596);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Результат:";
            // 
            // bBuildPrecendenceMatrix
            // 
            this.bBuildPrecendenceMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bBuildPrecendenceMatrix.BackColor = System.Drawing.Color.SeaGreen;
            this.bBuildPrecendenceMatrix.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bBuildPrecendenceMatrix.Location = new System.Drawing.Point(2, 582);
            this.bBuildPrecendenceMatrix.Name = "bBuildPrecendenceMatrix";
            this.bBuildPrecendenceMatrix.Size = new System.Drawing.Size(419, 58);
            this.bBuildPrecendenceMatrix.TabIndex = 8;
            this.bBuildPrecendenceMatrix.Text = "Построить матрицу предшествования";
            this.bBuildPrecendenceMatrix.UseVisualStyleBackColor = false;
            this.bBuildPrecendenceMatrix.Click += new System.EventHandler(this.bBuildPrecendenceMatrix_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(855, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "Матрица предшествования:";
            // 
            // tbPrecendenceMatrix
            // 
            this.tbPrecendenceMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrecendenceMatrix.BackColor = System.Drawing.Color.Gold;
            this.tbPrecendenceMatrix.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPrecendenceMatrix.Location = new System.Drawing.Point(855, 42);
            this.tbPrecendenceMatrix.Multiline = true;
            this.tbPrecendenceMatrix.Name = "tbPrecendenceMatrix";
            this.tbPrecendenceMatrix.ReadOnly = true;
            this.tbPrecendenceMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPrecendenceMatrix.Size = new System.Drawing.Size(681, 540);
            this.tbPrecendenceMatrix.TabIndex = 9;
            this.tbPrecendenceMatrix.WordWrap = false;
            // 
            // lResult
            // 
            this.lResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lResult.AutoSize = true;
            this.lResult.Location = new System.Drawing.Point(366, 651);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(0, 30);
            this.lResult.TabIndex = 7;
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1548, 690);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.tbPrecendenceMatrix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bBuildPrecendenceMatrix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRightSymbolsSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLeftSymbolsSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGrammar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Методы трансляции. Лабораторная работа №5 Вариант 12 Суховенко Эдуард";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbGrammar;
        private Label label2;
        private TextBox tbLeftSymbolsSet;
        private TextBox tbRightSymbolsSet;
        private Label label3;
        private Label label4;
        private Button bBuildPrecendenceMatrix;
        private Label label5;
        private TextBox tbPrecendenceMatrix;
        private Label lResult;
    }
}