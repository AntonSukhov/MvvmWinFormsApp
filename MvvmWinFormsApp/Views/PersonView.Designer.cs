namespace MvvmWinFormsApp.Views
{
    partial class PersonView
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
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.lblPersonId = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.lblPersoneAge = new System.Windows.Forms.Label();
            this.nudPersonId = new System.Windows.Forms.NumericUpDown();
            this.nudPersonAge = new System.Windows.Forms.NumericUpDown();
            this.tbxPersonName = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonAge)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 2;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRoot.Controls.Add(this.lblPersonId, 0, 0);
            this.tlpRoot.Controls.Add(this.lblPersonName, 0, 1);
            this.tlpRoot.Controls.Add(this.lblPersoneAge, 0, 2);
            this.tlpRoot.Controls.Add(this.nudPersonId, 1, 0);
            this.tlpRoot.Controls.Add(this.nudPersonAge, 1, 2);
            this.tlpRoot.Controls.Add(this.tbxPersonName, 1, 1);
            this.tlpRoot.Controls.Add(this.flpButtons, 1, 3);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 4;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRoot.Size = new System.Drawing.Size(397, 155);
            this.tlpRoot.TabIndex = 0;
            // 
            // lblPersonId
            // 
            this.lblPersonId.AutoSize = true;
            this.lblPersonId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonId.Location = new System.Drawing.Point(3, 0);
            this.lblPersonId.Name = "lblPersonId";
            this.lblPersonId.Size = new System.Drawing.Size(94, 25);
            this.lblPersonId.TabIndex = 0;
            this.lblPersonId.Text = "ИД:";
            this.lblPersonId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonName.Location = new System.Drawing.Point(3, 25);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(94, 25);
            this.lblPersonName.TabIndex = 2;
            this.lblPersonName.Text = "Имя:";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPersoneAge
            // 
            this.lblPersoneAge.AutoSize = true;
            this.lblPersoneAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersoneAge.Location = new System.Drawing.Point(3, 50);
            this.lblPersoneAge.Name = "lblPersoneAge";
            this.lblPersoneAge.Size = new System.Drawing.Size(94, 25);
            this.lblPersoneAge.TabIndex = 4;
            this.lblPersoneAge.Text = "Возраст:";
            this.lblPersoneAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPersonId
            // 
            this.nudPersonId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudPersonId.Location = new System.Drawing.Point(103, 3);
            this.nudPersonId.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudPersonId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersonId.Name = "nudPersonId";
            this.nudPersonId.Size = new System.Drawing.Size(291, 20);
            this.nudPersonId.TabIndex = 1;
            this.nudPersonId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPersonAge
            // 
            this.nudPersonAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudPersonAge.Location = new System.Drawing.Point(103, 53);
            this.nudPersonAge.Name = "nudPersonAge";
            this.nudPersonAge.Size = new System.Drawing.Size(291, 20);
            this.nudPersonAge.TabIndex = 5;
            // 
            // tbxPersonName
            // 
            this.tbxPersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPersonName.Location = new System.Drawing.Point(103, 28);
            this.tbxPersonName.Name = "tbxPersonName";
            this.tbxPersonName.Size = new System.Drawing.Size(291, 20);
            this.tbxPersonName.TabIndex = 3;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.Location = new System.Drawing.Point(103, 78);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpButtons.Size = new System.Drawing.Size(291, 100);
            this.flpButtons.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(213, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 155);
            this.Controls.Add(this.tlpRoot);
            this.Name = "PersonView";
            this.Text = "PersonView";
            this.tlpRoot.ResumeLayout(false);
            this.tlpRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonAge)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.Label lblPersonId;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblPersoneAge;
        private System.Windows.Forms.NumericUpDown nudPersonId;
        private System.Windows.Forms.NumericUpDown nudPersonAge;
        private System.Windows.Forms.TextBox tbxPersonName;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}