/*
- Given it is the 1st of January, 2020
- When I create an order of $100.00
- And I select 4 Installments
- And I select a frequency of 14 days
- Then I should be charged these 4 installments
  - `01/01/2020   -   $25.00`
  - `01/15/2020   -   $25.00`
  - `01/29/2020   -   $25.00`
  - `02/12/2020   -   $25.00`
*/
using System;

namespace QuadPay.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the QuadPay product definition.
    /// </summary>
    public class PaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(decimal purchaseAmount)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            paymentPlan.PurchaseAmount = purchaseAmount;

            Installment[] installments = new Installment[4];

            if (purchaseAmount <= 0)
            {
                // ? negatives and zero case
            }

            decimal remainder = ((purchaseAmount / 4) % 0.01M) * 4;
            decimal baseValue = Math.Truncate(100 * (purchaseAmount / 4)) / 100;
            DateTime dueDate = DateTime.Today;
            
            for (int i=0; i<4; i++) {
                Installment installment = new Installment();
                
                // set date
                installment.DueDate = dueDate;
                dueDate = dueDate.AddDays(7);

                // set amount
                installment.Amount = baseValue;
                if (remainder > 0) {
                    installment.Amount += 0.01M;
                    remainder -= 0.01M;
                }

                installments[i] = installment;
            }

            paymentPlan.Installments = installments;

            return paymentPlan;
        }
    }
}
