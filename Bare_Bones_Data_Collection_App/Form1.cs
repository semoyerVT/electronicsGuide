using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

// YOU WILL NEED TO ADD THIS TO YOUR REFERENCES FOR THIS PROJECT
// ... Right Click References --> Add Reference --> Search COM for 'Excel' --> Select the Excel Library and then 'Add'
using excel = Microsoft.Office.Interop.Excel;

namespace Bare_Bones_Data_Collection_App
{
    // The order of the functions inside this class is not important, though convention is to put the constructor at the top
    public partial class Form1 : Form
    {
        /*
         * Set the following to match your hardware baud rate (standard is 9600)
         *
         * Note: This code uses default Serial settings, and expects a newline character ('/n') delimiter between data samples
        */
        const int serialBaudRate = 9600;

        /*
         * The following are 'global variables', which can be accessed anywhere inside the class
        */

        SerialPort arduinoPort; // The COM Port instance

        Timer dataChecker; // To check for new data on COM port every ## milliseconds (see Form Load event)

        excel.Application excelApp; // Excel app used at runtime      
        excel.Workbook excelBook; // The current Excel workbook

        int rowIndex = 1; // To track where we are at logging to Excel

        DateTime fileTimestamp = DateTime.Now; // For setting the data file name

        // This constructor is created for you by default, 'InitializeComponent()' sets up the Form, don't change it
        public Form1()
        {
            InitializeComponent();
        }

        // Event is triggered right before the Form is displayed
        private void Form1_Load(object sender, EventArgs e)
        {
            // Call the event to refresh the COM port list
            button_portRefresh_Click(null, null);

            // Set up the data checker timer
            dataChecker = new Timer();
            dataChecker.Interval = 500; // A half second (500 ms) between checks should be sufficient
            dataChecker.Tick += DataChecker_Tick; // Event handler hookup for checking
            dataChecker.Start();

            // Set up excel application
            excelApp = new excel.Application();
        }

        // Event that is triggered continuously (every half second as defined above)
        private void DataChecker_Tick(object sender, EventArgs e)
        {
            // Check to make sure port has been created and is open
            if (arduinoPort == null || !arduinoPort.IsOpen)
            {
                Connection_Closed();
                return;
            }

            // Check for incoming data
            if (arduinoPort.BytesToRead > 0)
            {
                // Grab the data, looking for a 'newline' or 'linefeed' character as a 'delimiter'
                // .. really you're just matching what is being sent from the Arduino (i.e. Serial.println('data');)
                // .. where the 'ln' in 'println' is a newline character ('/n')
                var dataIn = arduinoPort.ReadLine();

                if (dataIn == string.Empty) return; // Verify there's something there
                if (double.TryParse(dataIn, out double dataVal)) // Verify it's an number
                {
                    label_dataIn.Text = dataVal.ToString(); // For the live feed

                    // Store to EXCEL!
                    if (checkBox_logExcel.Checked) Store_Data(dataVal);
                }
            }
        }

        // Event that is called when you click the 'OPEN' or 'CLOSE' button
        private void button_connection_Click(object sender, EventArgs e)
        {
            // Check for user selection
            if (comboBox_comPort.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the COM Port for your USB connected device");
                return;
            }

            // Checking for null first keeps the second condition (!arduinoPort.IsOpen) from breaking
            if (arduinoPort == null || !arduinoPort.IsOpen)
            {
                arduinoPort = new SerialPort(comboBox_comPort.Text, serialBaudRate);
            }

            // Toggle the Open-Close state
            if (arduinoPort.IsOpen)
            {
                arduinoPort.Close();
                Connection_Closed();
            }
            else
            {
                arduinoPort.Open();

                label_connectionStatus.Text = "OPEN";
                label_connectionStatus.ForeColor = System.Drawing.Color.Green;

                button_connection.Text = "CLOSE";
            }
        }

        // A custom function that's called in multiple places
        private void Connection_Closed()
        {
            label_connectionStatus.Text = "CLOSED";
            label_connectionStatus.ForeColor = System.Drawing.Color.Red;

            button_connection.Text = "OPEN";
            label_dataIn.Text = "--";
        }

        // Event that is called when the check state of the 'Log to Excel' checkbox changes
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If logging turned ON, recreate the workbook
            if (checkBox_logExcel.Checked)
            {
                fileTimestamp = DateTime.Now;
                if (excelBook == null) excelBook = excelApp.Workbooks.Add(Type.Missing);
            }            
            else Save_File(); // Otherwise, save the workbook
        }

        // Event that is called when you click the 'Change Path' button
        private void button_changePath_Click(object sender, EventArgs e)
        {
            // Create a Dialog for the user to select a folder
            var folderDialog = new FolderBrowserDialog();
            var dialogResult = folderDialog.ShowDialog();

            // Make sure they've selected something, then set the file path
            if (dialogResult == DialogResult.OK)
            {
                textBox_folderPath.Text = folderDialog.SelectedPath;
            }
        }

        // A custom function used to store data
        private void Store_Data(double dataVal)
        {
            var excelSheet = excelBook.ActiveSheet;

            // If the first entry, add the headers
            if (rowIndex == 1)
            {
                excelSheet.Cells[1, 1] = "Timestamp";
                excelSheet.Cells[1, 2] = "Data";
            }

            // Add the new data sample to the workbook
            excelSheet.Cells[++rowIndex, 1] = DateTime.Now.ToString("HH:mm:ss");
            excelSheet.Cells[rowIndex, 2] = dataVal;
        }

        // Event that is called when the Form is closing (or you exit the app)
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataChecker.Stop(); // Stop looking for data

            // Close and dispose of the Serial Port
            if (arduinoPort != null)
            {
                if (arduinoPort.IsOpen) arduinoPort.Close();
                arduinoPort.Dispose();
            }
      
            if (checkBox_logExcel.Checked) Save_File(); // Save the log file, if currently logging

            excelApp.Quit(); // If you don't do this it might hang up next run   

            dataChecker.Dispose(); // Dispose of the timer object, just a good habit
        }

        // A custom function
        private void Save_File()
        {
            // Check that a book exists and that entries have been made
            if (excelBook != null && rowIndex > 1)
            {
                // AutoFit the log sheet columns
                excelBook.ActiveSheet.Columns["A:B"].AutoFit();

                // Generate the file name using format '[Start Timestamp] ([## total] min)'
                var minutes = (DateTime.Now - fileTimestamp).TotalMinutes.ToString("0");
                var fileName = fileTimestamp.ToString("MM-dd-yyyy HH-mm-ss")
                    + " (" + minutes + " min)";

                // Generate folder path, create directory if it doesn't already exist
                var folderPath = Path.Combine(textBox_folderPath.Text, "Arduino_Data");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Generate a full file path
                var filePath = Path.Combine(folderPath, fileName);

                // Save and close the excel book
                excelBook.SaveAs(filePath);
                excelBook.Close();
            }

            // Reset variables used for log file management
            excelBook = null;
            rowIndex = 1;
        }

        // Event that is called when you click the 'Refresh Ports' button
        private void button_portRefresh_Click(object sender, EventArgs e)
        {
            // Get all available COM ports and put in combo box
            var availablePorts = SerialPort.GetPortNames();

            // Reset the combo box items
            comboBox_comPort.Items.Clear();
            comboBox_comPort.Items.AddRange(availablePorts);
        }
    }
}