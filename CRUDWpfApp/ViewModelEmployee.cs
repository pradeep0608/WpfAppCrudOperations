using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRUDWpfApp
{
    public class ViewModelEmployee : INotifyPropertyChanged
    {

        private ModelEmployee m_modelEmployee;

        private ObservableCollection<ModelEmployee> m_modelEmployees;
        public ObservableCollection<ModelEmployee> EmployessCollection
        {
            get
            {
                return this.m_modelEmployees;
            }
                
            set
            {
                if(this.m_modelEmployees != value)
                {
                    this.m_modelEmployees = value;
                    this.RaisePropertyChanged("EmployessCollection");
                }
            }
        }

        public ICommand AddEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public ICommand UpdateEmployeeCommand { get; set; }

        public ViewModelEmployee()
        {
            this.EmployessCollection = new ObservableCollection<ModelEmployee>();

            this.EmployessCollection.Add(new ModelEmployee() { EmployeeName = "Employee 1" ,EmployeeAddress = "Employee Address 1",EmployeeId ="1"});
            this.EmployessCollection.Add(new ModelEmployee() { EmployeeName = "Employee 2", EmployeeAddress = "Employee Address 2", EmployeeId = "2" });
            this.EmployessCollection.Add(new ModelEmployee() { EmployeeName = "Employee 3", EmployeeAddress = "Employee Address 3", EmployeeId = "3" });
            
            AddEmployeeCommand = new RelayCommand(this.AddEmployeeToCollection);
            DeleteEmployeeCommand = new RelayCommand(this.DeleteEmployeeInCollection);
            UpdateEmployeeCommand = new RelayCommand(this.UpdateEmployeeToCollection);


        }

        public ModelEmployee SelectedEmployee
        {
            get
            {
                return this.m_modelEmployee;
            }

            set
            {
                if(this.m_modelEmployee != value)
                {
                    this.m_modelEmployee = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddEmployeeToCollection(object employee)
        {
            ModelEmployee model = employee as ModelEmployee;
            string employeeCountString = (this.EmployessCollection.Count+1).ToString();
            this.EmployessCollection.Add(new ModelEmployee() { EmployeeName = " New Employee" + employeeCountString, EmployeeAddress = "New Employee Address"+ employeeCountString, EmployeeId = "New Employee Number" + employeeCountString });
        }

        private void UpdateEmployeeToCollection(object employee)
        {
            if (this.SelectedEmployee != null)
            {
                foreach (var model in this.m_modelEmployees)
                {
                    if (model.EmployeeName == this.SelectedEmployee.EmployeeName)
                    {
                        model.EmployeeName = "Updated Name" + (this.EmployessCollection.Count + 1).ToString(); 
                        model.EmployeeAddress = "Updated Addreess" + (this.EmployessCollection.Count + 1).ToString();
                        model.EmployeeId = "Updated Id" + (this.EmployessCollection.Count + 1).ToString();
                        break;
                    }
                }
                this.RaisePropertyChanged("EmployessCollection");
            }
        }

        private void DeleteEmployeeInCollection(object employee)
        {
            this.EmployessCollection.Remove(this.SelectedEmployee);
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
