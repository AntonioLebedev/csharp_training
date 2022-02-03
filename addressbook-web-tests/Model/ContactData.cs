using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string allInformation;
        public string fullNameNicknamesection;
        public string titleCompanyAddresssection;
        public string phonesSection;
        public string emailHomepageSection;
        public string birthdayAnniversarysection;
        public string secondaryBlock;

        public ContactData()
        {


        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
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
            return "Firstname=" + Firstname + "\nMiddlename= " + Middlename + "\nLastname= " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Firstname != other.Firstname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return 0;
        }

        [Column(Name = "firstname")]

        public string Firstname { get; set; }

        [Column(Name = "middlename")]

        public string Middlename { get; set; }

        [Column(Name = "lastname")]

        public string Lastname { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]

        public string Id { get; set; }

        [Column(Name = "nickname")]

        public string Nickname { get; set; }

        [Column(Name = "title")]

        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]

        public string Address { get; set; }

        [Column(Name = "home")]

        public string HomePhone { get; set; }

        [Column(Name = "mobile")]

        public string MobilePhone { get; set; }

        [Column(Name = "work")]

        public string WorkPhone { get; set; }

        [Column(Name = "fax")]

        public string Fax { get; set; }

        [Column(Name = "email")]

        public string Email { get; set; }

        [Column(Name = "email2")]

        public string Email2 { get; set; }

        [Column(Name = "email3")]

        public string Email3 { get; set; }

        [Column(Name = "homepage")]

        public string Homepage { get; set; }

        [Column(Name = "bday")]

        public string BDay { get; set; }

        [Column(Name = "bmonth")]

        public string BMonth { get; set; }

        [Column(Name = "byear")]

        public string BYear { get; set; }

        [Column(Name = "aday")]

        public string ADay { get; set; }

        [Column(Name = "amonth")]

        public string AMonth { get; set; }

        [Column(Name = "ayear")]

        public string AYear { get; set; }

        [Column(Name = "address2")]

        public string Address2 { get; set; }

        [Column(Name = "phone2")]

        public string Phone2 { get; set; }

        [Column(Name = "notes")]

        public string Notes { get; set; }

        public static List<ContactData> GetAllContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }

        }

        public string GetAge(string day, string month, string year, string fieldName)
        {
            if (day == null) return null;

            int monthNumber = 0;
            int Age;
            switch (month)
            {
                case "January":
                    monthNumber = 1;
                    break;
                case "February":
                    monthNumber = 2;

                    break;
                case "March":
                    monthNumber = 3;

                    break;
                case "April":
                    monthNumber = 4;

                    break;
                case "May":
                    monthNumber = 5;

                    break;
                case "June":
                    monthNumber = 6;

                    break;
                case "July":
                    monthNumber = 7;

                    break;
                case "August":
                    monthNumber = 8;

                    break;
                case "September":
                    monthNumber = 9;

                    break;
                case "October":
                    monthNumber = 10;

                    break;
                case "November":
                    monthNumber = 11;

                    break;
                case "December":
                    monthNumber = 12;

                    break;
            }
            if (year != "")
            {
                if ((DateTime.Now.Month >= monthNumber) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }

        public string GetAnniversary(string day, string month, string year, string fieldName)
        {
            if (day == null) return null;

            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != null && year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }


        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (ReturnDetailswithRN(Email) + ReturnDetailswithRN(Email2) + ReturnDetailswithRN(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }


        [Newtonsoft.Json.JsonIgnore]
        public string AllInformation
        {
            get
            {
                string fullNameBlock = FullNameNicknamesection;
                string titleBlock = TitleCompanyAddresssection;
                string phoneBlock = PhonesSection;
                string emailBlock = EmailHomepageSection;
                string dateBlock = BirthdayAnniversarysection;
                string secondaryBlock = SecondarySection;
                string allInformation2 = "";



                if (allInformation != null)
                {
                    return allInformation = "";
                }
                else
                {
                    if (fullNameBlock != "")
                    {
                        allInformation2 = fullNameBlock;
                    }
                    if (titleBlock != "")
                    {
                        if (allInformation2 != "")
                        {
                            allInformation2 += ReturnDetailswithRNabove(titleBlock);
                        }
                        else
                        {
                            allInformation2 = titleBlock;
                        }
                    }
                    if (phoneBlock != "")
                    {
                        if (allInformation2 != "")
                        {
                            allInformation2 += ReturnDetailswithRNRNabove(phoneBlock);
                        }
                        else
                        {
                            allInformation2 = phoneBlock;
                        }
                    }
                    if (emailBlock != "")
                    {
                        if (allInformation2 != "")
                        {
                            allInformation2 += ReturnDetailswithRNRNabove(emailBlock);
                        }
                        else
                        {
                            allInformation2 = emailBlock;
                        }
                    }
                    if (dateBlock != null && dateBlock != "")
                    {
                        if (allInformation2 != "")
                        {
                            allInformation2 += ReturnDetailswithRNRNabove(dateBlock);
                        }
                        else
                        {
                            allInformation2 = dateBlock;
                        }
                    }
                    else
                        if (secondaryBlock != "" && secondaryBlock != "P:")
                    {
                        allInformation2 += "\r\n";

                    }
                    if (secondaryBlock != "")
                    {
                        if (allInformation2 != "")
                        {
                            allInformation2 += ReturnDetailswithRNRNabove(secondaryBlock);
                        }
                        else
                        {
                            allInformation2 = secondaryBlock;
                        }
                    }
                }
                return allInformation2.Trim();
            }
            set
            {
                allInformation = value;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public string FullNameNicknamesection
        {
            get
            {
                string fullNameNicknamesection = "";
                string fullName = ReturnFullName(Firstname.Trim(), Middlename.Trim(), Lastname.Trim());
                if (fullName != null && fullName != "")
                {
                    fullNameNicknamesection = fullName.Trim();
                }
                if (Nickname != null && Nickname != "")
                {
                    if (fullNameNicknamesection != null && fullNameNicknamesection != "")
                    {
                        fullNameNicknamesection += "\r\n" + Nickname.Trim();
                    }
                    else
                    {
                        fullNameNicknamesection = Nickname.Trim();
                    }
                }

                return fullNameNicknamesection;
            }
            set
            {
                fullNameNicknamesection = value;
            }
        }

        public string TitleCompanyAddresssection
        {
            get
            {
                string titleCompanyAddresssection = "";
                if (Title != null && Title != "")
                {
                    titleCompanyAddresssection = Title.Trim();
                }
                if (Company != null && Company != "")
                {
                    if (titleCompanyAddresssection != null && titleCompanyAddresssection != "")
                    {
                        titleCompanyAddresssection += "\r\n" + Company.Trim();
                    }
                    else
                    {
                        titleCompanyAddresssection = Company.Trim();
                    }
                }
                if (Address != null && Address != "")
                {
                    if (titleCompanyAddresssection != null && titleCompanyAddresssection != "")
                    {
                        titleCompanyAddresssection += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        titleCompanyAddresssection = Address.Trim();
                    }
                }
                return titleCompanyAddresssection;
            }
            set
            {
                titleCompanyAddresssection = value;
            }
        }

        public string PhonesSection
        {
            get
            {
                string phonesSection = "";

                if (HomePhone != null && HomePhone != "")
                {
                    phonesSection = ("H: " + HomePhone.Trim()).Trim();
                }
                if (MobilePhone != null && MobilePhone != "")
                {
                    if (phonesSection != null && phonesSection != "")
                    {
                        phonesSection += "\r\n" + ("M: " + MobilePhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesSection = ("M: " + MobilePhone.Trim()).Trim();
                    }
                }
                if (WorkPhone != null && WorkPhone != "")
                {
                    if (phonesSection != null && phonesSection != "")
                    {
                        phonesSection += "\r\n" + ("W: " + WorkPhone.Trim()).Trim();
                    }
                    else
                    {
                        phonesSection = ("W: " + WorkPhone.Trim()).Trim();
                    }
                }
                if (Fax != null && Fax != "")
                {
                    if (phonesSection != null && phonesSection != "")
                    {
                        phonesSection += "\r\n" + ("F: " + Fax.Trim()).Trim();
                    }
                    else
                    {
                        phonesSection = ("F: " + Fax.Trim()).Trim();
                    }
                }
                return phonesSection;
            }
            set
            {
                phonesSection = value;
            }
        }

        public string EmailHomepageSection
        {
            get
            {
                string emailHomepageSection = "";

                if (Email != null && Email != "")
                {
                    emailHomepageSection = Email;
                }
                if (Email2 != null && Email2 != "")
                {
                    if (emailHomepageSection != null && emailHomepageSection != "")
                    {
                        emailHomepageSection = emailHomepageSection.Trim() + "\r\n" + Email2.Trim();
                    }
                    else
                    {
                        emailHomepageSection = Email2;
                    }
                }
                if (Email3 != null && Email3 != "")
                {
                    if (emailHomepageSection != null && emailHomepageSection != "")
                    {
                        emailHomepageSection = emailHomepageSection + "\r\n" + Email3.Trim();
                    }
                    else
                    {
                        emailHomepageSection = Email3;
                    }
                }
                if (Homepage != null && Homepage != "")
                {
                    if (emailHomepageSection != null && emailHomepageSection != "")
                    {
                        emailHomepageSection = emailHomepageSection + "\r\n" + "Homepage:\r\n" + Homepage.Trim();
                    }
                    else
                    {
                        emailHomepageSection = "Homepage:\r\n" + Homepage.Trim();
                    }
                }
                return emailHomepageSection;
            }
            set
            {
                emailHomepageSection = value;
            }
        }

        public string BirthdayAnniversarysection
        {
            get
            {
                string birthString = GetAge(BDay, BMonth, BYear, "Birthday ");
                string anniverString = GetAnniversary(ADay, AMonth, AYear, "Anniversary ");
                string birthdayAnniversarysection = "";

                if (birthString != null && birthString != "")
                {
                    birthdayAnniversarysection = birthString.Trim();
                }
                if (anniverString != null && anniverString != "")
                {
                    if (birthdayAnniversarysection != null && birthdayAnniversarysection != "")
                    {
                        birthdayAnniversarysection += "\r\n" + anniverString.Trim();
                    }
                    else
                    {
                        birthdayAnniversarysection = anniverString.Trim();
                    }
                }
                return birthdayAnniversarysection;
            }
            set
            {
                birthdayAnniversarysection = value;
            }
        }

        public string SecondarySection
        {
            get
            {
                if (Address2 == null) return null;

                string secondaryBlock = "";
                if (Address2.Trim() != null && Address2.Trim() != "")
                {
                    secondaryBlock = Address2.Trim();
                }
                if (Phone2 != null && Phone2 != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                    else
                    {
                        secondaryBlock = "\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                }
                if (Notes.Trim() != null && Notes.Trim() != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + Notes.Trim();
                    }
                    else
                    {
                        secondaryBlock = Notes.Trim();
                    }
                }
                return secondaryBlock;
            }
            set
            {
                secondaryBlock = value;
            }

        }
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }

        public string ReturnDetailswithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        public string ReturnDetailswithoutRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnDetailswithRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnDetailswithRNRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }

        public string ReturnFullName(string name, string middlename, string lastname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
                if (FullName != "")
                {
                    FullName += " " + middlename;
                }
                else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName;
        }

    }
}