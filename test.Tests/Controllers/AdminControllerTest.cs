using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.Models;
using System.Collections.Generic;
using System.Linq;
using test.Controllers;

namespace test.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            //Arrange
            Member Bob = new Member() { LoginName = "Bod" };
            FakeMembersRepository repositoryParam = new FakeMembersRepository();
            repositoryParam.Members.Add(Bob);
            AdminController target = new AdminController(repositoryParam);
            string oldLoginParam = Bob.LoginName;
            string newLoginParam = "Tom";

            //Act
            target.ChangeLoginName(oldLoginParam, newLoginParam);

            //Assert
            Assert.AreEqual(newLoginParam, Bob.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }

        private class FakeMembersRepository : IMemberRepository
        {
            public List<Member> Members = new List<Member>();
            public bool DidSubmitChanges = false;

            public void AddMember(Member member)
            {
                throw new NotImplementedException();
            }

            public Member FetchByLoginName(string loginName)
            {
                return Members.First(m => m.LoginName == loginName);
            }

            public void SubmitChanges()
            {
                DidSubmitChanges = true;
            }
        }

        [TestMethod]
        public void CanAddBid()
        {
            //Arrange
            Item target = new Item();
            Member memberParam = new Member();
            decimal amountParam = 150M;

            //Act
            target.AddBid(memberParam, amountParam);

            //Assert
            Assert.AreEqual(1, target.Bids.Count());
            Assert.AreEqual(amountParam, target.Bids[0].BidAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAddLowerBid()
        {
            //Arrange
            Item target = new Item();
            Member memberParam = new Member();
            decimal amountParam = 150M;

            //Act
            target.AddBid(memberParam, amountParam);
            target.AddBid(memberParam, amountParam - 10);
        }

        [TestMethod]
        public void CanAddHigherBid()
        {
            //Arrange
            Item target = new Item();
            Member firstMember = new Member();
            Member secondMember = new Member();
            decimal amountParam = 150M;

            //Act
            target.AddBid(firstMember, amountParam);
            target.AddBid(secondMember, amountParam + 10);

            //Assert
            Assert.AreEqual(2, target.Bids.Count());
            Assert.AreEqual(amountParam + 10, target.Bids[1].BidAmount);
        }
    }
}
