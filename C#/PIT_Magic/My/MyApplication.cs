namespace PIT_Magic.My
{
    using Microsoft.VisualBasic.ApplicationServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [GeneratedCode("MyTemplate", "10.0.0.0"), EditorBrowsable(EditorBrowsableState.Never)]
    internal class MyApplication : WindowsFormsApplicationBase
    {
        [DebuggerStepThrough]
        public MyApplication() : base(AuthenticationMode.Windows)
        {
            this.IsSingleInstance = true;
            this.EnableVisualStyles = true;
            this.SaveMySettingsOnExit = true;
            this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining), STAThread, EditorBrowsable(EditorBrowsableState.Advanced), DebuggerHidden]
        internal static void Main(string[] Args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
            }
            finally
            {
            }
            MyProject.Application.Run(Args);
        }

        [DebuggerStepThrough]
        protected override void OnCreateMainForm()
        {
            this.MainForm = MyProject.Forms.PIT_Magic_Main;
        }
    }
}

