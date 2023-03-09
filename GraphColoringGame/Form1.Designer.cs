namespace GraphColoringGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vertexButton1 = new GraphColoringGame.Graphics.VertexButton();
            this.vertexButton2 = new GraphColoringGame.Graphics.VertexButton();
            this.SuspendLayout();
            // 
            // vertexButton1
            // 
            this.vertexButton1.BackColor = System.Drawing.SystemColors.Highlight;
            this.vertexButton1.Location = new System.Drawing.Point(217, 86);
            this.vertexButton1.Name = "vertexButton1";
            this.vertexButton1.Size = new System.Drawing.Size(50, 50);
            this.vertexButton1.TabIndex = 0;
            this.vertexButton1.UseVisualStyleBackColor = false;
            this.vertexButton1.Click += new System.EventHandler(this.vertexButton1_Click);
            // 
            // vertexButton2
            // 
            this.vertexButton2.Location = new System.Drawing.Point(398, 86);
            this.vertexButton2.Name = "vertexButton2";
            this.vertexButton2.Size = new System.Drawing.Size(75, 56);
            this.vertexButton2.TabIndex = 1;
            this.vertexButton2.Text = "vertexButton2";
            this.vertexButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vertexButton2);
            this.Controls.Add(this.vertexButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Graphics.VertexButton vertexButton1;
        private Graphics.VertexButton vertexButton2;
    }
}

