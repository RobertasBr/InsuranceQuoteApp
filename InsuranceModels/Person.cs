using static InsuranceModels.InsuranceService;

namespace InsuranceModels
{
    public class InsuranceService
    {
        public int Age { get; set; }
        public string Location { get; set; }

        public interface IInsuranceService
        {
            int GetDiscount();
        }

        private readonly IInsuranceService _insuranceService;

        public InsuranceService(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        public InsuranceService()
        {
            // Initialize _insuranceService with a default implementation or null
            // _insuranceService = new DefaultInsuranceService(); // if you have a default implementation
        }

        public double CalculateQuote(int age, string location)
        {
            double premium;

            if (location == "rural")
            {
                if ((age >= 18) && (age < 30))
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
                else
                    premium = 0.0;
            }
            else if (location == "urban")
            {
                if ((age >= 18) && (age <= 35))
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
                else
                    premium = 0.0;
            }
            else
            {
                premium = 0.0;
            }

            double discount = _insuranceService?.GetDiscount() ?? 0;

            if (age >= 50)
                premium *= 1 - (discount / 100);

            return premium;
        }
    }
}
