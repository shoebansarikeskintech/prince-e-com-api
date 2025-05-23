﻿
using ViewModel;

namespace RepositoryContract
{
    public interface ISellerRepository
    {
        public Task<ResponseViewModel> getByIdSeller(Guid sellerId);
        public Task<ResponseViewModel> getAllSeller();
        public Task<ResponseViewModel> getAllSellerForUser();
        public Task<ResponseViewModel> addSeller(AddSellerViewModel addSeller);
        public Task<ResponseViewModel> updateSeller(UpdateSellerViewModel updateSeller);
        public Task<ResponseViewModel> deleteSeller(DeleteSellerViewModel deleteSeller);
    }
}
