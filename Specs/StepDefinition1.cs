using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specs
{
    [Binding]
    public class StepDefinition1
    {
//        [Given(@"(\w+) has (\d+) shares? of (\w+) stock with \$(\d)")]
//        public void GivenPortfolio(string userName, int count, string stockTicker, int pricePerShare)
//        {
//        }
//
//        [When(@"(\w+) is selling (\d+) shares? of (\w+) stock at \$(\d)")]
//        public void WhenSellingShares(string userName, int count, string stockTicker, int perShare)
//        {
//        }
//
//        [Then(@"the sale-trade queue has (\d) shares? of (\w+) stock at \$(.*) per share")]
//        public void ThenSaleInQueue(int count, string stockTicker, int perShare)
//        {
//        }

        [Given(@"seller has 5 shares of XYZ stock with $0")]
        public void g1()
        {
            
        }

        [When(@"seller is selling 1 share of XYZ stock at $10 per share")]
        public void w1()
        {
            
        }

        [Then(@"the saletrade queue has 1 share of XYZ stock at $10 per share")]
        public void t1()
        {
            
        }


    }
}
