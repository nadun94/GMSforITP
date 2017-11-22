using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace GymMSystem.Interfaces
{
    public partial class Workout_printUI : MetroForm
    {
        DataTable workout;
        DataTable exercise;
        DataTable member;
        public Workout_printUI(DataTable w,DataTable ex,DataTable memb)
        {
            InitializeComponent();
            workout = w;
            exercise = ex;
            member = memb;
        }

        private void Workout_printUI_Load(object sender, EventArgs e)
        {
            Reports.Crystal_Reports.crstl_workout ct = new Reports.Crystal_Reports.crstl_workout();
            ct.Database.Tables["member"].SetDataSource(member);
            crpt_workout.ReportSource = null;
            crpt_workout.ReportSource = ct;



        }
    }
}
