using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Person
/// </summary>
namespace rpcwc.vo.directory
{
    public class Person : RPCVO
    {
        private String _firstName;
        private String _lastName;
        private DateTime _birthDate;
        private bool _isMember;
        private IList<Email> _emails;
        private IList<Phone> _phones;

        public String firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public String lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public bool isMember
        {
            get { return _isMember; }
            set { _isMember = value; }
        }
        public IList<Email> emails
        {
            get { return _emails; }
            set { _emails = value; }
        }
        public IList<Phone> phones
        {
            get { return _phones; }
            set { _phones = value; }
        }
    }
}
