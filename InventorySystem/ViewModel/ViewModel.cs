using InventorySystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;




namespace InventorySystem
{
    
    public class ViewModel : ViewModelBase
    {
        //controls if the save button is enabled. every text box will need to pass vaildation for this to be true
      
        //data trigger to manage the active view
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                if (value != currentView)
                {
                    currentView = value;
                    OnPropertyRaised("CurrentView");
                }
            }
        }
        // stores the master inventories
       
        private ObservableCollection<Part> allParts = new ObservableCollection<Part>();
        private ObservableCollection<Product> allProducts = new ObservableCollection<Product>();
        public ObservableCollection<Part> AllParts { get { return allParts; } set { this.allParts = value; } }
        public ObservableCollection<Product> AllProducts { get { return allProducts; } set { this.AllProducts = value; } }
        public ObservableCollection<Part> displayParts = new ObservableCollection<Part>();

        public ObservableCollection<Part> DisplayParts { get { return displayParts; } set { this.displayParts = value; } }

        public string searchString;
        public string SearchString
        {
            get { return searchString; }
            set {
                if (value != searchString)
                {
                    searchString = value;
                    OnPropertyRaised("SearchString");
                }
            }
        }
        
        // auto increments the part id for new parts
        public int PartIdIndex { get; set; }
        public string PartIdString { get { return PartIdIndex.ToString(); } }
        
        //for any instance of creating a new part
        public Part NewPart { get; set; }

        //data binding to the data grid
        public Object SelectedPart { get; set; }

        //properties for the add part screen
        public String NewPartId { get; set; }
        public String NewPartName { get; set; }
        public String NewPartStock { get; set; }
        public String NewPartPrice { get; set; }
        public String NewPartMax { get; set; }
        public String NewPartMin { get; set; }
        public String NewPartMachineId { get; set; }
        public String NewPartVendor { get; set; }
               
        public ViewModel()
        {
             DeSerialize();
            DisplayParts = AllParts;
            //active main screen view
            CurrentView = new MainWindowView();
        }

         ~ViewModel()
        {
            Serialize();
        }
        
        public RelayCommand HandleDeletePart
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnDeletePart);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnDeletePart()
        {
            //makes sure there is a product selected
            if (SelectedPart is null)
            {
                MessageBoxResult alert = MessageBox.Show("There is no part selected");
                return;
            }

            // if a producdt is selected, double checks that user wants to delete it
            if (MessageBox.Show("Do you want to delete the selected item?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                // end function to prevent deletion
                return;
            }

            //SelectedPart is data bound to the data grid's selected item
            Part selectedPart = (Part)SelectedPart;
            AllParts.Remove(selectedPart);
            Serialize();
            return;
        }

        public RelayCommand HandleAddPart
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnAddPart);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnAddPart()
        {//determines the highest number part id,and sets the id index to one higher
            int MaxIndex = 0;
            foreach (Part part in AllParts)
            {
                if (part.Id > MaxIndex)
                {
                    MaxIndex = part.Id;
                }
            }
            NewPartId = (MaxIndex + 1).ToString();
            CurrentView = new AddPartView();
                  
        
        }


        public RelayCommand HandleCancel
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnCancel);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnCancel()
        {
            //validates window closure
            if (MessageBox.Show("Do you want to discard changes and return to main screen?",
               "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                // end function to prevent closure
                return;
            }

            //loads the last saved file, ensuring that any canceled changes are rolled back
            DeSerialize();
            CurrentView = new MainWindowView();
        }

        public RelayCommand HandleNewPartSave
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnNewPartSave);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnNewPartSave()
        {
            // asks for confirmation to save changes
            //validates window closure
            if (MessageBox.Show("Do you want to save these changes?",
               "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                // end function to prevent saving changes, keeps window open
                return;
            }

            try
            {
                //determines if part is in house our outsourced
                if (NewPartMachineId == null)
                {
                    this.NewPart = new Outsourced(Convert.ToInt32(NewPartId), NewPartName, Convert.ToInt32(NewPartPrice), Convert.ToInt32(NewPartStock),
                        Convert.ToInt32(NewPartMin), Convert.ToInt32(NewPartMax), NewPartVendor);
                }
                else
                {
                    this.NewPart = new InHouse(Convert.ToInt32(NewPartId), NewPartName, Convert.ToDouble(NewPartPrice), Convert.ToInt32(NewPartStock),
                        Convert.ToInt32(NewPartMin), Convert.ToInt32(NewPartMax), Convert.ToInt32(NewPartMachineId));
                }

                AllParts.Add(NewPart);
            }
            catch (Exception) 
            {
                // i don't think this is reachable with the error validation in place, but here for good measure
                MessageBoxResult alert = MessageBox.Show("Please enter a value into each text box");
                return;
            }

            //nullify all NewPart variables
            NewPartId = null;
            NewPartName = null;
            NewPartPrice = null;
            NewPartStock = null;
            NewPartMin = null;
            NewPartMax = null;
            NewPartMachineId = null;
            NewPartVendor = null;

            Serialize();

            //returns current view to the main window
            CurrentView = new MainWindowView();
        }

        public RelayCommand HandleModifyPart
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnModifyPart);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnModifyPart()
        {
            if (SelectedPart is null)
            {
                MessageBoxResult alert = MessageBox.Show("Please select a part");
                return;
            }
            CurrentView = new ModifyPart();
        }

        public RelayCommand HandleSaveModifyPart
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnSaveModifyPart);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void OnSaveModifyPart()
        {
            //each variable will update automatically as the text box is changed. clicking cancel will roll back any changes by re-loading the last saved state

            //asks user for confirmation to commit changes
            
            if (MessageBox.Show("Do you want to save these changes?",
               "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                // end function to prevent save, keeps window open
                return;
            }

            // changes saved, return to main screen
            Serialize();
            CurrentView = new MainWindowView();
        }
        public RelayCommand HandleSerialize
        {
            get
            {
                RelayCommand command = new RelayCommand(this.Serialize);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void Serialize()
        {
            
            
                BinaryFormatter formatter;
                StreamWriter stream = new StreamWriter("inventory.bin");
                formatter = new BinaryFormatter();

                formatter.Serialize(stream.BaseStream, AllParts);
                stream.Close();
            
            
        }

        public RelayCommand HandleDeserialize
        {
            get
            {
                RelayCommand command = new RelayCommand(this.DeSerialize);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }

        public void DeSerialize()
        {
            StreamReader stream = new StreamReader("inventory.bin");
            var formatter = new BinaryFormatter();

            AllParts = (ObservableCollection<Part>)formatter.Deserialize(stream.BaseStream);
            stream.Close();
        }
        public void OnSearch()
        {    //empty display list
            DisplayParts.Clear();

            //if search string is found in a part name, adds that part to the display list
            foreach (Part p in AllParts)
            {
                if (p.Name.Contains(searchString))
                {
                    DisplayParts.Add(p);
                }

                
            }
        }

        public RelayCommand HandleSearch
        {
            get
            {
                RelayCommand command = new RelayCommand(this.OnSearch);
                return command;
            }
            set
            {
                RelayCommand command = value;
            }
        }


    }
    

}

