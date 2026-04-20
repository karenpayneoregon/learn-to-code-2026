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
        ExamplesGroupBox = new GroupBox();
        FormatDatesRadioButton = new RadioButton();
        AddSubtractRadioButton = new RadioButton();
        LessThanOrEqualRadioButton = new RadioButton();
        GreaterThanRadioButton = new RadioButton();
        EqualityRadioButton = new RadioButton();
        GreetingLabel = new Label();
        RawStringLiteralButton = new RadioButton();
        ExamplesGroupBox.SuspendLayout();
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
        GroupWorkDaysByWeekButton.Location = new Point(12, 183);
        GroupWorkDaysByWeekButton.Name = "GroupWorkDaysByWeekButton";
        GroupWorkDaysByWeekButton.Size = new Size(306, 29);
        GroupWorkDaysByWeekButton.TabIndex = 1;
        GroupWorkDaysByWeekButton.Text = "Group Work Days By Week";
        GroupWorkDaysByWeekButton.UseVisualStyleBackColor = true;
        GroupWorkDaysByWeekButton.Click += GroupWorkDaysByWeekButton_Click;
        // 
        // DateTimeTryParseButton
        // 
        DateTimeTryParseButton.Location = new Point(12, 40);
        DateTimeTryParseButton.Name = "DateTimeTryParseButton";
        DateTimeTryParseButton.Size = new Size(306, 29);
        DateTimeTryParseButton.TabIndex = 2;
        DateTimeTryParseButton.Text = "DateTime.TryParse";
        DateTimeTryParseButton.UseVisualStyleBackColor = true;
        DateTimeTryParseButton.Click += DateTimeTryParseButton_Click;
        // 
        // HolidaysButton
        // 
        HolidaysButton.Location = new Point(341, 183);
        HolidaysButton.Name = "HolidaysButton";
        HolidaysButton.Size = new Size(306, 29);
        HolidaysButton.TabIndex = 3;
        HolidaysButton.Text = "Holidays";
        HolidaysButton.UseVisualStyleBackColor = true;
        HolidaysButton.Click += HolidaysButton_Click;
        // 
        // DeconstructButton
        // 
        DeconstructButton.Location = new Point(12, 75);
        DeconstructButton.Name = "DeconstructButton";
        DeconstructButton.Size = new Size(306, 29);
        DeconstructButton.TabIndex = 4;
        DeconstructButton.Text = "Deconstruct";
        DeconstructButton.UseVisualStyleBackColor = true;
        DeconstructButton.Click += DeconstructButton_Click;
        // 
        // TryParseExactButton
        // 
        TryParseExactButton.Location = new Point(341, 40);
        TryParseExactButton.Name = "TryParseExactButton";
        TryParseExactButton.Size = new Size(306, 29);
        TryParseExactButton.TabIndex = 5;
        TryParseExactButton.Text = "DateTime.TryParseExact";
        TryParseExactButton.UseVisualStyleBackColor = true;
        TryParseExactButton.Click += TryParseExactButton_Click;
        // 
        // ConvertToEasternButton
        // 
        ConvertToEasternButton.Location = new Point(341, 75);
        ConvertToEasternButton.Name = "ConvertToEasternButton";
        ConvertToEasternButton.Size = new Size(306, 29);
        ConvertToEasternButton.TabIndex = 6;
        ConvertToEasternButton.Text = "Convert to eastern time";
        ConvertToEasternButton.UseVisualStyleBackColor = true;
        ConvertToEasternButton.Click += ConvertToEasternButton_Click;
        // 
        // OperatorsButton
        // 
        OperatorsButton.Location = new Point(663, 40);
        OperatorsButton.Name = "OperatorsButton";
        OperatorsButton.Size = new Size(306, 29);
        OperatorsButton.TabIndex = 7;
        OperatorsButton.Text = "Operators/Methods";
        OperatorsButton.UseVisualStyleBackColor = true;
        OperatorsButton.Click += OperatorsButton_Click;
        // 
        // ExamplesGroupBox
        // 
        ExamplesGroupBox.Controls.Add(RawStringLiteralButton);
        ExamplesGroupBox.Controls.Add(FormatDatesRadioButton);
        ExamplesGroupBox.Controls.Add(AddSubtractRadioButton);
        ExamplesGroupBox.Controls.Add(LessThanOrEqualRadioButton);
        ExamplesGroupBox.Controls.Add(GreaterThanRadioButton);
        ExamplesGroupBox.Controls.Add(EqualityRadioButton);
        ExamplesGroupBox.Location = new Point(663, 85);
        ExamplesGroupBox.Name = "ExamplesGroupBox";
        ExamplesGroupBox.Size = new Size(447, 225);
        ExamplesGroupBox.TabIndex = 8;
        ExamplesGroupBox.TabStop = false;
        ExamplesGroupBox.Text = "Examples";
        // 
        // FormatDatesRadioButton
        // 
        FormatDatesRadioButton.AutoSize = true;
        FormatDatesRadioButton.Location = new Point(231, 76);
        FormatDatesRadioButton.Name = "FormatDatesRadioButton";
        FormatDatesRadioButton.Size = new Size(145, 24);
        FormatDatesRadioButton.TabIndex = 10;
        FormatDatesRadioButton.TabStop = true;
        FormatDatesRadioButton.Text = "Standard formats";
        FormatDatesRadioButton.UseVisualStyleBackColor = true;
        // 
        // AddSubtractRadioButton
        // 
        AddSubtractRadioButton.AutoSize = true;
        AddSubtractRadioButton.Location = new Point(229, 37);
        AddSubtractRadioButton.Name = "AddSubtractRadioButton";
        AddSubtractRadioButton.Size = new Size(119, 24);
        AddSubtractRadioButton.TabIndex = 3;
        AddSubtractRadioButton.TabStop = true;
        AddSubtractRadioButton.Text = "Add/Subtract";
        AddSubtractRadioButton.UseVisualStyleBackColor = true;
        // 
        // LessThanOrEqualRadioButton
        // 
        LessThanOrEqualRadioButton.AutoSize = true;
        LessThanOrEqualRadioButton.Location = new Point(17, 117);
        LessThanOrEqualRadioButton.Name = "LessThanOrEqualRadioButton";
        LessThanOrEqualRadioButton.Size = new Size(154, 24);
        LessThanOrEqualRadioButton.TabIndex = 2;
        LessThanOrEqualRadioButton.TabStop = true;
        LessThanOrEqualRadioButton.Text = "Less Than Or Equal";
        LessThanOrEqualRadioButton.UseVisualStyleBackColor = true;
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
        // GreetingLabel
        // 
        GreetingLabel.AutoSize = true;
        GreetingLabel.Location = new Point(12, 9);
        GreetingLabel.Name = "GreetingLabel";
        GreetingLabel.Size = new Size(50, 20);
        GreetingLabel.TabIndex = 9;
        GreetingLabel.Text = "label1";
        // 
        // RawStringLiteralButton
        // 
        RawStringLiteralButton.AutoSize = true;
        RawStringLiteralButton.Location = new Point(231, 117);
        RawStringLiteralButton.Name = "RawStringLiteralButton";
        RawStringLiteralButton.Size = new Size(141, 24);
        RawStringLiteralButton.TabIndex = 10;
        RawStringLiteralButton.TabStop = true;
        RawStringLiteralButton.Text = "Raw string literal";
        RawStringLiteralButton.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1122, 674);
        Controls.Add(GreetingLabel);
        Controls.Add(ExamplesGroupBox);
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
        ExamplesGroupBox.ResumeLayout(false);
        ExamplesGroupBox.PerformLayout();
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
    private GroupBox ExamplesGroupBox;
    private RadioButton GreaterThanRadioButton;
    private RadioButton EqualityRadioButton;
    private RadioButton LessThanOrEqualRadioButton;
    private RadioButton AddSubtractRadioButton;
    private Label GreetingLabel;
    private RadioButton FormatDatesRadioButton;
    private RadioButton RawStringLiteralButton;
}
