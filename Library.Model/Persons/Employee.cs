﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{/// <summary>
/// class overides from <see cref="Person"/> and represents employee
/// </summary>
    public class Employee : Person
    {
        private string _login;
        /// <summary>
        /// represents login of castomer that automaticly srt password in <see cref="Library.Model.Employee.EmployeeLogins"/>
        /// </summary>
        public string Login
        {
            get
            {
                return _login;
            } 

            set
            {
                _login = value;
            }
        }
        /// <summary>
        /// represents password of Employee account
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// This parametr givs access to get menenger page or employee page
        /// </summary>
        public bool IsMananger { get; private set; }

      
        public Employee(string Fname,string Lname, int phonenumber,string login,string password, bool isMananger) : base(Fname,Lname, phonenumber)
        {
            _login = login;
            Password = password;
            IsMananger = isMananger;
        }

        public override string ToString()
        {
            if(IsMananger == false)
            {
                return $"Firs name: {FName}. \nLast name: {LName}.\nPhone number:{PhoneNumber}.\nRole: Regular Employee.";
            }
            else
            {
                return $"Firs name: {FName}. \nLast name: {LName}.\nPhone number:{PhoneNumber}.\nRole: Menenger.";
            }

        }
    }
    
}
