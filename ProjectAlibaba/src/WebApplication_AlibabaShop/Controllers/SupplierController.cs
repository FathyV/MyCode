using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupplierReference;
using System.ServiceModel;
using CommonReference;
using WebApplication_AlibabaShop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_AlibabaShop.Controllers
{
    public class SupplierController : Controller
    {
        SupplierServicesClient svcClient = new SupplierServicesClient();
        CommonServicesClient commonSvc = new CommonServicesClient();

        IHostingEnvironment env;
        public SupplierController(IHostingEnvironment env)
        {
            this.env = env;
        }
        #region Order Accept/Abort/Finish
        /// <summary>
        /// Change the status of the order from Pending to Processing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AcceptOrder(Guid id)
        {
            //calling service
            bool isAccepted = await svcClient.confirmOrderAsync(id);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> AbortOrder(Guid id)
        {
            //calling service
            bool isAccepted = await svcClient.abortOrderAsync(id);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> FinishOrder(Guid id)
        {
            //calling service
            bool isAccepted = await svcClient.finishOrderAsync(id);
            return RedirectToAction("OrderList");
        }
        #endregion

        #region Handle Quotation
        public async Task<IActionResult> HandleQuotation(Guid id)
        {
            //Go to the control
            vw_SupplierQuotation quotation = await svcClient.getQuotationByIdAsync(id);
            return View(quotation);
        }

        public async Task<IActionResult> SendBackQuotation(vw_SupplierQuotation model)
        {
            //Go to the control
            SupplierReference.Quotation quotation = new SupplierReference.Quotation();
            vw_SupplierQuotation q = await svcClient.getQuotationByIdAsync(model.Id);
            quotation.Id = model.Id;
            quotation.Product_Id = q.Product_Id;
            quotation.Supplier_Id = q.Supplier_Id;
            quotation.WholeSaler_Id = q.WholeSaler_Id;
            quotation.UnitMeasure_Id = q.UnitMeasure_Id;
            quotation.Qty = q.Qty;
            quotation.Message = q.Message;
            quotation.FileAttachment = q.FileAttachment;
            quotation.UnitPrice = model.UnitPrice;
            quotation.TaxAmount = model.TaxAmount;
            quotation.SubTotal = model.SubTotal;
            quotation.Total = model.Total;
            quotation.RequestDate = q.RequestDate;
            quotation.Status = (byte)1;
            await svcClient.handleQuotationAsync(quotation);
            return RedirectToAction("QuotationList");
        }
        #endregion

        #region Supplier & Contact Update
        public async Task<IActionResult> SupplierInfo()
        {
            HttpContext.Session.SetString("Id", "79DC9265-13CE-41D8-8820-21AB83BF899A");
            SupplierReference.Country[] cts = await svcClient.getCountryListAsync();
            SupplierReference.Ownership[] owns = await svcClient.getOwnershipListAsync();
            SupplierInfoViewModel viewModel = new SupplierInfoViewModel();
            viewModel.supplierInfo = await svcClient.getSupplierInfoAsync(new Guid(HttpContext.Session.GetString("Id")));
            viewModel.contactInfo = await svcClient.getContactAsync(new Guid(HttpContext.Session.GetString("Id")));
            viewModel.lstOwnership = owns.ToList();
            viewModel.lstCountry = cts.ToList();
            return View(viewModel);
        }
        public async Task<IActionResult> UpdateInfo()
        {
            HttpContext.Session.SetString("Id", "79DC9265-13CE-41D8-8820-21AB83BF899A");
            SupplierReference.Country[] cts = await svcClient.getCountryListAsync();
            SupplierReference.Ownership[] owns = await svcClient.getOwnershipListAsync();
            SupplierInfoViewModel viewModel = new SupplierInfoViewModel();
            viewModel.supplierInfo = await svcClient.getSupplierInfoAsync(new Guid(HttpContext.Session.GetString("Id")));
            viewModel.contactInfo = await svcClient.getContactAsync(new Guid(HttpContext.Session.GetString("Id")));
            viewModel.lstOwnership = owns.ToList();
            viewModel.lstCountry = cts.ToList();
            return View(viewModel);
        }

        public async Task<IActionResult> UpdateContact(SupplierInfoViewModel model)
        {
            await svcClient.updateContactAsync(model.contactInfo);
            return RedirectToAction("SupplierInfo");
        }

        public async Task<IActionResult> UpdateSupplier(SupplierInfoViewModel model, IList<IFormFile> files)
        {
            string rootpath = env.WebRootPath + @"\images\supplier\";
            string imageName = "";
            foreach (var file in files)
            {
                string[] lstPath = file.FileName.Split('\\');

                string filename = lstPath[lstPath.Length - 1];

                using (FileStream fs = System.IO.File.Create(rootpath + filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                imageName = filename;
                break;
            }
            if (imageName != "") model.supplierInfo.Logo = imageName;
            await svcClient.updateSupplierInfoAsync(model.supplierInfo);
            return RedirectToAction("SupplierInfo");
        }
        #endregion


        public async Task<IActionResult> Index()
        {
            SupplierIndexViewModel indexView = new SupplierIndexViewModel();

            #region Save Supplier Info in Session
            HttpContext.Session.SetString("Id", "79DC9265-13CE-41D8-8820-21AB83BF899A");
            vw_SupplierInfo s = await svcClient.getSupplierInfoAsync(new Guid(HttpContext.Session.GetString("Id")));
            HttpContext.Session.SetString("Name", s.Supplier_Name);
            HttpContext.Session.SetString("Logo", s.Logo);
            #endregion

            #region Loading Report
            #endregion


            #region Other component for index view
            vw_SupplierOrder[] lstOrder = await svcClient.getSupplierOrderListAsync(new Guid(HttpContext.Session.GetString("Id")));
            vw_SupplierQuotation[] lstQuotation = await svcClient.getSupplierQuotationAsync(new Guid(HttpContext.Session.GetString("Id")));
            vw_SupplierProducts[] lstProduct = await svcClient.viewProductListAsync(new SupplierReference.Supplier()
            {
                Id = new Guid(HttpContext.Session.GetString("Id"))
            });

            indexView.orderCollection = lstOrder.ToList();
            indexView.pendingQuotation = lstQuotation.ToList();
            indexView.topProduct = lstProduct.ToList();

            indexView.totalOrder = lstOrder.ToList().Count;
            indexView.totalProduct = lstProduct.ToList().Count;
            indexView.totalQuotation = lstQuotation.ToList().Count;

            foreach(vw_SupplierOrder order in lstOrder.ToList())
            {
                indexView.totalRevenue += (int)order.TotalPaid;
            }
            #endregion

            return View(indexView);
        }



        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            SupplierReference.Product p = await svcClient.getProductByIdAsync(id);
            p.Status = (byte)2;
            await svcClient.changeProductInfoAsync(p);
            return RedirectToAction("ProductDetails", id);
        }

        public async Task<IActionResult> UpdateProductImage(String id, IList<IFormFile> files)
        {
            Guid productId = new Guid(id);
            SupplierReference.Product p = await svcClient.getProductByIdAsync(productId);

            //save the image
            string rootpath = env.WebRootPath + @"\images\supplier\";
            string imageName = "";
            foreach (var file in files)
            {
                string[] lstPath = file.FileName.Split('\\');

                string filename = lstPath[lstPath.Length - 1];

                using (FileStream fs = System.IO.File.Create(rootpath + filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                imageName = filename;
                break;
            }
            p.Image = imageName;
            //Update database
            await svcClient.changeProductInfoAsync(p);
            return RedirectToAction("ProductDetails", new RouteValueDictionary(new { controller = "supplier", action = "ProductDetails", Id = productId }));
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="model"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<IActionResult> SaveProduct(SupplierProductDetailsViewModel model, IList<IFormFile> files)
        {
            vw_SupplierProducts supplierProduct = model.product;

            string rootpath = env.WebRootPath + @"\images\supplier\";
            string imageName = "";
            foreach (var file in files)
            {


                string[] lstPath = file.FileName.Split('\\');

                string filename = lstPath[lstPath.Length - 1];

                using (FileStream fs = System.IO.File.Create(rootpath + filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                imageName = filename;
                break;
            }


            SupplierReference.Product p = new SupplierReference.Product()
            {
                Id = Guid.NewGuid(),
                Name = supplierProduct.ProductName,
                Description = supplierProduct.Description,
                Supplier_Id = new Guid(HttpContext.Session.GetString("Id")),
                Category_Id = supplierProduct.Category_Id,
                Price = supplierProduct.Price,
                MinimumOrder = supplierProduct.MinimumOrder,
                MaximumOrder = supplierProduct.MaximumOrder,
                QtyInHand = supplierProduct.QtyInHand,
                Status = (byte)0,
                PostDate = DateTime.Today,
                Image = imageName,
                Discount = supplierProduct.Discount
            };

            bool isCreated = await svcClient.newProductAsync(p);

            return RedirectToAction("ProductList");
        }

        /// <summary>
        /// Move to add product form
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddProduct()
        {
            SupplierProductDetailsViewModel model = new SupplierProductDetailsViewModel();
            vw_Category[] lstCategory = await commonSvc.getVwCategoryAsync();
            model.categories = lstCategory.ToList();
            return View(model);
        }

        public async Task<IActionResult> ProductDetails(Guid id)
        {
            vw_SupplierProducts product = await svcClient.getProductDetailsAsync(id);
            vw_SupplierFeedback[] lstFb = await svcClient.getFeedbackListAsync(id);
            vw_SupplierOrder[] lstOrder = await svcClient.getOrderListAsync(id);
            vw_SupplierQuotation[] lstQuotation = await svcClient.getQuotationListByProductAsync(id);
            vw_Category[] lstCategory = await commonSvc.getVwCategoryAsync();
            SupplierProductDetailsViewModel productViewModel = new SupplierProductDetailsViewModel();
            productViewModel.product = product;
            productViewModel.feedbacks = lstFb.ToList();
            productViewModel.orders = lstOrder.ToList();
            productViewModel.quotations = lstQuotation.ToList();
            productViewModel.categories = lstCategory.ToList();
            return View(productViewModel);
        }

        public async Task<IActionResult> UpdateProduct(SupplierProductDetailsViewModel model)
        {
            vw_SupplierProducts pro = model.product;
            SupplierReference.Product updateProduct = new SupplierReference.Product()
            {
                Id = pro.Id,
                Supplier_Id = pro.Supplier_Id,
                Category_Id = pro.Category_Id,
                Name = pro.ProductName,
                Description = pro.Description,
                Price = pro.Price,
                MinimumOrder = pro.MinimumOrder,
                MaximumOrder = pro.MaximumOrder,
                QtyInHand = pro.QtyInHand,
                Views = pro.Views,
                PostDate = pro.PostDate,
                Image = pro.Image
            };

            if (pro.QtyInHand == 0) pro.Status = (Byte)1;
            else
                pro.Status = (Byte)0;

            bool isUpdated = await svcClient.changeProductInfoAsync(updateProduct);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> OrderList()
        {
            try
            {
                SupplierReference.Supplier s = new SupplierReference.Supplier();
                //s.Id = new Guid("79DC9265-13CE-41D8-8820-21AB83BF899A");
                s.Id = new Guid(HttpContext.Session.GetString("Id"));
                //Lay ra danh sach don hang dua theo supplier
                vw_SupplierOrder[] lst = await svcClient.getSupplierOrderListAsync(s.Id);
                return View(lst);
            }
            catch (FaultException<SupplierReference.AlibabaShopFaultedException> ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> QuotationList()
        {
            try
            {
                SupplierReference.Supplier s = new SupplierReference.Supplier();
                //s.Id = new Guid("79DC9265-13CE-41D8-8820-21AB83BF899A");
                s.Id = new Guid(HttpContext.Session.GetString("Id"));
                //Lay ra danh sach quotation dua theo supplier
                vw_SupplierQuotation[] lst = await svcClient.getSupplierQuotationAsync(s.Id);
                return View(lst);
            }
            catch (FaultException<SupplierReference.AlibabaShopFaultedException> ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> ProductList()
        {
            try
            {
                SupplierReference.Supplier s = new SupplierReference.Supplier();
                //s.Id = new Guid("79DC9265-13CE-41D8-8820-21AB83BF899A");
                s.Id = new Guid(HttpContext.Session.GetString("Id"));
                vw_SupplierProducts[] lst = await svcClient.viewProductListAsync(s);
                return View(lst);
            }
            catch (FaultException<SupplierReference.AlibabaShopFaultedException> ex)
            {
                throw ex;
            }
        }
    }
}
