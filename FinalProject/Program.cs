using DevExpress.Skins;
using DevExpress.UserSkins;
using FinalProject.Form;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context 
            Application.Run(new frmMain());
        }
    }
}