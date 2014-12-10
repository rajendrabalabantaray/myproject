
using System.Security;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caroma
{
    [Transaction(TransactionMode.Manual)]
  public  class downloadpicker:IExternalCommand
    {
        string Familyname = "bathRoom";
        static string _family_folder = Path.GetDirectoryName(typeof(Command).Assembly.Location);
        string FamilyPath = Path.GetFullPath(@"C:\rfadownload\Caroma_Marc Newson Invisi Wall Hung Suite.rfa");

        public Result Execute()//, Autodesk.Revit.DB.ElementSet elements , ref string message
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;

         Autodesk.Revit.DB.Document doc = uidoc.Document;

            // Retrieve elements from database
          
            FilteredElementCollector a = new FilteredElementCollector(doc).OfClass(typeof(Family));

            Family family = a.FirstOrDefault<Element>(e => e.Name.Equals(Familyname)) as Family;

            // Filtered element collector is iterable

            if (null == family)
            {
                // It is not present, so check for 
                // the file to load it from:

                if (!File.Exists(FamilyPath))
                {
                    //System.Security.Util.ErrorMsg(string.Format("Please ensure that the sample table " + "family file '{0}' exists in '{1}'.",Familyname, _family_folder));

                    return Result.Failed;
                }

                // Load family from file:

                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Load Family");
                    doc.LoadFamily(FamilyPath, out family);

                    tx.Commit();
                }

                //Application app1 = new Application();
                //Document doc1 = app1.OpenDocumentFile(FamilyPath,);
                System.Diagnostics.Process.Start(FamilyPath);



                //               FamilySymbol symbol = null;

                //foreach( FamilySymbol s in family.Symbols )
                //{
                //  symbol = s;

                //  // Our family only contains one
                //  // symbol, so pick it and leave

                //  break;
                //}

                // Place the family symbol:

                // PromptForFamilyInstancePlacement cannot 
                // be called inside transaction.

                //uidoc.PromptForFamilyInstancePlacement(symbol);

                //           UIApplication uiapp1 = commandData.Application;
                //           UIDocument uidoc1 = uiapp1.ActiveUIDocument;

                //           Application app1 = uiapp1.Application;
                //Document doc1 = app1.OpenDocumentFile(FamilyPath);
            }
            // Modify document within a transaction
            
         


            return Result.Succeeded;
        }
    }
}
