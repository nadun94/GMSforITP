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
using System.IO;


namespace GymMSystem.Interfaces
{
    public partial class inventory : MetroForm
    {
        public inventory()
        {
            InitializeComponent();
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            if (radio_nonRep.Checked)
            {
                lblQty.Visible = true;
                lblWeight.Visible = true;
                lblWeight.Refresh();
                lblQty.Refresh();

            }
            else if (radio_repItems.Checked)
            {
                lblQty.Visible = false;
                lblWeight.Visible = false;
                lblWeight.Refresh();
                lblQty.Refresh();

            }
        }

        private void btnHome_inven_Click(object sender, EventArgs e)
        {
            Main invma = new Main();
            this.Hide();
            invma.Show();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Int1_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.inventory inv = new Buisness_Logic.inventory();




                if (radio_nonRep.Checked)
                {
                    Buisness_Logic.nonRepairable_Item nr = new Buisness_Logic.nonRepairable_Item();

                    //initialize image
                    MemoryStream memt1p1 = new MemoryStream();
                    pictureBox_i2.Image.Save(memt1p1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] photo_inv = memt1p1.ToArray();
                    nr.name = txtI1_iname.Text;
                    nr.make = txtI1_imake.Text;
                    nr.model = txtI1_imodel.Text;
                    nr.price = double.Parse(txtI1_iprice.Text);
                    nr.qty = int.Parse(txtInv_1qty.Text);
                    nr.weight = double.Parse(txtInv1Weight.Text);
                    nr.photo = photo_inv;

                    Buisness_Logic.nonRepairableItem_repository nrir = new Buisness_Logic.nonRepairableItem_repository();

                    if (nrir.addNonRepairabItems(nr))
                    {
                        MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtI1_icode.Text = nr.invID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else if (radio_repItems.Checked)
                {
                    Buisness_Logic.repairablerable_Items repi = new Buisness_Logic.repairablerable_Items();

                    MemoryStream memt1p1 = new MemoryStream();
                    pictureBox_i2.Image.Save(memt1p1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] photo_inv = memt1p1.ToArray();
                    repi.name = txtI1_iname.Text;
                    repi.make = txtI1_imake.Text;
                    repi.model = txtI1_imodel.Text;
                    repi.price = double.Parse(txtI1_iprice.Text);
                    repi.photo = photo_inv;

                    Buisness_Logic.repairableItem_repository repirep = new Buisness_Logic.repairableItem_repository();



                    if (repirep.addRepItems(repi))
                    {
                        MessageBox.Show("Success", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtI1_icode.Text = repi.invID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed.", "Data Insertion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }

                else
                {
                    MessageBox.Show("Select either Repair or non Repair button.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnclear_invt1_Click(object sender, EventArgs e)
        {
            txtI1_iname.Text = "";
            txtI1_icode.Text = "";
            txtI1_imake.Text = "";
            txtInv1Weight.Text = "";
            txtI1_imodel.Text = "";
            txtI1_iprice.Text = "";
            txtInv_1qty.Text = "";
            pictureBox_i2.Image = null;
        }

        private void btnBrowse_i1_Click(object sender, EventArgs e)
        {
            try
            {
                openfinv.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openfinv.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    pictureBox_i2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_i2.Image = Image.FromFile(openfinv.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radio_repItems_CheckedChanged(object sender, EventArgs e)
        {
            lblQty.Visible = false;
            lblWeight.Visible = false;
            txtInv1Weight.Visible = false;
            txtInv_1qty.Visible = false;
            txtInv1Weight.Refresh();
            txtInv_1qty.Refresh();
            lblWeight.Refresh();
            lblQty.Refresh();
        }

        private void radio_nonRep_CheckedChanged(object sender, EventArgs e)
        {
            lblQty.Visible = true;
            lblWeight.Visible = true;
            txtInv1Weight.Visible = true;
            txtInv_1qty.Visible = true;
            txtInv1Weight.Refresh();
            txtInv_1qty.Refresh();
            lblWeight.Refresh();
            lblQty.Refresh();
        }
    }
}
