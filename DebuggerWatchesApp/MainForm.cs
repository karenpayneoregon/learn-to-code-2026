
using DebuggerWatchesApp.Classes;
using DebuggerWatchesApp.Classes.Configuration;
using DebuggerWatchesApp.Models.Configuration;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
#pragma warning disable CS8601 // Possible null reference assignment.

namespace DebuggerWatchesApp;

public partial class MainForm : Form
{
    /// <summary>
    /// Represents the application configuration, including logging, allowed hosts, and connection strings.
    /// </summary>
    /// <remarks>
    /// This field is initialized by reading the configuration from the appsettings.json file
    /// using <see cref="DebuggerWatchesApp.Classes.Configuration.ConfigurationOperations.ReadConfiguration"/>.
    /// It is used to manage and update application settings, such as connection strings.
    /// </remarks>
    private readonly Configuration configuration = ConfigurationOperations.ReadConfiguration();
    public MainForm()
    {

        InitializeComponent();

        ConnectionsListBox.SelectedIndex = 0;

        DataConnections.Instance.MainConnection = configuration.ConnectionStrings.MainConnection;

        Debugger.Break();
    }

    private void ChangeConnectionStringButton_Click(object sender, EventArgs e)
    {
        configuration.ConnectionStrings.MainConnection = ConnectionsListBox.SelectedItem!.ToString();
        ConfigurationOperations.SaveChanges(configuration);
        DataConnections.Instance.MainConnection = configuration.ConnectionStrings.MainConnection;

        Debugger.Break();
    }

    private void CurrentButton_Click(object sender, EventArgs e)
    {
        Dialogs.Information(this, 
            InitialCatalogFromConnectionString(DataConnections.Instance.MainConnection));
    }

    public static string InitialCatalogFromConnectionString(string connectionString)
        => new SqlConnectionStringBuilder(connectionString).InitialCatalog;
}
