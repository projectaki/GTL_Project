using GTL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.ControlLayer;

namespace GTL_Project.Controllers
{
    public class MemberController : Controller
    {


        public ActionResult Member()
        {
            return View();
        }

        public ActionResult MemberSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberSignUp(Member member)
        {
            if (ModelState.IsValid)
            {
                MemberControl.CreateMember(
                    member.Ssn,
                    member.FirstName,
                    member.LastName,
                    member.EmailAddress,
                    member.PhoneNumber,
                    member.Campus,
                    member.MemberType);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult MemberInfo(int id)
        {
            var data = MemberControl.LoadMemberInfo(id);

            List<Member> members = new List<Member>();

            foreach (var item in data)
            {
                members.Add(new Member
                {
                    Ssn = item.ssn,
                    FirstName = item.fname,
                    LastName = item.lname,
                    EmailAddress = item.mail_address,
                    PhoneNumber = item.phone_nr,
                    Campus = item.campus,
                    SignUpDate = item.sign_up_date,
                    MemberType = item.member_type
                });
            }
            return View(members);
        }

        public ActionResult SearchMemberWhere(string search)
        {
            var data = MemberControl.LoadMembersWhere(search);

            List<Member> members = new List<Member>();

            foreach (var item in data)
            {
                members.Add(new Member
                {
                    Ssn = item.ssn,
                    FirstName = item.fname,
                    LastName = item.lname,
                    EmailAddress = item.mail_address,
                    PhoneNumber = item.phone_nr,
                    Campus = item.campus,
                    SignUpDate = item.sign_up_date,
                    MemberType = item.member_type
                });
            }
            return View(members);
        }


    }
}