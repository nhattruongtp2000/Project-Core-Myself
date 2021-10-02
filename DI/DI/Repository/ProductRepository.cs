﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using DI.DI.Interace;
using Data.DB;
using ViewModel.ViewModels;
using Data.Data;
using Microsoft.AspNetCore.Http;
using ViewModel;
using Microsoft.AspNetCore.Identity;

namespace DI.DI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Iden2Context _iden2Context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductRepository (Iden2Context iden2Context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IHttpContextAccessor httpContextAccessor)
        {
            _iden2Context = iden2Context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Create(ProductCreateVm request)
        {
            var c =await UpLoadFile(request.PhotoReview);

            var product = new Product()
            {
                DateAccept = request.DateAccept,
                IdBrand = request.IdBrand,
                ProductName = request.ProductName,
                UseVoucher = request.UseVoucher,
                IdCategory=request.IdCategory,
                IsFree=false,
                Price=request.Price,
                PhotoReview = c
            };
             _iden2Context.Products.Add(product);
            return await _iden2Context.SaveChangesAsync();
        }

        public async Task<int> Delete(int IdProduct)
        {
            var product = await _iden2Context.Products.FirstOrDefaultAsync(x => x.IdProduct == IdProduct);
            _iden2Context.Products.Remove(product);
            return await _iden2Context.SaveChangesAsync();
        }

        public async Task<int> Edit(int IdProduct,ProductVm request)
        {
            var product = await _iden2Context.Products.FirstOrDefaultAsync(x => x.IdProduct == IdProduct);

            product.DateAccept = request.DateAccept;
            product.IdBrand = request.IdBrand;
            product.ProductName = request.ProductName;
            product.UseVoucher = request.UseVoucher;

            await _iden2Context.SaveChangesAsync();
            return product.IdBrand;
           
        }

        public async Task<List<ProductVm>> GetAll()
        {
            var products = _iden2Context.Products;
        

            var a =await products.Select(x => new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                IdBrand = x.IdBrand,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                PhotoReview = x.PhotoReview,
                IdCategory=x.IdCategory,
                IsFree=x.IsFree,
                Price=x.Price
            }).ToListAsync();
            return a;
        }

        public async Task<List<ProductVm>> GetNewProduct()
        {
            var products = _iden2Context.Products;


            var a = await products.Select(x => new ProductVm() 
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                IdBrand = x.IdBrand,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                PhotoReview = x.PhotoReview,
                Price=x.Price
            }).OrderBy(x=>x.IdProduct).ToListAsync();
            return a;
        }

        public async Task<ProductVm> GetProduct(int IdProduct)
        {
            var product =await _iden2Context.Products.FirstOrDefaultAsync(x => x.IdProduct == IdProduct);
            var a = new ProductVm()
            {
                IdProduct = product.IdProduct,
                DateAccept = product.DateAccept,
                IdBrand = product.IdBrand,
                ProductName = product.ProductName,
                UseVoucher = product.UseVoucher,
                IdCategory=product.IdCategory,
                Price=product.Price
                
            };
            return a;
        }

        public async Task<List<ProductVm>> GetProductPerCategory(int IdCategory)
        {

            var x = _iden2Context.Products.Where(x => x.IdCategory == IdCategory);
            var a = await x.Select(x => new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                PhotoReview = x.PhotoReview,
                IdBrand = x.IdBrand,
                IdCategory = x.IdCategory,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                Price=x.Price
            }).ToListAsync();
            return a;
        }

        public async Task<List<ProductVm>> Search(string key)
        {
            var products =  _iden2Context.Products.Where(x => x.ProductName.Contains(key));

            var a=await products.Select(x=> new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                IdBrand = x.IdBrand,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                Price=x.Price,
                IdCategory=x.IdCategory,
                PhotoReview=x.PhotoReview
            }).ToListAsync();

            return a;
        }

        public async Task<string> UpLoadFile(IFormFile fromFile)
        {
            if(fromFile == null || fromFile.Length == 0)
            {
                return null; 
            }

            var path = Path.Combine("wwwroot", "Images", fromFile.FileName);

            using(var stream = new FileStream(path,FileMode.Create))
            {
                await fromFile.CopyToAsync(stream);
            }
            return path.Substring(8);
        }

        public async Task<int> AddImages(int IdProduct, List<IFormFile> request)
        {

            if (request == null || request.Count == 0)
            {
                return 0;
            }

            foreach (var file in request)
            {
                var path = Path.Combine("wwwroot", "Images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var b = new ProductPhoto()
                {
                    IdProduct = IdProduct,
                    IFromFile = path.Substring(8)
                };
                _iden2Context.ProductPhotos.Add(b);               
            }
            await _iden2Context.SaveChangesAsync();
            return 1;
        }

        public async Task<ProductDetailsVm> GetProductDetail(int IdProduct)
        {
            var photos = _iden2Context.ProductPhotos.Where(x => x.IdProduct == IdProduct);
            List<string> linkPhotos =await photos.Select(x => x.IFromFile).ToListAsync();

            var product = await _iden2Context.Products.FirstOrDefaultAsync(x => x.IdProduct == IdProduct);
            var commemt =  _iden2Context.Comments.Where(x => x.IdProduct == IdProduct);
            var commentvm = await commemt.Select(x => new CommentVm() 
            {
            Content=x.Content,
            IdProduct=x.IdProduct,
            UserName=x.UserName
             
            }).ToListAsync();

            var relateProduct = await RelatedProduct(product.IdBrand,IdProduct);

            var a = new ProductDetailsVm()
            {
                IdProduct = product.IdProduct,
                DateAccept = product.DateAccept,
                IdBrand = product.IdBrand,
                ProductName = product.ProductName,
                UseVoucher = product.UseVoucher,
                IdCategory = product.IdCategory,
                PhotoReview = product.PhotoReview,
                ListPhotos = linkPhotos,
                RelatedProducts=relateProduct,
                Price=product.Price,
                Comments=commentvm
            };
            return a;
        }

        public async Task<List<ProductVm>> Filters(int pricemin, int pricemax)
        {
            var a = _iden2Context.Products.Where(x => x.Price >= pricemin && x.Price <= pricemax);
            var b = await a.Select(x => new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                IdBrand = x.IdBrand,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                PhotoReview = x.PhotoReview
            }).ToListAsync();
            return b;

        }

        public async Task<int> AddComment(int IdProduct,string Content)
        {
            var User =await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            string UserName = User.UserName;
            var comment = new Comment()
            {
                Status = false,
                Content = Content,
                DatePost = DateTime.Now,
                IdProduct = IdProduct,
                UserName = UserName
            };
            _iden2Context.Comments.Add(comment);
            return await _iden2Context.SaveChangesAsync();
        }

        public async Task<List<ProductVm>> GetProductPerBrand(int IdBrand)
        {
            var x = _iden2Context.Products.Where(x => x.IdBrand == IdBrand);
            var a = await x.Select(x => new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                PhotoReview = x.PhotoReview,
                IdBrand = x.IdBrand,
                IdCategory = x.IdCategory,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                Price = x.Price
            }).ToListAsync();
            return a;
        }

        public async Task<List<ProductVm>> RelatedProduct(int IdBrand,int IdProduct)
        {
            var x = _iden2Context.Products.Where(x => x.IdBrand == IdBrand && x.IdProduct!=IdProduct);
            var a = await x.Select(x => new ProductVm()
            {
                IdProduct = x.IdProduct,
                DateAccept = x.DateAccept,
                PhotoReview = x.PhotoReview,
                IdBrand = x.IdBrand,
                IdCategory = x.IdCategory,
                ProductName = x.ProductName,
                UseVoucher = x.UseVoucher,
                Price = x.Price
            }).ToListAsync();
            return a;
        }






        //public async Task<List<Photos>> UploadFiles(ProductCreateVm request)
        //{
        //    List<Photos> a = new List<Photos>();
        //    if (request.FileToUpload == null || request.FileToUpload.Count == 0)
        //    {
        //        return null;
        //    }

        //    foreach (var file in request.FileToUpload)
        //    {
        //        var path = Path.Combine("wwwroot", "Images", file.FileName);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }
        //        var b = new Photos()
        //        {
        //            IdProduct = request.IdProduct,
        //            LinkImageFile = path.Substring(8)
        //        };
        //        a.Add(b);
        //        await _iden2Context.SaveChangesAsync();
        //    }
        //    return a;
        //}


    }
}
