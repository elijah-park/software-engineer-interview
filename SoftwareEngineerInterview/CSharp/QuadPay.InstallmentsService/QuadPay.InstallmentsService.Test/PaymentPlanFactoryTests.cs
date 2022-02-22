using Shouldly;
using Xunit;

namespace QuadPay.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }

        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldGenerateGuid()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            
            // Act
            PaymentPlan paymentPlan = paymentPlanFactory.CreatePaymentPlan(11.37M);

            // Assert
            paymentPlan.Id.ShouldNotBe(System.Guid.Parse("00000000-0000-0000-0000-000000000000"));
        }

        // // TODO
        // [Fact]
        // public void WhenCreatePaymentPlanWithNegativeOrderAmount_ShouldReturnXXX()
        // {
        //     // Arrange
        //     var paymentPlanFactory = new PaymentPlanFactory();
            
        //     // Act
        //     var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

        //     // Assert
        //     paymentPlan.ShouldNotBeNull();
        // }

        // // TODO
        // [Fact]
        // public void WhenCreatePaymentPlanWithZeroOrderAmount_ShouldReturnXXX()
        // {
        //     // Arrange
        //     var paymentPlanFactory = new PaymentPlanFactory();
            
        //     // Act
        //     var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);

        //     // Assert
        //     paymentPlan.ShouldNotBeNull();
        // }
    }
}
