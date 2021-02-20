using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

// ATTENTION
//
// YOU WILL NEED TO ADD THIS TO YOUR REFERENCES FOR THIS PROJECT
// ... Right Click References --> Add Reference --> Search COM for 'Excel'
using excel = Microsoft.Office.Interop.Excel;

namespace Bare_Bones_Data_Collection_App
{
    public partial class Form1 : Form
    {
        SerialPort arduinoPort; // The COM Port instance

        Timer dataChecker; // To check for new data on COM port

        excel.Application excelApp; // Excel app used at runtime      
        excel.Workbook excelBook; // The current Excel workbook

        int rowIndex = 1; // To track where we are at logging to Excel

        DateTime fileTimestamp = DateTime.Now; // For setting the data file name

        // This function is created for you by default, it sets up the Form, don't mess with it
        // ... but you can add your own setup and initializations in here if you want, I prefer the 'Load' event for those
        public Form1()
        {
            InitializeComponent();
        }

        // Event is triggered right before the Form is displayed
        private void Form1_Load(object sender, EventArgs e)
        {
            // Call the event to refresh the COM port list
            button_portRefresh_Click(null, null);

            // Set up data checker using a Timer
            dataChecker = new Timer();
            dataChecker.Interval = 500; // A half second check should be sufficient, but you can adjust
            dataChecker.Tick += DataChecker_Tick; // Event handler hookup for each tick interval
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
            if(arduinoPort.BytesToRead > 0)
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
                MessageBox.Show("Choose a COM Port, restart app if needed");
                return;
            }

            // Checking for null keeps the second condition (!arduinoPort.IsOpen) from breaking
            if (arduinoPort == null || !arduinoPort.IsOpen) 
            {
                arduinoPort = new SerialPort(comboBox_comPort.Text, 9600);
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
            // Otherwise, save the workbook
            else Save_File();
        }

        // Event that is called when you click the 'Change Path' button
        private void button_changePath_Click(object sender, EventArgs e)
        {
            // Create a Dialog for the user to select a folder
            var folderDialog = new FolderBrowserDialog();
            var dialogResult = folderDialog.ShowDialog();

            // Make sure they've selected something, show the file path
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

            // Save the log file, if currently logging
            if (checkBox_logExcel.Checked) Save_File();
 
            excelApp.Quit(); // If you don't do this it might hang up next run   
            
            dataChecker.Dispose(); // Releases the Timer, just a good habit
        }

        // A custom function
        private void Save_File()
        {
            // Check that a book exists and that entries have been made
            if (excelBook != null && rowIndex > 1)
            {
                // Generate a new file name as a timestamp
                var fileName = fileTimestamp.ToString("HH-mm-ss") 
                    + " through " + DateTime.Now.ToString("HH-mm-ss");

                // Generate folder path, create directory if it doesn't already exist
                var folderPath = Path.Combine(textBox_folderPath.Text, "Arduino_Data");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Generate a full file path
                var filePath = Path.Combine(folderPath, fileName);
          
                excelBook.SaveAs(filePath);
                excelBook.Close();   
            }

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