using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Caroma
{
    class App : IExternalApplication
    {
        RibbonPanel ribbonPanel;
        RibbonPanel ribbonPanel2;
        RibbonPanel ribbonPanel1;
        PushButton pushButton;
        PushButton pushButton2;
        RibbonItem _button;
        public static string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string assyPath = Path.Combine(dir, "Caroma.dll");
        public Result OnStartup(UIControlledApplication a)
        {
         
            // Create a custom ribbon tab
            String tabName = "Caroma";
            a.CreateRibbonTab(tabName);

           
            ribbonPanel1 = a.CreateRibbonPanel(tabName, "Caroma Products");

            // Create a push button to trigger a command add it to the ribbon panel.
            // string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;




            PushButtonData buttonData1 = new PushButtonData("Caroma", "Caroma Products", assyPath, "Caroma.Command");
            PushButton pushButton1 = ribbonPanel1.AddItem(buttonData1) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
          
            pushButton1.ToolTip = "Caroma Products";



            Uri uriImage1 = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/icon1.png");
            BitmapImage largeImage1 = new BitmapImage(uriImage1);


            Uri urismall1 = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/icon1s.png");
            BitmapImage smallimg1 = new BitmapImage(urismall1);
            pushButton1.LargeImage = smallimg1;
            pushButton1.ToolTipImage = largeImage1;
            
       

           
          

            return Result.Succeeded;
        }

      
        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

       
    


    }
}
