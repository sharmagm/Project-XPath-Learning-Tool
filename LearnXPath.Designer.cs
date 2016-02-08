#region About
/*
 <fileinfo>
	<file name="LearnXPath.Designer.cs"></file>
	<namespace name="XMLAssignment1">
	<class name="LearnXPath">
	<revisions>
		<created date="10/15/2015" author="Garima Sharma">It defines all the controls and methods.</created>
		<changed date="" author=""></changed>
	</revisions>
	</class>
	</namespace>
 </fileinfo>
*/
#endregion About

namespace XMLAssignment1
{
    partial class LearnXPath
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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFileUpload = new System.Windows.Forms.TextBox();
            this.buttonUploadFile = new System.Windows.Forms.Button();
            this.textBoxFileContent = new System.Windows.Forms.TextBox();
            this.textBoxXPathResult = new System.Windows.Forms.TextBox();
            this.comboBoxXPath = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(758, 28);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(82, 26);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.BrowseFile);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // textBoxFileUpload
            // 
            this.textBoxFileUpload.Location = new System.Drawing.Point(45, 33);
            this.textBoxFileUpload.Name = "textBoxFileUpload";
            this.textBoxFileUpload.ReadOnly = true;
            this.textBoxFileUpload.Size = new System.Drawing.Size(694, 20);
            this.textBoxFileUpload.TabIndex = 1;
            // 
            // buttonUploadFile
            // 
            this.buttonUploadFile.Location = new System.Drawing.Point(385, 59);
            this.buttonUploadFile.Name = "buttonUploadFile";
            this.buttonUploadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonUploadFile.TabIndex = 2;
            this.buttonUploadFile.Text = "Upload File";
            this.buttonUploadFile.UseVisualStyleBackColor = true;
            this.buttonUploadFile.Click += new System.EventHandler(this.ReadXMLGenerateXPath);
            // 
            // textBoxFileContent
            // 
            this.textBoxFileContent.Location = new System.Drawing.Point(45, 88);
            this.textBoxFileContent.Multiline = true;
            this.textBoxFileContent.Name = "textBoxFileContent";
            this.textBoxFileContent.ReadOnly = true;
            this.textBoxFileContent.Size = new System.Drawing.Size(366, 277);
            this.textBoxFileContent.TabIndex = 3;
            this.textBoxFileContent.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxXPathResult
            // 
            this.textBoxXPathResult.Location = new System.Drawing.Point(417, 115);
            this.textBoxXPathResult.Multiline = true;
            this.textBoxXPathResult.Name = "textBoxXPathResult";
            this.textBoxXPathResult.ReadOnly = true;
            this.textBoxXPathResult.Size = new System.Drawing.Size(322, 250);
            this.textBoxXPathResult.TabIndex = 5;
            this.textBoxXPathResult.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // comboBoxXPath
            // 
            this.comboBoxXPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxXPath.FormattingEnabled = true;
            this.comboBoxXPath.Location = new System.Drawing.Point(417, 88);
            this.comboBoxXPath.Name = "comboBoxXPath";
            this.comboBoxXPath.Size = new System.Drawing.Size(322, 21);
            this.comboBoxXPath.TabIndex = 7;
            this.comboBoxXPath.SelectedIndexChanged += new System.EventHandler(this.DisplayXNodeForSelectedXPath);
            // 
            // LearnXPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 392);
            this.Controls.Add(this.comboBoxXPath);
            this.Controls.Add(this.textBoxXPathResult);
            this.Controls.Add(this.textBoxFileContent);
            this.Controls.Add(this.buttonUploadFile);
            this.Controls.Add(this.textBoxFileUpload);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "LearnXPath";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxFileUpload;
        private System.Windows.Forms.Button buttonUploadFile;
        private System.Windows.Forms.TextBox textBoxFileContent;
        private System.Windows.Forms.TextBox textBoxXPathResult;
        private System.Windows.Forms.ComboBox comboBoxXPath;
    }
}

