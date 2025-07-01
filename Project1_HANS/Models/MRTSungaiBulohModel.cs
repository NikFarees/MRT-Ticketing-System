using System.ComponentModel.DataAnnotations;

namespace Project1_HANS.Models
{
    public class MRTSungaiBulohModel
    {
		// Customer Information
		[Required]
        [Display(Name = "Customer Name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "IC number must be exactly 12 digits.")]
        [Display(Name = "Customer IC (excluded '-')")]
        public string? IC { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Customer Email")]
        public string? Email { get; set; }


        // Ticket Information
        [Display(Name = "Date & Time")]
        public DateTime TicketDateTime
        {
            get
            {
                return DateTime.Now;
            }

            set { }
        }
        [Display(Name = "Date & Time")]
        public DateTime ViewDateTime { get; set; }


        [Display(Name = "Ticket Id")]
        public string? TicketId
        {
            get
            {
                // Tick is to generate random id. 1 sec has million ticks 
                string hexTicks = DateTime.Now.Ticks.ToString("X"); // x = convert to hexadecimal
                return hexTicks.Substring(hexTicks.Length - 15, 9);
            }

            set { }
        }

        [Display(Name = "Ticket Id")]
        public string? ViewId { get; set; }

        [Required]
        [Display(Name = "Start Station")]
        public string? StartStation { get; set; }

        [Required]
        [Display(Name = "End Station")]
        public string? EndStation { get; set; }

        [Required]
        [Display(Name = "Ticket Type")]
        public string? TicketType { get; set; }

        [Required]
        [Display(Name = "Citizen")]
        public int Citizen { get; set; }

        [Required]
        [Display(Name = "Senior Citizen")]
        public int SeniorCitizen { get; set; }

        [Required]
        [Display(Name = "Disable")]
        public int Disable { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int Student { get; set; }


        // Array of Stations
        public string[] Stations { get;  } =
        {
            "Sungai Buloh", "Kampung Selamat", "Kwasa Damansara", "Kwasa Sentral", "Kota Damansara",
            "Surian", "Mutiara Damansara", "Bandar Utama", "Taman Tun Dr Ismail", "Phileo Damansara",
            "Pusat Bandar Damansara", "Semantan", "Muzium Negara", "Pasar Seni", "Merdeka",
            "Bukit Bintang", "Tun Razak Exchange", "Cochrane", "Maluri", "Taman Pertama",
            "Taman Midah", "Taman Mutiara", "Taman Connaught", "Taman Suntex", "Sri Raya",
            "Bandar Tun Hussein Onn", "Batu Sebelas Cheras", "Bukit Dukung", "Sungai Jernih", "Stadium Kajang",
            "Kajang"
        };

        // 2D array of Fares
        public double[][] Fares { get; } =
        {
            // Sungai Buloh
            new double[] { 0.8, 1.2, 1.8, 2, 2.6, 2.7, 3.1, 3.3, 3.2, 3.5, 3.3, 3.4, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.9, 4, 4.1, 4.3, 4.5, 4.6, 4.8, 4.8, 5, 5.3, 5.4, 5.5},

            // Kampung Selamat
            new double[] { 1.2, 0.8, 1.5, 1.8, 2.3, 2.7, 2.8, 3.1, 3.4, 3.3, 3.7, 3.3, 3.7, 3.8, 3.2, 3.3, 3.4, 3.5, 3.6, 3.8, 3.9, 4, 4.2, 4.4, 4.5, 4.6, 4.7, 4.9, 5.2, 5.2, 5.4},

            // Kwasa Damansara
            new double[] { 1.8 , 1.5, 0.8, 1.1, 1.8, 2.1, 2.6, 2.6, 3, 3.2, 3.3, 3.5, 3.4, 3.5, 3.6, 3.7, 3.2, 3.3, 3.4, 3.5, 3.6, 3.8, 3.9, 4.1, 4.3, 4.4, 4.5, 4.6, 4.9, 5, 5.1},

            // Kwasa Sentral
            new double[] { 2, 1.8, 1.1, 0.8, 1.6, 1.9, 2.3, 2.6, 2.8, 3, 3.1, 3.3, 3.8, 3.4, 3.4, 3.6, 3.8, 3.2, 3.3, 3.4, 3.5, 3.7, 3.8, 4, 4.1, 4.3, 4.4, 4.5, 4.8, 4.9, 5},

            // Kota Damansara
            new double[] { 2.6, 2.3, 1.8, 1.6, 0.8, 1.3, 1.8, 2, 2.4, 2.8, 3, 3.2, 3.3, 3.5, 3.6, 3.2, 3.4, 3.6, 3.7, 3.2, 3.2, 3.4, 3.5, 3.7, 3.9, 4, 4.1, 4.3, 4.6, 4.6, 4.8},

            // Surian
            new double[] { 2.7, 2.7, 2.1, 1.9, 1.3, 0.8, 1.3, 1.7, 2, 2.4, 2.7, 2.9,3.1, 3.3, 3.4, 3.6, 3.8, 3.4, 3.5, 3.7, 3.8, 3.2, 3.4, 3.6, 3.7, 3.9, 4, 4.1, 4.4, 4.5, 4.6},

            // Mutiara Damansara
            new double[] { 3.1, 2.8, 2.6, 2.3, 1.8, 1.3, 0.8, 1.3, 1.7, 2, 2.6, 2.8,3.2, 3.4, 3.1, 3.3, 3.5, 3.7, 3.2, 3.5, 3.6, 3.8, 3.2, 3.4, 3.6, 3.7, 3.8, 3.9, 4.2, 4.3, 4.4},

            // Bandar Utama
            new double[] { 3.3, 3.1, 2.6, 2.6, 2.0, 1.7, 1.3, 0.8, 1.3, 1.7, 2.2, 2.5, 2.9, 3.1, 3.2, 3.4, 3.2, 3.4, 3.6, 3.3, 3.4, 3.6, 3.8, 3.3, 3.4, 3.6, 3.6, 3.8, 4.1, 4.2, 4.3},

            // Taman Tun Dr Ismail
            new double[] { 3.2, 3.4, 3.0, 2.8, 2.4, 2.0, 1.7, 1.3, 0.8, 1.2, 1.8, 2.1, 2.8, 2.8, 2.9, 3.1, 3.4, 3.1, 3.3, 3.6, 3.7, 3.4, 3.6, 3.8, 3.2, 3.4, 3.5, 3.6, 3.9, 4.0, 4.1},

            // Phileo Damansara
            new double[] { 3.5, 3.3, 3.2, 3.0, 2.8, 2.4, 2.0, 1.7, 1.2, 0.8, 1.6, 1.8, 2.5, 2.7, 2.6, 2.8, 3.1, 3.3, 3.1, 3.3, 3.5, 3.7, 3.4, 3.6, 3.8, 3.2, 3.3, 3.5, 3.8, 3.9, 4.0},

            // Pusat Bandar Damansara
            new double[] { 3.3, 3.7, 3.3, 3.1, 3.0, 2.7, 2.6, 2.2, 1.8, 1.6, 0.8, 1.1, 1.8, 2.1, 2.2, 2.5, 2.8, 2.8, 3.0, 3.3, 3.5, 3.3, 3.5, 3.3, 3.5, 3.7, 3.8, 3.2, 3.5, 3.6, 3.7},

            // Semantan
            new double[] { 3.4, 3.3, 3.5, 3.3, 3.2, 2.9, 2.8, 2.5, 2.1, 1.8, 1.1, 0.8, 1.7, 1.9, 2.0, 2.3, 2.6, 2.6, 2.8, 3.1, 3.3, 3.1, 3.4, 3.7, 3.3, 3.5, 3.6, 3.1, 3.4, 3.5, 3.6},

            // Muzium Negara
            new double[] { 3.1, 3.7, 3.4, 3.8, 3.3, 3.1, 3.2, 2.9, 2.8, 2.5, 1.8, 1.7, 0.8, 1.2, 1.3, 1.6, 1.9, 2.1, 2.3, 2.7, 2.7, 3.0, 3.3, 3.2, 3.4, 3.7, 3.2, 3.5, 3.1, 3.2, 3.3},

            // Pasar Seni
            new double[] { 3.2, 3.8, 3.5, 3.4, 3.5, 3.3, 3.4, 3.1, 2.8, 2.7, 2.1, 1.9, 1.2, 0.8, 1.0, 1.3, 1.7, 1.8, 2.1, 2.5, 2.7, 2.8, 3.0, 3.5, 3.3, 3.5, 3.6, 3.3, 3.7, 3.8, 3.2},

            // Merdeka
            new double[] { 3.3, 3.2, 3.6, 3.4, 3.6, 3.4, 3.1, 3.2, 2.9, 2.6, 2.2, 2.0, 1.3, 1.0, 0.8, 1.1, 1.5, 1.8, 1.9, 2.3, 2.5, 2.6, 2.9, 3.3, 3.2, 3.4, 3.5, 3.8, 3.6, 3.7, 3.2},

            // Bukit Bintang
            new double[] { 3.40, 3.30, 3.70, 3.60, 3.20, 3.60, 3.30, 3.40, 3.10, 2.80,  2.50, 2.30, 1.60, 1.30, 1.10, 0.80, 1.20, 1.50, 1.80, 2.10, 2.30, 2.60, 2.70,3.10,3.40 ,3.20 ,3.30 , 3.60, 3.50, 3.60, 3.80},

            // Tun Razak Exchange
            new double[] { 3.50, 3.40, 3.20, 3.80, 3.40, 3.80, 3.50, 3.20, 3.40, 3.10, 2.80, 2.60, 1.90, 1.70, 1.50, 1.20, 0.80, 1.10, 1.40, 1.80, 1.90, 2.30, 2.70, 2.90, 3.10, 3.40, 3.10, 3.40, 3.30, 3.40, 3.60},

            // Cochrane
            new double[] { 3.60, 3.50, 3.30, 3.20, 3.60, 3.40, 3.70, 3.40, 3.10, 3.30, 2.80, 2.60, 2.10, 1.80, 1.80, 1.50, 1.10, 0.80, 1.10, 1.50, 1.80, 2.10, 2.40, 2.60, 2.90, 3.20, 3.30, 3.20, 3.70, 3.30, 3.40},

            // Maluri
            new double[] { 3.70, 3.60, 3.40, 3.30, 3.70, 3.50, 3.20, 3.60, 3.30, 3.10, 3.00, 2.80, 2.30, 2.10, 1.90, 1.80, 1.40, 1.10, 0.80, 1.30, 1.50, 1.80, 2.20, 2.70, 2.70, 3.00, 3.20, 3.10, 3.60, 3.70, 3.30},

            // Taman Pertama
            new double[] { 3.90, 3.80, 3.50, 3.40, 3.20, 3.70, 3.50, 3.30, 3.60, 3.30, 3.30, 3.10, 2.70, 2.50, 2.30, 2.10, 1.80, 1.50, 1.30, 0.80, 1.10, 1.50, 1.80, 2.30, 2.60, 2.70, 2.80, 3.20, 3.30, 3.40, 3.60},

            // Taman Midah
            new double[] { 4.00, 3.90, 3.60, 3.50, 3.20, 3.80, 3.60, 3.40, 3.70, 3.50, 3.50, 3.30, 2.70, 2.70 ,2.50, 2.30, 1.90, 1.80, 1.50, 1.10, 0.80, 1.30, 1.70, 2.10, 2.40, 2.80, 2.70, 3.00, 3.10, 3.30, 3.50},

            // Taman Mutiara
            new double[] { 4.10, 4.00, 3.80, 3.70, 3.40, 3.20, 3.80, 3.60, 3.40, 3.70, 3.30, 3.10, 3.00, 2.80, 2.60, 2.60, 2.30, 2.10, 1.80, 1.50, 1.30, 0.80, 1.20, 1.80, 2.00, 2.40, 2.60, 2.70, 3.30, 3.40, 3.20},

            // Taman Connaught
            new double[] { 4.30, 4.20, 3.90, 3.80, 3.60, 3.40, 3.20, 3.80, 3.60, 3.40, 3.50, 3.40, 3.30, 3.00, 2.90, 2.70, 2.70, 2.40, 2.20, 1.80, 1.70, 1.20, 0.80, 1.40, 1.80, 2.00, 2.20, 2.60, 3.00, 3.10, 3.40},

            // Taman Suntex
            new double[] {4.5, 4.4, 4.1, 4, 3.7, 3.6, 3.4, 3.3, 3.8, 3.6, 3.3, 3.7, 3.2, 3.5, 3.3, 3.1, 2.9, 2.6, 2.7, 2.3, 2.1, 1.8, 1.4, 0.8, 1.2, 1.6, 1.8, 2.1, 2.6, 2.7, 3},

            // Sri Raya
            new double[] { 4.6, 4.5, 4.3, 4.1, 3.9, 3.7, 3.6, 3.4, 3.2, 3.8, 3.5, 3.3, 3.4, 3.3, 3.2, 3.4, 3.1, 2.9, 2.7, 2.6, 2.4, 2, 1.8, 1.2, 0.8, 1.3, 1.5, 1.8, 2.5, 2.7, 2.7},

            // Bandar Tun Hussein Onn
            new double[] { 4.8, 4.6, 4.4, 4.3, 4, 3.9, 3.7, 3.6, 3.4, 3.2, 3.7, 3.5, 3.7, 3.5, 3.4, 3.2, 3.4, 3.2, 3, 2.7, 2.8, 2.4, 2, 1.6, 1.3, 0.8, 1.1, 1.5, 2.2, 2.3, 2.7},

            // Batu Sebelas Cheras
            new double[] { 4.8, 4.7, 4.5, 4.4, 4.1, 4, 3.8, 3.6, 3.5, 3.3, 3.8, 3.6, 3.2, 3.6, 3.5, 3.3, 3.1, 3.3, 3.2, 2.8, 2.7, 2.6, 2.2, 1.8, 1.5, 1.1, 0.8, 1.3, 2, 2.2, 2.5},

            // Bukit Dukung
            new double[] { 5, 4.9, 4.6, 4.5, 4.3, 4.1, 3.9, 3.8, 3.6, 3.5, 3.2, 3.1, 3.5, 3.3, 3.8, 3.6, 3.4, 3.2, 3.1, 3.2, 3, 2.7, 2.6, 2.1, 1.8, 1.5, 1.3, 0.8, 1.7, 1.8, 2.1},

            // Sungai Jernih
            new double[] { 5.3, 5.2, 4.9, 4.8, 4.6, 4.4, 4.2, 4.1, 3.9, 3.8, 3.5, 3.4, 3.1, 3.7, 3.6, 3.5, 3.3, 3.7, 3.6, 3.3, 3.1, 3.3, 3, 2.6, 2.5, 2.2, 2, 1.7, 0.8, 1.1, 1.4}, 

            // Stadium Kajang
            new double[] { 5.4, 5.2, 5, 4.9, 4.6, 4.5, 4.3, 4.2, 4, 3.9, 3.6, 3.5, 3.2, 3.8, 3.7, 3.6, 3.4, 3.3, 3.7, 3.4, 3.3, 3.4, 3.1, 2.7, 2.7, 2.3, 2.2, 1.8, 1.1, 0.8, 1.2},

            // Kajang
            new double[] { 5.5, 5.4, 5.1, 5, 4.8, 4.6, 4.4, 4.3, 4.1, 4, 3.7, 3.6, 3.3, 3.2, 3.2, 3.8, 3.6, 3.4, 3.3, 3.6, 3.5, 3.2, 3.4, 3, 2.7, 2.7, 2.5, 2.1, 1.4, 1.2, 0.8},

        };

        public double CalculateTotalFare()
        {
            // Get the index of the start and end stations in the station list
            int startIndex = Stations.ToList().IndexOf(StartStation);
			int endIndex = Stations.ToList().IndexOf(EndStation);

            if (startIndex < 0 || endIndex < 0)
            {
                return 0;
            }

            // Retrieve the fare for the selected route
            double routeFare = Fares[startIndex][endIndex];

            // Apply discounts for Senior Citizens, Disabled individuals, and Students
            double seniorCitizenDiscount = 0.5;
            double disabledDiscount = 0.6;
            double studentDiscount = 0.4;

            // Determine whether it's a one-way or return trip
            bool isReturnTrip = TicketType == "Return Ticket";

            // Calculate the total fare 
            double totalFare = 0;
            totalFare = routeFare * (
                Citizen +
                Student * (1 - studentDiscount) +
                SeniorCitizen * (1 - seniorCitizenDiscount) +
                Disable * (1 - disabledDiscount)
            );

            if (isReturnTrip)
                totalFare = totalFare * 2;

            return totalFare;
        }


        [Required]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [Display(Name = "Amount")]
        public double Amount
        {
            get
            {
                return CalculateTotalFare();
            }
            set { }
        }
    }

}
