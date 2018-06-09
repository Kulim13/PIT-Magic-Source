Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace PIT_Magic
    <DesignerGenerated> _
    Public Class PIT_Magic_Main
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.PIT_Magic_Main_Load)
            Me.AppPath = Application.StartupPath.ToString
            Me.newFileCounter = 1
            Me.InitializeComponent
            Me.lblVersionInfo.Text = ("PIT Magic v" & Me.GetAppVersion & " Copyright © Gaz 2012.")
            Me.sfdPIT.FileName = $"NewPitFile{Me.newFileCounter:00}.pit"
            Me.txtPITFile.Text = Me.sfdPIT.FileName
            Me.ofdPIT.FileName = Me.sfdPIT.FileName
            Me.newFileCounter += 1
            Me.cbDataType.SelectedIndex = 0
            Me.txtHdrMagic.Text = $"0x{&H12349876.ToString("X")}"
            Me.txtHdrSize.Text = Conversions.ToString(&H1C)
            Me.txtPITEntryCnt.Text = "0"
            Me.originalPitData = New PitData
            Me.myPitData = New PitData
            Me.myPitEntry = Nothing
            Me.originalPitData = PitData.Clone(Me.myPitData)
            Me.btnSave.Enabled = False
            Me.btnExport.Enabled = False
            Me.btnCopyClipboard.Enabled = False
        End Sub

        Private Sub btnCopyClipboard_Click(ByVal sender As Object, ByVal e As EventArgs)
            Clipboard.Clear
            Me.rtAnalysisOutput.SelectAll
            Me.rtAnalysisOutput.Copy
            Interaction.MsgBox("PIT Analysis was copied to clipboard successfully.", MsgBoxStyle.Information, Nothing)
        End Sub

        Private Sub btnCreatePITEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.myPitData Is Nothing) Then
                Me.myPitData = New PitData
                Me.myPitEntry = New PitEntry
                Me.myPitEntry.PartitionName = "PIT_ENTRY"
                Me.myPitData.AddEntry(Me.myPitEntry)
            Else
                Me.myPitEntry = New PitEntry
                Me.myPitEntry.PartitionName = "PIT_ENTRY"
                Me.myPitData.AddEntry(Me.myPitEntry)
            End If
            Me.cbPITEntries.Items.Clear
            Dim num As Integer = 0
            Dim entry As PitEntry
            For Each entry In Me.myPitData.Entries
                Me.cbPITEntries.Items.Add($"Entry #{num:00}: {If(String.IsNullOrEmpty(entry.EntryMemAddr), "New PIT Entry", entry.EntryMemAddr):D}
")
                num += 1
            Next
            Me.cbPITEntries.SelectedIndex = (Me.cbPITEntries.Items.Count - 1)
            Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
        End Sub

        Private Sub btnDonate_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Interaction.MsgBox("Thank you for using PIT Magic. Would you like to make a donation?", (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), "Show Your Support! :-)") = MsgBoxResult.Yes) Then
                Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7910259")
            End If
        End Sub

        Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                Dim num As Integer = 1
                Dim format As String = (Me.AppPath & "\PIT_Analysis_{0:000}.txt")
                Dim path As String = String.Empty
                path = String.Format(format, num)
                Do While File.Exists(path)
                    num += 1
                    path = String.Format(format, num)
                Loop
                Using writer As StreamWriter = New StreamWriter(path)
                    Dim str3 As String
                    For Each str3 In Me.rtAnalysisOutput.Lines
                        writer.WriteLine(str3)
                    Next
                    writer.WriteLine
                    writer.Write(("Generated on: " & Conversions.ToString(DateTime.Now)))
                End Using
                Interaction.MsgBox((path & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & "File saved successfully."), MsgBoxStyle.Information, Nothing)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("An error occurred while saving the 'PIT Analysis' file to disk.", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.CheckPITChanged = CheckPITStatus.PIT_Changed) Then
                Select Case Interaction.MsgBox((Path.GetFileName(Me.ofdPIT.FileName) & " has been modified. Do you want to save changes?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SavePITChanges
                        Exit Select
                    Case MsgBoxResult.Cancel
                        Return
                End Select
            ElseIf (Me.CheckPITChanged = CheckPITStatus.PIT_NewFile) Then
                Select Case Interaction.MsgBox((Me.txtPITFile.Text & " has been modified. Do you want to save new file?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SaveNewPITFile(Nothing)
                        Exit Select
                    Case MsgBoxResult.Cancel
                        Return
                End Select
            End If
            Me.ClearAll
            Me.cbPITEntries.Items.Clear
            Me.originalPitData = New PitData
            Me.myPitData = New PitData
            Me.myPitEntry = Nothing
            Me.sfdPIT.FileName = $"NewPitFile{Me.newFileCounter:00}.pit"
            Me.txtPITFile.Text = Me.sfdPIT.FileName
            Me.ofdPIT.FileName = Me.sfdPIT.FileName
            Me.cbDataType.SelectedIndex = 0
            Me.txtHdrMagic.Text = $"0x{&H12349876.ToString("X")}"
            Me.txtHdrSize.Text = Conversions.ToString(&H1C)
            Me.txtPITEntryCnt.Text = "0"
            Me.newFileCounter += 1
            Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim fileName As String = Me.ofdPIT.FileName
            If (Me.CheckPITChanged = CheckPITStatus.PIT_Changed) Then
                Select Case Interaction.MsgBox((Path.GetFileName(Me.ofdPIT.FileName) & " has been modified. Do you want to save changes?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SavePITChanges
                        Exit Select
                    Case MsgBoxResult.Cancel
                        Return
                End Select
            ElseIf (Me.CheckPITChanged = CheckPITStatus.PIT_NewFile) Then
                Select Case Interaction.MsgBox((Me.txtPITFile.Text & " has been modified. Do you want to save new file?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNo), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SaveNewPITFile(Nothing)
                        Exit Select
                    Case MsgBoxResult.Cancel
                        Return
                End Select
            End If
            Dim text As String = Me.txtPITFile.Text
            Try 
                Me.ofdPIT.FileName = String.Empty
                Me.ofdPIT.InitialDirectory = Me.AppPath
                If (Me.ofdPIT.ShowDialog = DialogResult.Cancel) Then
                    Me.ofdPIT.FileName = fileName
                Else
                    Dim byteStream As New FileStream(Me.ofdPIT.FileName, FileMode.Open, FileAccess.Read)
                    Me.txtPITFile.Text = Path.GetFileName(Me.ofdPIT.FileName)
                    Me.myPitInputStream = New PitInputStream(byteStream)
                    Me.myPitData = New PitData
                    If Me.myPitData.ReadPITFile(Me.myPitInputStream) Then
                        If (Me.cbDataType.SelectedIndex = 0) Then
                            Me.txtDummy1.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData1)
                            Me.txtDummy2.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData2)
                            Me.txtDummy3.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData3)
                            Me.txtDummy4.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData4)
                            Me.txtDummy5.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData5)
                        ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                            Me.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData1)
                            Me.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData2)
                            Me.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData3)
                            Me.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData4)
                            Me.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData5)
                        End If
                        Me.originalPitData = New PitData
                        Me.originalPitData = PitData.Clone(Me.myPitData)
                        Me.cbPITEntries.Items.Clear
                        Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
                        Dim num As Integer = 0
                        Dim entry As PitEntry
                        For Each entry In Me.myPitData.Entries
                            Me.cbPITEntries.Items.Add($"Entry #{num:00}: {entry.EntryMemAddr:D}
")
                            num += 1
                        Next
                        If (Me.cbPITEntries.Items.Count > 0) Then
                            Me.cbPITEntries.SelectedIndex = 0
                        End If
                    End If
                    byteStream.Close
                    Me.btnSave.Enabled = True
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Me.txtPITFile.Text = [text]
                Interaction.MsgBox("An error occurred while opening the requested file.", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub btnOpenPITFile_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim fileName As String = Me.ofdPIT.FileName
            Try 
                Me.ofdPIT.FileName = String.Empty
                Me.ofdPIT.InitialDirectory = Me.AppPath
                If (Me.ofdPIT.ShowDialog <> DialogResult.Cancel) Then
                    Dim byteStream As New FileStream(Me.ofdPIT.FileName, FileMode.Open, FileAccess.Read)
                    Dim inputStream As New PitInputStream(byteStream)
                    Dim data As New PitData
                    If data.ReadPITFile(inputStream) Then
                        Me.rtAnalysisOutput.Clear
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("PIT Magic v" & Me.GetAppVersion & " Copyright © Gaz 2012." & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Analysis for: " & Path.GetFileName(Me.ofdPIT.FileName) & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine & Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("<<< Pit File Start >>>" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine & Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("<<< PIT File Header Information >>>" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText($"Header Magic: 0x{&H12349876:X}     (4 Bytes)
")
                        Me.rtAnalysisOutput.AppendText($"Entry Count:  {data.EntryCount:D}             (4 Bytes)

")
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data #1 (In String and Hexadecimal Format):" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("String:       " & DummyDataType.GetStrFromDummyData(data.DummyData1)))
                        Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                        Me.rtAnalysisOutput.AppendText(("Hexadecimal:  " & DummyDataType.GetHexStrFromDummyData(data.DummyData1)))
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data #2 (In String and Hexadecimal Format):" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("String:       " & DummyDataType.GetStrFromDummyData(data.DummyData2)))
                        Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                        Me.rtAnalysisOutput.AppendText(("Hexadecimal:  " & DummyDataType.GetHexStrFromDummyData(data.DummyData2)))
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data #3 (In String and Hexadecimal Format):" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("String:       " & DummyDataType.GetStrFromDummyData(data.DummyData3)))
                        Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                        Me.rtAnalysisOutput.AppendText(("Hexadecimal:  " & DummyDataType.GetHexStrFromDummyData(data.DummyData3)))
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data #4 (In String and Hexadecimal Format):" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("String:       " & DummyDataType.GetStrFromDummyData(data.DummyData4)))
                        Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                        Me.rtAnalysisOutput.AppendText(("Hexadecimal:  " & DummyDataType.GetHexStrFromDummyData(data.DummyData4)))
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data #5 (In String and Hexadecimal Format):" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("String:       " & DummyDataType.GetStrFromDummyData(data.DummyData5)))
                        Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                        Me.rtAnalysisOutput.AppendText(("Hexadecimal:  " & DummyDataType.GetHexStrFromDummyData(data.DummyData5)))
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("Dummy Data Length: (" & Conversions.ToString(4) & " Bytes Per Block, 20 Bytes In Total.)" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(String.Concat(New String() { "Header Size: (", Conversions.ToString(&H1C), " Bytes)", Environment.NewLine, Environment.NewLine, Environment.NewLine }))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("<<< PIT File Entries >>>" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Dim entry As PitEntry
                        For Each entry In data.Entries
                            Dim str2 As String
                            Dim str3 As String
                            Dim str4 As String
                            Dim str5 As String
                            Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                            Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                            Me.rtAnalysisOutput.AppendText($"Entry Memory Address: {entry.EntryMemAddr:D}
")
                            Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                            Me.rtAnalysisOutput.AppendText(Environment.NewLine)
                            If ((entry.BinaryType And EntryBinaryType.AppProcessor) > EntryBinaryType.AppProcessor) Then
                                str3 = "(APP. PROCESSOR)"
                            ElseIf ((entry.BinaryType And EntryBinaryType.ComProcessor) > EntryBinaryType.AppProcessor) Then
                                str3 = "(COM. PROCESSOR)"
                            Else
                                str3 = "(UNKNOWN)"
                            End If
                            Me.rtAnalysisOutput.AppendText(("Binary Type: " & String.Format("               {0} {1,20}" & ChrW(10), CInt(entry.BinaryType), str3)))
                            If ((entry.DeviceType And EntryDeviceType.OneNand) > EntryDeviceType.OneNand) Then
                                str4 = "(ONE NAND)"
                            ElseIf ((entry.DeviceType And EntryDeviceType.FileOrFat) > EntryDeviceType.OneNand) Then
                                str4 = "(FILE / FAT)"
                            ElseIf ((entry.DeviceType And EntryDeviceType.MMC) > EntryDeviceType.OneNand) Then
                                str4 = "(MMC)"
                            ElseIf ((entry.DeviceType And EntryDeviceType.All) > EntryDeviceType.OneNand) Then
                                str4 = "(ALL)"
                            Else
                                str4 = "(UNKNOWN)"
                            End If
                            Me.rtAnalysisOutput.AppendText(("Device Type: " & String.Format("               {0} {1,20}" & ChrW(10), CInt(entry.DeviceType), str4)))
                            Me.rtAnalysisOutput.AppendText(("Identifier: " & $"                {entry.Identifier:D}
"))
                            If ((entry.Attribute And EntryAttribute.STL) > DirectCast(0, EntryAttribute)) Then
                                str2 = "(STL)"
                            ElseIf ((entry.Attribute And EntryAttribute.Write) > DirectCast(0, EntryAttribute)) Then
                                str2 = "(READ / WRITE)"
                            Else
                                str2 = "(READ ONLY)"
                            End If
                            Me.rtAnalysisOutput.AppendText(("Attribute: " & String.Format("                 {0} {1,20}" & ChrW(10), CInt(entry.Attribute), str2)))
                            If ((entry.UpdateAttribute And EntryUpdateAttribute.Fota) > DirectCast(0, EntryUpdateAttribute)) Then
                                str5 = "(FOTA)"
                            ElseIf ((entry.UpdateAttribute And EntryUpdateAttribute.Secure) > DirectCast(0, EntryUpdateAttribute)) Then
                                str5 = "(FOTA, SECURE)"
                            Else
                                str5 = "(UNKNOWN)"
                            End If
                            Me.rtAnalysisOutput.AppendText(("Update Attribute: " & String.Format("          {0} {1,20}" & ChrW(10), CInt(entry.UpdateAttribute), str5)))
                            Me.rtAnalysisOutput.AppendText(("Block Size: " & $"                {entry.BlockSize:###,###,###}
"))
                            Me.rtAnalysisOutput.AppendText(("Block Count: " & $"               {entry.BlockCount:###,###,###}
"))
                            Me.rtAnalysisOutput.AppendText(("File Offset (Obsolete): " & $"    {entry.FileOffset}
"))
                            Me.rtAnalysisOutput.AppendText(("File Size (Obsolete): " & $"      {entry.FileSize}
"))
                            Me.rtAnalysisOutput.AppendText(("Partition Name: " & $"            {entry.PartitionName}
"))
                            Me.rtAnalysisOutput.AppendText(("Flash FileName: " & $"            {entry.FlashFileName}
"))
                            Me.rtAnalysisOutput.AppendText(("FOTA FileName: " & $"             {entry.FotaFileName}
"))
                        Next
                        Me.rtAnalysisOutput.AppendText((Environment.NewLine & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("----------------------------------------------------------" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText(("<<< Pit File End >>>" & Environment.NewLine))
                        Me.rtAnalysisOutput.AppendText("----------------------------------------------------------")
                    End If
                    Me.btnExport.Enabled = True
                    Me.btnCopyClipboard.Enabled = True
                    Me.ofdPIT.FileName = fileName
                    byteStream.Close
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("An error occurred while opening the requested file.", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub btnRemPITEntry_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.cbPITEntries.Items.Count > 0) Then
                If (Interaction.MsgBox(("Remove Selected PIT Entry?" & ChrW(13) & ChrW(10) & ChrW(13) & ChrW(10) & Me.cbPITEntries.SelectedItem.ToString), (MsgBoxStyle.Question Or MsgBoxStyle.OkCancel), Nothing) = MsgBoxResult.Ok) Then
                    Dim text As String = Me.txtPITFile.Text
                    Me.myPitData.RemoveEntry(Me.myPitEntry.Index)
                    If (Me.cbPITEntries.SelectedIndex >= 0) Then
                        Me.cbPITEntries.Items.RemoveAt(Me.cbPITEntries.SelectedIndex)
                    End If
                    Me.cbPITEntries.Items.Clear
                    Dim num2 As Integer = (Me.myPitEntry.Index - 1)
                    Dim num As Integer = 0
                    Dim entry As PitEntry
                    For Each entry In Me.myPitData.Entries
                        Me.cbPITEntries.Items.Add($"Entry #{num:00}: {If(String.IsNullOrEmpty(entry.EntryMemAddr), "New PIT Entry", entry.EntryMemAddr):D}
")
                        num += 1
                    Next
                    If (Me.myPitData.EntryCount > 0) Then
                        Me.cbPITEntries.SelectedIndex = If((num2 < 0), 0, num2)
                        Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
                    Else
                        Dim selectedIndex As Integer = Me.cbDataType.SelectedIndex
                        Me.ClearAll
                        Me.txtPITFile.Text = [text]
                        Me.txtHdrMagic.Text = $"0x{&H12349876.ToString("X")}"
                        Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
                        Me.txtHdrSize.Text = Conversions.ToString(&H1C)
                        Me.cbDataType.SelectedIndex = selectedIndex
                        If (Me.cbDataType.SelectedIndex = 0) Then
                            Me.txtDummy1.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData1)
                            Me.txtDummy2.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData2)
                            Me.txtDummy3.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData3)
                            Me.txtDummy4.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData4)
                            Me.txtDummy5.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData5)
                        ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                            Me.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData1)
                            Me.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData2)
                            Me.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData3)
                            Me.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData4)
                            Me.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData5)
                        End If
                    End If
                End If
            Else
                Interaction.MsgBox("Nothing to remove! PIT Entry list is empty!", MsgBoxStyle.Information, Nothing)
            End If
        End Sub

        Private Sub btnResetForm_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim text As String = Me.txtPITFile.Text
            If (Not Me.originalPitData Is Nothing) Then
                Dim selectedIndex As Integer = Me.cbDataType.SelectedIndex
                Me.ClearAll
                Me.txtPITFile.Text = [text]
                Dim num2 As Integer = &H12349876
                Me.txtHdrMagic.Text = $"0x{num2.ToString("X")}"
                Me.txtPITEntryCnt.Text = Conversions.ToString(Me.myPitData.EntryCount)
                Me.txtHdrSize.Text = Conversions.ToString(&H1C)
                Me.cbDataType.SelectedIndex = selectedIndex
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.txtDummy1.Text = DummyDataType.GetStrFromDummyData(Me.originalPitData.DummyData1)
                    Me.txtDummy2.Text = DummyDataType.GetStrFromDummyData(Me.originalPitData.DummyData2)
                    Me.txtDummy3.Text = DummyDataType.GetStrFromDummyData(Me.originalPitData.DummyData3)
                    Me.txtDummy4.Text = DummyDataType.GetStrFromDummyData(Me.originalPitData.DummyData4)
                    Me.txtDummy5.Text = DummyDataType.GetStrFromDummyData(Me.originalPitData.DummyData5)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(Me.originalPitData.DummyData1)
                    Me.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(Me.originalPitData.DummyData2)
                    Me.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(Me.originalPitData.DummyData3)
                    Me.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(Me.originalPitData.DummyData4)
                    Me.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(Me.originalPitData.DummyData5)
                End If
            Else
                Me.txtPITFile.Text = [text]
                Me.txtHdrMagic.Text = $"0x{&H12349876.ToString("X")}"
                Me.txtPITEntryCnt.Text = "0"
                Me.txtHdrSize.Text = Conversions.ToString(&H1C)
            End If
            If (Me.cbPITEntries.Items.Count > 0) Then
                Me.cbPITEntries.SelectedIndex = 0
            End If
            Me.UpdatePITHeader
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.SavePITChanges
        End Sub

        Private Sub btnSaveAs_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.SaveNewPITFile(Nothing)
        End Sub

        Private Sub cbDumDisplayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.myPitData Is Nothing) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    If (Not Me.myPitData.DummyData1 Is Nothing) Then
                        Me.txtDummy1.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData1)
                    End If
                    If (Not Me.myPitData.DummyData2 Is Nothing) Then
                        Me.txtDummy2.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData2)
                    End If
                    If (Not Me.myPitData.DummyData3 Is Nothing) Then
                        Me.txtDummy3.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData3)
                    End If
                    If (Not Me.myPitData.DummyData4 Is Nothing) Then
                        Me.txtDummy4.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData4)
                    End If
                    If (Not Me.myPitData.DummyData5 Is Nothing) Then
                        Me.txtDummy5.Text = DummyDataType.GetStrFromDummyData(Me.myPitData.DummyData5)
                    End If
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    If (Not Me.myPitData.DummyData1 Is Nothing) Then
                        Me.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData1)
                    End If
                    If (Not Me.myPitData.DummyData2 Is Nothing) Then
                        Me.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData2)
                    End If
                    If (Not Me.myPitData.DummyData3 Is Nothing) Then
                        Me.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData3)
                    End If
                    If (Not Me.myPitData.DummyData4 Is Nothing) Then
                        Me.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData4)
                    End If
                    If (Not Me.myPitData.DummyData5 Is Nothing) Then
                        Me.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(Me.myPitData.DummyData5)
                    End If
                End If
            End If
        End Sub

        Private Sub cbPITEntries_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.cbPITEntries.Items.Count > 0) Then
                Me.UpdatePIT
            End If
        End Sub

        Private Sub cbPITEntries_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try 
                If (Me.cbPITEntries.SelectedIndex <> -1) Then
                    Me.myPitEntry = Me.myPitData.GetEntry(Me.cbPITEntries.SelectedIndex)
                    Me.numBinaryType.Value = New Decimal(CInt(Me.myPitEntry.BinaryType))
                    If ((Me.myPitEntry.BinaryType And EntryBinaryType.AppProcessor) > EntryBinaryType.AppProcessor) Then
                        Me.lblBinTypeStatus.Text = "APP. PROCESSOR"
                    ElseIf ((Me.myPitEntry.BinaryType And EntryBinaryType.ComProcessor) > EntryBinaryType.AppProcessor) Then
                        Me.lblBinTypeStatus.Text = "COM. PROCESSOR"
                    Else
                        Me.lblBinTypeStatus.Text = "UNKNOWN"
                    End If
                    Me.numDeviceType.Value = New Decimal(CInt(Me.myPitEntry.DeviceType))
                    If ((Me.myPitEntry.DeviceType And EntryDeviceType.OneNand) > EntryDeviceType.OneNand) Then
                        Me.lblDevTypeStatus.Text = "ONE NAND"
                    ElseIf ((Me.myPitEntry.DeviceType And EntryDeviceType.FileOrFat) > EntryDeviceType.OneNand) Then
                        Me.lblDevTypeStatus.Text = "FILE / FAT"
                    ElseIf ((Me.myPitEntry.DeviceType And EntryDeviceType.MMC) > EntryDeviceType.OneNand) Then
                        Me.lblDevTypeStatus.Text = "MMC"
                    ElseIf ((Me.myPitEntry.DeviceType And EntryDeviceType.All) > EntryDeviceType.OneNand) Then
                        Me.lblDevTypeStatus.Text = "ALL"
                    Else
                        Me.lblDevTypeStatus.Text = "UNKNOWN"
                    End If
                    Me.numIdentifier.Value = New Decimal(Me.myPitEntry.Identifier)
                    Me.numAttribute.Value = New Decimal(CInt(Me.myPitEntry.Attribute))
                    If ((Me.myPitEntry.Attribute And EntryAttribute.STL) > DirectCast(0, EntryAttribute)) Then
                        Me.lblAttribStatus.Text = "STL"
                    ElseIf ((Me.myPitEntry.Attribute And EntryAttribute.Write) > DirectCast(0, EntryAttribute)) Then
                        Me.lblAttribStatus.Text = "READ / WRITE"
                    Else
                        Me.lblAttribStatus.Text = "READ ONLY"
                    End If
                    Me.numUpdateAttribute.Value = New Decimal(CInt(Me.myPitEntry.UpdateAttribute))
                    If ((Me.myPitEntry.UpdateAttribute And EntryUpdateAttribute.Fota) > DirectCast(0, EntryUpdateAttribute)) Then
                        Me.lblUpdAttrStatus.Text = "FOTA"
                    ElseIf ((Me.myPitEntry.UpdateAttribute And EntryUpdateAttribute.Secure) > DirectCast(0, EntryUpdateAttribute)) Then
                        Me.lblUpdAttrStatus.Text = "FOTA, SECURE"
                    Else
                        Me.lblUpdAttrStatus.Text = "UNKNOWN"
                    End If
                    Me.numBlockSize.Value = New Decimal(Me.myPitEntry.BlockSize)
                    Me.numBlockCount.Value = New Decimal(Me.myPitEntry.BlockCount)
                    Me.numFileOffset.Value = New Decimal(Me.myPitEntry.FileOffset)
                    Me.numFileSize.Value = New Decimal(Me.myPitEntry.FileSize)
                    Me.txtPartName.Text = Me.myPitEntry.PartitionName
                    Me.txtFlashFileName.Text = Me.myPitEntry.FlashFileName
                    Me.txtFotaFileName.Text = Me.myPitEntry.FotaFileName
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("An indexing error occurred while selecting PIT Entry!", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Function CheckPITChanged() As CheckPITStatus
            If ((Not Me.myPitData Is Nothing) And (Not Me.originalPitData Is Nothing)) Then
                If Me.myPitData.Matches(Me.originalPitData) Then
                    Return CheckPITStatus.PIT_Unchanged
                End If
                Return CheckPITStatus.PIT_Changed
            End If
            If ((Not Me.myPitData Is Nothing) And (Me.originalPitData Is Nothing)) Then
                Return CheckPITStatus.PIT_NewFile
            End If
            Return CheckPITStatus.PIT_Unchanged
        End Function

        Private Sub ClearAll()
            Try 
                Dim enumerator As IEnumerator
                Try 
                    enumerator = Me.Controls.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As Control = DirectCast(enumerator.Current, Control)
                        If (current.GetType.Name = "Panel") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "GroupBox") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "TabControl") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "TextBox") Then
                            TryCast(current,TextBox).Clear
                        End If
                        If (current.GetType.Name = "RadioButton") Then
                            Dim button As RadioButton = TryCast(current,RadioButton)
                            button.Checked = False
                        End If
                        If (current.GetType.Name = "CheckBox") Then
                            Dim box2 As CheckBox = TryCast(current,CheckBox)
                            box2.Checked = False
                        End If
                        If (current.GetType.Name = "ComboBox") Then
                            Dim box3 As ComboBox = TryCast(current,ComboBox)
                            box3.SelectedIndex = -1
                        End If
                        If (current.GetType.Name = "NumericUpDown") Then
                            Dim down As NumericUpDown = TryCast(current,NumericUpDown)
                            down.Value = Decimal.Zero
                        End If
                        If (current.GetType.Name = "RichTextBox") Then
                            TryCast(current,RichTextBox).Clear
                        End If
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator,IDisposable).Dispose
                    End If
                End Try
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                MessageBox.Show(exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub ClearControls(ByVal Type As Control)
            Try 
                Dim enumerator As IEnumerator
                Try 
                    enumerator = Type.Controls.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As Control = DirectCast(enumerator.Current, Control)
                        If (current.GetType.Name = "TextBox") Then
                            TryCast(current,TextBox).Clear
                        End If
                        If (current.GetType.Name = "Panel") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "GroupBox") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "TabPage") Then
                            Me.ClearControls(current)
                        End If
                        If (current.GetType.Name = "ComboBox") Then
                            Dim box2 As ComboBox = TryCast(current,ComboBox)
                            box2.SelectedIndex = -1
                        End If
                        If (current.GetType.Name = "NumericUpDown") Then
                            Dim down As NumericUpDown = TryCast(current,NumericUpDown)
                            down.Value = Decimal.Zero
                        End If
                        If (current.GetType.Name = "RadioButton") Then
                            Dim button As RadioButton = TryCast(current,RadioButton)
                            button.Checked = False
                        End If
                        If (current.GetType.Name = "CheckBox") Then
                            Dim box3 As CheckBox = TryCast(current,CheckBox)
                            box3.Checked = False
                        End If
                        If (current.GetType.Name = "RichTextBox") Then
                            TryCast(current,RichTextBox).Clear
                        End If
                    Loop
                Finally
                    If TypeOf enumerator Is IDisposable Then
                        TryCast(enumerator,IDisposable).Dispose
                    End If
                End Try
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                MessageBox.Show(exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                ProjectData.ClearProjectError
            End Try
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try 
                If (disposing AndAlso (Not Me.components Is Nothing)) Then
                    Me.components.Dispose
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private Function GetAppVersion() As String
            Dim version As Version = Assembly.GetExecutingAssembly.GetName.Version
            Return String.Concat(New String() { Conversions.ToString(version.Major), ".", Conversions.ToString(version.Minor), ".", Conversions.ToString(version.Build) })
        End Function

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Dim manager As New ComponentResourceManager(GetType(PIT_Magic_Main))
            Me.tcPITLayout = New TabControl
            Me.tabPITFileEditor = New TabPage
            Me.btnResetForm = New Button
            Me.btnRemPITEntry = New Button
            Me.btnCreatePITEntry = New Button
            Me.gbPITOps = New GroupBox
            Me.btnNew = New Button
            Me.lblPITFile = New Label
            Me.txtPITFile = New TextBox
            Me.btnOpen = New Button
            Me.lblPITEntryList = New Label
            Me.btnSaveAs = New Button
            Me.cbPITEntries = New ComboBox
            Me.btnSave = New Button
            Me.gbPITFileHdrInfo = New GroupBox
            Me.Label8 = New Label
            Me.Label7 = New Label
            Me.Label6 = New Label
            Me.Label5 = New Label
            Me.Label4 = New Label
            Me.txtDummy5 = New TextBox
            Me.txtDummy4 = New TextBox
            Me.txtDummy3 = New TextBox
            Me.txtDummy2 = New TextBox
            Me.lblDummyDataTypeMsg = New Label
            Me.lblDummyDataType = New Label
            Me.cbDataType = New ComboBox
            Me.lblDummyData = New Label
            Me.txtDummy1 = New TextBox
            Me.gbHdrSize = New GroupBox
            Me.lblHdrSizeType = New Label
            Me.txtHdrSize = New TextBox
            Me.lblPITEntryCntType = New Label
            Me.lblHdrMagicType = New Label
            Me.lblPITEntryCnt = New Label
            Me.txtPITEntryCnt = New TextBox
            Me.lblHdrMagic = New Label
            Me.txtHdrMagic = New TextBox
            Me.gbCurrentPITEntry = New GroupBox
            Me.lblUpdAttrStatus = New Label
            Me.lblDevTypeStatus = New Label
            Me.numBinaryType = New NumericUpDown
            Me.lblBinTypeStatus = New Label
            Me.lblFotaFileName = New Label
            Me.txtFotaFileName = New TextBox
            Me.lblFlashFileName = New Label
            Me.lblPartName = New Label
            Me.txtFlashFileName = New TextBox
            Me.txtPartName = New TextBox
            Me.numBlockCount = New NumericUpDown
            Me.lblBlockSize = New Label
            Me.numBlockSize = New NumericUpDown
            Me.lblBlockCount = New Label
            Me.numAttribute = New NumericUpDown
            Me.lblAttribStatus = New Label
            Me.numUpdateAttribute = New NumericUpDown
            Me.numIdentifier = New NumericUpDown
            Me.numFileSize = New NumericUpDown
            Me.lblBinaryType = New Label
            Me.numFileOffset = New NumericUpDown
            Me.numDeviceType = New NumericUpDown
            Me.lblDeviceType = New Label
            Me.lblIdentifier = New Label
            Me.lblAttribute = New Label
            Me.lblUpdateAttribute = New Label
            Me.lblFileSize = New Label
            Me.lblFileOffset = New Label
            Me.tabPITFileAnalysis = New TabPage
            Me.btnOpenPITFile = New Button
            Me.btnExport = New Button
            Me.btnCopyClipboard = New Button
            Me.rtAnalysisOutput = New RichTextBox
            Me.lblVersionInfo = New Label
            Me.ofdPIT = New OpenFileDialog
            Me.sfdPIT = New SaveFileDialog
            Me.btnDonate = New Button
            Me.tcPITLayout.SuspendLayout
            Me.tabPITFileEditor.SuspendLayout
            Me.gbPITOps.SuspendLayout
            Me.gbPITFileHdrInfo.SuspendLayout
            Me.gbHdrSize.SuspendLayout
            Me.gbCurrentPITEntry.SuspendLayout
            Me.numBinaryType.BeginInit
            Me.numBlockCount.BeginInit
            Me.numBlockSize.BeginInit
            Me.numAttribute.BeginInit
            Me.numUpdateAttribute.BeginInit
            Me.numIdentifier.BeginInit
            Me.numFileSize.BeginInit
            Me.numFileOffset.BeginInit
            Me.numDeviceType.BeginInit
            Me.tabPITFileAnalysis.SuspendLayout
            Me.SuspendLayout
            Me.tcPITLayout.Controls.Add(Me.tabPITFileEditor)
            Me.tcPITLayout.Controls.Add(Me.tabPITFileAnalysis)
            Me.tcPITLayout.Dock = DockStyle.Top
            Dim point2 As New Point(0, 0)
            Me.tcPITLayout.Location = point2
            Me.tcPITLayout.Name = "tcPITLayout"
            Me.tcPITLayout.SelectedIndex = 0
            Dim size2 As New Size(&H200, &H21B)
            Me.tcPITLayout.Size = size2
            Me.tcPITLayout.TabIndex = 6
            Me.tabPITFileEditor.Controls.Add(Me.btnResetForm)
            Me.tabPITFileEditor.Controls.Add(Me.btnRemPITEntry)
            Me.tabPITFileEditor.Controls.Add(Me.btnCreatePITEntry)
            Me.tabPITFileEditor.Controls.Add(Me.gbPITOps)
            Me.tabPITFileEditor.Controls.Add(Me.gbPITFileHdrInfo)
            Me.tabPITFileEditor.Controls.Add(Me.gbCurrentPITEntry)
            point2 = New Point(4, &H16)
            Me.tabPITFileEditor.Location = point2
            Me.tabPITFileEditor.Name = "tabPITFileEditor"
            Dim padding2 As New Padding(3)
            Me.tabPITFileEditor.Padding = padding2
            size2 = New Size(&H1F8, &H201)
            Me.tabPITFileEditor.Size = size2
            Me.tabPITFileEditor.TabIndex = 0
            Me.tabPITFileEditor.Text = "PIT File Editor"
            Me.tabPITFileEditor.UseVisualStyleBackColor = True
            Me.btnResetForm.Image = DirectCast(manager.GetObject("btnResetForm.Image"), Image)
            Me.btnResetForm.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H184, &H1E3)
            Me.btnResetForm.Location = point2
            Me.btnResetForm.Name = "btnResetForm"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnResetForm.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnResetForm.Size = size2
            Me.btnResetForm.TabIndex = &H27
            Me.btnResetForm.Text = "Reset Form"
            Me.btnResetForm.UseVisualStyleBackColor = True
            Me.btnRemPITEntry.Image = DirectCast(manager.GetObject("btnRemPITEntry.Image"), Image)
            Me.btnRemPITEntry.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&HAE, &H1E3)
            Me.btnRemPITEntry.Location = point2
            Me.btnRemPITEntry.Name = "btnRemPITEntry"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnRemPITEntry.Padding = padding2
            size2 = New Size(&H9C, &H19)
            Me.btnRemPITEntry.Size = size2
            Me.btnRemPITEntry.TabIndex = &H26
            Me.btnRemPITEntry.Text = "Remove PIT Entry"
            Me.btnRemPITEntry.UseVisualStyleBackColor = True
            Me.btnCreatePITEntry.Image = DirectCast(manager.GetObject("btnCreatePITEntry.Image"), Image)
            Me.btnCreatePITEntry.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(6, &H1E3)
            Me.btnCreatePITEntry.Location = point2
            Me.btnCreatePITEntry.Name = "btnCreatePITEntry"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnCreatePITEntry.Padding = padding2
            size2 = New Size(&H9C, &H19)
            Me.btnCreatePITEntry.Size = size2
            Me.btnCreatePITEntry.TabIndex = &H25
            Me.btnCreatePITEntry.Text = "Create PIT Entry"
            Me.btnCreatePITEntry.UseVisualStyleBackColor = True
            Me.gbPITOps.Controls.Add(Me.btnNew)
            Me.gbPITOps.Controls.Add(Me.lblPITFile)
            Me.gbPITOps.Controls.Add(Me.txtPITFile)
            Me.gbPITOps.Controls.Add(Me.btnOpen)
            Me.gbPITOps.Controls.Add(Me.lblPITEntryList)
            Me.gbPITOps.Controls.Add(Me.btnSaveAs)
            Me.gbPITOps.Controls.Add(Me.cbPITEntries)
            Me.gbPITOps.Controls.Add(Me.btnSave)
            point2 = New Point(6, 6)
            Me.gbPITOps.Location = point2
            Me.gbPITOps.Name = "gbPITOps"
            size2 = New Size(&H1EC, &H67)
            Me.gbPITOps.Size = size2
            Me.gbPITOps.TabIndex = &H24
            Me.gbPITOps.TabStop = False
            Me.gbPITOps.Text = "PIT Operations:"
            Me.btnNew.Image = DirectCast(manager.GetObject("btnNew.Image"), Image)
            Me.btnNew.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(10, &H12)
            Me.btnNew.Location = point2
            Me.btnNew.Name = "btnNew"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnNew.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnNew.Size = size2
            Me.btnNew.TabIndex = 8
            Me.btnNew.Text = "New..."
            Me.btnNew.UseVisualStyleBackColor = True
            Me.lblPITFile.AutoSize = True
            point2 = New Point(6, &H34)
            Me.lblPITFile.Location = point2
            Me.lblPITFile.Name = "lblPITFile"
            size2 = New Size(&H2E, 13)
            Me.lblPITFile.Size = size2
            Me.lblPITFile.TabIndex = 7
            Me.lblPITFile.Text = "PIT File:"
            Me.txtPITFile.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(9, &H44)
            Me.txtPITFile.Location = point2
            Me.txtPITFile.Name = "txtPITFile"
            Me.txtPITFile.ReadOnly = True
            size2 = New Size(&H124, 20)
            Me.txtPITFile.Size = size2
            Me.txtPITFile.TabIndex = 6
            Me.btnOpen.Image = DirectCast(manager.GetObject("btnOpen.Image"), Image)
            Me.btnOpen.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H83, &H12)
            Me.btnOpen.Location = point2
            Me.btnOpen.Name = "btnOpen"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnOpen.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnOpen.Size = size2
            Me.btnOpen.TabIndex = 0
            Me.btnOpen.Text = "Open..."
            Me.btnOpen.UseVisualStyleBackColor = True
            Me.lblPITEntryList.AutoSize = True
            point2 = New Point(320, &H34)
            Me.lblPITEntryList.Location = point2
            Me.lblPITEntryList.Name = "lblPITEntryList"
            size2 = New Size(&H49, 13)
            Me.lblPITEntryList.Size = size2
            Me.lblPITEntryList.TabIndex = 5
            Me.lblPITEntryList.Text = "PIT Entry List:"
            Me.btnSaveAs.Image = DirectCast(manager.GetObject("btnSaveAs.Image"), Image)
            Me.btnSaveAs.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H175, &H12)
            Me.btnSaveAs.Location = point2
            Me.btnSaveAs.Name = "btnSaveAs"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnSaveAs.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnSaveAs.Size = size2
            Me.btnSaveAs.TabIndex = 3
            Me.btnSaveAs.Text = "Save As..."
            Me.btnSaveAs.UseVisualStyleBackColor = True
            Me.cbPITEntries.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cbPITEntries.FormattingEnabled = True
            point2 = New Point(&H143, &H44)
            Me.cbPITEntries.Location = point2
            Me.cbPITEntries.Name = "cbPITEntries"
            size2 = New Size(160, &H15)
            Me.cbPITEntries.Size = size2
            Me.cbPITEntries.TabIndex = 4
            Me.btnSave.Image = DirectCast(manager.GetObject("btnSave.Image"), Image)
            Me.btnSave.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&HFC, &H12)
            Me.btnSave.Location = point2
            Me.btnSave.Name = "btnSave"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnSave.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnSave.Size = size2
            Me.btnSave.TabIndex = 2
            Me.btnSave.Text = "Save..."
            Me.btnSave.UseVisualStyleBackColor = True
            Me.gbPITFileHdrInfo.Controls.Add(Me.Label8)
            Me.gbPITFileHdrInfo.Controls.Add(Me.Label7)
            Me.gbPITFileHdrInfo.Controls.Add(Me.Label6)
            Me.gbPITFileHdrInfo.Controls.Add(Me.Label5)
            Me.gbPITFileHdrInfo.Controls.Add(Me.Label4)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtDummy5)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtDummy4)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtDummy3)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtDummy2)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblDummyDataTypeMsg)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblDummyDataType)
            Me.gbPITFileHdrInfo.Controls.Add(Me.cbDataType)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblDummyData)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtDummy1)
            Me.gbPITFileHdrInfo.Controls.Add(Me.gbHdrSize)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblPITEntryCntType)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblHdrMagicType)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblPITEntryCnt)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtPITEntryCnt)
            Me.gbPITFileHdrInfo.Controls.Add(Me.lblHdrMagic)
            Me.gbPITFileHdrInfo.Controls.Add(Me.txtHdrMagic)
            point2 = New Point(6, &H73)
            Me.gbPITFileHdrInfo.Location = point2
            Me.gbPITFileHdrInfo.Name = "gbPITFileHdrInfo"
            size2 = New Size(&H1EC, 150)
            Me.gbPITFileHdrInfo.Size = size2
            Me.gbPITFileHdrInfo.TabIndex = &H23
            Me.gbPITFileHdrInfo.TabStop = False
            Me.gbPITFileHdrInfo.Text = "PIT File Header Information:"
            Me.Label8.AutoSize = True
            point2 = New Point(410, &H49)
            Me.Label8.Location = point2
            Me.Label8.Name = "Label8"
            size2 = New Size(&H3D, 13)
            Me.Label8.Size = size2
            Me.Label8.TabIndex = 80
            Me.Label8.Text = "Dummy #5:"
            Me.Label7.AutoSize = True
            point2 = New Point(&H14C, &H49)
            Me.Label7.Location = point2
            Me.Label7.Name = "Label7"
            size2 = New Size(&H3D, 13)
            Me.Label7.Size = size2
            Me.Label7.TabIndex = &H4F
            Me.Label7.Text = "Dummy #4:"
            Me.Label6.AutoSize = True
            point2 = New Point(&HFE, &H49)
            Me.Label6.Location = point2
            Me.Label6.Name = "Label6"
            size2 = New Size(&H3D, 13)
            Me.Label6.Size = size2
            Me.Label6.TabIndex = &H4E
            Me.Label6.Text = "Dummy #3:"
            Me.Label5.AutoSize = True
            point2 = New Point(&HB0, &H49)
            Me.Label5.Location = point2
            Me.Label5.Name = "Label5"
            size2 = New Size(&H3D, 13)
            Me.Label5.Size = size2
            Me.Label5.TabIndex = &H4D
            Me.Label5.Text = "Dummy #2:"
            Me.Label4.AutoSize = True
            point2 = New Point(&H62, &H49)
            Me.Label4.Location = point2
            Me.Label4.Name = "Label4"
            size2 = New Size(&H3D, 13)
            Me.Label4.Size = size2
            Me.Label4.TabIndex = &H4C
            Me.Label4.Text = "Dummy #1:"
            Me.txtDummy5.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H19D, &H59)
            Me.txtDummy5.Location = point2
            Me.txtDummy5.Name = "txtDummy5"
            size2 = New Size(70, 20)
            Me.txtDummy5.Size = size2
            Me.txtDummy5.TabIndex = &H4B
            Me.txtDummy4.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H14F, &H59)
            Me.txtDummy4.Location = point2
            Me.txtDummy4.Name = "txtDummy4"
            size2 = New Size(70, 20)
            Me.txtDummy4.Size = size2
            Me.txtDummy4.TabIndex = &H4A
            Me.txtDummy3.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H101, &H59)
            Me.txtDummy3.Location = point2
            Me.txtDummy3.Name = "txtDummy3"
            size2 = New Size(70, 20)
            Me.txtDummy3.Size = size2
            Me.txtDummy3.TabIndex = &H49
            Me.txtDummy2.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&HB3, &H59)
            Me.txtDummy2.Location = point2
            Me.txtDummy2.Name = "txtDummy2"
            size2 = New Size(70, 20)
            Me.txtDummy2.Size = size2
            Me.txtDummy2.TabIndex = &H48
            point2 = New Point(&HD1, &H72)
            Me.lblDummyDataTypeMsg.Location = point2
            Me.lblDummyDataTypeMsg.Name = "lblDummyDataTypeMsg"
            size2 = New Size(&HD8, &H1B)
            Me.lblDummyDataTypeMsg.Size = size2
            Me.lblDummyDataTypeMsg.TabIndex = &H47
            Me.lblDummyDataTypeMsg.Text = "(Displays Dummy Data In Specified Format.) (4 Bytes Per Block, 20 Bytes In Total.)"
            Me.lblDummyDataTypeMsg.TextAlign = ContentAlignment.MiddleCenter
            Me.lblDummyDataType.AutoSize = True
            point2 = New Point(6, 120)
            Me.lblDummyDataType.Location = point2
            Me.lblDummyDataType.Name = "lblDummyDataType"
            size2 = New Size(60, 13)
            Me.lblDummyDataType.Size = size2
            Me.lblDummyDataType.TabIndex = 70
            Me.lblDummyDataType.Text = "Data Type:"
            Me.cbDataType.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cbDataType.FormattingEnabled = True
            Me.cbDataType.Items.AddRange(New Object() { "String", "Hexadecimal" })
            point2 = New Point(&H65, &H75)
            Me.cbDataType.Location = point2
            Me.cbDataType.Name = "cbDataType"
            size2 = New Size(&H66, &H15)
            Me.cbDataType.Size = size2
            Me.cbDataType.TabIndex = &H45
            Me.lblDummyData.AutoSize = True
            point2 = New Point(6, &H5C)
            Me.lblDummyData.Location = point2
            Me.lblDummyData.Name = "lblDummyData"
            size2 = New Size(&H47, 13)
            Me.lblDummyData.Size = size2
            Me.lblDummyData.TabIndex = &H43
            Me.lblDummyData.Text = "Dummy Data:"
            Me.txtDummy1.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H65, &H59)
            Me.txtDummy1.Location = point2
            Me.txtDummy1.Name = "txtDummy1"
            size2 = New Size(70, 20)
            Me.txtDummy1.Size = size2
            Me.txtDummy1.TabIndex = &H42
            Me.gbHdrSize.Controls.Add(Me.lblHdrSizeType)
            Me.gbHdrSize.Controls.Add(Me.txtHdrSize)
            point2 = New Point(&H15C, &H12)
            Me.gbHdrSize.Location = point2
            Me.gbHdrSize.Name = "gbHdrSize"
            size2 = New Size(&H87, &H2E)
            Me.gbHdrSize.Size = size2
            Me.gbHdrSize.TabIndex = &H3D
            Me.gbHdrSize.TabStop = False
            Me.gbHdrSize.Text = "Header Size:"
            Me.lblHdrSizeType.AutoSize = True
            point2 = New Point(&H53, &H13)
            Me.lblHdrSizeType.Location = point2
            Me.lblHdrSizeType.Name = "lblHdrSizeType"
            size2 = New Size(&H27, 13)
            Me.lblHdrSizeType.Size = size2
            Me.lblHdrSizeType.TabIndex = &H41
            Me.lblHdrSizeType.Text = "(Bytes)"
            Me.txtHdrSize.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(12, &H10)
            Me.txtHdrSize.Location = point2
            Me.txtHdrSize.Name = "txtHdrSize"
            Me.txtHdrSize.ReadOnly = True
            size2 = New Size(&H41, 20)
            Me.txtHdrSize.Size = size2
            Me.txtHdrSize.TabIndex = &H40
            Me.lblPITEntryCntType.AutoSize = True
            point2 = New Point(&HB7, &H2F)
            Me.lblPITEntryCntType.Location = point2
            Me.lblPITEntryCntType.Name = "lblPITEntryCntType"
            size2 = New Size(&H99, 13)
            Me.lblPITEntryCntType.Size = size2
            Me.lblPITEntryCntType.TabIndex = &H3B
            Me.lblPITEntryCntType.Text = "(32-Bit Signed Integer, 4 Bytes)"
            Me.lblHdrMagicType.AutoSize = True
            point2 = New Point(&HB7, &H15)
            Me.lblHdrMagicType.Location = point2
            Me.lblHdrMagicType.Name = "lblHdrMagicType"
            size2 = New Size(&H99, 13)
            Me.lblHdrMagicType.Size = size2
            Me.lblHdrMagicType.TabIndex = &H3A
            Me.lblHdrMagicType.Text = "(32-Bit Signed Integer, 4 Bytes)"
            Me.lblPITEntryCnt.AutoSize = True
            point2 = New Point(6, &H2F)
            Me.lblPITEntryCnt.Location = point2
            Me.lblPITEntryCnt.Name = "lblPITEntryCnt"
            size2 = New Size(&H55, 13)
            Me.lblPITEntryCnt.Size = size2
            Me.lblPITEntryCnt.TabIndex = &H39
            Me.lblPITEntryCnt.Text = "PIT Entry Count:"
            Me.txtPITEntryCnt.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&H65, &H2C)
            Me.txtPITEntryCnt.Location = point2
            Me.txtPITEntryCnt.Name = "txtPITEntryCnt"
            Me.txtPITEntryCnt.ReadOnly = True
            size2 = New Size(&H4C, 20)
            Me.txtPITEntryCnt.Size = size2
            Me.txtPITEntryCnt.TabIndex = &H38
            Me.lblHdrMagic.AutoSize = True
            point2 = New Point(6, &H15)
            Me.lblHdrMagic.Location = point2
            Me.lblHdrMagic.Name = "lblHdrMagic"
            size2 = New Size(&H4D, 13)
            Me.lblHdrMagic.Size = size2
            Me.lblHdrMagic.TabIndex = &H37
            Me.lblHdrMagic.Text = "Header Magic:"
            Me.txtHdrMagic.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&H65, &H12)
            Me.txtHdrMagic.Location = point2
            Me.txtHdrMagic.Name = "txtHdrMagic"
            Me.txtHdrMagic.ReadOnly = True
            size2 = New Size(&H4C, 20)
            Me.txtHdrMagic.Size = size2
            Me.txtHdrMagic.TabIndex = &H36
            Me.gbCurrentPITEntry.Controls.Add(Me.lblUpdAttrStatus)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblDevTypeStatus)
            Me.gbCurrentPITEntry.Controls.Add(Me.numBinaryType)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblBinTypeStatus)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblFotaFileName)
            Me.gbCurrentPITEntry.Controls.Add(Me.txtFotaFileName)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblFlashFileName)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblPartName)
            Me.gbCurrentPITEntry.Controls.Add(Me.txtFlashFileName)
            Me.gbCurrentPITEntry.Controls.Add(Me.txtPartName)
            Me.gbCurrentPITEntry.Controls.Add(Me.numBlockCount)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblBlockSize)
            Me.gbCurrentPITEntry.Controls.Add(Me.numBlockSize)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblBlockCount)
            Me.gbCurrentPITEntry.Controls.Add(Me.numAttribute)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblAttribStatus)
            Me.gbCurrentPITEntry.Controls.Add(Me.numUpdateAttribute)
            Me.gbCurrentPITEntry.Controls.Add(Me.numIdentifier)
            Me.gbCurrentPITEntry.Controls.Add(Me.numFileSize)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblBinaryType)
            Me.gbCurrentPITEntry.Controls.Add(Me.numFileOffset)
            Me.gbCurrentPITEntry.Controls.Add(Me.numDeviceType)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblDeviceType)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblIdentifier)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblAttribute)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblUpdateAttribute)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblFileSize)
            Me.gbCurrentPITEntry.Controls.Add(Me.lblFileOffset)
            point2 = New Point(6, &H10F)
            Me.gbCurrentPITEntry.Location = point2
            Me.gbCurrentPITEntry.Name = "gbCurrentPITEntry"
            size2 = New Size(&H1EC, &HCE)
            Me.gbCurrentPITEntry.Size = size2
            Me.gbCurrentPITEntry.TabIndex = &H22
            Me.gbCurrentPITEntry.TabStop = False
            Me.gbCurrentPITEntry.Text = "Current PIT Entry:"
            point2 = New Point(&H95, &H7E)
            Me.lblUpdAttrStatus.Location = point2
            Me.lblUpdAttrStatus.Name = "lblUpdAttrStatus"
            size2 = New Size(&H76, 13)
            Me.lblUpdAttrStatus.Size = size2
            Me.lblUpdAttrStatus.TabIndex = &H34
            Me.lblUpdAttrStatus.Text = "FOTA"
            Me.lblUpdAttrStatus.TextAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H95, &H2F)
            Me.lblDevTypeStatus.Location = point2
            Me.lblDevTypeStatus.Name = "lblDevTypeStatus"
            size2 = New Size(&H76, 13)
            Me.lblDevTypeStatus.Size = size2
            Me.lblDevTypeStatus.TabIndex = &H33
            Me.lblDevTypeStatus.Text = "ALL"
            Me.lblDevTypeStatus.TextAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H65, &H12)
            Me.numBinaryType.Location = point2
            Dim num As New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numBinaryType.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numBinaryType.Minimum = num
            Me.numBinaryType.Name = "numBinaryType"
            size2 = New Size(&H2A, 20)
            Me.numBinaryType.Size = size2
            Me.numBinaryType.TabIndex = 50
            point2 = New Point(&H95, 20)
            Me.lblBinTypeStatus.Location = point2
            Me.lblBinTypeStatus.Name = "lblBinTypeStatus"
            size2 = New Size(&H76, 13)
            Me.lblBinTypeStatus.Size = size2
            Me.lblBinTypeStatus.TabIndex = &H31
            Me.lblBinTypeStatus.Text = "APP. PROCESSOR"
            Me.lblBinTypeStatus.TextAlign = ContentAlignment.MiddleLeft
            Me.lblFotaFileName.AutoSize = True
            point2 = New Point(&H111, &HB0)
            Me.lblFotaFileName.Location = point2
            Me.lblFotaFileName.Name = "lblFotaFileName"
            size2 = New Size(&H58, 13)
            Me.lblFotaFileName.Size = size2
            Me.lblFotaFileName.TabIndex = &H30
            Me.lblFotaFileName.Text = "FOTA File Name:"
            Me.txtFotaFileName.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H17B, &HAD)
            Me.txtFotaFileName.Location = point2
            Me.txtFotaFileName.Name = "txtFotaFileName"
            size2 = New Size(&H68, 20)
            Me.txtFotaFileName.Size = size2
            Me.txtFotaFileName.TabIndex = &H2F
            Me.lblFlashFileName.AutoSize = True
            point2 = New Point(&H111, 150)
            Me.lblFlashFileName.Location = point2
            Me.lblFlashFileName.Name = "lblFlashFileName"
            size2 = New Size(&H55, 13)
            Me.lblFlashFileName.Size = size2
            Me.lblFlashFileName.TabIndex = &H2E
            Me.lblFlashFileName.Text = "Flash File Name:"
            Me.lblPartName.AutoSize = True
            point2 = New Point(&H111, &H7C)
            Me.lblPartName.Location = point2
            Me.lblPartName.Name = "lblPartName"
            size2 = New Size(&H4F, 13)
            Me.lblPartName.Size = size2
            Me.lblPartName.TabIndex = &H2D
            Me.lblPartName.Text = "Partition Name:"
            Me.txtFlashFileName.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H17B, &H93)
            Me.txtFlashFileName.Location = point2
            Me.txtFlashFileName.Name = "txtFlashFileName"
            size2 = New Size(&H68, 20)
            Me.txtFlashFileName.Size = size2
            Me.txtFlashFileName.TabIndex = &H2C
            Me.txtPartName.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(&H17B, &H79)
            Me.txtPartName.Location = point2
            Me.txtPartName.Name = "txtPartName"
            size2 = New Size(&H68, 20)
            Me.txtPartName.Size = size2
            Me.txtPartName.TabIndex = &H2B
            point2 = New Point(&H65, &HAE)
            Me.numBlockCount.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numBlockCount.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numBlockCount.Minimum = num
            Me.numBlockCount.Name = "numBlockCount"
            size2 = New Size(&H68, 20)
            Me.numBlockCount.Size = size2
            Me.numBlockCount.TabIndex = &H2A
            Me.numBlockCount.ThousandsSeparator = True
            Me.lblBlockSize.AutoSize = True
            point2 = New Point(6, 150)
            Me.lblBlockSize.Location = point2
            Me.lblBlockSize.Name = "lblBlockSize"
            size2 = New Size(&H53, 13)
            Me.lblBlockSize.Size = size2
            Me.lblBlockSize.TabIndex = &H27
            Me.lblBlockSize.Text = "Block Size (KB):"
            point2 = New Point(&H65, &H94)
            Me.numBlockSize.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numBlockSize.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numBlockSize.Minimum = num
            Me.numBlockSize.Name = "numBlockSize"
            size2 = New Size(&H68, 20)
            Me.numBlockSize.Size = size2
            Me.numBlockSize.TabIndex = &H29
            Me.numBlockSize.ThousandsSeparator = True
            Me.lblBlockCount.AutoSize = True
            point2 = New Point(6, &HB0)
            Me.lblBlockCount.Location = point2
            Me.lblBlockCount.Name = "lblBlockCount"
            size2 = New Size(&H5B, 13)
            Me.lblBlockCount.Size = size2
            Me.lblBlockCount.TabIndex = 40
            Me.lblBlockCount.Text = "Block Count (KB):"
            point2 = New Point(&H65, &H60)
            Me.numAttribute.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numAttribute.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numAttribute.Minimum = num
            Me.numAttribute.Name = "numAttribute"
            size2 = New Size(&H2A, 20)
            Me.numAttribute.Size = size2
            Me.numAttribute.TabIndex = &H24
            point2 = New Point(&H95, 100)
            Me.lblAttribStatus.Location = point2
            Me.lblAttribStatus.Name = "lblAttribStatus"
            size2 = New Size(&H76, 13)
            Me.lblAttribStatus.Size = size2
            Me.lblAttribStatus.TabIndex = &H23
            Me.lblAttribStatus.Text = "READ / WRITE"
            Me.lblAttribStatus.TextAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H65, &H7A)
            Me.numUpdateAttribute.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numUpdateAttribute.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numUpdateAttribute.Minimum = num
            Me.numUpdateAttribute.Name = "numUpdateAttribute"
            size2 = New Size(&H2A, 20)
            Me.numUpdateAttribute.Size = size2
            Me.numUpdateAttribute.TabIndex = &H1F
            point2 = New Point(&H65, 70)
            Me.numIdentifier.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numIdentifier.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numIdentifier.Minimum = num
            Me.numIdentifier.Name = "numIdentifier"
            size2 = New Size(&H2A, 20)
            Me.numIdentifier.Size = size2
            Me.numIdentifier.TabIndex = &H21
            point2 = New Point(&H17B, &H2C)
            Me.numFileSize.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numFileSize.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numFileSize.Minimum = num
            Me.numFileSize.Name = "numFileSize"
            size2 = New Size(&H68, 20)
            Me.numFileSize.Size = size2
            Me.numFileSize.TabIndex = 30
            Me.lblBinaryType.AutoSize = True
            point2 = New Point(6, 20)
            Me.lblBinaryType.Location = point2
            Me.lblBinaryType.Name = "lblBinaryType"
            size2 = New Size(&H42, 13)
            Me.lblBinaryType.Size = size2
            Me.lblBinaryType.TabIndex = 6
            Me.lblBinaryType.Text = "Binary Type:"
            point2 = New Point(&H17B, &H12)
            Me.numFileOffset.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numFileOffset.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numFileOffset.Minimum = num
            Me.numFileOffset.Name = "numFileOffset"
            size2 = New Size(&H68, 20)
            Me.numFileOffset.Size = size2
            Me.numFileOffset.TabIndex = &H1D
            point2 = New Point(&H65, &H2C)
            Me.numDeviceType.Location = point2
            num = New Decimal(New Integer() { &H7FFFFFFF, 0, 0, 0 })
            Me.numDeviceType.Maximum = num
            num = New Decimal(New Integer() { -2147483648, 0, 0, -2147483648 })
            Me.numDeviceType.Minimum = num
            Me.numDeviceType.Name = "numDeviceType"
            size2 = New Size(&H2A, 20)
            Me.numDeviceType.Size = size2
            Me.numDeviceType.TabIndex = &H20
            Me.lblDeviceType.AutoSize = True
            point2 = New Point(6, &H2F)
            Me.lblDeviceType.Location = point2
            Me.lblDeviceType.Name = "lblDeviceType"
            size2 = New Size(&H47, 13)
            Me.lblDeviceType.Size = size2
            Me.lblDeviceType.TabIndex = 8
            Me.lblDeviceType.Text = "Device Type:"
            Me.lblIdentifier.AutoSize = True
            point2 = New Point(7, &H48)
            Me.lblIdentifier.Location = point2
            Me.lblIdentifier.Name = "lblIdentifier"
            size2 = New Size(50, 13)
            Me.lblIdentifier.Size = size2
            Me.lblIdentifier.TabIndex = 10
            Me.lblIdentifier.Text = "Identifier:"
            Me.lblAttribute.AutoSize = True
            point2 = New Point(7, &H62)
            Me.lblAttribute.Location = point2
            Me.lblAttribute.Name = "lblAttribute"
            size2 = New Size(&H31, 13)
            Me.lblAttribute.Size = size2
            Me.lblAttribute.TabIndex = 12
            Me.lblAttribute.Text = "Attribute:"
            Me.lblUpdateAttribute.AutoSize = True
            point2 = New Point(6, &H7C)
            Me.lblUpdateAttribute.Location = point2
            Me.lblUpdateAttribute.Name = "lblUpdateAttribute"
            size2 = New Size(&H57, 13)
            Me.lblUpdateAttribute.Size = size2
            Me.lblUpdateAttribute.TabIndex = &H12
            Me.lblUpdateAttribute.Text = "Update Attribute:"
            Me.lblFileSize.AutoSize = True
            point2 = New Point(&H111, &H2F)
            Me.lblFileSize.Location = point2
            Me.lblFileSize.Name = "lblFileSize"
            size2 = New Size(&H31, 13)
            Me.lblFileSize.Size = size2
            Me.lblFileSize.TabIndex = &H10
            Me.lblFileSize.Text = "File Size:"
            Me.lblFileOffset.AutoSize = True
            point2 = New Point(&H111, 20)
            Me.lblFileOffset.Location = point2
            Me.lblFileOffset.Name = "lblFileOffset"
            size2 = New Size(100, 13)
            Me.lblFileOffset.Size = size2
            Me.lblFileOffset.TabIndex = 14
            Me.lblFileOffset.Text = "File Offset (In TAR):"
            Me.tabPITFileAnalysis.Controls.Add(Me.btnOpenPITFile)
            Me.tabPITFileAnalysis.Controls.Add(Me.btnExport)
            Me.tabPITFileAnalysis.Controls.Add(Me.btnCopyClipboard)
            Me.tabPITFileAnalysis.Controls.Add(Me.rtAnalysisOutput)
            point2 = New Point(4, &H16)
            Me.tabPITFileAnalysis.Location = point2
            Me.tabPITFileAnalysis.Name = "tabPITFileAnalysis"
            padding2 = New Padding(3)
            Me.tabPITFileAnalysis.Padding = padding2
            size2 = New Size(&H1F8, &H201)
            Me.tabPITFileAnalysis.Size = size2
            Me.tabPITFileAnalysis.TabIndex = 1
            Me.tabPITFileAnalysis.Text = "PIT File Analysis"
            Me.tabPITFileAnalysis.UseVisualStyleBackColor = True
            Me.btnOpenPITFile.Image = DirectCast(manager.GetObject("btnOpenPITFile.Image"), Image)
            Me.btnOpenPITFile.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(6, &H1E3)
            Me.btnOpenPITFile.Location = point2
            Me.btnOpenPITFile.Name = "btnOpenPITFile"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnOpenPITFile.Padding = padding2
            size2 = New Size(&H8F, &H19)
            Me.btnOpenPITFile.Size = size2
            Me.btnOpenPITFile.TabIndex = 6
            Me.btnOpenPITFile.Text = "Open PIT File..."
            Me.btnOpenPITFile.UseVisualStyleBackColor = True
            Me.btnExport.Image = DirectCast(manager.GetObject("btnExport.Image"), Image)
            Me.btnExport.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&HB5, &H1E3)
            Me.btnExport.Location = point2
            Me.btnExport.Name = "btnExport"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnExport.Padding = padding2
            size2 = New Size(&H8F, &H19)
            Me.btnExport.Size = size2
            Me.btnExport.TabIndex = 5
            Me.btnExport.Text = "Export To File..."
            Me.btnExport.UseVisualStyleBackColor = True
            Me.btnCopyClipboard.Image = DirectCast(manager.GetObject("btnCopyClipboard.Image"), Image)
            Me.btnCopyClipboard.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H163, &H1E3)
            Me.btnCopyClipboard.Location = point2
            Me.btnCopyClipboard.Name = "btnCopyClipboard"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnCopyClipboard.Padding = padding2
            size2 = New Size(&H8F, &H19)
            Me.btnCopyClipboard.Size = size2
            Me.btnCopyClipboard.TabIndex = 4
            Me.btnCopyClipboard.Text = "Copy To Clipboard"
            Me.btnCopyClipboard.UseVisualStyleBackColor = True
            Me.rtAnalysisOutput.Font = New Font("Lucida Console", 9.75!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(6, 6)
            Me.rtAnalysisOutput.Location = point2
            Me.rtAnalysisOutput.Name = "rtAnalysisOutput"
            Me.rtAnalysisOutput.ReadOnly = True
            size2 = New Size(&H1EC, &H1D7)
            Me.rtAnalysisOutput.Size = size2
            Me.rtAnalysisOutput.TabIndex = 0
            Me.rtAnalysisOutput.Text = "Open a PIT file to analyze it's contents."
            Me.lblVersionInfo.AutoSize = True
            Me.lblVersionInfo.Font = New Font("Segoe UI Semibold", 12!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point2 = New Point(6, &H222)
            Me.lblVersionInfo.Location = point2
            Me.lblVersionInfo.Name = "lblVersionInfo"
            size2 = New Size(&H12A, &H15)
            Me.lblVersionInfo.Size = size2
            Me.lblVersionInfo.TabIndex = 9
            Me.lblVersionInfo.Text = "PIT Magic v#.#.# Copyright © Gaz 2012."
            Me.ofdPIT.DefaultExt = "pit"
            Me.ofdPIT.Filter = "Samsung PIT Files (*.pit)|*.pit"
            Me.ofdPIT.Title = "Open PIT File..."
            Me.sfdPIT.DefaultExt = "pit"
            Me.sfdPIT.Filter = "Samsung PIT Files (*.pit)|*.pit"
            Me.sfdPIT.Title = "Save PIT File As..."
            Me.btnDonate.Image = DirectCast(manager.GetObject("btnDonate.Image"), Image)
            Me.btnDonate.ImageAlign = ContentAlignment.MiddleLeft
            point2 = New Point(&H188, &H221)
            Me.btnDonate.Location = point2
            Me.btnDonate.Name = "btnDonate"
            padding2 = New Padding(5, 0, 0, 0)
            Me.btnDonate.Padding = padding2
            size2 = New Size(110, &H19)
            Me.btnDonate.Size = size2
            Me.btnDonate.TabIndex = &H27
            Me.btnDonate.Text = "Donate..."
            Me.btnDonate.UseVisualStyleBackColor = True
            Dim ef2 As New SizeF(6!, 13!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            size2 = New Size(&H200, &H241)
            Me.ClientSize = size2
            Me.Controls.Add(Me.btnDonate)
            Me.Controls.Add(Me.lblVersionInfo)
            Me.Controls.Add(Me.tcPITLayout)
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PIT_Magic_Main"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "PIT Magic"
            Me.tcPITLayout.ResumeLayout(False)
            Me.tabPITFileEditor.ResumeLayout(False)
            Me.gbPITOps.ResumeLayout(False)
            Me.gbPITOps.PerformLayout
            Me.gbPITFileHdrInfo.ResumeLayout(False)
            Me.gbPITFileHdrInfo.PerformLayout
            Me.gbHdrSize.ResumeLayout(False)
            Me.gbHdrSize.PerformLayout
            Me.gbCurrentPITEntry.ResumeLayout(False)
            Me.gbCurrentPITEntry.PerformLayout
            Me.numBinaryType.EndInit
            Me.numBlockCount.EndInit
            Me.numBlockSize.EndInit
            Me.numAttribute.EndInit
            Me.numUpdateAttribute.EndInit
            Me.numIdentifier.EndInit
            Me.numFileSize.EndInit
            Me.numFileOffset.EndInit
            Me.numDeviceType.EndInit
            Me.tabPITFileAnalysis.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout
        End Sub

        Private Sub numAttribute_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If ((Convert.ToInt64(Me.numAttribute.Value) And 2) > 0) Then
                Me.lblAttribStatus.Text = "STL"
            ElseIf ((Convert.ToInt64(Me.numAttribute.Value) And 1) > 0) Then
                Me.lblAttribStatus.Text = "READ / WRITE"
            Else
                Me.lblAttribStatus.Text = "READ ONLY"
            End If
        End Sub

        Private Sub numBinaryType_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If ((Convert.ToInt64(Me.numBinaryType.Value) And 0) > 0) Then
                Me.lblBinTypeStatus.Text = "APP. PROCESSOR"
            ElseIf ((Convert.ToInt64(Me.numBinaryType.Value) And 1) > 0) Then
                Me.lblBinTypeStatus.Text = "COM. PROCESSOR"
            Else
                Me.lblBinTypeStatus.Text = "UNKNOWN"
            End If
        End Sub

        Private Sub numDeviceType_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If ((Convert.ToInt64(Me.numDeviceType.Value) And 0) > 0) Then
                Me.lblDevTypeStatus.Text = "ONE NAND"
            ElseIf ((Convert.ToInt64(Me.numDeviceType.Value) And 1) > 0) Then
                Me.lblDevTypeStatus.Text = "FILE / FAT"
            ElseIf ((Convert.ToInt64(Me.numDeviceType.Value) And 2) > 0) Then
                Me.lblDevTypeStatus.Text = "MMC"
            ElseIf ((Convert.ToInt64(Me.numDeviceType.Value) And 3) > 0) Then
                Me.lblDevTypeStatus.Text = "ALL"
            Else
                Me.lblDevTypeStatus.Text = "UNKNOWN"
            End If
        End Sub

        Private Sub numUpdateAttribute_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            If ((Convert.ToInt64(Me.numUpdateAttribute.Value) And 1) > 0) Then
                Me.lblUpdAttrStatus.Text = "FOTA"
            ElseIf ((Convert.ToInt64(Me.numUpdateAttribute.Value) And 2) > 0) Then
                Me.lblUpdAttrStatus.Text = "FOTA, SECURE"
            Else
                Me.lblUpdAttrStatus.Text = "UNKNOWN"
            End If
        End Sub

        Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
            If (Me.CheckPITChanged = CheckPITStatus.PIT_Changed) Then
                Select Case Interaction.MsgBox((Path.GetFileName(Me.ofdPIT.FileName) & " has been modified. Do you want to save changes?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SavePITChanges
                        Exit Select
                    Case MsgBoxResult.Cancel
                        e.Cancel = True
                        Exit Select
                End Select
            ElseIf (Me.CheckPITChanged = CheckPITStatus.PIT_NewFile) Then
                Select Case Interaction.MsgBox((Me.txtPITFile.Text & " has been modified. Do you want to save new file?"), (MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel), Nothing)
                    Case MsgBoxResult.Yes
                        Me.SaveNewPITFile(e)
                        Exit Select
                    Case MsgBoxResult.Cancel
                        e.Cancel = True
                        Exit Select
                End Select
            End If
            MyBase.OnFormClosing(e)
        End Sub

        Private Sub PIT_Magic_Main_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub SaveNewPITFile(ByVal Optional e As FormClosingEventArgs = Nothing)
            Try 
                If (Me.cbPITEntries.Items.Count > 0) Then
                    Me.sfdPIT.FileName = Me.txtPITFile.Text
                    Me.sfdPIT.InitialDirectory = Me.AppPath
                    If (Me.sfdPIT.ShowDialog = DialogResult.Cancel) Then
                        If (Not e Is Nothing) Then
                            e.Cancel = True
                        End If
                    Else
                        Dim stream2 As New MemoryStream
                        Dim byteStream As New FileStream(Me.sfdPIT.FileName, FileMode.Create)
                        Dim outputStream As New PitOutputStream(byteStream)
                        Me.myPitData.WritePITFile(outputStream)
                        stream2.WriteTo(byteStream)
                        stream2.Close
                        byteStream.Close
                        Me.ofdPIT.FileName = Me.sfdPIT.FileName
                        Me.btnSave.Enabled = True
                        Me.originalPitData = Nothing
                        Me.originalPitData = New PitData
                        Me.originalPitData = PitData.Clone(Me.myPitData)
                        Interaction.MsgBox(("Changes saved to '" & Path.GetFileName(Me.sfdPIT.FileName) & "' successfully."), MsgBoxStyle.Information, Nothing)
                    End If
                Else
                    Interaction.MsgBox("You MUST create at least ONE PIT Entry before saving to disk.", MsgBoxStyle.Exclamation, Nothing)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("An error occurred while saving the file to disk.", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub SavePITChanges()
            Try 
                If (Me.cbPITEntries.Items.Count > 0) Then
                    Dim stream2 As New MemoryStream
                    Dim byteStream As New FileStream(Me.ofdPIT.FileName, FileMode.Create)
                    Dim outputStream As New PitOutputStream(byteStream)
                    Me.myPitData.WritePITFile(outputStream)
                    stream2.WriteTo(byteStream)
                    stream2.Close
                    byteStream.Close
                    Me.originalPitData = Nothing
                    Me.originalPitData = New PitData
                    Me.originalPitData = PitData.Clone(Me.myPitData)
                    Interaction.MsgBox(("Changes saved to '" & Path.GetFileName(Me.ofdPIT.FileName) & "' successfully."), MsgBoxStyle.Information, Nothing)
                Else
                    Interaction.MsgBox("You MUST create at least ONE PIT Entry before saving to disk.", MsgBoxStyle.Exclamation, Nothing)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Interaction.MsgBox("An error occurred while saving the file to disk.", MsgBoxStyle.Critical, Nothing)
                ProjectData.ClearProjectError
            End Try
        End Sub

        Private Sub txtDummy1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim array As Char() = New Char(0  - 1) {}
            If (Me.cbDataType.SelectedIndex = 0) Then
                Me.txtDummy1.MaxLength = 4
            Else
                If (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy1.MaxLength = 8
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString.ToUpper)
                    array = New Char() { "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, ChrW(8), ChrW(127) }
                End If
                If (Array.IndexOf(Of Char)(array, e.KeyChar) = -1) Then
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub txtDummy1_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdatePITHeader
        End Sub

        Private Sub txtDummy2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim array As Char() = New Char(0  - 1) {}
            If (Me.cbDataType.SelectedIndex = 0) Then
                Me.txtDummy2.MaxLength = 4
            Else
                If (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy2.MaxLength = 8
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString.ToUpper)
                    array = New Char() { "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, ChrW(8), ChrW(127) }
                End If
                If (Array.IndexOf(Of Char)(array, e.KeyChar) = -1) Then
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub txtDummy2_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdatePITHeader
        End Sub

        Private Sub txtDummy3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim array As Char() = New Char(0  - 1) {}
            If (Me.cbDataType.SelectedIndex = 0) Then
                Me.txtDummy3.MaxLength = 4
            Else
                If (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy3.MaxLength = 8
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString.ToUpper)
                    array = New Char() { "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, ChrW(8), ChrW(127) }
                End If
                If (Array.IndexOf(Of Char)(array, e.KeyChar) = -1) Then
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub txtDummy3_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdatePITHeader
        End Sub

        Private Sub txtDummy4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim array As Char() = New Char(0  - 1) {}
            If (Me.cbDataType.SelectedIndex = 0) Then
                Me.txtDummy4.MaxLength = 4
            Else
                If (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy4.MaxLength = 8
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString.ToUpper)
                    array = New Char() { "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, ChrW(8), ChrW(127) }
                End If
                If (Array.IndexOf(Of Char)(array, e.KeyChar) = -1) Then
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub txtDummy4_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdatePITHeader
        End Sub

        Private Sub txtDummy5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            Dim array As Char() = New Char(0  - 1) {}
            If (Me.cbDataType.SelectedIndex = 0) Then
                Me.txtDummy5.MaxLength = 4
            Else
                If (Me.cbDataType.SelectedIndex = 1) Then
                    Me.txtDummy5.MaxLength = 8
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString.ToUpper)
                    array = New Char() { "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "0"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, ChrW(8), ChrW(127) }
                End If
                If (Array.IndexOf(Of Char)(array, e.KeyChar) = -1) Then
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub txtDummy5_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
            Me.UpdatePITHeader
        End Sub

        Private Sub UpdatePIT()
            Me.UpdatePITHeader
            If (Me.cbPITEntries.Items.Count > 0) Then
                Me.myPitEntry.BinaryType = DirectCast(Convert.ToInt32(Me.numBinaryType.Value), EntryBinaryType)
                Me.myPitEntry.DeviceType = DirectCast(Convert.ToInt32(Me.numDeviceType.Value), EntryDeviceType)
                Me.myPitEntry.Identifier = Convert.ToInt32(Me.numIdentifier.Value)
                Me.myPitEntry.Attribute = DirectCast(Convert.ToInt32(Me.numAttribute.Value), EntryAttribute)
                Me.myPitEntry.UpdateAttribute = DirectCast(Convert.ToInt32(Me.numUpdateAttribute.Value), EntryUpdateAttribute)
                Me.myPitEntry.BlockSize = Convert.ToInt32(Me.numBlockSize.Value)
                Me.myPitEntry.BlockCount = Convert.ToInt32(Me.numBlockCount.Value)
                Me.myPitEntry.FileOffset = Convert.ToInt32(Me.numFileOffset.Value)
                Me.myPitEntry.FileSize = Convert.ToInt32(Me.numFileSize.Value)
                If String.IsNullOrEmpty(Me.txtPartName.Text) Then
                    Me.myPitEntry.PartitionName = String.Empty
                Else
                    Me.myPitEntry.PartitionName = Me.txtPartName.Text
                End If
                If String.IsNullOrEmpty(Me.txtFlashFileName.Text) Then
                    Me.myPitEntry.FlashFileName = String.Empty
                Else
                    Me.myPitEntry.FlashFileName = Me.txtFlashFileName.Text
                End If
                If String.IsNullOrEmpty(Me.txtFotaFileName.Text) Then
                    Me.myPitEntry.FotaFileName = String.Empty
                Else
                    Me.myPitEntry.FotaFileName = Me.txtFotaFileName.Text
                End If
            End If
        End Sub

        Private Sub UpdatePITHeader()
            If (Me.myPitData Is Nothing) Then
                Me.myPitData = New PitData
            End If
            If Not String.IsNullOrEmpty(Me.txtDummy1.Text) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.myPitData.DummyData1 = DummyDataType.GetDummyDataFromStr(Me.txtDummy1.Text)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.myPitData.DummyData1 = DummyDataType.GetDummyDataFromHexStr(Me.txtDummy1.Text)
                End If
            Else
                Me.myPitData.DummyData1 = New Byte() { 0, 0, 0, 0 }
            End If
            If Not String.IsNullOrEmpty(Me.txtDummy2.Text) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.myPitData.DummyData2 = DummyDataType.GetDummyDataFromStr(Me.txtDummy2.Text)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.myPitData.DummyData2 = DummyDataType.GetDummyDataFromHexStr(Me.txtDummy2.Text)
                End If
            Else
                Me.myPitData.DummyData2 = New Byte() { 0, 0, 0, 0 }
            End If
            If Not String.IsNullOrEmpty(Me.txtDummy3.Text) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.myPitData.DummyData3 = DummyDataType.GetDummyDataFromStr(Me.txtDummy3.Text)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.myPitData.DummyData3 = DummyDataType.GetDummyDataFromHexStr(Me.txtDummy3.Text)
                End If
            Else
                Me.myPitData.DummyData3 = New Byte() { 0, 0, 0, 0 }
            End If
            If Not String.IsNullOrEmpty(Me.txtDummy4.Text) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.myPitData.DummyData4 = DummyDataType.GetDummyDataFromStr(Me.txtDummy4.Text)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.myPitData.DummyData4 = DummyDataType.GetDummyDataFromHexStr(Me.txtDummy4.Text)
                End If
            Else
                Me.myPitData.DummyData4 = New Byte() { 0, 0, 0, 0 }
            End If
            If Not String.IsNullOrEmpty(Me.txtDummy5.Text) Then
                If (Me.cbDataType.SelectedIndex = 0) Then
                    Me.myPitData.DummyData5 = DummyDataType.GetDummyDataFromStr(Me.txtDummy5.Text)
                ElseIf (Me.cbDataType.SelectedIndex = 1) Then
                    Me.myPitData.DummyData5 = DummyDataType.GetDummyDataFromHexStr(Me.txtDummy5.Text)
                End If
            Else
                Me.myPitData.DummyData5 = New Byte() { 0, 0, 0, 0 }
            End If
        End Sub


        ' Properties
        Friend Overridable Property btnCopyClipboard As Button
            Get
                Return Me._btnCopyClipboard
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnCopyClipboard_Click)
                If (Not Me._btnCopyClipboard Is Nothing) Then
                    RemoveHandler Me._btnCopyClipboard.Click, handler
                End If
                Me._btnCopyClipboard = WithEventsValue
                If (Not Me._btnCopyClipboard Is Nothing) Then
                    AddHandler Me._btnCopyClipboard.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnCreatePITEntry As Button
            Get
                Return Me._btnCreatePITEntry
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnCreatePITEntry_Click)
                If (Not Me._btnCreatePITEntry Is Nothing) Then
                    RemoveHandler Me._btnCreatePITEntry.Click, handler
                End If
                Me._btnCreatePITEntry = WithEventsValue
                If (Not Me._btnCreatePITEntry Is Nothing) Then
                    AddHandler Me._btnCreatePITEntry.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnDonate As Button
            Get
                Return Me._btnDonate
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnDonate_Click)
                If (Not Me._btnDonate Is Nothing) Then
                    RemoveHandler Me._btnDonate.Click, handler
                End If
                Me._btnDonate = WithEventsValue
                If (Not Me._btnDonate Is Nothing) Then
                    AddHandler Me._btnDonate.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnExport As Button
            Get
                Return Me._btnExport
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnExport_Click)
                If (Not Me._btnExport Is Nothing) Then
                    RemoveHandler Me._btnExport.Click, handler
                End If
                Me._btnExport = WithEventsValue
                If (Not Me._btnExport Is Nothing) Then
                    AddHandler Me._btnExport.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnNew As Button
            Get
                Return Me._btnNew
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnNew_Click)
                If (Not Me._btnNew Is Nothing) Then
                    RemoveHandler Me._btnNew.Click, handler
                End If
                Me._btnNew = WithEventsValue
                If (Not Me._btnNew Is Nothing) Then
                    AddHandler Me._btnNew.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnOpen As Button
            Get
                Return Me._btnOpen
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnOpen_Click)
                If (Not Me._btnOpen Is Nothing) Then
                    RemoveHandler Me._btnOpen.Click, handler
                End If
                Me._btnOpen = WithEventsValue
                If (Not Me._btnOpen Is Nothing) Then
                    AddHandler Me._btnOpen.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnOpenPITFile As Button
            Get
                Return Me._btnOpenPITFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnOpenPITFile_Click)
                If (Not Me._btnOpenPITFile Is Nothing) Then
                    RemoveHandler Me._btnOpenPITFile.Click, handler
                End If
                Me._btnOpenPITFile = WithEventsValue
                If (Not Me._btnOpenPITFile Is Nothing) Then
                    AddHandler Me._btnOpenPITFile.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnRemPITEntry As Button
            Get
                Return Me._btnRemPITEntry
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnRemPITEntry_Click)
                If (Not Me._btnRemPITEntry Is Nothing) Then
                    RemoveHandler Me._btnRemPITEntry.Click, handler
                End If
                Me._btnRemPITEntry = WithEventsValue
                If (Not Me._btnRemPITEntry Is Nothing) Then
                    AddHandler Me._btnRemPITEntry.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnResetForm As Button
            Get
                Return Me._btnResetForm
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnResetForm_Click)
                If (Not Me._btnResetForm Is Nothing) Then
                    RemoveHandler Me._btnResetForm.Click, handler
                End If
                Me._btnResetForm = WithEventsValue
                If (Not Me._btnResetForm Is Nothing) Then
                    AddHandler Me._btnResetForm.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnSave As Button
            Get
                Return Me._btnSave
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnSave_Click)
                If (Not Me._btnSave Is Nothing) Then
                    RemoveHandler Me._btnSave.Click, handler
                End If
                Me._btnSave = WithEventsValue
                If (Not Me._btnSave Is Nothing) Then
                    AddHandler Me._btnSave.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property btnSaveAs As Button
            Get
                Return Me._btnSaveAs
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.btnSaveAs_Click)
                If (Not Me._btnSaveAs Is Nothing) Then
                    RemoveHandler Me._btnSaveAs.Click, handler
                End If
                Me._btnSaveAs = WithEventsValue
                If (Not Me._btnSaveAs Is Nothing) Then
                    AddHandler Me._btnSaveAs.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property cbDataType As ComboBox
            Get
                Return Me._cbDataType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ComboBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cbDumDisplayType_SelectedIndexChanged)
                If (Not Me._cbDataType Is Nothing) Then
                    RemoveHandler Me._cbDataType.SelectedIndexChanged, handler
                End If
                Me._cbDataType = WithEventsValue
                If (Not Me._cbDataType Is Nothing) Then
                    AddHandler Me._cbDataType.SelectedIndexChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property cbPITEntries As ComboBox
            Get
                Return Me._cbPITEntries
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As ComboBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.cbPITEntries_Click)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.cbPITEntries_SelectedIndexChanged)
                If (Not Me._cbPITEntries Is Nothing) Then
                    RemoveHandler Me._cbPITEntries.Click, handler
                    RemoveHandler Me._cbPITEntries.SelectedIndexChanged, handler2
                End If
                Me._cbPITEntries = WithEventsValue
                If (Not Me._cbPITEntries Is Nothing) Then
                    AddHandler Me._cbPITEntries.Click, handler
                    AddHandler Me._cbPITEntries.SelectedIndexChanged, handler2
                End If
            End Set
        End Property

        Friend Overridable Property gbCurrentPITEntry As GroupBox
            Get
                Return Me._gbCurrentPITEntry
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._gbCurrentPITEntry = WithEventsValue
            End Set
        End Property

        Friend Overridable Property gbHdrSize As GroupBox
            Get
                Return Me._gbHdrSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._gbHdrSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property gbPITFileHdrInfo As GroupBox
            Get
                Return Me._gbPITFileHdrInfo
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._gbPITFileHdrInfo = WithEventsValue
            End Set
        End Property

        Friend Overridable Property gbPITOps As GroupBox
            Get
                Return Me._gbPITOps
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                Me._gbPITOps = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label4 As Label
            Get
                Return Me._Label4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label4 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label5 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label6 As Label
            Get
                Return Me._Label6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label6 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label7 As Label
            Get
                Return Me._Label7
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label7 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Label8 As Label
            Get
                Return Me._Label8
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._Label8 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblAttribStatus As Label
            Get
                Return Me._lblAttribStatus
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblAttribStatus = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblAttribute As Label
            Get
                Return Me._lblAttribute
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblAttribute = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblBinaryType As Label
            Get
                Return Me._lblBinaryType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblBinaryType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblBinTypeStatus As Label
            Get
                Return Me._lblBinTypeStatus
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblBinTypeStatus = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblBlockCount As Label
            Get
                Return Me._lblBlockCount
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblBlockCount = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblBlockSize As Label
            Get
                Return Me._lblBlockSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblBlockSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblDeviceType As Label
            Get
                Return Me._lblDeviceType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblDeviceType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblDevTypeStatus As Label
            Get
                Return Me._lblDevTypeStatus
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblDevTypeStatus = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblDummyData As Label
            Get
                Return Me._lblDummyData
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblDummyData = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblDummyDataType As Label
            Get
                Return Me._lblDummyDataType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblDummyDataType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblDummyDataTypeMsg As Label
            Get
                Return Me._lblDummyDataTypeMsg
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblDummyDataTypeMsg = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFileOffset As Label
            Get
                Return Me._lblFileOffset
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblFileOffset = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFileSize As Label
            Get
                Return Me._lblFileSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblFileSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFlashFileName As Label
            Get
                Return Me._lblFlashFileName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblFlashFileName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblFotaFileName As Label
            Get
                Return Me._lblFotaFileName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblFotaFileName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHdrMagic As Label
            Get
                Return Me._lblHdrMagic
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHdrMagic = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHdrMagicType As Label
            Get
                Return Me._lblHdrMagicType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHdrMagicType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblHdrSizeType As Label
            Get
                Return Me._lblHdrSizeType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblHdrSizeType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblIdentifier As Label
            Get
                Return Me._lblIdentifier
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblIdentifier = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblPartName As Label
            Get
                Return Me._lblPartName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblPartName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblPITEntryCnt As Label
            Get
                Return Me._lblPITEntryCnt
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblPITEntryCnt = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblPITEntryCntType As Label
            Get
                Return Me._lblPITEntryCntType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblPITEntryCntType = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblPITEntryList As Label
            Get
                Return Me._lblPITEntryList
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblPITEntryList = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblPITFile As Label
            Get
                Return Me._lblPITFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblPITFile = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblUpdateAttribute As Label
            Get
                Return Me._lblUpdateAttribute
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblUpdateAttribute = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblUpdAttrStatus As Label
            Get
                Return Me._lblUpdAttrStatus
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblUpdAttrStatus = WithEventsValue
            End Set
        End Property

        Friend Overridable Property lblVersionInfo As Label
            Get
                Return Me._lblVersionInfo
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                Me._lblVersionInfo = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numAttribute As NumericUpDown
            Get
                Return Me._numAttribute
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.numAttribute_ValueChanged)
                If (Not Me._numAttribute Is Nothing) Then
                    RemoveHandler Me._numAttribute.ValueChanged, handler
                End If
                Me._numAttribute = WithEventsValue
                If (Not Me._numAttribute Is Nothing) Then
                    AddHandler Me._numAttribute.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property numBinaryType As NumericUpDown
            Get
                Return Me._numBinaryType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.numBinaryType_ValueChanged)
                If (Not Me._numBinaryType Is Nothing) Then
                    RemoveHandler Me._numBinaryType.ValueChanged, handler
                End If
                Me._numBinaryType = WithEventsValue
                If (Not Me._numBinaryType Is Nothing) Then
                    AddHandler Me._numBinaryType.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property numBlockCount As NumericUpDown
            Get
                Return Me._numBlockCount
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numBlockCount = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numBlockSize As NumericUpDown
            Get
                Return Me._numBlockSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numBlockSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numDeviceType As NumericUpDown
            Get
                Return Me._numDeviceType
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.numDeviceType_ValueChanged)
                If (Not Me._numDeviceType Is Nothing) Then
                    RemoveHandler Me._numDeviceType.ValueChanged, handler
                End If
                Me._numDeviceType = WithEventsValue
                If (Not Me._numDeviceType Is Nothing) Then
                    AddHandler Me._numDeviceType.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property numFileOffset As NumericUpDown
            Get
                Return Me._numFileOffset
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numFileOffset = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numFileSize As NumericUpDown
            Get
                Return Me._numFileSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numFileSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numIdentifier As NumericUpDown
            Get
                Return Me._numIdentifier
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Me._numIdentifier = WithEventsValue
            End Set
        End Property

        Friend Overridable Property numUpdateAttribute As NumericUpDown
            Get
                Return Me._numUpdateAttribute
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As NumericUpDown)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.numUpdateAttribute_ValueChanged)
                If (Not Me._numUpdateAttribute Is Nothing) Then
                    RemoveHandler Me._numUpdateAttribute.ValueChanged, handler
                End If
                Me._numUpdateAttribute = WithEventsValue
                If (Not Me._numUpdateAttribute Is Nothing) Then
                    AddHandler Me._numUpdateAttribute.ValueChanged, handler
                End If
            End Set
        End Property

        Friend Overridable Property ofdPIT As OpenFileDialog
            Get
                Return Me._ofdPIT
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As OpenFileDialog)
                Me._ofdPIT = WithEventsValue
            End Set
        End Property

        Friend Overridable Property rtAnalysisOutput As RichTextBox
            Get
                Return Me._rtAnalysisOutput
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As RichTextBox)
                Me._rtAnalysisOutput = WithEventsValue
            End Set
        End Property

        Friend Overridable Property sfdPIT As SaveFileDialog
            Get
                Return Me._sfdPIT
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As SaveFileDialog)
                Me._sfdPIT = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tabPITFileAnalysis As TabPage
            Get
                Return Me._tabPITFileAnalysis
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabPage)
                Me._tabPITFileAnalysis = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tabPITFileEditor As TabPage
            Get
                Return Me._tabPITFileEditor
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabPage)
                Me._tabPITFileEditor = WithEventsValue
            End Set
        End Property

        Friend Overridable Property tcPITLayout As TabControl
            Get
                Return Me._tcPITLayout
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabControl)
                Me._tcPITLayout = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtDummy1 As TextBox
            Get
                Return Me._txtDummy1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Dim handler As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.txtDummy1_KeyPress)
                Dim handler2 As EventHandler = New EventHandler(AddressOf Me.txtDummy1_LostFocus)
                If (Not Me._txtDummy1 Is Nothing) Then
                    RemoveHandler Me._txtDummy1.KeyPress, handler
                    RemoveHandler Me._txtDummy1.LostFocus, handler2
                End If
                Me._txtDummy1 = WithEventsValue
                If (Not Me._txtDummy1 Is Nothing) Then
                    AddHandler Me._txtDummy1.KeyPress, handler
                    AddHandler Me._txtDummy1.LostFocus, handler2
                End If
            End Set
        End Property

        Friend Overridable Property txtDummy2 As TextBox
            Get
                Return Me._txtDummy2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.txtDummy2_LostFocus)
                Dim handler2 As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.txtDummy2_KeyPress)
                If (Not Me._txtDummy2 Is Nothing) Then
                    RemoveHandler Me._txtDummy2.LostFocus, handler
                    RemoveHandler Me._txtDummy2.KeyPress, handler2
                End If
                Me._txtDummy2 = WithEventsValue
                If (Not Me._txtDummy2 Is Nothing) Then
                    AddHandler Me._txtDummy2.LostFocus, handler
                    AddHandler Me._txtDummy2.KeyPress, handler2
                End If
            End Set
        End Property

        Friend Overridable Property txtDummy3 As TextBox
            Get
                Return Me._txtDummy3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.txtDummy3_LostFocus)
                Dim handler2 As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.txtDummy3_KeyPress)
                If (Not Me._txtDummy3 Is Nothing) Then
                    RemoveHandler Me._txtDummy3.LostFocus, handler
                    RemoveHandler Me._txtDummy3.KeyPress, handler2
                End If
                Me._txtDummy3 = WithEventsValue
                If (Not Me._txtDummy3 Is Nothing) Then
                    AddHandler Me._txtDummy3.LostFocus, handler
                    AddHandler Me._txtDummy3.KeyPress, handler2
                End If
            End Set
        End Property

        Friend Overridable Property txtDummy4 As TextBox
            Get
                Return Me._txtDummy4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.txtDummy4_LostFocus)
                Dim handler2 As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.txtDummy4_KeyPress)
                If (Not Me._txtDummy4 Is Nothing) Then
                    RemoveHandler Me._txtDummy4.LostFocus, handler
                    RemoveHandler Me._txtDummy4.KeyPress, handler2
                End If
                Me._txtDummy4 = WithEventsValue
                If (Not Me._txtDummy4 Is Nothing) Then
                    AddHandler Me._txtDummy4.LostFocus, handler
                    AddHandler Me._txtDummy4.KeyPress, handler2
                End If
            End Set
        End Property

        Friend Overridable Property txtDummy5 As TextBox
            Get
                Return Me._txtDummy5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.txtDummy5_LostFocus)
                Dim handler2 As KeyPressEventHandler = New KeyPressEventHandler(AddressOf Me.txtDummy5_KeyPress)
                If (Not Me._txtDummy5 Is Nothing) Then
                    RemoveHandler Me._txtDummy5.LostFocus, handler
                    RemoveHandler Me._txtDummy5.KeyPress, handler2
                End If
                Me._txtDummy5 = WithEventsValue
                If (Not Me._txtDummy5 Is Nothing) Then
                    AddHandler Me._txtDummy5.LostFocus, handler
                    AddHandler Me._txtDummy5.KeyPress, handler2
                End If
            End Set
        End Property

        Friend Overridable Property txtFlashFileName As TextBox
            Get
                Return Me._txtFlashFileName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtFlashFileName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtFotaFileName As TextBox
            Get
                Return Me._txtFotaFileName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtFotaFileName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtHdrMagic As TextBox
            Get
                Return Me._txtHdrMagic
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtHdrMagic = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtHdrSize As TextBox
            Get
                Return Me._txtHdrSize
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtHdrSize = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtPartName As TextBox
            Get
                Return Me._txtPartName
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtPartName = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtPITEntryCnt As TextBox
            Get
                Return Me._txtPITEntryCnt
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtPITEntryCnt = WithEventsValue
            End Set
        End Property

        Friend Overridable Property txtPITFile As TextBox
            Get
                Return Me._txtPITFile
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                Me._txtPITFile = WithEventsValue
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("btnCopyClipboard")> _
        Private _btnCopyClipboard As Button
        <AccessedThroughProperty("btnCreatePITEntry")> _
        Private _btnCreatePITEntry As Button
        <AccessedThroughProperty("btnDonate")> _
        Private _btnDonate As Button
        <AccessedThroughProperty("btnExport")> _
        Private _btnExport As Button
        <AccessedThroughProperty("btnNew")> _
        Private _btnNew As Button
        <AccessedThroughProperty("btnOpen")> _
        Private _btnOpen As Button
        <AccessedThroughProperty("btnOpenPITFile")> _
        Private _btnOpenPITFile As Button
        <AccessedThroughProperty("btnRemPITEntry")> _
        Private _btnRemPITEntry As Button
        <AccessedThroughProperty("btnResetForm")> _
        Private _btnResetForm As Button
        <AccessedThroughProperty("btnSave")> _
        Private _btnSave As Button
        <AccessedThroughProperty("btnSaveAs")> _
        Private _btnSaveAs As Button
        <AccessedThroughProperty("cbDataType")> _
        Private _cbDataType As ComboBox
        <AccessedThroughProperty("cbPITEntries")> _
        Private _cbPITEntries As ComboBox
        <AccessedThroughProperty("gbCurrentPITEntry")> _
        Private _gbCurrentPITEntry As GroupBox
        <AccessedThroughProperty("gbHdrSize")> _
        Private _gbHdrSize As GroupBox
        <AccessedThroughProperty("gbPITFileHdrInfo")> _
        Private _gbPITFileHdrInfo As GroupBox
        <AccessedThroughProperty("gbPITOps")> _
        Private _gbPITOps As GroupBox
        <AccessedThroughProperty("Label4")> _
        Private _Label4 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("Label7")> _
        Private _Label7 As Label
        <AccessedThroughProperty("Label8")> _
        Private _Label8 As Label
        <AccessedThroughProperty("lblAttribStatus")> _
        Private _lblAttribStatus As Label
        <AccessedThroughProperty("lblAttribute")> _
        Private _lblAttribute As Label
        <AccessedThroughProperty("lblBinaryType")> _
        Private _lblBinaryType As Label
        <AccessedThroughProperty("lblBinTypeStatus")> _
        Private _lblBinTypeStatus As Label
        <AccessedThroughProperty("lblBlockCount")> _
        Private _lblBlockCount As Label
        <AccessedThroughProperty("lblBlockSize")> _
        Private _lblBlockSize As Label
        <AccessedThroughProperty("lblDeviceType")> _
        Private _lblDeviceType As Label
        <AccessedThroughProperty("lblDevTypeStatus")> _
        Private _lblDevTypeStatus As Label
        <AccessedThroughProperty("lblDummyData")> _
        Private _lblDummyData As Label
        <AccessedThroughProperty("lblDummyDataType")> _
        Private _lblDummyDataType As Label
        <AccessedThroughProperty("lblDummyDataTypeMsg")> _
        Private _lblDummyDataTypeMsg As Label
        <AccessedThroughProperty("lblFileOffset")> _
        Private _lblFileOffset As Label
        <AccessedThroughProperty("lblFileSize")> _
        Private _lblFileSize As Label
        <AccessedThroughProperty("lblFlashFileName")> _
        Private _lblFlashFileName As Label
        <AccessedThroughProperty("lblFotaFileName")> _
        Private _lblFotaFileName As Label
        <AccessedThroughProperty("lblHdrMagic")> _
        Private _lblHdrMagic As Label
        <AccessedThroughProperty("lblHdrMagicType")> _
        Private _lblHdrMagicType As Label
        <AccessedThroughProperty("lblHdrSizeType")> _
        Private _lblHdrSizeType As Label
        <AccessedThroughProperty("lblIdentifier")> _
        Private _lblIdentifier As Label
        <AccessedThroughProperty("lblPartName")> _
        Private _lblPartName As Label
        <AccessedThroughProperty("lblPITEntryCnt")> _
        Private _lblPITEntryCnt As Label
        <AccessedThroughProperty("lblPITEntryCntType")> _
        Private _lblPITEntryCntType As Label
        <AccessedThroughProperty("lblPITEntryList")> _
        Private _lblPITEntryList As Label
        <AccessedThroughProperty("lblPITFile")> _
        Private _lblPITFile As Label
        <AccessedThroughProperty("lblUpdateAttribute")> _
        Private _lblUpdateAttribute As Label
        <AccessedThroughProperty("lblUpdAttrStatus")> _
        Private _lblUpdAttrStatus As Label
        <AccessedThroughProperty("lblVersionInfo")> _
        Private _lblVersionInfo As Label
        <AccessedThroughProperty("numAttribute")> _
        Private _numAttribute As NumericUpDown
        <AccessedThroughProperty("numBinaryType")> _
        Private _numBinaryType As NumericUpDown
        <AccessedThroughProperty("numBlockCount")> _
        Private _numBlockCount As NumericUpDown
        <AccessedThroughProperty("numBlockSize")> _
        Private _numBlockSize As NumericUpDown
        <AccessedThroughProperty("numDeviceType")> _
        Private _numDeviceType As NumericUpDown
        <AccessedThroughProperty("numFileOffset")> _
        Private _numFileOffset As NumericUpDown
        <AccessedThroughProperty("numFileSize")> _
        Private _numFileSize As NumericUpDown
        <AccessedThroughProperty("numIdentifier")> _
        Private _numIdentifier As NumericUpDown
        <AccessedThroughProperty("numUpdateAttribute")> _
        Private _numUpdateAttribute As NumericUpDown
        <AccessedThroughProperty("ofdPIT")> _
        Private _ofdPIT As OpenFileDialog
        <AccessedThroughProperty("rtAnalysisOutput")> _
        Private _rtAnalysisOutput As RichTextBox
        <AccessedThroughProperty("sfdPIT")> _
        Private _sfdPIT As SaveFileDialog
        <AccessedThroughProperty("tabPITFileAnalysis")> _
        Private _tabPITFileAnalysis As TabPage
        <AccessedThroughProperty("tabPITFileEditor")> _
        Private _tabPITFileEditor As TabPage
        <AccessedThroughProperty("tcPITLayout")> _
        Private _tcPITLayout As TabControl
        <AccessedThroughProperty("txtDummy1")> _
        Private _txtDummy1 As TextBox
        <AccessedThroughProperty("txtDummy2")> _
        Private _txtDummy2 As TextBox
        <AccessedThroughProperty("txtDummy3")> _
        Private _txtDummy3 As TextBox
        <AccessedThroughProperty("txtDummy4")> _
        Private _txtDummy4 As TextBox
        <AccessedThroughProperty("txtDummy5")> _
        Private _txtDummy5 As TextBox
        <AccessedThroughProperty("txtFlashFileName")> _
        Private _txtFlashFileName As TextBox
        <AccessedThroughProperty("txtFotaFileName")> _
        Private _txtFotaFileName As TextBox
        <AccessedThroughProperty("txtHdrMagic")> _
        Private _txtHdrMagic As TextBox
        <AccessedThroughProperty("txtHdrSize")> _
        Private _txtHdrSize As TextBox
        <AccessedThroughProperty("txtPartName")> _
        Private _txtPartName As TextBox
        <AccessedThroughProperty("txtPITEntryCnt")> _
        Private _txtPITEntryCnt As TextBox
        <AccessedThroughProperty("txtPITFile")> _
        Private _txtPITFile As TextBox
        Private AppPath As String
        Private components As IContainer
        Private myPitData As PitData
        Private myPitEntry As PitEntry
        Private myPitInputStream As PitInputStream
        Private myPitOutputStream As PitOutputStream
        Private newFileCounter As Integer
        Private originalPitData As PitData

        ' Nested Types
        Public Enum CheckPITStatus
            ' Fields
            PIT_Changed = 1
            PIT_NewFile = 2
            PIT_Unchanged = 0
        End Enum
    End Class
End Namespace

