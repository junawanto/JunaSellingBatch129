using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selling.Model;
using Selling.ViewModel;

namespace Selling.Repo
{
    public class tblItemRepo:iSelling<Selling.ViewModel.tblItem>
    {
        private DataContext dataContext = new DataContext();
        public bool Create(Selling.ViewModel.tblItem model)
        {
            bool result = true;
            Model.tblItem mdlItem = new Model.tblItem();
            //mdlOfficer.tblOfficerID = model.tblOfficerID;
            mdlItem.ItemCode = model.ItemCode;
            mdlItem.ItemName = model.ItemName;
            mdlItem.BuyingPrice = model.BuyingPrice;
            mdlItem.SellingPrice = model.SellingPrice;
            mdlItem.ItemAmount = model.ItemAmount;
            mdlItem.Pieces = model.Pieces;

            dataContext.TblItem.Add(mdlItem);
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
        public bool Update(Selling.ViewModel.tblItem model)
        {
            bool result = true;
            Model.tblItem mdlItem = dataContext.TblItem.Where(mdl => mdl.ItemCode == model.ItemCode).FirstOrDefault();
            //mdlOfficer.tblOfficerID = model.tblOfficerID;
            mdlItem.ItemCode = model.ItemCode;
            mdlItem.ItemName = model.ItemName;
            mdlItem.BuyingPrice = model.BuyingPrice;
            mdlItem.SellingPrice = model.SellingPrice;
            mdlItem.ItemAmount = model.ItemAmount;
            mdlItem.Pieces = model.Pieces;

            dataContext.TblItem.Add(mdlItem);
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
        public bool Delete(string kodeItem)
        {
            bool result = true;
            Model.tblItem mdlItem = dataContext.TblItem.Where(mdl => mdl.ItemCode == kodeItem).FirstOrDefault();
            dataContext.TblItem.Remove(mdlItem);
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
        public List<Selling.ViewModel.tblItem> GetAll()
        {
            List<Selling.ViewModel.tblItem> result = new List<ViewModel.tblItem>();
            result = (from item in dataContext.TblItem
                      select new Selling.ViewModel.tblItem
                      {
                          tblItemID     = item.tblItemID,
                          ItemCode      = item.ItemCode,
                          ItemName      = item.ItemName,
                          BuyingPrice   = item.BuyingPrice,
                          SellingPrice  = item.SellingPrice,
                          ItemAmount    = item.ItemAmount,
                          Pieces        = item.Pieces
                      }).ToList();

            return result;
        }
        public Selling.ViewModel.tblItem GetById(string code)
        {
            Selling.ViewModel.tblItem result = new Selling.ViewModel.tblItem();
            result = (from item in dataContext.TblItem
                      where item.ItemCode == code
                      select new Selling.ViewModel.tblItem
                      {
                          tblItemID     = item.tblItemID,
                          ItemCode      = item.ItemCode,
                          ItemName      = item.ItemName,
                          BuyingPrice   = item.BuyingPrice,
                          SellingPrice  = item.SellingPrice,
                          ItemAmount    = item.ItemAmount,
                          Pieces        = item.Pieces
                      }).FirstOrDefault();

            return result;
        }
    }
}
