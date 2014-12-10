using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caroma
{
    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            FrmProduct objproduct = new FrmProduct(commandData, ref message, elements);
            objproduct.ShowDialog();
            if (ClsProperties.download)
            {
                CmdPlaceFamilyInstance objcmd = new CmdPlaceFamilyInstance();
                objcmd.Execute(commandData, ref message, elements);
            }
            return Result.Succeeded;

        }
    }

   



    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class CmdPlaceFamilyInstance : IExternalCommand
    {

        FamilySymbol symbol1;
        string FamilyPath = Path.GetFullPath(@"C:\Temp\" + ClsProperties.filename + ".rfa");
        string Familyname = ClsProperties.filename;
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData,ref string message, ElementSet elements)
            
        {
            
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

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
                    // System.Security.Util.ErrorMsg(string.Format("Please ensure that the sample table " + "family file '{0}' exists in '{1}'.",Familyname, _family_folder));

                    return Result.Failed;
                }

                // Load family from file:

                using (Transaction tx = new Transaction(doc))
                {
                    tx.Start("Load Family");
                    doc.LoadFamily(FamilyPath, out family);

                    tx.Commit();
                }




                FamilySymbol symbol;

                symbol = null;

                foreach (FamilySymbol s in family.Symbols)
                {

                    symbol = s;

                    // Our family only contains one
                    // symbol, so pick it and leave

                    break;
                }

                //Place the family symbol:

                //PromptForFamilyInstancePlacement cannot 
                //be called inside transaction.

                uidoc.PromptForFamilyInstancePlacement(symbol);

                //           UIApplication uiapp1 = commandData.Application;
                //           UIDocument uidoc1 = uiapp1.ActiveUIDocument;



                //           Autodesk.Revit.ApplicationServices.Application app1 = uiapp1.Application;
                //Document doc1 = app1.OpenDocumentFile(FamilyPath);
            }
            //Modify document within a transaction
                 
            else {

                

                foreach (FamilySymbol s in family.Symbols)
                {

                    symbol1 = s;

                    // Our family only contains one
                    // symbol, so pick it and leave

                    break;
                }
                uidoc.PromptForFamilyInstancePlacement(symbol1);
                //Place the family symbol:

                //PromptForFamilyInstancePlacement cannot 
                //be called inside transaction.

              
            
            
            
            }


            return Result.Succeeded;
        }





  


















        public static Element FindElementByName( Document doc, Type targetType,string targetName)
        {
            return new FilteredElementCollector(doc)
              .OfClass(targetType).FirstOrDefault<Element>(  e => e.Name.Equals(targetName));
        }

        }

       




    

    }

