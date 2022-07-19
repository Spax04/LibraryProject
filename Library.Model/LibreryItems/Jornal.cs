using System;
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
        public int Discount { get; set; }
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
        public string Contributers { get; private set; }

        /// <summary>
        /// list of  editors for spicific jornal
        /// </summary>
        public string Editors { get; set; }

        /// <summary>
        /// enum that meins how offen jornal coming out
        /// </summary>
        public JornalFrequency Frequency { get; set; }

        /// <summary>
        /// list of  ganers for spicific jornal
        /// </summary>
        public List<string> Ganers { get; private set; }
        public double gettingDiscountPrice()
        {
            double newPrice = 0;
            if(Discount > 0)
            {
                newPrice = Price * (Discount / 100);
            }
            return newPrice;
        }


        public Jornal(string title, DateTime publishDate,double price,int discount = 0) : base(title, publishDate)
        {
            _price = price;
            Discount = discount;
        }

        public override string ToString()
        {
            if(Discount > 0)
            {
                return $"'{Title}' | {PublishDate:D} | {Ganers} | {Editors} | {Contributers} | {gettingDiscountPrice():C} | {Discount}% ";
            }
            else
            {
                return $"'{Title}' | {PublishDate:D} | {Ganers} | {Editors} | {Contributers} | {Price:C}";
            }
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
