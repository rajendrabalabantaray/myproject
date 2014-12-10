using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caroma
{
    public partial class frmLogin : Form
    {
        public static ExternalCommandData commandata1;
        public static Autodesk.Revit.DB.ElementSet elements1;
        string message1;
        public frmLogin(ExternalCommandData commandata2, ref string mess, Autodesk.Revit.DB.ElementSet ele)
        {
            InitializeComponent();
            commandata1 = commandata2;
            elements1 = ele;
            message1 = mess;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }


        public Boolean RunServiceMethod()
        {

             Boolean Status = false;
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

                binding.MaxBufferSize = 65536;
                binding.MaxBufferPoolSize = 524288;
                binding.MaxReceivedMessageSize = 65536;

                binding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
                binding.TextEncoding = System.Text.Encoding.UTF8;
                binding.TransferMode = System.ServiceModel.TransferMode.Buffered;

                binding.UseDefaultWebProxy = true;
                binding.ReaderQuotas.MaxDepth = 32;
                binding.ReaderQuotas.MaxStringContentLength = 8192;

                binding.ReaderQuotas.MaxArrayLength = 16384;
                binding.ReaderQuotas.MaxBytesPerRead = 4096;
                binding.ReaderQuotas.MaxNameTableCharCount = 16384;

                binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

                binding.Security.Transport.Realm = "";
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

                EndpointAddress endpoint = new EndpointAddress("http://caroma.designcontent.com.au/Caroma.asmx?wsdl");
                CaromaService.CaromaSoapClient objService = new CaromaService.CaromaSoapClient(binding, endpoint);
                Status = objService._getAuthentication(ClsProperties.Username, ClsProperties.Password);
            }
               
            catch (Exception ex)
            {
                 MessageBox.Show("Please Check your Internet Connection.");
            }

            return Status;
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == String.Empty)
            {
                MessageBox.Show("Please input UserName");
                txtUserName.Focus();
            }

            else if (txtPassword.Text == String.Empty)
            {
               MessageBox.Show("Please input Password");
                txtPassword.Focus();
            }
            else
            {
                ClsProperties.Username = "admin";
                ClsProperties.Password = "Welcome@123";
                Boolean Status = false;
                try
                {
                    Status = RunServiceMethod();
                    if (Status)
                    {

                     

                        //FrmProduct objProduct = new FrmProduct(commandata1, ref message1, elements1);
                        //objProduct.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserName or Password.");
                        txtPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Check your Internet Connection.");
                }

                finally
                {

                }
            }
        }
    }
}
