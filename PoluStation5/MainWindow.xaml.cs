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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PoluStation5
{
    public partial class MainWindow : Window
    {
        public int Limit = 14; //A quantidade de jogos que o user há na biblioteca + 1 não sei porque mas é necessarioK
        public int Selected = 1; //O Selecionado deve ser 1 pois é a loja
        public int Retries = 0; // Não mude | Esse codigo é usado no RenameAll() para renomear todos para zero , idependente da quantidade de jogos na biblioteca
        public string ActualSelectedOnMenu; //Não mude | Ele vai ser o string do int que vai ser usado no ActualObject();
        public int LabelToRename = 1; //Tambem não mude | Ele vai ser o int que vai ser adicionado +1 a cada tentativa, logo ele vai tentar o maximo de objetos que conseguir ( OBS : POR ISSO É IDEPENDENTE DA QUANTIDADE DE JOGOS NA BIBLIOTECA )
        public int DefaultToAddOnWidth = 175;
        public MainWindow()
        {
            InitializeComponent();
        }
        Storyboard storyboard = new Storyboard();
        TimeSpan halfsecond = TimeSpan.FromMilliseconds(500);
        TimeSpan second = TimeSpan.FromSeconds(1);

        void ActualObject(int ActualSelected)
        {
            if (ActualSelected < Limit)
            {
                string ASToString = ActualSelected.ToString();
                RemoveIntShit(ASToString);
                ActualSelectedOnMenu = "PH" + ASToString;
            }
            else
            {
                MessageBox.Show("No Games");
            }
        }

        private IEasingFunction Smooth
        {
            get;
            set;
        }

        public void ObjectShiftPos(DependencyObject Object, Thickness Get, Thickness Set)
        {
            ThicknessAnimation ShiftAnimation = new ThicknessAnimation()
            {
                From = Get,
                To = Set,
                Duration = second,
                EasingFunction = Smooth,
            };
            Storyboard.SetTarget(ShiftAnimation, Object);
            Storyboard.SetTargetProperty(ShiftAnimation, new PropertyPath(MarginProperty));
            storyboard.Children.Add(ShiftAnimation);
            storyboard.Begin();
        }

        string RemoveIntShit(string Int)
        {
            Int.Replace(" ", string.Empty);
            return Int.ToString();
        }

        private void ChangeSelectedP(Object sender)
        {
            if (MenuOrganization.FindName(ActualSelectedOnMenu) == null == false)
            {
                RenameOnPlus();
                Object selected = MenuOrganization.FindName(ActualSelectedOnMenu);
                (selected as Label).Content = "1";
                //ACtual.Content = Selected.ToString();
            }
        }

        // public int DefaultPar = 51; //Parametro normal da posição do menu
        // public int ChangeParTo = 150; //Parametro que ira mudar a posição do menu
        // public int AddPosition = 240; //Parametro que ira adicionar no height

        private void ChangeSelectedM(Object sender)
        {
            if (MenuOrganization.FindName(ActualSelectedOnMenu) == null == false)
            {
                RenameOnMinus();
                Object selected = MenuOrganization.FindName(ActualSelectedOnMenu);
                (selected as Label).Content = "1";
                //ACtual.Content = Selected.ToString();
            }
        }

        private void RenameOnPlus()
        {
            while (Retries < Limit)
                try
                {
                    if (LabelToRename < Limit)
                    {
                        Object selected = MenuOrganization.FindName("PH" + LabelToRename);
                        (selected as Label).Content = "0";
                        LabelToRename++;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    if (++Retries == Limit)
                        LabelToRename = 1;
                    throw;
                    continue;
                }
        }
        private void RenameOnMinus()
        {
            while (Retries < Limit)
                try
                {
                    if (LabelToRename < Limit)
                    {
                        Object selected = MenuOrganization.FindName("PH" + LabelToRename);
                        (selected as Label).Content = "0";
                        LabelToRename--;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    if (++Retries == Limit)
                        LabelToRename = 1;
                    throw;
                    continue;
                }
        }

        private void PoluStationW_KeyDown_1(object sender, KeyEventArgs e)
        {

            /*if (Selected <= Limit)
            {*/
            if (e.Key == Key.Right)
            {
                if (Selected == Limit - 1 == false)
                {
                    Selected++;
                    ActualObject(Selected);
                    ChangeSelectedP(null);
                }
            }
            else if (e.Key == Key.Left)
            {
                if (Selected == 1 == false)
                {
                    Selected--;
                    ActualObject(Selected);
                    ChangeSelectedM(null);
                }
            }
            else if (e.Key == Key.Up)
            {
                MessageBox.Show("Não disponivel");
            }
            /*}
            else if (Selected <= 1 && Selected >= 9)
            {
                Selected = 0;
            }*/
        }
    }
}
