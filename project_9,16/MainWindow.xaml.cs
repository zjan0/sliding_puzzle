using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project_9_16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int score = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start.Click += Start_Click;
        }
        private void Start_Click(object sender,RoutedEventArgs e)
        {
            bool valid = true;
            try
            {
                int size = int.Parse(Sizexy.Text);
                if((size<2)||(size>10))
                {
                    valid = false;
                    Sizexy.Text = "Enter Field Size: 2-10";
                }
            }
            catch
            {
                valid = false;
                Sizexy.Text = "Enter Field Size: 2-10";
            }
            if(valid==true)
            {
                Generate();
            }
        }
        private void Generate()
        {
            Intro.Visibility = Visibility.Hidden;
            PanelF.Visibility = Visibility.Visible;
            Field.ColumnDefinitions.Clear();
            Field.RowDefinitions.Clear();
            Field.Children.Clear();
            int number = 0;
            for(int a=0;a<int.Parse(Sizexy.Text);a++)
            {
                Field.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int b=0;b<int.Parse(Sizexy.Text);b++)
            {
                Field.RowDefinitions.Add(new RowDefinition());
            }
            for(int y=0;y<int.Parse(Sizexy.Text);y++)
            {
                for(int x=0;x<int.Parse(Sizexy.Text);x++)
                {
                    number++;
                    Button box = new Button();
                    box.Click += Move;
                    if(number<int.Parse(Sizexy.Text)*int.Parse(Sizexy.Text))
                    {
                        box.Content = number;
                    }
                    box.TabIndex = number;
                    Grid.SetColumn(box, x);
                    Grid.SetRow(box, y);
                    Field.Children.Add(box);
                }
            }
            Shuffle();
        }
        private void Shuffle()
        {
            double moves = 0;
            bool easy = true;
            Random random = new Random();
            while(easy==true)
            {
                moves++;
                Button Btnempty = null;
                int rng = random.Next(1, 5);
                foreach (Button button in Field.Children)
                {
                    if (button.Content == null)
                    {
                        Btnempty = button;
                        break;
                    }
                }
                foreach(Button search in Field.Children)
                {
                    if((rng==1)&&(Btnempty.TabIndex+1==search.TabIndex)&& (Btnempty.TabIndex % int.Parse(Sizexy.Text) != 0))
                    {
                        Btnempty.Content = search.Content;
                        search.Content = null;
                    }
                    if ((rng == 2) && (Btnempty.TabIndex - 1 == search.TabIndex)&& (Btn.TabIndex % int.Parse(Sizexy.Text) != 0))
                    {
                        Btnempty.Content = search.Content;
                        search.Content = null;
                    }
                    if ((Btnempty.TabIndex + int.Parse(Sizexy.Text) == search.TabIndex)&&(rng==3))
                    {
                        Btnempty.Content = search.Content;
                        search.Content = null;
                    }
                    if ((Btnempty.TabIndex - int.Parse(Sizexy.Text) == search.TabIndex)&&(rng==4))
                    {
                        Btnempty.Content = search.Content;
                        search.Content = null;
                    }
                }
                if(moves==int.Parse(Sizexy.Text)*int.Parse(Sizexy.Text)*10)
                {
                    easy= Check();
                    if(easy==true)
                    {
                        moves = 0;
                    }
                }
            }
        }
        private void Move(object sender,RoutedEventArgs e)
        {
            Button Btn = (Button)sender;
            if(Btn.Content==null)
            {
                return;
            }
            Button Btnempty = null;
            foreach(Button button in Field.Children)
            {
                if (button.Content==null)
                {
                    Btnempty = button;
                    break;
                }
            }
            if ((Btnempty.TabIndex+1==Btn.TabIndex)||(Btnempty.TabIndex - 1 == Btn.TabIndex)||(Btnempty.TabIndex+int.Parse(Sizexy.Text)==Btn.TabIndex)||(Btnempty.TabIndex-int.Parse(Sizexy.Text)==Btn.TabIndex))
            {
                if (((Btnempty.TabIndex + 1 == Btn.TabIndex)&&(Btnempty.TabIndex%int.Parse(Sizexy.Text)==0))|| (Btnempty.TabIndex - 1 == Btn.TabIndex)&& (Btn.TabIndex % int.Parse(Sizexy.Text)==0))
                {

                }
                else
                {
                score++;
                Scorec.Content = $"moves: {score}";
                Btnempty.Content = Btn.Content;
                Btn.Content = null;
                }
            }
            bool finish= Check();
            if(finish==true)
            {
                Moves.Content = $"Moves: {score}";
                PanelF.Visibility = Visibility.Hidden;
                Ending.Visibility = Visibility.Visible;
            }
        }
        private bool Check()
        {
            bool check = false;
            int number = 0;
            foreach(Button btn in Field.Children)
            {
                number++;
                if ((btn.Content==null)&&(number!=Field.Children.Count))
                {
                    return check;
                }
                else if(number!=Convert.ToInt16(btn.Content))
                {
                    return check;
                }
            }
            check = true;
            return check;
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            Again.Click += NewAgain;
        }
        private void NewAgain(object sender, RoutedEventArgs e)
        {
            Intro.Visibility = Visibility.Visible;
            Ending.Visibility = Visibility.Hidden;
            score = 0;
            Sizexy.Text = "Enter Field Size: 2-10";
        }
    }
}