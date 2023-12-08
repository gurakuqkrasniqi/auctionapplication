using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Business
{
    public static class Check
    {
        public static T IsNotNull<T>(T dependency)
            where T : class
        {
            return dependency ?? throw new ArgumentNullException($"{dependency} is null!");
        }

        public static void IsNotNull(object parameterValue, string parameterName)
        {
            if (parameterValue == null)
            {
                throw new ArgumentNullException($"{parameterName} is null!");
            }
        }

        public static void IsNotEmpty(string parameterValue, string parameterName)
        {
            if (parameterValue == null)
            {
                throw new ArgumentNullException($"{parameterName} is null!");
            }

            if (string.IsNullOrWhiteSpace(parameterValue))
            {
                throw new ArgumentException($"{parameterName} is empty!");
            }
        }
    }
}
