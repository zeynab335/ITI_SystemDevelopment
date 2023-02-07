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

namespace Calculator
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

        private void AddValueToText(object sender, RoutedEventArgs e)
        {
            string value = (((Button)sender).Content.ToString());
            int num;

            string text;

            int.TryParse(value, out num);
            if (num > 0)
            {
                text = value;
            }
            else
            {
                text = " " + value + " ";                
            }

            if (text.Equals(" = "))
                Calculate(txt.Text);

            else txt.Text += text;
           
        }

        private void Calculate(string text)
        {
            var Text = text.Split(" ");
            List<string> Operators = new List<string>() ;
            List<int> Numbers = new List<int>();

            //int Right, Left;
            foreach (string Operator in Text)
            {
                switch (Operator) {

                    // Operators
                    case "+":
                        Operators.Add("+");
                        break;

                    case "-":
                        Operators.Add("-");
                        break;

                    case "X":
                        Operators.Add("X");
                        break;

                    case "÷":
                        Operators.Add("÷");
                        break;

                    // Add Numbers
                    case "1":
                        Numbers.Add(1);
                        break;

                   default: Numbers.Add(int.Parse(Operator)); break;

                }
            }


            int Result = Numbers[0];

            int j;

            for (int i=1; i<Numbers.Count; i++) {

                j = i - 1;

                if (Operators[j].Equals("X") || Operators[j].Equals("÷")){
                    
                    // 4*4/4 ==> 
                    if (j!=0 && (Operators[j-1].Equals("X") || Operators[j-1].Equals("÷")))
                    {
                        switch (Operators[j])
                        {

                            case "X":

                                Result *= Numbers[i];

                                break;

                            case "÷":
                                Result /= Numbers[i];
                                break;

                        }
                    }
                    else
                    {
                        switch (Operators[j])
                        {

                            case "X":
                                Result -= Numbers[j];
                                Result += Numbers[j] * Numbers[i];

                                break;

                            case "÷":
                                Result -= Numbers[j];
                                Result += Numbers[j] / Numbers[i];
                                break;

                        }
                    }
                  
                }
                else
                {
                    switch (Operators[j])
                    {
                        case "+":
                            Result += Numbers[i];
                            break;

                        case "-":
                            Result -= Numbers[i];
                            break;

                    }
                }
               
            
            }

            txt.Text = Result.ToString();
            
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            txt.Text = "";
        }
    }
}
