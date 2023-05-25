using System;
using Data_Access_Layer;
using Data_Access_Layer.Context;

namespace Business_Logic_Layer.ViewModel
{
    public class RapairBLL
    {
        private readonly RepairDAL _RepairDAL;

        public RapairBLL()
        {
            _RepairDAL = new RepairDAL();
        }

        public async Task<RapairModel> AddProduct(RapairModel product)
        {
            RepairEntityModel formaat = new RepairEntityModel()
            {
               _id = Guid.NewGuid(),
                aard = product.aard,
                calibernummer = product.calibernummer,
                customerId = product.customerId,
                gender = product.gender,
                typeBand = product.typeBand,
                kastnummer = product.kastnummer,
                kenmerk = product.kenmerk,
                mechanism = product.mechanism,
                material = product.material,
                merk = product.merk,
                serienummer = product.serienummer,
                status = product.status,
                wachtMakers = product.wachtMakers,
                name = product.name,

            };
            await _RepairDAL.CreateProduct(formaat);

            return product;
        }

        public async Task<IEnumerable<RapairModel>> GetProducts()
        {
            var products = await _RepairDAL.GetProducts();

            return products.Select(product => new RapairModel
            {
               _id = product._id,
                aard = product.aard,
                calibernummer = product.calibernummer,
                gender = product.gender,
                typeBand = product.typeBand,
                kastnummer = product.kastnummer,
                kenmerk = product.kenmerk,
                mechanism = product.mechanism,
                material = product.material,
                merk = product.merk,
                serienummer = product.serienummer,
                status = product.status,
                wachtMakers = product.wachtMakers,
                name = product.name,
                customerId = product.customerId
            });
        }

        public async Task<RapairModel> GetProductById(Guid id)
        {
            var product = await _RepairDAL.GetProductById(id);

            if (product == null)
            {
                return null;
            }

            return new RapairModel
            {
               _id= product._id,
                aard = product.aard,
                calibernummer = product.calibernummer,
                gender = product.gender,
                typeBand = product.typeBand,
                kastnummer = product.kastnummer,
                kenmerk = product.kenmerk,
                mechanism = product.mechanism,
                material = product.material,
                merk = product.merk,
                serienummer = product.serienummer,
                status = product.status,
                wachtMakers = product.wachtMakers,
                name = product.name,
            };
        }

        public async Task<RapairModel> UpdateProduct(Guid id, RapairModel product)
        {
            var existingProduct = await _RepairDAL.GetProductById(id);

            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.name = product.name;
            existingProduct.customerId = product.customerId;
            existingProduct.aard = product.aard;
            existingProduct.calibernummer = product.calibernummer;
            existingProduct.gender = product.gender;
            existingProduct.typeBand = product.typeBand;
            existingProduct.kastnummer = product.kastnummer;
            existingProduct.kenmerk = product.kenmerk;
            existingProduct.mechanism = product.mechanism;
            existingProduct.material = product.material;
            existingProduct.wachtMakers = product.wachtMakers;
            existingProduct.merk = product.merk;
            existingProduct.serienummer = product.serienummer;
            existingProduct.status = product.status;

            try
            {
                await _RepairDAL.UpdateProduct();
            }
            catch (Exception ex)
            {
                return null;
            }

            return new RapairModel
            {
                name = existingProduct.name,
                wachtMakers = existingProduct.wachtMakers,
               _id = existingProduct._id,
                aard = existingProduct.aard,
                calibernummer = existingProduct.calibernummer,
                gender = existingProduct.gender,
                typeBand = existingProduct.typeBand,
                kastnummer = existingProduct.kastnummer,
                kenmerk = existingProduct.kenmerk,
                mechanism = existingProduct.mechanism,
                material = existingProduct.material,
                merk = existingProduct.merk,
                serienummer = existingProduct.serienummer,
                status = existingProduct.status,
                customerId = existingProduct.customerId
            };
        }

        public async Task<bool> UpdateStatus(Guid id, string status)
        {
            var updatedStatus = await _RepairDAL.UpdateStatus(id, status);

            if (UpdateStatus == null)
            {
                return false;
            }

            return true;
        }
        public async Task<RapairModel> DeleteProduct(Guid id)
        {
            var existingProduct = await _RepairDAL.GetProductById(id);

            if (existingProduct == null)
            {
                return null;
            }

            try
            {
                await _RepairDAL.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return null;
            }

            return new RapairModel
            {
                aard = existingProduct.aard,
                calibernummer = existingProduct.calibernummer,
                gender = existingProduct.gender,
                typeBand = existingProduct.typeBand,
                kastnummer = existingProduct.kastnummer,
                kenmerk = existingProduct.kenmerk,
                mechanism = existingProduct.mechanism,
                material = existingProduct.material,
                merk = existingProduct.merk,
                serienummer = existingProduct.serienummer,
                status = existingProduct.status,
                customerId = existingProduct.customerId
            };
        }


    }
}

