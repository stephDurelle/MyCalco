using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace MaCalco
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window

    {
        double output ;
        double output1;
        bool operationclick=false;
        string operation = "";
        double resultat;
        // String x = "";



        public MainWindow()
        {
            InitializeComponent();
          
            Btndivise.Content = "\u00F7";
            Btnmoins.Content = "\u2212";
            Btnplus.Content = "\uFF0B";
            BtnpOUm.Content = "\u00B1";
            Btnmulti.Content = "\u2716";
         






            sortiechiffre.Text = "0";
        }
        
        private void B_Click(Object sender, RoutedEventArgs e)
        {
            String name = ((Button)sender).Name;
            switch (name)
            {
                case "Un":
                case "Deux":
                case "Trois":
                case "Quatre":
                case "Cinq":
                case "Six":
                case "Sept":
                case "Huit":
                case "Neuf":
                case "Zero":
                    if (!operationclick)
                    {
                        output = double.Parse(output.ToString() + ((Button)sender).Content.ToString()); 
                        sortiechiffre.Text = output.ToString();
                    }
                    else
                    {
                        output1 = double.Parse(((Button)sender).Content.ToString()); // Affectez le chiffre à output1
                        sortiechiffre.Text = output1.ToString();
                        operationclick = false;
                    }
                    break;

                case "Btnexpo":
                    operationclick = true;
                    operation = "10^";
                    sortiechiffre1.Text = $"{operation}({output})  ";
                        output1 = Math.Pow(10, (output) );



                        sortiechiffre.Text = output1.ToString();
                    operationclick = false;
                    output = 0;
                    output1 = 0;

                    break;
                case "Btnabsolu":
                    operationclick = true;
                    sortiechiffre1.Text = $"Abs( {output})   ";
                    output1 = Math.Abs(output);
                    sortiechiffre.Text = output1.ToString();
                    operationclick=false;
                    output = 0;
                    output1 = 0;
                    break;
                case "Btnplus":
                case "Btnmoins":
                case "Btnmulti":
                case "Btndivise":
                case "Btnmodulo":               
                    operationclick = true;
                    operation = ((Button)sender).Content.ToString();
                    sortiechiffre1.Text = output + " " + operation + " ";



                    break;

                case "Btnegal":
                    operationclick = true;
                    if (operation != "")
                    {
                       
                        switch (operation)
                        {
                            case "\uFF0B":
                              resultat = output + output1;
                               
                                break;
                            case "\u2212":
                                resultat = output - output1;
                                break;
                            case "\u2716":
                                resultat = output * output1;
                                break;
                            case "\uFF05":
                                if (output1 != 0)
                                {
                                    
                                    resultat = output % output1;
                                }
                                else { sortiechiffre.Text = "Erreur"; }
                                break;
                            case "\u00F7":
                                if (output1 != 0)
                                    resultat = output / output1;
                                else
                                    sortiechiffre.Text = "Erreur"; // Division par zéro
                                break;
                        }
                        sortiechiffre.Text = resultat.ToString();
                        sortiechiffre1.Text = output + " " + operation + " " + output1 + "=  ";
                        operation = "";
                       output = 0;
                        output1 = 0;
                        operationclick = false;
                       
                        
                    }
                    
                    break;
                  

            }
         
        }
       
        private void Bsigne_Click(Object sender, RoutedEventArgs e)
        {
            output *= -1;
            sortiechiffre1.Text = output+ operation;
            sortiechiffre.Text = $"{output}";
        }
        private void Bparent1_Click(Object sender, RoutedEventArgs e)
        {
           
            sortiechiffre1.Text = "(" + output +output1;
            sortiechiffre.Text = "0";
        }
        private void Bparent2_Click(Object sender, RoutedEventArgs e)
        {
            output1 = output;
            sortiechiffre1.Text = "(" + output1 + ")";
            sortiechiffre.Text = "0";
        }
      
        private void Bvirgule_Click(Object sender, RoutedEventArgs e)
        {
            
            output1 = output;
            sortiechiffre1.Text = output1 + ",";
            sortiechiffre.Text = "0";
        }
       
        private void Bsup_Click(Object sender, RoutedEventArgs e)
        {
            output = 0;
            output1 = 0;
            sortiechiffre1.Text = "";
            sortiechiffre.Text = "0";
            operation = "";
            operationclick = false;
            
        }
       
       


     
    }


}
