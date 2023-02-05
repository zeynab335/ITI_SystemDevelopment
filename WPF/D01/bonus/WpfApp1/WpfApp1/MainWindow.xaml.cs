using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        private void richbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                richbox.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                richbox.Document.ContentEnd
            );


            FlowDocument myFlowDoc = new FlowDocument();

            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(textRange.Text.ToString().Trim() + " Append text");

            // Add the paragraph to the FlowDocument.
            myFlowDoc.Blocks.Add(myParagraph);
            richbox.Document =  myFlowDoc;
        }
    }
}
