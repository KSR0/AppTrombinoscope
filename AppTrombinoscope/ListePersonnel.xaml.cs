using BddpersonnelContext;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionPersonnel.xaml
    /// </summary>
    public partial class ListePersonnel : Window
    {
        private bddpersonnels bdd;
        public ListePersonnel(bddpersonnels bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
            DataGridPersonnel.ItemsSource = bdd.GetPersonnel();
        }
    }
}
