namespace DebuggerWatchesApp;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        ChangeConnectionStringButton = new Button();
        ConnectionsListBox = new ListBox();
        CurrentButton = new Button();
        SuspendLayout();
        // 
        // ChangeConnectionStringButton
        // 
        ChangeConnectionStringButton.Location = new Point(12, 26);
        ChangeConnectionStringButton.Name = "ChangeConnectionStringButton";
        ChangeConnectionStringButton.Size = new Size(196, 29);
        ChangeConnectionStringButton.TabIndex = 0;
        ChangeConnectionStringButton.Text = "Change Connection string";
        ChangeConnectionStringButton.UseVisualStyleBackColor = true;
        ChangeConnectionStringButton.Click += ChangeConnectionStringButton_Click;
        // 
        // ConnectionsListBox
        // 
        ConnectionsListBox.FormattingEnabled = true;
        ConnectionsListBox.Items.AddRange(new object[] { "Server=.\\\\sqlexpress;Database=North;Trusted_Connection=True;MultipleActiveResultSets=True;", "Server=(local)\\\\sqlexpress;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=True;" });
        ConnectionsListBox.Location = new Point(12, 61);
        ConnectionsListBox.Name = "ConnectionsListBox";
        ConnectionsListBox.Size = new Size(776, 104);
        ConnectionsListBox.TabIndex = 1;
        // 
        // CurrentButton
        // 
        CurrentButton.Location = new Point(694, 26);
        CurrentButton.Name = "CurrentButton";
        CurrentButton.Size = new Size(94, 29);
        CurrentButton.TabIndex = 2;
        CurrentButton.Text = "Current";
        CurrentButton.UseVisualStyleBackColor = true;
        CurrentButton.Click += CurrentButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 218);
        Controls.Add(CurrentButton);
        Controls.Add(ConnectionsListBox);
        Controls.Add(ChangeConnectionStringButton);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Watches";
        ResumeLayout(false);
    }

    #endregion

    private Button ChangeConnectionStringButton;
    private ListBox ConnectionsListBox;
    private Button CurrentButton;
}
