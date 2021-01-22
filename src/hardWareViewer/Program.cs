using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Settings.User;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System.IO;
using System.Data;

namespace hardWareViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
                if (Project.FillSettings(args))
                {
                    Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                    Logging.StartFirstLevel(1);
                    Logging.Comment("Вход в программу");
                    Logging.StopFirstLevel();

                    config.userName = Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;
                    config.statusCode = Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower();

                    //DataTable dt = readSQL.GetTMovementMaterial();
                    //Application.Run(new journalMovementMaterial.frmList());
                    //Application.Run(new MovementMaterial.frmAddMovementMaterial() {Text = "Добавить движение расходного материала" });
                    //Application.Run(new MovementMaterial.frmAddMovementMaterial() { Text = "Редактировать движение расходного материала", row = dt.DefaultView[4] });
                    
                    Application.Run(new frmMain());

                    Logging.StartFirstLevel(2);
                    Logging.Comment("Выход из программы");
                    Logging.StopFirstLevel();
                    Project.clearBufferFiles();
                }
        }
    }
}
