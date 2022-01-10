using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address1 = "";
        private string homephone = "";
        private string mobilephone = "";
        private string workphone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string note = "";

        public ContactData (string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() & Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return $"contact = {Lastname} {Firstname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (this.Firstname !=  other.Firstname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            if(this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Lastname.CompareTo(other.Lastname) & Firstname.CompareTo(other.Firstname);
        }

        public string Firstname
        {
            get;
            set;
        }
        public string Middlename
        {
            get;
            set;
        }
        public string Lastname
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }
        public string Homephone
        {
            get
            {
                return homephone;
            }
            set
            {
                homephone = value;
            }
        }
        public string Mobilephone
        {
            get
            {
                return mobilephone;
            }
            set
            {
                mobilephone = value;
            }
        }
        public string Workphone
        {
            get
            {
                return workphone;
            }
            set
            {
                workphone = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {

                bday = value;
            }
        }
        public string Bmonth        
        {
            get
            {
                return bmonth;
            }
            set
            {

                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {

                byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {

                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {

                amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {

                ayear = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {

                address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {

                phone2 = value;
            }
        }
        public string Note
        {
            get
            {
                return note;
            }
            set
            {

                note = value;
            }
        }
    }
}
