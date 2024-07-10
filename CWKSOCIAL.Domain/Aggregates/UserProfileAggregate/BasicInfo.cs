using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWKSOCIAL.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfo
    {
        private BasicInfo()
        {            
        }

        public static BasicInfo CreateBasicInfo(string firstName, string lastName, string emailAddress, string phone, DateTime dob, string currentCity)
        {
            // TODO: Add validation, error handling strategies, error notification strategies

            return new BasicInfo
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Phone = phone,
                DateOfBirth = dob,
                CurrentCity = currentCity
            };
        }


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone {  get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CurrentCity { get; private set; }
    }
}
