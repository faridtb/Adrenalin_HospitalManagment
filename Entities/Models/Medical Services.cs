using System.Collections.Generic;

namespace Entities.Models
{
    public class Medical_Services : Services
    {
        public int ServiceFee { get; set; }

        public override string ToString()
        {
            return $"Service ID:{profID}\n" +
                $"Service name:{Name}\n" +
                $"Service price:{ServiceFee}\n" +
                $"--------------";

        }
    }
}
