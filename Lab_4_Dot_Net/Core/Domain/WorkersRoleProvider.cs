using Lab_4_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab_4_Dot_Net.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Lab_4_Dot_Net.Core.Domain
{
    public class WorkersRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            using (LostAndFoundContext context = new LostAndFoundContext())
            {
                var worker = context.Workers.Where(w => w.Login == usernames[0]).FirstOrDefault();
                var role = context.Roles.Where(r => r.RoleName == roleNames[0]).FirstOrDefault();
                worker.Mappings.Add(new WorkerRoleMapping() {Role = role, Worker = worker });
                context.SaveChanges();                
            }
        }

        public override void CreateRole(string roleName) => throw new NotImplementedException();

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)=> throw new NotImplementedException();

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) => throw new NotImplementedException();

        public override string[] GetAllRoles() => throw new NotImplementedException();

        public override string[] GetRolesForUser(string username)
        {
            using (LostAndFoundContext context = new LostAndFoundContext())
            {
                var worker = context.Workers.Include(w => w.Mappings).Where(w=>w.Login == username).FirstOrDefault();
                var roles = context.Roles.ToList();
                var roleIdentifiers = worker.Mappings.Select(m => m.RoleId).ToList();
                var workerRoles = roles.Where(r => roleIdentifiers.Contains(r.RoleId)).Select(r => r.RoleName).ToArray();
                return workerRoles;
            }
        }

        public override string[] GetUsersInRole(string roleName) => throw new NotImplementedException();

        public override bool IsUserInRole(string username, string roleName) => throw new NotImplementedException();

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) => throw new NotImplementedException();

        public override bool RoleExists(string roleName) => throw new NotImplementedException();
    }
}