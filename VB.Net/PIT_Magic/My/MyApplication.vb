Imports Microsoft.VisualBasic.ApplicationServices
Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace PIT_Magic.My
    <GeneratedCode("MyTemplate", "10.0.0.0"), EditorBrowsable(EditorBrowsableState.Never)> _
    Friend Class MyApplication
        Inherits WindowsFormsApplicationBase
        ' Methods
        <DebuggerStepThrough> _
        Public Sub New()
            MyBase.New(AuthenticationMode.Windows)
            Me.IsSingleInstance = True
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses
        End Sub

        <MethodImpl((MethodImplOptions.NoOptimization Or MethodImplOptions.NoInlining)), STAThread, EditorBrowsable(EditorBrowsableState.Advanced), DebuggerHidden> _
        Friend Shared Sub Main(ByVal Args As String())
            Try 
                Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering)
            End Try
            MyProject.Application.Run(Args)
        End Sub

        <DebuggerStepThrough> _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = MyProject.Forms.PIT_Magic_Main
        End Sub

    End Class
End Namespace

