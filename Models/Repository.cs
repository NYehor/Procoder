﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Procoder.Models
{

    public class Repository : IRepositoryUsers/*, IRepositoryMaps*/
    {
        private ProcoderContext context;

        public Repository(ProcoderContext ctx) => context = ctx;

        public JsonResult GetAllMyMaps(int userId)
        {
            IEnumerable<object> map = context.Maps
                 .OrderBy(c => c.Id)
                 .Where(d => d.userId == userId)
                 .Select(p => new { map = p.Name, category = p.Category, create = p.CreateData, edit = p.LastEdit }
                 )
                 .AsEnumerable()
                 .Select(an => new
                 {
                     name = an.map,
                     category = an.category,
                     CreateData = an.create,
                     LastEdit = an.edit
                 });
            return new JsonResult(map);
        }

        //public ActionResult<IEnumerable<IMapForList>> GetConcreteMap(int mapId)
        //{
        //    var map = context.Maps
        //         .Where(v => v.Id == mapId)
        //         .Select(n => new Map
        //         {
        //             userId = n.userId,
        //             Id = n.Id,
        //             Category = n.Category,
        //             Status = n.Status,
        //             Name = n.Name,
        //             CreateData = n.CreateData,
        //             LastEdit = n.LastEdit
        //         })
        //                             //continue here
        //          .Include(c => c.Nodes).ToArray();
        //    return map;
        //}

        public ActionResult<IEnumerable<object>> GetAllUser()
        {
            var users = context.Users
                .OrderBy(o => o.UserId)
               .Select(p => new { p.UserId, p.Name }).ToArray();
            return users;
        }

        public JsonResult GetUser(int id)
        {

            var user = context.Users
            .Select(p => new
            {
                p.UserId,
                p.Name,
                p.LastName,
                p.Email,
                p.Password
            })
            .Where(p => id == p.UserId)
            .ToList();
            //.FirstOrDefault(p => p.userId == id);
            return new JsonResult(user);

        }


        public ActionResult<bool> AddNewUser()
        {
            bool result = false;





            return result;
        }
    }
}
