namespace App30
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
            this.txtNomeProduto = new MaterialSkin.Controls.MaterialTextBox();
            this.txtValorProduto = new MaterialSkin.Controls.MaterialTextBox();
            this.btnEnviar = new MaterialSkin.Controls.MaterialButton();
            this.btnDeletar = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxNomes = new MaterialSkin.Controls.MaterialListBox();
            this.listBoxValor = new MaterialSkin.Controls.MaterialListBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.AnimateReadOnly = false;
            this.txtNomeProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNomeProduto.Depth = 0;
            this.txtNomeProduto.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNomeProduto.LeadingIcon = null;
            this.txtNomeProduto.Location = new System.Drawing.Point(271, 162);
            this.txtNomeProduto.MaxLength = 50;
            this.txtNomeProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNomeProduto.Multiline = false;
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(189, 50);
            this.txtNomeProduto.TabIndex = 0;
            this.txtNomeProduto.Text = "";
            this.txtNomeProduto.TrailingIcon = null;
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.AnimateReadOnly = false;
            this.txtValorProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValorProduto.Depth = 0;
            this.txtValorProduto.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtValorProduto.LeadingIcon = null;
            this.txtValorProduto.Location = new System.Drawing.Point(609, 162);
            this.txtValorProduto.MaxLength = 50;
            this.txtValorProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.txtValorProduto.Multiline = false;
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.Size = new System.Drawing.Size(189, 50);
            this.txtValorProduto.TabIndex = 0;
            this.txtValorProduto.Text = "";
            this.txtValorProduto.TrailingIcon = null;
            // 
            // btnEnviar
            // 
            this.btnEnviar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnviar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEnviar.Depth = 0;
            this.btnEnviar.HighEmphasis = true;
            this.btnEnviar.Icon = null;
            this.btnEnviar.Location = new System.Drawing.Point(866, 166);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEnviar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEnviar.Size = new System.Drawing.Size(73, 36);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEnviar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEnviar.UseAccentColor = false;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeletar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeletar.Depth = 0;
            this.btnDeletar.HighEmphasis = true;
            this.btnDeletar.Icon = null;
            this.btnDeletar.Location = new System.Drawing.Point(146, 568);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeletar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeletar.Size = new System.Drawing.Size(84, 36);
            this.btnDeletar.TabIndex = 1;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDeletar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeletar.UseAccentColor = false;
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(504, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(420, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 45);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vendas";
            // 
            // listBoxNomes
            // 
            this.listBoxNomes.BackColor = System.Drawing.Color.White;
            this.listBoxNomes.BorderColor = System.Drawing.Color.LightGray;
            this.listBoxNomes.Depth = 0;
            this.listBoxNomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBoxNomes.Location = new System.Drawing.Point(69, 290);
            this.listBoxNomes.MouseState = MaterialSkin.MouseState.HOVER;
            this.listBoxNomes.Name = "listBoxNomes";
            this.listBoxNomes.SelectedIndex = -1;
            this.listBoxNomes.SelectedItem = null;
            this.listBoxNomes.Size = new System.Drawing.Size(241, 256);
            this.listBoxNomes.TabIndex = 4;
            // 
            // listBoxValor
            // 
            this.listBoxValor.BackColor = System.Drawing.Color.White;
            this.listBoxValor.BorderColor = System.Drawing.Color.LightGray;
            this.listBoxValor.Depth = 0;
            this.listBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.listBoxValor.Location = new System.Drawing.Point(435, 290);
            this.listBoxValor.MouseState = MaterialSkin.MouseState.HOVER;
            this.listBoxValor.Name = "listBoxValor";
            this.listBoxValor.SelectedIndex = -1;
            this.listBoxValor.SelectedItem = null;
            this.listBoxValor.Size = new System.Drawing.Size(241, 256);
            this.listBoxValor.TabIndex = 4;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNome.Location = new System.Drawing.Point(435, 573);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 31);
            this.lblNome.TabIndex = 5;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValor.Location = new System.Drawing.Point(517, 573);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(0, 31);
            this.lblValor.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 638);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.listBoxValor);
            this.Controls.Add(this.listBoxNomes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtValorProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtNomeProduto;
        private MaterialSkin.Controls.MaterialTextBox txtValorProduto;
        private MaterialSkin.Controls.MaterialButton btnEnviar;
        private MaterialSkin.Controls.MaterialButton btnDeletar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialListBox listBoxNomes;
        private MaterialSkin.Controls.MaterialListBox listBoxValor;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblValor;
    }
}
