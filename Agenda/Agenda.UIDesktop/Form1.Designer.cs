namespace Agenda.UIDesktop
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
            lblNomeNovo = new Label();
            txtNomeNovo = new TextBox();
            lblNomeSalvo = new Label();
            txtNomeSalvo = new TextBox();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // lblNomeNovo
            // 
            lblNomeNovo.AutoSize = true;
            lblNomeNovo.Location = new Point(11, 7);
            lblNomeNovo.Name = "lblNomeNovo";
            lblNomeNovo.Size = new Size(82, 15);
            lblNomeNovo.TabIndex = 0;
            lblNomeNovo.Text = "Novo Contato";
            // 
            // txtNomeNovo
            // 
            txtNomeNovo.Location = new Point(11, 25);
            txtNomeNovo.Name = "txtNomeNovo";
            txtNomeNovo.Size = new Size(351, 23);
            txtNomeNovo.TabIndex = 1;
            // 
            // lblNomeSalvo
            // 
            lblNomeSalvo.AutoSize = true;
            lblNomeSalvo.Location = new Point(11, 51);
            lblNomeSalvo.Name = "lblNomeSalvo";
            lblNomeSalvo.Size = new Size(71, 15);
            lblNomeSalvo.TabIndex = 2;
            lblNomeSalvo.Text = "Nome Salvo";
            // 
            // txtNomeSalvo
            // 
            txtNomeSalvo.Location = new Point(11, 69);
            txtNomeSalvo.Name = "txtNomeSalvo";
            txtNomeSalvo.Size = new Size(348, 23);
            txtNomeSalvo.TabIndex = 3;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(287, 98);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvar);
            Controls.Add(txtNomeSalvo);
            Controls.Add(lblNomeSalvo);
            Controls.Add(txtNomeNovo);
            Controls.Add(lblNomeNovo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeNovo;
        private TextBox txtNomeNovo;
        private Label lblNomeSalvo;
        private TextBox txtNomeSalvo;
        private Button btnSalvar;
    }
}
