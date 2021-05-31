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
using PieceFabric;

namespace ChessWPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Piece[,] board;
        public PiecesData piecesData;
        public Piece curPiece;


        public MainWindow()
        {
            InitializeComponent();
            board = new Piece[8, 8];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = board[Grid.GetRow(sender as Button),Grid.GetColumn(sender as Button)].ToString();
            if (curPiece != null)
            {
                board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)] = curPiece;
                (sender as Button).Content = curPiece.ToString();
            }
            else 
            {
                curPiece = board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)];
            }
        }

        private void btnPlace_Click(object sender, RoutedEventArgs e)
        {
            piecesData = new PiecesData 
            {
                Name = ((ListBoxItem)lbPiece.SelectedItem).Content.ToString(),
                Data = new Dictionary<string, int>
                {
                    { "X", int.Parse(tbX.Text)},
                    { "Y", int.Parse(tbY.Text) }
                }
            };
            board[piecesData.Data["X"], piecesData.Data["Y"]] = PieceFab.Make(piecesData);
        }
    }
}
