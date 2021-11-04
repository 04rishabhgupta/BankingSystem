using Bank;
using NUnit.Framework;
using System;

namespace BankNUnitTests
{
    public class BankAccountTests
    {


        [Test]
        public void Adding_Funds_Updates_Balance()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT
            account.Add(500);

            //ASSERT
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Adding_Negative_Funds_Throws()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
        }

        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Withdraw(500);

            // ASSERT
            Assert.AreEqual(500, account.Balance);
        }

        [Test]
        public void Withdrawing_Negative_Funds_Throws()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        [Test]
        public void Withdrawing_Greater_Amount_Than_Balance_Throws()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(13000));
        }

        [Test]
        public void Transferring_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var account = new BankAccount(1000);
            var otheraccount = new BankAccount();

            // ACT
            account.TransferFundsTo(otheraccount, 500);

            // ASSERT
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, otheraccount.Balance);
        }

        [Test]
        public void Transferring_Funds_To_Nonexisting_Account_Throws()
        {
            //ARRANGE
            var account = new BankAccount(1000);

            //ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 13000));
        }
    }
}