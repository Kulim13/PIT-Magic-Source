namespace PIT_Magic
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class PIT_Magic_Main : Form
    {
        [AccessedThroughProperty("btnCopyClipboard")]
        private Button _btnCopyClipboard;
        [AccessedThroughProperty("btnCreatePITEntry")]
        private Button _btnCreatePITEntry;
        [AccessedThroughProperty("btnDonate")]
        private Button _btnDonate;
        [AccessedThroughProperty("btnExport")]
        private Button _btnExport;
        [AccessedThroughProperty("btnNew")]
        private Button _btnNew;
        [AccessedThroughProperty("btnOpen")]
        private Button _btnOpen;
        [AccessedThroughProperty("btnOpenPITFile")]
        private Button _btnOpenPITFile;
        [AccessedThroughProperty("btnRemPITEntry")]
        private Button _btnRemPITEntry;
        [AccessedThroughProperty("btnResetForm")]
        private Button _btnResetForm;
        [AccessedThroughProperty("btnSave")]
        private Button _btnSave;
        [AccessedThroughProperty("btnSaveAs")]
        private Button _btnSaveAs;
        [AccessedThroughProperty("cbDataType")]
        private ComboBox _cbDataType;
        [AccessedThroughProperty("cbPITEntries")]
        private ComboBox _cbPITEntries;
        [AccessedThroughProperty("gbCurrentPITEntry")]
        private GroupBox _gbCurrentPITEntry;
        [AccessedThroughProperty("gbHdrSize")]
        private GroupBox _gbHdrSize;
        [AccessedThroughProperty("gbPITFileHdrInfo")]
        private GroupBox _gbPITFileHdrInfo;
        [AccessedThroughProperty("gbPITOps")]
        private GroupBox _gbPITOps;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("Label5")]
        private Label _Label5;
        [AccessedThroughProperty("Label6")]
        private Label _Label6;
        [AccessedThroughProperty("Label7")]
        private Label _Label7;
        [AccessedThroughProperty("Label8")]
        private Label _Label8;
        [AccessedThroughProperty("lblAttribStatus")]
        private Label _lblAttribStatus;
        [AccessedThroughProperty("lblAttribute")]
        private Label _lblAttribute;
        [AccessedThroughProperty("lblBinaryType")]
        private Label _lblBinaryType;
        [AccessedThroughProperty("lblBinTypeStatus")]
        private Label _lblBinTypeStatus;
        [AccessedThroughProperty("lblBlockCount")]
        private Label _lblBlockCount;
        [AccessedThroughProperty("lblBlockSize")]
        private Label _lblBlockSize;
        [AccessedThroughProperty("lblDeviceType")]
        private Label _lblDeviceType;
        [AccessedThroughProperty("lblDevTypeStatus")]
        private Label _lblDevTypeStatus;
        [AccessedThroughProperty("lblDummyData")]
        private Label _lblDummyData;
        [AccessedThroughProperty("lblDummyDataType")]
        private Label _lblDummyDataType;
        [AccessedThroughProperty("lblDummyDataTypeMsg")]
        private Label _lblDummyDataTypeMsg;
        [AccessedThroughProperty("lblFileOffset")]
        private Label _lblFileOffset;
        [AccessedThroughProperty("lblFileSize")]
        private Label _lblFileSize;
        [AccessedThroughProperty("lblFlashFileName")]
        private Label _lblFlashFileName;
        [AccessedThroughProperty("lblFotaFileName")]
        private Label _lblFotaFileName;
        [AccessedThroughProperty("lblHdrMagic")]
        private Label _lblHdrMagic;
        [AccessedThroughProperty("lblHdrMagicType")]
        private Label _lblHdrMagicType;
        [AccessedThroughProperty("lblHdrSizeType")]
        private Label _lblHdrSizeType;
        [AccessedThroughProperty("lblIdentifier")]
        private Label _lblIdentifier;
        [AccessedThroughProperty("lblPartName")]
        private Label _lblPartName;
        [AccessedThroughProperty("lblPITEntryCnt")]
        private Label _lblPITEntryCnt;
        [AccessedThroughProperty("lblPITEntryCntType")]
        private Label _lblPITEntryCntType;
        [AccessedThroughProperty("lblPITEntryList")]
        private Label _lblPITEntryList;
        [AccessedThroughProperty("lblPITFile")]
        private Label _lblPITFile;
        [AccessedThroughProperty("lblUpdateAttribute")]
        private Label _lblUpdateAttribute;
        [AccessedThroughProperty("lblUpdAttrStatus")]
        private Label _lblUpdAttrStatus;
        [AccessedThroughProperty("lblVersionInfo")]
        private Label _lblVersionInfo;
        [AccessedThroughProperty("numAttribute")]
        private NumericUpDown _numAttribute;
        [AccessedThroughProperty("numBinaryType")]
        private NumericUpDown _numBinaryType;
        [AccessedThroughProperty("numBlockCount")]
        private NumericUpDown _numBlockCount;
        [AccessedThroughProperty("numBlockSize")]
        private NumericUpDown _numBlockSize;
        [AccessedThroughProperty("numDeviceType")]
        private NumericUpDown _numDeviceType;
        [AccessedThroughProperty("numFileOffset")]
        private NumericUpDown _numFileOffset;
        [AccessedThroughProperty("numFileSize")]
        private NumericUpDown _numFileSize;
        [AccessedThroughProperty("numIdentifier")]
        private NumericUpDown _numIdentifier;
        [AccessedThroughProperty("numUpdateAttribute")]
        private NumericUpDown _numUpdateAttribute;
        [AccessedThroughProperty("ofdPIT")]
        private OpenFileDialog _ofdPIT;
        [AccessedThroughProperty("rtAnalysisOutput")]
        private RichTextBox _rtAnalysisOutput;
        [AccessedThroughProperty("sfdPIT")]
        private SaveFileDialog _sfdPIT;
        [AccessedThroughProperty("tabPITFileAnalysis")]
        private TabPage _tabPITFileAnalysis;
        [AccessedThroughProperty("tabPITFileEditor")]
        private TabPage _tabPITFileEditor;
        [AccessedThroughProperty("tcPITLayout")]
        private TabControl _tcPITLayout;
        [AccessedThroughProperty("txtDummy1")]
        private TextBox _txtDummy1;
        [AccessedThroughProperty("txtDummy2")]
        private TextBox _txtDummy2;
        [AccessedThroughProperty("txtDummy3")]
        private TextBox _txtDummy3;
        [AccessedThroughProperty("txtDummy4")]
        private TextBox _txtDummy4;
        [AccessedThroughProperty("txtDummy5")]
        private TextBox _txtDummy5;
        [AccessedThroughProperty("txtFlashFileName")]
        private TextBox _txtFlashFileName;
        [AccessedThroughProperty("txtFotaFileName")]
        private TextBox _txtFotaFileName;
        [AccessedThroughProperty("txtHdrMagic")]
        private TextBox _txtHdrMagic;
        [AccessedThroughProperty("txtHdrSize")]
        private TextBox _txtHdrSize;
        [AccessedThroughProperty("txtPartName")]
        private TextBox _txtPartName;
        [AccessedThroughProperty("txtPITEntryCnt")]
        private TextBox _txtPITEntryCnt;
        [AccessedThroughProperty("txtPITFile")]
        private TextBox _txtPITFile;
        private string AppPath;
        private IContainer components;
        private PitData myPitData;
        private PitEntry myPitEntry;
        private PitInputStream myPitInputStream;
        private PitOutputStream myPitOutputStream;
        private int newFileCounter;
        private PitData originalPitData;

        public PIT_Magic_Main()
        {
            base.Load += new EventHandler(this.PIT_Magic_Main_Load);
            this.AppPath = Application.StartupPath.ToString();
            this.newFileCounter = 1;
            this.InitializeComponent();
            this.lblVersionInfo.Text = "PIT Magic v" + this.GetAppVersion() + " Copyright \x00a9 Gaz 2012.";
            this.sfdPIT.FileName = $"NewPitFile{this.newFileCounter:00}.pit";
            this.txtPITFile.Text = this.sfdPIT.FileName;
            this.ofdPIT.FileName = this.sfdPIT.FileName;
            this.newFileCounter++;
            this.cbDataType.SelectedIndex = 0;
            this.txtHdrMagic.Text = $"0x{0x12349876.ToString("X")}";
            this.txtHdrSize.Text = Conversions.ToString(0x1c);
            this.txtPITEntryCnt.Text = "0";
            this.originalPitData = new PitData();
            this.myPitData = new PitData();
            this.myPitEntry = null;
            this.originalPitData = PitData.Clone(this.myPitData);
            this.btnSave.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnCopyClipboard.Enabled = false;
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            this.rtAnalysisOutput.SelectAll();
            this.rtAnalysisOutput.Copy();
            Interaction.MsgBox("PIT Analysis was copied to clipboard successfully.", MsgBoxStyle.Information, null);
        }

        private void btnCreatePITEntry_Click(object sender, EventArgs e)
        {
            if (this.myPitData == null)
            {
                this.myPitData = new PitData();
                this.myPitEntry = new PitEntry();
                this.myPitEntry.PartitionName = "PIT_ENTRY";
                this.myPitData.AddEntry(this.myPitEntry);
            }
            else
            {
                this.myPitEntry = new PitEntry();
                this.myPitEntry.PartitionName = "PIT_ENTRY";
                this.myPitData.AddEntry(this.myPitEntry);
            }
            this.cbPITEntries.Items.Clear();
            int num = 0;
            foreach (PitEntry entry in this.myPitData.Entries)
            {
                this.cbPITEntries.Items.Add($"Entry #{num:00}: {string.IsNullOrEmpty(entry.EntryMemAddr) ? "New PIT Entry" : entry.EntryMemAddr:D}
");
                num++;
            }
            this.cbPITEntries.SelectedIndex = this.cbPITEntries.Items.Count - 1;
            this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Thank you for using PIT Magic. Would you like to make a donation?", MsgBoxStyle.Question | MsgBoxStyle.YesNo, "Show Your Support! :-)") == MsgBoxResult.Yes)
            {
                Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7910259");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 1;
                string format = this.AppPath + @"\PIT_Analysis_{0:000}.txt";
                string path = string.Empty;
                path = string.Format(format, num);
                while (File.Exists(path))
                {
                    num++;
                    path = string.Format(format, num);
                }
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (string str3 in this.rtAnalysisOutput.Lines)
                    {
                        writer.WriteLine(str3);
                    }
                    writer.WriteLine();
                    writer.Write("Generated on: " + Conversions.ToString(DateTime.Now));
                }
                Interaction.MsgBox(path + "\r\n\r\nFile saved successfully.", MsgBoxStyle.Information, null);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("An error occurred while saving the 'PIT Analysis' file to disk.", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.CheckPITChanged() == CheckPITStatus.PIT_Changed)
            {
                switch (Interaction.MsgBox(Path.GetFileName(this.ofdPIT.FileName) + " has been modified. Do you want to save changes?", MsgBoxStyle.Question | MsgBoxStyle.YesNoCancel, null))
                {
                    case MsgBoxResult.Yes:
                        this.SavePITChanges();
                        break;

                    case MsgBoxResult.Cancel:
                        return;
                }
            }
            else if (this.CheckPITChanged() == CheckPITStatus.PIT_NewFile)
            {
                switch (Interaction.MsgBox(this.txtPITFile.Text + " has been modified. Do you want to save new file?", MsgBoxStyle.Question | MsgBoxStyle.YesNo, null))
                {
                    case MsgBoxResult.Yes:
                        this.SaveNewPITFile(null);
                        break;

                    case MsgBoxResult.Cancel:
                        return;
                }
            }
            this.ClearAll();
            this.cbPITEntries.Items.Clear();
            this.originalPitData = new PitData();
            this.myPitData = new PitData();
            this.myPitEntry = null;
            this.sfdPIT.FileName = $"NewPitFile{this.newFileCounter:00}.pit";
            this.txtPITFile.Text = this.sfdPIT.FileName;
            this.ofdPIT.FileName = this.sfdPIT.FileName;
            this.cbDataType.SelectedIndex = 0;
            this.txtHdrMagic.Text = $"0x{0x12349876.ToString("X")}";
            this.txtHdrSize.Text = Conversions.ToString(0x1c);
            this.txtPITEntryCnt.Text = "0";
            this.newFileCounter++;
            this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string fileName = this.ofdPIT.FileName;
            if (this.CheckPITChanged() == CheckPITStatus.PIT_Changed)
            {
                switch (Interaction.MsgBox(Path.GetFileName(this.ofdPIT.FileName) + " has been modified. Do you want to save changes?", MsgBoxStyle.Question | MsgBoxStyle.YesNoCancel, null))
                {
                    case MsgBoxResult.Yes:
                        this.SavePITChanges();
                        break;

                    case MsgBoxResult.Cancel:
                        return;
                }
            }
            else if (this.CheckPITChanged() == CheckPITStatus.PIT_NewFile)
            {
                switch (Interaction.MsgBox(this.txtPITFile.Text + " has been modified. Do you want to save new file?", MsgBoxStyle.Question | MsgBoxStyle.YesNo, null))
                {
                    case MsgBoxResult.Yes:
                        this.SaveNewPITFile(null);
                        break;

                    case MsgBoxResult.Cancel:
                        return;
                }
            }
            string text = this.txtPITFile.Text;
            try
            {
                this.ofdPIT.FileName = string.Empty;
                this.ofdPIT.InitialDirectory = this.AppPath;
                if (this.ofdPIT.ShowDialog() == DialogResult.Cancel)
                {
                    this.ofdPIT.FileName = fileName;
                }
                else
                {
                    FileStream byteStream = new FileStream(this.ofdPIT.FileName, FileMode.Open, FileAccess.Read);
                    this.txtPITFile.Text = Path.GetFileName(this.ofdPIT.FileName);
                    this.myPitInputStream = new PitInputStream(byteStream);
                    this.myPitData = new PitData();
                    if (this.myPitData.ReadPITFile(this.myPitInputStream))
                    {
                        if (this.cbDataType.SelectedIndex == 0)
                        {
                            this.txtDummy1.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData1);
                            this.txtDummy2.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData2);
                            this.txtDummy3.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData3);
                            this.txtDummy4.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData4);
                            this.txtDummy5.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData5);
                        }
                        else if (this.cbDataType.SelectedIndex == 1)
                        {
                            this.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData1);
                            this.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData2);
                            this.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData3);
                            this.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData4);
                            this.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData5);
                        }
                        this.originalPitData = new PitData();
                        this.originalPitData = PitData.Clone(this.myPitData);
                        this.cbPITEntries.Items.Clear();
                        this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
                        int num = 0;
                        foreach (PitEntry entry in this.myPitData.Entries)
                        {
                            this.cbPITEntries.Items.Add($"Entry #{num:00}: {entry.EntryMemAddr:D}
");
                            num++;
                        }
                        if (this.cbPITEntries.Items.Count > 0)
                        {
                            this.cbPITEntries.SelectedIndex = 0;
                        }
                    }
                    byteStream.Close();
                    this.btnSave.Enabled = true;
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.txtPITFile.Text = text;
                Interaction.MsgBox("An error occurred while opening the requested file.", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void btnOpenPITFile_Click(object sender, EventArgs e)
        {
            string fileName = this.ofdPIT.FileName;
            try
            {
                this.ofdPIT.FileName = string.Empty;
                this.ofdPIT.InitialDirectory = this.AppPath;
                if (this.ofdPIT.ShowDialog() != DialogResult.Cancel)
                {
                    FileStream byteStream = new FileStream(this.ofdPIT.FileName, FileMode.Open, FileAccess.Read);
                    PitInputStream inputStream = new PitInputStream(byteStream);
                    PitData data = new PitData();
                    if (data.ReadPITFile(inputStream))
                    {
                        this.rtAnalysisOutput.Clear();
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("PIT Magic v" + this.GetAppVersion() + " Copyright \x00a9 Gaz 2012." + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Analysis for: " + Path.GetFileName(this.ofdPIT.FileName) + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("<<< Pit File Start >>>" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("<<< PIT File Header Information >>>" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText($"Header Magic: 0x{0x12349876:X}     (4 Bytes)
");
                        this.rtAnalysisOutput.AppendText($"Entry Count:  {data.EntryCount:D}             (4 Bytes)

");
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data #1 (In String and Hexadecimal Format):" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("String:       " + DummyDataType.GetStrFromDummyData(data.DummyData1));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Hexadecimal:  " + DummyDataType.GetHexStrFromDummyData(data.DummyData1));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data #2 (In String and Hexadecimal Format):" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("String:       " + DummyDataType.GetStrFromDummyData(data.DummyData2));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Hexadecimal:  " + DummyDataType.GetHexStrFromDummyData(data.DummyData2));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data #3 (In String and Hexadecimal Format):" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("String:       " + DummyDataType.GetStrFromDummyData(data.DummyData3));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Hexadecimal:  " + DummyDataType.GetHexStrFromDummyData(data.DummyData3));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data #4 (In String and Hexadecimal Format):" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("String:       " + DummyDataType.GetStrFromDummyData(data.DummyData4));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Hexadecimal:  " + DummyDataType.GetHexStrFromDummyData(data.DummyData4));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data #5 (In String and Hexadecimal Format):" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("String:       " + DummyDataType.GetStrFromDummyData(data.DummyData5));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Hexadecimal:  " + DummyDataType.GetHexStrFromDummyData(data.DummyData5));
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Dummy Data Length: (" + Conversions.ToString(4) + " Bytes Per Block, 20 Bytes In Total.)" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("Header Size: (" + Conversions.ToString(0x1c) + " Bytes)" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("<<< PIT File Entries >>>" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        foreach (PitEntry entry in data.Entries)
                        {
                            string str2;
                            string str3;
                            string str4;
                            string str5;
                            this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                            this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                            this.rtAnalysisOutput.AppendText($"Entry Memory Address: {entry.EntryMemAddr:D}
");
                            this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                            this.rtAnalysisOutput.AppendText(Environment.NewLine);
                            if ((entry.BinaryType & PitEntry.EntryBinaryType.AppProcessor) > PitEntry.EntryBinaryType.AppProcessor)
                            {
                                str3 = "(APP. PROCESSOR)";
                            }
                            else if ((entry.BinaryType & PitEntry.EntryBinaryType.ComProcessor) > PitEntry.EntryBinaryType.AppProcessor)
                            {
                                str3 = "(COM. PROCESSOR)";
                            }
                            else
                            {
                                str3 = "(UNKNOWN)";
                            }
                            this.rtAnalysisOutput.AppendText("Binary Type: " + string.Format("               {0} {1,20}\n", (int) entry.BinaryType, str3));
                            if ((entry.DeviceType & PitEntry.EntryDeviceType.OneNand) > PitEntry.EntryDeviceType.OneNand)
                            {
                                str4 = "(ONE NAND)";
                            }
                            else if ((entry.DeviceType & PitEntry.EntryDeviceType.FileOrFat) > PitEntry.EntryDeviceType.OneNand)
                            {
                                str4 = "(FILE / FAT)";
                            }
                            else if ((entry.DeviceType & PitEntry.EntryDeviceType.MMC) > PitEntry.EntryDeviceType.OneNand)
                            {
                                str4 = "(MMC)";
                            }
                            else if ((entry.DeviceType & PitEntry.EntryDeviceType.All) > PitEntry.EntryDeviceType.OneNand)
                            {
                                str4 = "(ALL)";
                            }
                            else
                            {
                                str4 = "(UNKNOWN)";
                            }
                            this.rtAnalysisOutput.AppendText("Device Type: " + string.Format("               {0} {1,20}\n", (int) entry.DeviceType, str4));
                            this.rtAnalysisOutput.AppendText("Identifier: " + $"                {entry.Identifier:D}
");
                            if ((entry.Attribute & PitEntry.EntryAttribute.STL) > ((PitEntry.EntryAttribute) 0))
                            {
                                str2 = "(STL)";
                            }
                            else if ((entry.Attribute & PitEntry.EntryAttribute.Write) > ((PitEntry.EntryAttribute) 0))
                            {
                                str2 = "(READ / WRITE)";
                            }
                            else
                            {
                                str2 = "(READ ONLY)";
                            }
                            this.rtAnalysisOutput.AppendText("Attribute: " + string.Format("                 {0} {1,20}\n", (int) entry.Attribute, str2));
                            if ((entry.UpdateAttribute & PitEntry.EntryUpdateAttribute.Fota) > ((PitEntry.EntryUpdateAttribute) 0))
                            {
                                str5 = "(FOTA)";
                            }
                            else if ((entry.UpdateAttribute & PitEntry.EntryUpdateAttribute.Secure) > ((PitEntry.EntryUpdateAttribute) 0))
                            {
                                str5 = "(FOTA, SECURE)";
                            }
                            else
                            {
                                str5 = "(UNKNOWN)";
                            }
                            this.rtAnalysisOutput.AppendText("Update Attribute: " + string.Format("          {0} {1,20}\n", (int) entry.UpdateAttribute, str5));
                            this.rtAnalysisOutput.AppendText("Block Size: " + $"                {entry.BlockSize:###,###,###}
");
                            this.rtAnalysisOutput.AppendText("Block Count: " + $"               {entry.BlockCount:###,###,###}
");
                            this.rtAnalysisOutput.AppendText("File Offset (Obsolete): " + $"    {entry.FileOffset}
");
                            this.rtAnalysisOutput.AppendText("File Size (Obsolete): " + $"      {entry.FileSize}
");
                            this.rtAnalysisOutput.AppendText("Partition Name: " + $"            {entry.PartitionName}
");
                            this.rtAnalysisOutput.AppendText("Flash FileName: " + $"            {entry.FlashFileName}
");
                            this.rtAnalysisOutput.AppendText("FOTA FileName: " + $"             {entry.FotaFileName}
");
                        }
                        this.rtAnalysisOutput.AppendText(Environment.NewLine + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("<<< Pit File End >>>" + Environment.NewLine);
                        this.rtAnalysisOutput.AppendText("----------------------------------------------------------");
                    }
                    this.btnExport.Enabled = true;
                    this.btnCopyClipboard.Enabled = true;
                    this.ofdPIT.FileName = fileName;
                    byteStream.Close();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("An error occurred while opening the requested file.", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void btnRemPITEntry_Click(object sender, EventArgs e)
        {
            if (this.cbPITEntries.Items.Count > 0)
            {
                if (Interaction.MsgBox("Remove Selected PIT Entry?\r\n\r\n" + this.cbPITEntries.SelectedItem.ToString(), MsgBoxStyle.Question | MsgBoxStyle.OkCancel, null) == MsgBoxResult.Ok)
                {
                    string text = this.txtPITFile.Text;
                    this.myPitData.RemoveEntry(this.myPitEntry.Index);
                    if (this.cbPITEntries.SelectedIndex >= 0)
                    {
                        this.cbPITEntries.Items.RemoveAt(this.cbPITEntries.SelectedIndex);
                    }
                    this.cbPITEntries.Items.Clear();
                    int num2 = this.myPitEntry.Index - 1;
                    int num = 0;
                    foreach (PitEntry entry in this.myPitData.Entries)
                    {
                        this.cbPITEntries.Items.Add($"Entry #{num:00}: {string.IsNullOrEmpty(entry.EntryMemAddr) ? "New PIT Entry" : entry.EntryMemAddr:D}
");
                        num++;
                    }
                    if (this.myPitData.EntryCount > 0)
                    {
                        this.cbPITEntries.SelectedIndex = (num2 < 0) ? 0 : num2;
                        this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
                    }
                    else
                    {
                        int selectedIndex = this.cbDataType.SelectedIndex;
                        this.ClearAll();
                        this.txtPITFile.Text = text;
                        this.txtHdrMagic.Text = $"0x{0x12349876.ToString("X")}";
                        this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
                        this.txtHdrSize.Text = Conversions.ToString(0x1c);
                        this.cbDataType.SelectedIndex = selectedIndex;
                        if (this.cbDataType.SelectedIndex == 0)
                        {
                            this.txtDummy1.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData1);
                            this.txtDummy2.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData2);
                            this.txtDummy3.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData3);
                            this.txtDummy4.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData4);
                            this.txtDummy5.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData5);
                        }
                        else if (this.cbDataType.SelectedIndex == 1)
                        {
                            this.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData1);
                            this.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData2);
                            this.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData3);
                            this.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData4);
                            this.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData5);
                        }
                    }
                }
            }
            else
            {
                Interaction.MsgBox("Nothing to remove! PIT Entry list is empty!", MsgBoxStyle.Information, null);
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            string text = this.txtPITFile.Text;
            if (this.originalPitData != null)
            {
                int selectedIndex = this.cbDataType.SelectedIndex;
                this.ClearAll();
                this.txtPITFile.Text = text;
                int num2 = 0x12349876;
                this.txtHdrMagic.Text = $"0x{num2.ToString("X")}";
                this.txtPITEntryCnt.Text = Conversions.ToString(this.myPitData.EntryCount);
                this.txtHdrSize.Text = Conversions.ToString(0x1c);
                this.cbDataType.SelectedIndex = selectedIndex;
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.txtDummy1.Text = DummyDataType.GetStrFromDummyData(this.originalPitData.DummyData1);
                    this.txtDummy2.Text = DummyDataType.GetStrFromDummyData(this.originalPitData.DummyData2);
                    this.txtDummy3.Text = DummyDataType.GetStrFromDummyData(this.originalPitData.DummyData3);
                    this.txtDummy4.Text = DummyDataType.GetStrFromDummyData(this.originalPitData.DummyData4);
                    this.txtDummy5.Text = DummyDataType.GetStrFromDummyData(this.originalPitData.DummyData5);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(this.originalPitData.DummyData1);
                    this.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(this.originalPitData.DummyData2);
                    this.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(this.originalPitData.DummyData3);
                    this.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(this.originalPitData.DummyData4);
                    this.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(this.originalPitData.DummyData5);
                }
            }
            else
            {
                this.txtPITFile.Text = text;
                this.txtHdrMagic.Text = $"0x{0x12349876.ToString("X")}";
                this.txtPITEntryCnt.Text = "0";
                this.txtHdrSize.Text = Conversions.ToString(0x1c);
            }
            if (this.cbPITEntries.Items.Count > 0)
            {
                this.cbPITEntries.SelectedIndex = 0;
            }
            this.UpdatePITHeader();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SavePITChanges();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            this.SaveNewPITFile(null);
        }

        private void cbDumDisplayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.myPitData != null)
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    if (this.myPitData.DummyData1 != null)
                    {
                        this.txtDummy1.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData1);
                    }
                    if (this.myPitData.DummyData2 != null)
                    {
                        this.txtDummy2.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData2);
                    }
                    if (this.myPitData.DummyData3 != null)
                    {
                        this.txtDummy3.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData3);
                    }
                    if (this.myPitData.DummyData4 != null)
                    {
                        this.txtDummy4.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData4);
                    }
                    if (this.myPitData.DummyData5 != null)
                    {
                        this.txtDummy5.Text = DummyDataType.GetStrFromDummyData(this.myPitData.DummyData5);
                    }
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    if (this.myPitData.DummyData1 != null)
                    {
                        this.txtDummy1.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData1);
                    }
                    if (this.myPitData.DummyData2 != null)
                    {
                        this.txtDummy2.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData2);
                    }
                    if (this.myPitData.DummyData3 != null)
                    {
                        this.txtDummy3.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData3);
                    }
                    if (this.myPitData.DummyData4 != null)
                    {
                        this.txtDummy4.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData4);
                    }
                    if (this.myPitData.DummyData5 != null)
                    {
                        this.txtDummy5.Text = DummyDataType.GetHexStrFromDummyData(this.myPitData.DummyData5);
                    }
                }
            }
        }

        private void cbPITEntries_Click(object sender, EventArgs e)
        {
            if (this.cbPITEntries.Items.Count > 0)
            {
                this.UpdatePIT();
            }
        }

        private void cbPITEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbPITEntries.SelectedIndex != -1)
                {
                    this.myPitEntry = this.myPitData.GetEntry(this.cbPITEntries.SelectedIndex);
                    this.numBinaryType.Value = new decimal((int) this.myPitEntry.BinaryType);
                    if ((this.myPitEntry.BinaryType & PitEntry.EntryBinaryType.AppProcessor) > PitEntry.EntryBinaryType.AppProcessor)
                    {
                        this.lblBinTypeStatus.Text = "APP. PROCESSOR";
                    }
                    else if ((this.myPitEntry.BinaryType & PitEntry.EntryBinaryType.ComProcessor) > PitEntry.EntryBinaryType.AppProcessor)
                    {
                        this.lblBinTypeStatus.Text = "COM. PROCESSOR";
                    }
                    else
                    {
                        this.lblBinTypeStatus.Text = "UNKNOWN";
                    }
                    this.numDeviceType.Value = new decimal((int) this.myPitEntry.DeviceType);
                    if ((this.myPitEntry.DeviceType & PitEntry.EntryDeviceType.OneNand) > PitEntry.EntryDeviceType.OneNand)
                    {
                        this.lblDevTypeStatus.Text = "ONE NAND";
                    }
                    else if ((this.myPitEntry.DeviceType & PitEntry.EntryDeviceType.FileOrFat) > PitEntry.EntryDeviceType.OneNand)
                    {
                        this.lblDevTypeStatus.Text = "FILE / FAT";
                    }
                    else if ((this.myPitEntry.DeviceType & PitEntry.EntryDeviceType.MMC) > PitEntry.EntryDeviceType.OneNand)
                    {
                        this.lblDevTypeStatus.Text = "MMC";
                    }
                    else if ((this.myPitEntry.DeviceType & PitEntry.EntryDeviceType.All) > PitEntry.EntryDeviceType.OneNand)
                    {
                        this.lblDevTypeStatus.Text = "ALL";
                    }
                    else
                    {
                        this.lblDevTypeStatus.Text = "UNKNOWN";
                    }
                    this.numIdentifier.Value = new decimal(this.myPitEntry.Identifier);
                    this.numAttribute.Value = new decimal((int) this.myPitEntry.Attribute);
                    if ((this.myPitEntry.Attribute & PitEntry.EntryAttribute.STL) > ((PitEntry.EntryAttribute) 0))
                    {
                        this.lblAttribStatus.Text = "STL";
                    }
                    else if ((this.myPitEntry.Attribute & PitEntry.EntryAttribute.Write) > ((PitEntry.EntryAttribute) 0))
                    {
                        this.lblAttribStatus.Text = "READ / WRITE";
                    }
                    else
                    {
                        this.lblAttribStatus.Text = "READ ONLY";
                    }
                    this.numUpdateAttribute.Value = new decimal((int) this.myPitEntry.UpdateAttribute);
                    if ((this.myPitEntry.UpdateAttribute & PitEntry.EntryUpdateAttribute.Fota) > ((PitEntry.EntryUpdateAttribute) 0))
                    {
                        this.lblUpdAttrStatus.Text = "FOTA";
                    }
                    else if ((this.myPitEntry.UpdateAttribute & PitEntry.EntryUpdateAttribute.Secure) > ((PitEntry.EntryUpdateAttribute) 0))
                    {
                        this.lblUpdAttrStatus.Text = "FOTA, SECURE";
                    }
                    else
                    {
                        this.lblUpdAttrStatus.Text = "UNKNOWN";
                    }
                    this.numBlockSize.Value = new decimal(this.myPitEntry.BlockSize);
                    this.numBlockCount.Value = new decimal(this.myPitEntry.BlockCount);
                    this.numFileOffset.Value = new decimal(this.myPitEntry.FileOffset);
                    this.numFileSize.Value = new decimal(this.myPitEntry.FileSize);
                    this.txtPartName.Text = this.myPitEntry.PartitionName;
                    this.txtFlashFileName.Text = this.myPitEntry.FlashFileName;
                    this.txtFotaFileName.Text = this.myPitEntry.FotaFileName;
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("An indexing error occurred while selecting PIT Entry!", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private CheckPITStatus CheckPITChanged()
        {
            if ((this.myPitData != null) & (this.originalPitData != null))
            {
                if (this.myPitData.Matches(this.originalPitData))
                {
                    return CheckPITStatus.PIT_Unchanged;
                }
                return CheckPITStatus.PIT_Changed;
            }
            if ((this.myPitData != null) & (this.originalPitData == null))
            {
                return CheckPITStatus.PIT_NewFile;
            }
            return CheckPITStatus.PIT_Unchanged;
        }

        private void ClearAll()
        {
            try
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = this.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control current = (Control) enumerator.Current;
                        if (current.GetType().Name == "Panel")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "GroupBox")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "TabControl")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "TextBox")
                        {
                            (current as TextBox).Clear();
                        }
                        if (current.GetType().Name == "RadioButton")
                        {
                            RadioButton button = current as RadioButton;
                            button.Checked = false;
                        }
                        if (current.GetType().Name == "CheckBox")
                        {
                            CheckBox box2 = current as CheckBox;
                            box2.Checked = false;
                        }
                        if (current.GetType().Name == "ComboBox")
                        {
                            ComboBox box3 = current as ComboBox;
                            box3.SelectedIndex = -1;
                        }
                        if (current.GetType().Name == "NumericUpDown")
                        {
                            NumericUpDown down = current as NumericUpDown;
                            down.Value = decimal.Zero;
                        }
                        if (current.GetType().Name == "RichTextBox")
                        {
                            (current as RichTextBox).Clear();
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        private void ClearControls(Control Type)
        {
            try
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = Type.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control current = (Control) enumerator.Current;
                        if (current.GetType().Name == "TextBox")
                        {
                            (current as TextBox).Clear();
                        }
                        if (current.GetType().Name == "Panel")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "GroupBox")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "TabPage")
                        {
                            this.ClearControls(current);
                        }
                        if (current.GetType().Name == "ComboBox")
                        {
                            ComboBox box2 = current as ComboBox;
                            box2.SelectedIndex = -1;
                        }
                        if (current.GetType().Name == "NumericUpDown")
                        {
                            NumericUpDown down = current as NumericUpDown;
                            down.Value = decimal.Zero;
                        }
                        if (current.GetType().Name == "RadioButton")
                        {
                            RadioButton button = current as RadioButton;
                            button.Checked = false;
                        }
                        if (current.GetType().Name == "CheckBox")
                        {
                            CheckBox box3 = current as CheckBox;
                            box3.Checked = false;
                        }
                        if (current.GetType().Name == "RichTextBox")
                        {
                            (current as RichTextBox).Clear();
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private string GetAppVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return (Conversions.ToString(version.Major) + "." + Conversions.ToString(version.Minor) + "." + Conversions.ToString(version.Build));
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PIT_Magic_Main));
            this.tcPITLayout = new TabControl();
            this.tabPITFileEditor = new TabPage();
            this.btnResetForm = new Button();
            this.btnRemPITEntry = new Button();
            this.btnCreatePITEntry = new Button();
            this.gbPITOps = new GroupBox();
            this.btnNew = new Button();
            this.lblPITFile = new Label();
            this.txtPITFile = new TextBox();
            this.btnOpen = new Button();
            this.lblPITEntryList = new Label();
            this.btnSaveAs = new Button();
            this.cbPITEntries = new ComboBox();
            this.btnSave = new Button();
            this.gbPITFileHdrInfo = new GroupBox();
            this.Label8 = new Label();
            this.Label7 = new Label();
            this.Label6 = new Label();
            this.Label5 = new Label();
            this.Label4 = new Label();
            this.txtDummy5 = new TextBox();
            this.txtDummy4 = new TextBox();
            this.txtDummy3 = new TextBox();
            this.txtDummy2 = new TextBox();
            this.lblDummyDataTypeMsg = new Label();
            this.lblDummyDataType = new Label();
            this.cbDataType = new ComboBox();
            this.lblDummyData = new Label();
            this.txtDummy1 = new TextBox();
            this.gbHdrSize = new GroupBox();
            this.lblHdrSizeType = new Label();
            this.txtHdrSize = new TextBox();
            this.lblPITEntryCntType = new Label();
            this.lblHdrMagicType = new Label();
            this.lblPITEntryCnt = new Label();
            this.txtPITEntryCnt = new TextBox();
            this.lblHdrMagic = new Label();
            this.txtHdrMagic = new TextBox();
            this.gbCurrentPITEntry = new GroupBox();
            this.lblUpdAttrStatus = new Label();
            this.lblDevTypeStatus = new Label();
            this.numBinaryType = new NumericUpDown();
            this.lblBinTypeStatus = new Label();
            this.lblFotaFileName = new Label();
            this.txtFotaFileName = new TextBox();
            this.lblFlashFileName = new Label();
            this.lblPartName = new Label();
            this.txtFlashFileName = new TextBox();
            this.txtPartName = new TextBox();
            this.numBlockCount = new NumericUpDown();
            this.lblBlockSize = new Label();
            this.numBlockSize = new NumericUpDown();
            this.lblBlockCount = new Label();
            this.numAttribute = new NumericUpDown();
            this.lblAttribStatus = new Label();
            this.numUpdateAttribute = new NumericUpDown();
            this.numIdentifier = new NumericUpDown();
            this.numFileSize = new NumericUpDown();
            this.lblBinaryType = new Label();
            this.numFileOffset = new NumericUpDown();
            this.numDeviceType = new NumericUpDown();
            this.lblDeviceType = new Label();
            this.lblIdentifier = new Label();
            this.lblAttribute = new Label();
            this.lblUpdateAttribute = new Label();
            this.lblFileSize = new Label();
            this.lblFileOffset = new Label();
            this.tabPITFileAnalysis = new TabPage();
            this.btnOpenPITFile = new Button();
            this.btnExport = new Button();
            this.btnCopyClipboard = new Button();
            this.rtAnalysisOutput = new RichTextBox();
            this.lblVersionInfo = new Label();
            this.ofdPIT = new OpenFileDialog();
            this.sfdPIT = new SaveFileDialog();
            this.btnDonate = new Button();
            this.tcPITLayout.SuspendLayout();
            this.tabPITFileEditor.SuspendLayout();
            this.gbPITOps.SuspendLayout();
            this.gbPITFileHdrInfo.SuspendLayout();
            this.gbHdrSize.SuspendLayout();
            this.gbCurrentPITEntry.SuspendLayout();
            this.numBinaryType.BeginInit();
            this.numBlockCount.BeginInit();
            this.numBlockSize.BeginInit();
            this.numAttribute.BeginInit();
            this.numUpdateAttribute.BeginInit();
            this.numIdentifier.BeginInit();
            this.numFileSize.BeginInit();
            this.numFileOffset.BeginInit();
            this.numDeviceType.BeginInit();
            this.tabPITFileAnalysis.SuspendLayout();
            this.SuspendLayout();
            this.tcPITLayout.Controls.Add(this.tabPITFileEditor);
            this.tcPITLayout.Controls.Add(this.tabPITFileAnalysis);
            this.tcPITLayout.Dock = DockStyle.Top;
            Point point2 = new Point(0, 0);
            this.tcPITLayout.Location = point2;
            this.tcPITLayout.Name = "tcPITLayout";
            this.tcPITLayout.SelectedIndex = 0;
            Size size2 = new Size(0x200, 0x21b);
            this.tcPITLayout.Size = size2;
            this.tcPITLayout.TabIndex = 6;
            this.tabPITFileEditor.Controls.Add(this.btnResetForm);
            this.tabPITFileEditor.Controls.Add(this.btnRemPITEntry);
            this.tabPITFileEditor.Controls.Add(this.btnCreatePITEntry);
            this.tabPITFileEditor.Controls.Add(this.gbPITOps);
            this.tabPITFileEditor.Controls.Add(this.gbPITFileHdrInfo);
            this.tabPITFileEditor.Controls.Add(this.gbCurrentPITEntry);
            point2 = new Point(4, 0x16);
            this.tabPITFileEditor.Location = point2;
            this.tabPITFileEditor.Name = "tabPITFileEditor";
            Padding padding2 = new Padding(3);
            this.tabPITFileEditor.Padding = padding2;
            size2 = new Size(0x1f8, 0x201);
            this.tabPITFileEditor.Size = size2;
            this.tabPITFileEditor.TabIndex = 0;
            this.tabPITFileEditor.Text = "PIT File Editor";
            this.tabPITFileEditor.UseVisualStyleBackColor = true;
            this.btnResetForm.Image = (Image) manager.GetObject("btnResetForm.Image");
            this.btnResetForm.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x184, 0x1e3);
            this.btnResetForm.Location = point2;
            this.btnResetForm.Name = "btnResetForm";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnResetForm.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnResetForm.Size = size2;
            this.btnResetForm.TabIndex = 0x27;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnRemPITEntry.Image = (Image) manager.GetObject("btnRemPITEntry.Image");
            this.btnRemPITEntry.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0xae, 0x1e3);
            this.btnRemPITEntry.Location = point2;
            this.btnRemPITEntry.Name = "btnRemPITEntry";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnRemPITEntry.Padding = padding2;
            size2 = new Size(0x9c, 0x19);
            this.btnRemPITEntry.Size = size2;
            this.btnRemPITEntry.TabIndex = 0x26;
            this.btnRemPITEntry.Text = "Remove PIT Entry";
            this.btnRemPITEntry.UseVisualStyleBackColor = true;
            this.btnCreatePITEntry.Image = (Image) manager.GetObject("btnCreatePITEntry.Image");
            this.btnCreatePITEntry.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(6, 0x1e3);
            this.btnCreatePITEntry.Location = point2;
            this.btnCreatePITEntry.Name = "btnCreatePITEntry";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnCreatePITEntry.Padding = padding2;
            size2 = new Size(0x9c, 0x19);
            this.btnCreatePITEntry.Size = size2;
            this.btnCreatePITEntry.TabIndex = 0x25;
            this.btnCreatePITEntry.Text = "Create PIT Entry";
            this.btnCreatePITEntry.UseVisualStyleBackColor = true;
            this.gbPITOps.Controls.Add(this.btnNew);
            this.gbPITOps.Controls.Add(this.lblPITFile);
            this.gbPITOps.Controls.Add(this.txtPITFile);
            this.gbPITOps.Controls.Add(this.btnOpen);
            this.gbPITOps.Controls.Add(this.lblPITEntryList);
            this.gbPITOps.Controls.Add(this.btnSaveAs);
            this.gbPITOps.Controls.Add(this.cbPITEntries);
            this.gbPITOps.Controls.Add(this.btnSave);
            point2 = new Point(6, 6);
            this.gbPITOps.Location = point2;
            this.gbPITOps.Name = "gbPITOps";
            size2 = new Size(0x1ec, 0x67);
            this.gbPITOps.Size = size2;
            this.gbPITOps.TabIndex = 0x24;
            this.gbPITOps.TabStop = false;
            this.gbPITOps.Text = "PIT Operations:";
            this.btnNew.Image = (Image) manager.GetObject("btnNew.Image");
            this.btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(10, 0x12);
            this.btnNew.Location = point2;
            this.btnNew.Name = "btnNew";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnNew.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnNew.Size = size2;
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.lblPITFile.AutoSize = true;
            point2 = new Point(6, 0x34);
            this.lblPITFile.Location = point2;
            this.lblPITFile.Name = "lblPITFile";
            size2 = new Size(0x2e, 13);
            this.lblPITFile.Size = size2;
            this.lblPITFile.TabIndex = 7;
            this.lblPITFile.Text = "PIT File:";
            this.txtPITFile.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(9, 0x44);
            this.txtPITFile.Location = point2;
            this.txtPITFile.Name = "txtPITFile";
            this.txtPITFile.ReadOnly = true;
            size2 = new Size(0x124, 20);
            this.txtPITFile.Size = size2;
            this.txtPITFile.TabIndex = 6;
            this.btnOpen.Image = (Image) manager.GetObject("btnOpen.Image");
            this.btnOpen.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x83, 0x12);
            this.btnOpen.Location = point2;
            this.btnOpen.Name = "btnOpen";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnOpen.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnOpen.Size = size2;
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.lblPITEntryList.AutoSize = true;
            point2 = new Point(320, 0x34);
            this.lblPITEntryList.Location = point2;
            this.lblPITEntryList.Name = "lblPITEntryList";
            size2 = new Size(0x49, 13);
            this.lblPITEntryList.Size = size2;
            this.lblPITEntryList.TabIndex = 5;
            this.lblPITEntryList.Text = "PIT Entry List:";
            this.btnSaveAs.Image = (Image) manager.GetObject("btnSaveAs.Image");
            this.btnSaveAs.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x175, 0x12);
            this.btnSaveAs.Location = point2;
            this.btnSaveAs.Name = "btnSaveAs";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnSaveAs.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnSaveAs.Size = size2;
            this.btnSaveAs.TabIndex = 3;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.cbPITEntries.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPITEntries.FormattingEnabled = true;
            point2 = new Point(0x143, 0x44);
            this.cbPITEntries.Location = point2;
            this.cbPITEntries.Name = "cbPITEntries";
            size2 = new Size(160, 0x15);
            this.cbPITEntries.Size = size2;
            this.cbPITEntries.TabIndex = 4;
            this.btnSave.Image = (Image) manager.GetObject("btnSave.Image");
            this.btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0xfc, 0x12);
            this.btnSave.Location = point2;
            this.btnSave.Name = "btnSave";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnSave.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnSave.Size = size2;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.gbPITFileHdrInfo.Controls.Add(this.Label8);
            this.gbPITFileHdrInfo.Controls.Add(this.Label7);
            this.gbPITFileHdrInfo.Controls.Add(this.Label6);
            this.gbPITFileHdrInfo.Controls.Add(this.Label5);
            this.gbPITFileHdrInfo.Controls.Add(this.Label4);
            this.gbPITFileHdrInfo.Controls.Add(this.txtDummy5);
            this.gbPITFileHdrInfo.Controls.Add(this.txtDummy4);
            this.gbPITFileHdrInfo.Controls.Add(this.txtDummy3);
            this.gbPITFileHdrInfo.Controls.Add(this.txtDummy2);
            this.gbPITFileHdrInfo.Controls.Add(this.lblDummyDataTypeMsg);
            this.gbPITFileHdrInfo.Controls.Add(this.lblDummyDataType);
            this.gbPITFileHdrInfo.Controls.Add(this.cbDataType);
            this.gbPITFileHdrInfo.Controls.Add(this.lblDummyData);
            this.gbPITFileHdrInfo.Controls.Add(this.txtDummy1);
            this.gbPITFileHdrInfo.Controls.Add(this.gbHdrSize);
            this.gbPITFileHdrInfo.Controls.Add(this.lblPITEntryCntType);
            this.gbPITFileHdrInfo.Controls.Add(this.lblHdrMagicType);
            this.gbPITFileHdrInfo.Controls.Add(this.lblPITEntryCnt);
            this.gbPITFileHdrInfo.Controls.Add(this.txtPITEntryCnt);
            this.gbPITFileHdrInfo.Controls.Add(this.lblHdrMagic);
            this.gbPITFileHdrInfo.Controls.Add(this.txtHdrMagic);
            point2 = new Point(6, 0x73);
            this.gbPITFileHdrInfo.Location = point2;
            this.gbPITFileHdrInfo.Name = "gbPITFileHdrInfo";
            size2 = new Size(0x1ec, 150);
            this.gbPITFileHdrInfo.Size = size2;
            this.gbPITFileHdrInfo.TabIndex = 0x23;
            this.gbPITFileHdrInfo.TabStop = false;
            this.gbPITFileHdrInfo.Text = "PIT File Header Information:";
            this.Label8.AutoSize = true;
            point2 = new Point(410, 0x49);
            this.Label8.Location = point2;
            this.Label8.Name = "Label8";
            size2 = new Size(0x3d, 13);
            this.Label8.Size = size2;
            this.Label8.TabIndex = 80;
            this.Label8.Text = "Dummy #5:";
            this.Label7.AutoSize = true;
            point2 = new Point(0x14c, 0x49);
            this.Label7.Location = point2;
            this.Label7.Name = "Label7";
            size2 = new Size(0x3d, 13);
            this.Label7.Size = size2;
            this.Label7.TabIndex = 0x4f;
            this.Label7.Text = "Dummy #4:";
            this.Label6.AutoSize = true;
            point2 = new Point(0xfe, 0x49);
            this.Label6.Location = point2;
            this.Label6.Name = "Label6";
            size2 = new Size(0x3d, 13);
            this.Label6.Size = size2;
            this.Label6.TabIndex = 0x4e;
            this.Label6.Text = "Dummy #3:";
            this.Label5.AutoSize = true;
            point2 = new Point(0xb0, 0x49);
            this.Label5.Location = point2;
            this.Label5.Name = "Label5";
            size2 = new Size(0x3d, 13);
            this.Label5.Size = size2;
            this.Label5.TabIndex = 0x4d;
            this.Label5.Text = "Dummy #2:";
            this.Label4.AutoSize = true;
            point2 = new Point(0x62, 0x49);
            this.Label4.Location = point2;
            this.Label4.Name = "Label4";
            size2 = new Size(0x3d, 13);
            this.Label4.Size = size2;
            this.Label4.TabIndex = 0x4c;
            this.Label4.Text = "Dummy #1:";
            this.txtDummy5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x19d, 0x59);
            this.txtDummy5.Location = point2;
            this.txtDummy5.Name = "txtDummy5";
            size2 = new Size(70, 20);
            this.txtDummy5.Size = size2;
            this.txtDummy5.TabIndex = 0x4b;
            this.txtDummy4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x14f, 0x59);
            this.txtDummy4.Location = point2;
            this.txtDummy4.Name = "txtDummy4";
            size2 = new Size(70, 20);
            this.txtDummy4.Size = size2;
            this.txtDummy4.TabIndex = 0x4a;
            this.txtDummy3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x101, 0x59);
            this.txtDummy3.Location = point2;
            this.txtDummy3.Name = "txtDummy3";
            size2 = new Size(70, 20);
            this.txtDummy3.Size = size2;
            this.txtDummy3.TabIndex = 0x49;
            this.txtDummy2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0xb3, 0x59);
            this.txtDummy2.Location = point2;
            this.txtDummy2.Name = "txtDummy2";
            size2 = new Size(70, 20);
            this.txtDummy2.Size = size2;
            this.txtDummy2.TabIndex = 0x48;
            point2 = new Point(0xd1, 0x72);
            this.lblDummyDataTypeMsg.Location = point2;
            this.lblDummyDataTypeMsg.Name = "lblDummyDataTypeMsg";
            size2 = new Size(0xd8, 0x1b);
            this.lblDummyDataTypeMsg.Size = size2;
            this.lblDummyDataTypeMsg.TabIndex = 0x47;
            this.lblDummyDataTypeMsg.Text = "(Displays Dummy Data In Specified Format.) (4 Bytes Per Block, 20 Bytes In Total.)";
            this.lblDummyDataTypeMsg.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDummyDataType.AutoSize = true;
            point2 = new Point(6, 120);
            this.lblDummyDataType.Location = point2;
            this.lblDummyDataType.Name = "lblDummyDataType";
            size2 = new Size(60, 13);
            this.lblDummyDataType.Size = size2;
            this.lblDummyDataType.TabIndex = 70;
            this.lblDummyDataType.Text = "Data Type:";
            this.cbDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] { "String", "Hexadecimal" });
            point2 = new Point(0x65, 0x75);
            this.cbDataType.Location = point2;
            this.cbDataType.Name = "cbDataType";
            size2 = new Size(0x66, 0x15);
            this.cbDataType.Size = size2;
            this.cbDataType.TabIndex = 0x45;
            this.lblDummyData.AutoSize = true;
            point2 = new Point(6, 0x5c);
            this.lblDummyData.Location = point2;
            this.lblDummyData.Name = "lblDummyData";
            size2 = new Size(0x47, 13);
            this.lblDummyData.Size = size2;
            this.lblDummyData.TabIndex = 0x43;
            this.lblDummyData.Text = "Dummy Data:";
            this.txtDummy1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x65, 0x59);
            this.txtDummy1.Location = point2;
            this.txtDummy1.Name = "txtDummy1";
            size2 = new Size(70, 20);
            this.txtDummy1.Size = size2;
            this.txtDummy1.TabIndex = 0x42;
            this.gbHdrSize.Controls.Add(this.lblHdrSizeType);
            this.gbHdrSize.Controls.Add(this.txtHdrSize);
            point2 = new Point(0x15c, 0x12);
            this.gbHdrSize.Location = point2;
            this.gbHdrSize.Name = "gbHdrSize";
            size2 = new Size(0x87, 0x2e);
            this.gbHdrSize.Size = size2;
            this.gbHdrSize.TabIndex = 0x3d;
            this.gbHdrSize.TabStop = false;
            this.gbHdrSize.Text = "Header Size:";
            this.lblHdrSizeType.AutoSize = true;
            point2 = new Point(0x53, 0x13);
            this.lblHdrSizeType.Location = point2;
            this.lblHdrSizeType.Name = "lblHdrSizeType";
            size2 = new Size(0x27, 13);
            this.lblHdrSizeType.Size = size2;
            this.lblHdrSizeType.TabIndex = 0x41;
            this.lblHdrSizeType.Text = "(Bytes)";
            this.txtHdrSize.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(12, 0x10);
            this.txtHdrSize.Location = point2;
            this.txtHdrSize.Name = "txtHdrSize";
            this.txtHdrSize.ReadOnly = true;
            size2 = new Size(0x41, 20);
            this.txtHdrSize.Size = size2;
            this.txtHdrSize.TabIndex = 0x40;
            this.lblPITEntryCntType.AutoSize = true;
            point2 = new Point(0xb7, 0x2f);
            this.lblPITEntryCntType.Location = point2;
            this.lblPITEntryCntType.Name = "lblPITEntryCntType";
            size2 = new Size(0x99, 13);
            this.lblPITEntryCntType.Size = size2;
            this.lblPITEntryCntType.TabIndex = 0x3b;
            this.lblPITEntryCntType.Text = "(32-Bit Signed Integer, 4 Bytes)";
            this.lblHdrMagicType.AutoSize = true;
            point2 = new Point(0xb7, 0x15);
            this.lblHdrMagicType.Location = point2;
            this.lblHdrMagicType.Name = "lblHdrMagicType";
            size2 = new Size(0x99, 13);
            this.lblHdrMagicType.Size = size2;
            this.lblHdrMagicType.TabIndex = 0x3a;
            this.lblHdrMagicType.Text = "(32-Bit Signed Integer, 4 Bytes)";
            this.lblPITEntryCnt.AutoSize = true;
            point2 = new Point(6, 0x2f);
            this.lblPITEntryCnt.Location = point2;
            this.lblPITEntryCnt.Name = "lblPITEntryCnt";
            size2 = new Size(0x55, 13);
            this.lblPITEntryCnt.Size = size2;
            this.lblPITEntryCnt.TabIndex = 0x39;
            this.lblPITEntryCnt.Text = "PIT Entry Count:";
            this.txtPITEntryCnt.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x65, 0x2c);
            this.txtPITEntryCnt.Location = point2;
            this.txtPITEntryCnt.Name = "txtPITEntryCnt";
            this.txtPITEntryCnt.ReadOnly = true;
            size2 = new Size(0x4c, 20);
            this.txtPITEntryCnt.Size = size2;
            this.txtPITEntryCnt.TabIndex = 0x38;
            this.lblHdrMagic.AutoSize = true;
            point2 = new Point(6, 0x15);
            this.lblHdrMagic.Location = point2;
            this.lblHdrMagic.Name = "lblHdrMagic";
            size2 = new Size(0x4d, 13);
            this.lblHdrMagic.Size = size2;
            this.lblHdrMagic.TabIndex = 0x37;
            this.lblHdrMagic.Text = "Header Magic:";
            this.txtHdrMagic.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(0x65, 0x12);
            this.txtHdrMagic.Location = point2;
            this.txtHdrMagic.Name = "txtHdrMagic";
            this.txtHdrMagic.ReadOnly = true;
            size2 = new Size(0x4c, 20);
            this.txtHdrMagic.Size = size2;
            this.txtHdrMagic.TabIndex = 0x36;
            this.gbCurrentPITEntry.Controls.Add(this.lblUpdAttrStatus);
            this.gbCurrentPITEntry.Controls.Add(this.lblDevTypeStatus);
            this.gbCurrentPITEntry.Controls.Add(this.numBinaryType);
            this.gbCurrentPITEntry.Controls.Add(this.lblBinTypeStatus);
            this.gbCurrentPITEntry.Controls.Add(this.lblFotaFileName);
            this.gbCurrentPITEntry.Controls.Add(this.txtFotaFileName);
            this.gbCurrentPITEntry.Controls.Add(this.lblFlashFileName);
            this.gbCurrentPITEntry.Controls.Add(this.lblPartName);
            this.gbCurrentPITEntry.Controls.Add(this.txtFlashFileName);
            this.gbCurrentPITEntry.Controls.Add(this.txtPartName);
            this.gbCurrentPITEntry.Controls.Add(this.numBlockCount);
            this.gbCurrentPITEntry.Controls.Add(this.lblBlockSize);
            this.gbCurrentPITEntry.Controls.Add(this.numBlockSize);
            this.gbCurrentPITEntry.Controls.Add(this.lblBlockCount);
            this.gbCurrentPITEntry.Controls.Add(this.numAttribute);
            this.gbCurrentPITEntry.Controls.Add(this.lblAttribStatus);
            this.gbCurrentPITEntry.Controls.Add(this.numUpdateAttribute);
            this.gbCurrentPITEntry.Controls.Add(this.numIdentifier);
            this.gbCurrentPITEntry.Controls.Add(this.numFileSize);
            this.gbCurrentPITEntry.Controls.Add(this.lblBinaryType);
            this.gbCurrentPITEntry.Controls.Add(this.numFileOffset);
            this.gbCurrentPITEntry.Controls.Add(this.numDeviceType);
            this.gbCurrentPITEntry.Controls.Add(this.lblDeviceType);
            this.gbCurrentPITEntry.Controls.Add(this.lblIdentifier);
            this.gbCurrentPITEntry.Controls.Add(this.lblAttribute);
            this.gbCurrentPITEntry.Controls.Add(this.lblUpdateAttribute);
            this.gbCurrentPITEntry.Controls.Add(this.lblFileSize);
            this.gbCurrentPITEntry.Controls.Add(this.lblFileOffset);
            point2 = new Point(6, 0x10f);
            this.gbCurrentPITEntry.Location = point2;
            this.gbCurrentPITEntry.Name = "gbCurrentPITEntry";
            size2 = new Size(0x1ec, 0xce);
            this.gbCurrentPITEntry.Size = size2;
            this.gbCurrentPITEntry.TabIndex = 0x22;
            this.gbCurrentPITEntry.TabStop = false;
            this.gbCurrentPITEntry.Text = "Current PIT Entry:";
            point2 = new Point(0x95, 0x7e);
            this.lblUpdAttrStatus.Location = point2;
            this.lblUpdAttrStatus.Name = "lblUpdAttrStatus";
            size2 = new Size(0x76, 13);
            this.lblUpdAttrStatus.Size = size2;
            this.lblUpdAttrStatus.TabIndex = 0x34;
            this.lblUpdAttrStatus.Text = "FOTA";
            this.lblUpdAttrStatus.TextAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x95, 0x2f);
            this.lblDevTypeStatus.Location = point2;
            this.lblDevTypeStatus.Name = "lblDevTypeStatus";
            size2 = new Size(0x76, 13);
            this.lblDevTypeStatus.Size = size2;
            this.lblDevTypeStatus.TabIndex = 0x33;
            this.lblDevTypeStatus.Text = "ALL";
            this.lblDevTypeStatus.TextAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x65, 0x12);
            this.numBinaryType.Location = point2;
            decimal num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numBinaryType.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numBinaryType.Minimum = num;
            this.numBinaryType.Name = "numBinaryType";
            size2 = new Size(0x2a, 20);
            this.numBinaryType.Size = size2;
            this.numBinaryType.TabIndex = 50;
            point2 = new Point(0x95, 20);
            this.lblBinTypeStatus.Location = point2;
            this.lblBinTypeStatus.Name = "lblBinTypeStatus";
            size2 = new Size(0x76, 13);
            this.lblBinTypeStatus.Size = size2;
            this.lblBinTypeStatus.TabIndex = 0x31;
            this.lblBinTypeStatus.Text = "APP. PROCESSOR";
            this.lblBinTypeStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.lblFotaFileName.AutoSize = true;
            point2 = new Point(0x111, 0xb0);
            this.lblFotaFileName.Location = point2;
            this.lblFotaFileName.Name = "lblFotaFileName";
            size2 = new Size(0x58, 13);
            this.lblFotaFileName.Size = size2;
            this.lblFotaFileName.TabIndex = 0x30;
            this.lblFotaFileName.Text = "FOTA File Name:";
            this.txtFotaFileName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x17b, 0xad);
            this.txtFotaFileName.Location = point2;
            this.txtFotaFileName.Name = "txtFotaFileName";
            size2 = new Size(0x68, 20);
            this.txtFotaFileName.Size = size2;
            this.txtFotaFileName.TabIndex = 0x2f;
            this.lblFlashFileName.AutoSize = true;
            point2 = new Point(0x111, 150);
            this.lblFlashFileName.Location = point2;
            this.lblFlashFileName.Name = "lblFlashFileName";
            size2 = new Size(0x55, 13);
            this.lblFlashFileName.Size = size2;
            this.lblFlashFileName.TabIndex = 0x2e;
            this.lblFlashFileName.Text = "Flash File Name:";
            this.lblPartName.AutoSize = true;
            point2 = new Point(0x111, 0x7c);
            this.lblPartName.Location = point2;
            this.lblPartName.Name = "lblPartName";
            size2 = new Size(0x4f, 13);
            this.lblPartName.Size = size2;
            this.lblPartName.TabIndex = 0x2d;
            this.lblPartName.Text = "Partition Name:";
            this.txtFlashFileName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x17b, 0x93);
            this.txtFlashFileName.Location = point2;
            this.txtFlashFileName.Name = "txtFlashFileName";
            size2 = new Size(0x68, 20);
            this.txtFlashFileName.Size = size2;
            this.txtFlashFileName.TabIndex = 0x2c;
            this.txtPartName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(0x17b, 0x79);
            this.txtPartName.Location = point2;
            this.txtPartName.Name = "txtPartName";
            size2 = new Size(0x68, 20);
            this.txtPartName.Size = size2;
            this.txtPartName.TabIndex = 0x2b;
            point2 = new Point(0x65, 0xae);
            this.numBlockCount.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numBlockCount.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numBlockCount.Minimum = num;
            this.numBlockCount.Name = "numBlockCount";
            size2 = new Size(0x68, 20);
            this.numBlockCount.Size = size2;
            this.numBlockCount.TabIndex = 0x2a;
            this.numBlockCount.ThousandsSeparator = true;
            this.lblBlockSize.AutoSize = true;
            point2 = new Point(6, 150);
            this.lblBlockSize.Location = point2;
            this.lblBlockSize.Name = "lblBlockSize";
            size2 = new Size(0x53, 13);
            this.lblBlockSize.Size = size2;
            this.lblBlockSize.TabIndex = 0x27;
            this.lblBlockSize.Text = "Block Size (KB):";
            point2 = new Point(0x65, 0x94);
            this.numBlockSize.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numBlockSize.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numBlockSize.Minimum = num;
            this.numBlockSize.Name = "numBlockSize";
            size2 = new Size(0x68, 20);
            this.numBlockSize.Size = size2;
            this.numBlockSize.TabIndex = 0x29;
            this.numBlockSize.ThousandsSeparator = true;
            this.lblBlockCount.AutoSize = true;
            point2 = new Point(6, 0xb0);
            this.lblBlockCount.Location = point2;
            this.lblBlockCount.Name = "lblBlockCount";
            size2 = new Size(0x5b, 13);
            this.lblBlockCount.Size = size2;
            this.lblBlockCount.TabIndex = 40;
            this.lblBlockCount.Text = "Block Count (KB):";
            point2 = new Point(0x65, 0x60);
            this.numAttribute.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numAttribute.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numAttribute.Minimum = num;
            this.numAttribute.Name = "numAttribute";
            size2 = new Size(0x2a, 20);
            this.numAttribute.Size = size2;
            this.numAttribute.TabIndex = 0x24;
            point2 = new Point(0x95, 100);
            this.lblAttribStatus.Location = point2;
            this.lblAttribStatus.Name = "lblAttribStatus";
            size2 = new Size(0x76, 13);
            this.lblAttribStatus.Size = size2;
            this.lblAttribStatus.TabIndex = 0x23;
            this.lblAttribStatus.Text = "READ / WRITE";
            this.lblAttribStatus.TextAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x65, 0x7a);
            this.numUpdateAttribute.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numUpdateAttribute.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numUpdateAttribute.Minimum = num;
            this.numUpdateAttribute.Name = "numUpdateAttribute";
            size2 = new Size(0x2a, 20);
            this.numUpdateAttribute.Size = size2;
            this.numUpdateAttribute.TabIndex = 0x1f;
            point2 = new Point(0x65, 70);
            this.numIdentifier.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numIdentifier.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numIdentifier.Minimum = num;
            this.numIdentifier.Name = "numIdentifier";
            size2 = new Size(0x2a, 20);
            this.numIdentifier.Size = size2;
            this.numIdentifier.TabIndex = 0x21;
            point2 = new Point(0x17b, 0x2c);
            this.numFileSize.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numFileSize.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numFileSize.Minimum = num;
            this.numFileSize.Name = "numFileSize";
            size2 = new Size(0x68, 20);
            this.numFileSize.Size = size2;
            this.numFileSize.TabIndex = 30;
            this.lblBinaryType.AutoSize = true;
            point2 = new Point(6, 20);
            this.lblBinaryType.Location = point2;
            this.lblBinaryType.Name = "lblBinaryType";
            size2 = new Size(0x42, 13);
            this.lblBinaryType.Size = size2;
            this.lblBinaryType.TabIndex = 6;
            this.lblBinaryType.Text = "Binary Type:";
            point2 = new Point(0x17b, 0x12);
            this.numFileOffset.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numFileOffset.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numFileOffset.Minimum = num;
            this.numFileOffset.Name = "numFileOffset";
            size2 = new Size(0x68, 20);
            this.numFileOffset.Size = size2;
            this.numFileOffset.TabIndex = 0x1d;
            point2 = new Point(0x65, 0x2c);
            this.numDeviceType.Location = point2;
            num = new decimal(new int[] { 0x7fffffff, 0, 0, 0 });
            this.numDeviceType.Maximum = num;
            num = new decimal(new int[] { -2147483648, 0, 0, -2147483648 });
            this.numDeviceType.Minimum = num;
            this.numDeviceType.Name = "numDeviceType";
            size2 = new Size(0x2a, 20);
            this.numDeviceType.Size = size2;
            this.numDeviceType.TabIndex = 0x20;
            this.lblDeviceType.AutoSize = true;
            point2 = new Point(6, 0x2f);
            this.lblDeviceType.Location = point2;
            this.lblDeviceType.Name = "lblDeviceType";
            size2 = new Size(0x47, 13);
            this.lblDeviceType.Size = size2;
            this.lblDeviceType.TabIndex = 8;
            this.lblDeviceType.Text = "Device Type:";
            this.lblIdentifier.AutoSize = true;
            point2 = new Point(7, 0x48);
            this.lblIdentifier.Location = point2;
            this.lblIdentifier.Name = "lblIdentifier";
            size2 = new Size(50, 13);
            this.lblIdentifier.Size = size2;
            this.lblIdentifier.TabIndex = 10;
            this.lblIdentifier.Text = "Identifier:";
            this.lblAttribute.AutoSize = true;
            point2 = new Point(7, 0x62);
            this.lblAttribute.Location = point2;
            this.lblAttribute.Name = "lblAttribute";
            size2 = new Size(0x31, 13);
            this.lblAttribute.Size = size2;
            this.lblAttribute.TabIndex = 12;
            this.lblAttribute.Text = "Attribute:";
            this.lblUpdateAttribute.AutoSize = true;
            point2 = new Point(6, 0x7c);
            this.lblUpdateAttribute.Location = point2;
            this.lblUpdateAttribute.Name = "lblUpdateAttribute";
            size2 = new Size(0x57, 13);
            this.lblUpdateAttribute.Size = size2;
            this.lblUpdateAttribute.TabIndex = 0x12;
            this.lblUpdateAttribute.Text = "Update Attribute:";
            this.lblFileSize.AutoSize = true;
            point2 = new Point(0x111, 0x2f);
            this.lblFileSize.Location = point2;
            this.lblFileSize.Name = "lblFileSize";
            size2 = new Size(0x31, 13);
            this.lblFileSize.Size = size2;
            this.lblFileSize.TabIndex = 0x10;
            this.lblFileSize.Text = "File Size:";
            this.lblFileOffset.AutoSize = true;
            point2 = new Point(0x111, 20);
            this.lblFileOffset.Location = point2;
            this.lblFileOffset.Name = "lblFileOffset";
            size2 = new Size(100, 13);
            this.lblFileOffset.Size = size2;
            this.lblFileOffset.TabIndex = 14;
            this.lblFileOffset.Text = "File Offset (In TAR):";
            this.tabPITFileAnalysis.Controls.Add(this.btnOpenPITFile);
            this.tabPITFileAnalysis.Controls.Add(this.btnExport);
            this.tabPITFileAnalysis.Controls.Add(this.btnCopyClipboard);
            this.tabPITFileAnalysis.Controls.Add(this.rtAnalysisOutput);
            point2 = new Point(4, 0x16);
            this.tabPITFileAnalysis.Location = point2;
            this.tabPITFileAnalysis.Name = "tabPITFileAnalysis";
            padding2 = new Padding(3);
            this.tabPITFileAnalysis.Padding = padding2;
            size2 = new Size(0x1f8, 0x201);
            this.tabPITFileAnalysis.Size = size2;
            this.tabPITFileAnalysis.TabIndex = 1;
            this.tabPITFileAnalysis.Text = "PIT File Analysis";
            this.tabPITFileAnalysis.UseVisualStyleBackColor = true;
            this.btnOpenPITFile.Image = (Image) manager.GetObject("btnOpenPITFile.Image");
            this.btnOpenPITFile.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(6, 0x1e3);
            this.btnOpenPITFile.Location = point2;
            this.btnOpenPITFile.Name = "btnOpenPITFile";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnOpenPITFile.Padding = padding2;
            size2 = new Size(0x8f, 0x19);
            this.btnOpenPITFile.Size = size2;
            this.btnOpenPITFile.TabIndex = 6;
            this.btnOpenPITFile.Text = "Open PIT File...";
            this.btnOpenPITFile.UseVisualStyleBackColor = true;
            this.btnExport.Image = (Image) manager.GetObject("btnExport.Image");
            this.btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0xb5, 0x1e3);
            this.btnExport.Location = point2;
            this.btnExport.Name = "btnExport";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnExport.Padding = padding2;
            size2 = new Size(0x8f, 0x19);
            this.btnExport.Size = size2;
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export To File...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Image = (Image) manager.GetObject("btnCopyClipboard.Image");
            this.btnCopyClipboard.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x163, 0x1e3);
            this.btnCopyClipboard.Location = point2;
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnCopyClipboard.Padding = padding2;
            size2 = new Size(0x8f, 0x19);
            this.btnCopyClipboard.Size = size2;
            this.btnCopyClipboard.TabIndex = 4;
            this.btnCopyClipboard.Text = "Copy To Clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.rtAnalysisOutput.Font = new Font("Lucida Console", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point2 = new Point(6, 6);
            this.rtAnalysisOutput.Location = point2;
            this.rtAnalysisOutput.Name = "rtAnalysisOutput";
            this.rtAnalysisOutput.ReadOnly = true;
            size2 = new Size(0x1ec, 0x1d7);
            this.rtAnalysisOutput.Size = size2;
            this.rtAnalysisOutput.TabIndex = 0;
            this.rtAnalysisOutput.Text = "Open a PIT file to analyze it's contents.";
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            point2 = new Point(6, 0x222);
            this.lblVersionInfo.Location = point2;
            this.lblVersionInfo.Name = "lblVersionInfo";
            size2 = new Size(0x12a, 0x15);
            this.lblVersionInfo.Size = size2;
            this.lblVersionInfo.TabIndex = 9;
            this.lblVersionInfo.Text = "PIT Magic v#.#.# Copyright \x00a9 Gaz 2012.";
            this.ofdPIT.DefaultExt = "pit";
            this.ofdPIT.Filter = "Samsung PIT Files (*.pit)|*.pit";
            this.ofdPIT.Title = "Open PIT File...";
            this.sfdPIT.DefaultExt = "pit";
            this.sfdPIT.Filter = "Samsung PIT Files (*.pit)|*.pit";
            this.sfdPIT.Title = "Save PIT File As...";
            this.btnDonate.Image = (Image) manager.GetObject("btnDonate.Image");
            this.btnDonate.ImageAlign = ContentAlignment.MiddleLeft;
            point2 = new Point(0x188, 0x221);
            this.btnDonate.Location = point2;
            this.btnDonate.Name = "btnDonate";
            padding2 = new Padding(5, 0, 0, 0);
            this.btnDonate.Padding = padding2;
            size2 = new Size(110, 0x19);
            this.btnDonate.Size = size2;
            this.btnDonate.TabIndex = 0x27;
            this.btnDonate.Text = "Donate...";
            this.btnDonate.UseVisualStyleBackColor = true;
            SizeF ef2 = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef2;
            this.AutoScaleMode = AutoScaleMode.Font;
            size2 = new Size(0x200, 0x241);
            this.ClientSize = size2;
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.lblVersionInfo);
            this.Controls.Add(this.tcPITLayout);
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PIT_Magic_Main";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "PIT Magic";
            this.tcPITLayout.ResumeLayout(false);
            this.tabPITFileEditor.ResumeLayout(false);
            this.gbPITOps.ResumeLayout(false);
            this.gbPITOps.PerformLayout();
            this.gbPITFileHdrInfo.ResumeLayout(false);
            this.gbPITFileHdrInfo.PerformLayout();
            this.gbHdrSize.ResumeLayout(false);
            this.gbHdrSize.PerformLayout();
            this.gbCurrentPITEntry.ResumeLayout(false);
            this.gbCurrentPITEntry.PerformLayout();
            this.numBinaryType.EndInit();
            this.numBlockCount.EndInit();
            this.numBlockSize.EndInit();
            this.numAttribute.EndInit();
            this.numUpdateAttribute.EndInit();
            this.numIdentifier.EndInit();
            this.numFileSize.EndInit();
            this.numFileOffset.EndInit();
            this.numDeviceType.EndInit();
            this.tabPITFileAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void numAttribute_ValueChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt64(this.numAttribute.Value) & 2L) > 0L)
            {
                this.lblAttribStatus.Text = "STL";
            }
            else if ((Convert.ToInt64(this.numAttribute.Value) & 1L) > 0L)
            {
                this.lblAttribStatus.Text = "READ / WRITE";
            }
            else
            {
                this.lblAttribStatus.Text = "READ ONLY";
            }
        }

        private void numBinaryType_ValueChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt64(this.numBinaryType.Value) & 0L) > 0L)
            {
                this.lblBinTypeStatus.Text = "APP. PROCESSOR";
            }
            else if ((Convert.ToInt64(this.numBinaryType.Value) & 1L) > 0L)
            {
                this.lblBinTypeStatus.Text = "COM. PROCESSOR";
            }
            else
            {
                this.lblBinTypeStatus.Text = "UNKNOWN";
            }
        }

        private void numDeviceType_ValueChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt64(this.numDeviceType.Value) & 0L) > 0L)
            {
                this.lblDevTypeStatus.Text = "ONE NAND";
            }
            else if ((Convert.ToInt64(this.numDeviceType.Value) & 1L) > 0L)
            {
                this.lblDevTypeStatus.Text = "FILE / FAT";
            }
            else if ((Convert.ToInt64(this.numDeviceType.Value) & 2L) > 0L)
            {
                this.lblDevTypeStatus.Text = "MMC";
            }
            else if ((Convert.ToInt64(this.numDeviceType.Value) & 3L) > 0L)
            {
                this.lblDevTypeStatus.Text = "ALL";
            }
            else
            {
                this.lblDevTypeStatus.Text = "UNKNOWN";
            }
        }

        private void numUpdateAttribute_ValueChanged(object sender, EventArgs e)
        {
            if ((Convert.ToInt64(this.numUpdateAttribute.Value) & 1L) > 0L)
            {
                this.lblUpdAttrStatus.Text = "FOTA";
            }
            else if ((Convert.ToInt64(this.numUpdateAttribute.Value) & 2L) > 0L)
            {
                this.lblUpdAttrStatus.Text = "FOTA, SECURE";
            }
            else
            {
                this.lblUpdAttrStatus.Text = "UNKNOWN";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.CheckPITChanged() == CheckPITStatus.PIT_Changed)
            {
                switch (Interaction.MsgBox(Path.GetFileName(this.ofdPIT.FileName) + " has been modified. Do you want to save changes?", MsgBoxStyle.Question | MsgBoxStyle.YesNoCancel, null))
                {
                    case MsgBoxResult.Yes:
                        this.SavePITChanges();
                        break;

                    case MsgBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            else if (this.CheckPITChanged() == CheckPITStatus.PIT_NewFile)
            {
                switch (Interaction.MsgBox(this.txtPITFile.Text + " has been modified. Do you want to save new file?", MsgBoxStyle.Question | MsgBoxStyle.YesNoCancel, null))
                {
                    case MsgBoxResult.Yes:
                        this.SaveNewPITFile(e);
                        break;

                    case MsgBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            base.OnFormClosing(e);
        }

        private void PIT_Magic_Main_Load(object sender, EventArgs e)
        {
        }

        private void SaveNewPITFile(FormClosingEventArgs e = null)
        {
            try
            {
                if (this.cbPITEntries.Items.Count > 0)
                {
                    this.sfdPIT.FileName = this.txtPITFile.Text;
                    this.sfdPIT.InitialDirectory = this.AppPath;
                    if (this.sfdPIT.ShowDialog() == DialogResult.Cancel)
                    {
                        if (e != null)
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MemoryStream stream2 = new MemoryStream();
                        FileStream byteStream = new FileStream(this.sfdPIT.FileName, FileMode.Create);
                        PitOutputStream outputStream = new PitOutputStream(byteStream);
                        this.myPitData.WritePITFile(outputStream);
                        stream2.WriteTo(byteStream);
                        stream2.Close();
                        byteStream.Close();
                        this.ofdPIT.FileName = this.sfdPIT.FileName;
                        this.btnSave.Enabled = true;
                        this.originalPitData = null;
                        this.originalPitData = new PitData();
                        this.originalPitData = PitData.Clone(this.myPitData);
                        Interaction.MsgBox("Changes saved to '" + Path.GetFileName(this.sfdPIT.FileName) + "' successfully.", MsgBoxStyle.Information, null);
                    }
                }
                else
                {
                    Interaction.MsgBox("You MUST create at least ONE PIT Entry before saving to disk.", MsgBoxStyle.Exclamation, null);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("An error occurred while saving the file to disk.", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void SavePITChanges()
        {
            try
            {
                if (this.cbPITEntries.Items.Count > 0)
                {
                    MemoryStream stream2 = new MemoryStream();
                    FileStream byteStream = new FileStream(this.ofdPIT.FileName, FileMode.Create);
                    PitOutputStream outputStream = new PitOutputStream(byteStream);
                    this.myPitData.WritePITFile(outputStream);
                    stream2.WriteTo(byteStream);
                    stream2.Close();
                    byteStream.Close();
                    this.originalPitData = null;
                    this.originalPitData = new PitData();
                    this.originalPitData = PitData.Clone(this.myPitData);
                    Interaction.MsgBox("Changes saved to '" + Path.GetFileName(this.ofdPIT.FileName) + "' successfully.", MsgBoxStyle.Information, null);
                }
                else
                {
                    Interaction.MsgBox("You MUST create at least ONE PIT Entry before saving to disk.", MsgBoxStyle.Exclamation, null);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("An error occurred while saving the file to disk.", MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void txtDummy1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] array = new char[0];
            if (this.cbDataType.SelectedIndex == 0)
            {
                this.txtDummy1.MaxLength = 4;
            }
            else
            {
                if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy1.MaxLength = 8;
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    array = new char[] { 
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F',
                        '\b', '\x007f'
                    };
                }
                if (Array.IndexOf<char>(array, e.KeyChar) == -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDummy1_LostFocus(object sender, EventArgs e)
        {
            this.UpdatePITHeader();
        }

        private void txtDummy2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] array = new char[0];
            if (this.cbDataType.SelectedIndex == 0)
            {
                this.txtDummy2.MaxLength = 4;
            }
            else
            {
                if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy2.MaxLength = 8;
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    array = new char[] { 
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F',
                        '\b', '\x007f'
                    };
                }
                if (Array.IndexOf<char>(array, e.KeyChar) == -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDummy2_LostFocus(object sender, EventArgs e)
        {
            this.UpdatePITHeader();
        }

        private void txtDummy3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] array = new char[0];
            if (this.cbDataType.SelectedIndex == 0)
            {
                this.txtDummy3.MaxLength = 4;
            }
            else
            {
                if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy3.MaxLength = 8;
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    array = new char[] { 
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F',
                        '\b', '\x007f'
                    };
                }
                if (Array.IndexOf<char>(array, e.KeyChar) == -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDummy3_LostFocus(object sender, EventArgs e)
        {
            this.UpdatePITHeader();
        }

        private void txtDummy4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] array = new char[0];
            if (this.cbDataType.SelectedIndex == 0)
            {
                this.txtDummy4.MaxLength = 4;
            }
            else
            {
                if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy4.MaxLength = 8;
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    array = new char[] { 
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F',
                        '\b', '\x007f'
                    };
                }
                if (Array.IndexOf<char>(array, e.KeyChar) == -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDummy4_LostFocus(object sender, EventArgs e)
        {
            this.UpdatePITHeader();
        }

        private void txtDummy5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] array = new char[0];
            if (this.cbDataType.SelectedIndex == 0)
            {
                this.txtDummy5.MaxLength = 4;
            }
            else
            {
                if (this.cbDataType.SelectedIndex == 1)
                {
                    this.txtDummy5.MaxLength = 8;
                    e.KeyChar = Conversions.ToChar(e.KeyChar.ToString().ToUpper());
                    array = new char[] { 
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F',
                        '\b', '\x007f'
                    };
                }
                if (Array.IndexOf<char>(array, e.KeyChar) == -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDummy5_LostFocus(object sender, EventArgs e)
        {
            this.UpdatePITHeader();
        }

        private void UpdatePIT()
        {
            this.UpdatePITHeader();
            if (this.cbPITEntries.Items.Count > 0)
            {
                this.myPitEntry.BinaryType = (PitEntry.EntryBinaryType) Convert.ToInt32(this.numBinaryType.Value);
                this.myPitEntry.DeviceType = (PitEntry.EntryDeviceType) Convert.ToInt32(this.numDeviceType.Value);
                this.myPitEntry.Identifier = Convert.ToInt32(this.numIdentifier.Value);
                this.myPitEntry.Attribute = (PitEntry.EntryAttribute) Convert.ToInt32(this.numAttribute.Value);
                this.myPitEntry.UpdateAttribute = (PitEntry.EntryUpdateAttribute) Convert.ToInt32(this.numUpdateAttribute.Value);
                this.myPitEntry.BlockSize = Convert.ToInt32(this.numBlockSize.Value);
                this.myPitEntry.BlockCount = Convert.ToInt32(this.numBlockCount.Value);
                this.myPitEntry.FileOffset = Convert.ToInt32(this.numFileOffset.Value);
                this.myPitEntry.FileSize = Convert.ToInt32(this.numFileSize.Value);
                if (string.IsNullOrEmpty(this.txtPartName.Text))
                {
                    this.myPitEntry.PartitionName = string.Empty;
                }
                else
                {
                    this.myPitEntry.PartitionName = this.txtPartName.Text;
                }
                if (string.IsNullOrEmpty(this.txtFlashFileName.Text))
                {
                    this.myPitEntry.FlashFileName = string.Empty;
                }
                else
                {
                    this.myPitEntry.FlashFileName = this.txtFlashFileName.Text;
                }
                if (string.IsNullOrEmpty(this.txtFotaFileName.Text))
                {
                    this.myPitEntry.FotaFileName = string.Empty;
                }
                else
                {
                    this.myPitEntry.FotaFileName = this.txtFotaFileName.Text;
                }
            }
        }

        private void UpdatePITHeader()
        {
            if (this.myPitData == null)
            {
                this.myPitData = new PitData();
            }
            if (!string.IsNullOrEmpty(this.txtDummy1.Text))
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.myPitData.DummyData1 = DummyDataType.GetDummyDataFromStr(this.txtDummy1.Text);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.myPitData.DummyData1 = DummyDataType.GetDummyDataFromHexStr(this.txtDummy1.Text);
                }
            }
            else
            {
                this.myPitData.DummyData1 = new byte[] { 0, 0, 0, 0 };
            }
            if (!string.IsNullOrEmpty(this.txtDummy2.Text))
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.myPitData.DummyData2 = DummyDataType.GetDummyDataFromStr(this.txtDummy2.Text);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.myPitData.DummyData2 = DummyDataType.GetDummyDataFromHexStr(this.txtDummy2.Text);
                }
            }
            else
            {
                this.myPitData.DummyData2 = new byte[] { 0, 0, 0, 0 };
            }
            if (!string.IsNullOrEmpty(this.txtDummy3.Text))
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.myPitData.DummyData3 = DummyDataType.GetDummyDataFromStr(this.txtDummy3.Text);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.myPitData.DummyData3 = DummyDataType.GetDummyDataFromHexStr(this.txtDummy3.Text);
                }
            }
            else
            {
                this.myPitData.DummyData3 = new byte[] { 0, 0, 0, 0 };
            }
            if (!string.IsNullOrEmpty(this.txtDummy4.Text))
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.myPitData.DummyData4 = DummyDataType.GetDummyDataFromStr(this.txtDummy4.Text);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.myPitData.DummyData4 = DummyDataType.GetDummyDataFromHexStr(this.txtDummy4.Text);
                }
            }
            else
            {
                this.myPitData.DummyData4 = new byte[] { 0, 0, 0, 0 };
            }
            if (!string.IsNullOrEmpty(this.txtDummy5.Text))
            {
                if (this.cbDataType.SelectedIndex == 0)
                {
                    this.myPitData.DummyData5 = DummyDataType.GetDummyDataFromStr(this.txtDummy5.Text);
                }
                else if (this.cbDataType.SelectedIndex == 1)
                {
                    this.myPitData.DummyData5 = DummyDataType.GetDummyDataFromHexStr(this.txtDummy5.Text);
                }
            }
            else
            {
                this.myPitData.DummyData5 = new byte[] { 0, 0, 0, 0 };
            }
        }

        internal virtual Button btnCopyClipboard
        {
            get => 
                this._btnCopyClipboard;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnCopyClipboard_Click);
                if (this._btnCopyClipboard != null)
                {
                    this._btnCopyClipboard.Click -= handler;
                }
                this._btnCopyClipboard = value;
                if (this._btnCopyClipboard != null)
                {
                    this._btnCopyClipboard.Click += handler;
                }
            }
        }

        internal virtual Button btnCreatePITEntry
        {
            get => 
                this._btnCreatePITEntry;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnCreatePITEntry_Click);
                if (this._btnCreatePITEntry != null)
                {
                    this._btnCreatePITEntry.Click -= handler;
                }
                this._btnCreatePITEntry = value;
                if (this._btnCreatePITEntry != null)
                {
                    this._btnCreatePITEntry.Click += handler;
                }
            }
        }

        internal virtual Button btnDonate
        {
            get => 
                this._btnDonate;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnDonate_Click);
                if (this._btnDonate != null)
                {
                    this._btnDonate.Click -= handler;
                }
                this._btnDonate = value;
                if (this._btnDonate != null)
                {
                    this._btnDonate.Click += handler;
                }
            }
        }

        internal virtual Button btnExport
        {
            get => 
                this._btnExport;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnExport_Click);
                if (this._btnExport != null)
                {
                    this._btnExport.Click -= handler;
                }
                this._btnExport = value;
                if (this._btnExport != null)
                {
                    this._btnExport.Click += handler;
                }
            }
        }

        internal virtual Button btnNew
        {
            get => 
                this._btnNew;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnNew_Click);
                if (this._btnNew != null)
                {
                    this._btnNew.Click -= handler;
                }
                this._btnNew = value;
                if (this._btnNew != null)
                {
                    this._btnNew.Click += handler;
                }
            }
        }

        internal virtual Button btnOpen
        {
            get => 
                this._btnOpen;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnOpen_Click);
                if (this._btnOpen != null)
                {
                    this._btnOpen.Click -= handler;
                }
                this._btnOpen = value;
                if (this._btnOpen != null)
                {
                    this._btnOpen.Click += handler;
                }
            }
        }

        internal virtual Button btnOpenPITFile
        {
            get => 
                this._btnOpenPITFile;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnOpenPITFile_Click);
                if (this._btnOpenPITFile != null)
                {
                    this._btnOpenPITFile.Click -= handler;
                }
                this._btnOpenPITFile = value;
                if (this._btnOpenPITFile != null)
                {
                    this._btnOpenPITFile.Click += handler;
                }
            }
        }

        internal virtual Button btnRemPITEntry
        {
            get => 
                this._btnRemPITEntry;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnRemPITEntry_Click);
                if (this._btnRemPITEntry != null)
                {
                    this._btnRemPITEntry.Click -= handler;
                }
                this._btnRemPITEntry = value;
                if (this._btnRemPITEntry != null)
                {
                    this._btnRemPITEntry.Click += handler;
                }
            }
        }

        internal virtual Button btnResetForm
        {
            get => 
                this._btnResetForm;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnResetForm_Click);
                if (this._btnResetForm != null)
                {
                    this._btnResetForm.Click -= handler;
                }
                this._btnResetForm = value;
                if (this._btnResetForm != null)
                {
                    this._btnResetForm.Click += handler;
                }
            }
        }

        internal virtual Button btnSave
        {
            get => 
                this._btnSave;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnSave_Click);
                if (this._btnSave != null)
                {
                    this._btnSave.Click -= handler;
                }
                this._btnSave = value;
                if (this._btnSave != null)
                {
                    this._btnSave.Click += handler;
                }
            }
        }

        internal virtual Button btnSaveAs
        {
            get => 
                this._btnSaveAs;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.btnSaveAs_Click);
                if (this._btnSaveAs != null)
                {
                    this._btnSaveAs.Click -= handler;
                }
                this._btnSaveAs = value;
                if (this._btnSaveAs != null)
                {
                    this._btnSaveAs.Click += handler;
                }
            }
        }

        internal virtual ComboBox cbDataType
        {
            get => 
                this._cbDataType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.cbDumDisplayType_SelectedIndexChanged);
                if (this._cbDataType != null)
                {
                    this._cbDataType.SelectedIndexChanged -= handler;
                }
                this._cbDataType = value;
                if (this._cbDataType != null)
                {
                    this._cbDataType.SelectedIndexChanged += handler;
                }
            }
        }

        internal virtual ComboBox cbPITEntries
        {
            get => 
                this._cbPITEntries;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.cbPITEntries_Click);
                EventHandler handler2 = new EventHandler(this.cbPITEntries_SelectedIndexChanged);
                if (this._cbPITEntries != null)
                {
                    this._cbPITEntries.Click -= handler;
                    this._cbPITEntries.SelectedIndexChanged -= handler2;
                }
                this._cbPITEntries = value;
                if (this._cbPITEntries != null)
                {
                    this._cbPITEntries.Click += handler;
                    this._cbPITEntries.SelectedIndexChanged += handler2;
                }
            }
        }

        internal virtual GroupBox gbCurrentPITEntry
        {
            get => 
                this._gbCurrentPITEntry;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbCurrentPITEntry = value;
            }
        }

        internal virtual GroupBox gbHdrSize
        {
            get => 
                this._gbHdrSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbHdrSize = value;
            }
        }

        internal virtual GroupBox gbPITFileHdrInfo
        {
            get => 
                this._gbPITFileHdrInfo;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbPITFileHdrInfo = value;
            }
        }

        internal virtual GroupBox gbPITOps
        {
            get => 
                this._gbPITOps;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbPITOps = value;
            }
        }

        internal virtual Label Label4
        {
            get => 
                this._Label4;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }

        internal virtual Label Label5
        {
            get => 
                this._Label5;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }

        internal virtual Label Label6
        {
            get => 
                this._Label6;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
            }
        }

        internal virtual Label Label7
        {
            get => 
                this._Label7;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }
        }

        internal virtual Label Label8
        {
            get => 
                this._Label8;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
            }
        }

        internal virtual Label lblAttribStatus
        {
            get => 
                this._lblAttribStatus;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribStatus = value;
            }
        }

        internal virtual Label lblAttribute
        {
            get => 
                this._lblAttribute;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribute = value;
            }
        }

        internal virtual Label lblBinaryType
        {
            get => 
                this._lblBinaryType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblBinaryType = value;
            }
        }

        internal virtual Label lblBinTypeStatus
        {
            get => 
                this._lblBinTypeStatus;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblBinTypeStatus = value;
            }
        }

        internal virtual Label lblBlockCount
        {
            get => 
                this._lblBlockCount;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblBlockCount = value;
            }
        }

        internal virtual Label lblBlockSize
        {
            get => 
                this._lblBlockSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblBlockSize = value;
            }
        }

        internal virtual Label lblDeviceType
        {
            get => 
                this._lblDeviceType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDeviceType = value;
            }
        }

        internal virtual Label lblDevTypeStatus
        {
            get => 
                this._lblDevTypeStatus;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDevTypeStatus = value;
            }
        }

        internal virtual Label lblDummyData
        {
            get => 
                this._lblDummyData;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDummyData = value;
            }
        }

        internal virtual Label lblDummyDataType
        {
            get => 
                this._lblDummyDataType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDummyDataType = value;
            }
        }

        internal virtual Label lblDummyDataTypeMsg
        {
            get => 
                this._lblDummyDataTypeMsg;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDummyDataTypeMsg = value;
            }
        }

        internal virtual Label lblFileOffset
        {
            get => 
                this._lblFileOffset;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFileOffset = value;
            }
        }

        internal virtual Label lblFileSize
        {
            get => 
                this._lblFileSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFileSize = value;
            }
        }

        internal virtual Label lblFlashFileName
        {
            get => 
                this._lblFlashFileName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFlashFileName = value;
            }
        }

        internal virtual Label lblFotaFileName
        {
            get => 
                this._lblFotaFileName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFotaFileName = value;
            }
        }

        internal virtual Label lblHdrMagic
        {
            get => 
                this._lblHdrMagic;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblHdrMagic = value;
            }
        }

        internal virtual Label lblHdrMagicType
        {
            get => 
                this._lblHdrMagicType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblHdrMagicType = value;
            }
        }

        internal virtual Label lblHdrSizeType
        {
            get => 
                this._lblHdrSizeType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblHdrSizeType = value;
            }
        }

        internal virtual Label lblIdentifier
        {
            get => 
                this._lblIdentifier;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblIdentifier = value;
            }
        }

        internal virtual Label lblPartName
        {
            get => 
                this._lblPartName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPartName = value;
            }
        }

        internal virtual Label lblPITEntryCnt
        {
            get => 
                this._lblPITEntryCnt;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPITEntryCnt = value;
            }
        }

        internal virtual Label lblPITEntryCntType
        {
            get => 
                this._lblPITEntryCntType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPITEntryCntType = value;
            }
        }

        internal virtual Label lblPITEntryList
        {
            get => 
                this._lblPITEntryList;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPITEntryList = value;
            }
        }

        internal virtual Label lblPITFile
        {
            get => 
                this._lblPITFile;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPITFile = value;
            }
        }

        internal virtual Label lblUpdateAttribute
        {
            get => 
                this._lblUpdateAttribute;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblUpdateAttribute = value;
            }
        }

        internal virtual Label lblUpdAttrStatus
        {
            get => 
                this._lblUpdAttrStatus;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblUpdAttrStatus = value;
            }
        }

        internal virtual Label lblVersionInfo
        {
            get => 
                this._lblVersionInfo;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblVersionInfo = value;
            }
        }

        internal virtual NumericUpDown numAttribute
        {
            get => 
                this._numAttribute;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.numAttribute_ValueChanged);
                if (this._numAttribute != null)
                {
                    this._numAttribute.ValueChanged -= handler;
                }
                this._numAttribute = value;
                if (this._numAttribute != null)
                {
                    this._numAttribute.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown numBinaryType
        {
            get => 
                this._numBinaryType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.numBinaryType_ValueChanged);
                if (this._numBinaryType != null)
                {
                    this._numBinaryType.ValueChanged -= handler;
                }
                this._numBinaryType = value;
                if (this._numBinaryType != null)
                {
                    this._numBinaryType.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown numBlockCount
        {
            get => 
                this._numBlockCount;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._numBlockCount = value;
            }
        }

        internal virtual NumericUpDown numBlockSize
        {
            get => 
                this._numBlockSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._numBlockSize = value;
            }
        }

        internal virtual NumericUpDown numDeviceType
        {
            get => 
                this._numDeviceType;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.numDeviceType_ValueChanged);
                if (this._numDeviceType != null)
                {
                    this._numDeviceType.ValueChanged -= handler;
                }
                this._numDeviceType = value;
                if (this._numDeviceType != null)
                {
                    this._numDeviceType.ValueChanged += handler;
                }
            }
        }

        internal virtual NumericUpDown numFileOffset
        {
            get => 
                this._numFileOffset;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._numFileOffset = value;
            }
        }

        internal virtual NumericUpDown numFileSize
        {
            get => 
                this._numFileSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._numFileSize = value;
            }
        }

        internal virtual NumericUpDown numIdentifier
        {
            get => 
                this._numIdentifier;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._numIdentifier = value;
            }
        }

        internal virtual NumericUpDown numUpdateAttribute
        {
            get => 
                this._numUpdateAttribute;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.numUpdateAttribute_ValueChanged);
                if (this._numUpdateAttribute != null)
                {
                    this._numUpdateAttribute.ValueChanged -= handler;
                }
                this._numUpdateAttribute = value;
                if (this._numUpdateAttribute != null)
                {
                    this._numUpdateAttribute.ValueChanged += handler;
                }
            }
        }

        internal virtual OpenFileDialog ofdPIT
        {
            get => 
                this._ofdPIT;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ofdPIT = value;
            }
        }

        internal virtual RichTextBox rtAnalysisOutput
        {
            get => 
                this._rtAnalysisOutput;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtAnalysisOutput = value;
            }
        }

        internal virtual SaveFileDialog sfdPIT
        {
            get => 
                this._sfdPIT;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._sfdPIT = value;
            }
        }

        internal virtual TabPage tabPITFileAnalysis
        {
            get => 
                this._tabPITFileAnalysis;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tabPITFileAnalysis = value;
            }
        }

        internal virtual TabPage tabPITFileEditor
        {
            get => 
                this._tabPITFileEditor;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tabPITFileEditor = value;
            }
        }

        internal virtual TabControl tcPITLayout
        {
            get => 
                this._tcPITLayout;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tcPITLayout = value;
            }
        }

        internal virtual TextBox txtDummy1
        {
            get => 
                this._txtDummy1;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler handler = new KeyPressEventHandler(this.txtDummy1_KeyPress);
                EventHandler handler2 = new EventHandler(this.txtDummy1_LostFocus);
                if (this._txtDummy1 != null)
                {
                    this._txtDummy1.KeyPress -= handler;
                    this._txtDummy1.LostFocus -= handler2;
                }
                this._txtDummy1 = value;
                if (this._txtDummy1 != null)
                {
                    this._txtDummy1.KeyPress += handler;
                    this._txtDummy1.LostFocus += handler2;
                }
            }
        }

        internal virtual TextBox txtDummy2
        {
            get => 
                this._txtDummy2;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.txtDummy2_LostFocus);
                KeyPressEventHandler handler2 = new KeyPressEventHandler(this.txtDummy2_KeyPress);
                if (this._txtDummy2 != null)
                {
                    this._txtDummy2.LostFocus -= handler;
                    this._txtDummy2.KeyPress -= handler2;
                }
                this._txtDummy2 = value;
                if (this._txtDummy2 != null)
                {
                    this._txtDummy2.LostFocus += handler;
                    this._txtDummy2.KeyPress += handler2;
                }
            }
        }

        internal virtual TextBox txtDummy3
        {
            get => 
                this._txtDummy3;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.txtDummy3_LostFocus);
                KeyPressEventHandler handler2 = new KeyPressEventHandler(this.txtDummy3_KeyPress);
                if (this._txtDummy3 != null)
                {
                    this._txtDummy3.LostFocus -= handler;
                    this._txtDummy3.KeyPress -= handler2;
                }
                this._txtDummy3 = value;
                if (this._txtDummy3 != null)
                {
                    this._txtDummy3.LostFocus += handler;
                    this._txtDummy3.KeyPress += handler2;
                }
            }
        }

        internal virtual TextBox txtDummy4
        {
            get => 
                this._txtDummy4;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.txtDummy4_LostFocus);
                KeyPressEventHandler handler2 = new KeyPressEventHandler(this.txtDummy4_KeyPress);
                if (this._txtDummy4 != null)
                {
                    this._txtDummy4.LostFocus -= handler;
                    this._txtDummy4.KeyPress -= handler2;
                }
                this._txtDummy4 = value;
                if (this._txtDummy4 != null)
                {
                    this._txtDummy4.LostFocus += handler;
                    this._txtDummy4.KeyPress += handler2;
                }
            }
        }

        internal virtual TextBox txtDummy5
        {
            get => 
                this._txtDummy5;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler handler = new EventHandler(this.txtDummy5_LostFocus);
                KeyPressEventHandler handler2 = new KeyPressEventHandler(this.txtDummy5_KeyPress);
                if (this._txtDummy5 != null)
                {
                    this._txtDummy5.LostFocus -= handler;
                    this._txtDummy5.KeyPress -= handler2;
                }
                this._txtDummy5 = value;
                if (this._txtDummy5 != null)
                {
                    this._txtDummy5.LostFocus += handler;
                    this._txtDummy5.KeyPress += handler2;
                }
            }
        }

        internal virtual TextBox txtFlashFileName
        {
            get => 
                this._txtFlashFileName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtFlashFileName = value;
            }
        }

        internal virtual TextBox txtFotaFileName
        {
            get => 
                this._txtFotaFileName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtFotaFileName = value;
            }
        }

        internal virtual TextBox txtHdrMagic
        {
            get => 
                this._txtHdrMagic;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHdrMagic = value;
            }
        }

        internal virtual TextBox txtHdrSize
        {
            get => 
                this._txtHdrSize;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtHdrSize = value;
            }
        }

        internal virtual TextBox txtPartName
        {
            get => 
                this._txtPartName;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPartName = value;
            }
        }

        internal virtual TextBox txtPITEntryCnt
        {
            get => 
                this._txtPITEntryCnt;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPITEntryCnt = value;
            }
        }

        internal virtual TextBox txtPITFile
        {
            get => 
                this._txtPITFile;
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtPITFile = value;
            }
        }

        public enum CheckPITStatus
        {
            PIT_Unchanged,
            PIT_Changed,
            PIT_NewFile
        }
    }
}

