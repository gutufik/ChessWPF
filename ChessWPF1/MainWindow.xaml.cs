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
        public Button[,] buttons;


        public MainWindow()
        {
            InitializeComponent();
            board = new Piece[8, 8];
            buttons = new Button[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 80;
                    buttons[i, j].Height = 80;
                    buttons[i, j].Click += Button_Click;
                    buttons[i, j].Background = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                    BaseGrid.Children.Add(buttons[i, j]);
                    Grid.SetRow(buttons[i, j], i);
                    Grid.SetColumn(buttons[i, j], j);
                    //buttons[i,j].Margin = new Thickness(j*40, i*40, j*10, i*10);
                    //Panel.Children.Add(buttons[i, j]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(sender as Button).Content = $"{Grid.GetRow(sender as Button)},{Grid.GetColumn(sender as Button)}";
            
            if (curPiece != null)
            {
                int prevX = curPiece.x;
                int prevY = curPiece.y;
                
                if (curPiece.Move(Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)))
                {
                    board[Grid.GetRow(sender as Button), Grid.GetColumn(sender as Button)] = curPiece;
                    (sender as Button).Content = curPiece.ToString();
                    buttons[prevX, prevY].Content = "";
                    board[prevX, prevY] = null;
                    curPiece = null;
                }
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
            buttons[piecesData.Data["X"], piecesData.Data["Y"]].Content = piecesData.Name;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            board[int.Parse(tbDelX.Text), int.Parse(tbDelY.Text)] = null;
            buttons[int.Parse(tbDelX.Text), int.Parse(tbDelY.Text)].Content = "";
        }
    }
}
