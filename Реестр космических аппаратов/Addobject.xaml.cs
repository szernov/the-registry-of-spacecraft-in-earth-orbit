﻿using System;
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

namespace Реестр_космических_аппаратов
{
    /// <summary>
    /// Логика взаимодействия для Addobject.xaml
    /// </summary>
    public partial class Addobject : Page
    {
        MainWindow mw;
        public Addobject(MainWindow v)
        {
            InitializeComponent();
            mw = v;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        { try
            {
                int i = 0;
                int j = 0;
                foreach (Sputnik sm in mw.sputniks.ToArray())
                {
                    if (sm.Callsign == callsignt.Text)
                    {
                        i += 1;
                        MessageBox.Show("Объект с таким именем уже существует");
                        break;
                    }



                }
                foreach (Spacestation sv in mw.spacestations.ToArray())
                {
                    if (sv.Callsign == callsignt.Text)
                    {
                        j += 1;
                        MessageBox.Show("Объект с таким именем уже существует");
                        break;

                    }
                }




                if (ElementType.SelectedIndex == 0 && i == 0 && j == 0)
                {
                    Sputnik sp = new Sputnik(callsignt.Text, int.Parse(launcht.Text), int.Parse(reenteryt.Text), int.Parse(daysinorbitt.Text), 0, rockett.Text, int.Parse(launchmasst.Text));
                    mw.sputniks.Add(sp);
                    mw.Write();
                    mw.Writeser();
                }
                if (ElementType.SelectedIndex == 1 && j == 0 && i == 0)
                {
                    Spacestation st = new Spacestation(callsignt.Text, int.Parse(launcht.Text), int.Parse(reenteryt.Text), int.Parse(daysinorbitt.Text), 1, int.Parse(crewt.Text));
                    mw.spacestations.Add(st);
                    mw.Write();
                    mw.Writeser();
                }
            }

            catch(Exception b)
            { MessageBox.Show(b.ToString()); }


        }

                    
        

            

        private void ElementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ElementType.SelectedIndex==0)
            {
                launchmass.Visibility = Visibility.Visible;
                rocket.Visibility = Visibility.Visible;
                crew.Visibility = Visibility.Collapsed;
                rockett.Visibility = Visibility.Visible;
                launchmasst.Visibility = Visibility.Visible;
                crewt.Visibility = Visibility.Collapsed;
            }
            else
            {
                launchmass.Visibility = Visibility.Collapsed;
                rocket.Visibility = Visibility.Collapsed;
                crew.Visibility = Visibility.Visible;
                rockett.Visibility = Visibility.Collapsed;
                launchmasst.Visibility = Visibility.Collapsed;
                crewt.Visibility = Visibility.Visible;
            }
        }
    }
}
