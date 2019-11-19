
namespace CustomerArrears
{
    /// <summary>
    /// Emulates the customer arrears scoring.
    /// </summary>
    public class CustomerData
    {
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public int Balance { get; set; }

        /// <summary>
        /// Gets or sets the late score.
        /// </summary>
        /// <value>
        /// The late score.
        /// </value>
        public int LateScore { get; set; }

        /// <summary>
        /// Gets or sets the early score.
        /// </summary>
        /// <value>
        /// The early score.
        /// </value>
        public int EarlyScore { get; set; }

        /// <summary>
        /// Gets or sets the segment.
        /// </summary>
        /// <value>
        /// The segment.
        /// </value>
        public int Segment { get; set; }

        /// <summary>
        /// Gets or sets the arrears status. The arrears status can be:
        /// EC - Early Care, 
        /// ES - Early Stage,
        /// LS - Late Stage  
        /// </summary>
        /// <value>
        /// The arrears status.
        /// </value>
        public string ArrearsStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of missed payments.
        /// </summary>
        /// <value>
        /// The number of missed payments.
        /// </value>
        public int NumberOfMissedPayments { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// The country code can be:
        /// UK - United Kingdom
        /// ROI - Republic of Ireland
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the arrears strategy code.
        /// </summary>
        /// <value>
        /// The arrears strategy code.
        /// </value>
        public string ArrearsStrategyCode { get; set; }

        /// <summary>
        /// Gets or sets the payment frequency.
        /// </summary>
        /// <value>
        /// The payment frequency.
        /// </value>
        public string PaymentFrequency { get; set; }

        /// <summary>
        /// Gets or sets the waiver in place.
        /// </summary>
        /// <value>
        /// The waiver in place.
        /// </value>
        public string WaiverInPlace { get; set; }

        public bool SetArrearsStatus(string status)
        {
            this.WaiverInPlace = status;
            return true;
        }

        public void SetBalance(int balance)
        {
            this.Balance = balance;
        }

        public void SetArrearsStatus2(string status)
        {
            this.WaiverInPlace = status;
        }
    }
}
