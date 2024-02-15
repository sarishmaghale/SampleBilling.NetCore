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
                    int PayableAmount = 0;
                    int Amount = 0;
                    foreach (var item in billings.Details)
                    {
                        if (item != null)
                        {
                            TotalAmount = (int)(TotalAmount + (item.Quantity * item.Price));
                           Amount = TotalAmount;
                            PayableAmount = TotalAmount;
                        }
                        
                    }
                    if (billings.Discount != null)
                    {
                        Amount =(int) (billings.Discount * TotalAmount) / 100;
                        PayableAmount = PayableAmount - Amount;
                    }
                    Billing data1 = new Billing()
                    {
                        Name = billings.Name,
                        Total = TotalAmount,
                        Status = true,
                        BillingDate= TodayDate,
                       Phone=billings.Phone,
                       Discount=billings.Discount??0,
                       PayableAmt=PayableAmount,
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
                                CategoryId =DetailData.CategoryId,
                                Quantity = DetailData.Quantity,
                                Price = DetailData.Price
                            };
                            await db.BillingDetails.AddAsync(data2);
                            await db.SaveChangesAsync();
                            int BrdId = DetailData.BrandId;
                            var EditSales = db.SalesAndStocks.Where(x => x.BrandId == BrdId).FirstOrDefault();
                            if (EditSales != null)
                            {
                                EditSales.TotalSales += data2.Quantity;
                                EditSales.LeftStocks -= data2.Quantity;
                            }
                            db.Entry(EditSales).State = EntityState.Modified;
                            await db.SaveChangesAsync();

                        }
                    }
                    //var CustomerData=await db.Customers.Where(x => x.CustomerPhone == billings.Phone).FirstOrDefaultAsync();
                    //if (CustomerData != null)
                    //{
                    //    CustomerData.CustomerName = billings.Name;
                    //    CustomerData.Points=Cus
                    //    db.Entry(CustomerData).State = EntityState.Modified;
                    //    await db.SaveChangesAsync();
                    //}
                    //else
                    //{
                    //    Customer customers = new Customer()
                    //    {
                    //        CustomerName = billings.Name,
                    //        CustomerPhone = billings.Phone,
                    //        Points = 1;
                    //    }
                    //}
                   
                   
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
           BillingDate=x.BillingDate,
           PayableAmt=x.PayableAmt,
           Discount=x.Discount

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
                Price=m.Price??0
            }).ToListAsync();
            model.BillId = id;
            model.Name = await db.Billings.Where(a => a.BillId == id).Select(a => a.Name).FirstOrDefaultAsync();
            model.Total = await db.Billings.Where(b => b.BillId == id).Select(b => b.Total).FirstOrDefaultAsync();
            model.PayableAmt = await db.Billings.Where(c => c.BillId == id).Select(c => c.PayableAmt).FirstOrDefaultAsync();
            model.Discount = await db.Billings.Where(d => d.BillId == id).Select(d => d.Discount).FirstOrDefaultAsync();
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
