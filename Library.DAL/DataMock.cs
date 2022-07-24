using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class DataMock 
    {
        private static DataMock _instens;
        public static DataMock Instens
        {
            get
            {
                if( _instens == null)
                {
                   _instens = new DataMock();
                }
                return _instens;
            }
        }
        public List <LibraryItem> LibraryItemsList { get; private set; }
       
        public List <Person> PersonList { get; private set; }
        public Dictionary <string, Employee> EmployLogins { get; private set; }
        private DataMock()
        {
            LibraryItemsList = new List<LibraryItem>();
            PersonList = new List<Person>();
            EmployLogins = new Dictionary<string, Employee>();
            Init();
        }

        /*public List<LibraryItem> searhingBookInList(string word)
        {
            List<LibraryItem> list = new List<LibraryItem>();
            for(int i = 0; i < LibraryItemsList.Count; i++)
            {
                Book b1 = LibraryItemsList[i] as Book;
                if(b1 != null)
                {
                    if (b1.Discription.Contains(word))
                    {
                        list.Add(LibraryItemsList[i]);
                    }
                }
            }
            return list;
        }*/

        public void Init()
        {
            ISBN.Countries = new Dictionary<string, int>();
            ISBN.Publishers = new Dictionary<string, int>();
            #region Countries ISBN

            ISBN.Countries.Add("English", 0);
            ISBN.Countries.Add("French", 2);
            ISBN.Countries.Add("German", 3);
            ISBN.Countries.Add("Japanese", 4);
            ISBN.Countries.Add("Russian ", 5);
            ISBN.Countries.Add("Iran", 600);
            ISBN.Countries.Add("Kazakhstan", 601);
            ISBN.Countries.Add("Indonesia", 602);
            ISBN.Countries.Add("Saudi Arabia", 603);
            ISBN.Countries.Add("Vietnam", 604);
            ISBN.Countries.Add("Turkey", 605);
            ISBN.Countries.Add("Romania", 606);
            ISBN.Countries.Add("Mexico", 607);
            ISBN.Countries.Add("Macedonia", 608);
            ISBN.Countries.Add("Lithuania", 609);
            ISBN.Countries.Add("Thailand", 611);
            ISBN.Countries.Add("Peru", 612);
            ISBN.Countries.Add("Mauritius", 613);
            ISBN.Countries.Add("Lebanon", 614);
            ISBN.Countries.Add("Hungary", 615);
            ISBN.Countries.Add("Ukraine", 617);
            ISBN.Countries.Add("Greece", 618);
            ISBN.Countries.Add("Bulgaria", 619);
            ISBN.Countries.Add("Philippines", 621);
            ISBN.Countries.Add("People's Republic of China", 7);
            ISBN.Countries.Add("Former Czechoslovakia", 80);
            ISBN.Countries.Add("If", 81);
            ISBN.Countries.Add("Norway", 82);
            ISBN.Countries.Add("Poland", 83);
            ISBN.Countries.Add("Spain", 84);
            ISBN.Countries.Add("Brazil", 85);
            ISBN.Countries.Add("Former Yugoslavia", 86);
            ISBN.Countries.Add("Denmark", 87);
            ISBN.Countries.Add("Italy", 88);
            ISBN.Countries.Add("South Korea", 89);
            ISBN.Countries.Add("Netherlands", 90);
            ISBN.Countries.Add("Sweden", 91);
            ISBN.Countries.Add("International Publishers", 92);
            ISBN.Countries.Add("Argentina", 950);
            ISBN.Countries.Add("Finland", 951);
            ISBN.Countries.Add("Croatia", 953);
            ISBN.Countries.Add("Sri Lanka", 955);
            ISBN.Countries.Add("Chile", 956);
            ISBN.Countries.Add("Taiwan", 957);
            ISBN.Countries.Add("Colombia", 958);
            ISBN.Countries.Add("Cuba", 959);
            ISBN.Countries.Add("Slovenia", 961);
            ISBN.Countries.Add("Hongkong", 962);
            ISBN.Countries.Add("Israel", 965);
            ISBN.Countries.Add("Malaysia", 967);
            ISBN.Countries.Add("Pakistan", 969);
            ISBN.Countries.Add("Portugal", 972);
            ISBN.Countries.Add("Caribbean Community", 976);
            ISBN.Countries.Add("Egypt", 977);
            ISBN.Countries.Add("Nigeria", 978);
            ISBN.Countries.Add("Venezuela", 980);
            ISBN.Countries.Add("Singapore", 981);
            ISBN.Countries.Add("South Pacific", 982);
            ISBN.Countries.Add("Bangladesh", 984);
            ISBN.Countries.Add("Belarus", 985);
            ISBN.Countries.Add("Bosnia and Herzegovina", 9926);
            ISBN.Countries.Add("Qatar", 9927);
            ISBN.Countries.Add("Albania", 9928);
            ISBN.Countries.Add("Guatemala", 9929);
            ISBN.Countries.Add("Costa Rica", 9930);
            ISBN.Countries.Add("Algeria", 9931);
            ISBN.Countries.Add("Laos", 9932);
            ISBN.Countries.Add("Syria", 9933);
            ISBN.Countries.Add("Latvia", 9934);
            ISBN.Countries.Add("Island", 9935);
            ISBN.Countries.Add("Afghanistan", 9936);
            ISBN.Countries.Add("Nepal", 9937);
            ISBN.Countries.Add("Tunisia", 9938);
            ISBN.Countries.Add("Armenia", 9939);
            ISBN.Countries.Add("Montenegro", 9940);
            ISBN.Countries.Add("Georgia", 9941);
            ISBN.Countries.Add("Ecuador", 9942);
            ISBN.Countries.Add("Uzbekistan", 9943);
            ISBN.Countries.Add("Dominican Republic", 9945);
            ISBN.Countries.Add("North Korea", 9946);
            ISBN.Countries.Add("Estonia", 9949);
            ISBN.Countries.Add("Palestinian Territories", 9950);
            ISBN.Countries.Add("Kosovo", 9951);
            ISBN.Countries.Add("Azerbaijan", 9952);
            ISBN.Countries.Add("Morocco", 9954);
            ISBN.Countries.Add("Cameroon", 9956);
            ISBN.Countries.Add("Jordan", 9957);
            ISBN.Countries.Add("Libya", 9959);
            ISBN.Countries.Add("Panama", 9962);
            ISBN.Countries.Add("Cyprus", 9963);
            ISBN.Countries.Add("Ghana", 9964);
            ISBN.Countries.Add("Kenya", 9966);
            ISBN.Countries.Add("Kyrgyzstan", 9967);
            ISBN.Countries.Add("Uganda", 9970);
            ISBN.Countries.Add("Uruguay", 9974);
            ISBN.Countries.Add("Republic of Moldova", 9975);
            ISBN.Countries.Add("Tanzania", 9976);
            ISBN.Countries.Add("Papua New Guinea", 9980);
            ISBN.Countries.Add("Zambia", 9982);
            ISBN.Countries.Add("Gambia", 9983);
            ISBN.Countries.Add("Bahrain", 99901);
            ISBN.Countries.Add("Gabon", 99902);
            ISBN.Countries.Add("Netherlands Antilles(Curaçao)", 99904);
            ISBN.Countries.Add("Bolivia", 99905);
            ISBN.Countries.Add("Kuwait", 99906);
            ISBN.Countries.Add("Malawi", 99908);
            ISBN.Countries.Add("Malta", 99909);
            ISBN.Countries.Add("Sierra Leone", 99910);
            ISBN.Countries.Add("Lesotho", 99911);
            ISBN.Countries.Add("Botswana", 99912);
            ISBN.Countries.Add("Andorra", 99913);
            ISBN.Countries.Add("Suriname", 99914);
            ISBN.Countries.Add("Maldives", 99915);
            ISBN.Countries.Add("Namibia", 99916);
            ISBN.Countries.Add("Brunei", 99917);
            ISBN.Countries.Add("Faroe Islands", 99918);
            ISBN.Countries.Add("Benin", 99919);
            ISBN.Countries.Add("El Salvador", 99923);
            ISBN.Countries.Add("Nicaragua", 99924);
            ISBN.Countries.Add("Paraguay", 99925);
            ISBN.Countries.Add("Honduras", 99926);
            ISBN.Countries.Add("Mongolia", 99929);
            ISBN.Countries.Add("Seychelles", 99931);
            ISBN.Countries.Add("Haiti", 99935);
            ISBN.Countries.Add("Bhutan", 99936);
            ISBN.Countries.Add("Macau", 99937);
            ISBN.Countries.Add("Republika Srpska", 99938);
            ISBN.Countries.Add("Sudan", 99942);
            ISBN.Countries.Add("Ethiopia", 99944);
            ISBN.Countries.Add("Tajikistan", 99947);
            ISBN.Countries.Add("Eritrea", 99948);
            ISBN.Countries.Add("Cambodia", 99950);
            ISBN.Countries.Add("Democratic Republic of the Congo", 99951);
            ISBN.Countries.Add("Mali", 99952);
            ISBN.Countries.Add("Luxembourg", 99959);
            ISBN.Countries.Add("Oman", 99969);
            ISBN.Countries.Add("Myanmar", 99971);
            ISBN.Countries.Add("Rwanda", 99977);
            #endregion

            ISBN.Publishers.Add("Pyramid Books", 01);
            ISBN.Publishers.Add("Berkley Publishing", 02);
            ISBN.Publishers.Add("Popular Library", 03);
            ISBN.Publishers.Add("DAW Books", 04);
            ISBN.Publishers.Add("Celestial Publications", 05);
            ISBN.Publishers.Add("Scholastic Books", 06);
            ISBN.Publishers.Add("Tundra Books", 07);
            ISBN.Publishers.Add("Penguin english library", 22);

            #region Book Genres
            Book.BookGenres.Add("Action and adventure");
            Book.BookGenres.Add("Art / architecture");
            Book.BookGenres.Add("Alternate history");
            Book.BookGenres.Add("Autobiography");
            Book.BookGenres.Add("Anthology");
            Book.BookGenres.Add("Biography");
            Book.BookGenres.Add("Chick lit");
            Book.BookGenres.Add("Business / economics");
            Book.BookGenres.Add("Children's");
            Book.BookGenres.Add("Crafts / hobbies");
            Book.BookGenres.Add("Classic");
            Book.BookGenres.Add("Cookbook");
            Book.BookGenres.Add("Comic book");
            Book.BookGenres.Add("Diary");
            Book.BookGenres.Add("Coming-of-age");
            Book.BookGenres.Add("Dictionary");
            Book.BookGenres.Add("Crime");
            Book.BookGenres.Add("Encyclopedia");
            Book.BookGenres.Add("Drama");
            Book.BookGenres.Add("Guide");
            Book.BookGenres.Add("Fairytale");
            Book.BookGenres.Add("Health / fitness");
            Book.BookGenres.Add("Fantasy");
            Book.BookGenres.Add("History");
            Book.BookGenres.Add("Graphic novel");
            Book.BookGenres.Add("Home and garden");
            Book.BookGenres.Add("Historical fiction");
            Book.BookGenres.Add("Humor");
            Book.BookGenres.Add("Horror");
            Book.BookGenres.Add("Journal");
            Book.BookGenres.Add("Mystery");
            Book.BookGenres.Add("Math");
            Book.BookGenres.Add("Paranormal romance");
            Book.BookGenres.Add("Memoir");
            Book.BookGenres.Add("Picture book");
            Book.BookGenres.Add("Philosophy");
            Book.BookGenres.Add("Poetry");
            Book.BookGenres.Add("Prayer");
            Book.BookGenres.Add("Political thriller");
            Book.BookGenres.Add("Religion, spirituality, and new age");
            Book.BookGenres.Add("Romance");
            Book.BookGenres.Add("Textbook");
            Book.BookGenres.Add("Satire");
            Book.BookGenres.Add("True crime");
            Book.BookGenres.Add("Science fiction");
            Book.BookGenres.Add("Review");
            Book.BookGenres.Add("Short story");
            Book.BookGenres.Add("Science");
            Book.BookGenres.Add("Suspense");
            Book.BookGenres.Add("Self help");
            Book.BookGenres.Add("Thriller");
            Book.BookGenres.Add("Sports and leisure");
            Book.BookGenres.Add("Western");
            Book.BookGenres.Add("Travel");
            Book.BookGenres.Add("Young adult");
            Book.BookGenres.Add("True crime");
            Book.BookGenres.Add("War");
            #endregion

            Jornal.JornalGaners.Add("Informational");
            Jornal.JornalGaners.Add("Analitical");
            Jornal.JornalGaners.Add("artistic and journalistic");
            Jornal.JornalGaners.Add("Internet");
            Jornal.JornalGaners.Add("Men's");
            Jornal.JornalGaners.Add("Science");
            Jornal.JornalGaners.Add("Literary");
            Jornal.JornalGaners.Add("Industrial and practical");
            Jornal.JornalGaners.Add("Socio-political");
            Jornal.JornalGaners.Add("Popular science");


            // Books
            Book book1 = new Book("War and Piese", new DateTime(1864,1,1), "Scholastic Books", 123321, "Ukraine");
            book1.Genres = "War";
            book1.Authors.Add("L.N. Tolstoy");
            LibraryItemsList.Add(book1);
            Book book2 = new Book("Crime and punishment", new DateTime(1887, 4, 9), "DAW Books", 551231, "Eritrea");
            book2.Genres = "Crime";
            book2.Authors.Add("F.M. Dostoevsky");
            LibraryItemsList.Add(book2);
            //Jornals
            Jornal jornal1 = new Jornal("Hacker",new DateTime(2022,2,2),1.30,12312500);
            jornal1.Editors = "MegaMind";
            jornal1.Contributers = "Stepan Corkin";
            jornal1.Ganers = "Informational";
            jornal1.Frequency = Jornal.JornalFrequency.BiWeekly;
            LibraryItemsList.Add(jornal1);
            Jornal jornal2 = new Jornal("Universe", new DateTime(2020, 4, 12), 2.30, 122300500);
            jornal2.Editors = "Aladin";
            jornal2.Contributers = "Anton Mehecko";
            jornal2.Ganers = "Science";
            jornal2.Frequency = Jornal.JornalFrequency.Weekly;
            LibraryItemsList.Add(jornal2);
            Jornal jornal3 = new Jornal("Maxim", new DateTime(2020, 8, 30), 1.60, 12277050);
            jornal3.Editors = "Roxan";
            jornal3.Contributers = "Sara Manchon";
            jornal3.Ganers = "Men's";
            jornal3.Frequency = Jornal.JornalFrequency.Annualy;
            LibraryItemsList.Add(jornal3);
            //Employee
            Employee em1 = new Employee("Alex", "Gotlib", 00222002, "admin", "password", true);
            Employee m2 = new Employee("Sara", "Simon",0450512, "sara", "sara", false);
            EmployLogins.Add(em1.Login,em1);
            EmployLogins.Add(m2.Login,m2);
            PersonList.Add(em1);
            PersonList.Add(m2);
            //Customer
            Customer c1 = new Customer("Michael","Hadat",000111222);
            Customer c2 = new Customer("David", "Koko", 215451);
            PersonList.Add(c1);
            PersonList.Add(c2);
        }

        
    }
}
