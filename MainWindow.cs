﻿using M7Actividad2.Model;
using M7Actividad2.Model.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M7Actividad2
{
    public partial class MainWindow : Form
    {
        private static Vuelo[] vuelos;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void butAirline_Click(object sender, EventArgs e)
        {
            AirlineFilterWindow airlineFilterWindow = new AirlineFilterWindow();
            airlineFilterWindow.ShowDialog();
        }

        private void showAllFlights()
        {
            VueloRespositoryInterface vueloRepository = new MysqlVueloRepository();
            vuelos = vueloRepository.GetAll();
        }

        public void showFlightsByAirline(string airline)
        {
            VueloRespositoryInterface vueloRepository = new MysqlVueloRepository();
            vuelos = vueloRepository.getByAirline(airline);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            showFlights(vuelos);
        }

        private void showFlights(Vuelo[] vuelos)
        {
            lvAllFlights.Items.Clear();

            foreach (Vuelo vuelo in vuelos)
            {
                ListViewItem lvItem = lvAllFlights.Items.Add(vuelo._flightNumber);
                lvItem.SubItems.Add(vuelo._originAirportId);
                lvItem.SubItems.Add(vuelo._destinationAirportId);
                lvItem.SubItems.Add(vuelo._flightDate);
                lvItem.SubItems.Add(vuelo._airlineId);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            showAllFlights();
        }
    }
}
