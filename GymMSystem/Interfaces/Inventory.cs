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
            Buisness_Logic.repairableItem_repository er = new Buisness_Logic.repairableItem_repository();
            dataGridINV1.DataSource = er.searchEqui_Items();
            this.dataGridINV1.Columns[5].Visible = false;


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
        private bool validateInvAdd()
        {
            bool make, qty, weight, price, model, name;
            bool weightLiftItem, all;
            Buisness_Logic.validation val = new Buisness_Logic.validation();

            //Inventory product price
            if (!val.isPrice(txtI1_iprice.Text))
            {
                this.errorProvider1.SetError(txtI1_iprice, "Price is invalid.");
                price = false;
            }
            else
            {
                this.errorProvider1.SetError(txtI1_iprice, (string)null);
                price = true;
            }

            //Inventory product name
            if (!val.IsWord(txtI1_iname.Text))
            {
                this.errorProvider1.SetError(txtI1_iname, "Name is invalid.");
                name = false;
            }
            else
            {
                this.errorProvider1.SetError(txtI1_iname, (string)null);
                name = true;
            }

            //model 
            if (!val.IsAlphaNumeric(txtI1_imodel.Text))
            {
                this.errorProvider1.SetError(txtI1_imodel, "Model is invalid.");
                model = false;
            }
            else
            {
                this.errorProvider1.SetError(txtI1_imodel, (string)null);
                model = true;
            }
            //make
            if (!val.IsAlphaNumeric(txtI1_imake.Text))
            {
                this.errorProvider1.SetError(txtI1_imake, "Make is invalid.");
                make = false;
            }
            else
            {
                this.errorProvider1.SetError(txtI1_imake, (string)null);
                make = true;
            }

            all = make == true && price == true && name == true && model == true;

            //weight liftin items or non repair items
            if (radio_nonRep.Checked)
            {
                //Inventory product quantity
                if (!val.IsNumeric(txtInv_1qty.Text))
                {
                    this.errorProvider1.SetError(txtInv_1qty, "Quantity is invalid.");
                    qty = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtInv_1qty, (string)null);
                    qty = true;
                }

                //Product weight
                if (!val.IsWeight(txtInv1Weight.Text))
                {
                    this.errorProvider1.SetError(txtInv1Weight, "Weight is invalid.");
                    weight = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtInv1Weight, (string)null);
                    weight = true;
                }
                weightLiftItem = weight == true && qty == true && all;

                if (weightLiftItem == true) return true;
                else return false;
                         
            }

            if (all == true) return true;
            else return false;




        }


        private void btnsave_Int1_Click(object sender, EventArgs e)
        {
            if (validateInvAdd())
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

        private void radio_nonRep_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtInv_1qty_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_i4_Click(object sender, EventArgs e)
        {

        }

        private bool validateNonRepItem_search()
        {
            Buisness_Logic.validation valp = new Buisness_Logic.validation();
            bool name, pid;

            if (string.IsNullOrWhiteSpace(txtwl_code.Text) && string.IsNullOrWhiteSpace(txtwl_name.Text))
            {
                MessageBox.Show("Please enter ItemID or Item name  to search inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                //Product name
                if (!valp.IsWord(txtwl_name.Text) && !string.IsNullOrWhiteSpace(txtwl_name.Text))
                {
                    this.errorProvider1.SetError(txtwl_name, "Item name is invalid.");
                    name = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtwl_name, (string)null);
                    name = true;

                }

                //Produt ID

                if (!valp.IsNumeric(txtwl_code.Text) && !string.IsNullOrWhiteSpace(txtwl_code.Text))
                {
                    this.errorProvider1.SetError(txtwl_code, "Item ID is invalid.");
                    pid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtwl_code, (string)null);
                    pid = true;
                }

                //return all

                bool condition = pid == true && name == true;

                if (condition) return true;
                else return false;

            }
        }
        private void btnWli_search_Click(object sender, EventArgs e)
        {
            if (validateNonRepItem_search())
            {

                Buisness_Logic.nonRepairable_Item prd = new Buisness_Logic.nonRepairable_Item();
                Buisness_Logic.nonRepairableItem_repository nrirep = new Buisness_Logic.nonRepairableItem_repository();


                bool x = nrirep.searchWL_Items((string.IsNullOrEmpty(txtwl_code.Text) ? 0 : int.Parse(txtwl_code.Text)), txtwl_name.Text.ToString(), prd);
                if (x)
                {
                    MessageBox.Show("Record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtwl_name.Text = prd.name;
                    txtwl_qty.Text = prd.qty.ToString();
                    txtwl_price.Text = prd.price.ToString();
                    txtwl_make.Text = prd.make.ToString();
                    txtwl_weight.Text = prd.weight.ToString();
                    txtwl_model.Text = prd.model;
                    txtwl_code.Text = prd.invID.ToString();

                    picboxWli.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream ms = new MemoryStream(prd.photo);

                    ms.Read(prd.photo, 0, prd.photo.Length);
                    picboxWli.Image = Image.FromStream(ms);
                }
                else
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private bool validateInvUpdate_weightLifting()
        {
            bool make, qty, weight, price, model, name;
            bool weightLiftItem;
            Buisness_Logic.validation val = new Buisness_Logic.validation();

            //Inventory product price
            if (!val.isPrice(txtwl_price.Text))
            {
                this.errorProvider1.SetError(txtwl_price, "Price is invalid.");
                price = false;
            }
            else
            {
                this.errorProvider1.SetError(txtwl_price, (string)null);
                price = true;
            }

            //Inventory product name
            if (!val.IsWord(txtwl_name.Text))
            {
                this.errorProvider1.SetError(txtwl_name, "Name is invalid.");
                name = false;
            }
            else
            {
                this.errorProvider1.SetError(txtwl_name, (string)null);
                name = true;
            }

            //model 
            if (!val.IsAlphaNumeric(txtwl_model.Text))
            {
                this.errorProvider1.SetError(txtwl_model, "Model is invalid.");
                model = false;
            }
            else
            {
                this.errorProvider1.SetError(txtwl_model, (string)null);
                model = true;
            }
            //make
            if (!val.IsAlphaNumeric(txtwl_make.Text))
            {
                this.errorProvider1.SetError(txtwl_make, "Make is invalid.");
                make = false;
            }
            else
            {
                this.errorProvider1.SetError(txtwl_make, (string)null);
                make = true;
            }

    

           //Inventory product quantity
                if (!val.IsNumeric(txtwl_qty.Text))
                {
                    this.errorProvider1.SetError(txtwl_qty, "Quantity is invalid.");
                    qty = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtwl_qty, (string)null);
                    qty = true;
                }

                //Product weight
                if (!val.IsWeight(txtwl_weight.Text))
                {
                    this.errorProvider1.SetError(txtwl_weight, "Weight is invalid.");
                    weight = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtwl_weight, (string)null);
                    weight = true;
                }
                weightLiftItem = weight == true && qty == true && make == true && price == true && name == true && model == true; ;

             

            

            if (weightLiftItem == true) return true;
            else return false;


        }

        private void btnwliUpdate_Click(object sender, EventArgs e)
        {

            if (validateInvUpdate_weightLifting())
            {
                Buisness_Logic.nonRepairableItem_repository nrirepo = new Buisness_Logic.nonRepairableItem_repository();
                Buisness_Logic.nonRepairable_Item prd = new Buisness_Logic.nonRepairable_Item();

                     int newq = (string.IsNullOrEmpty(txtwl_Newqty.Text) ? 0 : int.Parse(txtwl_Newqty.Text)) + int.Parse(txtwl_qty.Text);
                prd.name = txtwl_name.Text;
                prd.make = txtwl_make.Text;
                prd.model = txtwl_model.Text;
                prd.qty = newq;
                prd.price = double.Parse(txtwl_price.Text);
                prd.weight = double.Parse(txtwl_weight.Text);
                prd.invID = int.Parse(txtwl_code.Text);

                MemoryStream ms = new MemoryStream();
                picboxWli.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo_prod = ms.ToArray();
                prd.photo = photo_prod;

              

                if (nrirepo.updateWeightLiftingItems(prd))
                {
                    MessageBox.Show("Record update succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtwl_qty.Text = prd.qty.ToString();
                }
            }
        }

        private void btnwlidelete_Click(object sender, EventArgs e)
        {
            int pid;
            pid = int.Parse(txtwl_code.Text);

            Buisness_Logic.nonRepairableItem_repository pa = new Buisness_Logic.nonRepairableItem_repository();

            if (pa.deleteWLI(pid))
            {
                MessageBox.Show("Record delete succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Record deletion failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool validateRepItem_search()
        {
            Buisness_Logic.validation valp = new Buisness_Logic.validation();
            bool name, pid;

            if (string.IsNullOrWhiteSpace(txtEqui_code.Text) && string.IsNullOrWhiteSpace(txtEqui_name.Text))
            {
                MessageBox.Show("Please enter ItemID or Item name  to search inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                //Product name
                if (!valp.IsWord(txtEqui_name.Text) && !string.IsNullOrWhiteSpace(txtEqui_name.Text))
                {
                    this.errorProvider1.SetError(txtEqui_name, "Item name is invalid.");
                    name = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtEqui_name, (string)null);
                    name = true;

                }

                //Produt ID

                if (!valp.IsNumeric(txtEqui_code.Text) && !string.IsNullOrWhiteSpace(txtEqui_code.Text))
                {
                    this.errorProvider1.SetError(txtEqui_code, "Item ID is invalid.");
                    pid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtEqui_code, (string)null);
                    pid = true;
                }

                //return all

                bool condition = pid == true && name == true;

                if (condition) return true;
                else return false;

            }
        }
        private void btnEqui_search_Click(object sender, EventArgs e)
        {
            if (validateRepItem_search())
            {

                Buisness_Logic.repairablerable_Items prd = new Buisness_Logic.repairablerable_Items();
                Buisness_Logic.repairableItem_repository rirep = new Buisness_Logic.repairableItem_repository();


                bool x = rirep.searchEqui_Items((string.IsNullOrEmpty(txtEqui_code.Text) ? 0 : int.Parse(txtEqui_code.Text)), txtEqui_name.Text.ToString(), prd);
                if (x)
                {
                    MessageBox.Show("Record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEqui_name.Text = prd.name;
                    txtEqui_price.Text = prd.price.ToString();
                    txtEqui_make.Text = prd.make.ToString();
                    txtEqui_Model.Text = prd.model;
                    txtEqui_code.Text = prd.invID.ToString();

                    pictureBoxEqui.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream ms = new MemoryStream(prd.photo);

                    ms.Read(prd.photo, 0, prd.photo.Length);
                    pictureBoxEqui.Image = Image.FromStream(ms);
                }
                else
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool validateInvUpdate_Equipment()
        {
            bool make, price, model, name;
            bool equi;
            Buisness_Logic.validation val = new Buisness_Logic.validation();

            //Inventory product price
            if (!val.isPrice(txtEqui_price.Text))
            {
                this.errorProvider1.SetError(txtEqui_price, "Price is invalid.");
                price = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEqui_price, (string)null);
                price = true;
            }

            //Inventory product name
            if (!val.IsWord(txtEqui_name.Text))
            {
                this.errorProvider1.SetError(txtEqui_name, "Name is invalid.");
                name = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEqui_name, (string)null);
                name = true;
            }

            //model 
            if (!val.IsAlphaNumeric(txtEqui_Model.Text))
            {
                this.errorProvider1.SetError(txtEqui_Model, "Model is invalid.");
                model = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEqui_Model, (string)null);
                model = true;
            }
            //make
            if (!val.IsAlphaNumeric(txtEqui_make.Text))
            {
                this.errorProvider1.SetError(txtEqui_make, "Make is invalid.");
                make = false;
            }
            else
            {
                this.errorProvider1.SetError(txtEqui_make, (string)null);
                make = true;
            }



            equi =  make == true && price == true && name == true && model == true; ;





            if (equi == true) return true;
            else return false;


        }
        private void btnEqui_update_Click(object sender, EventArgs e)
        {
            if (validateInvUpdate_Equipment())
            {
                Buisness_Logic.repairableItem_repository rirepo = new Buisness_Logic.repairableItem_repository();
                Buisness_Logic.repairablerable_Items prd = new Buisness_Logic.repairablerable_Items();

             
                prd.name = txtEqui_name.Text;
                prd.make = txtEqui_make.Text;
                prd.model = txtEqui_Model.Text;         
                prd.price = double.Parse(txtEqui_price.Text);
                prd.invID = int.Parse(txtEqui_code.Text);

                MemoryStream ms = new MemoryStream();
                pictureBoxEqui.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo_prod = ms.ToArray();
                prd.photo = photo_prod;



                if (rirepo.update_Equipments(prd))
                {
                    MessageBox.Show("Record update succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
                }
            }
        }

        private void btnEqui_delete_Click(object sender, EventArgs e)
        {
            int pid;
            pid = int.Parse(txtEqui_code.Text);

            Buisness_Logic.repairableItem_repository pa = new Buisness_Logic.repairableItem_repository();

            if (pa.deleteEqui(pid))
            {
                MessageBox.Show("Record delete succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Record deletion failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRepairs_addfrom_Click(object sender, EventArgs e)
        {
           DialogResult conform =  MessageBox.Show("Are you sure you want add this item to repair?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(conform == DialogResult.Yes)
            {
                try
                {
                    Buisness_Logic.repair rep = new Buisness_Logic.repair();
                    rep.equipmentID = int.Parse(txtEqui_code.Text);
                    rep.equipmentName = txtEqui_name.Text;
                    rep.start_date = DateTime.Now.ToShortDateString();



                    if (rep.addToRepair(rep))
                    {
                        MessageBox.Show("Equipment is to be repaired.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                catch (Exception repex)
                {

                    throw;
                }

            }
            
        }

        private void btnsearch_i5_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.repair rep = new Buisness_Logic.repair();

                bool x = rep.searchRepairItem((string.IsNullOrEmpty(txtI1_irepair.Text) ? 0 : int.Parse(txtI1_irepair.Text)), (string.IsNullOrEmpty(txtI1_icod.Text) ? 0 : int.Parse(txtI1_icod.Text)), rep);
                if (x)
                {
                    MessageBox.Show("Record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtI1_imachine.Text = rep.equipmentName;
                    txtI1_irepair.Text = rep.repID.ToString();
                    txtI1_icod.Text = rep.equipmentID.ToString();
                    txtI1_istart.Text = rep.start_date;
                    txtI1_idescription.Text = rep.descriptioin;
                    txtI1_icost.Text = rep.cost.ToString();
                    txti_repfdate.Text = rep.finished_date;
                    cmbRepairINV.SelectedItem = rep.status;
                }
                else
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception sfsdf)
            {

                throw;
            }
        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {

        }

        private void txtI1_irepair_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_i6_Click(object sender, EventArgs e)
        {
            try
            {
                Buisness_Logic.repair rep = new Buisness_Logic.repair();

                double cost_for_repair = string.IsNullOrWhiteSpace(txtI1_icost.Text) ? 0 : double.Parse(txtI1_icost.Text);
                rep.repID = int.Parse(txtI1_irepair.Text);
                rep.equipmentID = int.Parse(txtI1_icod.Text);
                rep.status = cmbRepairINV.SelectedItem.ToString();
                rep.cost = cost_for_repair;
                rep.descriptioin = txtI1_idescription.Text;
                rep.start_date = txtI1_istart.Text;
                rep.finished_date = txti_repfdate.Text;
                rep.equipmentName = txtI1_imachine.Text;

                if (rep.updateRepItemDetails(rep))
                {
                    MessageBox.Show("Record update successfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Record update failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception sdfas)
            {

                throw;
            }
        }
    }
}
