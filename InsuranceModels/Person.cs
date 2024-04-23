using static InsuranceModels.InsuranceService;

namespace InsuranceModels
{
    //public interface IPersonservice
    //{
    //	int GetRate();

    //}
    //public class PersonService : IPersonservice
    //{
    //	public int GetRate()
    //	{
    //		//throw new NotImplementedException();
    //		return 0;
    //	}
    //}

    public class InsuranceService
    {
        public int Age { get; set; }
        public string Location { get; set; }
        // Add more properties as required
        public interface IInsuranceService
        {
            int GetDiscount();
        }
        private readonly IInsuranceService _insuranceService;
        public InsuranceService(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        // Assume CalculateQuote is a method that takes age and location and returns a quote

        public double CalculateQuote(int age, string location)
        {

            // Your calculation logic here, can use properties as view linked directly to model

            double premium;

            //a
            if (location == "rural")
                //b
                if ((age >= 18) && (age < 30))
                    premium = 5.0;
                //c
                else
                    //c1
                    if (age >= 31)
                    premium = 2.50;
                //d
                else
                    premium = 0.0;
            //e
            else
            //f
            if (location == "urban")
                //g
                if ((age >= 18) && (age <= 35))
                    premium = 6.0;
                //h
                else
                //i
                if (age >= 36)
                    premium = 5.0;

                //j
                else
                    premium = 0.0;
            //k
            else
                premium = 0.0;

            double discount = _insuranceService.GetDiscount();
            //l
            if (age >= 50)
                premium *= 1 - (discount / 100);

            return premium;
        }
    }
}

