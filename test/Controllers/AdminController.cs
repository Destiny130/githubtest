using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class AdminController : Controller
    {
        IMemberRepository membersRepository;
        public AdminController(IMemberRepository repositoryParam)
        {
            membersRepository = repositoryParam;
        }

        public ActionResult ChangeLoginName(string oldLoginParam, string newLoginParam)
        {
            Member member = membersRepository.FetchByLoginName(oldLoginParam);
            member.LoginName = newLoginParam;
            membersRepository.SubmitChanges();

            return View();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}