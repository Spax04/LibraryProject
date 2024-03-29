﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// class representing Jornal handled by the library
    /// </summary>
    public class Jornal : LibraryItem
    {
        private double _dicount;
        public double Discount {
            get 
            {
                return _dicount; 
            }
            set 
            {
                if(value < 99 && value > 0) 
                { 
                    _dicount = value;
                }
                else
                {
                    _dicount = 0;
                }
            }
        }
        private double _price;
        public double Price 
        { 
            get
            {
                return _price; 
            } 
            set 
            { 
                if(value > 0)
                {
                    _price = value;
                }else
                _price = 0;
            } 
        }
        /// <summary>
        /// list of jornal ganers
        /// </summary>
        public static List<string> JornalGaners = new List<string>();

        /// <summary>
        /// list of  Contibuters for spicific jornal
        /// </summary>
        public string Contributers { get;  set; }

        /// <summary>
        /// list of  editors for spicific jornal
        /// </summary>
        public string Editors { get; set; }

        /// <summary>
        /// enum that meins how offen jornal coming out
        /// </summary>
        public JornalFrequency Frequency { get; set; }
        public int SerialNumber { get; set; }

        /// <summary>
        /// list of  ganers for spicific jornal
        /// </summary>
        public string Ganers { get;  set; }

        /// <summary>
        /// 
        /// </summary>
        public double GettingDiscountPrice()
        {
           Price = Price * (Discount / 100);
            return Price;
        }

       


        public Jornal(string title, DateTime publishDate, double price,  int serialnumber ,JornalFrequency jf = JornalFrequency.Other) : base(title, publishDate)
        {
            _price = price;
            Frequency = jf;
            SerialNumber = serialnumber;
            
        }

        public override string ToString()
        {
            if(Discount > 0)
            {
                return $"'{Title}' | {PublishDate:D} | {Ganers} | {Editors} | {Frequency} | {Contributers} | {GettingDiscountPrice():C} | {Discount}% ";
            }
            else
            {
                return $"'{Title}' | {PublishDate:D} | {Ganers} | {Editors} | {Frequency} | {Contributers} | {Price:C}";
            }
        }
        /// <summary>
        /// represents ditales about jornal
        /// </summary>
        public override string Ditales()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Jornal information:");
            sb.AppendLine($"Jornal title: {Title}");
            sb.AppendLine($"Publish date: {PublishDate}");
            sb.AppendLine($"Jornal Gener: {Ganers}");
            sb.AppendLine($"Editor: {Editors}");
            sb.AppendLine($"Contributer: {Contributers}");
            if(Discount > 0)
            {
                sb.AppendLine($"Sele price {GettingDiscountPrice():C}. Discont {Discount}% ");
                sb.AppendLine($"Price before sele{Price:C}");
            }
            else
            {
                sb.AppendLine($"Price: {Price:C}");
            }
            sb.AppendLine($"Jornal in stock.");
            return sb.ToString();
        }



        /// <summary>
        /// frequency of jornal publishing
        /// </summary>
        public enum JornalFrequency
        {
            Daily,
            Weekly,
            BiWeekly,
            Monthly,
            BiMonthly,
            Qurterly,
            SemiAnnualy,
            Annualy,
            BiAnnualy,
            Other
        }
    }
}
