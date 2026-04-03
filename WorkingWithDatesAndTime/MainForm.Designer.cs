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
        SuspendLayout();
        // 
        // ResultsTextBox
        // 
        ResultsTextBox.Dock = DockStyle.Bottom;
        ResultsTextBox.Font = new Font("Courier New", 12F);
        ResultsTextBox.Location = new Point(0, 220);
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1122, 515);
        Controls.Add(HolidaysButton);
        Controls.Add(DateTimeTryParseButton);
        Controls.Add(GroupWorkDaysByWeekButton);
        Controls.Add(ResultsTextBox);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Working with date/time";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox ResultsTextBox;
    private Button GroupWorkDaysByWeekButton;
    private Button DateTimeTryParseButton;
    private Button HolidaysButton;
}
