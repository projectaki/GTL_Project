﻿using DataLayer.DataAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ControlLayer
{
    public static class MemberControl
    {
       
        public static int CreateMember(int Ssn, string FirstName, string LastName,
            string EmailAddress, string PhoneNumber, string Campus, string MemberType)
        {
            Member data = new Member
            {
                ssn = Ssn,
                fname = FirstName,
                lname = LastName,
                mail_address = EmailAddress,
                phone_nr = PhoneNumber,
                campus = Campus,
                member_type = MemberType
            };
                string sql = @"insert into dbo.Person (ssn,fname,lname,mail_address,phone_nr) values (
                               @Ssn,@fname,@lname,@mail_address,@phone_nr)
                               insert into dbo.Member (ssn,campus,sign_up_date,member_type) values (@Ssn,@Campus,CURRENT_TIMESTAMP,@Member_Type);";

            return SQLDataAccess.SaveData(sql,data);
        }

        public static List<Member> LoadMember(int id)
        {
            string sql = @"select person.ssn,fname,lname,mail_address,phone_nr,campus,sign_up_date,member_type
                           from person
                           inner join Member on person.ssn = member.ssn
                           where person.ssn =" + id + 
                           " order by fname;";
            var data = SQLDataAccess.LoadData<Member>(sql);
            return data;
        }

        public static List<Member> LoadMembersWhere(string search)
        {

            string sql = "select person.ssn,fname,lname,mail_address,phone_nr,campus,sign_up_date,member_type"
                           + " from person"
                           + " inner join Member on person.ssn = member.ssn"
                           + " where fname+" + "' " + "'" + " + lname like" + "'" + "%" + search + "%" + "'" 
                           + " order by fname;";



                           
            var data = SQLDataAccess.LoadData<Member>(sql);
            return data;
        }


    }
}
