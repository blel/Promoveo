using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public class PublishingPlatformRoleDAL : PromoveoServiceLibrary.ServiceDefinitions.IPublishingPlatformRole
    {
        public IList<Role> GetRoles()
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            publishingPlatformRoleAdapter.Fill(ds.PublishingPlatformRole);
            return (from cc in ds.PublishingPlatformRole
                    select new Role() { FK_Configuration = cc.FK_Configuration, Id = cc.Id, Name = cc.RoleName }).ToList();
        }

        public Role GetRole(int Id)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            publishingPlatformRoleAdapter.Fill(ds.PublishingPlatformRole);
            return (from cc in ds.PublishingPlatformRole
                    where cc.Id == Id
                    select new Role() { FK_Configuration = cc.FK_Configuration, Id = cc.Id, Name = cc.RoleName }).Single();
        }
     
        public int CreateRole(Role role)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            int Id = publishingPlatformRoleAdapter.Insert(role.Name, role.FK_Configuration);
            ds.AcceptChanges();
            return Id;
        }

        public void UpdateRole(Role role)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            publishingPlatformRoleAdapter.Fill(ds.PublishingPlatformRole);
            Data.PromoveoDataSet.PublishingPlatformRoleRow roleToUpdate = ds.PublishingPlatformRole.Where(cc => cc.Id == role.Id).Single();
            roleToUpdate.Id = role.Id;
            roleToUpdate.FK_Configuration = role.FK_Configuration;
            roleToUpdate.RoleName = role.Name;
            ds.AcceptChanges();
        }




    }
}
