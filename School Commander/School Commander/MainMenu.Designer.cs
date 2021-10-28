
namespace School_Commander
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUrediProfil = new FontAwesome.Sharp.IconButton();
            this.btnIzlaz = new FontAwesome.Sharp.IconButton();
            this.btnPomoc = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnIspisiSatnicu = new FontAwesome.Sharp.IconButton();
            this.btnUrediSatnicu = new FontAwesome.Sharp.IconButton();
            this.btnNoviProfil = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Marlett", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "SCHOOL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(690, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "COMMANDER";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUrediProfil);
            this.panel1.Controls.Add(this.btnIzlaz);
            this.panel1.Controls.Add(this.btnPomoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 220);
            this.panel1.TabIndex = 3;
            // 
            // btnUrediProfil
            // 
            this.btnUrediProfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(159)))), ((int)(((byte)(140)))));
            this.btnUrediProfil.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUrediProfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrediProfil.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrediProfil.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnUrediProfil.IconColor = System.Drawing.Color.Black;
            this.btnUrediProfil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUrediProfil.Location = new System.Drawing.Point(246, 0);
            this.btnUrediProfil.Name = "btnUrediProfil";
            this.btnUrediProfil.Size = new System.Drawing.Size(515, 220);
            this.btnUrediProfil.TabIndex = 3;
            this.btnUrediProfil.Text = "Uredi profil\r\n";
            this.btnUrediProfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUrediProfil.UseVisualStyleBackColor = false;
            this.btnUrediProfil.Click += new System.EventHandler(this.btnUrediProfil_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.btnIzlaz.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIzlaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzlaz.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzlaz.ForeColor = System.Drawing.Color.Black;
            this.btnIzlaz.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnIzlaz.IconColor = System.Drawing.Color.Black;
            this.btnIzlaz.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIzlaz.IconSize = 58;
            this.btnIzlaz.Location = new System.Drawing.Point(761, 0);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(247, 220);
            this.btnIzlaz.TabIndex = 1;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIzlaz.UseVisualStyleBackColor = false;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnPomoc
            // 
            this.btnPomoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(38)))));
            this.btnPomoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPomoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPomoc.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPomoc.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.btnPomoc.IconColor = System.Drawing.Color.Black;
            this.btnPomoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPomoc.Location = new System.Drawing.Point(0, 0);
            this.btnPomoc.Name = "btnPomoc";
            this.btnPomoc.Size = new System.Drawing.Size(246, 220);
            this.btnPomoc.TabIndex = 0;
            this.btnPomoc.Text = "Pomoć";
            this.btnPomoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPomoc.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnIspisiSatnicu);
            this.panel2.Controls.Add(this.btnUrediSatnicu);
            this.panel2.Controls.Add(this.btnNoviProfil);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 220);
            this.panel2.TabIndex = 4;
            // 
            // btnIspisiSatnicu
            // 
            this.btnIspisiSatnicu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(220)))), ((int)(((byte)(59)))));
            this.btnIspisiSatnicu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIspisiSatnicu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIspisiSatnicu.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIspisiSatnicu.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnIspisiSatnicu.IconColor = System.Drawing.Color.Black;
            this.btnIspisiSatnicu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIspisiSatnicu.Location = new System.Drawing.Point(728, 0);
            this.btnIspisiSatnicu.Name = "btnIspisiSatnicu";
            this.btnIspisiSatnicu.Size = new System.Drawing.Size(280, 220);
            this.btnIspisiSatnicu.TabIndex = 2;
            this.btnIspisiSatnicu.Text = "Ispiši satnicu";
            this.btnIspisiSatnicu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIspisiSatnicu.UseVisualStyleBackColor = false;
            this.btnIspisiSatnicu.Click += new System.EventHandler(this.btnIspisiSatnicu_Click);
            // 
            // btnUrediSatnicu
            // 
            this.btnUrediSatnicu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.btnUrediSatnicu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUrediSatnicu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrediSatnicu.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrediSatnicu.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnUrediSatnicu.IconColor = System.Drawing.Color.Black;
            this.btnUrediSatnicu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUrediSatnicu.Location = new System.Drawing.Point(280, 0);
            this.btnUrediSatnicu.Name = "btnUrediSatnicu";
            this.btnUrediSatnicu.Size = new System.Drawing.Size(448, 220);
            this.btnUrediSatnicu.TabIndex = 1;
            this.btnUrediSatnicu.Text = "Uredi satnicu";
            this.btnUrediSatnicu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUrediSatnicu.UseVisualStyleBackColor = false;
            this.btnUrediSatnicu.Click += new System.EventHandler(this.btnUrediSatnicu_Click);
            // 
            // btnNoviProfil
            // 
            this.btnNoviProfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(214)))), ((int)(((byte)(114)))));
            this.btnNoviProfil.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNoviProfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoviProfil.Font = new System.Drawing.Font("Marlett", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoviProfil.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnNoviProfil.IconColor = System.Drawing.Color.Black;
            this.btnNoviProfil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNoviProfil.Location = new System.Drawing.Point(0, 0);
            this.btnNoviProfil.Name = "btnNoviProfil";
            this.btnNoviProfil.Size = new System.Drawing.Size(280, 220);
            this.btnNoviProfil.TabIndex = 0;
            this.btnNoviProfil.Text = "Novi profil";
            this.btnNoviProfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNoviProfil.UseVisualStyleBackColor = false;
            this.btnNoviProfil.Click += new System.EventHandler(this.btnNoviProfil_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Commander";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnUrediProfil;
        private FontAwesome.Sharp.IconButton btnIzlaz;
        private FontAwesome.Sharp.IconButton btnPomoc;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnIspisiSatnicu;
        private FontAwesome.Sharp.IconButton btnUrediSatnicu;
        private FontAwesome.Sharp.IconButton btnNoviProfil;
    }
}

