namespace WindowFormsDemo
{
    partial class MainForm
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
            this.createTaskControl1 = new WindowFormsDemo.CreateTaskControl();
            this.taskListControl1 = new WindowFormsDemo.TaskListControl();
            this.SuspendLayout();
            // 
            // createTaskControl1
            // 
            this.createTaskControl1.Location = new System.Drawing.Point(13, 13);
            this.createTaskControl1.Name = "createTaskControl1";
            this.createTaskControl1.Size = new System.Drawing.Size(289, 161);
            this.createTaskControl1.TabIndex = 0;
            this.createTaskControl1.TaskCreated += new System.EventHandler(this.onTaskCreated);
            // 
            // taskListControl1
            // 
            this.taskListControl1.Location = new System.Drawing.Point(13, 190);
            this.taskListControl1.Name = "taskListControl1";
            this.taskListControl1.Size = new System.Drawing.Size(75, 23);
            this.taskListControl1.TabIndex = 1;
            this.taskListControl1.Text = "taskListControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 657);
            this.Controls.Add(this.taskListControl1);
            this.Controls.Add(this.createTaskControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private CreateTaskControl createTaskControl1;
        private TaskListControl taskListControl1;
    }
}

