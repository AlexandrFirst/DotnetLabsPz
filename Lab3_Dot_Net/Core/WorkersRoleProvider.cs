using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lab3_Dot_Net.Core.Domain.WorkerRoleMappings;
using Lab3_Dot_Net.Persistence;

namespace Lab3_Dot_Net.Core
{
    public class WorkersRoleProvider : RoleProvider
    {
        private readonly IUnitOfWork _repository;

        public WorkersRoleProvider()
        {
            _repository = new UnitOfWork();
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var workers = _repository.Workers.GetAll();
            var roles = _repository.Roles.GetAll();
            foreach (var userName in usernames)
                foreach (var roleName in roleNames)
                {
                    var worker = workers.Where(w => w.Login == userName).FirstOrDefault();
                    var role = roles.Where(r => r.RoleName == roleName).FirstOrDefault();
                    WorkerRoleMapping mapping = new WorkerRoleMapping()
                    {
                        RoleId = role.RoleId,
                        WorkerId = worker.WorkerId
                    };
                    if (!_repository.RoleMappings.Exists(mapping))
                        _repository.RoleMappings.Add(mapping);
                }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var workers = _repository.Workers.GetAll();
            var roles = _repository.Roles.GetAll();
            var mappings = _repository.RoleMappings.GetAll();
            var userRoles = (from w in workers
                             join
           mapping in mappings
           on w.WorkerId equals mapping.WorkerId
                             join role in roles
                             on mapping.RoleId equals role.RoleId
                             where w.Login == username
                             select role.RoleName).ToArray();
            return userRoles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}