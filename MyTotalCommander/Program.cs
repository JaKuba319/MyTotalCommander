using MyTotalCommander.Presenters;
using MyTotalCommander.Views;
using System.Reflection;

namespace MyTotalCommander
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var view = new Form1();
            var presenter = new MainPresenter(view);
            Application.Run(view);
        }
    }
}