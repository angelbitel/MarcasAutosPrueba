using Application.Brands.Queries.GetCarBrands;
using Application.Brands.Queries.GetCarBrandsByName;
using Domain.Entities;
using Domain.Enum;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers.Brands
{
    [Route("api/brands")]
    public sealed class BrandsControllers : BaseController
    {
        public BrandsControllers(ISender sender) : base(sender)
        {
        }

        [HttpGet("car")]
        public async Task<ActionResult<List<Brand>>> GetAllCars(CancellationToken cancellationToken)
        {
            try
            {
            var query = new GetCarBrandsQuery(BrandType.Car);

            Result<List<Brand>> result = await Sender.Send(query, cancellationToken);

            return Ok(result.Value);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("car/{name}")]
        public async Task<ActionResult<List<Brand>>> GetByName(string name,CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetCarBrandsByNameQuery(name);

                Result<List<Brand>> result = await Sender.Send(query, cancellationToken);

                return Ok(result.Value);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
