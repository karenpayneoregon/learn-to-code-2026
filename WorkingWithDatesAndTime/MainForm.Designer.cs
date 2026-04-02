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
        ReultsTextBox = new TextBox();
        GroupWorkDaysByWeekButton = new Button();
        DateTimeTryParseButton = new Button();
        SuspendLayout();
        // 
        // ReultsTextBox
        // 
        ReultsTextBox.Dock = DockStyle.Bottom;
        ReultsTextBox.Font = new Font("Courier New", 12F);
        ReultsTextBox.Location = new Point(0, 275);
        ReultsTextBox.Multiline = true;
        ReultsTextBox.Name = "ReultsTextBox";
        ReultsTextBox.Size = new Size(1122, 240);
        ReultsTextBox.TabIndex = 0;
        // 
        // GroupWorkDaysByWeekButton
        // 
        GroupWorkDaysByWeekButton.Location = new Point(12, 222);
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1122, 515);
        Controls.Add(DateTimeTryParseButton);
        Controls.Add(GroupWorkDaysByWeekButton);
        Controls.Add(ReultsTextBox);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Working with date/time";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox ReultsTextBox;
    private Button GroupWorkDaysByWeekButton;
    private Button DateTimeTryParseButton;
}
