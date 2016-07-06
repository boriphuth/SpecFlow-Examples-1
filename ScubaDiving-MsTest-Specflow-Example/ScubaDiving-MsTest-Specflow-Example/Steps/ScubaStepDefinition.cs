using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScubaDiving;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ScubaDiving_MsTest_Specflow_Example
{
    [Binding]
    public sealed class ScubaStepDefinition
    {
        private Scuba _scuba;

        private List<String> _diveSites = new List<string>();

        [Given(@"a new Dive Site named ""(.*)""")]
        public void GivenAtANewDiveSiteNamed(string diveSiteName)
        {
            _scuba = new Scuba();
            _scuba.DiveSiteName = diveSiteName;

            // used for many dives per day
            _diveSites.Add(diveSiteName);
        }

        [Given(@"at a new Dive Site")]
        public void GivenAtANewDiveSite()
        {
            _scuba = new Scuba();
        }

        [Given(@"I dive with (.*) others")]
        public void GivenDiveWithOthers(int numberOfBuddies)
        {
            _scuba.NumberOfBuddies = numberOfBuddies;
        }

        [When(@"I dive a depth of (.*) meters for (.*) minutes")]
        public void WhenIDiveADepthOfMetersForMinutes(int depth, int time)
        {
            _scuba.Depth = depth;
            _scuba.DiveTime = time;
        }

        [Then(@"the sum of the groups time is (.*) minutes")]
        public void ThenTheSumOfTheGroupsTimeIsMinutes(int numOfMins)
        {
            // number of buddies + yourself * dive time is the sum of all time under the water
            var sum = (_scuba.NumberOfBuddies + 1) *_scuba.DiveTime;
            Assert.AreEqual(numOfMins,sum);
        }


        [When(@"I manage to make it to the Next Dive Site named ""(.*)""")]
        public void WhenIManageToMakeItToTheNextDiveSiteNamed(string diveSiteName)
        {
            _diveSites.Add(diveSiteName);
        }

        [Then(@"I've dived")]
        public void ThenIVeDived(Table table)
        {
            foreach (var ds in table.Rows)
            {
                Assert.IsTrue(_diveSites.Contains(ds["Dive Site Name"]));
            }
        }

        [When(@"I dive the following depths in a day:(.*)")]
        public void WhenIDiveTheFollowingDepthsInADay(string series)
        {
            var count = 0;

             foreach (var diveDepth in series.Trim().Split(','))
            {
                count = count + int.Parse(diveDepth);
            }
            _scuba.SumOfDepths = count;
        }

        [Then(@"my sum of all depths for the day is (.*) meters")]
        public void ThenMySumOfAllDepthsForTheDayIsMeters(int sumDepths)
        {
            Assert.AreEqual(sumDepths, _scuba.SumOfDepths);
        }

        [Then(@"my sum of all times for the day is (.*) minutes")]
        public void ThenMySumOfAllTimesForTheDayIsMinutes(int sumTime)
        {
            Assert.AreEqual(sumTime, _scuba.SumOfTime);
        }

        [When(@"I dive the for a time of in minutes:(.*)")]
        public void WhenIDiveTheForATimeOfInMinutes(string series)
        {
            var count = 0;

            foreach (var diveTime in series.Trim().Split(','))
            {
                count = count + int.Parse(diveTime);
            }
            _scuba.SumOfTime = count;
        }




    }
}
