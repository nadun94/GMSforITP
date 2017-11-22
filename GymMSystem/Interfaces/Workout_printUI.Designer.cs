namespace GymMSystem.Interfaces
{
    partial class Workout_printUI
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
            this.crpt_workout = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crpt_workout
            // 
            this.crpt_workout.ActiveViewIndex = -1;
            this.crpt_workout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpt_workout.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpt_workout.Location = new System.Drawing.Point(63, 46);
            this.crpt_workout.Name = "crpt_workout";
            this.crpt_workout.Size = new System.Drawing.Size(1090, 611);
            this.crpt_workout.TabIndex = 3;
            this.crpt_workout.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Workout_printUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 712);
            this.Controls.Add(this.crpt_workout);
            this.Name = "Workout_printUI";
            this.Load += new System.EventHandler(this.Workout_printUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpt_workout;
    }
}