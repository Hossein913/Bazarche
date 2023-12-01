using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace App.Domain.AppServices.Product
{
    public class CommentAppServices : ICommentAppServices
    {
        protected readonly ICommentServices _commentServices;

        public CommentAppServices(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        public async Task Create(CommentCreateDto comment, CancellationToken cancellationToken)
        {
            _commentServices.Create(comment,cancellationToken);
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentOutputDto>> GetAllCustomer(int CustomerId, CancellationToken cancellationToken)
        {
            var result = await _commentServices.GetAllCustomer(CustomerId, cancellationToken);
            return result;
        }

        public async Task<List<CommentOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentOutputDto>> GetAllForConfirm(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
        {
            var result = await _commentServices.GetAllForProduct(ProductId, cancellationToken);
            return result;
        }

        public async Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken)
        {
            var result = await _commentServices.GetDetail(commentId, cancellationToken);
            return result;
        }

        public async Task HardDeleted(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int commentId, CancellationToken cancellationToken)
        {
            await _commentServices.SoftDelete(commentId, cancellationToken);
        }

        public async Task Update(CommentUpdateDto commentDto, CancellationToken cancellationToken)
        {
            await _commentServices.Update(commentDto, cancellationToken);
        }
    }
}
