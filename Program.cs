using GameLauncher.Connections;

namespace GameLauncher
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
            if (!System.Diagnostics.Debugger.IsAttached) 
            {
                Application.ThreadException += new
                    ThreadExceptionEventHandler(UIThreadException);

                // Set the unhandled exception mode to force all Windows Forms errors
                // to go through our handler.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException += new
                    UnhandledExceptionEventHandler(UnhandledException);
            }

            ApplicationConfiguration.Initialize();

            Management.Online = IGDBObj.TestConnectivity();
            Management.Config = Config.Load();
            
            if (Management.Online)
            {
                if (!Management.IGDBViable)
                    Application.Run(new IGDBDetailsForm());

                if (!new IGDBObj(Management.Config.IGDBId!, Management.Config.IGDBSecret!).TestCredentials())
                    Application.Run(new IGDBDetailsForm());
                
                Management.IGDBObj = new(Management.Config.IGDBId!, Management.Config.IGDBSecret!);
                Management.RichPresence = new("1237693349612224562");
            }
            
            Application.Run(new Form1());
        }
        
        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            
            MessageBox.Show(error.Message, "A critical error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is RestorableError)
                MessageBox.Show(e.Exception.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (e.Exception is NotImplementedException)
                MessageBox.Show("This feature is not yet implemented", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                throw e.Exception;
        }
    }
}