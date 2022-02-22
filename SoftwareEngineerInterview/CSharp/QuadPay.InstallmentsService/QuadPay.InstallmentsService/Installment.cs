using System;

namespace QuadPay.InstallmentsService
{
    /// <summary>
    /// Data structure which defines all the properties for an installment.
    /// </summary>
    public class Installment
    {
        /// <summary>
        /// Gets or sets the unique identifier for each installment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date that the installment payment is due.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the installment.
        /// </summary>
        public decimal Amount { get; set; }

        public override string ToString() {
            return String.Format("{0}   -   ${1:#.00}", DueDate.ToString("MM/dd/yy"), Amount);
        }

        public Installment() {
            this.Id = System.Guid.NewGuid();
        }
	}
}
