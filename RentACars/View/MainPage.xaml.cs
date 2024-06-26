﻿using Microsoft.Maui.Animations;
using RentACars.Auto;
using RentACars.Utilities.DataAccess;
using RentACars.Utilities.DataAccess.Files;
using RentACars.Utilities.Interfaces;
using RentACars.ViewModel;

namespace RentACars.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageVM, IDataAccess dataAccessService,IAlertService alertService)
        {
            dataAccess = dataAccessService;
            alert = alertService;
            mainPageViewModel = mainPageVM;
            // Définition du BindingContext avec le ViewModel
            BindingContext = mainPageVM;

            InitializeComponent();
        }

        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IAlertService alert;
        /// <summary>
        /// keep a reference to the ViewModel for eventual testings
        /// </summary>
        private MainPageViewModel mainPageViewModel;



        //private void ButtonTestVehicule_Clicked(object sender, EventArgs e)
        //{
        //    Car FirstVehicule = new Car(1, "renault_megane.jpg", "Renault", "Megane", "Noir", "1-EAU-288", true, "VF1JP0YB25V481693", "1.5DCI", "2020", 4.35, 1.81, 190, "Diesel", 110, 70, 21, "B");
            
        //    lblDebug.Text = "Véhicule Crée";
            
        //}

        //private void ButtonDataAccessCSVFiles_Clicked(object sender, EventArgs e)
        //{
        //    string CONFIG_FILE = @"C:\Users\Ai\source\repos\RentACars\RentACars\Configuration\Datas\Config.txt";
        //    DataFilesManager dataFilesStaffMember = new DataFilesManager(CONFIG_FILE);
        //    DataAccessCsvFiles daCsv = new DataAccessCsvFiles(dataFilesStaffMember);
        //    VehiclesCollection vehicule = daCsv.GetAllVehicles();
        //    vehicule.ToList().ForEach(st => lblDebug.Text += $"\n Immat : {st.Plate} - Marque {st.Brand} ");
            
        //    VehiclesCollection vehicules = daCsv.GetAllVehicles();
        //    vehicule.ToList().ForEach(c => lblDebug.Text += $"\n Immat:{c.Plate} - Marque{c.Brand}{c.Model}");
        //}

        //private void ButtonDataAccessJSONFiles_Clicked(object sender, EventArgs e)
        //{
        //    string CONFIG_FILE = @"C:\Users\Ai\source\repos\RentACars\RentACars\Configuration\Datas\ConfigJson.txt";
        //    DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
        //    DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);
        //    VehiclesCollection vehicule = da.GetAllVehicles();
        //    vehicule.ToList().ForEach(it => lblDebug.Text += $"\n Immat: {it.Plate} - Marque {it.Model}");
        //    vehicule[0].Plate = "C'est une blague";
        //    vehicule[5].Model = "BlaBla"; //changement du prix du 6ème item
        //                               //sauvegarde des données 
        //    //da.UpdateAllVehiculesDatas(vehicule);
        //}

    }

}
