using eShop.Models.DTO;
using eShop.Models.eShopDbModels;
using MediatR;

namespace eShop.Application.Queries;

public sealed record GetCatalogPagedQuery(int Page, int Limit) : IRequest<GenericPagedResponse<Catalog>>;
