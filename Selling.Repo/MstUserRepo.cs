using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selling.ViewModel;
using Selling.Model;
using Selling.ViewModel;

namespace Selling.Repo
{
    public class MstUserRepo
    {
        private DataContext dataContext = new DataContext();
        public List<MstUserViewModel> GetAll(MstUserViewModel dataLogin)
        {
            List<MstUserViewModel> result = new List<MstUserViewModel>();
            result = (from masterUser in dataContext.MstUser
                      join officer in dataContext.TblOfficer on masterUser.officerCode equals officer.OfficerCode
                      where masterUser.Username == dataLogin.Username
                      && masterUser.Password == dataLogin.Password
                      select new MstUserViewModel
                      {
                          Id            = masterUser.Id,
                          Username      = masterUser.Username,
                          Password      = masterUser.Password,
                          Active        = masterUser.Active,
                          officerCode   = masterUser.officerCode,
                          officerName   = officer.OfficerName,
                      }).ToList();
            return result;
        }   
        
    }
}
