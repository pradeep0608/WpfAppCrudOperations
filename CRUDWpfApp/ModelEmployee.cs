using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWpfApp
{
    public class ModelEmployee : INotifyPropertyChanged
    {
        private string m_employeeName;
        private string m_employeeAddress;
        private string m_employeeId;
        public string EmployeeName
        {
            get
            {
                return m_employeeName;
            }
            set
            {
                if(this.m_employeeName != value)
                {
                    this.m_employeeName = value;
                    this.RaisePropertyChanged(nameof(this.EmployeeName));
                }
            }
        }

        public string EmployeeAddress {
            get
            {
                return m_employeeAddress;
            }

            set
            {
                if(m_employeeAddress != value)
                {
                    this.m_employeeAddress = value;
                    this.RaisePropertyChanged(nameof(this.EmployeeAddress));
                }
            }
        }
        public string EmployeeId {
            get
            {
                return m_employeeId;
            }

            set
            {
                if(this.m_employeeId != value)
                {
                    this.m_employeeId = value;
                    this.RaisePropertyChanged(nameof(this.EmployeeId));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
