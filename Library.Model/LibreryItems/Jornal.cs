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
        /// <summary>
        /// list of jornal ganers
        /// </summary>
        public static List<string> JornalGaners = new List<string>();

        /// <summary>
        /// list of  Contibuters for spicific jornal
        /// </summary>
        public List<string> Contributers { get; private set; }

        /// <summary>
        /// list of  editors for spicific jornal
        /// </summary>
        public List<string> Editors { get; set; }

        /// <summary>
        /// enum that meins how offen jornal coming out
        /// </summary>
        public JornalFrequency Frequency { get; set; }

        /// <summary>
        /// list of  ganers for spicific jornal
        /// </summary>
        public List<string> Ganers { get; private set; }


        public Jornal(string title, DateTime publishDate) : base(title, publishDate)
        {
            Contributers = new List<string>();
            Editors = new List<string>();
            Ganers = new List<string>();
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
