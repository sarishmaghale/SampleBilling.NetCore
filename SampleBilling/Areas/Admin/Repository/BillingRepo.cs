using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleBilling.Data;
using SampleBilling.Areas.Admin.Interface;
using SampleBilling.Areas.Admin.Models;
using System;

namespace SampleBilling.Areas.Admin.Repository
{
    public class BillingRepo : IBillingRepo
    {
        private BillingDbContext db;
        public BillingRepo(BillingDbContext _db)
        {
            db = _db;
        }

        public async Task<int> AddBilling(BillingViewModel billings)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var TodayDate = DateTime.Now.ToShortDateString();
                    int TotalAmount = 0;
                    foreach (var item in billings.Details)
                    {
                        if (item != null)
                        {
                            TotalAmount = (int)(TotalAmount + (item.Quantity * item.Price));
                        }
                        
                    }
                    Billing data1 = new Billing()
                    {
                        Name = billings.Name,
                        Total = TotalAmount,
                        Status = true,
                        BillingDate= TodayDate,
                    };
                    await db.Billings.AddAsync(data1);
                    await db.SaveChangesAsync();
                   
                    foreach (var DetailData in billings.Details)
                    {
                        if (DetailData != null) {
                            BillingDetail data2 = new BillingDetail()
                            {
                                BillId = data1.BillId,
                                BrandId = DetailData.BrandId,
                                CategoryId = DetailData.CategoryId,
                                Quantity = DetailData.Quantity,
                                Price = DetailData.Price
                            };
                            await db.BillingDetails.AddAsync(data2);
                            await db.SaveChangesAsync();

                            var EditSales = await db.Sales.Where(x => x.ProductId == data2.BrandId).FirstOrDefaultAsync();
                            EditSales.TotalSales = EditSales.TotalSales + data2.Quantity;
                            EditSales.LeftStocks = EditSales.LeftStocks - data2.Quantity;
                            db.Entry(EditSales).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }                                                               
                    }                   
                   
                    transaction.Commit();
                    return data1.BillId;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
                
        }  
 

        public async Task<IEnumerable<BillingViewModel>> getBillings()
        {
           var data= await db.Billings.Where(a=> a.Status==true).Select(x => new BillingViewModel() { 
           BillId=x.BillId,
           Name=x.Name,
           Total=x.Total,
           BillingDate=x.BillingDate

           }).OrderByDescending(x => x.BillId).ToListAsync();
            return data;
        }

        public async Task<BillingViewModel> getBillingDetails(int id)
        {
            var model = new BillingViewModel();
            model.Details =await db.BillingDetails.Where(x => x.BillId == id).Select(m => new BillingViewModel()
            {
                CategoryId=m.CategoryId,
                BrandId=m.BrandId,
                Quantity=m.Quantity,
                Price=m.Price
            }).ToListAsync();
            model.BillId = id;
            model.Name = await db.Billings.Where(a => a.BillId == id).Select(a => a.Name).FirstOrDefaultAsync();
            model.Total = await db.Billings.Where(b => b.BillId == id).Select(b => b.Total).FirstOrDefaultAsync();
            return model;
        }

        public async Task<bool> deleteBilling(int id)
        {
            var data =  await db.Billings.Where(x => x.BillId == id).FirstOrDefaultAsync();
            data.Status = false;
            db.Entry(data).State = EntityState.Modified;
            int res= await db.SaveChangesAsync();
            bool result = (res > 0) ? true : false;
            return result;
        }
    }
}
