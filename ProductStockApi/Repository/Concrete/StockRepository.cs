using ProductStockApi.Data.Model;
using ProductStockApi.ProductsApi;
using ProductStockApi.Repository;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ProductStockApi.Service
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;
        private ProductsList _list;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }
        public Stock AddStock(int id, int count)
        {
            try
            {
                var stock = new Stock();
                _list = new ProductsList();
                var products = _list.GetProducts();
                stock = _context.Stocks.Where(x => x.StockProductId == id).FirstOrDefault();
                foreach (var item in products)
                {
                    if (item.ProductId == id)
                    {
                        if (stock == null)
                        {
                            stock = new Stock();
                            stock.StockProductId = id;
                            stock.ProductCount = count;
                            _context.Stocks.Add(stock);
                            break;
                        }
                        else if (stock != null)
                        {
                            //stock = _context.Stocks.Where(x => x.ProductId == id).FirstOrDefault();
                            stock.ProductCount += count;
                            _context.Stocks.Update(stock);
                            break;
                        }
                    }
                }
                _context.SaveChanges();
                return stock;
            }
            catch (InvalidProductIdException ex)
            {
                Log.Error(ex.Message);
                throw new InvalidProductIdException();
            }
        }
        public Stock RemoveStock(int id, int count)
        {
            try {
                _list = new ProductsList();
                var stock = new Stock();
                stock = _context.Stocks.Where(x => x.StockProductId == id).FirstOrDefault();
                var products = _list.GetProducts();
                foreach (var item in products)
                {
                    if (item.ProductId == id)
                    {
                        if (stock == null)
                        {
                            throw new ProductNotFountException("Product is not found on stock");
                        }
                        else if (stock != null)
                        {
                            if (count > stock.ProductCount)
                            {
                                throw new OutOfException();
                            }
                            stock.ProductCount -= count;
                            _context.Stocks.Update(stock);
                            _context.SaveChanges();
                            break;
                        }
                    }                  
                }
                return stock;
            }
            catch(ProductNotFountException ex) 
            {
                Log.Error(ex.Message);
                throw new ProductNotFountException();
            }
            catch(OutOfException ex)
            {
                Log.Error(ex.Message);
                throw new OutOfException();
            }
            catch(InvalidProductIdException ex)
            {
                Log.Error(ex.Message);
                throw new InvalidProductIdException();
            }
        }

        
        public Stock GetStock(int id)
        {
            try
            {
                var stock = new Stock();
                stock = _context.Stocks.Where(x => x.StockProductId == id).FirstOrDefault();
                return stock;
            }
            catch (InvalidProductIdException ex)
            {
                Log.Error(ex.Message);
                throw new InvalidProductIdException();
            }
        }
    }
}
