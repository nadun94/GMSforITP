﻿using System;
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
    public partial class salesManagement : MetroForm
    {
        public salesManagement()
        {
            InitializeComponent();
        }

        // product list for add to cart
        List<Buisness_Logic.product> prdList = new List<Buisness_Logic.product>();
       
        private void salesManagement_Load(object sender, EventArgs e)
        {
            Buisness_Logic.productRepository prep = new Buisness_Logic.productRepository();
            dataGridPriducts.DataSource = prep.searchProducts_for_dataGrid();
            this.dataGridPriducts.Columns[7].Visible = false;
            
        }

       
        private void btnHome_SalesMgt_Click(object sender, EventArgs e)
        {
            Main smmain = new Main();
            this.Hide();
            smmain.Show();

        }
        private bool validateProduct()
        {
            Buisness_Logic.validation valp = new Buisness_Logic.validation();
            bool  name, make, type, qty, bprice, sprice;

            //Product name
            if (!valp.IsWord(txtAddp_name.Text))
            {
                this.errorProvider1.SetError(txtAddp_name, "Product name is invalid.");
                name= false;

            }
            else
            {
                this.errorProvider1.SetError(txtAddp_name, (string)null);
                name = true;

            }

            //Product make

            if (!valp.IsWord(txtAddp_make.Text))
            {
                this.errorProvider1.SetError(txtAddp_make, "Product make is invalid.");
                make = false;
            }
            else
            {
                this.errorProvider1.SetError(txtAddp_make, (string)null);
                make = true;
            }

            //Product type

            if (cmb_addproduct_type.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmb_addproduct_type, "Product type is not selected.");
                type = false;
            }
            else
            {
                this.errorProvider1.SetError(cmb_addproduct_type, (string)null);
                type = true;
            }

            //Quantity

            if (!valp.IsNumeric(txtadd_qty.Text))
            {
                this.errorProvider1.SetError(txtadd_qty, "Product quantity is invalid.");
                qty = false;
            }
            else
            {
                this.errorProvider1.SetError(txtadd_qty, (string)null);
                qty = true;
            }

            //Buying price
            if (!valp.isPrice(txtAddp_bprice.Text))
            {
                this.errorProvider1.SetError(txtAddp_bprice, "Product buying price is invalid.");
                bprice = false;
            }
            else
            {
                this.errorProvider1.SetError(txtAddp_bprice, (string)null);
                bprice = true;
            }

            //Selling price
            if (!valp.isPrice(txtAddp_sell_price.Text))
            {
                this.errorProvider1.SetError(txtAddp_sell_price, "Product selling price is invalid.");
                sprice = false;
            }
            else
            {
                this.errorProvider1.SetError(txtAddp_sell_price, (string)null);
                sprice = true;
            }


            //maing returning point

            bool condition = name == true && bprice == true && sprice == true && qty == true && type == true && make == true;

            if (condition) return true;
            else return false;


        }

        private void mtrtil1splmnt_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateProduct())
                {
                    Buisness_Logic.product prd = new Buisness_Logic.product();


                    prd.name = txtAddp_name.Text;
                    prd.qty = int.Parse(txtadd_qty.Text);
                    prd.make = txtAddp_make.Text;
                    prd.buying_price = double.Parse(txtAddp_bprice.Text);
                    prd.selling_Price = double.Parse(txtAddp_sell_price.Text);
                    prd.productType = cmb_addproduct_type.SelectedItem.ToString();


                    MemoryStream ms = new MemoryStream();
                    picBox1_addproduct.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = ms.ToArray();
                    prd.photo = pic;

                    Buisness_Logic.productRepository prorep = new Buisness_Logic.productRepository();

                    if (prorep.save_Product(prd))
                    {
                        txtAddp_ID.Text = prd.productID.ToString();
                        MessageBox.Show("Poduct saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



            }
            catch (Exception expropd)
            {
                MessageBox.Show(expropd.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        private void mtrtil2splmnt_clear_Click(object sender, EventArgs e)
        {
            txtAddp_ID.Text = "";
            txtAddp_make.Text = "";
            txtAddp_name.Text = "";
            txtAddp_bprice.Text = "";
            txtAddp_sell_price.Text = "";
            txtadd_qty.Text = "";
            cmb_addproduct_type.SelectedItem = null;
            picBox1_addproduct.Image = null;
        }

        private void mtrtil3splmnt_brows_Click(object sender, EventArgs e)
        {
            try
            {
                openfileprod1.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openfileprod1.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    picBox1_addproduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox1_addproduct.Image = Image.FromFile(openfileprod1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private bool validateProduct_search()
        {
            Buisness_Logic.validation valp = new Buisness_Logic.validation();
            bool name, pid;

            if (string.IsNullOrWhiteSpace(txtp2_prodID.Text) && string.IsNullOrWhiteSpace(txtp2name.Text))
            {
                MessageBox.Show("Please enter ProductID or product name  to search products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                //Product name
                if (!valp.IsWord(txtp2name.Text) && !string.IsNullOrWhiteSpace(txtp2name.Text))
                {
                    this.errorProvider1.SetError(txtp2name, "Product name is invalid.");
                    name = false;

                }
                else
                {
                    this.errorProvider1.SetError(txtp2name, (string)null);
                    name = true;

                }

                //Produt ID

                if (!valp.IsNumeric(txtp2_prodID.Text) && !string.IsNullOrWhiteSpace(txtp2_prodID.Text))
                {
                    this.errorProvider1.SetError(txtp2_prodID, "Product ID is invalid.");
                    pid = false;
                }
                else
                {
                    this.errorProvider1.SetError(txtp2_prodID, (string)null);
                    pid = true;
                }

                //return all

                bool condition = pid == true && name == true;

                if (condition) return true;
                else return false;

            }
            }
        private void btnprod_search_Click(object sender, EventArgs e)
        {

            if (validateProduct_search())
            {
                Buisness_Logic.product prd = new Buisness_Logic.product();
                Buisness_Logic.productRepository prp = new Buisness_Logic.productRepository();
              
              
                bool x = prp.searchProduct((string.IsNullOrEmpty(txtp2_prodID.Text) ? 0 : int.Parse(txtp2_prodID.Text)), txtp2name.Text.ToString(),prd);
                if (x)
                {
                    MessageBox.Show("Record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtp2name.Text = prd.name;
                    txtp2_availableqty.Text = prd.qty.ToString();
                    txtp2_bprice.Text = prd.buying_price.ToString();
                    txtp2_make.Text = prd.make.ToString();
                    txtp2_sellingprice.Text = prd.selling_Price.ToString();
                    cmbp2ProdType.SelectedItem = prd.productType;
                    txtp2_prodID.Text = prd.productID.ToString();

                    picbox_editProd.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream ms = new MemoryStream(prd.photo);

                    ms.Read(prd.photo, 0, prd.photo.Length);
                    picbox_editProd.Image = Image.FromStream(ms);
                }
                else
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }
        }

        private void btnEditprod_browse_Click(object sender, EventArgs e)
        {
            try
            {
                openfileprod1.Filter = "Image files | *.jpg; *.PNG; *.gif; *.BMP";
                DialogResult drMem1 = openfileprod1.ShowDialog();

                if (drMem1 == DialogResult.OK)
                {
                    picbox_editProd.SizeMode = PictureBoxSizeMode.StretchImage;
                    picbox_editProd.Image = Image.FromFile(openfileprod1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool validateUpdateProducts()
        {
            Buisness_Logic.validation valp = new Buisness_Logic.validation();
            bool name, make, type, qty,nqty, bprice, sprice;

            //Product name
            if (!valp.IsWord(txtp2name.Text))
            {
                this.errorProvider1.SetError(txtp2name, "Product name is invalid.");
                name = false;

            }
            else
            {
                this.errorProvider1.SetError(txtp2name, (string)null);
                name = true;

            }

            //Product make

            if (!valp.IsWord(txtp2_make.Text))
            {
                this.errorProvider1.SetError(txtp2_make, "Product make is invalid.");
                make = false;
            }
            else
            {
                this.errorProvider1.SetError(txtp2_make, (string)null);
                make = true;
            }

            //Product type

            if (cmbp2ProdType.SelectedIndex.Equals(-1))
            {
                this.errorProvider1.SetError(cmbp2ProdType, "Product type is not selected.");
                type = false;
            }
            else
            {
                this.errorProvider1.SetError(cmbp2ProdType, (string)null);
                type = true;
            }

            //Quantity

            if (!valp.IsNumeric(txtp2_availableqty.Text))
            {
                this.errorProvider1.SetError(txtp2_availableqty, "Product quantity is invalid.");
                qty = false;
            }
            else
            {
                this.errorProvider1.SetError(txtp2_availableqty, (string)null);
                qty = true;
            }

            //updated qty after adding to the stock

            if (!valp.IsNumeric(txtp2Newqty.Text) && !string.IsNullOrWhiteSpace(txtp2Newqty.Text))
            {
                this.errorProvider1.SetError(txtp2Newqty, "Product quantity is invalid.");
                nqty = false;
            }
            else
            {
                this.errorProvider1.SetError(txtp2Newqty, (string)null);
                nqty = true;
            }
            //Buying price
            if (!valp.isPrice(txtp2_bprice.Text))
            {
                this.errorProvider1.SetError(txtp2_bprice, "Product buying price is invalid.");
                bprice = false;
            }
            else
            {
                this.errorProvider1.SetError(txtp2_bprice, (string)null);
                bprice = true;
            }

            //Selling price
            if (!valp.isPrice(txtp2_sellingprice.Text))
            {
                this.errorProvider1.SetError(txtp2_sellingprice, "Product selling price is invalid.");
                sprice = false;
            }
            else
            {
                this.errorProvider1.SetError(txtp2_sellingprice, (string)null);
                sprice = true;
            }


            //maing returning point

            bool condition = name == true && bprice == true && sprice == true && qty == true && type == true && make == true && nqty==true;

            if (condition) return true;
            else return false;


        }
        private void btnprod_update_Click(object sender, EventArgs e)
        {

            if (validateUpdateProducts())
            {
                Buisness_Logic.product prd = new Buisness_Logic.product();

                int newq = (string.IsNullOrEmpty(txtp2Newqty.Text) ? 0 : int.Parse(txtp2Newqty.Text)) + int.Parse(txtp2_availableqty.Text);
                prd.name = txtp2name.Text;
                prd.make = txtp2_make.Text;
                prd.productType = cmbp2ProdType.SelectedItem.ToString();
                prd.qty = newq;
                prd.buying_price = double.Parse(txtp2_bprice.Text);
                prd.selling_Price = double.Parse(txtp2_sellingprice.Text);
                prd.productID = int.Parse(txtp2_prodID.Text);

                MemoryStream ms = new MemoryStream();
                picbox_editProd.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo_prod = ms.ToArray();
                prd.photo = photo_prod;

                Buisness_Logic.productRepository prep = new Buisness_Logic.productRepository();

                if (prep.updateProduct(prd))
                {
                    MessageBox.Show("Record update succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtp2_availableqty.Text = prd.qty.ToString();
                }

            }
        }

        private void btnprod_delete_Click(object sender, EventArgs e)
        {
            int pid;
            pid = int.Parse(txtp2_prodID.Text);

            Buisness_Logic.productRepository pa = new Buisness_Logic.productRepository();

            if (pa.deleteProduct(pid))
            {
                MessageBox.Show("Record delete succesfull.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Record deletion failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            Buisness_Logic.productRepository pr = new Buisness_Logic.productRepository();

            var dt_pr = pr.searchProducts_for_dataGrid();


            dataGridCART.DataSource = dt_pr;
            this.dataGridCART.Columns[7].Visible = false;



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        int count = 0;
        string sub;
        private void dataGridCART_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            try
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridCART.Rows[e.RowIndex];

            
                    int pid = (int)row.Cells[0].Value;
                    
                    string make = row.Cells[2].Value.ToString();
                   double price  =(double) row.Cells[6].Value;
                    int qty = (int)row.Cells[4].Value;
                    //sub = "p" + count.ToString();
                   
                    string name = row.Cells[1].Value.ToString();
                    Buisness_Logic.product sub  = new Buisness_Logic.product();
                    sub.productID = pid;
                    sub.make = make;
                    sub.selling_Price = price;
                    sub.name = name;
                    sub.qty = qty;

                    prdList.Add(sub);


                    count++;
                    
                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }
        public void carList()
        {
            try
            {
                int x = prdList.Count;
                for (int i = 1; i < x; i++)
                {
                   // DataGridViewRow row = (DataGridViewRow)dataGRid_sell.Rows[i].Clone();
                    dataGRid_sell.Rows[i].Cells[0].Value = prdList[i].productID;
                    dataGRid_sell.Rows[i].Cells[1].Value = prdList[i].name; 
                    dataGRid_sell.Rows[i].Cells[2].Value = prdList[i].selling_Price;
                    dataGRid_sell.Rows[i].Cells[3].Value = null;
                    dataGRid_sell.Rows[i].Cells[4].Value = prdList[i].make;
                    

                    
                }
                dataGRid_sell.Refresh();
            }
            catch (Exception fs)
            {

                throw;
            }
        }

        private void salesMgtsTab_MouseClick(object sender, MouseEventArgs e)
        {
            
    }

        private void dataGridPriducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridPriducts.Rows[e.RowIndex];
                    txtp2name.Text = row.Cells[1].Value.ToString();
                    txtp2_make.Text = row.Cells[2].Value.ToString();
                    cmbp2ProdType.SelectedItem = row.Cells[3].Value.ToString();
                    txtp2_availableqty.Text = row.Cells[4].Value.ToString();
                    txtp2_bprice.Text= row.Cells[5].Value.ToString();
                    txtp2_sellingprice.Text = row.Cells[6].Value.ToString();
                    txtp2_prodID.Text = row.Cells[0].Value.ToString();





                    byte[] picdg = (byte[])row.Cells[7].Value;
                    picbox_editProd.SizeMode = PictureBoxSizeMode.StretchImage;

                    MemoryStream msdg1 = new MemoryStream(picdg);
                    msdg1.Position = 0;

                    msdg1.Read(picdg, 0, picdg.Length);
                    picbox_editProd.Image = Image.FromStream(msdg1);
                    picbox_editProd.Refresh();

                }
            }
            catch (Exception ecell)
            {

                throw;
            }
        }

        private void btnEditProd_clear_Click(object sender, EventArgs e)
        {
            txtp2_prodID.Text = "";
            txtp2_sellingprice.Clear();
            txtp2_make.Text = "";
            txtp2_bprice.Text = "";
            cmbp2ProdType.SelectedIndex = -1;
            picbox_editProd.Image = null;


            picbox_editProd.Refresh();
            cmbp2ProdType.Refresh();

        }
    }
}
