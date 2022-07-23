﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Customer : Person
    {
        public List<LibraryItem> customerItems;
        public Customer(string Fname,string Lname, int phonenumber) : base(Fname,Lname, phonenumber)
        {
            customerItems = new List<LibraryItem>();

        }

        public string bookCustomerDitales()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Books recorded on {FName} {LName}");
            for(int i = 0; i < customerItems.Count; i++)
            {
                sb.AppendLine($"{i+1}. {customerItems[i].Ditales()}");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"First name: {FName}. Last name: {LName}. Phone number: {PhoneNumber}";
        }
    }
}
