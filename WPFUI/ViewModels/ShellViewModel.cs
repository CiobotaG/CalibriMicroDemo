using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Tim";
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Time", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
            IsDisabled = true;
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyOfPropertyChange(() => FirstName);
                    CanClearText(value);
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public string FullName
        {
            get { return $"{n} {LastName}"; }
        }
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public void CanClearText(string firstname)
        {
        	if (String.IsNullOrWhiteSpace(firstname))
        	{
        		IsDisabled = false;
        	}
        	else
        	{
                IsDisabled = true;
            }
        }

        public int n = 0;
        public bool CanAsdf()
        {
            return !String.IsNullOrWhiteSpace(LastName);
        }

        public void Asdf()
        {
            FirstName = "";
            LastName = "";
        }

        private bool _CanClearText;
        public bool IsDisabled
        {
            get { return _CanClearText; }
            set
            {  _CanClearText = value;   
                NotifyOfPropertyChange(() => IsDisabled);
            }
        }

        public void ClearText(string firstName, string lastName)
        {

            
                
              IsDisabled = false;
                FirstName = "";
                LastName = "";
            

            NotifyOfPropertyChange(() => IsDisabled);
        }
         
        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
}
