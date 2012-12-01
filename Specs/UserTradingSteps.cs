using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Specs
{
    [Binding]
    public class UserTradingSteps
    {
        private StockExchange so;

        [BeforeScenario]
        public void Setup()
        {
            so = new StockExchange();
        }

        [Given(@"(.*) applies for an account with tax id ""(.*)"", bank account number ""(.*)"", and routing number ""(.*)""")]
        public void GivenPersonAppliesForAnAccountWithTaxIdBankAccountNumberAndRoutingNumber(string username, string idnum, string acct, string routing)
        {
            so.AddAccount(username, idnum, acct, routing);
        }

        [Given(@"(.*) has signed stock market trade agreements")]
        public void GivenPersonHasSignedStockMarketTradeAgreements(string username)
        {
            var account = so.GetAccount(username);
            account.AcceptTerms();
        }

        [Then(@"there exists an account for (.*)")]
        public void ThenThereExistsAnAccount(string username)
        {
            Assert.NotNull(so.GetAccount(username));
        }

        [Then(@"(.*)'s account has signed stock market trade agreements")]
        public void ThenAccountHasSignedStockMarketTradeAgreements(string username)
        {
            Assert.IsTrue(so.GetAccount(username).HasAcceptedTerms);
        }


        [Given(@"(.*) has (.*) shares of (.*) stock with \$(.*)")]
        public void GivenSellerHasSharesOfXYZStockWith(string username, int qty, string stockTicker, int money)
        {
            var portfolio = so.AddAccount(username, null, null, null);
            portfolio.Username = username;
            portfolio.AddStock(qty, stockTicker);
            portfolio.AddMoney(money);
        }
        
        [When(@"(.*) is selling (.*) share of (.*) stock at \$(.*) per share")]
        public void WhenSellerIsSellingShareOfXYZStockAtPerShare(string username, int shares, string stockTicker, int price)
        {
            var seller = so.GetAccount(username);
            seller.Sell(shares, stockTicker, price);
        }
        
        [Then(@"the saletrade queue has (.*) share of (.*) stock at \$(.*) per share")]
        public void ThenTheSaletradeQueueHasShareOfXYZStockAtPerShare(int count, string stockTicker, int price)
        {
            Assert.IsTrue(
                so.PendingSales.Exists(sale => sale.Count == count && sale.StockTicker == stockTicker && sale.Price == price)
            );
        }
    }

    public class Sale
    {
        public decimal Price { get; set; }
        public string StockTicker { get; set; }
        public decimal Count { get; set; }
    }

    public class Account
    {
        private StockExchange stockExchange;

        public Account(StockExchange so)
        {
            stockExchange = so;
        }

        public string Username { get; set; }

        public bool HasAcceptedTerms { get; set; }
        

        public void AddStock(int qty, string stockTicker)
        {
        }

        public void AddMoney(int money)
        {
        }

        public void Sell(int shares, string stockTicker, int price)
        {
            stockExchange.PendingSales.Add(new Sale
                {
                    Count = shares,
                    Price = price,
                    StockTicker = stockTicker
                });
        }

        public void AcceptTerms()
        {
            
        }
    }

    public class StockExchange
    {
        public StockExchange()
        {
            PendingSales = new List<Sale>();
        }

        public Account AddAccount(string username, string idnum, string acct, string routing)
        {
            return new Account(this);
        }

        public Account GetAccount(string username)
        {
            return new Account(this);
        }

        public List<Sale> PendingSales { get; set; }
    }
}
