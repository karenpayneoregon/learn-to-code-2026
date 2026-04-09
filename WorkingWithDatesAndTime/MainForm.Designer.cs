namespace WorkingWithDatesAndTime;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ResultsTextBox = new TextBox();
        GroupWorkDaysByWeekButton = new Button();
        DateTimeTryParseButton = new Button();
        HolidaysButton = new Button();
        DeconstructButton = new Button();
        TryParseExactButton = new Button();
        ConvertToEasternButton = new Button();
        OperatorsButton = new Button();
        groupBox1 = new GroupBox();
        EqualityRadioButton = new RadioButton();
        GreaterThanRadioButton = new RadioButton();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // ResultsTextBox
        // 
        ResultsTextBox.Dock = DockStyle.Bottom;
        ResultsTextBox.Font = new Font("Courier New", 12F);
        ResultsTextBox.Location = new Point(0, 379);
        ResultsTextBox.Multiline = true;
        ResultsTextBox.Name = "ResultsTextBox";
        ResultsTextBox.ScrollBars = ScrollBars.Both;
        ResultsTextBox.Size = new Size(1122, 295);
        ResultsTextBox.TabIndex = 0;
        // 
        // GroupWorkDaysByWeekButton
        // 
        GroupWorkDaysByWeekButton.Location = new Point(12, 164);
        GroupWorkDaysByWeekButton.Name = "GroupWorkDaysByWeekButton";
        GroupWorkDaysByWeekButton.Size = new Size(306, 29);
        GroupWorkDaysByWeekButton.TabIndex = 1;
        GroupWorkDaysByWeekButton.Text = "Group Work Days By Week";
        GroupWorkDaysByWeekButton.UseVisualStyleBackColor = true;
        GroupWorkDaysByWeekButton.Click += GroupWorkDaysByWeekButton_Click;
        // 
        // DateTimeTryParseButton
        // 
        DateTimeTryParseButton.Location = new Point(12, 21);
        DateTimeTryParseButton.Name = "DateTimeTryParseButton";
        DateTimeTryParseButton.Size = new Size(306, 29);
        DateTimeTryParseButton.TabIndex = 2;
        DateTimeTryParseButton.Text = "DateTime.TryParse";
        DateTimeTryParseButton.UseVisualStyleBackColor = true;
        DateTimeTryParseButton.Click += DateTimeTryParseButton_Click;
        // 
        // HolidaysButton
        // 
        HolidaysButton.Location = new Point(341, 164);
        HolidaysButton.Name = "HolidaysButton";
        HolidaysButton.Size = new Size(306, 29);
        HolidaysButton.TabIndex = 3;
        HolidaysButton.Text = "Holidays";
        HolidaysButton.UseVisualStyleBackColor = true;
        HolidaysButton.Click += HolidaysButton_Click;
        // 
        // DeconstructButton
        // 
        DeconstructButton.Location = new Point(12, 56);
        DeconstructButton.Name = "DeconstructButton";
        DeconstructButton.Size = new Size(306, 29);
        DeconstructButton.TabIndex = 4;
        DeconstructButton.Text = "Deconstruct";
        DeconstructButton.UseVisualStyleBackColor = true;
        DeconstructButton.Click += DeconstructButton_Click;
        // 
        // TryParseExactButton
        // 
        TryParseExactButton.Location = new Point(341, 21);
        TryParseExactButton.Name = "TryParseExactButton";
        TryParseExactButton.Size = new Size(306, 29);
        TryParseExactButton.TabIndex = 5;
        TryParseExactButton.Text = "DateTime.TryParseExact";
        TryParseExactButton.UseVisualStyleBackColor = true;
        TryParseExactButton.Click += TryParseExactButton_Click;
        // 
        // ConvertToEasternButton
        // 
        ConvertToEasternButton.Location = new Point(341, 56);
        ConvertToEasternButton.Name = "ConvertToEasternButton";
        ConvertToEasternButton.Size = new Size(306, 29);
        ConvertToEasternButton.TabIndex = 6;
        ConvertToEasternButton.Text = "Convert to eastern time";
        ConvertToEasternButton.UseVisualStyleBackColor = true;
        ConvertToEasternButton.Click += ConvertToEasternButton_Click;
        // 
        // OperatorsButton
        // 
        OperatorsButton.Location = new Point(663, 21);
        OperatorsButton.Name = "OperatorsButton";
        OperatorsButton.Size = new Size(306, 29);
        OperatorsButton.TabIndex = 7;
        OperatorsButton.Text = "Operators";
        OperatorsButton.UseVisualStyleBackColor = true;
        OperatorsButton.Click += OperatorsButton_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(GreaterThanRadioButton);
        groupBox1.Controls.Add(EqualityRadioButton);
        groupBox1.Location = new Point(663, 66);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(447, 225);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "groupBox1";
        // 
        // EqualityRadioButton
        // 
        EqualityRadioButton.AutoSize = true;
        EqualityRadioButton.Location = new Point(17, 37);
        EqualityRadioButton.Name = "EqualityRadioButton";
        EqualityRadioButton.Size = new Size(73, 24);
        EqualityRadioButton.TabIndex = 0;
        EqualityRadioButton.TabStop = true;
        EqualityRadioButton.Text = "Equals";
        EqualityRadioButton.UseVisualStyleBackColor = true;
        // 
        // GreaterThanRadioButton
        // 
        GreaterThanRadioButton.AutoSize = true;
        GreaterThanRadioButton.Location = new Point(17, 76);
        GreaterThanRadioButton.Name = "GreaterThanRadioButton";
        GreaterThanRadioButton.Size = new Size(112, 24);
        GreaterThanRadioButton.TabIndex = 1;
        GreaterThanRadioButton.TabStop = true;
        GreaterThanRadioButton.Text = "Greater than";
        GreaterThanRadioButton.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1122, 674);
        Controls.Add(groupBox1);
        Controls.Add(OperatorsButton);
        Controls.Add(ConvertToEasternButton);
        Controls.Add(TryParseExactButton);
        Controls.Add(DeconstructButton);
        Controls.Add(HolidaysButton);
        Controls.Add(DateTimeTryParseButton);
        Controls.Add(GroupWorkDaysByWeekButton);
        Controls.Add(ResultsTextBox);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Working with date/time";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox ResultsTextBox;
    private Button GroupWorkDaysByWeekButton;
    private Button DateTimeTryParseButton;
    private Button HolidaysButton;
    private Button DeconstructButton;
    private Button TryParseExactButton;
    private Button ConvertToEasternButton;
    private Button OperatorsButton;
    private GroupBox groupBox1;
    private RadioButton GreaterThanRadioButton;
    private RadioButton EqualityRadioButton;
}
