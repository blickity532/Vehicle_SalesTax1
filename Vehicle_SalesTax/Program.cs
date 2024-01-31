using System;
using System.Windows.Forms;

namespace Riley_Vehicle_SalesTax
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
            Application.Run(new MainForm());
        }
    }

    public partial class MainForm : Form
    {
        // Constants for warranty costs
        const decimal OneYearWarrantyCost = 1000;
        const decimal TwoYearWarrantyCost = 2000;
        const decimal ThreeYearWarrantyCost = 3000;

        // Constants for sales tax rates
        const decimal WashingtonTaxRate = 0.086m; // 8.6%

        // Controls
        private Label basePriceLabel;
        private TextBox carPriceTextBox;
        private Label warrantyLabel;
        private ComboBox warrantyComboBox;
        private Label stateSoldLabel;
        private ComboBox locationComboBox;
        private Button calculateButton;
        private Button clearButton;
        private Button exitButton;
        private Label resultLabel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Cars Sales Tax Calculator";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(400, 250);

            // Base Price Label
            basePriceLabel = new Label();
            basePriceLabel.Text = "Base Price:";
            basePriceLabel.Location = new System.Drawing.Point(40, 30);
            basePriceLabel.Size = new System.Drawing.Size(70, 20);
            this.Controls.Add(basePriceLabel);

            // Car Price TextBox
            carPriceTextBox = new TextBox();
            carPriceTextBox.Location = new System.Drawing.Point(120, 30);
            carPriceTextBox.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(carPriceTextBox);

            // Warranty Label
            warrantyLabel = new Label();
            warrantyLabel.Text = "Warranty:";
            warrantyLabel.Location = new System.Drawing.Point(40, 70);
            warrantyLabel.Size = new System.Drawing.Size(70, 20);
            this.Controls.Add(warrantyLabel);

            // Warranty ComboBox
            warrantyComboBox = new ComboBox();
            warrantyComboBox.Items.AddRange(new object[] { "No Warranty", "One Year", "Two Year", "Three Year" });
            warrantyComboBox.Location = new System.Drawing.Point(120, 70);
            warrantyComboBox.Size = new System.Drawing.Size(150, 21);
            warrantyComboBox.SelectedIndex = 0;
            this.Controls.Add(warrantyComboBox);

            // State Sold Label
            stateSoldLabel = new Label();
            stateSoldLabel.Text = "State Sold:";
            stateSoldLabel.Location = new System.Drawing.Point(40, 110);
            stateSoldLabel.Size = new System.Drawing.Size(70, 20);
            this.Controls.Add(stateSoldLabel);

            // Location ComboBox
            locationComboBox = new ComboBox();
            locationComboBox.Items.AddRange(new object[] { "WA", "OR" });
            locationComboBox.Location = new System.Drawing.Point(120, 110);
            locationComboBox.Size = new System.Drawing.Size(150, 21);
            locationComboBox.SelectedIndex = 0;
            this.Controls.Add(locationComboBox);

            // Calculate Button
            calculateButton = new Button();
            calculateButton.Text = "Calculate";
            calculateButton.Location = new System.Drawing.Point(80, 150);
            calculateButton.Size = new System.Drawing.Size(80, 30);
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);

            // Clear Button
            clearButton = new Button();
            clearButton.Text = "Clear";
            clearButton.Location = new System.Drawing.Point(180, 150);
            clearButton.Size = new System.Drawing.Size(80, 30);
            clearButton.Click += ClearButton_Click;
            this.Controls.Add(clearButton);

            // Exit Button
            exitButton = new Button();
            exitButton.Text = "Exit";
            exitButton.Location = new System.Drawing.Point(280, 150);
            exitButton.Size = new System.Drawing.Size(80, 30);
            exitButton.Click += ExitButton_Click;
            this.Controls.Add(exitButton);

            // Result Label
            resultLabel = new Label();
            resultLabel.Location = new System.Drawing.Point(120, 190);
            resultLabel.Size = new System.Drawing.Size(280, 20);
            this.Controls.Add(resultLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // Implement the logic to calculate sales tax and display the result
            // Convert string inputs to appropriate numerical variables
            if (decimal.TryParse(carPriceTextBox.Text, out decimal baseCost))
            {
                decimal totalCost = baseCost;

                // Check warranty selection and add cost
                if (warrantyComboBox.Text == "One Year")
                    totalCost += OneYearWarrantyCost;
                else if (warrantyComboBox.Text == "Two Year")
                    totalCost += TwoYearWarrantyCost;
                else if (warrantyComboBox.Text == "Three Year")
                    totalCost += ThreeYearWarrantyCost;

                // Check location for sales tax calculation
                if (locationComboBox.Text == "WA")
                    totalCost += totalCost * WashingtonTaxRate;

                // Display the result in money format
                resultLabel.Text = $"Total Vehicle cost is {totalCost:C}";
            }
            else
            {
                MessageBox.Show("Invalid input for car price. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Implement the logic to reset the form to its default state
            carPriceTextBox.Text = "";
            warrantyComboBox.SelectedIndex = 0;
            locationComboBox.SelectedIndex = 0;
            resultLabel.Text = "";
            carPriceTextBox.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Implement the logic to terminate the application
            Application.Exit();
        }
    }
}
