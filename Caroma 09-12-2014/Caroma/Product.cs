using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using ExpanderApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caroma
{
    [Transaction(TransactionMode.Automatic)]
    [Regeneration(RegenerationOption.Manual)]

    public partial class FrmProduct : System.Windows.Forms.Form
    {

        #region Properties
        public static ExternalCommandData commandata;
         public static Autodesk.Revit.DB.ElementSet elements;
         string message;
         [System.Runtime.InteropServices.DllImport("gdi32.dll")]
         private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
         private PrivateFontCollection MYpfc = new PrivateFontCollection();
         DataSet dsProduct = new DataSet();
         DataSet dsProducttypesearch = new DataSet();
         List<Button> lstButtons = new List<Button>();
         ArrayList arr = new ArrayList();
         private int selected = 0;
         private int begin = 0;
         private int end = 0;
         string path2;
         PictureBox loading = new PictureBox();
         PictureBox loading1 = new PictureBox();
         System.Windows.Forms.Form frmProgress = new System.Windows.Forms.Form();
         System.Windows.Forms.Form frmProgress2 = new System.Windows.Forms.Form();
         Label lblStatus = new Label();
         Label lblStatus1 = new Label();
         Label lblStatus2 = new Label();
         System.Windows.Forms.Form frmProgress3 = new System.Windows.Forms.Form();
         System.Windows.Forms.Form form = new System.Windows.Forms.Form();
         PictureBox pb = new PictureBox();
         string fileName = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "loginbg.jpg")).Replace("file:\\", "");
         string imgname = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "loadingimage1.gif")).Replace("file:\\", "");
         //string urlcategory = "http://54.213.22.112//CaromaWebService/uploads/p/published/";
         //string urlrangeimg = "http://54.213.22.112//CaromaWebService/media/8/";
         String linkiconimg = "http://caroma.designcontent.com.au/";
         //string urlcategory = "http://publisher.gwabk.com.au/uploads/p/published/";
         string urlNEw = "http://www.gwastorage.com.au/media/8/";

         string urlcategory = "http://caroma.designcontent.com.au/uploads/p/published/";
         string urlrangeimg = "http://caroma.designcontent.com.au/media/8/";
         String replacehres=String.Empty;
         string urlRevit = "http://caroma.designcontent.com.au/Revit/";

        List<String> SearchCriteria=new List<string>();

         # endregion

        #region Watermark

         private void txtSearch_Leave(object sender, EventArgs e)
         {
             if (txtSearch.Text == "")
             {
                 txtSearch.Text = "SEARCH CAROMA";
                 txtSearch.ForeColor = System.Drawing.Color.Gray;
             }
         }

         private void txtSearch_Enter(object sender, EventArgs e)
         {
             if (txtSearch.Text == "SEARCH CAROMA")
             {
                 txtSearch.Text = "";
                 txtSearch.ForeColor = System.Drawing.Color.Black;
             }
         }

         private void txtKeyword_Leave(object sender, EventArgs e)
         {
             if (txtKeyword.Text == "")
             {
                 txtKeyword.Text = "KEYWORD OR CODE";
                 txtKeyword.ForeColor = System.Drawing.Color.Gray;
             }
         }

         private void txtKeyword_Enter(object sender, EventArgs e)
         {
             if (txtKeyword.Text == "KEYWORD OR CODE")
             {
                 txtKeyword.Text = "";
                 txtKeyword.ForeColor = System.Drawing.Color.Black;
             }
         }

         #endregion

        public FrmProduct(ExternalCommandData comma,ref string mess, Autodesk.Revit.DB.ElementSet ele)
        {
            InitializeComponent();
            commandata = comma;
            elements=ele;
            message = mess;
            txtKeyword.ForeColor = System.Drawing.Color.LightGray;
            txtKeyword.Text = "KEYWORD OR CODE";
            this.txtKeyword.Leave += new System.EventHandler(this.txtKeyword_Leave);
            this.txtKeyword.Enter += new System.EventHandler(this.txtKeyword_Enter);

            txtSearch.ForeColor = System.Drawing.Color.LightGray;
            txtSearch.Text = "SEARCH CAROMA";
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);


            try
            {
                unsafe
                {
                    fixed (byte* pFontData = Properties.Resources.brown)
                    {
                        uint dummy = 0;
                        MYpfc.AddMemoryFont((IntPtr)pFontData, Properties.Resources.brown.Length);
                        AddFontMemResourceEx((IntPtr)pFontData, (uint)Properties.Resources.brown.Length, IntPtr.Zero, ref dummy);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Font does not correctly appear");

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // SiteMap
            ClsProperties.Username = "admin";
            lblSiteProducts.Visible = false;
            lnkCatagories.Visible = false;
            lblsiteCategories.Visible = false;
            lnkviewcategoriesType.Visible = false;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            // SiteMap
            ClsProperties.download = false;
            lstProductTypeImage.Visible = false;
            lstProductTypeDetailsImage.Visible = false;
            groupBox1.Visible = false;
            lstProductListImage.Visible = true;

            lnkLogout.Visible = false;
            dsProduct = new DataSet();
            DisplayProductImage();
            BindSearchBox();
            gpseekbar.Visible = false;
            bathseekgb.Visible = false;
            ColorGB.Visible = false;
            inletTypeGB.Visible = false;
            trapTypeGB.Visible = false;
            productTypeGB.Visible = false;
            SaveBtnSearch.Location = new System.Drawing.Point(55, 634);
            CancelSearch.Location = new System.Drawing.Point(150, 634);
            SaveBtnSearch.Visible = false;
            CancelSearch.Visible = false;

            lstProductListImage.Font = new Font(MYpfc.Families[0],10);
            lblProductList.Font = new Font(MYpfc.Families[0], 14, FontStyle.Bold);
            lblCategories.Font = new Font(MYpfc.Families[0],14,FontStyle.Bold);

            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            mainListview.Visible = true;

        }

        public Button CreateLabelHeader(Expander expander, string text, System.Drawing.Color backColor, Image collapsedImage = null, Image expandedImage = null, int height = 25, Font font = null)
        {
            Button headerLabel = new Button();
            headerLabel.FlatStyle = FlatStyle.Flat;
            headerLabel.FlatAppearance.BorderSize = 1;

            headerLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            headerLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            headerLabel.ForeColor = System.Drawing.Color.FromArgb(75, 75, 75);
            headerLabel.Text = text;
            headerLabel.Font = new Font("Brown", 11, FontStyle.Regular);

            // headerLabel.Font = new System.Drawing.Font(MYpfc.Families[0], 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            headerLabel.AutoSize = false;
            headerLabel.Height = height;
            if (font != null)
                headerLabel.Font = font;
            headerLabel.TextAlign = ContentAlignment.MiddleLeft;
            if (collapsedImage != null && expandedImage != null)
            {
                headerLabel.Image = collapsedImage;
                headerLabel.ImageAlign = ContentAlignment.MiddleRight;
            }
            headerLabel.BackColor = backColor;
            if (collapsedImage != null && expandedImage != null)
            {
                expander.StateChanged += delegate { headerLabel.Image = expander.Expanded ? collapsedImage : expandedImage; };
            }
            headerLabel.Click += delegate { expander.Toggle(); };

            headerLabel.Click += mybutton_click;
            expander.Header = headerLabel;

            return headerLabel;
        }

        private void CreateContentLabel(Expander expander, string[] text, int height)
        {

            //LinkLabel labelContent = new LinkLabel();
            //labelContent.Text = text;
            //labelContent.Size = new System.Drawing.Size(expander.Width, 544);
            //expander.Content = labelContent;
            ListBox lb = new ListBox();
            foreach (string s in text)
            {
                lb.Items.Add(s);
            }

            lb.BackColor = System.Drawing.Color.White;
            lb.Size = new Size(190, 230);
            lb.Location = new System.Drawing.Point(0, 23);
            //lb.I = 200;


            lb.ScrollAlwaysVisible = true;
            lb.Margin = new Padding(0, 10, 0, 20);

            lb.Font = new Font(MYpfc.Families[0], 10, FontStyle.Regular);
            //lb.Dock = DockStyle.Bottom;
            //expander.Content = lb;
            lb.BringToFront();
            lb.SelectedIndexChanged += lstselectedindexrange_click;
            lb.DrawMode = DrawMode.OwnerDrawVariable;
            lb.DrawItem += new DrawItemEventHandler(DrawItem);
            lb.MeasureItem += new MeasureItemEventHandler(MeasureItem);

            expander.Controls.Add(lb);
        }

        private void mybutton_click(object sender, EventArgs e)
        {
            Button btxt = sender as Button;
            string btnstring = btxt.Text;
            //MessageBox.Show(btnstring);
           
            displaylstProductList(btnstring);
        }

        public String get_categorylist()
        {
            String getData = String.Empty;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "CaromaSoap";
                binding.CloseTimeout = System.TimeSpan.Parse("00:10:00");

                binding.OpenTimeout = System.TimeSpan.Parse("00:10:00");
                binding.ReceiveTimeout = System.TimeSpan.Parse("00:10:00");
                binding.SendTimeout = System.TimeSpan.Parse("00:10:00");

                binding.AllowCookies = false;
                binding.BypassProxyOnLocal = false;
                binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;

                binding.MaxBufferSize = 28454546;
                binding.MaxBufferPoolSize = 28454546;
                binding.MaxReceivedMessageSize = 28454546;

                binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = System.ServiceModel.TransferMode.Buffered;

                binding.UseDefaultWebProxy = true;
                binding.ReaderQuotas.MaxDepth = 28454546;
                binding.ReaderQuotas.MaxStringContentLength = 28454546;

                binding.ReaderQuotas.MaxArrayLength = 28454546;
                binding.ReaderQuotas.MaxBytesPerRead = 28454546;
                binding.ReaderQuotas.MaxNameTableCharCount = 28454546;

                binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                binding.Security.Transport.Realm = "";
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress endpoint = new EndpointAddress("http://caroma.designcontent.com.au/Caroma.asmx?wsdl");
                CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient(binding, endpoint);
                getData = objService._getCategoryList(ClsProperties.Username);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Check your Internet Connection.");
            }
            return getData;
        }

        protected bool CheckUrlExists(string url)
        {
            // If the url does not contain Http. Add it.
            // if i want to also check for https how can i do.this code is only for http not https
            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        private Image LoadImage(string url)
        {
            if (CheckUrlExists(url))
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bmp = new Bitmap(responseStream);
                responseStream.Dispose();
                return bmp;
            }
            else
            {
                url = "http://caroma.designcontent.com.au/media/8/no_image_thumb.gif";
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap bmp = new Bitmap(responseStream);
                responseStream.Dispose();
                return bmp;
            }
              
           


            //else
            //{
            //    String URLLL = url;
            //    String urlfolder = String.Empty;
            //    string[] bits = URLLL.Split('/');
            //    //foreach (string bit in bits)
            //    //{
            //    //    urlfolder = bit;
            //    //    break;
            //    //}
            //    String  FolderNAme= bits[5].ToString();
            //    String FolderImage = bits[6].ToString();
            //    String URL756 = urlNEw+ FolderNAme+"/"+FolderImage;
            //    Directory.CreateDirectory("C:\\CaromaImage\\" + FolderNAme + "");
            //    WebClient webClient = new WebClient();
            //    webClient.DownloadFileAsync(new Uri(URL756), @"C:\CaromaImage\" + FolderNAme + "\\" + FolderImage);

            //    String replacehres = FolderImage.Replace("small_150px_150px", "large_800px_800px");
            //    String URL7561 = urlNEw + FolderNAme + "/" + replacehres;
            //    WebClient webClient1 = new WebClient();
            //    webClient1.DownloadFileAsync(new Uri(URL7561), @"C:\CaromaImage\" + FolderNAme + "\\" + replacehres);

               
            //    System.Net.WebRequest request = System.Net.WebRequest.Create(URL756);
            //    System.Net.WebResponse response = request.GetResponse();
            //    System.IO.Stream responseStream = response.GetResponseStream();
            //    Bitmap bmp = new Bitmap(responseStream);
            //    responseStream.Dispose();
            //    return bmp;

            //}
   
        }

        private DataSet getCategoryData(String UserName)
        {
            String getData = String.Empty;
            try
            {
               // CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient();
                getData = get_categorylist();
                StringReader theReader = new StringReader(getData);
                dsProduct.ReadXml(theReader);
              //  objService.Close();
            }
            catch (Exception ex)
            {
                //lblProductErrorMessage.Text = "Please Check your Internet Connection.";
            }
            return dsProduct;
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin objLogin = new frmLogin(commandata,ref message,elements);
            objLogin.Show();
            this.Hide();
        }

        private void lstProductList_DrawItem(object sender, DrawItemEventArgs e)
        {
          
    if (e.Index<0) return;
    //if the item state is selected them change the back color 
    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        e = new DrawItemEventArgs(e.Graphics,
                                  e.Font, 
                                  e.Bounds, 
                                  e.Index,
                                  e.State ^ DrawItemState.Selected,
                                 e.ForeColor,
                                  System.Drawing.Color.FromArgb(0, 196, 220));//Choose the color
    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    // Draw the background of the ListBox control for each item.
    e.DrawBackground();
    // Draw the current item text
   // e.Graphics.DrawString(lstProductList.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
    // If the ListBox has focus, draw a focus rectangle around the selected item.
    e.DrawFocusRectangle();

        }
       
        private void displayProgress()
        {
            frmProgress3 = new System.Windows.Forms.Form();
            loading = new PictureBox();
            loading.Image = new Bitmap(Caroma.Properties.Resources.loadingimage1); 
            loading.SizeMode = PictureBoxSizeMode.StretchImage;
            lblStatus2 = new Label();
            frmProgress3.StartPosition = FormStartPosition.CenterScreen;
            frmProgress3.FormBorderStyle = FormBorderStyle.None;
            frmProgress3.Size = new Size(150, 75);
            frmProgress3.BackColor = System.Drawing.Color.White;
            frmProgress3.BackgroundImage = new Bitmap(Caroma.Properties.Resources.loginbg);//new Bitmap(@"..\Formbg\loadingimage.gif");;
            frmProgress3.BackgroundImageLayout = ImageLayout.Stretch;
            loading.Size = new Size(30, 30);
            loading.Location = new System.Drawing.Point(60, 10);
            lblStatus2.Text = "Loading......";
            lblStatus2.Font = new Font(MYpfc.Families[0], 12);
            lblStatus2.Location = new System.Drawing.Point(40, 50);
            lblStatus2.ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
            lblStatus2.BackColor = System.Drawing.Color.Transparent;
            frmProgress3.Controls.Add(loading);
            frmProgress3.Controls.Add(lblStatus2);
            frmProgress3.Show();
            Application.DoEvents();
        }

        private void DisplayProductImage()
        {

            try
            {
                displayProgress();
                imageLstProduct.Images.Clear();
                lstProductListImage.Clear();

                //lstProductList.Items.Clear();
                getCategoryData(ClsProperties.Username);
                DataTable table = dsProduct.Tables[0];
                DataTable range = dsProduct.Tables[1];
                lstProductListImage.Visible = false;
                lblProductList.Visible = false;
                lblCategories.Text = "PRODUCTS";

                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                mainListview.Visible = true;
                mainListview.Items.Clear();

                //listbox

                if (table.Rows.Count > 0)
                {

                    Accordion accordion = new Accordion();
                    accordion.Size = new Size(190, 600);
                    // lstProductList.Visible = false;
                    accordion.Location = new System.Drawing.Point(8, 156);

                    //table.DefaultView.RowFilter = "Isdeleted = 'False'";
                    table = table.DefaultView.ToTable();
                    var filePaths = from row in table.AsEnumerable()
                                    select row.Field<string>("category_name");
                    var productid = (from row in table.AsEnumerable()
                                     select row["category_id"]).FirstOrDefault();
                    var filePathsArray = filePaths.ToList();
                    for (int i = 0; i < filePathsArray.Count; i++)
                    {

                        String m = filePathsArray[i].ToString();
                        //if (!filePathsArray.Contains(m))
                        //{
                        range = range.DefaultView.ToTable();
                        var rangepath = from row in range.AsEnumerable()
                                        where row["parent_category_name"].ToString().Equals(m.ToString(), StringComparison.InvariantCultureIgnoreCase)
                                        select row["range_name"].ToString();
                        var rangpatharray = rangepath.Distinct().ToList();
                        rangpatharray.Sort();
                        Expander expander1 = new Expander();
                        expander1.BorderStyle = BorderStyle.FixedSingle;
                        expander1.Dock = DockStyle.Left;
                        expander1.Dock = DockStyle.Right;
                        expander1.Dock = DockStyle.Bottom;
                        //Button btn1 = new Button();

                        //btn1.Text = filePathsArray[i].ToString();
                        //expander1.Header = btn1;
                        lstButtons.Add(CreateLabelHeader(expander1, filePathsArray[i].ToString(), System.Drawing.Color.White));
                        CreateContentLabel(expander1, rangpatharray.ToArray(), 10);
                        accordion.Add(expander1);
                        accordion.BringToFront();

                        //}
                    }

                    this.Controls.Add(accordion);

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        //imageLstProduct images = new ImageList();
                        String URLImage = table.Rows[j]["Category_images"].ToString();
                        String urlembed = urlcategory + URLImage;
                        String ProductName = table.Rows[j]["category_name"].ToString();
                        LinkLabel linkLabel1 = new LinkLabel();
                        imageLstProduct.Images.Add(LoadImage(urlembed));
                        mainListview.View = System.Windows.Forms.View.LargeIcon;
                        imageLstProduct.ImageSize = new Size(150, 150);
                        mainListview.LargeImageList = imageLstProduct;
                        mainListview.Items.Add(ProductName, j);
                        //lstProductListImage.ItemSize = new Size(180, 35);
                        // int producttype = Convert.ToInt32(table.Rows[j]["ProductID"].ToString());
                        //for (int m = 0; m < tableptype.Rows.Count; m++)
                        mainListview.BringToFront();
                        mainListview.Items[j].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                        mainListview.Items[j].Font = new System.Drawing.Font(MYpfc.Families[0], 13, System.Drawing.FontStyle.Regular);
                    }
                }
                frmProgress3.Close();
            }
            catch (Exception ex) { }
            
            frmProgress3.Close();


        }

        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lpb=sender as ListBox;
           

            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Font fontlb = new Font(MYpfc.Families[0], 8, FontStyle.Regular);
                e = new DrawItemEventArgs(e.Graphics,
                                          fontlb,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                        System.Drawing.Color.FromArgb(0, 196, 220),
                                          System.Drawing.Color.LightGray);//Choose the color
            }
            e.DrawBackground();
            // You'll change the font size here. Notice the 20
            e.Graphics.DrawString(lpb.Items[e.Index].ToString(), new Font(MYpfc.Families[0], 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.DimGray), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // You may need to experiment with the ItemHeight here..
            e.ItemHeight = 15;
        }

        private void lstselectedindexrange_click(object sender, EventArgs e)
        {
            ListBox lst = sender as ListBox;
            String SelectedrangenameName=lst.GetItemText(lst.SelectedItem);

            DisplayRangeimage(SelectedrangenameName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void displaylstProductList(String SelectedName) // Main ListView Product List
        {


            // SiteMap
            displayProgress();
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = false;
            lnkviewcategoriesType.Visible = false;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            // SiteMap
            lnkCatagories.Text = SelectedName.ToUpper();
            String Selectedrangename = String.Empty;
            DataTable dtProdcutListImage = dsProduct.Tables[1];
            imageLstProduct.Images.Clear();
            lstProductTypeImage.Clear();
            String ProductTypeName = String.Empty;
            
            Int16 Count = 0;
            dtProdcutListImage.DefaultView.RowFilter = "parent_category_name ='" + SelectedName + "'";
            dtProdcutListImage = dtProdcutListImage.DefaultView.ToTable();
            for (int j = 0; j < dtProdcutListImage.Rows.Count; j++)
            {
                String GetProductName = dtProdcutListImage.Rows[j]["parent_category_name"].ToString();
                //Dictionary<String,String> uniqueobj=new Dictionary<string,string>();

                //if (string.Equals(SelectedName, GetProductName, StringComparison.OrdinalIgnoreCase))

                //if (SelectedName == dsProduct.Tables[0].Rows[j]["ProductName"].ToString())
                //{
                    Selectedrangename = dtProdcutListImage.Rows[j]["range_name"].ToString();
                    ListViewItem objLVI = lstProductTypeImage.FindItemWithText(Selectedrangename);

                    if (objLVI == null)
                    {
                        Count = Convert.ToInt16(Count + 1);
                        ProductTypeName = Selectedrangename;
                        String ProductTypeImage = dtProdcutListImage.Rows[j]["catalog_thumbnail_url"].ToString();
                        string urlfolder = string.Empty;
                        string[] bits = ProductTypeImage.Split('_');
                        foreach (string bit in bits)
                        {
                            urlfolder = bit;
                            break;
                        }
                        string rangeurlimg = urlrangeimg + urlfolder + "/" + ProductTypeImage;
                        lstProductListImage.Visible = true;

                        lstProductTypeDetailsImage.Visible = false;
                        groupBox1.Visible = false;
                        lstProductTypeImage.Visible = true;

                        imageLstProduct.Images.Add(LoadImage(rangeurlimg)); 
                        lstProductTypeImage.View = System.Windows.Forms.View.LargeIcon;
                        imageLstProduct.ImageSize = new Size(150, 150);
                        lstProductTypeImage.LargeImageList = imageLstProduct;

                        lstProductTypeImage.Items.Add(Selectedrangename, Count - 1);
                        lstProductTypeImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                        lstProductTypeImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 13, System.Drawing.FontStyle.Regular);
                        lstProductTypeImage.LabelWrap = true;

                   // }
                }
            }

            if (Selectedrangename == String.Empty)
            {
                //// SiteMap
                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;
                //// SiteMap
                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;
                //dsProduct = new DataSet();
                //DisplayProductImage();
                //frmProgress3.Close();
             
                lblMessage.Text = "No records found for '" + SelectedName + "'";
            }
            frmProgress3.Close();
        
        }

        private void lstProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String SelectedProductName = lstProductList.SelectedItem.ToString();
          //  displaylstProductList(SelectedProductName);
          
        }

        private void lstProductListImage_MouseHover(object sender, EventArgs e)
        {
            //lstProductListImage.BackColor = Color.FromArgb(0, 196, 220);
        }

        private void displaylstProductTypeImage(String SelectedProductTypeName)
        {

            displayProgress();
            // SiteMap
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = true;
            lnkviewcategoriesType.Visible = true;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            mainListview.Visible = false;
            lnkviewcategoriesType.Text = SelectedProductTypeName.ToUpper();
            lstProductTypeDetailsImage.Visible = true;
           
            DataTable dtProdcutListTypeImage = dsProduct.Tables[1];
            String CategorieName = lnkCatagories.Text;
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();
            String ProductTypeDetailsName = String.Empty;
            // SiteMap

         
            Int16 Count = 0;
          
            dsProduct.Tables[1].CaseSensitive = false;
          DataRow[] dtfinal=  dsProduct.Tables[1].Select("parent_category_name= '" + CategorieName + "' and range_name = '" + SelectedProductTypeName + "'");

          foreach (object itemrow in dtfinal)
          {
                    ProductTypeDetailsName = ((System.Data.DataRow)(itemrow)).ItemArray[3].ToString();
                    String ProductTypeDetailsImage = ((System.Data.DataRow)(itemrow)).ItemArray[4].ToString();
              
                    //Count = Convert.ToInt16(Count + 1);
                    Count = Convert.ToInt16(Count + 1);

                    string urlfolder = string.Empty;
                    string[] bits = ProductTypeDetailsImage.Split('_');
                    foreach (string bit in bits)
                    {
                        urlfolder = bit;
                        break;
                    }
                    string rangeurlimg = urlrangeimg + urlfolder + "/" + ProductTypeDetailsImage;
                   

                    lstProductListImage.Visible = false;
                    lstProductTypeImage.Visible = false;
                    groupBox1.Visible = false;
                   

                    imageLstProduct.Images.Add(LoadImage(rangeurlimg));
                    lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                    imageLstProduct.ImageSize = new Size(150, 150);
                    lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                    lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                    lstProductTypeDetailsImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                    lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
                 //   lstProductTypeDetailsImage.View = System.Windows.Forms.View.Details;
                   lstProductTypeDetailsImage.LabelWrap = true;
                   lblMessage.Text = "";
                                  
                }

            if (ProductTypeDetailsName == String.Empty)
            {

                //// SiteMap

                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;

                //// SiteMap

                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;
               
                //dsProduct = new DataSet();
                //DisplayProductImage();
                //frmProgress3.Close();
              
                lblMessage.Text = "No records found for '" + SelectedProductTypeName + "'";
            }

            
            frmProgress3.Close();
     

        }

        private void lstProductTypeImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedProductTypeName = lstProductTypeImage.SelectedItems[0].Text.ToString();
            DisplayRangeimage(SelectedProductTypeName);
        }

        private void displaylstProductTypeDetailsImage(String SelectedProductTypeImageName) // Pdoctlist Image -3
        {
            displayProgress();
            // SiteMap
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = true;
            lnkviewcategoriesType.Visible = true;
            lblviewtypeimage.Visible = true;
            lnkviewCatagoriesTypeImages.Visible = true;

            lnkviewCatagoriesTypeImages.Text = SelectedProductTypeImageName.ToUpper();

            String SelectedProductTypeimgname = String.Empty;
            String SelectedProductTypeRevitimgname = String.Empty;
            DataTable dtProdcutListTypeDetailsImage = dsProduct.Tables[1];
            String ProductTypeDetailsViewImage = String.Empty;

            // SiteMap
            dsProduct.Tables[1].CaseSensitive = false;
             DataRow[] row = dsProduct.Tables[1].Select("catalog_web_name =  '" + SelectedProductTypeImageName + "'");

             foreach (object itemrow in row)
             {
                 SelectedProductTypeimgname = ((System.Data.DataRow)(itemrow)).ItemArray[4].ToString();
                 SelectedProductTypeRevitimgname = ((System.Data.DataRow)(itemrow)).ItemArray[5].ToString();
                 String SelectedcatalogWebName = ((System.Data.DataRow)(itemrow)).ItemArray[3].ToString();
                 String SelectedcatalogName = ((System.Data.DataRow)(itemrow)).ItemArray[1].ToString();

                 string urlfolder = string.Empty;
                 string[] bits = SelectedProductTypeimgname.Split('_');
                 foreach (string bit in bits)
                 {
                     urlfolder = bit;
                     break;
                 }

                 # region Revit File Name
                 dsProduct.Tables[12].CaseSensitive = false;
                 DataRow[] RevitFileAmazon = dsProduct.Tables[12].Select("Category_web_name = '" + SelectedcatalogWebName + "'");
                 String RevitFileNameAmazon = String.Empty;
                 foreach (object item in RevitFileAmazon)
                 {
                     RevitFileNameAmazon = ((System.Data.DataRow)(item)).ItemArray[2].ToString();
                     break;
                 }
                 String SelectedProductTypeRevitFileName = urlRevit + RevitFileNameAmazon;
                 ClsProperties.RevitFilePath = SelectedProductTypeRevitFileName;
                 #endregion

                 ProductTypeDetailsViewImage = urlrangeimg + urlfolder + "/" + SelectedProductTypeimgname;
                 lstProductListImage.Visible = false;
                 lstProductTypeImage.Visible = false;
                 lstProductTypeDetailsImage.Visible = false;
                 groupBox1.Visible = true;
                String ProductTypeDetailsRevitViewImage = urlrangeimg + urlfolder + "/" + SelectedProductTypeRevitimgname;
                String hresRevitimg = ProductTypeDetailsRevitViewImage.ToString();
                 lblProductDetailsimageName.Text = SelectedcatalogWebName;
                 String hresimg = ProductTypeDetailsViewImage.ToString();
                 if (hresRevitimg.Contains("small_150px_150px"))
                 hresRevitimg = hresRevitimg.Replace("small_150px_150px", "large_800px_800px");
                 else
                     hresRevitimg = hresRevitimg.Replace("150px", "800px");
                 if (hresimg.Contains("small_150px_150px"))          
                     replacehres = hresimg.Replace("small_150px_150px", "large_800px_800px");
                 else 
                     replacehres = hresimg.Replace("150px", "800px");
                 if (CheckUrlExists(replacehres)){} else {replacehres = "http://caroma.designcontent.com.au/media/8/no_image_thumb.gif"; }
                 if (CheckUrlExists(hresRevitimg)){} else {hresRevitimg = "http://caroma.designcontent.com.au/media/8/no_image_thumb.gif";}

                 PictureViewmage.ImageLocation = replacehres;
                 PictureViewmage.SizeMode = PictureBoxSizeMode.StretchImage;
                 pictureviewimage2.ImageLocation = hresRevitimg;
                 pictureviewimage2.SizeMode = PictureBoxSizeMode.StretchImage;
                 
                 lblMessage.Text = "";
                 break;
             }

            if (ProductTypeDetailsViewImage == String.Empty)
            {
                //// SiteMap
                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;

                //// SiteMap

                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;

                //dsProduct = new DataSet();
                //DisplayProductImage();
                //frmProgress3.Close();
              
                lblMessage.Text = "No records found for '" + SelectedProductTypeImageName + "'";
            }

            frmProgress3.Close();
        

        }

        private void lstProductTypeDetailsImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SelectedProductTypeImageName = lstProductTypeDetailsImage.SelectedItems[0].Text.ToString();
            displaylstProductTypeDetailsImage(SelectedProductTypeImageName);
        }

        private void pictureviewimage2_Click(object sender, EventArgs e)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(600, 600);
            form.FormBorderStyle = FormBorderStyle.None;
            string fileName1 = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "frame.png")).Replace("file:\\", "");
            form.BackgroundImage = Image.FromFile(fileName1);// new Bitmap(@"..\Formbg\loadingimage.gif"); ;
            form.BackgroundImageLayout = ImageLayout.Stretch;
            pb.ImageLocation = null;

            pb.Dock = DockStyle.None;
            pb.Size = new Size(592, 568);
            pb.Location = new System.Drawing.Point(3, 29);
            pb.Margin = new System.Windows.Forms.Padding(2);
            pb.ImageLocation = pictureviewimage2.ImageLocation;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;


            // Add the button to the form. 
            PictureBox pb1 = new PictureBox();
            string pbimg1 = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "headerpopup.jpg")).Replace("file:\\", "");
            pb1.ImageLocation = pbimg1;// new Bitmap(@"..\Formbg\loadingimage.gif"); ;
            pb1.Location = new System.Drawing.Point(0, 0);
            pb1.Size = new Size(934, 32);
            pb1.BringToFront();

            Button button1 = new Button();
            button1.Size = new Size(20, 20);
            button1.Text = "X";
            button1.ForeColor = System.Drawing.Color.White;
            button1.BackColor = System.Drawing.Color.DarkRed;
            button1.Location = new System.Drawing.Point(570, 7);

            button1.Click += new System.EventHandler(this.button1_Click);
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BringToFront();



            form.Controls.Add(button1);
            form.Controls.Add(pb1);
            form.Controls.Add(pb);
            form.ShowDialog();
        }

        private void PictureViewmage_Click(object sender, EventArgs e)
        {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Size = new Size(600, 600);
                form.FormBorderStyle = FormBorderStyle.None;
                string fileName1 = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "frame.png")).Replace("file:\\", "");
                form.BackgroundImage = Image.FromFile(fileName1);// new Bitmap(@"..\Formbg\loadingimage.gif"); ;
                form.BackgroundImageLayout = ImageLayout.Stretch;
                pb.ImageLocation = null;
          
                pb.Dock = DockStyle.None;
                pb.Size = new Size(592, 568);
                pb.Location = new System.Drawing.Point(3,29);
                pb.Margin = new System.Windows.Forms.Padding(2);
                pb.ImageLocation = PictureViewmage.ImageLocation;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;


                // Add the button to the form. 
                PictureBox pb1 = new PictureBox();
                string pbimg1 = (System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "Formbg", "headerpopup.jpg")).Replace("file:\\", "");
                pb1.ImageLocation = pbimg1;// new Bitmap(@"..\Formbg\loadingimage.gif"); ;
                pb1.Location = new System.Drawing.Point(0, 0);
                pb1.Size = new Size(934, 32);
                pb1.BringToFront();

                Button button1 = new Button();
                button1.Size = new Size(20, 20);
                button1.Text = "X";
                button1.ForeColor = System.Drawing.Color.White;
                button1.BackColor = System.Drawing.Color.DarkRed;
                button1.Location = new System.Drawing.Point(570, 7);

                button1.Click += new System.EventHandler(this.button1_Click);
                button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
                button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
                button1.FlatStyle = FlatStyle.Flat;
                button1.FlatAppearance.BorderSize = 0;
                button1.BringToFront();



                form.Controls.Add(button1);
                form.Controls.Add(pb1);
                form.Controls.Add(pb);
                form.ShowDialog();
            
        } // To be copied

        private void button1_Click(object sender, EventArgs e)
        {
            form.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"c:\Temp\", "*.rfa",SearchOption.AllDirectories);
            string fname = ClsProperties.RevitFilePath.ToString();
            
            int k = fname.LastIndexOf("/");
            fname = fname.Remove(0, k + 1);
            fname = fname.Replace("%20", " ");
            fname = fname.Replace(".rfa", "");
            
            foreach (string path in filePaths)
            {
                 string path1;
                
                    path1=path;
                  int s = path1.LastIndexOf("\\");
                path1 = path1.Remove(0, s + 1);
                path1 = path1.Replace(".rfa", "");
                if(path1==fname){
                path2=path1;
                break;
                
                }
            }

                if (path2 == fname)
                {

                    DialogResult dialogResult = MessageBox.Show("File Already Exists! \n Are you sure you wish to overwrite existing file?", "Caroma", MessageBoxButtons.YesNo);


                    if (dialogResult == DialogResult.Yes)
                    {

                        ClsProperties.download = true;
                        frmProgress = new System.Windows.Forms.Form();
                        loading = new PictureBox();
                        lblStatus = new Label();

                        frmProgress.StartPosition = FormStartPosition.CenterScreen;
                        //frmProgress.Size = new Size(PictureViewmage.Image.Size.Width, PictureViewmage.Image.Size.Height);
                        frmProgress.Size = new Size(150, 75);
                        frmProgress.FormBorderStyle = FormBorderStyle.None;

                        frmProgress.BackgroundImage = Image.FromFile(fileName);
                        frmProgress.BackgroundImageLayout = ImageLayout.Stretch;
                        loading.Size = new Size(30, 30);

                        loading.Image = new Bitmap(Caroma.Properties.Resources.loadingimage1); 
                        loading.SizeMode = PictureBoxSizeMode.StretchImage;
                        loading.Location = new System.Drawing.Point(60, 10);
                        lblStatus.Text = "Loading...";
                        lblStatus.Font = new Font(MYpfc.Families[0], 12);
                        lblStatus.Location = new System.Drawing.Point(40, 50);
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                        lblStatus.BackColor = System.Drawing.Color.Transparent;

                        frmProgress.Size = new Size(150, 75);
                        frmProgress.Controls.Add(loading);
                        frmProgress.Controls.Add(lblStatus);

                        frmProgress.Load += new EventHandler(frmProgress_Load);
                        frmProgress.ShowDialog();
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else {


                    ClsProperties.download = true;
                    frmProgress = new System.Windows.Forms.Form();
                    loading = new PictureBox();
                    lblStatus = new Label();

                    frmProgress.StartPosition = FormStartPosition.CenterScreen;
                    //frmProgress.Size = new Size(PictureViewmage.Image.Size.Width, PictureViewmage.Image.Size.Height);
                    frmProgress.Size = new Size(150, 75);
                    frmProgress.FormBorderStyle = FormBorderStyle.None;

                    frmProgress.BackgroundImage = Image.FromFile(fileName);
                    frmProgress.BackgroundImageLayout = ImageLayout.Stretch;
                    loading.Size = new Size(30, 30);

                    loading.Image = new Bitmap(Caroma.Properties.Resources.loadingimage1);
                    loading.SizeMode = PictureBoxSizeMode.StretchImage;
                    loading.Location = new System.Drawing.Point(60, 10);
                    lblStatus.Text = "Loading...";
                    lblStatus.Font = new Font(MYpfc.Families[0], 12);
                    lblStatus.Location = new System.Drawing.Point(40, 50);
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                    lblStatus.BackColor = System.Drawing.Color.Transparent;

                    frmProgress.Size = new Size(150, 75);
                    frmProgress.Controls.Add(loading);
                    frmProgress.Controls.Add(lblStatus);

                    frmProgress.Load += new EventHandler(frmProgress_Load);
                    frmProgress.ShowDialog();
                    //do something
                
                
                
                }
            }

        private void BindSearchBox()
        {
            DataTable table5 = dsProduct.Tables[0];
            table5 = table5.DefaultView.ToTable();
            var filePaths = from row in table5.AsEnumerable()
                            select row.Field<string>("category_name");
            var filePathsArray = filePaths.ToList();
            for (int i = 0; i < filePathsArray.Count; i++)
            {
                searchProductCombo.Items.Add(filePathsArray[i].ToString().ToUpper());
            }
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TURE if the Status code == 200
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            //String RevitFilePath = String.Empty;
            //System.Web.HttpUtility.UrlEncode(string url);
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            string fname = ClsProperties.RevitFilePath.ToString();
          
            int k = fname.LastIndexOf("/");
            fname = fname.Remove(0, k + 1);
            fname = fname.Replace("%20", " ");
            fname = fname.Replace(".rfa", "");
            ClsProperties.filename = fname;
            if (RemoteFileExists(ClsProperties.RevitFilePath))
            {
                get_RevitDownloadCount();
                webClient.DownloadFileAsync(new Uri(ClsProperties.RevitFilePath), @"c:\Temp\" + fname + ".rfa");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
               
                lblMessage.Text = "";
                //
            }
            else 
            {

                MessageBox.Show(fname+ " File Does Not Exist." );
                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;

                //// SiteMap

                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;

                //dsProduct = new DataSet();
                //DisplayProductImage();
      
                //lblMessage.Text = "No records found for '" + fname + "'";

                frmProgress.Close();
            }
           
            
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //bar.Value = e.ProgressPercentage;
        }

        public void Completed(object sender, AsyncCompletedEventArgs e)
        {
            lblStatus.Text = "Completed";
            frmProgress.Refresh();
            System.Threading.Thread.Sleep(2000);
            string FamilyPath = Path.GetFullPath(@"c:\Temp\" + ClsProperties.filename + ".rfa");
            CmdPlaceFamilyInstance objcmd = new CmdPlaceFamilyInstance();
            UIApplication uiapp = commandata.Application;
            frmProgress.Close();
            this.Hide();
        }

        private void lnkProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // SiteMap

            lblSiteProducts.Visible = false;
            lnkCatagories.Visible = false;
            lblsiteCategories.Visible = false;
            lnkviewcategoriesType.Visible = false;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;

            // SiteMap

            lstProductTypeImage.Visible = false;
            lstProductTypeDetailsImage.Visible = false;
            groupBox1.Visible = false;
            lstProductListImage.Visible = true;
          
            dsProduct = new DataSet();
            DisplayProductImage();
        }

        private void lnkCatagories_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String SelectedProductName = lnkCatagories.Text;
            if (SelectedProductName == "SEARCH")
            {
                Search();
            }
            else
            {
                displaylstProductList(SelectedProductName);
            }
        }

        private void lnkviewcategoriesType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String SelectedProductTypeName = lnkviewcategoriesType.Text;
            displaylstProductTypeImage(SelectedProductTypeName);
        }

        private void lnkviewCatagoriesTypeImages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String SelectedProductTypeImageName = lnkviewCatagoriesTypeImages.Text;
            displaylstProductTypeDetailsImage(SelectedProductTypeImageName);
        }

        #region TrackBar

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar)sender;

            myTB.Text = myTB.Value.ToString();
            label6.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB1;
            myTB1 = (System.Windows.Forms.TrackBar)sender;

            myTB1.Text = myTB1.Value.ToString();
            label7.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar)sender;

            myTB.Text = myTB.Value.ToString();
            label8.Text = trackBar3.Value.ToString();

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar)sender;

            myTB.Text = myTB.Value.ToString();
            label9.Text = trackBar4.Value.ToString();

        }

        #endregion 

        #region Search

        public String get_productSearch(String value)
        {
            String getData = String.Empty;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "CaromaSoap";
                binding.CloseTimeout = System.TimeSpan.Parse("00:10:00");

                binding.OpenTimeout = System.TimeSpan.Parse("00:10:00");
                binding.ReceiveTimeout = System.TimeSpan.Parse("00:10:00");
                binding.SendTimeout = System.TimeSpan.Parse("00:10:00");

                binding.AllowCookies = false;
                binding.BypassProxyOnLocal = false;
                binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;

                binding.MaxBufferSize = 28454546;
                binding.MaxBufferPoolSize = 28454546;
                binding.MaxReceivedMessageSize = 28454546;

                binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = System.ServiceModel.TransferMode.Buffered;

                binding.UseDefaultWebProxy = true;
                binding.ReaderQuotas.MaxDepth = 28454546;
                binding.ReaderQuotas.MaxStringContentLength = 28454546;

                binding.ReaderQuotas.MaxArrayLength = 28454546;
                binding.ReaderQuotas.MaxBytesPerRead = 28454546;
                binding.ReaderQuotas.MaxNameTableCharCount = 28454546;

                binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                binding.Security.Transport.Realm = "";
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress endpoint = new EndpointAddress("http://caroma.designcontent.com.au/Caroma.asmx?wsdl");
                CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient(binding, endpoint);
                getData = objService._getProductSearch(value);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Check your Internet Connection.");
            }
            return getData;
        }

        private void Search()
        {
            // SiteMap
            displayProgress();
           
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = false;
            lnkviewcategoriesType.Visible = false;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;

            lnkviewcategoriesType.Text = "SEARCH";

            DataTable dtProdcutListTypeImage = dsProduct.Tables[2];
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();

            // SiteMap

            imageLstProduct.Images.Clear();

            DataRow[] row = dsProduct.Tables[2].Select("IsDeleted =0");
            Int16 Count = 0;
            
            foreach (object item in row)
            {
                String ProductTypeDetailsName = ((System.Data.DataRow)(item)).ItemArray[1].ToString();
                String ProductTypeDetailsImage = ((System.Data.DataRow)(item)).ItemArray[3].ToString();
                Int16 ProductTypeDetailsID = Convert.ToInt16(((System.Data.DataRow)(item)).ItemArray[0].ToString());
               
                Count = Convert.ToInt16(Count + 1);
                lstProductListImage.Visible = false;
            
                lstProductTypeImage.Visible = false;
                groupBox1.Visible = false;
                lstProductTypeDetailsImage.Visible = true;

                imageLstProduct.Images.Add(LoadImage(ProductTypeDetailsImage));
                lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                imageLstProduct.ImageSize = new Size(150, 150);
                lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                lstProductTypeDetailsImage.Items[Count-1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
               lstProductTypeDetailsImage.LabelWrap = true;
            }

            frmProgress3.Close();
         
        }

        private void Search(String searchText)
        {

            displayProgress();
            // SiteMap

            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = false;
            lnkviewcategoriesType.Visible = false;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            mainListview.Visible = false;

            lnkviewcategoriesType.Text = "SEARCH";
            String Data = get_productSearch(searchText);
            StringReader theReader = new StringReader(Data);
           DataSet  dtProdcutListTypeImage = new DataSet ();
           dtProdcutListTypeImage.ReadXml(theReader);

            
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();
            String ProductTypeDetailsName = String.Empty;
            // SiteMap

            imageLstProduct.Images.Clear();
            Int16 Count = 0;

            for (int i = 0; i < dtProdcutListTypeImage.Tables[0].Rows.Count; i++)
            {
                
                    Count = Convert.ToInt16(Count + 1);

                    ProductTypeDetailsName = dtProdcutListTypeImage.Tables[0].Rows[i]["catalog_web_name"].ToString();

                    String ProductTypeDetailsImage = dtProdcutListTypeImage.Tables[0].Rows[i]["catalog_thumbnail_url"].ToString();

                    string urlfolder = string.Empty;
                    string[] bits = ProductTypeDetailsImage.Split('_');
                    foreach (string bit in bits)
                    {
                        urlfolder = bit;
                        break;
                    }
                    string rangeurlimg = urlrangeimg + urlfolder + "/" + ProductTypeDetailsImage;


                    lstProductListImage.Visible = false;
                    lstProductTypeImage.Visible = false;
                    groupBox1.Visible = false;
                    lstProductTypeDetailsImage.Visible = true;

                    imageLstProduct.Images.Add(LoadImage(rangeurlimg));
                    lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                    imageLstProduct.ImageSize = new Size(150, 150);
                    lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                    lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                    lstProductTypeDetailsImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                    lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
                    lstProductTypeDetailsImage.LabelWrap = true;
                    lblMessage.Text = "";
            }

            if (ProductTypeDetailsName == String.Empty)
            {
                //frmProgress3.Close();
              
                //// SiteMap
                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;
                //// SiteMap
                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;
                //dsProduct = new DataSet();
                //DisplayProductImage();
               
                lblMessage.Text = "No records found for '" + searchText + "'";

            }

            frmProgress3.Close();
       
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {

            }
            // Search();
            else
            {
                Search(txtSearch.Text);
            }
                
        }

        #endregion

        #region Image Navigation
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (selected == arr.Count - 1)
            {
                selected = 0;
                PictureViewmage.ImageLocation = arr[selected].ToString();
                PictureViewmage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                selected = selected + 1;
                PictureViewmage.ImageLocation = arr[selected].ToString();
                PictureViewmage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                selected = arr.Count - 1;
                PictureViewmage.ImageLocation = arr[selected].ToString();
                PictureViewmage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                selected = selected - 1;
                PictureViewmage.ImageLocation = arr[selected].ToString();
                PictureViewmage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        #endregion

        private void mainListview_SelectedIndexChanged(object sender, EventArgs e)
        {

            String SelectedProductName = mainListview.SelectedItems[0].Text.ToString();
          

            mainListview.Visible = false;
            lstProductListImage.Visible = true;
            lblProductList.Visible = true;
            lblCategories.Text = "CATEGORIES";
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            //displaylstProductList(SelectedProductName);
         
              for (int i = 0; i < lstButtons.Count; i++)
            {
                  

                if (lstButtons[i].Text == SelectedProductName)
                {

                    lstButtons[i].PerformClick();
                }
            }
        }

        private void DisplayProductTypeFirstSectionSearch(String ProductName)
        {
            SearchImageArrayIcon.Images.Clear();
            imageListProductTypeSearch.Clear();

            DataTable tableProductType = dsProduct.Tables[3];

            tableProductType.DefaultView.RowFilter = "Isdeleted = 'False' and parent_category_name ='" +ProductName + "'";
            tableProductType = tableProductType.DefaultView.ToTable();
            var filePaths = from row in tableProductType.AsEnumerable()
                            select row.Field<string>("ProductTypeName");
            var filePathsArray = filePaths.ToList();
            
            for (int i = 0; i < filePathsArray.Count; i++)
            {

                String ProductTypeNamee = tableProductType.Rows[i]["ProductTypeName"].ToString();
                String ProductTypeImagee = tableProductType.Rows[i]["ProductTypeIcon"].ToString();
                if (ProductTypeImagee == "")
                {
                    SearchImageArrayIcon.Images.Add(LoadImage(ProductTypeImagee));
                }
                else {

                    SearchImageArrayIcon.Images.Add(LoadImage(linkiconimg + ProductTypeImagee));
                }
                imageListProductTypeSearch.View = System.Windows.Forms.View.LargeIcon;
                SearchImageArrayIcon.ImageSize = new Size(32, 32);
                imageListProductTypeSearch.LargeImageList = SearchImageArrayIcon;

                imageListProductTypeSearch.Items.Add(ProductTypeNamee, i);
                imageListProductTypeSearch.Items[i].ForeColor = System.Drawing.Color.Black;
                imageListProductTypeSearch.Items[i].Font = new System.Drawing.Font(MYpfc.Families[0], 8, System.Drawing.FontStyle.Regular);

            }
        
        }

        private void DisplayProductSecondSectionSearch(Int16 ProductSeachTablename, String ProductSeachSectionHeader,String ProductNamee) 
        {
            imgtype.Images.Clear();
            Traptypelstview.Clear();

            DataTable tableProductType = dsProduct.Tables[ProductSeachTablename];
            tableProductType.DefaultView.RowFilter = "Isdeleted = 'False'";
            DataRow[] foundRows;
            tableProductType.CaseSensitive = false;
            foundRows = tableProductType.Select("Parent_Category_name = '" + ProductNamee + "'");

            for (int i = 0; i < foundRows.Length; i++)
            {
                String ProductTypeNamee = foundRows[i][1].ToString();
                String ProductTypeImagee = foundRows[i][3].ToString();
                if (ProductTypeImagee == "")
                {
                    imgtype.Images.Add(LoadImage(ProductTypeImagee));
                }
                else
                {

                    imgtype.Images.Add(LoadImage(linkiconimg + ProductTypeImagee));
                }
                
                Traptypelstview.View = System.Windows.Forms.View.LargeIcon;
                imgtype.ImageSize = new Size(32, 32);
                Traptypelstview.LargeImageList = imgtype;

                Traptypelstview.Items.Add(ProductTypeNamee, i);
                Traptypelstview.Items[i].ForeColor = System.Drawing.Color.Black;
                Traptypelstview.Items[i].Font = new System.Drawing.Font(MYpfc.Families[0], 8, System.Drawing.FontStyle.Regular);
            }
            trapTypeGB.Text = ProductSeachSectionHeader;

        }

        private void DisplayProductThirdSectionSearch(Int16 ProductSeachTableIndex, String ProductSeachSectionHeader, String ProductNamee)
        {
            inletimg.Images.Clear();
            iuletTypelistview.Clear();

            DataTable tableProductType = dsProduct.Tables[ProductSeachTableIndex];
            tableProductType.DefaultView.RowFilter = "Isdeleted = 'False'";
            DataRow[] foundRows;
            tableProductType.CaseSensitive = false;
            foundRows = tableProductType.Select("Parent_Category_name = '" + ProductNamee + "'");

            for (int i = 0; i < foundRows.Length; i++)
            {
                String ProductTypeNamee = foundRows[i][1].ToString();
                String ProductTypeImagee = foundRows[i][3].ToString();
                if (ProductTypeImagee == "")
                {
                    inletimg.Images.Add(LoadImage(ProductTypeImagee));
                }
                else
                {

                    inletimg.Images.Add(LoadImage(linkiconimg + ProductTypeImagee));
                }
               

                iuletTypelistview.View = System.Windows.Forms.View.LargeIcon;
                inletimg.ImageSize = new Size(32, 32);
                iuletTypelistview.LargeImageList = inletimg;

                iuletTypelistview.Items.Add(ProductTypeNamee, i);
                iuletTypelistview.Items[i].ForeColor = System.Drawing.Color.Black;
                iuletTypelistview.Items[i].Font = new System.Drawing.Font(MYpfc.Families[0], 8, System.Drawing.FontStyle.Regular);
            }
            inletTypeGB.Text = ProductSeachSectionHeader;

        }

        private void DisplayProductFourthSectionSearch(Int16 ProductSeachTableIndex, String ProductSeachSectionHeader, String ProductNamee)
        {
            colorImgListArray.Images.Clear();
            colorListView.Clear();

            DataTable tableProductType = dsProduct.Tables[ProductSeachTableIndex];
            tableProductType.DefaultView.RowFilter = "Isdeleted = 'False'";
            DataRow[] foundRows;
            tableProductType.CaseSensitive = false;
            foundRows = tableProductType.Select("Parent_Category_name = '" + ProductNamee + "'");

            for (int i = 0; i < foundRows.Length; i++)
            {
                String ProductTypeNamee = foundRows[i][1].ToString();
                String ProductTypeImagee = foundRows[i][3].ToString();
                if (ProductTypeImagee == "")
                {
                    colorImgListArray.Images.Add(LoadImage(ProductTypeImagee));
                }
                else
                {

                    colorImgListArray.Images.Add(LoadImage(linkiconimg + ProductTypeImagee));
                }
               
                colorListView.View = System.Windows.Forms.View.LargeIcon;
                colorImgListArray.ImageSize = new Size(32, 32);
                colorListView.LargeImageList = colorImgListArray;

                colorListView.Items.Add(ProductTypeNamee, i);
                colorListView.Items[i].ForeColor = System.Drawing.Color.Black;
                colorListView.Items[i].Font = new System.Drawing.Font(MYpfc.Families[0], 8, System.Drawing.FontStyle.Regular);
            }
            ColorGB.Text = ProductSeachSectionHeader;
        }

        private void DisplayRangeimage(String SelectedrangenameName) // Product Type 
        {
            displayProgress();
            // SiteMap
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = true;
            lnkviewcategoriesType.Visible = true;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            lnkviewcategoriesType.Text = SelectedrangenameName.ToUpper();
            DataTable dtProdcutListTypeImage = dsProduct.Tables[1];
            String CategorieName = lnkCatagories.Text;
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();
            String ProductTypeDetailsName = String.Empty;
            // SiteMap

            imageLstProduct.Images.Clear();
            Int16 Count = 0;
            for (int i = 0; i < dsProduct.Tables[1].Rows.Count; i++)
            {
                String GetProductTypeName = dsProduct.Tables[1].Rows[i]["parent_category_name"].ToString();
                String GetRangeName = dsProduct.Tables[1].Rows[i]["range_name"].ToString();

                if ((string.Equals(CategorieName, GetProductTypeName, StringComparison.OrdinalIgnoreCase)) && (string.Equals(SelectedrangenameName, GetRangeName, StringComparison.OrdinalIgnoreCase)))
                {

                    //Count = Convert.ToInt16(Count + 1);
                    Count = Convert.ToInt16(Count + 1);

                    ProductTypeDetailsName = dsProduct.Tables[1].Rows[i]["catalog_web_name"].ToString();
                    
                    String ProductTypeDetailsImage = dsProduct.Tables[1].Rows[i]["catalog_thumbnail_url"].ToString();

                    string urlfolder = string.Empty;
                    string[] bits = ProductTypeDetailsImage.Split('_');
                    foreach (string bit in bits)
                    {
                        urlfolder = bit;
                        break;
                    }
                    string rangeurlimg = urlrangeimg + urlfolder + "/" + ProductTypeDetailsImage;


                    lstProductListImage.Visible = false;
                    lstProductTypeImage.Visible = false;
                    groupBox1.Visible = false;
                    lstProductTypeDetailsImage.Visible = true;

                    imageLstProduct.Images.Add(LoadImage(rangeurlimg));
                    lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                    imageLstProduct.ImageSize = new Size(150, 150);
                    lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                    lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                    lstProductTypeDetailsImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                    lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
                    lstProductTypeDetailsImage.LabelWrap = true;
                    lblMessage.Text = "";
                }
            }

            if (ProductTypeDetailsName == String.Empty)
            {

                // SiteMap

                //lblSiteProducts.Visible = false;
                //lnkCatagories.Visible = false;
                //lblsiteCategories.Visible = false;
                //lnkviewcategoriesType.Visible = false;
                //lblviewtypeimage.Visible = false;
                //lnkviewCatagoriesTypeImages.Visible = false;

                //// SiteMap

                //lstProductTypeImage.Visible = false;
                //lstProductTypeDetailsImage.Visible = false;
                //groupBox1.Visible = false;
                //lstProductListImage.Visible = true;

                //dsProduct = new DataSet();
                //DisplayProductImage();
                //frmProgress3.Close();
                
                lblMessage.Text = "No records found for '" + SelectedrangenameName + "'";
            }
            frmProgress3.Close();
         

        }

        private void searchProductCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainListview.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            lblProductList.Visible = true;
            lblCategories.Text = "CATEGORIES";

            String ProductName = searchProductCombo.SelectedItem.ToString();
            for (int i = 0; i < lstButtons.Count; i++)
            {
                  if ((string.Equals(lstButtons[i].Text, ProductName, StringComparison.OrdinalIgnoreCase)) )
                {
                    lstButtons[i].PerformClick();
                }
            }

            DataRow[] foundRows;
            DataTable tableProductType = dsProduct.Tables[2];
            tableProductType.CaseSensitive = false;
            foundRows = tableProductType.Select("Parent_Category_name = '" + ProductName + "'");

            //tableProductType = tableProductType.DefaultView.ToTable();
            //var filePaths = from row in tableProductType.AsEnumerable()
            //                select row.Field<string>("ProductTrapTypeName");
            //var filePathsArray = filePaths.ToList();
            ColorGB.Visible = false;
            inletTypeGB.Visible = false;
            trapTypeGB.Visible = false;
            productTypeGB.Visible = false;
            for (Int16 t = 0; t < foundRows.Length; t++)
            {
                Int16 ProductSeachTablename = Convert.ToInt16(foundRows[t].ItemArray[2].ToString());
                String ProductSeachSectionHeader = foundRows[t].ItemArray[1].ToString();
                    if (ProductSeachSectionHeader == "PRODUCT TYPE")
                    {
                        imageListProductTypeSearch.Size=new Size(281,141);
                        productTypeGB.Size = new Size(292, 165);
                        productTypeGB.Visible = true;
                        DisplayProductTypeFirstSectionSearch(ProductName);
                        SaveBtnSearch.Visible = true;
                        CancelSearch.Visible = true;
                  
                    }
                    else if (t == 1)
                    {
                        trapTypeGB.Visible = true;
                        DisplayProductSecondSectionSearch(ProductSeachTablename, ProductSeachSectionHeader, ProductName);
                        inletTypeGB.Visible = false;
                    }
                    else if (t == 2)
                    {
                        inletTypeGB.Visible = true;
                        DisplayProductThirdSectionSearch(ProductSeachTablename, ProductSeachSectionHeader, ProductName);
                        ColorGB.Visible = false;
                        bathseekgb.Location = new System.Drawing.Point(5, 660);
                        gpseekbar.Location = new System.Drawing.Point(5, 639);
                        SaveBtnSearch.Location = new System.Drawing.Point(55, 670);
                        CancelSearch.Location = new System.Drawing.Point(150, 670);
                    }
                    else if (t == 3)
                    {

                        ColorGB.Visible = true;
                        DisplayProductFourthSectionSearch(ProductSeachTablename, ProductSeachSectionHeader, ProductName);
                        bathseekgb.Location = new System.Drawing.Point(5, 790);
                        //gpseekbar.Location = new System.Drawing.Point(6, 751);
                        SaveBtnSearch.Location = new System.Drawing.Point(55, 800);
                        CancelSearch.Location = new System.Drawing.Point(150, 800);
                    }
            }

            string cond = searchProductCombo.SelectedItem.ToString();
            if (cond == "TOILET SUITES")
            {
                gpseekbar.Visible = true;
                bathseekgb.Visible = false;
                gpseekbar.Location = new System.Drawing.Point(6, 600);
                SaveBtnSearch.Location = new System.Drawing.Point(55, 900);
                CancelSearch.Location = new System.Drawing.Point(150,900);
            }
            else if (cond == "BATHS")
            {
                gpseekbar.Visible = false;
                bathseekgb.Visible = true;
                SaveBtnSearch.Location = new System.Drawing.Point(55, 900);
                CancelSearch.Location = new System.Drawing.Point(150, 900);
            }
            else if (cond == "BATHROOM ACCESSORIES")
            {
                imageListProductTypeSearch.Size = new Size(281, 460);
                productTypeGB.Size = new Size(292, 480);
                gpseekbar.Visible = false;
                bathseekgb.Visible = false;
            }

            else {

                gpseekbar.Visible = false;
                bathseekgb.Visible = false;
            
            }
           
            productTypeGB.Focus();
        }
        
        private void iuletTypelistview_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void SaveBtnSearch_Click(object sender, EventArgs e)
        {
            Int16 count = Convert.ToInt16(imageListProductTypeSearch.CheckedItems.Count);
            Int16 count1 = Convert.ToInt16(Traptypelstview.CheckedItems.Count);
            Int16 count2 = Convert.ToInt16(iuletTypelistview.CheckedItems.Count);
            Int16 count3 = Convert.ToInt16(colorListView.CheckedItems.Count);
            SearchCriteria = new List<string>();
            Int16 ProdictId = 0;
            String FirstSection = String.Empty;
            String SecondSection = String.Empty;
            String ThirdSection = String.Empty;
            String FourthSection = String.Empty;
            String FirstSectionQuery = String.Empty;
            String SecondSectionQuery = String.Empty;
            String ThirdSectionQuery = String.Empty;
            String FourthSectionQuery = String.Empty;
            String StrProduct = searchProductCombo.SelectedItem.ToString();

            for (Int16 b = 0; b < dsProduct.Tables[0].Rows.Count; b++)
            {
                String Str = dsProduct.Tables[0].Rows[b]["category_name"].ToString();
                if (String.Equals(Str, searchProductCombo.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    ProdictId = Convert.ToInt16(dsProduct.Tables[0].Rows[b]["category_id"]);
                    break;
                }
            }

            if (count > 0)
            {
                //Int16 ProductId = searchProductCombo
                FirstSection = productTypeGB.Text;
                FirstSectionQuery = "SELECT distinct catalog_id   FROM [mv_web_view_catalog_attributes] where category_parent_id=" + ProdictId + "";
                FirstSectionQuery += " and attribute_label='" + FirstSection + "' and ";
                for (Int16 b = 0; b < count; b++)
                {
                    FirstSectionQuery += " CONVERT(NVARCHAR(MAX), value) ='" + imageListProductTypeSearch.CheckedItems[b].Text + "' or ";
                }
                FirstSectionQuery = FirstSectionQuery.Remove(FirstSectionQuery.Length - 3);
                FirstSectionQuery = FirstSectionQuery + ";";
            }

            if (count1 > 0)
            {
                if (FirstSectionQuery != String.Empty)
                {
                    FirstSectionQuery = FirstSectionQuery.Remove(FirstSectionQuery.Length - 1);
                    FirstSectionQuery = FirstSectionQuery + "";
                }

                SecondSection = trapTypeGB.Text;
                SecondSectionQuery = "SELECT distinct catalog_id  FROM [mv_web_view_catalog_attributes] where category_parent_id=" + ProdictId + "";
                SecondSectionQuery += " and attribute_label='" + SecondSection + "' and ";

                for (Int16 b = 0; b < count1; b++)
                {
                    SecondSectionQuery += " CONVERT(NVARCHAR(MAX), value) ='" + Traptypelstview.CheckedItems[b].Text + "' or ";
                }

                SecondSectionQuery = SecondSectionQuery.Remove(SecondSectionQuery.Length - 3);
                SecondSectionQuery = SecondSectionQuery + ";";
            }

            if (count2 > 0)
            {
                if (SecondSectionQuery != String.Empty)
                {
                    SecondSectionQuery = SecondSectionQuery.Remove(SecondSectionQuery.Length - 1);
                    SecondSectionQuery = SecondSectionQuery + "";
                }
                ThirdSection = inletTypeGB.Text;
                ThirdSectionQuery = "SELECT  distinct catalog_id  FROM [mv_web_view_catalog_attributes] where category_parent_id=" + ProdictId + "";
                ThirdSectionQuery += " and attribute_label='" + ThirdSection + "' and ";
                for (Int16 b = 0; b < count2; b++)
                {
                    ThirdSectionQuery += " CONVERT(NVARCHAR(MAX), value) ='" + iuletTypelistview.CheckedItems[b].Text + "' or ";
                }
                ThirdSectionQuery = ThirdSectionQuery.Remove(ThirdSectionQuery.Length - 3);
                ThirdSectionQuery = ThirdSectionQuery + ";";
            }

            if (count3 > 0)
            {
                if (ThirdSectionQuery != String.Empty)
                {
                    ThirdSectionQuery = ThirdSectionQuery.Remove(ThirdSectionQuery.Length - 1);
                    ThirdSectionQuery = ThirdSectionQuery + "";
                }
                FourthSection = ColorGB.Text;
                FourthSectionQuery = "SELECT  distinct catalog_id FROM [mv_web_view_catalog_attributes] where category_parent_id=" + ProdictId + "";
                FourthSectionQuery += " and attribute_label='" + FourthSection + "' and ";

                for (Int16 b = 0; b < count3; b++)
                {
                    FourthSectionQuery += " CONVERT(NVARCHAR(MAX), value) ='" + colorListView.CheckedItems[b].Text + "' or ";
                }
                FourthSectionQuery = FourthSectionQuery.Remove(FourthSectionQuery.Length - 3);
                FourthSectionQuery = FourthSectionQuery + ";";
            }

            String FinalQuery = FirstSectionQuery + SecondSectionQuery + ThirdSectionQuery + FourthSectionQuery;

            String getoutput = get_productTypeSearch(FinalQuery, StrProduct);
            dsProducttypesearch = new DataSet();
            if (getoutput == String.Empty)
            {
                displaylstProductTypeImage(dsProducttypesearch);
                lblFilterResult.Text = "0" + " STYLES FOUND";
            }
            else
            {
            

                StringReader theReader = new StringReader(getoutput);
                dsProducttypesearch.ReadXml(theReader);
                displaylstProductTypeImage(dsProducttypesearch);
                lblFilterResult.Text = dsProducttypesearch.Tables[0].Rows.Count.ToString() + " STYLES FOUND";

            }
            

        }

        private void displaylstProductTypeImagesearch(List<String>  SearchCriteria)
        {

            displayProgress();
            mainListview.Visible = false;

            // SiteMap
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = true;
            lnkviewcategoriesType.Visible = true;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;

            //lnkviewcategoriesType.Text = SelectedProductTypeName.ToUpper();

            Int16 SelectedProductTypeID = 0;
            DataTable dtProdcutListTypeImage = dsProduct.Tables[2];
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();
            String ProductTypeDetailsName = String.Empty;
            // SiteMap
            String SelectedProductTypeName = "";
            imageLstProduct.Images.Clear();
            foreach (String author in SearchCriteria)
            {
                SelectedProductTypeName = author;
                  for (int i = 0; i < dsProduct.Tables[2].Rows.Count; i++)
                {
                    String GetProductTypeName = dsProduct.Tables[2].Rows[i]["ProductDetailsName"].ToString();
                //if (string.Equals(SelectedProductTypeName, GetProductTypeName, StringComparison.OrdinalIgnoreCase))

                bool b;
                b = GetProductTypeName.Contains(SelectedProductTypeName);
                if(b)
                {

                    SelectedProductTypeID = Convert.ToInt16(dsProduct.Tables[1].Rows[i]["ProductTypeID"]);

                    Int16 Count = 0;
                    //Count = Convert.ToInt16(Count + 1);
                    for (int j = 0; j < dtProdcutListTypeImage.Rows.Count; j++)
                    {
                        if (SelectedProductTypeID == Convert.ToInt16(dsProduct.Tables[2].Rows[j]["ProductTypeID"]))
                        {
                            Count = Convert.ToInt16(Count + 1);
                            ProductTypeDetailsName = dsProduct.Tables[2].Rows[j]["ProductDetailsName"].ToString();
                            String ProductTypeDetailsImage = dsProduct.Tables[2].Rows[j]["ProductDetailsImage"].ToString();
                            Int16 ProductTypeDetailsID = Convert.ToInt16(dsProduct.Tables[2].Rows[j]["ProductDetailsID"].ToString());

                            lstProductListImage.Visible = false;
                            lstProductTypeImage.Visible = false;
                            groupBox1.Visible = false;
                            lstProductTypeDetailsImage.Visible = true;

                            imageLstProduct.Images.Add(LoadImage(ProductTypeDetailsImage));
                            lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                            imageLstProduct.ImageSize = new Size(130, 150);
                            lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                            lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                            lstProductTypeDetailsImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                            lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
                            lstProductTypeDetailsImage.LabelWrap = true;
                            lblMessage.Text = "";

                        }
                    }
                    break;
                }
            }

        }

            if (ProductTypeDetailsName == String.Empty)
            {

                // SiteMap

                lblSiteProducts.Visible = false;
                lnkCatagories.Visible = false;
                lblsiteCategories.Visible = false;
                lnkviewcategoriesType.Visible = false;
                lblviewtypeimage.Visible = false;
                lnkviewCatagoriesTypeImages.Visible = false;

                // SiteMap

                lstProductTypeImage.Visible = false;
                lstProductTypeDetailsImage.Visible = false;
                groupBox1.Visible = false;
                lstProductListImage.Visible = true;

                dsProduct = new DataSet();
                DisplayProductImage();
                frmProgress3.Close();
               
                lblMessage.Text = "No records found for '" + SelectedProductTypeName + "'";
            }


            frmProgress3.Close();
         

        }

        public String get_productTypeSearch(String value, String ProductName)
        {
            String getData = String.Empty;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "CaromaSoap";
                binding.CloseTimeout = System.TimeSpan.Parse("00:10:00");

                binding.OpenTimeout = System.TimeSpan.Parse("00:10:00");
                binding.ReceiveTimeout = System.TimeSpan.Parse("00:10:00");
                binding.SendTimeout = System.TimeSpan.Parse("00:10:00");

                binding.AllowCookies = false;
                binding.BypassProxyOnLocal = false;
                binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;

                binding.MaxBufferSize = 28454546;
                binding.MaxBufferPoolSize = 28454546;
                binding.MaxReceivedMessageSize = 28454546;

                binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = System.ServiceModel.TransferMode.Buffered;

                binding.UseDefaultWebProxy = true;
                binding.ReaderQuotas.MaxDepth = 28454546;
                binding.ReaderQuotas.MaxStringContentLength = 28454546;

                binding.ReaderQuotas.MaxArrayLength = 28454546;
                binding.ReaderQuotas.MaxBytesPerRead = 28454546;
                binding.ReaderQuotas.MaxNameTableCharCount = 28454546;

                binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                binding.Security.Transport.Realm = "";
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress endpoint = new EndpointAddress("http://caroma.designcontent.com.au/Caroma.asmx?wsdl");
                CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient(binding, endpoint);
                getData = objService._getProductTypeSearch(value, ProductName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Check your Internet Connection.");
            }
            return getData;
        }

        private void displaylstProductTypeImage(DataSet SelectedProductTypeName)
        {

            displayProgress();
            // SiteMap
            lblSiteProducts.Visible = true;
            lnkCatagories.Visible = true;
            lblsiteCategories.Visible = true;
            lnkviewcategoriesType.Visible = true;
            lblviewtypeimage.Visible = false;
            lnkviewCatagoriesTypeImages.Visible = false;
            mainListview.Visible = false;
            // lnkviewcategoriesType.Text = SelectedProductTypeName.ToUpper();


            DataTable dtProdcutListTypeImage = dsProduct.Tables[1];
            String CategorieName = lnkCatagories.Text;
            imageLstProduct.Images.Clear();
            lstProductTypeDetailsImage.Clear();
            String ProductTypeDetailsName = String.Empty;
            // SiteMap
            lblFilterResult.Visible = true;
            
            imageLstProduct.Images.Clear();
            Int16 Count = 0;
            if (SelectedProductTypeName != null && SelectedProductTypeName.Tables.Count > 0)
            {
                if (SelectedProductTypeName.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < SelectedProductTypeName.Tables[0].Rows.Count; i++)
                    {
                        // String GetProductTypeName = SelectedProductTypeName.Tables[0].Rows[i]["parent_category_name"].ToString();

                        //Count = Convert.ToInt16(Count + 1);
                        Count = Convert.ToInt16(Count + 1);

                        ProductTypeDetailsName = SelectedProductTypeName.Tables[0].Rows[i]["catalog_web_name"].ToString();
                        String ProductTypeDetailsImage = SelectedProductTypeName.Tables[0].Rows[i]["catalog_thumbnail_url"].ToString();

                        string urlfolder = string.Empty;
                        string[] bits = ProductTypeDetailsImage.Split('_');
                        foreach (string bit in bits)
                        {
                            urlfolder = bit;
                            break;
                        }
                        string rangeurlimg = urlrangeimg + urlfolder + "/" + ProductTypeDetailsImage;

                        lstProductListImage.Visible = false;
                        lstProductTypeImage.Visible = false;
                        groupBox1.Visible = false;
                        lstProductTypeDetailsImage.Visible = true;

                        imageLstProduct.Images.Add(LoadImage(rangeurlimg));
                        lstProductTypeDetailsImage.View = System.Windows.Forms.View.LargeIcon;
                        imageLstProduct.ImageSize = new Size(150, 150);
                        lstProductTypeDetailsImage.LargeImageList = imageLstProduct;
                        lstProductTypeDetailsImage.Items.Add(ProductTypeDetailsName, Count - 1);
                        lstProductTypeDetailsImage.Items[Count - 1].ForeColor = System.Drawing.Color.FromArgb(0, 196, 220);
                        lstProductTypeDetailsImage.Items[Count - 1].Font = new System.Drawing.Font(MYpfc.Families[0], 9, System.Drawing.FontStyle.Regular);
                        lstProductTypeDetailsImage.LabelWrap = true;
                    }
                }
                else
                {
                    lstProductTypeDetailsImage.Visible = true;
                }
            }

            else
            {
                lstProductTypeDetailsImage.Visible = true;
            }

            //if (ProductTypeDetailsName == String.Empty)
            //{

            //    // SiteMap

            //    lblSiteProducts.Visible = false;
            //    lnkCatagories.Visible = false;
            //    lblsiteCategories.Visible = false;
            //    lnkviewcategoriesType.Visible = false;
            //    lblviewtypeimage.Visible = false;
            //    lnkviewCatagoriesTypeImages.Visible = false;

            //    // SiteMap

            //    lstProductTypeImage.Visible = false;
            //    lstProductTypeDetailsImage.Visible = false;
            //    groupBox1.Visible = false;
            //    lstProductListImage.Visible = true;

            //    dsProduct = new DataSet();
            //    DisplayProductImage();
            //    frmProgress3.Close();
            //    lblMessage.Text = "No records found for '" + SelectedProductTypeName + "'";
            //}


            frmProgress3.Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void get_RevitDownloadCount()
        {
            String getData = String.Empty;
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Name = "CaromaSoap";
                binding.CloseTimeout = System.TimeSpan.Parse("00:10:00");

                binding.OpenTimeout = System.TimeSpan.Parse("00:10:00");
                binding.ReceiveTimeout = System.TimeSpan.Parse("00:10:00");
                binding.SendTimeout = System.TimeSpan.Parse("00:10:00");

                binding.AllowCookies = false;
                binding.BypassProxyOnLocal = false;
                binding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;

                binding.MaxBufferSize = 28454546;
                binding.MaxBufferPoolSize = 28454546;
                binding.MaxReceivedMessageSize = 28454546;

                binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = System.ServiceModel.TransferMode.Buffered;

                binding.UseDefaultWebProxy = true;
                binding.ReaderQuotas.MaxDepth = 28454546;
                binding.ReaderQuotas.MaxStringContentLength = 28454546;

                binding.ReaderQuotas.MaxArrayLength = 28454546;
                binding.ReaderQuotas.MaxBytesPerRead = 28454546;
                binding.ReaderQuotas.MaxNameTableCharCount = 28454546;

                binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                binding.Security.Transport.Realm = "";
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress endpoint = new EndpointAddress("http://caroma.designcontent.com.au/Caroma.asmx?wsdl");
                CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient(binding, endpoint);
                 objService.downloadCount();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please Check your Internet Connection.");
            }
           
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar)sender;

            myTB.Text = myTB.Value.ToString();
            label13.Text = trackBar8.Value.ToString();
     
        }

        private void productDetClose_Click(object sender, EventArgs e)
        {
            String str = lnkviewcategoriesType.Text;

            DisplayRangeimage(str);
        }

    }
}
