using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public class UserDAL : PromoveoServiceLibrary.ServiceDefinitions.IUser
    {
        public IList<User> GetUsers()
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            return ds.PublishingPlatformUser.Select(cc => new User() { Id = cc.Id, Name = cc.Name, Shortname = cc.Shortname, Email = cc.Email }).ToList();
        }

        public User GetUser(int Id)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            return ds.PublishingPlatformUser.Where(cc => cc.Id == Id).Select(cc => new User()
            {
                Email = cc.Email,
                Shortname = cc.Shortname,
                Name = cc.Name,
                Id = cc.Id
            }).FirstOrDefault();
        }

        public int InsertUser(User user)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            int Id = userAdapter.Insert(user.Name, user.Shortname, user.Email);
            ds.AcceptChanges();
            return Id;
        }

        public void UpdateUser(User user)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            Data.PromoveoDataSet.PublishingPlatformUserRow recordToUpdate = ds.PublishingPlatformUser.Where(cc => cc.Id == user.Id).Single();
            recordToUpdate.Name = user.Name;
            recordToUpdate.Email = user.Email;
            recordToUpdate.Shortname = user.Shortname;
            ds.AcceptChanges();
        }

        public void DeleteUser(User user)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            userAdapter.Delete(user.Id, user.Name, user.Shortname, user.Email);
            ds.AcceptChanges();
        }
    }
}
