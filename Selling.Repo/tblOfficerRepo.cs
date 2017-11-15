using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selling.Model;
using Selling.ViewModel;
using System.Data.Entity;

namespace Selling.Repo
{
    public class tblOfficerRepo:iSelling<Selling.ViewModel.tblOfficer>
    {
        private DataContext dataContext = new DataContext();
        public bool Create(Selling.ViewModel.tblOfficer model)
        {
            bool result = true;
            Model.tblOfficer mdlOfficer = new Model.tblOfficer();
            //mdlOfficer.tblOfficerID = model.tblOfficerID;
            mdlOfficer.OfficerCode = model.OfficerCode;
            mdlOfficer.OfficerName = model.OfficerName;
            mdlOfficer.OfficerPassword = model.OfficerPassword;
            mdlOfficer.OfficerStatus = model.OfficerStatus;

            dataContext.TblOfficer.Add(mdlOfficer);
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
                return result;
            }
            
            return result;
        }
        public bool Update(Selling.ViewModel.tblOfficer model)
        {
            bool result = true;
            Model.tblOfficer mdlOfficer = dataContext.TblOfficer.Where(mdl => mdl.OfficerCode == model.OfficerCode).FirstOrDefault();
            mdlOfficer.tblOfficerID = model.tblOfficerID;
            mdlOfficer.OfficerCode = model.OfficerCode;
            mdlOfficer.OfficerName = model.OfficerName;
            mdlOfficer.OfficerPassword = model.OfficerPassword;
            mdlOfficer.OfficerStatus = model.OfficerStatus;

            dataContext.Entry(mdlOfficer).State = EntityState.Modified;
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
                return result;
            }

            return result;
        }
        public bool Delete(string kodeOfficer)
        {
            bool result = true;
            Model.tblOfficer mdlOfficer = dataContext.TblOfficer.Where(mdl => mdl.OfficerCode == kodeOfficer).FirstOrDefault();
            dataContext.TblOfficer.Remove(mdlOfficer);
            try
            {
                dataContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
                return result;
            }

            return result;
        }
        public List<Selling.ViewModel.tblOfficer> GetAll()
        {
            List<Selling.ViewModel.tblOfficer> result = new List<ViewModel.tblOfficer>();
            result = (from officer in dataContext.TblOfficer
                      select new Selling.ViewModel.tblOfficer
                      {
                          tblOfficerID      = officer.tblOfficerID,
                          OfficerCode       = officer.OfficerCode,
                          OfficerName       = officer.OfficerName,
                          OfficerPassword   = officer.OfficerPassword,
                          OfficerStatus     = officer.OfficerStatus
                      }).ToList();

            return result;
        }
        public Selling.ViewModel.tblOfficer GetById(string code)
        {
            Selling.ViewModel.tblOfficer result = new Selling.ViewModel.tblOfficer();
            result = (from officer in dataContext.TblOfficer
                      where officer.OfficerCode == code
                      select new Selling.ViewModel.tblOfficer
                      {
                          tblOfficerID = officer.tblOfficerID,
                          OfficerCode = officer.OfficerCode,
                          OfficerName = officer.OfficerName,
                          OfficerPassword = officer.OfficerPassword,
                          OfficerStatus = officer.OfficerStatus
                      }).FirstOrDefault();

            return result;
        }
    }
}
