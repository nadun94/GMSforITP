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
    public partial class salesManagement : MetroForm
    {
        public salesManagement()
        {
            InitializeComponent();
        }

        private void salesManagement_Load(object sender, EventArgs e)
        {

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

            if (valp.IsWord(txtAddp_name.Text, "Product name"))
            {
                if (valp.IsWord(txtAddp_make.Text, "Make"))
                {
                    // if (valp.IsWord(cmb_addproduct_type.SelectedValue.ToString(), "Product type"))
                    if (valp.IsNumeric(txtadd_qty.Text, "Product quantity"))
                    {

                        if (picBox1_addproduct.Image != null) return true;

                        else
                        {
                            MessageBox.Show("Please fill all feilds.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }



                    }

                    else return false;


                }


                else return false;

            }
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
    }
}
