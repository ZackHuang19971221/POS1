using System;
using System.Threading.Tasks;
using System.Windows;

namespace FOH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int aaa = 0;
        private async void Button1_Click(object Sender, EventArgs e)
        {
            try
            {
                aaa = aaa + 1;
                int a = await SendDataAsync(aaa);
                // Do something with the result if needed
                this.TB.Text = a.ToString();
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private async Task<int> SendDataAsync(int Url)
        {
            await Task.Delay(5000); // Replaces Thread.Sleep(5000)
            return Url;
        }
    }
}
