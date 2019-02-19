namespace CSharpToStreamBase
{
    partial class PocForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this._textBox = new System.Windows.Forms.TextBox();
            this._expression = new System.Windows.Forms.TextBox();
            this._name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(12, 179);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(586, 493);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.OnPictureClick);
            // 
            // _textBox
            // 
            this._textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox.Location = new System.Drawing.Point(12, 12);
            this._textBox.Multiline = true;
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(586, 161);
            this._textBox.TabIndex = 0;
            this._textBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _expression
            // 
            this._expression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._expression.BackColor = System.Drawing.Color.White;
            this._expression.Font = new System.Drawing.Font("Consolas", 9.75F);
            this._expression.Location = new System.Drawing.Point(109, 345);
            this._expression.Multiline = true;
            this._expression.Name = "_expression";
            this._expression.ReadOnly = true;
            this._expression.Size = new System.Drawing.Size(473, 138);
            this._expression.TabIndex = 1;
            this._expression.Click += new System.EventHandler(this.OnClick);
            // 
            // _name
            // 
            this._name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._name.AutoSize = true;
            this._name.BackColor = System.Drawing.Color.White;
            this._name.Font = new System.Drawing.Font("Consolas", 9.75F);
            this._name.Location = new System.Drawing.Point(106, 313);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(0, 15);
            this._name.TabIndex = 3;
            this._name.Click += new System.EventHandler(this.OnClick);
            // 
            // PocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 681);
            this.Controls.Add(this._name);
            this.Controls.Add(this._expression);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "PocForm";
            this.Text = "c# to StreamBase Expression Language";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.TextBox _expression;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

