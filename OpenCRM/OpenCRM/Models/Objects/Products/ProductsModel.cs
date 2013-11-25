﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OpenCRM.Controllers.Session;
using OpenCRM.DataBase;
using OpenCRM.Models.Settings;
using OpenCRM.Views.Objects.Contacts;
using OpenCRM.Views.Objects.Products;

namespace OpenCRM.Models.Objects.Products
{
    public class ProductsModel
    {
        #region Variables
        public static bool IsNew { get; set; }
        public static bool IsEditing { get; set; }
        public static bool IsSearching { get; set; }

        public ProductsData Data { get; set; }
        #endregion

        #region Constructores


        public ProductsModel()
        {
            this.Data = new ProductsData();
        }
      

        #endregion

        #region Methods

        #region Load Products DataGrid

        public void LoadRecentProduts(DataGrid RecentProductsGrid)
        {
            var listProducts = new List<DataGridRecentProducts>();
            try
            {
                using (var _db = new OpenCRMEntities())
                {
                    var query =
                    (
                        from products in _db.Products
                        select
                         new DataGridRecentProducts()
                         {
                             Nombre = products.Name,
                             Codigo = products.Code,
                             Description = products.Description

                         }

                    ).ToList();


                    listProducts = query;
                }
            }
            catch (Exception)
            {

                throw;
            }

            listProducts.ForEach(x => x.Nombre = x.Nombre.PadRight(100));
            listProducts.ForEach(x => x.Codigo = x.Codigo.PadRight(50));
            RecentProductsGrid.ItemsSource = listProducts;
        }
        #endregion

        #region Save

        public void Save(CreateProduct createProduct)
        {
            this.Data.name = createProduct.TxtBoxName.Text;
            this.Data.code = createProduct.TxtBoxCodigo.Text;
            this.Data.description = createProduct.TxtBoxDescripcion.Text;

            int value;
            if (Int32.TryParse(createProduct.TxtBoxQuantity.Text, out value))
                this.Data.quantity = value;

            int precio;
            if (Int32.TryParse(createProduct.TxtBoxPrecio.Text, out precio))
                this.Data.price = precio;

         
            this.Data.createby = Session.UserId;
            this.Data.createdate = DateTime.Now;
            this.Data.updateby = Session.UserId;
            this.Data.updatedate = DateTime.Now;
            this.Data.active = createProduct.cbxCampaignActive.IsChecked.Value;
   

            this.Save();
        }

        private void Save()
        {
            try
            {
                using (var _db = new OpenCRMEntities())
                {
                    DataBase.Products product = null;

                    if (IsNew)
                    {
                        product = _db.Products.Create();
                    }
                    if (IsEditing)
                    {
                        product = _db.Products.FirstOrDefault(x => x.ProductId == this.Data.productId);
                    }

                    product.Name = this.Data.name;
                    product.Code = this.Data.code;
                    product.Description = this.Data.description;
                    product.Quantity = this.Data.quantity;
                    product.Price = this.Data.price;
                    product.User = _db.User.FirstOrDefault(x=>x.UserId == this.Data.createby);
                    product.CreateDate = this.Data.createdate;
                    product.User1 = _db.User.FirstOrDefault(x => x.UserId == this.Data.updateby);
                    product.UpdateDate = this.Data.updatedate;
                    product.Active = this.Data.active;

                    if (IsNew)
                    {
                        _db.Products.Add(product);
                    }

                    _db.SaveChanges();
                    MessageBox.Show("Producto Guardado con Exito");
                    PageSwitcher.Switch("/Views/Objects/Products/ProductsView.xaml");

                }
            }
            catch (Exception exe)
            {
                
                MessageBox.Show(exe.ToString());
            }
        }


        #endregion

        #region Edit

        public void LoadEditProducts(EditContacts EditProducts)
        {
            
        }

        #endregion


        #endregion

    }

    class DataGridRecentProducts
    {
        #region Properties
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Description { get; set; }
        #endregion
    }

    public class ProductsData
    {
        #region Properties

        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public int createby { get; set; }
        public DateTime createdate { get; set; }
        public int updateby { get; set; }
        public DateTime updatedate { get; set; }
        public bool hiddenproduct { get; set; }
        public string code { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        #endregion
    }
        
}
    

