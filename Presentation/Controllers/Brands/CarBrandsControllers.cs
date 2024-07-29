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
    public sealed class CarBrandsControllers : BaseController
    {
        public CarBrandsControllers(ISender sender) : base(sender){}

        [HttpGet("car")]
        public async Task<ActionResult<List<Brand>>> GetAllCars(CancellationToken cancellationToken)
        {
            try
            {
                // Crear una consulta para obtener marcas de coches del tipo 'Car'.
                var query = new GetCarBrandsQuery(BrandType.Car);

                // Enviar la consulta usando el mediador y esperar el resultado.
                Result<List<Brand>> result = await Sender.Send(query, cancellationToken);

                // Devolver la lista de marcas de coches con un estado HTTP 200 OK.
                return Ok(result.Value);

            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, devolver un estado HTTP 400 Bad Request con el mensaje de error.
                return BadRequest(ex.Message);
            }
        }

        // Punto de entrada GET /car/{name} para recuperar marcas de coches por nombre.
        [HttpGet("car/{name}")]
        public async Task<ActionResult<List<Brand>>> GetByName(string name,CancellationToken cancellationToken)
        {
            // Validar que el parámetro name no sea nulo o vacío.
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("El nombre de la marca no puede estar vacío.");
            }

            try
            { // Crear una consulta para obtener marcas de coches por nombre.
                var query = new GetCarBrandsByNameQuery(name);

                // Enviar la consulta usando el mediador y esperar el resultado.
                Result<List<Brand>> result = await Sender.Send(query, cancellationToken);

                // Si el resultado es exitoso y contiene valores, devolverlos con un estado HTTP 200 OK.
                if (result.IsSuccess && result.Value != null)
                {
                    return Ok(result.Value);
                }
                else
                {
                    // Si no se encuentran marcas, devolver un estado HTTP 404 Not Found.
                    return NotFound("No se encontraron marcas de coches con el nombre especificado.");
                }

            }
            catch (Exception ex)
            {
                // Registrar la excepción aquí (no implementado en este ejemplo).
                // Si ocurre una excepción, devolver un estado HTTP 400 Bad Request con el mensaje de error.
                return BadRequest(ex.Message);
            }
        }
    }
}
